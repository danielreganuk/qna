import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { QuestionsComponent } from './questions/questions.component';
import { QuestionDetailComponent } from './question-detail/question-detail.component';
import { CreateQuestionComponent } from './create-question/create-question.component';
import { HttpClientModule } from '@angular/common/http';
import { QuestionsClient } from './qna-api/integration/clients/questions-client.api';

@NgModule({
  declarations: [
    AppComponent,
    QuestionsComponent,
    QuestionDetailComponent,
    CreateQuestionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [QuestionsClient],
  bootstrap: [AppComponent]
})
export class AppModule { }
