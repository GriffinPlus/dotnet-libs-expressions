///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// This file is part of the Griffin+ common library suite.
// Project URL: https://github.com/griffinplus/dotnet-libs-expressions
// The source code is licensed under the MIT license.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace GriffinPlus.Lib.Expressions
{
	/// <summary>
	/// An expression visitor that calculates the hash code of certain expression.
	/// </summary>
	internal sealed class ExpressionHashCodeCalculation : ExpressionVisitor
	{
		/// <summary>
		/// Instance cache, keeps only one instance per thread to reduce GC pressure.
		/// </summary>
		private static readonly ThreadLocal<ExpressionHashCodeCalculation> sInstance = new ThreadLocal<ExpressionHashCodeCalculation>(() => new ExpressionHashCodeCalculation());

		/// <summary>
		/// A dictionary that caches the hash code of a processed expression.
		/// </summary>
		private static readonly ConditionalWeakTable<Expression, StrongBox<int>> sHashCodeCache = new ConditionalWeakTable<Expression, StrongBox<int>>();

		// Parameters for the FNV-1a Hash
		// (see http://www.isthe.com/chongo/tech/comp/fnv/)
		private const int FnvHashOffset = unchecked((int)2166136261);
		private const int FnvPrime = 16777619;

		/// <summary>
		/// Initializes a new instance of the <see cref="ExpressionHashCodeCalculation"/> class.
		/// </summary>
		private ExpressionHashCodeCalculation()
		{

		}

		/// <summary>
		/// Gets the singleton instance of the class for the current thread.
		/// </summary>
		public static ExpressionHashCodeCalculation Instance => sInstance.Value;

		/// <summary>
		/// Gets the hash code of the expression.
		/// </summary>
		public int HashCode { get; private set; }

		/// <summary>
		/// Gets or sets a value indicating whether calculated hash code are cached speeding up repetitive requests
		/// (enabled by default, but it can be disabled for testing purposes).
		/// </summary>
		public bool CacheHashCodes { get; set; } = true;

		/// <summary>
		/// Calculates the hash code of the specified expression.
		/// </summary>
		/// <param name="expression">Expression to get the hash code of.</param>
		/// <returns>Hash code of the specified expression.</returns>
		public static int GetHashCode(Expression expression)
		{
			if (expression == null) throw new ArgumentNullException(nameof(expression));

			var instance = sInstance.Value;

			// query hash code cache
			if (sInstance.Value.CacheHashCodes)
			{
				if (sHashCodeCache.TryGetValue(expression, out var cachedHashCode)) {
					return cachedHashCode.Value;
				}
			}

			// calculate hash code
			instance.HashCode = FnvHashOffset;
			instance.Visit(expression);

			// update hash code cache
			if (instance.CacheHashCodes) {
				sHashCodeCache.Add(expression, new StrongBox<int>(instance.HashCode));
			}

			return instance.HashCode;
		}

		/// <inheritdoc />
		public override Expression Visit(Expression expression)
		{
			if (expression == null) return null;
			Hash((int)expression.NodeType);
			Hash(expression.Type);
			return base.Visit(expression);
		}

		/// <inheritdoc />
		protected override Expression VisitBinary(BinaryExpression node)
		{
			Hash(node.Method);
			Hash(node.IsLifted);
			Hash(node.IsLiftedToNull);
			return base.VisitBinary(node);
		}

		/// <inheritdoc />
		protected override CatchBlock VisitCatchBlock(CatchBlock node)
		{
			Hash(node.Test);
			return base.VisitCatchBlock(node);
		}

		/// <inheritdoc />
		protected override Expression VisitConstant(ConstantExpression node)
		{
			Hash(node.Value);
			return node;
		}

		/// <inheritdoc />
		protected override Expression VisitDebugInfo(DebugInfoExpression node)
		{
			Hash(node.Document);
			Hash(node.StartLine);
			Hash(node.StartColumn);
			Hash(node.EndLine);
			Hash(node.EndColumn);
			Hash(node.IsClear);
			return base.VisitDebugInfo(node);
		}

		/// <inheritdoc />
		protected override Expression VisitDynamic(DynamicExpression node)
		{
			Hash(node.Binder);
			Hash(node.DelegateType);
			return base.VisitDynamic(node);
		}

		/// <inheritdoc />
		protected override ElementInit VisitElementInit(ElementInit node)
		{
			Hash(node.AddMethod);
			return base.VisitElementInit(node);
		}

		/// <inheritdoc />
		protected override Expression VisitGoto(GotoExpression node)
		{
			Hash((int)node.Kind);
			Hash(node.Target);
			return base.VisitGoto(node);
		}

		/// <inheritdoc />
		protected override Expression VisitIndex(IndexExpression node)
		{
			Hash(node.Indexer);
			return base.VisitIndex(node);
		}

		/// <inheritdoc />
		protected override Expression VisitLabel(LabelExpression node)
		{
			Hash(node.Target);
			return base.VisitLabel(node);
		}

		/// <inheritdoc />
		protected override LabelTarget VisitLabelTarget(LabelTarget node)
		{
			if (node == null) return null;
			Hash(node.Name);
			return base.VisitLabelTarget(node);
		}

		/// <inheritdoc />
		protected override Expression VisitLambda<T>(Expression<T> node)
		{
			Hash(node.Name);
			Hash(node.ReturnType);
			Hash(node.TailCall);
			return base.VisitLambda(node);
		}

		/// <inheritdoc />
		protected override Expression VisitLoop(LoopExpression node)
		{
			Hash(node.BreakLabel);
			Hash(node.ContinueLabel);
			return base.VisitLoop(node);
		}

		/// <inheritdoc />
		protected override Expression VisitMember(MemberExpression node)
		{
			Hash(node.Member);
			return base.VisitMember(node);
		}

		/// <inheritdoc />
		protected override MemberBinding VisitMemberBinding(MemberBinding node)
		{
			Hash(node.BindingType);
			return base.VisitMemberBinding(node);
		}

		/// <inheritdoc />
		protected override Expression VisitMethodCall(MethodCallExpression node)
		{
			Hash(node.Method);
			return base.VisitMethodCall(node);
		}

		/// <inheritdoc />
		protected override Expression VisitNew(NewExpression node)
		{
			Hash(node.Constructor);
			return base.VisitNew(node);
		}

		/// <inheritdoc />
		protected override Expression VisitParameter(ParameterExpression parameter)
		{
			Hash(parameter.Name);
			Hash(parameter.IsByRef);
			return parameter;
		}

		/// <inheritdoc />
		protected override Expression VisitSwitch(SwitchExpression node)
		{
			Hash(node.Comparison);
			return base.VisitSwitch(node);
		}

		/// <inheritdoc />
		protected override Expression VisitTypeBinary(TypeBinaryExpression node)
		{
			Hash(node.TypeOperand);
			return base.VisitTypeBinary(node);
		}

		/// <inheritdoc />
		protected override Expression VisitUnary(UnaryExpression node)
		{
			Hash(node.Method);
			Hash(node.IsLifted);
			Hash(node.IsLiftedToNull);
			return base.VisitUnary(node);
		}

		/// <summary>
		/// Calculates the specified value into current hash code.
		/// </summary>
		/// <param name="value">Value to hash.</param>
		private void Hash(int value)
		{
			unchecked
			{
				HashCode ^= value;
				HashCode *= FnvPrime;
			}
		}

		/// <summary>
		/// Calculates the specified value into current hash code.
		/// </summary>
		/// <param name="value">Value to hash.</param>
		private void Hash(bool value)
		{
			unchecked
			{
				HashCode ^= value ? 1 : 0;
				HashCode *= FnvPrime;
			}
		}

		/// <summary>
		/// Calculates the specified type into current hash code.
		/// </summary>
		/// <param name="type">Type to hash.</param>
		private void Hash(Type type)
		{
			unchecked
			{
				if (type != null) HashCode ^= type.GetHashCode();
				else              HashCode ^= 532106345; // magic number
				HashCode *= FnvPrime;
			}
		}

		/// <summary>
		/// Calculates the specified constructor into current hash code.
		/// </summary>
		/// <param name="constructor">Constructor to hash.</param>
		private void Hash(ConstructorInfo constructor)
		{
			unchecked
			{
				if (constructor != null) HashCode ^= constructor.GetHashCode();
				else                     HashCode ^= 10397522; // magic number
				HashCode *= FnvPrime;
			}
		}

		/// <summary>
		/// Calculates the specified method into current hash code.
		/// </summary>
		/// <param name="method">Method to hash.</param>
		private void Hash(MethodInfo method)
		{
			unchecked
			{
				if (method != null) HashCode ^= method.GetHashCode();
				else                HashCode ^= 123864332; // magic number
				HashCode *= FnvPrime;
			}
		}

		/// <summary>
		/// Calculates the specified member into current hash code.
		/// </summary>
		/// <param name="member">Member to hash.</param>
		private void Hash(MemberInfo member)
		{
			unchecked
			{
				if (member != null) HashCode ^= member.GetHashCode();
				else                HashCode ^= 75206420; // magic number
				HashCode *= FnvPrime;
			}
		}

		/// <summary>
		/// Calculates the specified member into current hash code.
		/// </summary>
		/// <param name="target">Label target to hash.</param>
		private void Hash(LabelTarget target)
		{
			unchecked
			{
				if (target != null)
				{
					Hash(target.Name);
					Hash(target.Type);
				}
				else
				{
					HashCode ^= 350286420; // magic number
					HashCode *= FnvPrime;
				}
			}
		}

		/// <summary>
		/// Calculates the specified symbol document into current hash code.
		/// </summary>
		/// <param name="document">Document to hash.</param>
		private void Hash(SymbolDocumentInfo document)
		{
			unchecked
			{
				if (document != null)
				{
					Hash(document.FileName);
					Hash(document.DocumentType);
					Hash(document.Language);
					Hash(document.LanguageVendor);
				}
				else
				{
					HashCode ^= 75206420; // magic number
					HashCode *= FnvPrime;
				}
			}
		}

		/// <summary>
		/// Calculates the specified value into current hash code.
		/// </summary>
		/// <param name="value">Value to hash.</param>
		private void Hash(object value)
		{
			unchecked
			{
				if (value != null) HashCode ^= value.GetHashCode();
				else               HashCode ^= 875231744; // magic number
				HashCode *= FnvPrime;
			}
		}

	}
}