<script setup>
    import { Link } from '@inertiajs/vue3'
</script>

<template>
    <main class="container">
        <header>
            <Link href="/">Home</Link>
            <span> - </span>
            <Link href="/about">About</Link>
        </header>
        <section>
            <slot />
        </section>
    </main>
</template>