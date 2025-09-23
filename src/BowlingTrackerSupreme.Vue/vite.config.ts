import { defineConfig } from 'vite';
import plugin from '@vitejs/plugin-vue';
import tailwindcss from '@tailwindcss/vite';

// https://vitejs.dev/config/
export default defineConfig({
    plugins: [plugin(), tailwindcss()],
    server: {
    watch: {
      usePolling: true,
    },
    hmr: {
      host: 'localhost',
      port: 5173
    },
    host: true,
    port: 5173
  }
})
