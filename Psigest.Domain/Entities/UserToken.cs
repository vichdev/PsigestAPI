namespace Psigest.Domain.Entities;
public sealed class UserToken(string value, DateTime expirationTime)
{
    public string Value { get; private set; } = value;
    public DateTime ExpirationTime { get; private set; } = expirationTime;
}
