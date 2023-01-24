using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace webApiPubs.Models
{
    public partial class Titles
    {
        public Titles()
        {
            Sales = new HashSet<Sales>();
            Titleauthor = new HashSet<Titleauthor>();
        }

        public string TitleId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string PubId { get; set; }
        public decimal? Price { get; set; }
        public decimal? Advance { get; set; }
        public int? Royalty { get; set; }
        public int? YtdSales { get; set; }
        public string Notes { get; set; }
        public DateTime Pubdate { get; set; }

        public virtual Publisher Pub { get; set; }
        public virtual ICollection<Sales> Sales { get; set; }
        public virtual ICollection<Titleauthor> Titleauthor { get; set; }
    }
}
