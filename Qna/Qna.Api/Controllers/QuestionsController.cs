using Microsoft.AspNetCore.Mvc;
using Qna.Api.Shared;
using Qna.Application.Authors.Queries.GetAuthorByEmailAddress;
using Qna.Application.Questions.Commands.CreateQuestion;
using Qna.Application.Questions.Queries.GetQuestionDetail;
using Qna.Application.Questions.Queries.GetQuestionsList;
using System;
using System.Threading.Tasks;

namespace Qna.Api.Controllers
{
    [ApiController]
    public class QuestionsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAll()
        {
            var response = await Mediator.Send(new GetQuestionsListQuery());
            return await GenerateResponse(response, response.Count);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse>> Get(int id)
        {
            var response = await Mediator.Send(new GetQuestionDetailQuery(id));
            return await GenerateResponse(response);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateQuestionCommand command)
        {
            try
            {
                var author = await Mediator.Send(new GetAuthorByEmailAddressQuery(command.Author.EmailAddress));
                command.AuthorId = author.AuthorId;
            }
            catch (Exception ex)
            {
                // surpress for now.
            }
            var response = await Mediator.Send(command);

            return await GenerateResponse(response);
        }
    }
}