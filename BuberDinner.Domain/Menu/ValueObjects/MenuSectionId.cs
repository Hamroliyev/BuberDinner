using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

public sealed class MuneSectionId : ValueObject
{
    public Guid Value { get; private set; }
    private MuneSectionId(Guid value)
    {
        Value = value;
    }
    public static MuneSectionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}