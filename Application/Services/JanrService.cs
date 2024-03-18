using Application.Common;
using Application.DTOs.JanrDTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Infrastructure.Interfaces;

namespace Application.Services;

public class JanrService(IUnitOfWork unitOfWork,
                        IMapper mapper,
                        IValidator<Janr> validator) 
    : IJanrService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<Janr> _validator = validator;

    public async Task CreateAsync(AddJanrDto addJanrDto)
    {
        if (addJanrDto is null)
        {
            throw new BookException("AddJanrDtoIsNull");
        }

        var model = _mapper.Map<Janr>(addJanrDto);
        var result = await _validator.ValidateAsync(model);

        if (!result.IsValid)
        {
            throw new BookException(result);
        }

        await _unitOfWork.Janrs.AddAsync(model);
    }

    public async Task DeleteAsync(int id)
    {
        var model = await _unitOfWork.Janrs.GetByIdAsync(id);
        if (model is null)
        {
            throw new NotFoundException("Janr is not found");
        }

        await _unitOfWork.Janrs.DeleteAsync(model);
    }

    public async Task<List<JanrDto>> GetAllAsync()
    {
        var janrs = await _unitOfWork.Janrs.GetAllAsync();
        var result = janrs.Select(x => _mapper.Map<JanrDto>(x)).ToList();
        return result;
    }

    public async Task<JanrDto> GetByIdAsync(int id)
    {
        var model = await _unitOfWork.Janrs.GetByIdAsync(id);
        if (model is null)
        {
            throw new NotFoundException("Janr is not found");
        }
        return _mapper.Map<JanrDto>(model);
    }

    public async Task UpdateAsync(JanrDto updJanrDto)
    {
        var model = await _unitOfWork.Janrs.GetByIdAsync(updJanrDto.Id);
        if (model is null)
        {
            throw new NotFoundException("Janr is not found");
        }

        model.Name = updJanrDto.Name;

        var result = await _validator.ValidateAsync(model);
        if (!result.IsValid)
        {
            throw new BookException(result);
        }
        await _unitOfWork.Janrs.UpdateAsync(model);

       
    }
}
