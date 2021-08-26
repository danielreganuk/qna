import { IQuestionClient } from "../contracts/IQuestionsClient.interface";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from "rxjs";
import { QuestionListDto } from "../../data/models/dtos/QuestionListDto.model";
import { QuestionDetailDto } from "../../data/models/dtos/QuestionDetailDto.model";
import { Injectable } from "@angular/core";

@Injectable()
export class QuestionsClient implements IQuestionClient {
  private baseUrl: string = "https://localhost:44342";

  constructor(private http: HttpClient) {
  }

  getAll(): Observable<QuestionListDto> {
    const url = this.baseUrl + '/api/Questions/GetAll';

    let headers: HttpHeaders = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Accept', 'application/json');

    return this.http.get<QuestionListDto>(url, { headers: headers });
  }

  get(id: number): Observable<QuestionDetailDto> {
    const url = this.baseUrl + `/api/Questions/Get/${id}`;

    let headers: HttpHeaders = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Accept', 'application/json');

    return this.http.get<QuestionDetailDto>(url, { headers: headers });
  }
}

