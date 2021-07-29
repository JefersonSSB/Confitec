using System;
using System.Threading.Tasks;
using Confitec.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Confitec.Application.Queries.Usuario;
using Confitec.Application.Commands.Usuario;

namespace Confitec.Api.Controllers
{
    [ApiController]
    [Route("v1/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult> Buscar()
        {
            try
            {
                var result = await _mediator.Send(new BuscarUsuariosQuery());
                return Ok(result);
            }
            catch 
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> BuscarPorId(int id)
        {
            try
            {

                var result = await _mediator.Send(new BuscarUsuarioPorIdQuery(id));
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }

        }

        [HttpPost]
        public async Task<ActionResult> Incluir([FromBody] IncluirUsuarioCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch 
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Alterar([FromBody] AlterarUsuarioCommand command)
        {
            
                var result = await _mediator.Send(command);
                return Ok(result);
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeletarUsuarioCommand(id));
                return Ok(result);

            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}