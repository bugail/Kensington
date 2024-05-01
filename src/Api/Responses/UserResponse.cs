// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="RegistrationTests.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Kensington.Api.Responses;

public class UserResponse
{
    public UserResponse()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UserResponse"/> class.
    /// </summary>
    /// <param name="firstname">The firstname.</param>
    /// <param name="surname">The surname.</param>
    /// <param name="displayName">The display name.</param>
    public UserResponse(string firstname, string surname, string displayName)
    {
        Firstname = firstname;
        Surname = surname;
        DisplayName = displayName;
    }

    public string Firstname { get; }
    public string Surname { get; }
    public string DisplayName { get; }
}