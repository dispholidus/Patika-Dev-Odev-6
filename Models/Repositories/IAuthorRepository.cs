using BookStoreApi.Models.Entities;

namespace BookStoreApi.Models.Repositories
{
    public interface IAuthorRepository
    {
        public AuthorModel? GetAuthorById(int authorId);
        public IEnumerable<AuthorModel> GetAuthors();
        public bool AddAuthor(AuthorModel authorModel);
        public bool UpdateAuthorById(int authorId, AuthorModel authorModel);
        public bool DeleteAuthorById(int authorId);
    }
}
