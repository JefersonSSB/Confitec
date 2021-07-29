using System;
using System.Threading.Tasks;
using Confitec.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Confitec.Api.Controllers
{
    [ApiController]
    [Route("v1/escolaridade")]
    public class EscolaridadeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EscolaridadeController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult> Buscar()
        {
            try
            {
                var result = await _mediator.Send(new BuscarEscolaridadeQuery());
                return Ok(result);

            }
            catch
            {
                return StatusCode(500);
            }

        }
    }
}
