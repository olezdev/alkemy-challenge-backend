using AlkemyChallenge.Movies.Application.Contracts.Persistence;
using AlkemyChallenge.Movies.Application.Exceptions;
using AlkemyChallenge.Movies.Domain.Entities;
using MediatR;

namespace AlkemyChallenge.Movies.Application.Features.Characters.Commands;

public class DeleteCharacterCommand : IRequest<Unit>
{
    public int Id { get; set; }
}

public class DeleteCharacterCommandHandler : IRequestHandler<DeleteCharacterCommand, Unit>
{
    private readonly ICharacterRepository _characterRepository;

    public DeleteCharacterCommandHandler(ICharacterRepository characterRepository)
    {
        _characterRepository = characterRepository;
    }

    public async Task<Unit> Handle(DeleteCharacterCommand request, CancellationToken cancellationToken)
    {
        var character = await _characterRepository.GetByIdAsync(request.Id);
        if (character == null)
        {
            throw new NotFoundException(nameof(Character), request.Id);
        }

        await _characterRepository.DeleteAsync(character);
        await _characterRepository.SaveChangesAsync();
        return Unit.Value;
    }
}