FROM node:24-alpine

RUN npm install -g vite

RUN mkdir /app && chown node:node /app

USER node

WORKDIR /app

COPY --chown=node:node package.json package-lock.json ./

RUN npm install

COPY --chown=node:node . .

EXPOSE 5173

CMD ["npx", "vite", "--host"]