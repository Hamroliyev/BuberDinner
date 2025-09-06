using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinners = new();
    private readonly List<MenuReviewId> _menuReviews = new();
    public string Name { get; private set; }
    public string Description { get; private set; }
    public float AverageRating { get; private set; } = 0;
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public HostId HostId { get; }
    public IReadOnlyList<DinnerId> Dinners => _dinners.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviews => _menuReviews.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Menu(
        MenuId menuId,
        HostId hostId,
        string name,
        string description,
        List<MenuSection> sections)
        : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        _sections = sections;
    }

    public static Menu Create(
        string name,
        string description,
        HostId hostId,
        List<MenuSection>? sections)
    {
        return new(
            MenuId.CreateUnique(),
            hostId,
            name,
            description,
            sections ?? new List<MenuSection>());
    }
    
    private Menu(MenuId menuId) : base(menuId) { /* For EF */ }
}