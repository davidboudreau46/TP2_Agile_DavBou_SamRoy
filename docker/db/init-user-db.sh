#!/bin/bash
set -e

psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" <<-EOSQL
    CREATE USER admin WITH PASSWORD 'admin';
    CREATE DATABASE TP2DB;
    GRANT ALL PRIVILEGES ON DATABASE admin TO admin;
EOSQL