import { IApiResponse } from "../../interfaces/IApiResponse.interface";
import { QuestionListVm } from "../view-models/QuestionListVm.model";

export class QuestionListDto implements IApiResponse {
  success: boolean;
  message: string;
  dataCount: number;
  data: QuestionListVm[] | undefined;
}
