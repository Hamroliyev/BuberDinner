using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _menuItems;
    public string Name { get; }
    public string Description { get; }
    public IReadOnlyList<MenuItem> MenuItems => _menuItems.AsReadOnly();

    private MenuSection(
        MenuSectionId menuSectionId,
        string name,
        string description,
        List<MenuItem>? menuItems)
         : base(menuSectionId)
    {
        Name = name;
        Description = description;
        _menuItems = menuItems ?? new List<MenuItem>();
    }

    public static MenuSection Create(
        string name,
        string description,
        List<MenuItem>? menuItems)
    {
        return new(
            MenuSectionId.CreateUnique(),
            name,
            description,
            menuItems);
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private MenuSection() { } // For EF Core
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}