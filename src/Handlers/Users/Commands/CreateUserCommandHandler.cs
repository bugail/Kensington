using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Kensington.Core.Commands;
using Kensington.Core.Messages.Outbox;
using Kensington.Core.Results;
using Kensington.Services.Interfaces;
using Kensington.Services.Requests;
using MediatR;

namespace Kensington.Handlers.Users.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserResult>
{
    private readonly IUsersService usersService;
    private readonly IOutboxMessengerService outboxMessengerService;
    private readonly IMapper mapper;

    public CreateUserCommandHandler(
        IUsersService usersService,
        IOutboxMessengerService outboxMessengerService,
        IMapper mapper)
    {
        this.usersService = usersService;
        this.outboxMessengerService = outboxMessengerService;
        this.mapper = mapper;
    }

    public async Task<UserResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var bob = mapper.Map<UserRequest>(request);
        var email = new EmailOutboxDto("bob@mail.com", "New User Created", "New user created");
        await outboxMessengerService.SendMessageAsync(email, cancellationToken);
        return await usersService.PostAsync(bob, cancellationToken);
    }
}