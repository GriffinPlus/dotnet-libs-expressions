///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// This file is part of the Griffin+ common library suite.
// Project URL: https://github.com/griffinplus/dotnet-libs-expressions
// The source code is licensed under the MIT license.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// uncomment to generate ExpressionHashCodeTest_Generated.tsv in the output directory that contains
// the generated hash codes for the processed expressions (for reviewing purposes)
// #define WRITE_GENERATED_HASH_CODES_TO_FILE

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using Xunit;

// ReSharper disable RedundantExplicitParamsArrayCreation
// ReSharper disable PossibleNullReferenceException
// ReSharper disable UnusedMember.Local
// ReSharper disable AssignNullToNotNullAttribute

namespace GriffinPlus.Lib.Expressions
{

	/// <summary>
	/// Unit tests for the <see cref="ExpressionEqualityComparer"/> class.
	/// </summary>
	public class ExpressionEqualityComparerTests
	{
		private static readonly Lazy<TestRecord[]> sExpectedData = new Lazy<TestRecord[]>(GenerateTestData, true);

		/// <summary>
		/// Initializes the <see cref="ExpressionEqualityComparerTests"/> class.
		/// </summary>
		static ExpressionEqualityComparerTests()
		{
			// disable caching hash codes during unit tests
			ExpressionHashCodeCalculation.Instance.CacheHashCodes = false;
		}

		/// <summary>
		/// Generates test data that can be used as expected data in subsequent runs.
		/// The generated file (ExpressionHashCodeTest_Generated.tsv) is put into the build directory and
		/// must be copied to the project folder in case of an update).
		/// </summary>
		/// <returns>The generated test data set.</returns>
		private static TestRecord[] GenerateTestData()
		{
			// generate the expected set of hash codes (file can be used as expected data later on)
			ExpressionEqualityComparer comparer = new ExpressionEqualityComparer();
			List<TestRecord> records = new List<TestRecord>();
			foreach (var expression in TestExpressions)
			{
				int hashCode = comparer.GetHashCode(expression);
				records.Add(
					new TestRecord
					{
						Expression = expression.ToString(),
						HashCode = hashCode
					});
			}

#if WRITE_GENERATED_HASH_CODES_TO_FILE
			// write expected data set
			string path = Path.GetFullPath("ExpressionHashCodeTest_Generated.tsv");
			Helpers.WriteTestData(path, records);

#endif // WRITE_GENERATED_HASH_CODES_TO_FILE

			// check whether the generated hash codes are different
			// (different expressions may have the same hash code, but it should not happen too often...)
			Dictionary<int, string> set = new Dictionary<int, string>();
			int duplicateHashCodeCount = 0;
			foreach (var record in records)
			{
				if (set.TryGetValue(record.HashCode, out var other))
				{
					Console.WriteLine("Detected duplicate hash code ({0}) for expression ({1}) and expression ({2})", record.HashCode, other, record.Expression);
					duplicateHashCodeCount++;
					continue;
				}

				set.Add(record.HashCode, record.Expression);
			}

			// check whether the number of hash code duplicates is below the threshold of 5%
			double duplicateHashCodeRatio = (double)duplicateHashCodeCount / records.Count;
			Assert.True(duplicateHashCodeRatio < 0.05);

			return records.ToArray();
		}

		/// <summary>
		/// Loads test data shipped with the project.
		/// </summary>
		/// <returns>The loaded test data set.</returns>
		private static TestRecord[] LoadTestData()
		{
			string path = Path.GetFullPath(@"Test Data\ExpressionHashCodeTest.tsv");
			return TestDataHelpers.ReadTestData(path).ToArray();
		}

		#region GetHashCode()

		[Theory]
		[MemberData(nameof(GetHashCode_TestData))]
		public void GetHashCode_Success(Expression expression, int expectedHashCode)
		{
			ExpressionEqualityComparer comparer = new ExpressionEqualityComparer();
			int hashCode = comparer.GetHashCode(expression);
			Assert.Equal(expectedHashCode, hashCode);
		}

		public static IEnumerable<object[]> GetHashCode_TestData
		{
			get
			{
				var expressions = TestExpressions.ToArray();
				var hashCodes = sExpectedData.Value.Select(x => x.HashCode).ToArray();
				Assert.Equal(expressions.Length, hashCodes.Length);

				for (int i = 0; i < expressions.Length; i++)
				{
					yield return new object[]
					{
						expressions[i],
						hashCodes[i]
					};
				}
			}
		}

		#endregion

		#region Equals()

		[Fact]
		public void Equals_Success()
		{
			ExpressionEqualityComparer comparer = new ExpressionEqualityComparer();

			var expressions = TestExpressions.ToArray();
			for (int i = 0; i < expressions.Length; i++)
			{
				for (int j = 0; j < expressions.Length; j++)
				{
					bool isEqual = comparer.Equals(expressions[i], expressions[j]);
					if (i == j) Assert.True(isEqual, $"Expression {i} {expressions[i]} compared with itself should be equal, but Equals() returns false.");
					else Assert.False(isEqual, $"Expression {i} {expressions[i]} compared with expression {j} ({expressions[j]}) should not be equal, but Equals() returns true.");
				}
			}
		}

		#endregion

		#region Test Data

		public static IEnumerable<Expression> TestExpressions
		{
			get
			{
				#region Primitive Expressions

				// NodeType: Constant
				yield return Expression.Constant(1);

				// NodeType: Parameter / Variable (are the same)
				yield return Expression.Parameter(typeof(int));
				yield return Expression.Parameter(typeof(int), "x");
				// yield return Expression.Variable(typeof(int));
				// yield return Expression.Variable(typeof(int), "x");

				// NodeType: Property
				yield return Expression.Property(
					Expression.Variable(typeof(string), "sp1"),
					typeof(string).GetProperty(nameof(string.Length)));

				// NodeType: Property
				yield return Expression.Property(
					Expression.Variable(typeof(string), "sp2"),
					typeof(string).GetProperty(nameof(string.Length)).GetMethod);

				// NodeType: Property
				yield return Expression.Property(
					Expression.Variable(typeof(string), "sp3"),
					nameof(string.Length));

				// NodeType: Property
				yield return Expression.Property( // list[index]
					Expression.Variable(typeof(List<int>), "list"),
					typeof(List<int>).GetProperty("Item"),
					Expression.Variable(typeof(int), "index"));

				// same as...
				// // NodeType: Index
				// yield return Expression.MakeIndex(            // list[index]
				//	Expression.Variable(typeof(List<int>), "list"),
				//	typeof(List<int>).GetProperty("Item"),
				//	new[] { Expression.Variable(typeof(int), "index") });

				// NodeType: PropertyOrField
				yield return Expression.PropertyOrField(
					Expression.Variable(typeof(string), "spf"),
					nameof(string.Length));

				// NodeType: RuntimeVariables
				yield return Expression.RuntimeVariables(
					Expression.Parameter(typeof(int)),
					Expression.Parameter(typeof(long)));

				// NodeType: Dynamic
				// TODO

				// NodeType: Assign
				yield return Expression.Assign(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				#endregion

				#region Object Creation / Initialization

				// NodeType: Default
				yield return Expression.Default(typeof(int));

				// NodeType: New
				yield return Expression.New(typeof(Point)); // new Point()
				yield return Expression.New(                // new Point(x, y)
					typeof(Point).GetConstructor(new[] { typeof(int), typeof(int) }),
					new Expression[]
					{
						Expression.Parameter(typeof(int), "x"),
						Expression.Parameter(typeof(int), "y")
					});

				// NodeType: MemberInit
				yield return Expression.MemberInit( // new Point() { X = 1, Y = 2 }
					Expression.New(typeof(Point)),
					new MemberBinding[]
					{
						Expression.Bind(typeof(Point).GetProperty("X"), Expression.Constant(1)),
						Expression.Bind(typeof(Point).GetProperty("Y"), Expression.Constant(2))
					});

				#endregion

				#region Unboxing

				// NodeType: Unbox
				yield return Expression.Unbox(
					Expression.Variable(typeof(object), "x"),
					typeof(int));

				#endregion

				#region Arithmetic Operations

				// NodeType: Add
				yield return Expression.Add(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: AddChecked
				yield return Expression.AddChecked(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: AddAssign
				yield return Expression.AddAssign(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: AddAssignChecked
				yield return Expression.AddAssignChecked(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: Subtract
				yield return Expression.Subtract(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: SubtractChecked
				yield return Expression.SubtractChecked(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: SubtractAssign
				yield return Expression.SubtractAssign(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: SubtractAssignChecked
				yield return Expression.SubtractAssignChecked(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: Multiply
				yield return Expression.Multiply(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: MultiplyChecked
				yield return Expression.MultiplyChecked(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: MultiplyAssign
				yield return Expression.MultiplyAssign(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: MultiplyAssignChecked
				yield return Expression.MultiplyAssignChecked(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: Divide
				yield return Expression.Divide(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: DivideAssign
				yield return Expression.DivideAssign(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: Modulo
				yield return Expression.Modulo(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: ModuloAssign
				yield return Expression.ModuloAssign(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: Power
				yield return Expression.Power(
					Expression.Variable(typeof(double), "x"),
					Expression.Variable(typeof(double), "y"));

				// NodeType: PowerAssign
				yield return Expression.PowerAssign(
					Expression.Variable(typeof(double), "x"),
					Expression.Variable(typeof(double), "y"));

				// NodeType: Increment
				yield return Expression.Increment(Expression.Variable(typeof(int), "x"));

				// NodeType: PreIncrementAssign
				yield return Expression.PreIncrementAssign(Expression.Variable(typeof(int), "x"));

				// NodeType: PostIncrementAssign
				yield return Expression.PostIncrementAssign(Expression.Variable(typeof(int), "x"));

				// NodeType: Decrement
				yield return Expression.Decrement(Expression.Variable(typeof(int), "x"));

				// NodeType: PreDecrementAssign
				yield return Expression.PreDecrementAssign(Expression.Variable(typeof(int), "x"));

				// NodeType: PostDecrementAssign
				yield return Expression.PostDecrementAssign(Expression.Variable(typeof(int), "x"));

				// NodeType: Negate
				yield return Expression.Negate(Expression.Variable(typeof(int), "x"));

				// NodeType: NegateChecked
				yield return Expression.NegateChecked(Expression.Variable(typeof(int), "x"));

				// NodeType: UnaryPlus
				yield return Expression.UnaryPlus(Expression.Variable(typeof(int), "x"));

				#endregion

				#region Bitwise Operations

				// NodeType: And
				yield return Expression.And(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: AndAssign
				yield return Expression.AndAssign(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: Or
				yield return Expression.Or(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: OrAssign
				yield return Expression.OrAssign(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: ExclusiveOr
				yield return Expression.ExclusiveOr(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: ExclusiveOrAssign
				yield return Expression.ExclusiveOrAssign(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: Not
				yield return Expression.Not(Expression.Variable(typeof(int), "x"));

				// NodeType: OnesComplement
				yield return Expression.OnesComplement(Expression.Variable(typeof(int), "x"));

				// NodeType: LeftShift
				yield return Expression.LeftShift(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: LeftShiftAssign
				yield return Expression.LeftShiftAssign(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: RightShift
				yield return Expression.RightShift(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: RightShiftAssign
				yield return Expression.RightShiftAssign(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				#endregion

				#region Logical Operations

				// NodeType: And
				yield return Expression.And(
					Expression.Variable(typeof(bool), "x"),
					Expression.Variable(typeof(bool), "y"));

				// NodeType: AndAssign
				yield return Expression.AndAssign(
					Expression.Variable(typeof(bool), "x"),
					Expression.Variable(typeof(bool), "y"));

				// NodeType: AndAlso
				yield return Expression.AndAlso(
					Expression.Variable(typeof(bool), "x"),
					Expression.Variable(typeof(bool), "y"));

				// NodeType: Or
				yield return Expression.Or(
					Expression.Variable(typeof(bool), "x"),
					Expression.Variable(typeof(bool), "y"));

				// NodeType: OrAssign
				yield return Expression.OrAssign(
					Expression.Variable(typeof(bool), "x"),
					Expression.Variable(typeof(bool), "y"));

				// NodeType: OrElse
				yield return Expression.OrElse(
					Expression.Variable(typeof(bool), "x"),
					Expression.Variable(typeof(bool), "y"));

				// NodeType: ExclusiveOr
				yield return Expression.ExclusiveOr(
					Expression.Variable(typeof(bool), "x"),
					Expression.Variable(typeof(bool), "y"));

				// NodeType: ExclusiveOrAssign
				yield return Expression.ExclusiveOrAssign(
					Expression.Variable(typeof(bool), "x"),
					Expression.Variable(typeof(bool), "y"));

				// NodeType: Not
				yield return Expression.Not(Expression.Variable(typeof(bool), "x"));

				#endregion

				#region Array Operations

				// NodeType: NewArrayBounds
				yield return Expression.NewArrayBounds( // new int[x]
					typeof(int),
					Expression.Variable(typeof(int), "x"));

				// NodeType: NewArrayInit
				yield return Expression.NewArrayInit( // new int[] { 1, 2, 3 }
					typeof(int),
					new Expression[]
					{
						Expression.Constant(1),
						Expression.Constant(2),
						Expression.Constant(3)
					});

				// NodeType: ArrayIndex
				yield return Expression.ArrayIndex( // array[index]
					Expression.Variable(typeof(int[]), "array"),
					Expression.Variable(typeof(int), "index"));

				// NodeType: ArrayAccess
				yield return Expression.ArrayAccess( // array[index1,index2]
					Expression.Variable(typeof(int[,]), "array"),
					Expression.Variable(typeof(int), "index1"),
					Expression.Variable(typeof(int), "index2"));

				// NodeType: ArrayLength
				yield return Expression.ArrayLength( // array.Length
					Expression.Variable(typeof(int[]), "array"));

				#endregion

				#region ListInit, ElementInit

				{
					// example from the documentation of the 'ListInit' expression

					string tree1 = "maple";
					string tree2 = "oak";

					MethodInfo addMethod = typeof(Dictionary<int, string>).GetMethod("Add");

					// Create two ElementInit objects that represent the two key-value pairs to add to the Dictionary.
					ElementInit elementInit1 =
						Expression.ElementInit(
							addMethod,
							Expression.Constant(tree1.Length),
							Expression.Constant(tree1));
					ElementInit elementInit2 =
						Expression.ElementInit(
							addMethod,
							Expression.Constant(tree2.Length),
							Expression.Constant(tree2));

					// Create a NewExpression that represents constructing
					// a new instance of Dictionary<int, string>.
					NewExpression newDictionaryExpression = Expression.New(typeof(Dictionary<int, string>));

					// Create a ListInitExpression that represents initializing a new Dictionary<> instance with two key-value pairs.
					yield return Expression.ListInit(
						newDictionaryExpression,
						elementInit1,
						elementInit2);
				}

				#endregion

				#region Member Access

				// NodeType: MemberAccess
				yield return Expression.MakeMemberAccess(
					Expression.Variable(typeof(Point), "pt"),
					typeof(Point).GetProperty("X"));

				#endregion

				#region Coalesce

				// NodeType: Coalesce
				yield return Expression.Coalesce(
					Expression.Variable(typeof(string), "x"),
					Expression.Variable(typeof(string), "y"));

				#endregion

				#region Conditional, If-Then, If-Then-Else, Switch

				// NodeType: Condition
				yield return Expression.Condition( // condition ? x : y
					Expression.Variable(typeof(bool), "condition"),
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: IfThen
				// if (x > 1) { y = 1 }
				yield return Expression.IfThen(
					Expression.GreaterThan(
						Expression.Variable(typeof(int), "x"),
						Expression.Constant(1)),
					Expression.Assign(
						Expression.Variable(typeof(int), "y"),
						Expression.Constant(1)));

				// NodeType: IfThenElse
				// if (x > 1) { y = 1 } else { y = 2 }
				yield return Expression.IfThenElse(
					Expression.GreaterThan(
						Expression.Variable(typeof(int), "x"),
						Expression.Constant(1)),
					Expression.Assign(
						Expression.Variable(typeof(int), "y"),
						Expression.Constant(1)),
					Expression.Assign(
						Expression.Variable(typeof(int), "y"),
						Expression.Constant(2)));

				// NodeType: Switch, SwitchCase
				{
					// int value = ...
					// int result;
					// switch (value)
					// {
					//     case 1:
					//         result = 100;
					//         break;
					//     case 2:
					//         result = 200;
					//         break;
					//     default:
					//         result = -1;
					//         break;
					// }
					var switchValueExpression = Expression.Variable(typeof(int), "value");
					var resultExpression = Expression.Variable(typeof(int), "result");
					yield return Expression.Switch(
						switchValueExpression,
						Expression.Assign(resultExpression, Expression.Constant(-1)),
						new[]
						{
							Expression.SwitchCase(
								Expression.Assign(resultExpression, Expression.Constant(100)),
								Expression.Constant(1)),
							Expression.SwitchCase(
								Expression.Assign(resultExpression, Expression.Constant(200)),
								Expression.Constant(2))
						});
				}

				#endregion

				#region Conversion

				// NodeType: Convert
				yield return Expression.Convert( // (int)x
					Expression.Variable(typeof(double), "x"),
					typeof(int));

				// NodeType: ConvertChecked
				yield return Expression.ConvertChecked( // checked((int)x)
					Expression.Variable(typeof(double), "x"),
					typeof(int));

				// NodeType: TypeAs
				yield return Expression.TypeAs(
					Expression.Constant(42, typeof(int)),
					typeof(int?));

				#endregion

				#region Comparison

				// NodeType: IsTrue
				yield return Expression.IsTrue(Expression.Variable(typeof(bool), "x"));

				// NodeType: IsFalse
				yield return Expression.IsFalse(Expression.Variable(typeof(bool), "x"));

				// NodeType: NotEqual
				yield return Expression.NotEqual(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: LessThan
				yield return Expression.LessThan(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: LessThanOrEqual
				yield return Expression.LessThanOrEqual(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: Equal
				yield return Expression.Equal(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: GreaterThanOrEqual
				yield return Expression.GreaterThanOrEqual(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: GreaterThan
				yield return Expression.GreaterThan(
					Expression.Variable(typeof(int), "x"),
					Expression.Variable(typeof(int), "y"));

				// NodeType: Equal (same as above)
				yield return Expression.ReferenceEqual(
					Expression.Variable(typeof(object), "x"),
					Expression.Variable(typeof(object), "y"));

				// NodeType: NotEqual (same as above)
				yield return Expression.ReferenceNotEqual(
					Expression.Variable(typeof(object), "x"),
					Expression.Variable(typeof(object), "y"));

				// NodeType: TypeEqual
				yield return Expression.TypeEqual(
					Expression.Constant(42, typeof(int)),
					typeof(int));

				// NodeType: TypeIs
				yield return Expression.TypeIs(
					Expression.Constant(42, typeof(int)),
					typeof(int));

				#endregion

				#region Call

				// NodeType: Call
				yield return Expression.Call( // string.Concat(x, y)
					typeof(string).GetMethod(
						"Concat",
						new[] { typeof(string), typeof(string) }),
					Expression.Variable(typeof(string), "x"),
					Expression.Variable(typeof(string), "y"));

				// NodeType: Call
				yield return Expression.Call( // x.ToString()
					Expression.Variable(typeof(object), "x"),
					typeof(object).GetMethod("ToString"));

				#endregion

				#region Lambda

				{
					// NodeType: Lambda
					ParameterExpression lambdaParameter = Expression.Parameter(typeof(int), "x");
					yield return Expression.Lambda( // x => x
						lambdaParameter,
						lambdaParameter);
				}

				{
					// NodeType: Lambda
					ParameterExpression lambdaParameter = Expression.Parameter(typeof(int), "x");
					yield return Expression.Lambda( // x => x + x
						Expression.Add(lambdaParameter, lambdaParameter),
						lambdaParameter);
				}

				#endregion

				#region Block

				// block with no variables and return value
				yield return Expression.Block( // { x++; y++ }
					Expression.PostIncrementAssign(Expression.Variable(typeof(int), "x")),
					Expression.PostIncrementAssign(Expression.Variable(typeof(int), "y")));

				{
					// block (with variables and return value)
					var arg = Expression.Parameter(typeof(int), "arg");
					yield return Expression.Block( // { var arg; x++; return arg++}
						typeof(int),               // result type
						new[] { arg },             // arguments
						Expression.PostIncrementAssign(Expression.Variable(typeof(int), "x")),
						Expression.PostIncrementAssign(arg) // returned from the block
					);
				}

				#endregion

				#region Goto, Label

				{
					LabelTarget returnTarget = Expression.Label();
					yield return Expression.Block(
						Expression.Call(Expression.Constant("Top"), typeof(string).GetMethod("ToString", Type.EmptyTypes)),
						Expression.Goto(returnTarget),
						Expression.Call(Expression.Constant("Flop"), typeof(string).GetMethod("ToString", Type.EmptyTypes)), // not executed
						Expression.Label(returnTarget));
				}

				{
					LabelTarget returnTarget = Expression.Label();
					yield return Expression.Block(
						Expression.Call(Expression.Constant("Top"), typeof(string).GetMethod("ToString", Type.EmptyTypes)),
						Expression.Return(returnTarget),
						Expression.Call(Expression.Constant("Flop"), typeof(string).GetMethod("ToString", Type.EmptyTypes)), // not executed
						Expression.Label(returnTarget));
				}

				#endregion

				#region Invoke

				{
					// example from the documentation of the 'Invoke' expression
					Expression<Func<int, int, bool>> largeSumTest = (num1, num2) => num1 + num2 > 1000;
					yield return Expression.Invoke(
						largeSumTest,
						Expression.Constant(539),
						Expression.Constant(281));
				}

				#endregion

				#region Loop, Continue, Break

				{
					// example from the documentation of the 'Continue' expression
					// --------------------------------------------------------------------------------

					// A label that is used by a break statement and a loop. 
					LabelTarget breakLabel = Expression.Label();

					// A label that is used by the Continue statement and the loop it refers to.
					LabelTarget continueLabel = Expression.Label();

					// This expression represents a Continue statement.
					Expression continueExpr = Expression.Continue(continueLabel);

					// A variable that triggers the exit from the loop.
					ParameterExpression count = Expression.Parameter(typeof(int));

					// A loop statement.
					yield return Expression.Loop(
						Expression.Block(
							Expression.IfThen(
								Expression.GreaterThan(count, Expression.Constant(3)),
								Expression.Break(breakLabel)),
							Expression.PreIncrementAssign(count),
							Expression.Call(
								null,
								typeof(Console).GetMethod("WriteLine", new[] { typeof(string) }),
								Expression.Constant("Loop")),
							continueExpr,
							Expression.PreDecrementAssign(count)),
						breakLabel,
						continueLabel);
				}

				{
					// example from the documentation of the 'Break' expression
					// -------------------------------------------------------------------------------

					// Creating a parameter expression.
					ParameterExpression value = Expression.Parameter(typeof(int), "value");

					// Creating an expression to hold a local variable. 
					ParameterExpression result = Expression.Parameter(typeof(int), "result");

					// Creating a label to jump to from a loop.
					LabelTarget label = Expression.Label(typeof(int));

					// Creating a method body.
					yield return Expression.Block(
						new[] { result },
						Expression.Assign(result, Expression.Constant(1)),
						Expression.Loop(
							Expression.IfThenElse(
								Expression.GreaterThan(value, Expression.Constant(1)),
								Expression.MultiplyAssign(result, Expression.PostDecrementAssign(value)),
								Expression.Break(label, result)),
							label));
				}

				{
					// example from the documentation of the 'Loop' expression
					// -------------------------------------------------------------------------------

					// Creating a parameter expression.
					ParameterExpression value = Expression.Parameter(typeof(int), "value");

					// Creating an expression to hold a local variable. 
					ParameterExpression result = Expression.Parameter(typeof(int), "result");

					// Creating a label to jump to from a loop.
					LabelTarget label = Expression.Label(typeof(int));

					// Creating a method body.
					yield return Expression.Block(
						new[] { result },
						Expression.Assign(result, Expression.Constant(1)),
						Expression.Loop(
							Expression.IfThenElse(
								Expression.GreaterThan(value, Expression.Constant(1)),
								Expression.MultiplyAssign(
									result,
									Expression.PostDecrementAssign(value)),
								Expression.Break(label, result)),
							label));
				}

				#endregion

				#region Try-Catch, Try-Catch-Finally, Try-Finally, Try-Fault, Throw, Rethrow

				yield return Expression.TryCatch(
					Expression.Block(
						Expression.Throw(Expression.New(typeof(Exception))),
						Expression.Constant("try block")),
					Expression.Catch(
						typeof(Exception),
						Expression.Constant("catch block")));

				yield return Expression.TryCatchFinally(
					Expression.Block(
						Expression.Throw(Expression.New(typeof(Exception))),
						Expression.Constant("try block")),
					Expression.Constant("try block"),
					Expression.Catch(
						typeof(Exception),
						Expression.Constant("catch block")));

				yield return Expression.TryFinally(
					Expression.Block(
						Expression.Throw(Expression.New(typeof(Exception))),
						Expression.Constant("try block")),
					Expression.Constant("finally block"));

				yield return Expression.TryFault(
					Expression.Block(
						Expression.Throw(Expression.New(typeof(Exception))),
						Expression.Constant("try block")),
					Expression.Constant("fault block"));

				yield return Expression.Rethrow();

				#endregion

				#region Quote

				// NodeType: Quote
				{
					var lambdaParameter = Expression.Parameter(typeof(int), "x");
					yield return Expression.Quote(
						Expression.Lambda(
							lambdaParameter,
							lambdaParameter));
				}

				#endregion

				#region DebugInfo

				// NodeType: DebugInfo
				yield return Expression.DebugInfo(
					Expression.SymbolDocument("test.cs"),
					1,
					2,
					3,
					4);

				#endregion
			}
		}

		#endregion
	}

}
