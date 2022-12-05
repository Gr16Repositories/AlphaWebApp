namespace AlphaWebApp.Models
{
    public class SupscriptionType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }

        public string Description { get; set; }
        
        public Supscription SupscriptionId { get; set; }
        public virtual Supscription Supscription { get; set; }
    }
}
