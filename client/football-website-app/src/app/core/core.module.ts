import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthenticationService } from './services/authentication.service';
import { CheckForUpdateService } from './services/check-for-update.service';

import { PromptUpdateService } from './services/prompt-update.service';
import { LogUpdateService } from './services/log-update.service';

import { CacheInterceptor } from './interceptors/cache-interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NavigationComponent } from './components/navigation/navigation.component';
import { SharedModule } from '../shared/shared.module';
import { CoreRoutingModule } from './core-routing.module';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';

// This module contains all the services and all the top level app components
@NgModule({
  imports: [CommonModule, CoreRoutingModule],
  declarations: [
    NavigationComponent,
    HeaderComponent,
    FooterComponent,
    HeaderComponent,
  ],
  providers: [
    AuthenticationService,
    CheckForUpdateService,
    SharedModule,
    PromptUpdateService,
    LogUpdateService,
    { provide: HTTP_INTERCEPTORS, useClass: CacheInterceptor, multi: true },
  ],
  exports: [HeaderComponent, NavigationComponent, FooterComponent],
})
export class CoreModule {}
