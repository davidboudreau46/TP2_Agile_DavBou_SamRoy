#!/bin/bash
docker build -t samroydavbou/web_image:latest -f ./docker/web/Dockerfile  .
docker run -it --rm --link SamDavPGDB -e WEBAPP_DATABASE_CONNECTIONSTRING=$WEBAPP_DATABASE_CONNECTIONSTRING samroydavbou/web_image


