FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /
RUN mkdir /src
RUN mkdir /src/ZundokoSolution
WORKDIR /
COPY ./src/ZundokoSolution src/ZundokoSolution

# build
WORKDIR /src/ZundokoSolution
ARG NUGET_SOURCE
ARG NUGET_USER
ARG NUGET_PASS
RUN dotnet nuget add source ${NUGET_SOURCE} -u ${NUGET_USER} -p ${NUGET_PASS} --store-password-in-clear-text
RUN dotnet restore
RUN dotnet build -c Release -o /app/build

# publish
FROM build AS publish
WORKDIR /src/ZundokoSolution/Zundoko.Web
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# run
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Zundoko.Web.dll"]
