FROM node:20-alpine AS frontend-builder

WORKDIR /app/frontend

COPY frontend/package*.json ./
RUN npm install

COPY frontend/ ./
RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS backend-builder

WORKDIR /src

COPY backend/NumberToWordApp/*.csproj ./backend/
RUN dotnet restore ./backend/NumberToWordApp.csproj

COPY backend/NumberToWordApp/ ./backend/
WORKDIR /src/backend
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview

WORKDIR /app

COPY --from=backend-builder /app/publish ./

COPY --from=frontend-builder /app/frontend/dist ./wwwroot/

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "NumberToWordApp.dll"]

