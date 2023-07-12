<script setup>
	import Layout from './Layout.vue'
	import { Head } from '@inertiajs/vue3'
	import { router } from '@inertiajs/vue3'
	import { useForm } from '@inertiajs/vue3'

	defineProps({ 
		controller: Object
	})
	const form = useForm({
		name: null,
	})
	function submit() {
		form.post('/users', {
			preserveScroll: true,
			onSuccess: () => form.reset('name'),
		})
	}
</script>

<template>
	<Layout>
		<Head title="Welcome" />
		<article>
			<h1>Add a name</h1>
			<form @submit.prevent="submit">
    			<label for="full_name">name:</label>
				<input id="full_name" v-model="form.name" />
				<button type="submit">Add name</button>
			</form>
			<h2>Names</h2>
			<ul>
				<li v-for="name in controller.names" :key="name">
					{{ name }}
				</li>
			</ul>
		</article>
	</Layout>
</template>