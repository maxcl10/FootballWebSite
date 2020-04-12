import { BrowserModule, Title } from '@angular/platform-browser';

import { NgModule, APP_INITIALIZER } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ServiceWorkerModule } from '@angular/service-worker';

// Routing
import { AppRoutingModule } from './app-routing.module';

// Modules
import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { ModalModule } from 'ngx-bootstrap/modal';

// App is our top level component
import { AppComponent } from './app.component';
import { APP_RESOLVER_PROVIDERS } from './app.resolver';
import { AppState } from './app.service';

import { environment } from '../environments/environment';
import { AppConfig } from './app.config';
import { PlayersModule } from './players/players.module';

// Application wide providers
const APP_PROVIDERS = [...APP_RESOLVER_PROVIDERS, AppState];

export function initializeApp(appConfig: AppConfig) {
  return () => appConfig.load();
}

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
    ModalModule.forRoot(),
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
