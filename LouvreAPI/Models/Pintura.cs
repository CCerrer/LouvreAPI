namespace LouvreAPI.Models
{
    public class Pintura
    {
        public int Id { get; set; } = 0;
        public string? Name { get; set; } = string.Empty;
        public string? Autor { get; set; } = string.Empty;
        public string? Tecnica { get; set; } = string.Empty;
        public string? Descricao { get; set; } = string.Empty;
        public int YearMade { get; set; } = 0;
    }
}
