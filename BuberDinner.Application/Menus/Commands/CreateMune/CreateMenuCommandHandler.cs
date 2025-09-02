using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Host;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMune;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository menuRepository;

    public CreateMenuCommandHandler(
        IMenuRepository menuRepository)
    {
        this.menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var menu = Menu.Create(
            hostId: HostId.Create(request.HostId),
            name: request.Name,
            description: request.Description,
            sections: request.Sections.ConvertAll(section => MenuSection.Create(
                name: section.Name,
                description: section.Description,
                section.Items.ConvertAll(item => MenuItem.Create(
                    item.Name,
                    item.Description
                    )))));

        this.menuRepository.Add(menu);

        return menu;
    }
}
