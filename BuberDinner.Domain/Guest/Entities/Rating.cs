using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Guest.Entities;

public sealed class Rating : Entity<RatingId>
{
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public float Value { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Rating(
        RatingId ratingId,
        HostId hostId,
        DinnerId dinnerId,
        float value,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(ratingId)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Value = value;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Rating Create(
        HostId hostId,
        DinnerId dinnerId,
        float value)
    {
        return new(
            RatingId.CreateUnique(),
            hostId,
            dinnerId,
            value,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}