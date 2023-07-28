#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Api-Itvbr/Api-Itvbr.csproj", "Api-Itvbr/"]
RUN dotnet restore "Api-Itvbr/Api-Itvbr.csproj"
COPY . .
WORKDIR "/src/Api-Itvbr"
RUN dotnet build "Api-Itvbr.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api-Itvbr.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api-Itvbr.dll"]
