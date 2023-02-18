namespace API_projeto
{
    public class CityEventEntity
    {
        
        //Propriedades da classe CityEvent
        public string Title { get; set; }

        public string? Description { get; set; }
        public DateTime DateHourEvent { get; set; }
        public string Local { get; set; }
        public string? Address { get; set; }
        public decimal? Price { get; set; }
        public bool Status { get; set; }

        
    }
}