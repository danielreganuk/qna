import { Observable } from 'rxjs';
import { QuestionListDto } from '../../data/models/dtos/QuestionListDto.model';

export interface IQuestionClient {
  getAll(): Observable<QuestionListDto>;
  // get(id: number): Observable<EmployeeDetailVm>;
  // create(command: UpsertEmployeeCommand): Observable<void>;
  // delete(id: number): Observable<void>;
}
