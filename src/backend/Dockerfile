FROM mcr.microsoft.com/dotnet/sdk AS build
WORKDIR /src

COPY *.sln .
COPY Shrink/*.csproj ./Shrink/
COPY Shrink.Tests/*.csproj ./Shrink.Tests/
RUN dotnet restore

COPY Shrink/. ./Shrink/
COPY Shrink.Tests/. ./Shrink.Test/

RUN dotnet build -c Release -o ./out

WORKDIR /src
RUN dotnet test

RUN dotnet publish Shrink -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./

ENV ASPNETCORE_URLS=http://0.0.0.0:5000
ENV aes_key=MTIzMTIzMTIzMTIzMjEzMw==

EXPOSE 5000
ENTRYPOINT ["dotnet", "Shrink.dll"]
