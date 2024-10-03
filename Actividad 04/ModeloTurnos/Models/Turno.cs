namespace ModeloTurnos.Models
{
    public class Turno
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string? Cliente { get; set; }
        public bool Cancelacion { get; set; }
        public string? MotivoCancelacion { get; set; }
    }
}
