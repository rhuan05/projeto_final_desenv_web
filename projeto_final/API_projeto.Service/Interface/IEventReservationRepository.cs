using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_projeto.Service.Interface
{
    public interface IEventReservationRepository
    {

        //Propriedades da interface EventReservation
        public bool InserirReserva(EventReservationEntity eventReservation);
        public bool EditarQuantidadeReserva(int numero, long idReservation);
        public List<EventReservationEntity> ConsultaPersonTitle(string nome, string tituloEvento);
        public bool Deletar(long id);
    }
}
