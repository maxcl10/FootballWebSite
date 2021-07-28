# Stage 1
FROM node:latest as node
WORKDIR /app
COPY package*.json ./
RUN npm install --silent
COPY . .
RUN npm run build:prod

# Stage 2
FROM nginx:alpine
COPY --from=node /app/dist /usr/share/nginx/html
COPY ./nginx.conf /etc/nginx/conf.d/default.conf
CMD ["nginx", "-g", "daemon off;"]


# docker build --rm -f "Dockerfile" -t test .
# --file , -f Name of the Dockerfile (Default is ‘PATH/Dockerfile’)
# --rm true Remove intermediate containers after a successful build
