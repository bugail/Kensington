// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ObjectExtensions.cs" company="Bugail Consulting Ltd">
//      Copyright 2024 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;

namespace Kensington.Core.Extensions;

public static class ObjectExtensions
{
    public static T ChangeType<T>(this object value)
    {
        var t = typeof(T);
        var currentValue = value;

        if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            if (value == null)
            {
                return default;
            }

            t = Nullable.GetUnderlyingType(t);
        }

        if (t == typeof(bool))
        {
            try
            {
                currentValue = Convert.ToBoolean(currentValue);
            }
            catch (Exception)
            {
                currentValue = Convert.ChangeType(currentValue, typeof(int));
            }
        }

        if (t == typeof(string))
        {
            return (T)(object)currentValue?.ToString();
        }

        return (T)Convert.ChangeType(currentValue, t);
    }

    public static string GetGenericTypeName(this object @object)
    {
        return TypeExtensions.GetGenericTypeName(@object.GetType());
    }
}