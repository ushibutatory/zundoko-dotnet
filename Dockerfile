FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /
RUN mkdir /src
RUN mkdir /src/ZundokoSolution
WORKDIR /
COPY ./src/ZundokoSolution src/ZundokoSolution

# build
WORKDIR /src/ZundokoSolution
ARG MY_NUGET_SOURCE
RUN echo ${MY_NUGET_SOURCE}
RUN dotnet restore -s https://api.nuget.org/v3/index.json -s ${MY_NUGET_SOURCE}
RUN dotnet build

# publish
WORKDIR /
RUN mkdir /release
WORKDIR /src/ZundokoSolution/Zundoko.Web
RUN dotnet publish -c Release -o /release

# deploy to heroku
WORKDIR /release
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Zundoko.Web.dll
