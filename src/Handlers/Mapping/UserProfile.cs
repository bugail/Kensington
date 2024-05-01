using AutoMapper;
using Kensington.Core.Commands;
using Kensington.Services.Requests;

namespace Kensington.Handlers.Mapping;

public class UserProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserProfile"/> class.
    /// </summary>
    public UserProfile()
    {
        CreateMap<CreateUserCommand, UserRequest>();
    }
}