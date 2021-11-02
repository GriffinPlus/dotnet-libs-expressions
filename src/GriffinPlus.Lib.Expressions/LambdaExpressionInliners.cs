///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// This file is part of the Griffin+ common library suite.
// Project URL: https://github.com/griffinplus/dotnet-libs-expressions
// The source code is licensed under the MIT license.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

// ReSharper disable InconsistentNaming

namespace GriffinPlus.Lib.Expressions
{

	/// <summary>
	/// A collection of static methods that allow inlining of strongly-typed lambda expressions by simply
	/// returning a lambda expression as is. There is no need to assign the lambda expression to a variable.
	/// </summary>
	public static class LambdaExpressionInliners
	{
		#region Action<>

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Action>
			EXPR(Expression<Action> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn">Type of the lambda parameter.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Action<TIn>>
			EXPR<TIn>(Expression<Action<TIn>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Action<TIn1, TIn2>>
			EXPR<TIn1, TIn2>(Expression<Action<TIn1, TIn2>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Action<TIn1, TIn2, TIn3>>
			EXPR<TIn1, TIn2, TIn3>(Expression<Action<TIn1, TIn2, TIn3>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Action<TIn1, TIn2, TIn3, TIn4>>
			EXPR<TIn1, TIn2, TIn3, TIn4>(
				Expression<Action<TIn1, TIn2, TIn3, TIn4>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth lambda parameter.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5>>
			EXPR<TIn1, TIn2, TIn3, TIn4, TIn5>(
				Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth lambda parameter.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth lambda parameter.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6>>
			EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6>(
				Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth lambda parameter.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth lambda parameter.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh lambda parameter.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7>>
			EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7>(
				Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth lambda parameter.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth lambda parameter.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh lambda parameter.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth lambda parameter.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8>>
			EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8>(
				Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth lambda parameter.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth lambda parameter.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh lambda parameter.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth lambda parameter.</typeparam>
		/// <typeparam name="TIn9">Type of the ninth lambda parameter.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9>>
			EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9>(
				Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth lambda parameter.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth lambda parameter.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh lambda parameter.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth lambda parameter.</typeparam>
		/// <typeparam name="TIn9">Type of the ninth lambda parameter.</typeparam>
		/// <typeparam name="TIn10">Type of the tenth lambda parameter.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10>>
			EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10>(
				Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth lambda parameter.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth lambda parameter.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh lambda parameter.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth lambda parameter.</typeparam>
		/// <typeparam name="TIn9">Type of the ninth lambda parameter.</typeparam>
		/// <typeparam name="TIn10">Type of the tenth lambda parameter.</typeparam>
		/// <typeparam name="TIn11">Type of the eleventh lambda parameter.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11>>
			EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11>(
				Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth lambda parameter.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth lambda parameter.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh lambda parameter.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth lambda parameter.</typeparam>
		/// <typeparam name="TIn9">Type of the ninth lambda parameter.</typeparam>
		/// <typeparam name="TIn10">Type of the tenth lambda parameter.</typeparam>
		/// <typeparam name="TIn11">Type of the eleventh lambda parameter.</typeparam>
		/// <typeparam name="TIn12">Type of the twelfth lambda parameter.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12>>
			EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12>(
				Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth lambda parameter.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth lambda parameter.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh lambda parameter.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth lambda parameter.</typeparam>
		/// <typeparam name="TIn9">Type of the ninth lambda parameter.</typeparam>
		/// <typeparam name="TIn10">Type of the tenth lambda parameter.</typeparam>
		/// <typeparam name="TIn11">Type of the eleventh lambda parameter.</typeparam>
		/// <typeparam name="TIn12">Type of the twelfth lambda parameter.</typeparam>
		/// <typeparam name="TIn13">Type of the thirteenth lambda parameter.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13>>
			EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13>(
				Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth lambda parameter.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth lambda parameter.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh lambda parameter.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth lambda parameter.</typeparam>
		/// <typeparam name="TIn9">Type of the ninth lambda parameter.</typeparam>
		/// <typeparam name="TIn10">Type of the tenth lambda parameter.</typeparam>
		/// <typeparam name="TIn11">Type of the eleventh lambda parameter.</typeparam>
		/// <typeparam name="TIn12">Type of the twelfth lambda parameter.</typeparam>
		/// <typeparam name="TIn13">Type of the thirteenth lambda parameter.</typeparam>
		/// <typeparam name="TIn14">Type of the fourteenth lambda parameter.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14>>
			EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14>(
				Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth lambda parameter.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth lambda parameter.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh lambda parameter.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth lambda parameter.</typeparam>
		/// <typeparam name="TIn9">Type of the ninth lambda parameter.</typeparam>
		/// <typeparam name="TIn10">Type of the tenth lambda parameter.</typeparam>
		/// <typeparam name="TIn11">Type of the eleventh lambda parameter.</typeparam>
		/// <typeparam name="TIn12">Type of the twelfth lambda parameter.</typeparam>
		/// <typeparam name="TIn13">Type of the thirteenth lambda parameter.</typeparam>
		/// <typeparam name="TIn14">Type of the fourteenth lambda parameter.</typeparam>
		/// <typeparam name="TIn15">Type of the fifteenth lambda parameter.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15>>
			EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15>(
				Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth lambda parameter.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth lambda parameter.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh lambda parameter.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth lambda parameter.</typeparam>
		/// <typeparam name="TIn9">Type of the ninth lambda parameter.</typeparam>
		/// <typeparam name="TIn10">Type of the tenth lambda parameter.</typeparam>
		/// <typeparam name="TIn11">Type of the eleventh lambda parameter.</typeparam>
		/// <typeparam name="TIn12">Type of the twelfth lambda parameter.</typeparam>
		/// <typeparam name="TIn13">Type of the thirteenth lambda parameter.</typeparam>
		/// <typeparam name="TIn14">Type of the fourteenth lambda parameter.</typeparam>
		/// <typeparam name="TIn15">Type of the fifteenth lambda parameter.</typeparam>
		/// <typeparam name="TIn16">Type of the sixteenth lambda parameter.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16>>
			EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16>(
				Expression<Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16>> expr)
		{
			return expr;
		}

		#endregion

		#region Func<>

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TOut">Type of the result of the lambda expression.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Func<TOut>>
			EXPR<TOut>(Expression<Func<TOut>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn">Type of the lambda parameter.</typeparam>
		/// <typeparam name="TOut">Type of the result of the lambda expression.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Func<TIn, TOut>>
			EXPR<TIn, TOut>(Expression<Func<TIn, TOut>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TOut">Type of the result of the lambda expression.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Func<TIn1, TIn2, TOut>>
			EXPR<TIn1, TIn2, TOut>(Expression<Func<TIn1, TIn2, TOut>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TOut">Type of the result of the lambda expression.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Func<TIn1, TIn2, TIn3, TOut>>
			EXPR<TIn1, TIn2, TIn3, TOut>(Expression<Func<TIn1, TIn2, TIn3, TOut>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <typeparam name="TOut">Type of the result of the lambda expression.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TOut>>
			EXPR<TIn1, TIn2, TIn3, TIn4, TOut>(
				Expression<Func<TIn1, TIn2, TIn3, TIn4, TOut>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth lambda parameter.</typeparam>
		/// <typeparam name="TOut">Type of the result of the lambda expression.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>>
			EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>(
				Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth lambda parameter.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth lambda parameter.</typeparam>
		/// <typeparam name="TOut">Type of the result of the lambda expression.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>>
			EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>(
				Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth lambda parameter.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth lambda parameter.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh lambda parameter.</typeparam>
		/// <typeparam name="TOut">Type of the result of the lambda expression.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>>
			EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>(
				Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth lambda parameter.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth lambda parameter.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh lambda parameter.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth lambda parameter.</typeparam>
		/// <typeparam name="TOut">Type of the result of the lambda expression.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TOut>>
			EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TOut>(
				Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TOut>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth lambda parameter.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth lambda parameter.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh lambda parameter.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth lambda parameter.</typeparam>
		/// <typeparam name="TIn9">Type of the ninth lambda parameter.</typeparam>
		/// <typeparam name="TOut">Type of the result of the lambda expression.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TOut>>
			EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TOut>(
				Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TOut>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth lambda parameter.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth lambda parameter.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh lambda parameter.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth lambda parameter.</typeparam>
		/// <typeparam name="TIn9">Type of the ninth lambda parameter.</typeparam>
		/// <typeparam name="TIn10">Type of the tenth lambda parameter.</typeparam>
		/// <typeparam name="TOut">Type of the result of the lambda expression.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TOut>>
			EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TOut>(
				Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TOut>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth lambda parameter.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth lambda parameter.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh lambda parameter.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth lambda parameter.</typeparam>
		/// <typeparam name="TIn9">Type of the ninth lambda parameter.</typeparam>
		/// <typeparam name="TIn10">Type of the tenth lambda parameter.</typeparam>
		/// <typeparam name="TIn11">Type of the eleventh lambda parameter.</typeparam>
		/// <typeparam name="TOut">Type of the result of the lambda expression.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TOut>>
			EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TOut>(
				Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TOut>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth lambda parameter.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth lambda parameter.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh lambda parameter.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth lambda parameter.</typeparam>
		/// <typeparam name="TIn9">Type of the ninth lambda parameter.</typeparam>
		/// <typeparam name="TIn10">Type of the tenth lambda parameter.</typeparam>
		/// <typeparam name="TIn11">Type of the eleventh lambda parameter.</typeparam>
		/// <typeparam name="TIn12">Type of the twelfth lambda parameter.</typeparam>
		/// <typeparam name="TOut">Type of the result of the lambda expression.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TOut>>
			EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TOut>(
				Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TOut>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth lambda parameter.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth lambda parameter.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh lambda parameter.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth lambda parameter.</typeparam>
		/// <typeparam name="TIn9">Type of the ninth lambda parameter.</typeparam>
		/// <typeparam name="TIn10">Type of the tenth lambda parameter.</typeparam>
		/// <typeparam name="TIn11">Type of the eleventh lambda parameter.</typeparam>
		/// <typeparam name="TIn12">Type of the twelfth lambda parameter.</typeparam>
		/// <typeparam name="TIn13">Type of the thirteenth lambda parameter.</typeparam>
		/// <typeparam name="TOut">Type of the result of the lambda expression.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TOut>>
			EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TOut>(
				Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TOut>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth lambda parameter.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth lambda parameter.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh lambda parameter.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth lambda parameter.</typeparam>
		/// <typeparam name="TIn9">Type of the ninth lambda parameter.</typeparam>
		/// <typeparam name="TIn10">Type of the tenth lambda parameter.</typeparam>
		/// <typeparam name="TIn11">Type of the eleventh lambda parameter.</typeparam>
		/// <typeparam name="TIn12">Type of the twelfth lambda parameter.</typeparam>
		/// <typeparam name="TIn13">Type of the thirteenth lambda parameter.</typeparam>
		/// <typeparam name="TIn14">Type of the fourteenth lambda parameter.</typeparam>
		/// <typeparam name="TOut">Type of the result of the lambda expression.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TOut>>
			EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TOut>(
				Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TOut>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth lambda parameter.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth lambda parameter.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh lambda parameter.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth lambda parameter.</typeparam>
		/// <typeparam name="TIn9">Type of the ninth lambda parameter.</typeparam>
		/// <typeparam name="TIn10">Type of the tenth lambda parameter.</typeparam>
		/// <typeparam name="TIn11">Type of the eleventh lambda parameter.</typeparam>
		/// <typeparam name="TIn12">Type of the twelfth lambda parameter.</typeparam>
		/// <typeparam name="TIn13">Type of the thirteenth lambda parameter.</typeparam>
		/// <typeparam name="TIn14">Type of the fourteenth lambda parameter.</typeparam>
		/// <typeparam name="TIn15">Type of the fifteenth lambda parameter.</typeparam>
		/// <typeparam name="TOut">Type of the result of the lambda expression.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TOut>>
			EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TOut>(
				Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TOut>> expr)
		{
			return expr;
		}

		/// <summary>
		/// Returns the passed strongly-typed lambda expression as is.
		/// </summary>
		/// <typeparam name="TIn1">Type of the first lambda parameter.</typeparam>
		/// <typeparam name="TIn2">Type of the second lambda parameter.</typeparam>
		/// <typeparam name="TIn3">Type of the third lambda parameter.</typeparam>
		/// <typeparam name="TIn4">Type of the fourth lambda parameter.</typeparam>
		/// <typeparam name="TIn5">Type of the fifth lambda parameter.</typeparam>
		/// <typeparam name="TIn6">Type of the sixth lambda parameter.</typeparam>
		/// <typeparam name="TIn7">Type of the seventh lambda parameter.</typeparam>
		/// <typeparam name="TIn8">Type of the eighth lambda parameter.</typeparam>
		/// <typeparam name="TIn9">Type of the ninth lambda parameter.</typeparam>
		/// <typeparam name="TIn10">Type of the tenth lambda parameter.</typeparam>
		/// <typeparam name="TIn11">Type of the eleventh lambda parameter.</typeparam>
		/// <typeparam name="TIn12">Type of the twelfth lambda parameter.</typeparam>
		/// <typeparam name="TIn13">Type of the thirteenth lambda parameter.</typeparam>
		/// <typeparam name="TIn14">Type of the fourteenth lambda parameter.</typeparam>
		/// <typeparam name="TIn15">Type of the fifteenth lambda parameter.</typeparam>
		/// <typeparam name="TIn16">Type of the sixteenth lambda parameter.</typeparam>
		/// <typeparam name="TOut">Type of the result of the lambda expression.</typeparam>
		/// <param name="expr">Lambda expression.</param>
		/// <returns>The specified lambda expression.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16, TOut>>
			EXPR<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16, TOut>(
				Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16, TOut>> expr)
		{
			return expr;
		}

		#endregion
	}

}
