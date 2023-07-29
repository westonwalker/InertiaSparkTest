<script setup>
	import { computed } from 'vue'
	import { Link } from '@inertiajs/vue3'
	import { usePage } from '@inertiajs/vue3'
	import { useForm } from '@inertiajs/vue3'

    const page = usePage()
	const auth = computed(() => page.props.auth)
	const form = useForm({})
	function submit() {
		form.post('/logout')
	}
</script>

<template>
	<nav class="relative w-full max-w-6xl mx-auto px-4">
		<div class="flex justify-between items-center">
			<ul>
				<li class="px-2 py-4">
					<Link href="/">
						<div class="inline-flex items-center">
							<img src="/images/logo.png" class="h-12 w-auto" />
							<h4 class="text-2xl font-bold text-gray-700">Spark</h4>
						</div>
					</Link>
				</li>
			</ul>
			<ul v-if="auth.isAuthenticated" class="flex-wrap items-center w-auto hidden md:flex space-x-4">
					<div class="relative ml-3">
						<div>
							<button class="flex rounded-full bg-transparent text-sm focus:outline-none focus:ring-2 focus:ring-white focus:ring-offset-2 focus:ring-offset-gray-800" id="user-menu-button" aria-expanded="false" aria-haspopup="true">
								<span class="sr-only">Open user menu</span>
								<img class="h-8 w-8 rounded-full" src="/images/anonymous-user.png" alt="User Avatar">
							</button>
						</div>
						<div class="absolute right-0 z-50 mt-2 w-48 origin-top-right shadow-2xl bg-white py-1 border border-gray-600" role="menu" aria-orientation="vertical" aria-labelledby="user-menu-button" tabindex="-1">
							<div>
								<Link href="/dashboard" class="block px-4 py-4 text-base text-gray-600 hover:text-black hover:bg-gray-100 font-semibold" role="menuitem">Dashboard</Link>
								<Link href="/account" class="block px-4 py-4 text-base text-gray-600 hover:text-black hover:bg-gray-100 font-semibold" role="menuitem">Account</Link>
								<form @submit.prevent="submit">
									<button type="submit" class="block px-4 py-4 w-full text-left text-base text-gray-600 hover:text-black hover:bg-gray-100 font-semibold" role="menuitem">
										Logout
									</button>
								</form>
								<p class="text-sm p-2 border-t">{{ auth.user.name }}</p>
							</div>
						</div>
					</div>
			</ul>
			<ul v-else class="flex-wrap items-center w-auto hidden md:flex space-x-4">
				<li class="px-2 py-4"><Link class="text-lg font-medium text-indigo-600 hover:text-indigo-700" href="/dashboard">dasj</Link></li>
				<li class="px-2 py-4"><Link class="text-lg font-medium text-indigo-600 hover:text-indigo-700" href="/login">Login</Link></li>
				<li class="px-2 py-4"><Link class="px-3 py-4 text-lg bg-indigo-600 hover:bg-indigo-700 text-white rounded-md font-medium" href="/register">Register</Link></li>
			</ul>
			<div class="w-auto md:hidden">
				<button class="text-gray-600 hover:text-black hover:bg-gray-100 bg-transparent p-2">
					<svg class="w-6 h-6" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor">
						<path stroke-linecap="round" stroke-linejoin="round" d="M3.75 6.75h16.5M3.75 12h16.5m-16.5 5.25h16.5" />
					</svg>
					<svg class="w-6 h-6" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor">
						<path fill-rule="evenodd" d="M5.47 5.47a.75.75 0 011.06 0L12 10.94l5.47-5.47a.75.75 0 111.06 1.06L13.06 12l5.47 5.47a.75.75 0 11-1.06 1.06L12 13.06l-5.47 5.47a.75.75 0 01-1.06-1.06L10.94 12 5.47 6.53a.75.75 0 010-1.06z" clip-rule="evenodd" />
					</svg>
				</button>
			</div>
		</div>
		<div class="lg:hidden bg-white drop-shadow-lg z-50 mb-12" id="mobile-menu">
			<div v-if="auth.isAuthenticated" class="py-3 space-y-1 px-4 md:px-12">
					<Link class="text-gray-600 hover:bg-gray-100 hover:text-black block px-4 py-2 font-medium" href="/dashboard">Dashboard</Link>
					<a class="text-gray-600 hover:bg-gray-100 hover:text-black block px-4 py-2 font-medium" href="/account">Account</a>
					<form @submit.prevent="submit">
						<button type="submit" class="text-gray-600 hover:bg-gray-100 hover:text-black block px-4 py-2 w-full text-left font-medium">Logout</button>
					</form>
					<p class="text-sm px-4 py-2 border-t">{{ auth.user.name }}</p>
			</div>
			<div v-else class="py-3 space-y-1 px-4 md:px-12">
					<a class="text-gray-600 hover:bg-gray-100 hover:text-black block px-4 py-2 font-medium" href="/login">Login</a>
					<a class="text-gray-600 hover:bg-gray-100 hover:text-black block px-4 py-2 font-medium" href="/register">Register</a>
			</div>
		</div>
	</nav>
</template>