FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["QuestionnarieApplication/QuestionnarieApplication.csproj", "QuestionnarieApplication/"]
RUN dotnet restore "QuestionnarieApplication/QuestionnarieApplication.csproj"
COPY . .
WORKDIR "/src/QuestionnarieApplication"
RUN dotnet build "QuestionnarieApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QuestionnarieApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QuestionnarieApplication.dll"]
