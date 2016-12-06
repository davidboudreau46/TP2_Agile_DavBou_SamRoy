#!/bin/bash
set -v
docker stop postgresdb
docker rm postgresdb
docker build -t db_image -f ./docker/db/Dockerfile  .
docker run --name postgresdb -p 5432:5432 -e POSTGRES_PASSWORD=$ROOT_POSTGRES_PASSWORD  -d db_image
docker ps