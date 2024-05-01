// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ObjectExtensions.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace Kensington.Core.Extensions;

public static class TypeExtensions
{
  public static string GetGenericTypeName(this Type type)
  {
    string empty = string.Empty;
    string genericTypeName;
    if (type.IsGenericType)
    {
      string str = string.Join(",", type.GetGenericArguments().Select((Func<Type, string>)(t => t.Name)).ToArray<string>());
      genericTypeName = type.Name.Remove(type.Name.IndexOf('`')) + "<" + str + ">";
    }
    else
    {
      genericTypeName = type.Name;
    }

    return genericTypeName;
  }
}