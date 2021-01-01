FROM mcr.microsoft.com/dotnet/core/sdk:3.1
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
RUN dotnet build

# publish
WORKDIR /
RUN mkdir /release
WORKDIR /src/ZundokoSolution/Zundoko.Web
RUN dotnet publish -c Release -o /release

# deploy to heroku
WORKDIR /release
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Zundoko.Web.dll
