using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MuneSectionId>
{
    private readonly List<MenuItem> _menuItems = new();
    public string Name { get; }
    public string Description { get; }
    public IReadOnlyList<MenuItem> MenuItems => _menuItems.AsReadOnly();

    private MenuSection(
        MuneSectionId menuSectionId,
        string name,
        string description,
        List<MenuItem>? menuItems)
         : base(menuSectionId)
    {
        Name = name;
        Description = description;
        this._menuItems = menuItems ?? new List<MenuItem>();
    }

    public static MenuSection Create(
        string name,
        string description,
        List<MenuItem>? menuItems)
    {
        return new(
            MuneSectionId.CreateUnique(),
            name,
            description,
            menuItems);
    }
}