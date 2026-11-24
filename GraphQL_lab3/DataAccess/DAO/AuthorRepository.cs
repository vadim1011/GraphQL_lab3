using GraphQL.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.DataAccess.DAO
{
    public class AuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        // 1. Выдать список авторов с персональными данными
        public List<Author> GetAllAuthors()
        {
            return _context.Author.ToList();
        }

        // 4. Вывести справку о заданном авторе
        public Author GetAuthorById(int id)
        {
            var author = _context.Author
                .Include(a => a.Articles)
                .Where(a => a.AuthorId == id)
                .FirstOrDefault();

            if (author != null) return author;
            return null!;
        }

        public async Task<Author> CreateAuthor(Author author)
        {
            await _context.Author.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }
    }
}
