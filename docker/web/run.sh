#!bin/bash
set -ev

srcPath=$PWD 

# Restore de tous les projets
dotnet restore
rm -rf /root/publish/*

# Publication de l'application web
dotnet publish $srcPath/app.web --configuration release --output /root/publish

# Appliquer la migration à la BD:
cd $srcPath/app.persistence
dotnet ef database update

#Démarrage du site web
cd $srcPath/app.web
dotnet /root/publish/app.web.dll