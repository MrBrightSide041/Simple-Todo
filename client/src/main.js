import { createApp } from 'vue'
import App from './App.vue'
import PrimeVue from 'primevue/config';
import Lara from '/src/presets/lara';
import Toast from "primevue/toast";
import ToastService from 'primevue/toastservice';
import './style.css'

const app = createApp(App);
app.use(PrimeVue, {
  unstyled: true,
  pt: Lara
});
app.use(ToastService)
app.component('Toast', Toast)

app.mount('#app')
