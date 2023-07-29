import { fileURLToPath, URL } from 'node:url'
import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import tailwindcss from 'tailwindcss'
import appsettings from "./appsettings.json"

export default defineConfig({
  plugins: [
    tailwindcss(),
    vue({
        template: {
            transformAssetUrls: {
                base: null,
                includeAbsolute: false,
            },
        },
    }),
  ],
  resolve: {
        alias: {
          '@': fileURLToPath(new URL('./Resources/Js', import.meta.url))
        }
    },
    build: {
        outDir: `./wwwroot/${appsettings.Vite.Build.OutputDir}`,
        rollupOptions: {
            input: "Resources/Js/app.js",
            output: {
                entryFileNames: `[name].js`,
                chunkFileNames: `[name].js`,
                assetFileNames: `[name].[ext]`
            }
        }
    },
    server: {
        port: appsettings.Vite.Port,
    },
})
