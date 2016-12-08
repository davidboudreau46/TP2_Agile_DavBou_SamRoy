#!/bin/bash
set -v
docker stop SamDavPGDB
docker rm SamDavPGDB
docker build -t samroydavbou/db_image:latest -f ./docker/db/Dockerfile  .
docker run -d --name SamDavPGDB -e POSTGRES_PASSWORD=$ROOT_POSTGRES_PASSWORD  -d samroydavbou/db_image:latest
docker start SamDavPGDB
docker ps