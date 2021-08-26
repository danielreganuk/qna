import { Observable } from 'rxjs';
import { QuestionListDto } from '../../data/models/dtos/QuestionListDto.model';
import { QuestionDetailDto } from '../../data/models/dtos/QuestionDetailDto.model';

export interface IQuestionClient {
  getAll(): Observable<QuestionListDto>;
  get(id: number): Observable<QuestionDetailDto>;
}
