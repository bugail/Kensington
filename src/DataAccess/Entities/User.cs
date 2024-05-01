// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="User.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using Kensington.DataAccess.Core;

namespace Kensington.DataAccess.Entities;

/// <summary>
/// The user entity.
/// </summary>
public class User : PrimaryKeyEntity<Guid>
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