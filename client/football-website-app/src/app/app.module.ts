import { BrowserModule, Title } from '@angular/platform-browser';

import { NgModule, APP_INITIALIZER, LOCALE_ID } from '@angular/core';
import { CommonModule } from '@angular/common';
import { registerLocaleData } from '@angular/common';
import localeFr from '@angular/common/locales/fr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ServiceWorkerModule } from '@angular/service-worker';

// Routing
import { AppRoutingModule } from './app-routing.module';

// Modules
import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';

// App is our top level component
import { AppComponent } from './app.component';
import { APP_RESOLVER_PROVIDERS } from './app.resolver';
import { AppState } from './app.service';

import { environment } from '../environments/environment';
import { AppConfig } from './app.config';
import { RouterModule } from '@angular/router';

// Application wide providers
const APP_PROVIDERS = [...APP_RESOLVER_PROVIDERS, AppState];

export function initializeApp(appConfig: AppConfig) {
  return () => appConfig.load();
}

registerLocaleData(localeFr, 'fr');

/**
 * `AppModule` is the main entry point into Angular2's bootstraping process
 */
@NgModule({
  bootstrap: [AppComponent],
  declarations: [AppComponent],
  imports: [
    // import Angular's modules
    BrowserModule,
    BrowserAnimationsModule,
    CommonModule,
    RouterModule,
    // App modules
    AppRoutingModule,
    CoreModule,
    SharedModule,
    // Service worker
    ServiceWorkerModule.register('/ngsw-worker.js', {
      enabled: environment.production,
    }),
  ],
  providers: [
    // expose our Services and Providers into Angular's dependency injection
    APP_PROVIDERS,
    Title,
    { provide: LOCALE_ID, useValue: 'fr' },
    AppConfig,
    {
      provide: APP_INITIALIZER,
      useFactory: initializeApp,
      deps: [AppConfig],
      multi: true,
    },
  ],
})
export class AppModule {}
