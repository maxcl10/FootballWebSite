import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ContactsRoutingModule } from './contacts-routing.module';
import { ContactsContainerComponent } from './contacts-container/contacts-container.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [ContactsContainerComponent],
  imports: [CommonModule, ContactsRoutingModule, SharedModule],
})
export class ContactsModule {}
