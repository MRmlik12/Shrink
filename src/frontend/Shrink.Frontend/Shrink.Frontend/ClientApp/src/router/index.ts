import Vue from 'vue';
import VueRouter, { RouteConfig } from 'vue-router';
import Index from '../views/Index.vue';
import Error from '../views/Error.vue';
import Report from '../views/Report.vue';

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'Index',
    component: Index,
  },
  {
    path: '/error',
    name: 'Error',
    component: Error,
  },
  {
    path: '/report',
    name: 'Report',
    component: Report,
  },
];

const router = new VueRouter({
  routes,
});

export default router;
