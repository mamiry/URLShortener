#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1809 AS build
WORKDIR /src
COPY ["URLShortener.MVC/URLShortener.MVC.csproj", "URLShortener.MVC/"]
COPY ["URLShortener.Data/URLShortener.Data.csproj", "URLShortener.Data/"]
COPY ["URLShortener.Domain/URLShortener.Domain.csproj", "URLShortener.Domain/"]
COPY ["URLShortener.Core/URLShortener.Core.csproj", "URLShortener.Core/"]
RUN dotnet restore "URLShortener.MVC/URLShortener.MVC.csproj"
COPY . .
WORKDIR "/src/URLShortener.MVC"
RUN dotnet build "URLShortener.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "URLShortener.MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "URLShortener.MVC.dll"]