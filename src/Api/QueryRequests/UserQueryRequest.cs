// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="UserQueryRequest.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Kensington.Api.QueryRequests;

public class UserQueryRequest
{
    /// <summary>
    /// Gets or sets the Firstname
    /// </summary>
    public string Firstname { get; set; }

    /// <summary>
    /// Gets or sets the Surname
    /// </summary>
    public string Surname { get; set; }

    /// <summary>
    /// Gets or sets the Displayname
    /// </summary>
    public string Displayname { get; set; }
}