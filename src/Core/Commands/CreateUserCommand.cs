// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CreateUserCommand.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using Kensington.Core.Results;
using MediatR;

namespace Kensington.Core.Commands;

public class CreateUserCommand : IRequest<UserResult>
{
    public CreateUserCommand(string firstname, string surname, string displayName)
    {
        Firstname = firstname;
        Surname = surname;
        DisplayName = displayName;
    }

    public string Firstname { get; }
    public string Surname { get; }
    public string DisplayName { get; }
}