using API_projeto.Repository;
using API_projeto.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API_projeto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class CityEventController : ControllerBase
    {
        
        
        private ICityEventRepository _repository { get; set; }
       
        //Construtor do controller CityEvent
        public CityEventController(ICityEventRepository eventoRepository)
        {
            _repository = eventoRepository;
        }

        //Inserir evento
        [HttpPost("inserir")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Inserir(CityEventEntity cityEvent)
        {
            if (!_repository.InserirEvento(cityEvent))
            {
                return BadRequest();
            }

            return Ok(cityEvent);
        }

        //Procuar evento (pelo título)
        [HttpGet("consultar/titulo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ConsultarPeloTitulo(string nome)
        {
             return Ok(_repository.ConsultaTitulo(nome));
        }

        //Procurar evento (pelo local e data)
        [HttpGet("consultar/local/data")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ConsultarLocalData(string local, DateTime data)
        {
            return Ok(_repository.ConsultaLocalData(local,data));
        }

        //Procurar evento (pela data e preço)
        [HttpGet("consultar/preco/data")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ConsultaPrecoData(decimal minPrice, decimal maxPrice,DateTime data)
        {
            return Ok(_repository.ConsultaPrecoData(minPrice,maxPrice, data));
        }

        //Atualizar evento existente
        [HttpPut("atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AtualizarEvento(CityEventEntity cityevent, int id)
        {   
            if(!_repository.EditarEvento(cityevent, id))
            {
                return BadRequest();
            }
            return Ok(cityevent);
        }
    }
}