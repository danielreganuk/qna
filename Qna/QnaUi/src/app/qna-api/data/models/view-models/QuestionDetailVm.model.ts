export class QuestionDetailVm {
  id: number;
  title: string;
  questionText: string;
  authorId: number;
  authorDisplayName: string;
  AuthorEmailAddress: string;
  createdDate: Date;
  answers: QuestionAnswerDetailsVm[];
}

export class QuestionAnswerDetailsVm {
  id: number;
  answerText: string;
  questionText: string;
  authorId: number;
  authorDisplayName: string;
  AuthorEmailAddress: string;
  createdDate: Date;
}
