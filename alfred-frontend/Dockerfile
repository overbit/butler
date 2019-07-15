FROM node:lts-alpine

# install simple http server for serving static content
RUN npm install -g http-server

ARG source
WORKDIR /inetpub/wwwroot
COPY ${source:-obj/Docker/publish} .

# build app for production with minification
RUN npm run build

EXPOSE 8080
CMD [ "http-server", "dist" ]