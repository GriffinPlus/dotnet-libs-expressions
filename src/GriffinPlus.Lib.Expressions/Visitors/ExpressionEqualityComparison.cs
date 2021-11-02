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
using System.Threading;

namespace GriffinPlus.Lib.Expressions
{

	/// <summary>
	/// An expression visitor that determines whether two expressions are equal.
	/// </summary>
	sealed partial class ExpressionEqualityComparison : ExpressionVisitor
	{
		private static readonly ThreadLocal<ExpressionEqualityComparison> sInstance               = new ThreadLocal<ExpressionEqualityComparison>(() => new ExpressionEqualityComparison());
		private                 Queue<object>                             mRemainingExpectedNodes = new Queue<object>();
		private                 Expression                                mExpectedExpression;
		private                 bool                                      mAreEqual;

		/// <summary>
		/// Initializes a new instance of the <see cref="ExpressionEqualityComparison"/> class.
		/// </summary>
		private ExpressionEqualityComparison()
		{
		}

		/// <summary>
		/// Determines whether the specified expressions are equal.
		/// </summary>
		/// <param name="expression1">First expression to compare.</param>
		/// <param name="expression2">Second expression to compare.</param>
		/// <returns>true, if the specified expressions are equal; otherwise false.</returns>
		public static bool AreEqual(Expression expression1, Expression expression2)
		{
			if (expression1 == null) throw new ArgumentNullException(nameof(expression1));
			if (expression2 == null) throw new ArgumentNullException(nameof(expression2));
			var instance = sInstance.Value;
			instance.mAreEqual = true;
			instance.mRemainingExpectedNodes.Clear();
			instance.mRemainingExpectedNodes = VisitedExpressionEnumeration.GetVisitedExpressions(expression2, sInstance.Value.mRemainingExpectedNodes);
			instance.Visit(expression1);
			if (instance.mRemainingExpectedNodes.Count > 0)
			{
				instance.mAreEqual = false; // the second expression is longer than the first one
			}

			return instance.mAreEqual;
		}

		/// <inheritdoc/>
		public override Expression Visit(Expression expression)
		{
			if (expression == null || !mAreEqual) return expression;

			// peek the next expected expression
			mExpectedExpression = PeekExpectedExpressionNode<Expression>();

			if (mExpectedExpression != null)
			{
				// abort, if the the node type of the expressions are not the same
				if (!CheckAreOfSameType(mExpectedExpression, expression))
				{
					return expression;
				}

				// remove the expected expression from the queue
				PopExpectedExpressionNode();

				// proceed visiting expression nodes...
				return base.Visit(expression);
			}

			mAreEqual = false;
			return expression;
		}

		/// <inheritdoc/>
		protected override Expression VisitBinary(BinaryExpression node)
		{
			Debug.Assert(node != null);
			var expected = (BinaryExpression)mExpectedExpression;
			if (!CheckEqual(node.Method, expected.Method)) return node;
			if (!CheckEqual(node.IsLifted, expected.IsLifted)) return node;
			if (!CheckEqual(node.IsLiftedToNull, expected.IsLiftedToNull)) return node;
			return base.VisitBinary(node);
		}

		/// <inheritdoc/>
		protected override CatchBlock VisitCatchBlock(CatchBlock node)
		{
			Debug.Assert(node != null);
			var expected = PeekExpectedExpressionNode<CatchBlock>();
			if (!CheckNotNull(expected)) return node;
			if (!CheckEqual(node.Test, expected.Test)) return node;
			PopExpectedExpressionNode();
			return base.VisitCatchBlock(node);
		}

		/// <inheritdoc/>
		protected override Expression VisitConstant(ConstantExpression node)
		{
			Debug.Assert(node != null);
			var expected = (ConstantExpression)mExpectedExpression;
			if (!CheckEqual(node.Value, expected.Value)) return node;
			return base.VisitConstant(node);
		}

		/// <inheritdoc/>
		protected override Expression VisitDebugInfo(DebugInfoExpression node)
		{
			Debug.Assert(node != null);
			var expected = (DebugInfoExpression)mExpectedExpression;
			if (!CheckEqual(node.Document, expected.Document)) return node;
			if (!CheckEqual(node.StartLine, expected.StartLine)) return node;
			if (!CheckEqual(node.StartColumn, expected.StartColumn)) return node;
			if (!CheckEqual(node.EndLine, expected.EndLine)) return node;
			if (!CheckEqual(node.EndColumn, expected.EndColumn)) return node;
			if (!CheckEqual(node.IsClear, expected.IsClear)) return node;
			return base.VisitDebugInfo(node);
		}

		/// <inheritdoc/>
		protected override Expression VisitDynamic(DynamicExpression node)
		{
			Debug.Assert(node != null);
			var expected = (DynamicExpression)mExpectedExpression;
			if (!CheckEqual(node.Binder, expected.Binder)) return node;
			if (!CheckEqual(node.DelegateType, expected.DelegateType)) return node;
			return base.VisitDynamic(node);
		}

		/// <inheritdoc/>
		protected override ElementInit VisitElementInit(ElementInit node)
		{
			Debug.Assert(node != null);
			var expected = PeekExpectedExpressionNode<ElementInit>();
			if (!CheckNotNull(expected)) return node;
			if (!CheckEqual(node.AddMethod, expected.AddMethod)) return node;
			PopExpectedExpressionNode();
			return base.VisitElementInit(node);
		}

		/// <inheritdoc/>
		protected override Expression VisitGoto(GotoExpression node)
		{
			Debug.Assert(node != null);
			var expected = (GotoExpression)mExpectedExpression;
			if (!CheckEqual(node.Kind, expected.Kind)) return node;
			if (!CheckEqual(node.Target, expected.Target)) return node;
			return base.VisitGoto(node);
		}

		/// <inheritdoc/>
		protected override Expression VisitIndex(IndexExpression node)
		{
			Debug.Assert(node != null);
			var expected = (IndexExpression)mExpectedExpression;
			if (!CheckEqual(node.Indexer, expected.Indexer)) return node;
			return base.VisitIndex(node);
		}

		/// <inheritdoc/>
		protected override Expression VisitLabel(LabelExpression node)
		{
			Debug.Assert(node != null);
			var expected = (LabelExpression)mExpectedExpression;
			if (!CheckEqual(node.Target, expected.Target)) return node;
			return base.VisitLabel(node);
		}

		/// <inheritdoc/>
		protected override Expression VisitMember(MemberExpression node)
		{
			Debug.Assert(node != null);
			var expected = (MemberExpression)mExpectedExpression;
			if (!CheckEqual(node.Member, expected.Member)) return node;
			return base.VisitMember(node);
		}

		/// <inheritdoc/>
		protected override MemberAssignment VisitMemberAssignment(MemberAssignment node)
		{
			Debug.Assert(node != null);
			var expected = PeekExpectedExpressionNode<MemberAssignment>();
			if (!CheckNotNull(expected)) return node;
			if (!CheckEqual(node.BindingType, expected.BindingType)) return node;
			if (!CheckEqual(node.Member, expected.Member)) return node;
			PopExpectedExpressionNode();
			return base.VisitMemberAssignment(node);
		}

		/// <inheritdoc/>
		protected override MemberBinding VisitMemberBinding(MemberBinding node)
		{
			Debug.Assert(node != null);
			var expected = PeekExpectedExpressionNode<MemberBinding>();
			if (!CheckNotNull(expected)) return node;
			if (!CheckEqual(node.BindingType, expected.BindingType)) return node;
			if (!CheckEqual(node.Member, expected.Member)) return node;
			PopExpectedExpressionNode();
			return base.VisitMemberBinding(node);
		}

		/// <inheritdoc/>
		protected override MemberListBinding VisitMemberListBinding(MemberListBinding node)
		{
			Debug.Assert(node != null);
			var expected = PeekExpectedExpressionNode<MemberListBinding>();
			if (!CheckNotNull(expected)) return node;
			if (!CheckEqual(node.BindingType, expected.BindingType)) return node;
			if (!CheckEqual(node.Member, expected.Member)) return node;
			PopExpectedExpressionNode();
			return base.VisitMemberListBinding(node);
		}

		/// <inheritdoc/>
		protected override MemberMemberBinding VisitMemberMemberBinding(MemberMemberBinding node)
		{
			Debug.Assert(node != null);
			var expected = PeekExpectedExpressionNode<MemberMemberBinding>();
			if (!CheckNotNull(expected)) return node;
			if (!CheckEqual(node.BindingType, expected.BindingType)) return node;
			if (!CheckEqual(node.Member, expected.Member)) return node;
			PopExpectedExpressionNode();
			return base.VisitMemberMemberBinding(node);
		}

		/// <inheritdoc/>
		protected override LabelTarget VisitLabelTarget(LabelTarget node)
		{
			if (node != null)
			{
				var expected = PeekExpectedExpressionNode<LabelTarget>();
				if (!CheckNotNull(expected)) return node;
				if (!CheckEqual(node.Name, expected.Name)) return node;
			}
			else
			{
				if (mRemainingExpectedNodes.Count == 0)
				{
					mAreEqual = false;
					return null;
				}

				object obj = mRemainingExpectedNodes.Peek();
				if (obj != null)
				{
					mAreEqual = false;
					return null;
				}
			}

			PopExpectedExpressionNode();
			return base.VisitLabelTarget(node);
		}

		/// <inheritdoc/>
		protected override Expression VisitLambda<T>(Expression<T> node)
		{
			Debug.Assert(node != null);
			var expected = (Expression<T>)mExpectedExpression;
			if (!CheckEqual(node.Name, expected.Name)) return node;
			if (!CheckEqual(node.ReturnType, expected.ReturnType)) return node;
			if (!CheckEqual(node.TailCall, expected.TailCall)) return node;
			return base.VisitLambda(node);
		}

		/// <inheritdoc/>
		protected override Expression VisitMethodCall(MethodCallExpression node)
		{
			Debug.Assert(node != null);
			var expected = (MethodCallExpression)mExpectedExpression;
			if (!CheckEqual(node.Method, expected.Method)) return node;
			return base.VisitMethodCall(node);
		}

		/// <inheritdoc/>
		protected override Expression VisitNew(NewExpression node)
		{
			Debug.Assert(node != null);
			var expected = (NewExpression)mExpectedExpression;
			if (!CheckEqual(node.Constructor, expected.Constructor)) return node;
			if (!CheckSequenceEqual(node.Members, expected.Members)) return node;
			return base.VisitNew(node);
		}

		/// <inheritdoc/>
		protected override Expression VisitParameter(ParameterExpression node)
		{
			Debug.Assert(node != null);
			var expected = (ParameterExpression)mExpectedExpression;
			if (!CheckEqual(node.Name, expected.Name)) return node;
			if (!CheckEqual(node.IsByRef, expected.IsByRef)) return node;
			return node;
		}

		/// <inheritdoc/>
		protected override Expression VisitSwitch(SwitchExpression node)
		{
			Debug.Assert(node != null);
			var expected = (SwitchExpression)mExpectedExpression;
			if (!CheckEqual(node.Comparison, expected.Comparison)) return node;
			return base.VisitSwitch(node);
		}

		/// <inheritdoc/>
		protected override Expression VisitTypeBinary(TypeBinaryExpression node)
		{
			Debug.Assert(node != null);
			var expected = (TypeBinaryExpression)mExpectedExpression;
			if (!CheckEqual(node.TypeOperand, expected.TypeOperand)) return node;
			return base.VisitTypeBinary(node);
		}

		/// <inheritdoc/>
		protected override Expression VisitUnary(UnaryExpression node)
		{
			Debug.Assert(node != null);
			var expected = (UnaryExpression)mExpectedExpression;
			if (!CheckEqual(node.Method, expected.Method)) return node;
			if (!CheckEqual(node.IsLifted, expected.IsLifted)) return node;
			if (!CheckEqual(node.IsLiftedToNull, expected.IsLiftedToNull)) return node;
			return base.VisitUnary(node);
		}

		/// <summary>
		/// Gets the next expected expression node without removing it from the queue.
		/// </summary>
		/// <returns>
		/// The next expected expression;
		/// null, if the first element in the queue is not of type <typeparamref name="T"/> or the queue is empty.
		/// </returns>
		private T PeekExpectedExpressionNode<T>() where T : class
		{
			if (mRemainingExpectedNodes.Count == 0) return null;
			return mRemainingExpectedNodes.Peek() as T;
		}

		/// <summary>
		/// Removes the next expected expression node from the queue.
		/// </summary>
		/// <returns>The next expected node; null, if the queue is empty.</returns>
		private void PopExpectedExpressionNode()
		{
			mRemainingExpectedNodes.Dequeue();
		}

		/// <summary>
		/// Checks whether the specified expression is not null.
		/// </summary>
		/// <param name="node">Expression to check.</param>
		/// <returns>true, if the expression is not null; otherwise false.</returns>
		private bool CheckNotNull(object node)
		{
			if (node == null)
			{
				mAreEqual = false;
				return false;
			}

			return true;
		}

		/// <summary>
		/// Checks whether the specified expressions are of the same type.
		/// </summary>
		/// <param name="expression1">First expression to compare.</param>
		/// <param name="expression2">Second expression to compare.</param>
		/// <returns>true, if the specified expressions are of the same type; otherwise false.</returns>
		private bool CheckAreOfSameType(Expression expression1, Expression expression2)
		{
			Debug.Assert(expression1 != null);
			Debug.Assert(expression2 != null);

			return
				CheckEqual(expression1.NodeType, expression2.NodeType) &&
				CheckEqual(expression1.Type, expression2.Type);
		}

		/// <summary>
		/// Checks whether the specified types are equal.
		/// </summary>
		/// <typeparam name="T">Type of the objects to compare.</typeparam>
		/// <param name="obj1">First object to compare.</param>
		/// <param name="obj2">Second object to compare.</param>
		/// <returns>true, if the specified objects are equal; otherwise false.</returns>
		private bool CheckEqual<T>(T obj1, T obj2)
		{
			if (!EqualityComparer<T>.Default.Equals(obj1, obj2))
			{
				mAreEqual = false;
				return false;
			}

			return true;
		}

		/// <summary>
		/// Checks whether the specified types are equal.
		/// </summary>
		/// <typeparam name="T">Type of the objects to compare.</typeparam>
		/// <param name="obj1">First object to compare.</param>
		/// <param name="obj2">Second object to compare.</param>
		/// <returns>true, if the specified objects are equal; otherwise false.</returns>
		private bool CheckSequenceEqual<T>(IEnumerable<T> obj1, IEnumerable<T> obj2)
		{
			if (obj1 == null && obj2 == null) return true;
			if ((obj1 != null) ^ (obj2 != null)) return false;

			if (!obj1.SequenceEqual(obj2))
			{
				mAreEqual = false;
				return false;
			}

			return true;
		}
	}

}
