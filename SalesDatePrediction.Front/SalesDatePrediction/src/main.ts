import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { provideHttpClient } from '@angular/common/http'; // Importa provideHttpClient
import { appConfig } from './app/app.config';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async'; // Asegúrate de que esto esté configurado correctamente

bootstrapApplication(AppComponent, {
  providers: [
    ...appConfig.providers, // Mantén los proveedores existentes
    provideHttpClient(), provideAnimationsAsync() // Agrega el proveedor de HttpClient
  ]
})
.catch((err) => console.error(err));