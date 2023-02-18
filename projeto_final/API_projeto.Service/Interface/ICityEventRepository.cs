using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_projeto.Service.Interface
{
    public interface ICityEventRepository
    {

        //Propriedades da interface CityEvent
        public bool InserirEvento(CityEventEntity cityevent);
        public bool EditarEvento(CityEventEntity cityevent, int id);
        public List<CityEventEntity> ConsultaTitulo(string nome);
        public List<CityEventEntity> ConsultaLocalData(string local, DateTime data);
        public List<CityEventEntity> ConsultaPrecoData(decimal minPrice, decimal maxPrice, DateTime data);
    }
}
