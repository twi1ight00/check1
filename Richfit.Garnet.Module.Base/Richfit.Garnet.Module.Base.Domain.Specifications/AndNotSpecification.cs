using System;
using System.Linq.Expressions;

namespace Richfit.Garnet.Module.Base.Domain.Specifications;

/// <summary>
/// Represents the combined specification which indicates that the first specification
/// can be satisifed by the given object whereas the second one cannot.
/// </summary>
/// <typeparam name="T">The type of the object to which the specification is applied.</typeparam>
public class AndNotSpecification<T> : CompositeSpecification<T>
{
	/// <summary>
	/// Constructs a new instance of <c>AndNotSpecification&lt;T&gt;</c> class.
	/// </summary>
	/// <param name="left">The first specification.</param>
	/// <param name="right">The second specification.</param>
	public AndNotSpecification(ISpecification<T> left, ISpecification<T> right)
		: base(left, right)
	{
	}

	/// <summary>
	/// Gets the LINQ expression which represents the current specification.
	/// </summary>
	/// <returns>The LINQ expression.</returns>
	public override Expression<Func<T, bool>> GetExpression()
	{
		UnaryExpression bodyNot = Expression.Not(base.Right.GetExpression().Body);
		Expression<Func<T, bool>> bodyNotExpression = Expression.Lambda<Func<T, bool>>(bodyNot, base.Right.GetExpression().Parameters);
		return base.Left.GetExpression().And(bodyNotExpression);
	}
}
