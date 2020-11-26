///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// This file is part of the Griffin+ common library suite.
// Project URL: https://github.com/griffinplus/dotnet-libs-expressions
// The source code is licensed under the MIT license.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;

namespace GriffinPlus.Lib.Expressions
{
	partial class ExpressionEqualityComparison
	{
		/// <summary>
		/// An expression visitor that returns a queue containing the visited expression nodes.
		/// </summary>
		internal sealed class VisitedExpressionEnumeration : ExpressionVisitor
		{
			private static readonly ThreadLocal<VisitedExpressionEnumeration> sInstance = new ThreadLocal<VisitedExpressionEnumeration>(() => new VisitedExpressionEnumeration());
			private Queue<object> mVisitedNodes = new Queue<object>();

			/// <summary>
			/// Initializes a new instance of the <see cref="VisitedExpressionEnumeration"/> class.
			/// </summary>
			private VisitedExpressionEnumeration()
			{

			}

			/// <summary>
			/// Gets an enumerable of visited expression nodes.
			/// </summary>
			/// <param name="expression">Expression to enumerate.</param>
			/// <param name="queue">Queue to populate with the enumerated expression nodes (null, to create a new queue).</param>
			/// <returns>A queue containing the enumerated expression nodes.</returns>
			public static Queue<object> GetVisitedExpressions(Expression expression, Queue<object> queue = null)
			{
				if (expression == null) throw new ArgumentNullException(nameof(expression));

				sInstance.Value.mVisitedNodes = queue ?? new Queue<object>();
				sInstance.Value.Visit(expression);
				return sInstance.Value.mVisitedNodes;
			}

			/// <inheritdoc />
			public override Expression Visit(Expression expression)
			{
				if (expression == null) return null;
				mVisitedNodes.Enqueue(expression);
				return base.Visit(expression);
			}

			/// <inheritdoc />
			protected override CatchBlock VisitCatchBlock(CatchBlock node)
			{
				mVisitedNodes.Enqueue(node);
				return base.VisitCatchBlock(node);
			}

			/// <inheritdoc />
			protected override ElementInit VisitElementInit(ElementInit node)
			{
				mVisitedNodes.Enqueue(node);
				return base.VisitElementInit(node);
			}

			/// <inheritdoc />
			protected override LabelTarget VisitLabelTarget(LabelTarget node)
			{
				mVisitedNodes.Enqueue(node);
				return base.VisitLabelTarget(node);
			}

			/// <inheritdoc />
			protected override MemberAssignment VisitMemberAssignment(MemberAssignment node)
			{
				mVisitedNodes.Enqueue(node);
				return base.VisitMemberAssignment(node);
			}

			/// <inheritdoc />
			protected override MemberBinding VisitMemberBinding(MemberBinding node)
			{
				mVisitedNodes.Enqueue(node);
				return base.VisitMemberBinding(node);
			}

			/// <inheritdoc />
			protected override MemberListBinding VisitMemberListBinding(MemberListBinding node)
			{
				mVisitedNodes.Enqueue(node);
				return base.VisitMemberListBinding(node);
			}

			/// <inheritdoc />
			protected override MemberMemberBinding VisitMemberMemberBinding(MemberMemberBinding node)
			{
				mVisitedNodes.Enqueue(node);
				return base.VisitMemberMemberBinding(node);
			}
		}
	}
}
