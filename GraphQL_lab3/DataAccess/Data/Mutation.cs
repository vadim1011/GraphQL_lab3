using GraphQL.DataAccess.DAO;
using GraphQL.DataAccess.Entity;

namespace GraphQL.DataAccess.Data
{
    public class Mutation
    {
        public async Task<Author> CreateAuthor(
            string fullName,
            string email,
            string phone,
            string bio,
            [Service] AuthorRepository repo)
        {
            var author = new Author
            {
                FullName = fullName,
                Email = email,
                Phone = phone,
                Bio = bio
            };
            return await repo.CreateAuthor(author);
        }

        public async Task<Rubric> CreateRubric(
            string name,
            string? description,
            [Service] RubricRepository repo)
        {
            var rubric = new Rubric
            {
                Name = name,
                Description = description
            };
            return await repo.CreateRubric(rubric);
        }

        public async Task<Issue> CreateIssue(
            string journalTitle,
            int number,
            DateTime releaseDate,
            [Service] IssueRepository repo)
        {
            var issue = new Issue
            {
                JournalTitle = journalTitle,
                Number = number,
                ReleaseDate = DateTime.SpecifyKind(releaseDate, DateTimeKind.Utc)
            };
            return await repo.CreateIssue(issue);
        }

        public async Task<Article> CreateArticle(
            string title,
            decimal honorarium,
            int authorId,
            int rubricId,
            int issueId,
            [Service] ArticleRepository repo)
        {
            var article = new Article
            {
                Title = title,
                Honorarium = honorarium,
                AuthorId = authorId,
                RubricId = rubricId,
                IssueId = issueId
            };
            return await repo.CreateArticle(article);
        }
    }
}
