# ===== BUILD STAGE =====
FROM node:22-alpine AS build

WORKDIR /app

COPY package*.json ./
RUN npm install

COPY . .
RUN npm run build --configuration=production

# 👇 ใส่ตรงนี้
RUN ls -R /app/dist


# ===== NGINX STAGE =====
FROM nginx:alpine

COPY --from=build /app/dist/thaibev-test/browser /usr/share/nginx/html
COPY default.conf.template /etc/nginx/templates/default.conf.template

EXPOSE 80