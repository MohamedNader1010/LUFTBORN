using LUFTBORN.Domain.Common;
using LUFTBORN.Domain.Users.Events;

namespace LUFTBORN.Domain.Users;

public class User : Entity
{
    public string Email { get; private set; } = null!;

    public string FirstName { get; private set; } = null!;

    public string LastName { get; private set; } = null!;
    

    public User(
        Guid id,
        string firstName,
        string lastName,
        string email)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        
        _domainEvents.Add(new UserCreatedEvent(this));
    }

    public void Update(
        string firstName,
        string lastName,
        string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    private User()
    {
    }
}