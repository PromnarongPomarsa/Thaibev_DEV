import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

// PrimeNG imports
import { providePrimeNG } from 'primeng/config';
import Lara from '@primeng/themes/lara';
import { DialogService } from 'primeng/dynamicdialog';


import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideClientHydration(),
    providePrimeNG({
      theme: {
        preset: Lara
      }
    }),
    DialogService]
};
