import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

if (environment.name === 'production') {
  enableProdMode();
}

/*
Workarround because for some reason the service worker is not registered with the other method
*/
// platformBrowserDynamic()
//   .bootstrapModule(AppModule)
//   .then(() => {
//     if ('serviceWorker' in navigator && environment.production) {
//       console.log('Service worker registered');
//       navigator.serviceWorker.register('ngsw-worker.js');
//     }
//   })
//   .catch(err => console.log(err));

platformBrowserDynamic()
  .bootstrapModule(AppModule)
  .catch(err => console.log(err));
