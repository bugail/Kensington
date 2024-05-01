// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="FizzBuzzController.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using AutoMapper;
using Kensington.Api.QueryRequests;
using Kensington.Api.Responses;
using Kensington.Services.Interfaces;
using Kensington.Services.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kensington.Api.Controllers.v1;

/// <summary>
/// The fizzBuzz controller.
/// </summary>
[Route("api/v1/[controller]")]
public class FizzBuzzController : BaseController
{
    private readonly IFizzBuzzService service;
    private readonly IMapper mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="FizzBuzzController"/> class.
    /// </summary>
    /// <param name="service">The fizzbuzz service.</param>
    /// <param name="mapper">The mapper.</param>
    public FizzBuzzController(
        IFizzBuzzService service,
        IMapper mapper)
    {
        this.service = service;
        this.mapper = mapper;
    }

    /// <summary>
    /// Post to get a fizzbuzz result.
    /// </summary>
    /// <param name="request">The request</param>
    /// <returns>A list of <see cref="string"/>.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IEnumerable<string> Post([FromBody]FizzBuzzQueryRequest request)
    {
        return service.GetFizzBuzzResults(mapper.Map<FizzBuzzRequest>(request));
    }
}