#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Services/TCC.Carrinho.API/TCC.Carrinho.API.csproj", "src/Services/TCC.Carrinho.API/"]
RUN dotnet restore "src/Services/TCC.Carrinho.API/TCC.Carrinho.API.csproj"
COPY . .
WORKDIR "/src/src/Services/TCC.Carrinho.API"
RUN dotnet build "TCC.Carrinho.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TCC.Carrinho.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TCC.Carrinho.API.dll"]