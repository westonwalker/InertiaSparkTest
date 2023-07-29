export default {
    content: [
        './**/*.{vue,js,ts}',
        "./**/*.{razor,cshtml,blazor,html}",
    ],
    theme: {
        extend: {},
    },
    plugins: [require('@tailwindcss/forms')],
}