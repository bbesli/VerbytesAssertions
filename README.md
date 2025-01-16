
# VerbytesAssertions

**VerbytesAssertions** is a modern, developer-friendly assertion library for .NET applications. Inspired by FluentAssertions, it provides a highly expressive, intuitive, and readable syntax for asserting the behavior and state of objects, methods, and systems during automated testing. Compatible with **xUnit**, **NUnit**, or **MSTest**, VerbytesAssertions simplifies and enhances your testing process.

---

## Features

- **Fluent Syntax**: Chainable, human-readable assertions.
- **Wide Assertion Coverage**: Support for booleans, strings, enums, collections, and more.
- **Custom Extensions**: Easily extend the library with your own assertion types.
- **Detailed Error Messages**: Clear and detailed feedback for failed tests.
- **Lightweight & Dependency-Free**: No external libraries required.
- **Seamless Integration**: Works out of the box with popular test frameworks like xUnit, NUnit, and MSTest.

---

## Project Structure

The project is structured into the following components:

- **`Primitives/`**: Core assertions for primitive types like booleans, strings, enums, etc.
- **`Extensions/`**: Fluent extensions for enabling `.Should()` syntax.
- **`Exceptions/`**: Custom exception types for better error messages.
- **`Properties/`**: Reserved for project-level properties or shared configurations.

---

## Installation

To include VerbytesAssertions in your project, copy the library's source files into your solution.

---

## Usage

### Boolean Assertions

```csharp
bool value = true;

// Check if the value is true
value.Should().BeTrue();

// Check if the value is false
value.Should().BeFalse();

// Check if the value matches the expected
value.Should().Be(true);

// Ensure the value is not equal to the unexpected
value.Should().NotBe(false);
```

### String Assertions

```csharp
string text = "Hello, World!";

// Check for equality
text.Should().Be("Hello, World!");

// Check for inequality
text.Should().NotBe("Goodbye");

// Check if it contains a substring
text.Should().Contain("World");

// Check if it starts or ends with specific text
text.Should().StartWith("Hello");
text.Should().EndWith("!");

// Check if it matches a regex
text.Should().MatchRegex(@"[A-Za-z, ]+!");
```

### Enum Assertions

```csharp
public enum MyEnum
{
    Value1 = 1,
    Value2 = 2,
    Value3 = 4
}

MyEnum myEnum = MyEnum.Value1;

// Check for equality
myEnum.Should().Be(MyEnum.Value1);

// Check for inequality
myEnum.Should().NotBe(MyEnum.Value2);

// Check if the enum value is defined in the enum type
myEnum.Should().BeDefined();

// Check if the enum has a specific flag
myEnum.Should().HaveFlag(MyEnum.Value1);

// Check if the enum value is one of several valid values
myEnum.Should().BeOneOf(MyEnum.Value1, MyEnum.Value2);
```

### Collection Assertions

```csharp
var collection = new List<int> { 1, 2, 3, 4 };

// Check if the collection contains an item
collection.Should().Contain(2);

// Check if it does not contain an item
collection.Should().NotContain(5);

// Check the count of items
collection.Should().HaveCount(4);

// Check if it contains all specific items
collection.Should().ContainAll(new[] { 1, 2 });

// Check if it matches exactly
collection.Should().BeEquivalentTo(new[] { 1, 2, 3, 4 });
```

---

## How to Write Tests with VerbytesAssertions

You can use VerbytesAssertions in your test projects with testing frameworks like xUnit, MSTest, or NUnit.

### xUnit Example

```csharp
using VerbytesAssertions.Exceptions;
using VerbytesAssertions.Extensions;
using Xunit;

public class BooleanAssertionsTests
{
    [Fact]
    public void BeTrue_ShouldPass_WhenValueIsTrue()
    {
        true.Should().BeTrue();
    }

    [Fact]
    public void BeFalse_ShouldFail_WhenValueIsTrue()
    {
        Assert.Throws<AssertionException>(() =>
        {
            true.Should().BeFalse();
        });
    }
}
```

---

## Future Enhancements

- Create NuGet packaging for easy distribution.
- Enhance error reporting with richer context details.

---

## License

This library is distributed under the MIT License.
