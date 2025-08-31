using BuberDinner.Domain.Menu;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMune;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    public Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        // Create the Menu entity from the command
        // Persist the Menu entity using a repository (not shown here)
        // Return the created Menu entity wrapped in ErrorOr
        return default!;
    }
}
