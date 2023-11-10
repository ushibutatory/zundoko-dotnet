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

namespace Zundoko.Lambda.List;

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
                        { "Access-Control-Allow-Methods", "OPTIONS, GET" }
                    },
                };

            case "GET":
                var album = provider.GetService<IAlbum>()
                    ?? throw new Exception($"Invalid configuration. [{nameof(IAlbum)}]");

                var songTitles = album.Songs.Select(song => song.GetType().Name);

                logger.LogDebug("SongTitles are {result}", JsonSerializer.Serialize(songTitles));

                return new APIGatewayProxyResponse
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    IsBase64Encoded = false,
                    Headers = new Dictionary<string, string> {
                        { "Content-Type", "application/json" },
                        { "Access-Control-Allow-Origin", "*" },
                    },
                    Body = JsonSerializer.Serialize(songTitles),
                };

            default:
                throw new Exception($"Not implemented Http method. {request.HttpMethod}");
        }
    }
}
