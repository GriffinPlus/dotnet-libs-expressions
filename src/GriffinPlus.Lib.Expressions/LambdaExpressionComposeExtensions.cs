///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// This file is part of the Griffin+ common library suite.
// Project URL: https://github.com/griffinplus/dotnet-libs-expressions
// The source code is licensed under the MIT license.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Linq.Expressions;

namespace GriffinPlus.Lib.Expressions
{
	/// <summary>
	/// Extension methods for composing strongly typed lambda expressions.
	/// </summary>
	public static class LambdaExpressionComposeExtensions
	{
		/// <summary>
		/// Composes the specified lambda expressions (for inner lambda expression without arguments).
		/// </summary>
		/// <typeparam name="TInterstitial">Interstitial type (output type of the inner lambda expression and input type of the outer lambda expression).</typeparam>
		/// <typeparam name="TOut">Result type of the outer lambda expression.</typeparam>
		/// <param name="inner">The inner lambda expression.</param>
		/// <param name="outer">The outer lambda expression.</param>
		/// <returns>A lambda expression representing the composition of the specified lambda expressions.</returns>
		public static Expression<Func<TOut>>
			Compose<TInterstitial, TOut>(
				this Expression<Func<TInterstitial>> inner,
				Expression<Func<TInterstitial, TOut>> outer)
		{
			if (inner == null) throw new ArgumentNullException(nameof(inner));
			if (outer == null) throw new ArgumentNullException(nameof(outer));
			var visitor = new ExpressionSwapVisitor(outer.Parameters[0], inner.Body);
			return Expression.Lambda<Func<TOut>>(visitor.Visit(outer.Body), inner.Parameters);
		}

		/// <summary>
		/// Composes the specified lambda expressions (for inner lambda expression with one argument).
		/// </summary>
		/// <typeparam name="TIn">Input type of the inner lambda expression.</typeparam>
		/// <typeparam name="TInterstitial">Interstitial type (output type of the inner lambda expression and input type of the outer lambda expression).</typeparam>
		/// <typeparam name="TOut">Result type of the outer lambda expression.</typeparam>
		/// <param name="inner">The inner lambda expression.</param>
		/// <param name="outer">The outer lambda expression.</param>
		/// <returns>A lambda expression representing the composition of the specified lambda expressions.</returns>
		public static Expression<Func<TIn, TOut>>
			Compose<TIn, TInterstitial, TOut>(
				this Expression<Func<TIn, TInterstitial>> inner,
				Expression<Func<TInterstitial, TOut>> outer)
		{
			if (inner == null) throw new ArgumentNullException(nameof(inner));
			if (outer == null) throw new ArgumentNullException(nameof(outer));
			var visitor = new ExpressionSwapVisitor(outer.Parameters[0], inner.Body);
			return Expression.Lambda<Func<TIn, TOut>>(visitor.Visit(outer.Body), inner.Parameters);
		}

		/// <summary>
		/// Composes the specified lambda expressions (for inner lambda expression with two arguments).
		/// </summary>
		/// <typeparam name="TIn1">Type of the first argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn2">Type of the second argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TInterstitial">Interstitial type (output type of the inner lambda expression and input type of the outer lambda expression).</typeparam>
		/// <typeparam name="TOut">Result type of the outer lambda expression.</typeparam>
		/// <param name="inner">The inner lambda expression.</param>
		/// <param name="outer">The outer lambda expression.</param>
		/// <returns>A lambda expression representing the composition of the specified lambda expressions.</returns>
		public static Expression<Func<TIn1, TIn2, TOut>>
			Compose<TIn1, TIn2, TInterstitial, TOut>(
				this Expression<Func<TIn1, TIn2, TInterstitial>> inner,
				Expression<Func<TInterstitial, TOut>> outer)
		{
			if (inner == null) throw new ArgumentNullException(nameof(inner));
			if (outer == null) throw new ArgumentNullException(nameof(outer));
			var visitor = new ExpressionSwapVisitor(outer.Parameters[0], inner.Body);
			return Expression.Lambda<Func<TIn1, TIn2, TOut>>(visitor.Visit(outer.Body), inner.Parameters);
		}

		/// <summary>
		/// Composes the specified lambda expressions (for inner lambda expression with three arguments).
		/// </summary>
		/// <typeparam name="TIn1">Type of the first argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn2">Type of the second argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn3">Type of the third argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TInterstitial">Interstitial type (output type of the inner lambda expression and input type of the outer lambda expression).</typeparam>
		/// <typeparam name="TOut">Result type of the outer lambda expression.</typeparam>
		/// <param name="inner">The inner lambda expression.</param>
		/// <param name="outer">The outer lambda expression.</param>
		/// <returns>A lambda expression representing the composition of the specified lambda expressions.</returns>
		public static Expression<Func<TIn1, TIn2, TIn3, TOut>>
			Compose<TIn1, TIn2, TIn3, TInterstitial, TOut>(
				this Expression<Func<TIn1, TIn2, TIn3, TInterstitial>> inner,
				Expression<Func<TInterstitial, TOut>> outer)
		{
			if (inner == null) throw new ArgumentNullException(nameof(inner));
			if (outer == null) throw new ArgumentNullException(nameof(outer));
			var visitor = new ExpressionSwapVisitor(outer.Parameters[0], inner.Body);
			return Expression.Lambda<Func<TIn1, TIn2, TIn3, TOut>>(visitor.Visit(outer.Body), inner.Parameters);
		}

		/// <summary>
		/// Composes the specified lambda expressions (for inner lambda expression with four arguments).
		/// </summary>
		/// <typeparam name="TIn1">Type of the first argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn2">Type of the second argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn3">Type of the third argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn4">Type of the forth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TInterstitial">Interstitial type (output type of the inner lambda expression and input type of the outer lambda expression).</typeparam>
		/// <typeparam name="TOut">Result type of the outer lambda expression.</typeparam>
		/// <param name="inner">The inner lambda expression.</param>
		/// <param name="outer">The outer lambda expression.</param>
		/// <returns>A lambda expression representing the composition of the specified lambda expressions.</returns>
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TOut>>
			Compose<TIn1, TIn2, TIn3, TIn4, TInterstitial, TOut>(
				this Expression<Func<TIn1, TIn2, TIn3, TIn4, TInterstitial>> inner,
				Expression<Func<TInterstitial, TOut>> outer)
		{
			if (inner == null) throw new ArgumentNullException(nameof(inner));
			if (outer == null) throw new ArgumentNullException(nameof(outer));
			var visitor = new ExpressionSwapVisitor(outer.Parameters[0], inner.Body);
			return Expression.Lambda<Func<TIn1, TIn2, TIn3, TIn4, TOut>>(visitor.Visit(outer.Body), inner.Parameters);
		}

		/// <summary>
		/// Composes the specified lambda expressions (for inner lambda expression with five arguments).
		/// </summary>
		/// <typeparam name="TIn1">Type of the first argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn2">Type of the second argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn3">Type of the third argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn4">Type of the forth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TInterstitial">Interstitial type (output type of the inner lambda expression and input type of the outer lambda expression).</typeparam>
		/// <typeparam name="TOut">Result type of the outer lambda expression.</typeparam>
		/// <param name="inner">The inner lambda expression.</param>
		/// <param name="outer">The outer lambda expression.</param>
		/// <returns>A lambda expression representing the composition of the specified lambda expressions.</returns>
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>>
			Compose<TIn1, TIn2, TIn3, TIn4, TIn5, TInterstitial, TOut>(
				this Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TInterstitial>> inner,
				Expression<Func<TInterstitial, TOut>> outer)
		{
			if (inner == null) throw new ArgumentNullException(nameof(inner));
			if (outer == null) throw new ArgumentNullException(nameof(outer));
			var visitor = new ExpressionSwapVisitor(outer.Parameters[0], inner.Body);
			return Expression.Lambda<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>>(visitor.Visit(outer.Body), inner.Parameters);
		}

		/// <summary>
		/// Composes the specified lambda expressions (for inner lambda expression with six arguments).
		/// </summary>
		/// <typeparam name="TIn1">Type of the first argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn2">Type of the second argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn3">Type of the third argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn4">Type of the forth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TInterstitial">Interstitial type (output type of the inner lambda expression and input type of the outer lambda expression).</typeparam>
		/// <typeparam name="TOut">Result type of the outer lambda expression.</typeparam>
		/// <param name="inner">The inner lambda expression.</param>
		/// <param name="outer">The outer lambda expression.</param>
		/// <returns>A lambda expression representing the composition of the specified lambda expressions.</returns>
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>>
			Compose<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TInterstitial, TOut>(
				this Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TInterstitial>> inner,
				Expression<Func<TInterstitial, TOut>> outer)
		{
			if (inner == null) throw new ArgumentNullException(nameof(inner));
			if (outer == null) throw new ArgumentNullException(nameof(outer));
			var visitor = new ExpressionSwapVisitor(outer.Parameters[0], inner.Body);
			return Expression.Lambda<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>>(visitor.Visit(outer.Body), inner.Parameters);
		}

		/// <summary>
		/// Composes the specified lambda expressions (for inner lambda expression with seven arguments).
		/// </summary>
		/// <typeparam name="TIn1">Type of the first argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn2">Type of the second argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn3">Type of the third argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn4">Type of the forth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TInterstitial">Interstitial type (output type of the inner lambda expression and input type of the outer lambda expression).</typeparam>
		/// <typeparam name="TOut">Result type of the outer lambda expression.</typeparam>
		/// <param name="inner">The inner lambda expression.</param>
		/// <param name="outer">The outer lambda expression.</param>
		/// <returns>A lambda expression representing the composition of the specified lambda expressions.</returns>
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>>
			Compose<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TInterstitial, TOut>(
				this Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TInterstitial>> inner,
				Expression<Func<TInterstitial, TOut>> outer)
		{
			if (inner == null) throw new ArgumentNullException(nameof(inner));
			if (outer == null) throw new ArgumentNullException(nameof(outer));
			var visitor = new ExpressionSwapVisitor(outer.Parameters[0], inner.Body);
			return Expression.Lambda<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>>(visitor.Visit(outer.Body), inner.Parameters);
		}

		/// <summary>
		/// Composes the specified lambda expressions (for inner lambda expression with eight arguments).
		/// </summary>
		/// <typeparam name="TIn1">Type of the first argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn2">Type of the second argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn3">Type of the third argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn4">Type of the forth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TInterstitial">Interstitial type (output type of the inner lambda expression and input type of the outer lambda expression).</typeparam>
		/// <typeparam name="TOut">Result type of the outer lambda expression.</typeparam>
		/// <param name="inner">The inner lambda expression.</param>
		/// <param name="outer">The outer lambda expression.</param>
		/// <returns>A lambda expression representing the composition of the specified lambda expressions.</returns>
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TOut>>
			Compose<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TInterstitial, TOut>(
				this Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TInterstitial>> inner,
				Expression<Func<TInterstitial, TOut>> outer)
		{
			if (inner == null) throw new ArgumentNullException(nameof(inner));
			if (outer == null) throw new ArgumentNullException(nameof(outer));
			var visitor = new ExpressionSwapVisitor(outer.Parameters[0], inner.Body);
			return Expression.Lambda<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TOut>>(visitor.Visit(outer.Body), inner.Parameters);
		}

		/// <summary>
		/// Composes the specified lambda expressions (for inner lambda expression with nine arguments).
		/// </summary>
		/// <typeparam name="TIn1">Type of the first argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn2">Type of the second argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn3">Type of the third argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn4">Type of the forth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn9">Type of the ninth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TInterstitial">Interstitial type (output type of the inner lambda expression and input type of the outer lambda expression).</typeparam>
		/// <typeparam name="TOut">Result type of the outer lambda expression.</typeparam>
		/// <param name="inner">The inner lambda expression.</param>
		/// <param name="outer">The outer lambda expression.</param>
		/// <returns>A lambda expression representing the composition of the specified lambda expressions.</returns>
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TOut>>
			Compose<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TInterstitial, TOut>(
				this Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TInterstitial>> inner,
				Expression<Func<TInterstitial, TOut>> outer)
		{
			if (inner == null) throw new ArgumentNullException(nameof(inner));
			if (outer == null) throw new ArgumentNullException(nameof(outer));
			var visitor = new ExpressionSwapVisitor(outer.Parameters[0], inner.Body);
			return Expression.Lambda<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TOut>>(visitor.Visit(outer.Body), inner.Parameters);
		}

		/// <summary>
		/// Composes the specified lambda expressions (for inner lambda expression with ten arguments).
		/// </summary>
		/// <typeparam name="TIn1">Type of the first argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn2">Type of the second argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn3">Type of the third argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn4">Type of the forth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn9">Type of the ninth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn10">Type of the tenth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TInterstitial">Interstitial type (output type of the inner lambda expression and input type of the outer lambda expression).</typeparam>
		/// <typeparam name="TOut">Result type of the outer lambda expression.</typeparam>
		/// <param name="inner">The inner lambda expression.</param>
		/// <param name="outer">The outer lambda expression.</param>
		/// <returns>A lambda expression representing the composition of the specified lambda expressions.</returns>
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TOut>>
			Compose<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TInterstitial, TOut>(
				this Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TInterstitial>> inner,
				Expression<Func<TInterstitial, TOut>> outer)
		{
			if (inner == null) throw new ArgumentNullException(nameof(inner));
			if (outer == null) throw new ArgumentNullException(nameof(outer));
			var visitor = new ExpressionSwapVisitor(outer.Parameters[0], inner.Body);
			return Expression.Lambda<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TOut>>(visitor.Visit(outer.Body), inner.Parameters);
		}

		/// <summary>
		/// Composes the specified lambda expressions (for inner lambda expression with eleven arguments).
		/// </summary>
		/// <typeparam name="TIn1">Type of the first argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn2">Type of the second argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn3">Type of the third argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn4">Type of the forth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn9">Type of the ninth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn10">Type of the tenth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn11">Type of the eleventh argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TInterstitial">Interstitial type (output type of the inner lambda expression and input type of the outer lambda expression).</typeparam>
		/// <typeparam name="TOut">Result type of the outer lambda expression.</typeparam>
		/// <param name="inner">The inner lambda expression.</param>
		/// <param name="outer">The outer lambda expression.</param>
		/// <returns>A lambda expression representing the composition of the specified lambda expressions.</returns>
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TOut>>
			Compose<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TInterstitial, TOut>(
				this Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TInterstitial>> inner,
				Expression<Func<TInterstitial, TOut>> outer)
		{
			if (inner == null) throw new ArgumentNullException(nameof(inner));
			if (outer == null) throw new ArgumentNullException(nameof(outer));
			var visitor = new ExpressionSwapVisitor(outer.Parameters[0], inner.Body);
			return Expression.Lambda<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TOut>>(visitor.Visit(outer.Body), inner.Parameters);
		}

		/// <summary>
		/// Composes the specified lambda expressions (for inner lambda expression with twelve arguments).
		/// </summary>
		/// <typeparam name="TIn1">Type of the first argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn2">Type of the second argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn3">Type of the third argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn4">Type of the forth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn9">Type of the ninth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn10">Type of the tenth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn11">Type of the eleventh argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn12">Type of the twelfth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TInterstitial">Interstitial type (output type of the inner lambda expression and input type of the outer lambda expression).</typeparam>
		/// <typeparam name="TOut">Result type of the outer lambda expression.</typeparam>
		/// <param name="inner">The inner lambda expression.</param>
		/// <param name="outer">The outer lambda expression.</param>
		/// <returns>A lambda expression representing the composition of the specified lambda expressions.</returns>
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TOut>>
			Compose<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TInterstitial, TOut>(
				this Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TInterstitial>> inner,
				Expression<Func<TInterstitial, TOut>> outer)
		{
			if (inner == null) throw new ArgumentNullException(nameof(inner));
			if (outer == null) throw new ArgumentNullException(nameof(outer));
			var visitor = new ExpressionSwapVisitor(outer.Parameters[0], inner.Body);
			return Expression.Lambda<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TOut>>(visitor.Visit(outer.Body), inner.Parameters);
		}

		/// <summary>
		/// Composes the specified lambda expressions (for inner lambda expression with thirteen arguments).
		/// </summary>
		/// <typeparam name="TIn1">Type of the first argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn2">Type of the second argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn3">Type of the third argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn4">Type of the forth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn9">Type of the ninth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn10">Type of the tenth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn11">Type of the eleventh argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn12">Type of the twelfth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn13">Type of the thirteenth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TInterstitial">Interstitial type (output type of the inner lambda expression and input type of the outer lambda expression).</typeparam>
		/// <typeparam name="TOut">Result type of the outer lambda expression.</typeparam>
		/// <param name="inner">The inner lambda expression.</param>
		/// <param name="outer">The outer lambda expression.</param>
		/// <returns>A lambda expression representing the composition of the specified lambda expressions.</returns>
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TOut>>
			Compose<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TInterstitial, TOut>(
				this Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TInterstitial>> inner,
				Expression<Func<TInterstitial, TOut>> outer)
		{
			if (inner == null) throw new ArgumentNullException(nameof(inner));
			if (outer == null) throw new ArgumentNullException(nameof(outer));
			var visitor = new ExpressionSwapVisitor(outer.Parameters[0], inner.Body);
			return Expression.Lambda<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TOut>>(visitor.Visit(outer.Body), inner.Parameters);
		}

		/// <summary>
		/// Composes the specified lambda expressions (for inner lambda expression with fourteen arguments).
		/// </summary>
		/// <typeparam name="TIn1">Type of the first argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn2">Type of the second argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn3">Type of the third argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn4">Type of the forth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn9">Type of the ninth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn10">Type of the tenth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn11">Type of the eleventh argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn12">Type of the twelfth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn13">Type of the thirteenth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn14">Type of the fourteenth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TInterstitial">Interstitial type (output type of the inner lambda expression and input type of the outer lambda expression).</typeparam>
		/// <typeparam name="TOut">Result type of the outer lambda expression.</typeparam>
		/// <param name="inner">The inner lambda expression.</param>
		/// <param name="outer">The outer lambda expression.</param>
		/// <returns>A lambda expression representing the composition of the specified lambda expressions.</returns>
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TOut>>
			Compose<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TInterstitial, TOut>(
				this Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TInterstitial>> inner,
				Expression<Func<TInterstitial, TOut>> outer)
		{
			if (inner == null) throw new ArgumentNullException(nameof(inner));
			if (outer == null) throw new ArgumentNullException(nameof(outer));
			var visitor = new ExpressionSwapVisitor(outer.Parameters[0], inner.Body);
			return Expression.Lambda<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TOut>>(visitor.Visit(outer.Body), inner.Parameters);
		}

		/// <summary>
		/// Composes the specified lambda expressions (for inner lambda expression with fifteen arguments).
		/// </summary>
		/// <typeparam name="TIn1">Type of the first argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn2">Type of the second argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn3">Type of the third argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn4">Type of the forth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn9">Type of the ninth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn10">Type of the tenth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn11">Type of the eleventh argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn12">Type of the twelfth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn13">Type of the thirteenth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn14">Type of the fourteenth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn15">Type of the fifteenth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TInterstitial">Interstitial type (output type of the inner lambda expression and input type of the outer lambda expression).</typeparam>
		/// <typeparam name="TOut">Result type of the outer lambda expression.</typeparam>
		/// <param name="inner">The inner lambda expression.</param>
		/// <param name="outer">The outer lambda expression.</param>
		/// <returns>A lambda expression representing the composition of the specified lambda expressions.</returns>
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TOut>>
			Compose<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TInterstitial, TOut>(
				this Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TInterstitial>> inner,
				Expression<Func<TInterstitial, TOut>> outer)
		{
			if (inner == null) throw new ArgumentNullException(nameof(inner));
			if (outer == null) throw new ArgumentNullException(nameof(outer));
			var visitor = new ExpressionSwapVisitor(outer.Parameters[0], inner.Body);
			return Expression.Lambda<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TOut>>(visitor.Visit(outer.Body), inner.Parameters);
		}

		/// <summary>
		/// Composes the specified lambda expressions (for inner lambda expression with sixteen arguments).
		/// </summary>
		/// <typeparam name="TIn1">Type of the first argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn2">Type of the second argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn3">Type of the third argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn4">Type of the forth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn9">Type of the ninth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn10">Type of the tenth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn11">Type of the eleventh argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn12">Type of the twelfth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn13">Type of the thirteenth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn14">Type of the fourteenth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn15">Type of the fifteenth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TIn16">Type of the sixteenth argument of the inner lambda expression.</typeparam>
		/// <typeparam name="TInterstitial">Interstitial type (output type of the inner lambda expression and input type of the outer lambda expression).</typeparam>
		/// <typeparam name="TOut">Result type of the outer lambda expression.</typeparam>
		/// <param name="inner">The inner lambda expression.</param>
		/// <param name="outer">The outer lambda expression.</param>
		/// <returns>A lambda expression representing the composition of the specified lambda expressions.</returns>
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16, TOut>>
			Compose<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16, TInterstitial, TOut>(
				this Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16, TInterstitial>> inner,
				Expression<Func<TInterstitial, TOut>> outer)
		{
			if (inner == null) throw new ArgumentNullException(nameof(inner));
			if (outer == null) throw new ArgumentNullException(nameof(outer));
			var visitor = new ExpressionSwapVisitor(outer.Parameters[0], inner.Body);
			return Expression.Lambda<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16, TOut>>(visitor.Visit(outer.Body), inner.Parameters);
		}

	}
}
