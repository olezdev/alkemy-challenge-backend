using AlkemyChallenge.Movies.Application.Contracts.Persistence;
using AlkemyChallenge.Movies.Application.Exceptions;
using AlkemyChallenge.Movies.Domain.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AlkemyChallenge.Movies.Application.Features.Characters.Commands;

public class UpdateCharacterCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Image { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public decimal Weight { get; set; }
    public string? History { get; set; }
}

public class UpdateCharacterCommandHandler : IRequestHandler<UpdateCharacterCommand, Unit>
{
    private readonly ICharacterRepository _characterRepository;
    private readonly IMapper _mapper;

    public UpdateCharacterCommandHandler(ICharacterRepository characterRepository, IMapper mapper)
    {
        _characterRepository = characterRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateCharacterCommand request, CancellationToken cancellationToken)
    {
        var character = await _characterRepository.GetByIdAsync(request.Id);
        if (character == null)
        {
            throw new NotFoundException(nameof(Character), request.Id);
        }

        _mapper.Map(request, character);
        await _characterRepository.UpdateAsync(character);
        await _characterRepository.SaveChangesAsync();
        return Unit.Value;
    }
}

public class UpdateCharacterCommandValidator : AbstractValidator<UpdateCharacterCommand>
{
    public UpdateCharacterCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        RuleFor(p => p.Age)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(0);
        RuleFor(p => p.Weight)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(0);
        RuleFor(p => p.History)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();
    }
}

public class UpdateCharacterCommandProfile : Profile
{
    public UpdateCharacterCommandProfile()
    {
        CreateMap<UpdateCharacterCommand, Character>().ReverseMap();
    }
}