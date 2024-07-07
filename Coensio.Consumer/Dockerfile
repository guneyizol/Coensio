FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Coensio.Consumer/Coensio.Consumer.csproj", "Coensio.Consumer/"]
COPY ["Coensio.Contract/Coensio.Contract.csproj", "Coensio.Contract/"]
RUN dotnet restore "./Coensio.Consumer/Coensio.Consumer.csproj"
COPY . .
WORKDIR "/src/Coensio.Consumer"
RUN dotnet build "./Coensio.Consumer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM mcr.microsoft.com/dotnet/runtime:8.0
USER app
WORKDIR /app
COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "Coensio.Consumer.dll"]