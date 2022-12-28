namespace AlphaWebApp.Models.ViewModels
{
    public class PersonalizedNewsletterVM
    {
        public int ArticleId { get; set; }
        public DateTime ArticleDateStamp { get; set; }
        //public string LinkText { get; set; }
        public string ArticleHeadLine { get; set; }
        public string ArticleContentSummary { get; set; }
        //public string Content { get; set; }
        public int ArticleViews { get; set; }
        public int ArticleLikes { get; set; }
        public Uri ArticleImageLink { get; set; }
        //public bool Archive { get; set; } = false;
        //public bool EditorsChoice { get; set; } = false;

        //[ForeignKey("Category")]
        public int? ArticleCategoryId { get; set; }
        public virtual Category ArticleCategory { get; set; }

        //public virtual ICollection<Like> Like { get; set; }
    }
}
