using System;

namespace Qna.Domain.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public DateTime CreatedDate { get; set; }
        public int QuestionId { get; set; }
    }
}