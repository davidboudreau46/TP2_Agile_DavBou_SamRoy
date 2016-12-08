#!bin/bash
set -ev&
srcPath=$PWD
dotnet restore;
rm -rf /root/publish/*;
dotnet publish $srcPath/app.web --configuration release --output /root/publish;
cd $srcPath/app.persistence;
dotnet ef database update;
dotnet test $srcPath/app.web;
cd $srcPath/app.web;
dotnet test $srcPath/app.web.unitTests;
dotnet test $srcPath/app.web.acceptanceTests;