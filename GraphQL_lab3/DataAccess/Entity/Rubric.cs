using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.DataAccess.Entity
{
    public class Rubric
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RubricId { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
