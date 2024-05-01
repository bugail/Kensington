using AutoMapper;
using Kensington.DataAccess.Entities;
using Kensington.DataAccess.Queries;

namespace Kensington.DataAccess.Mapping;

/// <summary>
/// The user mapping profile.
/// </summary>
public class UserProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserProfile"/> class.
    /// </summary>
    public UserProfile()
    {
        CreateMap<UserQuery, User>();
    }
}