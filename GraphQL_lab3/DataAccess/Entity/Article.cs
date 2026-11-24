using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.DataAccess.Entity
{
    public class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticleId { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public decimal Honorarium { get; set; } // Размер гонорара за статью

        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;

        public int RubricId { get; set; }
        public Rubric Rubric { get; set; } = null!;

        public int IssueId { get; set; }
        public Issue Issue { get; set; } = null!;
    }
}
