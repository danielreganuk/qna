import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateQuestionComponent } from './create-question/create-question.component';
import { QuestionDetailComponent } from './question-detail/question-detail.component';
import { QuestionsComponent } from './questions/questions.component';


const routes: Routes = [
  { path: '', component: QuestionsComponent, pathMatch: 'full' },
  { path: 'question/:id', component: QuestionDetailComponent },
  { path: 'create-question', component: CreateQuestionComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
