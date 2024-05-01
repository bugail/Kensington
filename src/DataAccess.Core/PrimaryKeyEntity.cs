// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="PrimaryKeyEntity.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Kensington.DataAccess.Core;

public abstract class PrimaryKeyEntity<TId>
{
    /// <summary>
    /// Gets or sets the Unique identifier
    /// </summary>
    public TId Id { get; set; }
}