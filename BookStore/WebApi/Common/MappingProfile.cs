using AutoMapper;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Entities;

namespace WebApi.Common;

public class MappingProfile : Profile 
{
    public MappingProfile()
    {
        CreateMap<CreateBookModel, Book>(); 
            
        CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre,
                opt => opt.MapFrom(src => src.Genre.Name)); //src.Genre.Name şeklinde güncelledik çünkü book entitysinde artık genre de var
        
        CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre,
            opt => opt.MapFrom(src => src.Genre.Name));
        
        //Genre
        
        CreateMap<Genre, GenresViewModel>();
        
        CreateMap<Genre, GenreDetailViewModel>();
        
        // Author
        
        CreateMap<Author,AuthorViewModel>();
        
        CreateMap<Author,AuthorDetailViewModel>();
        
        CreateMap<CreateAuthorModel,Author>();
    }
   
    
}