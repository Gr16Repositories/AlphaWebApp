namespace AlphaWebApp.Models
{
    public class Like
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }

        //public bool Liked { get; set; }

        public DateTime LikedDate { get; set; } = DateTime.Now;
    }
}
