#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PycApi/PycApi.csproj", "PycApi/"]
COPY ["PycApi.Data/PycApi.Data.csproj", "PycApi.Data/"]
COPY ["PycApi.Service/PycApi.Service.csproj", "PycApi.Service/"]
COPY ["PycApi.Dto/PycApi.Dto.csproj", "PycApi.Dto/"]
COPY ["PycApi.Base/PycApi.Base.csproj", "PycApi.Base/"]
RUN dotnet restore "PycApi/PycApi.csproj"
COPY . .
WORKDIR "/src/PycApi"
RUN dotnet build "PycApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PycApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PycApi.dll"]