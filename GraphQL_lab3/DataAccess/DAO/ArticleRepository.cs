using GraphQL.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.DataAccess.DAO
{
    public class ArticleRepository
    {
        private readonly AppDbContext _context;

        public ArticleRepository(AppDbContext context)
        {
            _context = context;
        }

        // 2. Вывести список статей заданного номера журнала
        public List<Article> GetArticlesByIssue(int issueId)
        {
            return _context.Article
                .Include(a => a.Author)
                .Include(a => a.Rubric)
                .Include(a => a.Issue)
                .Where(a => a.IssueId == issueId)
                .ToList();
        }

        // 3. Рассчитать гонорар всех авторов заданного номера журнала
        public List<AuthorHonorarium> GetAuthorsHonorariumByIssue(int issueId)
        {
            return _context.Article
                .Include(a => a.Author)
                .Where(a => a.IssueId == issueId)
                .GroupBy(a => new { a.AuthorId, a.Author.FullName })
                .Select(g => new AuthorHonorarium
                {
                    AuthorId = g.Key.AuthorId,
                    FullName = g.Key.FullName,
                    TotalHonorarium = g.Sum(a => a.Honorarium)
                })
                .ToList();
        }

        // 5. Для заданного автора выдать список всех опубликованных статей и размер гонорара за каждую
        public List<Article> GetArticlesByAuthor(int authorId)
        {
            return _context.Article
                .Include(a => a.Issue)
                .Include(a => a.Rubric)
                .Where(a => a.AuthorId == authorId)
                .ToList();
        }

        // 6. Вывести список статей всех журналов для заданной рубрики
        public List<Article> GetArticlesByRubric(int rubricId)
        {
            return _context.Article
                .Include(a => a.Author)
                .Include(a => a.Issue)
                .Include(a => a.Rubric)
                .Where(a => a.RubricId == rubricId)
                .ToList();
        }

        // 8. Рассчитать гонорар авторов заданной рубрики журналов, выпущенных в заданный период времени
        public decimal GetHonorariumByRubricAndPeriod(int rubricId, DateTime startDate, DateTime endDate)
        {
            return _context.Article
                .Include(a => a.Issue)
                .Where(a => a.RubricId == rubricId
                            && a.Issue.ReleaseDate >= startDate
                            && a.Issue.ReleaseDate <= endDate)
                .Sum(a => a.Honorarium);
        }

        // 9. Рассчитать общий гонорар заданного автора за статьи, опубликованные во всех номерах журналов
        public decimal GetTotalAuthorHonorarium(int authorId)
        {
            return _context.Article
                .Where(a => a.AuthorId == authorId)
                .Sum(a => a.Honorarium);
        }

        public async Task<Article> CreateArticle(Article article)
        {
            await _context.Article.AddAsync(article);
            await _context.SaveChangesAsync();
            return article;
        }
    }
}
