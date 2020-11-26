///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// This file is part of the Griffin+ common library suite.
// Project URL: https://github.com/griffinplus/dotnet-libs-expressions
// The source code is licensed under the MIT license.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GriffinPlus.Lib.Expressions
{
	/// <summary>
	/// An equality comparer for LINQ expression trees.
	/// </summary>
	public class ExpressionEqualityComparer : IEqualityComparer<Expression>
	{
		/// <summary>
		/// Gets the singleton instance of the comparer.
		/// </summary>
		public static ExpressionEqualityComparer Instance {
			get;
		} = new ExpressionEqualityComparer();

		/// <summary>
		/// Determines whether the specified expressions are equal.
		/// </summary>
		/// <param name="x">The first expression to compare (may be null).</param>
		/// <param name="y">The seconds expression to compare (may be null).</param>
		/// <returns>true, if the specified expressions are equal; otherwise, false.</returns>
		public bool Equals(Expression x, Expression y)
		{
			if (x == null && y == null) return true;      // both expressions are null => equal
			if ((x != null) ^ (y != null)) return false;  // one expression is null => not equal
			return ExpressionEqualityComparison.AreEqual(x, y);
		}

		/// <summary>
		/// Returns a hash code for the specified object.
		/// </summary>
		/// <param name="expression">The expression for which a hash code is to be returned.</param>
		/// <returns>A hash code for the specified expression.</returns>
		/// <exception cref="ArgumentNullException">The specified expression is null.</exception>
		public int GetHashCode(Expression expression)
		{
			if (expression == null) throw new ArgumentNullException(nameof(expression));
			return ExpressionHashCodeCalculation.GetHashCode(expression);
		}
	}
}
