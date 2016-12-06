FROM postgres

ENV POSTGRES_PASSWORD=$ROOT_POSTGRES_PASSWORD

EXPOSE 5432

COPY ./docker/db/init-user-db.sh /docker-entrypoint-initdb.d/
RUN chmod +x /docker-entrypoint-initdb.d/init-user-db.sh