FROM microsoft/aspnetcore-build:1.0.1

ENV ASPNETCORE_URLS http://+:5000
# Trois valeurs par défaut possibles avec aspnet core: Development, Staging, Production
ENV ASPNETCORE_ENVIRONMENT=Production

ENV WEBAPP_DATABASE_CONNECTIONSTRING=$WEBAPP_DATABASE_CONNECTIONSTRING

EXPOSE 5000

COPY ./docker/web/run.sh /scripts/run.sh
COPY ./NamesGenerator /NamesGenerator
RUN chmod 775 /scripts/run.sh

WORKDIR /NamesGenerator
CMD ["sh","/scripts/run.sh"]