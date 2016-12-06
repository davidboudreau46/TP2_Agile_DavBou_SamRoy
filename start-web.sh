#!/bin/bash
docker build -t web_image -f ./docker/web/Dockerfile  .
docker run -it --rm --link SamDavPGDB -e WEBAPP_DATABASE_CONNECTIONSTRING=$WEBAPP_DATABASE_CONNECTIONSTRING web_image


