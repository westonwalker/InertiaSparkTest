<script setup>
	import Layout from './Layout.vue'
	import { Head } from '@inertiajs/vue3'
	defineProps({
		auth: Object
	})
</script>

<template>
	<Layout>
		<Head title="User Dashboard" />
		<section class="mx-auto max-w-6xl bg-white mb-20">
			<article class="my-6 sm:my-20 px-6 py-12 sm:py-20 sm:px-12 shadow-lg rounded-lg text-left">
				<h1 class="text-3xl sm:text-4xl font-bold text-gray-800 mb-20">
					User Dashboard for {{ auth.user.name }}
				</h1>
			</article>
		</section>
	</Layout>
</template>