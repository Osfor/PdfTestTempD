FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-back 	

WORKDIR /src 																			
COPY ./PdfTestTemp/ ./ 																		

RUN dotnet publish "PdfTestTemp.csproj" -c Release -o /app/publish --nologo 				

FROM base AS final 																		
WORKDIR /app 																			
COPY --from=build-back /app/publish . 													

# RUN apt-get update && apt-get install -y libfreetype6 libfontconfig1 libharfbuzz0b libjpeg62-turbo libpng16-16 libx11-6 libxext6 libxrandr2 libxinerama1 libxcursor1 libxi6 && rm -rf /var/lib/apt/lists/*

WORKDIR /app 																			

ENTRYPOINT ["dotnet", "PdfTestTemp.dll"]														