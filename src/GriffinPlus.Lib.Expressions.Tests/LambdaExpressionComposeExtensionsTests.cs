///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// This file is part of the Griffin+ common library suite.
// Project URL: https://github.com/griffinplus/dotnet-libs-expressions
// The source code is licensed under the MIT license.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

using Xunit;

// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable ClassNeverInstantiated.Local

namespace GriffinPlus.Lib.Expressions
{

	// needed for EXPR<>() functions
	using static LambdaExpressionInliners;

	/// <summary>
	/// Unit tests for the <see cref="LambdaExpressionComposeExtensions"/> class.
	/// </summary>
	public class LambdaExpressionComposeExtensionsTests
	{
		private class A
		{
			public B B { get; set; }
		}

		private class B
		{
			public C C { get; set; }
		}

		private class C
		{
			public D D { get; set; }
		}

		private class D
		{
			public int Value { get; set; }
		}

		[Theory]
		[MemberData(nameof(Compose_Data))]
		public void Compose(LambdaExpression lambda1, LambdaExpression lambda2, LambdaExpression expected)
		{
			int parameterCount = lambda1.Parameters.Count;

			var method = typeof(LambdaExpressionComposeExtensions)
				.GetMethods()
				.Where(x => x.Name == nameof(LambdaExpressionComposeExtensions.Compose))
				.First(x => x.IsGenericMethod && x.GetGenericArguments().Length == parameterCount + 2); // + 2 => interstitial type + result type

			List<Type> types = new List<Type>();
			types.AddRange(lambda1.Parameters.Select(x => x.Type));
			types.Add(lambda1.ReturnType); // interstitial type
			types.Add(lambda2.ReturnType); // result type

			method = method.MakeGenericMethod(types.ToArray());
			var expression = (Expression)method.Invoke(null, new object[] { lambda1, lambda2 });
			Assert.Equal(expected, expression, ExpressionEqualityComparer.Instance);
		}

		public static IEnumerable<object[]> Compose_Data
		{
			get
			{
				// (A x, ...) => x
				// (A x)      => x.B.C.D
				foreach (var expr in GenerateVariations(EXPR<A, A>(x => x)))
				{
					yield return new object[]
					{
						expr,
						EXPR<A, D>(x => x.B.C.D),
						GenerateVariation(EXPR<A, D>(x => x.B.C.D), expr)
					};
				}

				// (A x, ...) => x.B
				// (B x)      => x.C.D
				foreach (var expr in GenerateVariations(EXPR<A, B>(x => x.B)))
				{
					yield return new object[]
					{
						expr,
						EXPR<B, D>(x => x.C.D),
						GenerateVariation(EXPR<A, D>(x => x.B.C.D), expr)
					};
				}

				// (A x, ...) => x.B.C
				// (C x)      => x.D
				foreach (var expr in GenerateVariations(EXPR<A, C>(x => x.B.C)))
				{
					yield return new object[]
					{
						expr,
						EXPR<C, D>(x => x.D),
						GenerateVariation(EXPR<A, D>(x => x.B.C.D), expr)
					};
				}

				// (A x, ...) => x.B.C.D
				// (D x)      => x
				foreach (var expr in GenerateVariations(EXPR<A, D>(x => x.B.C.D)))
				{
					yield return new object[]
					{
						expr,
						EXPR<D, D>(x => x),
						GenerateVariation(EXPR<A, D>(x => x.B.C.D), expr)
					};
				}

				// (A x, ...) => x.B.C.D
				// (D x)      => x
				foreach (var expr in GenerateVariations(EXPR<A, B>(x => x.B)))
				{
					yield return new object[]
					{
						expr,
						EXPR<B, int>(x => x.C.D.Value),
						GenerateVariation(EXPR<A, int>(x => x.B.C.D.Value), expr)
					};
				}
			}
		}

		/// <summary>
		/// Generates variations of the specified lambda expression (must have one argument only).
		/// The variations are similar to the specified lambda expression, but have up to 15 additional dummy
		/// arguments extending the signature of the lambda expression to test the different overloads of the
		/// <c>Compose</c> method.
		/// </summary>
		/// <param name="lambda">Lambda expression to generate variations for.</param>
		/// <returns>The generated variations of the lambda expression.</returns>
		private static IEnumerable<LambdaExpression> GenerateVariations(LambdaExpression lambda)
		{
			Debug.Assert(lambda.Parameters.Count == 1);

			List<LambdaExpression> variations = new List<LambdaExpression>();
			for (int i = 2; i <= 16; i++)
			{
				List<ParameterExpression> parameters = new List<ParameterExpression> { lambda.Parameters[0] };
				for (int j = 2; j <= i; j++) parameters.Add(Expression.Parameter(typeof(int), $"_{j}"));
				variations.Add(Expression.Lambda(lambda.Body, parameters));
			}

			return variations;
		}

		/// <summary>
		/// Changes the signature of the specified lambda expression to the signature of the other specified lambda expression
		/// </summary>
		/// <param name="expression">Lambda expression to modify.</param>
		/// <param name="other">Lambda expression to take the signature from.</param>
		/// <returns>The modified lambda expression.</returns>
		private static LambdaExpression GenerateVariation(LambdaExpression expression, LambdaExpression other)
		{
			return Expression.Lambda(expression.Body, other.Parameters);
		}
	}

}
