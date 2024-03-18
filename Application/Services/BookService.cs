using Application.Common;
using Application.DTOs.BookDTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Infrastructure.Interfaces;

namespace Application.Services;

public class BookService(IUnitOfWork unitOfWork,
                            IMapper mapper,
                            IValidator<Book> validator)
    : IBookService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<Book> _validator = validator;

    public async Task CreateAsync(AddBookDto addBookDto)
    {
        if (addBookDto == null)
        {
            throw new BookException("Model is null");
        }

        var model = _mapper.Map<Book>(addBookDto);
        var result = await _validator.ValidateAsync(model);

        if (!result.IsValid)
        {
            throw new BookException(result);
        }

        await _unitOfWork.Books.AddAsync(model);
    }

    public async Task DeleteAsync(int id)
    {
        var model = await _unitOfWork.Books.GetByIdAsync(id);
        if (model == null)
        {
            throw new BookException("Not found");
        }

        await _unitOfWork.Books.DeleteAsync(model);
    }

    public async Task<List<BookDto>> GetAllAsync()
    {
        var list = await _unitOfWork.Books.GetAllAsync();
        var result = list.Select(_mapper.Map<BookDto>).ToList();
        return result;
    }

    public async Task<BookDto> GetByIdAsync(int id)
    {
        var model = await _unitOfWork.Books.GetByIdAsync(id);
        if (model == null)
        {
            throw new NotFoundException("Book not found");
        }
        return _mapper.Map<BookDto>(model);
    }

    public async Task UpdateAsync(BookDto updBookDto)
    {
        var model = await _unitOfWork.Books.GetByIdAsync(updBookDto.Id);
        if (model == null)
        {
            throw new NotFoundException("Book not found");
        }

        model.Name = updBookDto.Name;
        model.Price = updBookDto.Price;

        var result = await _validator.ValidateAsync(model);
        if (!result.IsValid)
        {
            throw new BookException(result);
        }

        await _unitOfWork.Books.UpdateAsync(model);
    }
}
