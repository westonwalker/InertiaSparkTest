<script setup>
	import Layout from '../Layout.vue'
	import { Head, Link } from '@inertiajs/vue3'
	import { router } from '@inertiajs/vue3'
	import { useForm } from '@inertiajs/vue3'

	defineProps({
		errors: Object
	})
	const form = useForm({
		Email: null,
		Password: null,
		RememberMe: false,
	})
	function submit() {
		form.post('/login', {
			preserveScroll: true,
			onSuccess: () => form.reset(),
		})
	}
</script>

<template>
	<Layout>
		<Head title="Login" />
		<div>
			<section class="w-full sm:max-w-md mx-auto py-12 flex flex-col justify-center items-center">
				<Link href="/">
					<img src="/images/logo.png" class="h-20 w-auto" />
				</Link>
				<h1 class="text-center mt-6 text-center text-3xl font-bold tracking-tight text-black">
					Login to your account
				</h1>
				<form @submit.prevent="submit" class="mt-6 flex flex-col py-8 px-4 sm:px-10 bg-white sm:mx-auto sm:w-full sm:max-w-md shadow-lg rounded-md">
					<div>
						<label for="email" class="block font-medium text-sm text-gray-700">Email address</label>
						<div class="mt-1">
							<input v-model="form.Email" id="email" type="email" autocomplete="email" class="border-gray-300 focus:border-indigo-500 focus:ring-indigo-500 rounded-md shadow-sm block mt-1 w-full" />
						</div>
						<div v-if="errors.Email">
							<p class="mt-1 text-red-500 text-sm" v-for="error in errors.Email" :key="error">
								{{ error }}
							</p>
						</div>
					</div>
					<div class="mt-8">
						<label for="password" class="block font-medium text-sm text-gray-700">Password</label>
						<div class="mt-1">
							<input v-model="form.Password" id="password" type="password" autocomplete="current-password" class="border-gray-300 focus:border-indigo-500 focus:ring-indigo-500 rounded-md shadow-sm block mt-1 w-full" />
						</div>
						<div v-if="errors.Password">
							<p class="mt-1 text-red-500 text-sm" v-for="error in errors.Password" :key="error">
								{{ error }}
							</p>
						</div>
					</div>
					<div class="mt-8">
						<label for="remember_me" class="inline-flex items-center">
							<input v-model="form.RememberMe" id="remember_me" type="checkbox" class="rounded border-gray-300 text-indigo-600 shadow-sm focus:ring-indigo-500">
							<span class="ml-2 text-sm text-gray-600">Remember me</span>
						</label>
					</div>
					<div class="mt-8 flex justify-end items-center">
						<Link href="/register" class="underline text-sm text-gray-600 hover:text-gray-900 rounded-md focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500">
							Don't have an account? Sign up
						</Link>
						<button type="submit" class="inline-flex items-center px-4 py-2 bg-indigo-700 border border-transparent rounded-md font-semibold text-xs text-white uppercase tracking-widest hover:bg-gray-700 focus:bg-gray-700 active:bg-gray-900 focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2 transition ease-in-out duration-150 ml-3">
							Login
						</button>
					</div>
				</form>
			</section>
		</div>
	</Layout>
</template>