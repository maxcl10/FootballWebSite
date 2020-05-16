import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoginRoutingModule } from './login-routing.module';
import { SharedModule } from '../shared/shared.module';
import { LoginContainerComponent } from './login-container/login-container.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [LoginContainerComponent],
  imports: [CommonModule, LoginRoutingModule, SharedModule, FormsModule],
})
export class LoginModule {}
