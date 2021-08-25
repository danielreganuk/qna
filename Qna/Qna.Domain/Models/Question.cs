using System;
using System.Collections.Generic;

namespace Qna.Domain.Models
{
    public class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }

        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string QuestionText { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}