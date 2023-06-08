using System;
using System.Linq.Expressions;

namespace Richfit.Garnet.Module.Base.Domain.Specifications;

/// <summary>
/// Represents the specification which indicates the semantics opposite to the given specification.
/// </summary>
/// <typeparam name="T">The type of the object to which the specification is applied.</typeparam>
public class NotSpecification<T> : Specification<T>
{
	private ISpecification<T> spec;

	/// <summary>
	/// Initializes a new instance of <c>NotSpecification&lt;T&gt;</c> class.
	/// </summary>
	/// <param name="specification">The specification to be reversed.</param>
	public NotSpecification(ISpecification<T> specification)
	{
		spec = specification;
	}

	/// <summary>
	/// Gets the LINQ expression which represents the current specification.
	/// </summary>
	/// <returns>The LINQ expression.</returns>
	public override Expression<Func<T, bool>> GetExpression()
	{
		UnaryExpression body = Expression.Not(spec.GetExpression().Body);
		return Expression.Lambda<Func<T, bool>>(body, spec.GetExpression().Parameters);
	}
}
