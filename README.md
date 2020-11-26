# Griffin+ Expressions Library

[![Azure DevOps builds (branch)](https://img.shields.io/azure-devops/build/griffinplus/2f589a5e-e2ab-4c08-bee5-5356db2b2aeb/32/master?label=Build)](https://dev.azure.com/griffinplus/DotNET%20Libraries/_build/latest?definitionId=32&branchName=master)
[![Tests (master)](https://img.shields.io/azure-devops/tests/griffinplus/DotNET%20Libraries/32/master?label=Tests)](https://dev.azure.com/griffinplus/DotNET%20Libraries/_build/latest?definitionId=32&branchName=master)
[![NuGet Version](https://img.shields.io/nuget/v/GriffinPlus.Lib.Expressions.svg)](https://www.nuget.org/packages/GriffinPlus.Lib.Expressions)
[![NuGet Downloads](https://img.shields.io/nuget/dt/GriffinPlus.Lib.Expressions.svg)](https://www.nuget.org/packages/GriffinPlus.Lib.Expressions)

## Overview

The *Griffin+ Expressions Library* contains helpers that come in handy when working with LINQ expressions.

It provides the following features:
- Inlining Lambda Expressions
- Composing Lambda Expressions
- Comparing Expressions

The library follows semantic versioning, so it should be safe to use higher versions of the library, as long as the
major version number does not change.

## Supported Platforms

The library is entirely written in C# using .NET Standard 2.0.

Therefore it should work on the following platforms (or higher):
- .NET Framework 4.6.1
- .NET Core 2.0
- .NET 5.0
- Mono 5.4
- Xamarin iOS 10.14
- Xamarin Mac 3.8
- Xamarin Android 8.0
- Universal Windows Platform (UWP) 10.0.16299

The library is tested automatically on the following frameworks and operating systems:
- .NET Framework 4.6.1 (Windows Server 2019)
- .NET Core 2.1 (Windows Server 2019 and Ubuntu 20.04)
- .NET Core 3.1 (Windows Server 2019 and Ubuntu 20.04)
- .NET 5.0  (Windows Server 2019 and Ubuntu 20.04)

## Usage

The *Griffin+ Expressions Library* ships everything in the `GriffinPlus.Lib.Expressions` namespace.

### Inlining Lambda Expressions

Usually lambda expressions have to be assigned to a variable before they can be used elsewhere, because the compiler
cannot infer the parameter types and the return type from a lambda expression. This prevents expressions from being
used inline. The static `EXPR` methods in the `LambdaExpressionInliners` class help to circumvent this limitation.
These generic methods mimic the signature of the desired lambda expression and return the specified lambda expression
without any modification. All `EXPR` methods are marked for *aggressive inlining* to eliminate the overhead that would
be caused by the method call.

To keep the code really short, it's recommended to include the methods into the namespace, so they can be used without
the class name. To do so, simply add `using static GriffinPlus.Lib.Expressions.LambdaExpressionInliners` at the
beginning of the C# source file where these methods are used.

The `EXPR` methods are available for lambda expressions with up to 16 parameters and with/without return value:

```csharp
// without return value (Action<>)
public static Expression<Action> EXPR(Expression<Action> expr);
public static Expression<Action<TIn1>> EXPR<TIn1>(Expression<Action<TIn1>> expr);
public static Expression<Action<TIn1, TIn2>> EXPR<TIn1, TIn2>(Expression<Action<TIn1, TIn2>> expr);
public static Expression<Action<TIn1, TIn2, TIn3>> EXPR<TIn1, TIn2, TIn3>(Expression<Action<TIn1, TIn2, TIn3>> expr);
public static Expression<Action<TIn1, TIn2, TIn3, TIn4>> EXPR<TIn1, TIn2, TIn3, TIn4>(Expression<Action<TIn1, TIn2, TIn3, TIn4>> expr);
public static Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5>> EXPR<TIn1, TIn2, TIn3, TIn4, TIn5>(Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5>> expr);
public static Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6>> EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6>(Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6>> expr);
public static Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7>> EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7>(Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7>> expr);
public static Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8>> EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8>(Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8>> expr);
public static Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9>> EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9>(Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9>> expr);
public static Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10>> EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10>(Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10>> expr);
public static Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11>> EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11>(Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11>> expr);
public static Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12>> EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12>(Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12>> expr);
public static Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13>> EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13>(Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13>> expr);
public static Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14>> EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14>(Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14>> expr);
public static Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15>> EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15>(Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15>> expr);
public static Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16>> EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16>(Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16>> expr);

// with return value (Func<>)
public static Expression<Func<TOut>> EXPR<TOut>(Expression<Func<TOut>> expr);
public static Expression<Func<TIn1, TOut>> EXPR<TIn1, TOut>(Expression<Func<TIn1, TOut>> expr);
public static Expression<Func<TIn1, TIn2, TOut>> EXPR<TIn1, TIn2, TOut>(Expression<Func<TIn1, TIn2, TOut>> expr);
public static Expression<Func<TIn1, TIn2, TIn3, TOut>> EXPR<TIn1, TIn2, TIn3, TOut>(Expression<Func<TIn1, TIn2, TIn3, TOut>> expr);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TOut>> EXPR<TIn1, TIn2, TIn3, TIn4, TOut>(Expression<Func<TIn1, TIn2, TIn3, TIn4, TOut>> expr);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>> EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>(Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>> expr);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>> EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>(Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>> expr);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>> EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>(Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>> expr);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TOut>> EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TOut>(Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TOut>> expr);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TOut>> EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TOut>(Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TOut>> expr);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TOut>> EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TOut>(Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TOut>> expr);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TOut>> EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TOut>(Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TOut>> expr);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TOut>> EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TOut>(Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TOut>> expr);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TOut>> EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TOut>(Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TOut>> expr);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TOut>> EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TOut>(Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TOut>> expr);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TOut>> EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TOut>(Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TOut>> expr);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16, TOut>> EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16, TOut>(Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16, TOut>> expr);
```

#### Example

In order to initialize an array of expressions you will usually have to write something like this:

```csharp
Expression<Func<int,int,int>> add = (x,y) => x + y;
Expression<Func<int,int,int>> subtract = (x,y) => x - y;
Expression<Func<int,int,int>> multiply = (x,y) => x * y;
Expression<Func<int,int,int>> divide = (x,y) => x / y;

var expressions = new[] { add, subtract, multiply, divide };
```

Each and every expression must be assigned to a named variable. This can become cumbersome when juggling with many expressions.
With the `EXPR<>` methods you can avoid inventing temporary variable names by inlining the expressions:

```csharp
var expressions = new[]
{
  EXPR<int,int,int>((x,y) => x + y),
  EXPR<int,int,int>((x,y) => x - y),
  EXPR<int,int,int>((x,y) => x * y),
  EXPR<int,int,int>((x,y) => x / y)
};
```

### Composing Lambda Expressions

In mathematics, function composition is an operation that takes two functions *f* and *g* and produces a function *h*
such that *h(x) = g(f(x))*. In this operation, the function *g* is applied to the result of applying the function *f*
to *x*. That is, the functions *f : X → Y* and *g : Y → Z* are composed to yield a function that maps *x* in *X* to
*g(f(x))* in *Z*.

Transferred to lambda expressions this means that composing `Expression<Func<X,Y>>` and `Expression<Func<Y,Z>>` produces
`Expression<Func<X,Z>>`. The `LambdaExpressionComposeExtensions` class contains extension methods that extend strong-typed
lambda expressions with function composition features. Lambda composition is supported for up to 16 parameters using
the following extension methods:

```csharp
public static Expression<Func<TOut>> Compose<TInterstitial, TOut>(this Expression<Func<TInterstitial>> inner, Expression<Func<TInterstitial, TOut>> outer);
public static Expression<Func<TIn1, TOut>> Compose<TIn1, TInterstitial, TOut>(this Expression<Func<In1, TInterstitial>> inner, Expression<Func<TInterstitial, TOut>> outer);
public static Expression<Func<TIn1, TIn2, TOut>> Compose<TIn1, TInterstitial, TOut>(this Expression<Func<TIn1, TIn2, TInterstitial>> inner, Expression<Func<TInterstitial, TOut>> outer);
public static Expression<Func<TIn1, TIn2, TIn3, TOut>> Compose<TIn1, TIn2, TInterstitial, TOut>(this Expression<Func<TIn1, TIn2, TIn3, TInterstitial>> inner, Expression<Func<TInterstitial, TOut>> outer);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TOut>> Compose<TIn1, TIn2, TIn3, TInterstitial, TOut>(this Expression<Func<TIn1, TIn2, TIn3, TIn4, TInterstitial>> inner, Expression<Func<TInterstitial, TOut>> outer);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>> Compose<TIn1, TIn2, TIn3, TIn4, TInterstitial, TOut>(this Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TInterstitial>> inner, Expression<Func<TInterstitial, TOut>> outer);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>> Compose<TIn1, TIn2, TIn3, TIn4, TIn5, TInterstitial, TOut>(this Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TInterstitial>> inner, Expression<Func<TInterstitial, TOut>> outer);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>> Compose<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TInterstitial, TOut>(this Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TInterstitial>> inner, Expression<Func<TInterstitial, TOut>> outer);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TOut>> Compose<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TInterstitial, TOut>(this Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TInterstitial>> inner, Expression<Func<TInterstitial, TOut>> outer);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TOut>> Compose<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TInterstitial, TOut>(this Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TInterstitial>> inner, Expression<Func<TInterstitial, TOut>> outer);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TOut>> Compose<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TInterstitial, TOut>(this Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TInterstitial>> inner, Expression<Func<TInterstitial, TOut>> outer);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TOut>> Compose<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TInterstitial, TOut>(this Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TInterstitial>> inner, Expression<Func<TInterstitial, TOut>> outer);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TOut>> Compose<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TInterstitial, TOut>(this Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TInterstitial>> inner, Expression<Func<TInterstitial, TOut>> outer);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TOut>> Compose<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TInterstitial, TOut>(this Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TInterstitial>> inner, Expression<Func<TInterstitial, TOut>> outer);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TOut>> Compose<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TInterstitial, TOut>(this Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TInterstitial>> inner, Expression<Func<TInterstitial, TOut>> outer);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TOut>> Compose<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TInterstitial, TOut>(this Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TInterstitial>> inner, Expression<Func<TInterstitial, TOut>> outer);
public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16, TOut>> Compose<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16, TInterstitial, TOut>(this Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16, TInterstitial>> inner, Expression<Func<TInterstitial, TOut>> outer);
```

#### Example

```csharp
Expression<Func<int,int,double>> expr1 = (x,y) => 5.0 * (x + y);
Expression<Func<double,string>> expr2 = (x) => x.ToString();
Expression<Func<int,int,string>> composition = expr1.Compose(expr2); // same as: (x,y) => (5.0 * (x + y)).ToString();
```

### Comparing Expressions

The library provides the `ExpressionEqualityComparer` class to calculate hash codes for expressions and check them for
equality. This class implements the `System.Collections.Generic.IEqualityComparer<Expression>` interface and can
therefore be used in conjunction with common collections as usual. It is recommended to use its singleton property
`Instance` to reduce GC pressure. The instance uses thread-local storage and is therefore thread-safe.

#### Example

```csharp
Expression<Func<int,int,double>> expr1 = (x,y) => 5.0 * (x + y);
Expression<Func<int,int,double>> expr2 = (x,y) => 5.0 * (x + y);
int hashCode1 = ExpressionEqualityComparer.Instance.GetHashCode(expr1);  // 0x497c66b1
int hashCode2 = ExpressionEqualityComparer.Instance.GetHashCode(expr2);  // 0x497c66b1
bool isEqual = ExpressionEqualityComparer.Instance.Equals(expr1, expr2); // true
```