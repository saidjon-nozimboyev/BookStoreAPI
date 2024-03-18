using Application.DTOs.AuthorDTOs;
using Application.DTOs.BookDTOs;
using Application.DTOs.JanrDTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Common;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AddAuthorDto, Author>();
        CreateMap<Author, AuthorDto>().ReverseMap();

        CreateMap<AddBookDto, Book>();
        CreateMap<Book, BookDto>().ReverseMap();

        CreateMap<AddJanrDto, Janr>();
        CreateMap<Janr, JanrDto>().ReverseMap();

    }
}
