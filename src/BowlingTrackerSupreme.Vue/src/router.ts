import { createRouter, createWebHistory, type RouteRecordRaw } from 'vue-router';

// Example routes
const routes: Array<RouteRecordRaw> = [
    {
        path: '/',
        name: 'Home',
        component: () => import('./Views/Home.vue'),
    },
    {
        path: '/newGame',
        name: 'NewGame',
        component: () => import('./Views/NewGame.vue'),
    },
    {
        path: '/test',
        name: 'Test',
        component: () => import('./Views/Test.vue'),
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;