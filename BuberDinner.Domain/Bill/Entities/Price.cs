using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Bill.Entities;

public sealed class Price
{
    public decimal Amount { get; }
    public string? Currency { get; }
}