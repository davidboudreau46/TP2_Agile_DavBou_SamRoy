#!/bin/bash
set -v
docker run -it --rm --link postgresdb:postgres postgres psql -h postgres -U postgres