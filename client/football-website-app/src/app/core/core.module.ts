import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthenticationService } from './services/authentication.service';
import { CheckForUpdateService } from './services/check-for-update.service';

import { PromptUpdateService } from './services/prompt-update.service';
import { LogUpdateService } from './services/log-update.service';

import { CacheInterceptor } from './interceptors/cache-interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

// This module contains all the services and all the top level app components
@NgModule({
  imports: [CommonModule],
  declarations: [],
  providers: [
    AuthenticationService,
    CheckForUpdateService,
    PromptUpdateService,
    LogUpdateService,
    { provide: HTTP_INTERCEPTORS, useClass: CacheInterceptor, multi: true },
  ],
})
export class CoreModule {}
