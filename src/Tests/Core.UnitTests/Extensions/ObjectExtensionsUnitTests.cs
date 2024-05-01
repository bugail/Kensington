using System;
using Kensington.Core.Extensions;

namespace Kensington.Core.UnitTests.Extensions;

public class ObjectExtensionsUnitTests
{
    [TestCase(null, ExpectedResult = null)]
    [TestCase(123, ExpectedResult = "123")]
    [TestCase(10.0, ExpectedResult = "10")]
    [TestCase(true, ExpectedResult = "True")]
    [TestCase(false, ExpectedResult = "False")]
    [TestCase(false, ExpectedResult = "False")]
    [TestCase("Hello World", ExpectedResult = "Hello World")]
    public string ChangeType_Returns_ValidString(object value)
    {
        var result = value.ChangeType<string>();
        return result;
    }

    [TestCase("e49b30a5-55a8-47f9-814e-c40b4aaba47d", ExpectedResult = "e49b30a5-55a8-47f9-814e-c40b4aaba47d")]
    public string ChangeType_ValidGuid_Returns_ValidString(string guidValue)
    {
        var guid = new Guid(guidValue);
        var result = guid.ChangeType<string>();
        return result;
    }

    [TestCase(null, ExpectedResult = null)]
    [TestCase(123, ExpectedResult = 123)]
    [TestCase(10.0, ExpectedResult = 10)]
    [TestCase(1234, ExpectedResult = 1234)]
    public int? ChangeType_Returns_ValidNullInt(object value)
    {
        var result = value.ChangeType<int?>();
        return result;
    }

    [TestCase(null, ExpectedResult = null)]
    [TestCase(1, ExpectedResult = true)]
    [TestCase(0, ExpectedResult = false)]
    [TestCase(1.0, ExpectedResult = true)]
    [TestCase(0.0, ExpectedResult = false)]
    [TestCase("1", ExpectedResult = true)]
    [TestCase("0", ExpectedResult = false)]
    [TestCase("true", ExpectedResult = true)]
    [TestCase("false", ExpectedResult = false)]
    public bool? ChangeType_Returns_ValidBool(object value)
    {
        var result = value.ChangeType<bool?>();
        return result;
    }

    [TestCase(1, ExpectedResult = 1)]
    [TestCase(0, ExpectedResult = 0)]
    [TestCase(1.0, ExpectedResult = 1)]
    [TestCase(0.0, ExpectedResult = 0)]
    [TestCase("1", ExpectedResult = 1)]
    [TestCase("0", ExpectedResult = 0)]
    [TestCase("1122", ExpectedResult = 1122)]
    [TestCase("0111", ExpectedResult = 111)]
    [TestCase("-111", ExpectedResult = -111)]
    public int ChangeType_Returns_ValidInt(object value)
    {
        var result = value.ChangeType<int>();
        return result;
    }
}