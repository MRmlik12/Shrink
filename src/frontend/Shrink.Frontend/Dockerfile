FROM mcr.microsoft.com/dotnet/sdk:5.0 AS dotnet-build
FROM node:14 AS node-build
WORKDIR /src

COPY *.sln .
COPY Shrink.Frontend/*.csproj ./Shrink.Frontend/
COPY Shrink.Frontend.Test/*.csproj ./Shrink.Test/
COPY Shrink.Frontend/. ./Shrink/
COPY Shrink.Frontend.Test/. ./Shrink.Frontend.Test/

RUN dotnet restore
RUN dotnet test
RUN dotnet build Shrink.Frontend -c Release ./out
RUN dotnet publish Shrink.Frontend -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=dotnet-build /app ./

EXPOSE 5000
ENTRYPOINT ["dotnet", "Shrink.dll"]