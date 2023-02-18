using API_projeto.Repository;
using API_projeto.Service.Interface;
using Microsoft.AspNetCore.Mvc;
namespace API_projeto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class EventReservationController : ControllerBase
    {
        //Criando a propriedade que vai armazenar o repositoryReservation
        private IEventReservationRepository _repository { get; set; }

        //Construtor do construtor reservar
        public EventReservationController(IEventReservationRepository eventoRepository)
        {
            _repository = eventoRepository;
        }
        
        //Fazer uma reserva
        [HttpPost("inserir")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Inserir(EventReservationEntity eventReservation)
        {
            if (!_repository.InserirReserva(eventReservation))
            {
                return BadRequest();
            }
            return Ok(eventReservation);
        }

        //Atualizar uma reserva
        [HttpPatch("atualizar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public IActionResult EditarQuantidade(int numero, long idReservation)
            {
            if (!_repository.EditarQuantidadeReserva(numero, idReservation));
                {
                    return BadRequest();
                }

                return NoContent();
            }

        //Consultar uma reserva
        [HttpGet("consulta")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<EventReservationEntity>> ConsultaPersonTitle(string nome, string tituloEvento)
        {
            
            return Ok(_repository.ConsultaPersonTitle(nome,tituloEvento));
        }

        //Deletar uma reserva
        [HttpDelete("deletar")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeletarReserva(long idReservation)
        {
            if (!_repository.Deletar(idReservation))
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
