# Sử dụng image SDK của .NET cho quá trình runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Sử dụng image SDK của .NET cho quá trình build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Sao chép file .csproj và khôi phục các dependency
COPY ["EngLabAPI.csproj", "./"]
RUN dotnet restore "./EngLabAPI.csproj"

# Sao chép toàn bộ source code và build ứng dụng
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Tạo final stage image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "EngLabAPI.dll"]
