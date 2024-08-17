FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
ENV ASPNETCORE_ENVIRONMENT=Development
WORKDIR /app
EXPOSE 8080


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["./SolutionProject.Api/SolutionProject.Api.csproj","SolutionProject.Api/"]
COPY ["./SolutionProject.Application/SolutionProject.Application.csproj","SolutionProject.Application/"]
COPY ["./SolutionProject.Domain/SolutionProject.Domain.csproj","SolutionProject.Domain/"]
COPY ["./SolutionProject.Infrastructure/SolutionProject.Infrastructure.csproj","SolutionProject.Infrastructure/"]
COPY . .
WORKDIR "/src/SolutionProject.Api"
RUN dotnet build "./SolutionProject.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SolutionProject.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SolutionProject.Api.dll"]