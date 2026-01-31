using SkunkWorksBank.Application.SharedContext.UseCases.Abstractions;
using SkunkWorksBank.Domain.Users.Entities;

namespace SkunkWorksBank.Application.UserContext.UseCases.Get
{
    public record Response(
        Guid Id,
        string Cpf,
        string FullName,
        bool IsActive,
        DateOnly Birthdate,
        bool IsPep,
        DateTime CreatedAt,
        DateTime UpdatedAt,
        UserStatusResponse UserStatus,
        List<UserContactResponse> Contacts
        ) : IQueryResponse

    {
        public static Response FromEntity(User user)
        {
            return new Response(
                 user.Id,
                 user.Cpf,
                 user.FullName,
                 user.IsActive,
                 user.Birthdate,
                 user.IsPep,
                 user.Tracker.CreatedAt,
                 user.Tracker.UpdatedAt,
                 new UserStatusResponse(user.UserStatus.Id, user.UserStatus.Name),
                 user.Contacts.Select(contact => new UserContactResponse(
                     contact.Id,
                     contact.UserId,
                     new ContactTypeResponse(
                         contact.ContactType.Id,
                         contact.ContactType.Value.ToString()
                     ),
                     contact.Value,
                     contact.IsPrimary,
                     contact.IsVerified
                 )).ToList()
            );
        }
    }

    //records de apoio
    public record UserStatusResponse(
        int Id,
        string Name
    );

    public record ContactTypeResponse(
        int Id,
        string Name
    );

    public record UserContactResponse(
        int Id,
        Guid UserId,
        ContactTypeResponse ContactType,
        string Value,
        bool IsPrimary,
        bool IsVerified
    );
}
