using AutoMapper;
using Kensington.Core.Results;
using Kensington.DataAccess.Entities;
using Kensington.DataAccess.Queries;
using Kensington.Services.Requests;

namespace Kensington.Services.Mapping;

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
        CreateMap<User, UserResult>();
        CreateMap<UserRequest, UserQuery>();
    }
}