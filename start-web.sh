#!/bin/bash
docker build -t web_image -f ./docker/web/Dockerfile  .
docker run -it --rm -p5000:5000 --link postgresdb:postgres -v $HOME/temp/publish:/root/publish -v $HOME/.nuget/packages:/root/.nuget/packages -v $PWD/NameGenerator:/NameGenerator -e WEBAPP_DATABASE_CONNECTIONSTRING=$WEBAPP_DATABASE_CONNECTIONSTRING web_image


