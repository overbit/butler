#!/bin/bash
clear
echo "ME:           Alfred wake up!!!" 
dotnet run --project alfred-api/alfred-api.csproj --launch-profile "Kestrel" &
cd alfred-frontend/
npm run serve &