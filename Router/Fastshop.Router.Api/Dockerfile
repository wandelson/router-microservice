FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Fastshop.Router.sln ./
COPY Router/Fastshop.Router.Api/Fastshop.Router.Api.csproj Router/Fastshop.Router.Api/
COPY Router/Fastshop.Router/Fastshop.Router.csproj Router/Fastshop.Router/
COPY Router/Fastshop.Router.Infra/Fastshop.Router.Infra.csproj Router/Fastshop.Router.Infra/
COPY Router/ExternalServices.StoneService/Fastshop.ExternalServices.Stone.csproj Router/ExternalServices.StoneService/
COPY Router/ExternalServices.Cielo/Fastshop.ExternalServices.Cielo.csproj Router/ExternalServices.Cielo/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/Router/Fastshop.Router.Api
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Fastshop.Router.Api.dll"]
