# String Calculator Kata Part 1

> Note: This is adapted from Roy Osherove's TDD Kata [Here](https://osherove.com/tdd-kata-1)

## The Point

To practice programming, yes.

But also to practice Test-Driven Development.

In the project `StringCalculator` you have two source code files.

One is `StringCalculatorTests` and the other is `StringCalculator`

The `StringCalculator` may only have **one** _public_ method on it, and it already does.

```csharp
public int Add(string numbers)
{
    return -42;
}
```

Your task is, by writing tests, to add the following functionality:

### An Empty String Returns Zero

Right now, that is failing. The test

```csharp
[Fact]
public void EmptyStringReturnsZero()
{
    var calculator = new StringCalculator();

    var result = calculator.Add("");

    Assert.Equal(0, result);
}
```

Modify the `Add` method to make this test pass. Don't worry about the next test.

> That 'Don't worry about the next test` is the _secret sauce_ of this Kata. Play dumb. Even if you've done it a million times. Write just enough to get this test to pass.

### A Single Digit Returns that Digit

The next one is when you pass a single digit to `StringCalculator#Add`, it returns that digit as a number.

For example:

```csharp
int answer = calculator.Add("2");
```

return `2` in the inswer.

```csharp
int answer = calculator.Add("212");
```

Returns `212` in the answer.

### Two Digits, Separated by a Comma

The next test should allow you to pass two numbers in.

```csharp
int answer = calculator.Add("1,2");
```

Should yield `3`

And

```csharp
int answer = calculator.Add("212,10");
```

Should yield `222`

> Safety Check - if when you are done with this step you can pass in multiple numbers (not just two) you have failed the kata!

For example, this would be "bad" (no need to write a test for it)

```csharp
int answer = calculator.Add("1,2,3");
```

Yielding `6`.

That's the next part.

### Unknown amount of Numbers

You saw this coming (but you didn't already write the code, _right?_... **RIGHT?**)

```csharp
int answer = calculator.Add("1,2,3");
```

Yields `6`

```csharp
int answer = calculator.Add("1,2,3,4,5,6,7,8,9");
```

Yields `45`

### Different Delimeters

```csharp
int answer = calculator.Add("1\n2\n3");
```

Yields `6`

> Note: the `\n` is a literal for a "new line"

Make sure all the previous tests _still_ pass.

Also, mixing delimeters is allowed.

```csharp
int answer = calculator.Add("1\n2,3");
```

Also yields `6`.
