using GraphQL.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.DataAccess.DAO
{
    public class RubricRepository
    {
        private readonly AppDbContext _context;

        public RubricRepository(AppDbContext context)
        {
            _context = context;
        }

        // 7. Выдать список всех рубрик журналов
        public List<Rubric> GetAllRubrics()
        {
            return _context.Rubric.ToList();
        }

        public List<Rubric> GetAllRubricsWithArticles()
        {
            return _context.Rubric.Include(r => r.Articles).ToList();
        }

        public async Task<Rubric> CreateRubric(Rubric rubric)
        {
            await _context.Rubric.AddAsync(rubric);
            await _context.SaveChangesAsync();
            return rubric;
        }
    }
}
