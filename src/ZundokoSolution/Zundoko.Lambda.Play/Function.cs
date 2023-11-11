using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Gozolop.Core.Aws.Lambda.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using Zundoko.Core;
using Zundoko.Core.Models.Abstracts;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Zundoko.Lambda.Play;

public class Function
{
    public APIGatewayProxyResponse FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
    {
        var provider = new Func<IServiceProvider>(() =>
        {
            var services = new ServiceCollection()
                .AddLogging(logging =>
                {
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Debug);
                    logging.AddProvider(new LambdaLoggerProvider(context));
                });

            services.SetupZundokoApplication();

            return services.BuildServiceProvider();
        })();

        var logger = provider.GetService<ILogger<Function>>()
            ?? throw new Exception($"Invalid configuration. [{nameof(ILogger<Function>)}]");
        logger.LogDebug("APIGatewayProxyRequest: {request}", JsonSerializer.Serialize(request));
        logger.LogDebug("ILambdaContext: {context}", JsonSerializer.Serialize(context));

        switch (request.HttpMethod)
        {
            case "OPTIONS":
                return new APIGatewayProxyResponse
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Headers = new Dictionary<string, string> {
                        { "Access-Control-Allow-Headers", "Content-Type" },
                        { "Access-Control-Allow-Origin", "*" },
                        { "Access-Control-Allow-Methods", "OPTIONS, POST" }
                    },
                };

            case "POST":
                var serializerOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                var args = JsonSerializer.Deserialize<Arguments>(request.Body, serializerOptions)
                    ?? throw new InvalidRequestException(request);
                var title = args.Title;

                if (string.IsNullOrEmpty(title))
                    throw new InvalidRequestException(request);

                var album = provider.GetService<IAlbum>()
                    ?? throw new Exception($"Invalid configuration. [{nameof(IAlbum)}]");

                if (!album.TryFindSong(title, out var song))
                    throw new InvalidRequestException(request);
                var house = provider.GetService<IHouse>()
                    ?? throw new Exception($"Invalid configuration. [{nameof(IHouse)}]");

                const int tryCount = 100;
                var result = house.Play(song, tryCount);

                logger.LogDebug("Result is {result}", JsonSerializer.Serialize(result));

                return new APIGatewayProxyResponse
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    IsBase64Encoded = false,
                    Headers = new Dictionary<string, string> {
                        { "Content-Type", "application/json" },
                        { "Access-Control-Allow-Origin", "*" },
                    },
                    Body = JsonSerializer.Serialize(result),
                };

            default:
                throw new Exception($"Not implemented Http method. {request.HttpMethod}");
        }
    }

    public class Arguments
    {
        public string? Title { get; set; } = string.Empty;
    }

    public class InvalidRequestException : Exception
    {
        public InvalidRequestException(APIGatewayProxyRequest request)
            : base($"Argument is invalid. [{request.Body}]")
        { }
    }
}
