using Microsoft.AspNetCore.Mvc;
using Qna.Api.Shared;
using Qna.Application.Answers.Commands.CreateAnswer;
using Qna.Application.Authors.Queries.GetAuthorByEmailAddress;
using System;
using System.Threading.Tasks;

namespace Qna.Api.Controllers
{
    [ApiController]
    public class AnswersController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateAnswerCommand command)
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