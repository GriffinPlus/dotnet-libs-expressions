///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// This file is part of the Griffin+ common library suite.
// Project URL: https://github.com/griffinplus/dotnet-libs-expressions
// The source code is licensed under the MIT license.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Linq.Expressions;

namespace GriffinPlus.Lib.Expressions
{
	/// <summary>
	/// An expression visitor that replaces one expression node with another.
	/// </summary>
	internal class ExpressionSwapVisitor : ExpressionVisitor
	{
		private readonly Expression mSource;
		private readonly Expression mReplacement;

		/// <summary>
		/// Initializes a new instance of the <see cref="ExpressionSwapVisitor"/> class.
		/// </summary>
		/// <param name="source">Expression to replace.</param>
		/// <param name="replacement">The replacement to use instead.</param>
		public ExpressionSwapVisitor(Expression source, Expression replacement)
		{
			mSource = source;
			mReplacement = replacement;
		}

		/// <summary>
		/// Dispatches the expression to one of the more specialized visit methods in this class.
		/// </summary>
		/// <param name="node">The expression to visit.</param>
		/// <returns>
		/// The modified expression, if it or any subexpression was modified;
		/// otherwise, returns the original expression.
		/// </returns>
		public override Expression Visit(Expression node)
		{
			return node == mSource ? mReplacement : base.Visit(node);
		}
	}
}