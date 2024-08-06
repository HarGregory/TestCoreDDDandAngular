import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Step1Component } from './registration/step1/step1.component';
import { Step2Component } from './registration/step2/step2.component';
import { SuccessComponent } from './registration/success/success.component'; // Замените на реальный путь

const routes: Routes = [
  { path: '', redirectTo: '/step1', pathMatch: 'full' }, // Переадресация на Step1Component
  { path: 'step1', component: Step1Component },
  { path: 'step2', component: Step2Component },
  { path: 'success', component: SuccessComponent } // Замените на реальный путь
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
