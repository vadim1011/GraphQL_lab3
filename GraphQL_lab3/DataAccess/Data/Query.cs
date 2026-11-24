using GraphQL.DataAccess.DAO;
using GraphQL.DataAccess.Entity;

namespace GraphQL.DataAccess.Data
{
    public class Query
    {
        // 1. Выдать список авторов с персональными данными
        public List<Author> GetAuthors([Service] AuthorRepository repo)
        {
            return repo.GetAllAuthors();
        }

        // 2. Вывести список статей заданного номера журнала
        public List<Article> GetArticlesByIssue(int issueId, [Service] ArticleRepository repo)
        {
            return repo.GetArticlesByIssue(issueId);
        }

        // 3. Рассчитать гонорар всех авторов заданного номера журнала
        public List<AuthorHonorarium> GetAuthorsHonorariumByIssue(int issueId, [Service] ArticleRepository repo)
        {
            return repo.GetAuthorsHonorariumByIssue(issueId);
        }

        // 4. Вывести справку о заданном авторе
        public Author GetAuthorInfo(int authorId, [Service] AuthorRepository repo)
        {
            return repo.GetAuthorById(authorId);
        }

        // 5. Для заданного автора выдать список всех опубликованных статей и размер гонорара за каждую
        public List<Article> GetAuthorArticlesWithHonorarium(int authorId, [Service] ArticleRepository repo)
        {
            return repo.GetArticlesByAuthor(authorId);
        }

        // 6. Вывести список статей всех журналов для заданной рубрики
        public List<Article> GetArticlesByRubric(int rubricId, [Service] ArticleRepository repo)
        {
            return repo.GetArticlesByRubric(rubricId);
        }

        // 7. Выдать список всех рубрик журналов
        public List<Rubric> GetRubrics([Service] RubricRepository repo)
        {
            return repo.GetAllRubrics();
        }

        // 8. Рассчитать гонорар авторов заданной рубрики журналов, выпущенных в заданный период времени
        public decimal GetHonorariumByRubricAndPeriod(
            int rubricId,
            DateTime startDate,
            DateTime endDate,
            [Service] ArticleRepository repo)
        {
            // PostgreSQL требует DateTime с Kind = Utc
            var utcStart = DateTime.SpecifyKind(startDate, DateTimeKind.Utc);
            var utcEnd = DateTime.SpecifyKind(endDate, DateTimeKind.Utc);
            return repo.GetHonorariumByRubricAndPeriod(rubricId, utcStart, utcEnd);
        }

        // 9. Рассчитать общий гонорар заданного автора за статьи, опубликованные во всех номерах журналов
        public decimal GetTotalAuthorHonorarium(int authorId, [Service] ArticleRepository repo)
        {
            return repo.GetTotalAuthorHonorarium(authorId);
        }

        // 10. Выдать информацию о всех номерах журнала
        public List<Issue> GetIssues([Service] IssueRepository repo)
        {
            return repo.GetAllIssues();
        }
    }
}
