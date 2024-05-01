// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="GetUserQuery.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;

namespace Kensington.Core.Results;

/// <summary>
/// The user result object.
/// </summary>
public class UserResult
{
    /// <summary>
    /// Gets or sets the Id
    /// </summary>
    public Guid UserId { get; set; }

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