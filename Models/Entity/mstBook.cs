using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksManager.Models.Entity
{
    [Table("mstBook")]
    public class mstBook
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string Publisher { get; set; }
        public int YearPublished { get; set; }
        public decimal Price { get; set; }
        public string MLACitation => $"{AuthorLastName}, {AuthorFirstName}. {Title}. {Publisher}, {YearPublished}.";
        public string ChicagoCitation => $"{AuthorLastName}, {AuthorFirstName}. *{Title}.* {Publisher}, {YearPublished}.";

    }
}
