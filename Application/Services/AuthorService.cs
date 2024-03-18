using Application.Common;
using Application.DTOs.AuthorDTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Infrastructure.Interfaces;

namespace Application.Services;

public class AuthorService(IUnitOfWork unitOfWork,
                            IMapper mapper,
                            IValidator<Author> validator) 
    : IAuthorService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<Author> _validator = validator;

    public async Task CreateAsync(AddAuthorDto addAuthorDto)
    {
        if (addAuthorDto is null)
        {
            throw new BookException("AuthorDto is null");
        }

        var model = _mapper.Map<Author>(addAuthorDto);
        var result = await _validator.ValidateAsync(model);
        if (!result.IsValid)
        {
            throw new BookException(result);
        }

        await _unitOfWork.Authors.AddAsync(model);

    }

    public async Task DeleteAsync(int id)
    {
        var model = await _unitOfWork.Authors.GetByIdAsync(id);
        if (model is null) 
        {
            throw new NotFoundException("Author not found");
        }

        await _unitOfWork.Authors.DeleteAsync(model);
    }

    public async Task<List<AuthorDto>> GetAllAsync()
    {
        var list = await _unitOfWork.Authors.GetAllAsync();
        var result = list.Select(_mapper.Map<AuthorDto>).ToList();
        return result;
    }

    public async Task<AuthorDto> GetByIdAsync(int id)
    {
        var model = await _unitOfWork.Authors.GetByIdAsync(id);
        if (model is null)
        {
            throw new NotFoundException("Author not found");
        }

        return _mapper.Map<AuthorDto>(model);
    }

    public async Task UpdateAsync(AuthorDto updAuthorDto)
    {
        var model = await _unitOfWork.Authors.GetByIdAsync(updAuthorDto.Id);
        if (model is null)
        {
            throw new BookException("Author not found");
        }

        model.Name = updAuthorDto.Name;

        var result = await _validator.ValidateAsync(model);
        if (!result.IsValid)
        {
            throw new BookException(result);
        }

        await _unitOfWork.Authors.UpdateAsync(model);
    }
}
