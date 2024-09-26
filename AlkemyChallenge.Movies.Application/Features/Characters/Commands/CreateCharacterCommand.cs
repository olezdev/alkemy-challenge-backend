using AlkemyChallenge.Movies.Application.Contracts.Persistence;
using AlkemyChallenge.Movies.Domain.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AlkemyChallenge.Movies.Application.Features.Characters.Commands;

public class CreateCharacterCommand : IRequest<int>
{
    public string Image { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public decimal Weight { get; set; }
    public string? History { get; set; }
    public override string ToString()
    {
        return $"Character name: {Name}; Age: {Age}; Weight: {Weight}; Hisotry: {History}";
    }
}

public class CreateCharacterCommandHandler : IRequestHandler<CreateCharacterCommand, int>
{
    private readonly ICharacterRepository _characterRepository;
    private readonly IMapper _mapper;

    public CreateCharacterCommandHandler(ICharacterRepository characterRepository, IMapper mapper)
    {
        _characterRepository = characterRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
    {
        var character = _mapper.Map<Character>(request);
        await _characterRepository.AddAsync(character);
        await _characterRepository.SaveChangesAsync();
        return character.Id;
    }
}

public class CreateCharacterCommandValidator : AbstractValidator<CreateCharacterCommand>
{
    public CreateCharacterCommandValidator()
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

public class CreateCharacterCommandProfile : Profile
{
    public CreateCharacterCommandProfile()
    {
        CreateMap<CreateCharacterCommand, Character>();
    }
}