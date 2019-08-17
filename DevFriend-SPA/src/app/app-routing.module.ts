import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DropzoneDirective } from './dropzone.directive';

const routes: Routes = [];

@NgModule({
   imports: [
      RouterModule.forRoot(routes)
   ],
   exports: [
      RouterModule
   ],
   declarations: [
      DropzoneDirective
   ]
})
export class AppRoutingModule { }
