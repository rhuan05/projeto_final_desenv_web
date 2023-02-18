using System.Diagnostics.Eventing.Reader;
using API_projeto.Service.Interface;
using Dapper;
using MySqlConnector;

namespace API_projeto.Repository
{
    public class CityEventRepository:ICityEventRepository
    {
        
        //Propriedade que armazena a variavel de ambiente
        private string _stringConnection { get; set; }
        public CityEventRepository() {
            _stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");
        }

        //Criar novo evento
        public bool InserirEvento(CityEventEntity cityevent) {
            string query = "INSERT INTO CityEvent(Title,description,dateHourEvent,local,address,price,status) VALUES(@Title,@description,@dateHourEvent,@local,@address,@price,@status)";
            DynamicParameters parametros = new(cityevent) ;
           
           
            using MySqlConnection conn = new MySqlConnection(_stringConnection);

            int linhasAfetadas = conn.Execute(query,parametros);
            
            return linhasAfetadas > 0; 
        }

        //Editar evento
        public bool EditarEvento(CityEventEntity cityevent,int id ) {
            string query = "UPDATE CityEvent  set Title = @title,description = @description,dateHourEvent = @dateHourEvent,local = @local,address = @address,price = @price,status = TRUE where idEvent=@id";
            
            var parametros = new DynamicParameters(new
            {
                cityevent.Title,
                cityevent.Description,
                cityevent.DateHourEvent,
                cityevent.Local,
                cityevent.Address,
                cityevent.Price,
                
            });
            parametros.Add("id", id);

            using MySqlConnection conn = new MySqlConnection(_stringConnection);

            int linhasAfetadas = conn.Execute(query, parametros);

            return linhasAfetadas > 0;
        }

        //Pesquisar evento pelo título
        public List<CityEventEntity> ConsultaTitulo(string nome)
        {
            var query = "SELECT * FROM CityEvent WHERE Title LIKE @nome";
            nome = $"%{nome}%";

            var parameters = new DynamicParameters(nome) ;            
            parameters.Add("nome", nome);
           
            using MySqlConnection conn = new(_stringConnection);

            return conn.Query<CityEventEntity>(query,parameters).ToList();
        }

        //Pesquisar evento pelo local e data
        public List<CityEventEntity> ConsultaLocalData(string local, DateTime data)
        {
            string query = "SELECT * FROM CityEvent WHERE Local = @local AND Date(dateHourEvent) = @data;";
            
            var parameters = new DynamicParameters();
            parameters.Add("local", local);
            parameters.Add("data", data);

            using MySqlConnection conn = new(_stringConnection);
            
            return conn.Query<CityEventEntity>(query, parameters).ToList();
        }

        //Pesquisar por preço e data
        public List<CityEventEntity> ConsultaPrecoData(decimal minPrice, decimal maxPrice, DateTime data)
        {
            string query = "SELECT * FROM CityEvent WHERE Price BETWEEN @minPrice AND @maxPrice AND DATE(dateHourEvent) = @date;";
            
            var parameters = new DynamicParameters();
            parameters.Add("minPrice", minPrice);
            parameters.Add("maxPrice", maxPrice);
            parameters.Add("date",data);

            using MySqlConnection conn = new(_stringConnection);

            return conn.Query<CityEventEntity>(query, parameters).ToList();

        }
    }
}
