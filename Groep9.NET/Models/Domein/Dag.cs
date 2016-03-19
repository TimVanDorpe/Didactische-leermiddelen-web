namespace Groep9.NET.Models.Domein
{
    public class Dag
    {
      
        public Dag(string naam)
        {
            this.Naam = naam;
        }

        public string Naam { get; set; }
        public int DagId { get; set; }
    }
}