using GraphQL.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.DataAccess.DAO
{
    public class IssueRepository
    {
        private readonly AppDbContext _context;

        public IssueRepository(AppDbContext context)
        {
            _context = context;
        }

        // 10. Выдать информацию о всех номерах журнала
        public List<Issue> GetAllIssues()
        {
            return _context.Issue.ToList();
        }

        public List<Issue> GetAllIssuesWithArticles()
        {
            return _context.Issue.Include(i => i.Articles).ToList();
        }

        public async Task<Issue> CreateIssue(Issue issue)
        {
            await _context.Issue.AddAsync(issue);
            await _context.SaveChangesAsync();
            return issue;
        }
    }
}
