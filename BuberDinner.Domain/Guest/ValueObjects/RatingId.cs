using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Guest.ValueObjects;

public sealed class RatingId : ValueObject
{
    public Guid Value { get; private set; }
    private RatingId(Guid value)
    {
        Value = value;
    }
    public static RatingId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}