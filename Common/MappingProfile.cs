using AutoMapper;
using BookStoreApi.Models.Entities;
using BookStoreApi.Models.Repositories;

namespace BookStoreApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BooksModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.GenreName))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.AuthorName + " " + src.Author.AuthorSurname));
            CreateMap<Book, BookModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.GenreName))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.AuthorName + " " + src.Author.AuthorSurname));
            CreateMap<Genre, GenreModel>();
            CreateMap<GenreModel, Genre>();
            CreateMap<Author, AuthorModel>();
            CreateMap<AuthorModel, Author>();
        }
    }
}
