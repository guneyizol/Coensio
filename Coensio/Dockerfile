FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Coensio/Coensio.csproj", "Coensio/"]
COPY ["Coensio.Contract/Coensio.Contract.csproj", "Coensio.Contract/"]
RUN dotnet restore "./Coensio/Coensio.csproj"
COPY . .
WORKDIR "/src/Coensio"
RUN dotnet build "./Coensio.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:8.0
USER app
WORKDIR /app
COPY --from=build /app/build .
EXPOSE 8080
ENTRYPOINT ["dotnet", "Coensio.dll"]