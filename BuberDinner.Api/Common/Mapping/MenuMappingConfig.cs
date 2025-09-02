using BuberDinner.Application.Menus.Commands.CreateMune;
using BuberDinner.Contracts.Menus;
using BuberDinner.Domain.Menu;
using Mapster;

using MenuSection = BuberDinner.Domain.Menu.Entities.MenuSection;
using MenuItem = BuberDinner.Domain.Menu.Entities.MenuItem;

namespace BuberDinner.Api.Common.Mapping;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest request, string hostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.hostId)
            .Map(dest => dest, src => src.request);

        config.NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.AverageRating, src => src.AverageRating)
            .Map(dest => dest.HostId, src => src.HostId.Value)
            .Map(dest => dest.DinnerIds, src => src.Dinners.Select(dinnerId => dinnerId))
            .Map(dest => dest.MenuReviewIds, src => src.MenuReviews.Select(menuReviewId => menuReviewId));

        config.NewConfig<MenuSection, MenuSectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<MenuItem, MenuItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}