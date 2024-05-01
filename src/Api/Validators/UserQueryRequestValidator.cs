// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="FizzBuzzQueryRequest.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using FluentValidation;
using Kensington.Api.QueryRequests;

namespace Kensington.Api.Validators;

public class UserQueryRequestValidator : AbstractValidator<UserQueryRequest>
{
    public UserQueryRequestValidator()
    {
    }
}