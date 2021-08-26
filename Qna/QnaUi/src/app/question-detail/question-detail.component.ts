import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { QuestionDetailDto } from '../qna-api/data/models/dtos/QuestionDetailDto.model';
import { QuestionsClient } from '../qna-api/integration/clients/questions-client.api';

@Component({
  selector: 'app-question-detail',
  templateUrl: './question-detail.component.html',
  styleUrls: ['./question-detail.component.scss']
})
export class QuestionDetailComponent implements OnInit {
  public vm: QuestionDetailDto = new QuestionDetailDto();
  id: number;
  constructor(private route: ActivatedRoute, private client: QuestionsClient) {
    this.id = parseInt(this.route.snapshot.paramMap.get('id'));

    client.get(this.id).subscribe(result => {
      this.vm = result;
      console.log(result);
    }, error => console.error(error));
   }

  ngOnInit(): void {
  }


}
