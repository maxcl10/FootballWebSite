# Stage 1
FROM node:10.16.2-alpine as node
WORKDIR /app
COPY package*.json ./
RUN npm install --silent
COPY . .
RUN npm run build:fcb --prod

# Stage 2
FROM nginx:1.13.12-alpine
COPY --from=node /app/dist /usr/share/nginx/html
COPY ./nginx.conf /etc/nginx/conf.d/default.conf
CMD ["nginx", "-g", "daemon off;"]
