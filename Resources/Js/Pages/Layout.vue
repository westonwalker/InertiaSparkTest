<script setup>
	import NavBar from '../Components/NavBar.vue'
	import Footer from '../Components/Footer.vue'
</script>

<template>
	<NavBar />
	<main class="container px-6 mx-auto py-20">
		<slot />
	</main>
	<Footer />
</template>