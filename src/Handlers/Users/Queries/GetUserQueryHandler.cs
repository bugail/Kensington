using System.Threading;
using System.Threading.Tasks;
using Kensington.Core.Queries.Users;
using Kensington.Core.Results;
using Kensington.Services.Interfaces;
using MediatR;

namespace Kensington.Handlers.Users.Queries;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserResult>
{
    private readonly IUsersService userService;

    public GetUserQueryHandler(IUsersService userService)
    {
        this.userService = userService;
    }

    public Task<UserResult> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return userService.GetAsync(request.Id, cancellationToken);
    }
}