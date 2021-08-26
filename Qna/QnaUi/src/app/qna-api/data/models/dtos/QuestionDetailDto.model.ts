import { IApiResponse } from "../../interfaces/IApiResponse.interface";
import { QuestionDetailVm } from "../view-models/QuestionDetailVm.model";

export class QuestionDetailDto implements IApiResponse {
  success: boolean;
  message: string;
  dataCount: number;
  data: QuestionDetailVm | undefined;
}
