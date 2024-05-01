// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="UserProfile.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using AutoMapper;
using Kensington.Api.QueryRequests;
using Kensington.Api.Responses;
using Kensington.Core.Results;
using Kensington.Services.Requests;

namespace Kensington.Api.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserResult, UserResponse>();

        CreateMap<UserQueryRequest, UserRequest>();
    }
}