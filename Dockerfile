FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5055
EXPOSE 7088

ENV ASPNETCORE_URLS=http://+:5055

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["aspnetcoreapi.csproj", "./"]
RUN dotnet restore "aspnetcoreapi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "aspnetcoreapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "aspnetcoreapi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV Settings:KeyOne=100
ENV Settings:KeyTwo=false

ENTRYPOINT ["dotnet", "aspnetcoreapi.dll"]
