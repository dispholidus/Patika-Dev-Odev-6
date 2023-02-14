using AutoMapper;
using BookStoreApi.DbOperations;
using BookStoreApi.Models.Entities;

namespace BookStoreApi.Models.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookStoreDbContext _bookStoreDbContext;
        private readonly IMapper _mapper;

        public AuthorRepository(BookStoreDbContext bookStoreDbContext, IMapper mapper)
        {
            _bookStoreDbContext = bookStoreDbContext;
            _mapper = mapper;
        }

        public bool AddAuthor(AuthorModel authorModel)
        {
            Author? author = _bookStoreDbContext.Authors.FirstOrDefault(a => a.AuthorName == authorModel.AuthorName && a.AuthorSurname == authorModel.AuthorSurname);
            if (author != null)
            {
                return false;
            }

            author = _mapper.Map<Author>(authorModel);

            _bookStoreDbContext.Authors.Add(author);
            _bookStoreDbContext.SaveChanges();

            return true;
        }

        public bool DeleteAuthorById(int authorId)
        {
            Author? author = _bookStoreDbContext.Authors.FirstOrDefault(a => a.AuthorId == authorId);
            if (author != null)
            {
                Book? book = _bookStoreDbContext.Books.FirstOrDefault(b => b.Author.AuthorName == author.AuthorName);
                if (book != null)
                {
                    return false;
                }
                _bookStoreDbContext.Remove(author);
                _bookStoreDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public AuthorModel? GetAuthorById(int authorId)
        {
            Author? author = _bookStoreDbContext.Authors.FirstOrDefault(a => a.AuthorId == authorId);
            if (author != null)
            {
                AuthorModel authorModel = _mapper.Map<AuthorModel>(author);
                return authorModel;
            }
            return null;

        }

        public IEnumerable<AuthorModel> GetAuthors()
        {
            IEnumerable<Author> authors = _bookStoreDbContext.Authors.OrderBy(a => a.AuthorId).ToList();
            List<AuthorModel> authorModels = new();
            foreach (Author author in authors)
            {
                authorModels.Add(_mapper.Map<AuthorModel>(author));
            }
            return authorModels;
        }

        public bool UpdateAuthorById(int authorId, AuthorModel authorModel)
        {
            Author? author = _bookStoreDbContext.Authors.FirstOrDefault(b => b.AuthorId == authorId);
            if (author != null)
            {
                author.AuthorName = authorModel.AuthorName != default ? authorModel.AuthorName : author.AuthorName;
                author.AuthorSurname = authorModel.AuthorSurname != default ? authorModel.AuthorSurname : author.AuthorSurname;
                author.AuthorBirthday = authorModel.AuthorBirthday != default ? authorModel.AuthorBirthday : author.AuthorBirthday;
                _bookStoreDbContext.SaveChanges();
                return true;

            }
            return false;
        }
    }
    public class AuthorModel
    {
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorSurname { get; set; } = string.Empty;
        public DateTime AuthorBirthday { get; set; }
    }
}
