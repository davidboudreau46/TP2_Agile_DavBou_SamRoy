#!/bin/bash
set -v
docker stop SamDavPGDB
docker rm SamDavPGDB
docker build -t samroydavbou/db_image:latest -f ./docker/db/Dockerfile  .
docker run --name SamDavPGDB -p 5432:5432 -e POSTGRES_PASSWORD=$ROOT_POSTGRES_PASSWORD  -d samroydavbou/db_image:latest
docker ps