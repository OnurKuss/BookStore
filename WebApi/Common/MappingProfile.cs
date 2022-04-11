using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Applications.AuthorOperations.Commands.CreateAuthor;
using WebApi.Applications.BookOperations;
using WebApi.Applications.GenreOperations.Queries.GetGenres;
using WebApi.Applications.UserOperations.Commands.CreateUser;
using WebApi.Entities;
using static WebApi.Applications.AuthorOperations.Queries.GetAuthorDetail.GetAuthorDetailQuery;
using static WebApi.Applications.AuthorOperations.Queries.GetAuthors.GetAuthorsQuery;
using static WebApi.Applications.GenreOperations.Queries.GetGenreDetail.GetGenreDetailQuery;

namespace WebApi.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookIdViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                                      .ForMember(dest=> dest.Author, opt=> opt.MapFrom(src=> src.Author.FirstName+ " " +src.Author.LastName));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<CreateAuthorModel, Author>();
            CreateMap<Author, AuthorDetailViewModel>();
            CreateMap<Author, AuthorViewModel>();

            CreateMap<CreateUserModel, User>();
            
        }
    }
}
