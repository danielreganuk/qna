import { Component, OnInit } from '@angular/core';
import { QuestionListDto } from '../qna-api/data/models/dtos/QuestionListDto.model';
import { QuestionsClient } from '../qna-api/integration/clients/questions-client.api';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.scss']
})
export class QuestionsComponent implements OnInit {
  public vm: QuestionListDto = new QuestionListDto();
  questionBoxOpen = false;

  constructor(private client: QuestionsClient) {
    client.getAll().subscribe(result => {
      this.vm = result;
      console.log(result);
    }, error => console.error(error));
   }

  ngOnInit(): void {
  }

  toggleQuestionBox() {
    this.questionBoxOpen = !this.questionBoxOpen;
  }

}
