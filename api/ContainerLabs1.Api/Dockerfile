#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["api/ContainerLabs1.Api/ContainerLabs1.Api.csproj", "api/ContainerLabs1.Api/"]
RUN dotnet restore "api/ContainerLabs1.Api/ContainerLabs1.Api.csproj"
COPY . .
WORKDIR "/src/api/ContainerLabs1.Api"
RUN dotnet build "ContainerLabs1.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ContainerLabs1.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContainerLabs1.Api.dll"]