using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.DataAccess.Entity
{
    public class Issue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IssueId { get; set; }

        [Required]
        public string? JournalTitle { get; set; } // Название журнала

        [Required]
        public int Number { get; set; } // Номер выпуска

        [Required]
        public DateTime ReleaseDate { get; set; } // Дата выпуска

        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
