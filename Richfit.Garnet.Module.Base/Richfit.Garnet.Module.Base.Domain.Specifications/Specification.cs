using System;
using System.Linq.Expressions;

namespace Richfit.Garnet.Module.Base.Domain.Specifications;

/// <summary>
/// Represents the base class for specifications.
/// </summary>
/// <typeparam name="T">The type of the object to which the specification is applied.</typeparam>
public abstract class Specification<T> : ISpecification<T>
{
	/// <summary>
	/// Evaluates a LINQ expression to its corresponding specification.
	/// </summary>
	/// <param name="expression">The LINQ expression to be evaluated.</param>
	/// <returns>The specification which represents the same semantics as the given LINQ expression.</returns>
	public static Specification<T> Eval(Expression<Func<T, bool>> expression)
	{
		return new ExpressionSpecification<T>(expression);
	}

	/// <summary>
	///  And operator
	/// </summary>
	/// <param name="leftSideSpecification">left operand in this AND operation</param>
	/// <param name="rightSideSpecification">right operand in this AND operation</param>
	/// <returns>New specification</returns>
	public static Specification<T>operator &(Specification<T> leftSideSpecification, Specification<T> rightSideSpecification)
	{
		return new AndSpecification<T>(leftSideSpecification, rightSideSpecification);
	}

	/// <summary>
	/// Or operator
	/// </summary>
	/// <param name="leftSideSpecification">left operand in this OR operation</param>
	/// <param name="rightSideSpecification">left operand in this OR operation</param>
	/// <returns>New specification </returns>
	public static Specification<T>operator |(Specification<T> leftSideSpecification, Specification<T> rightSideSpecification)
	{
		return new OrSpecification<T>(leftSideSpecification, rightSideSpecification);
	}

	/// <summary>
	/// Not specification
	/// </summary>
	/// <param name="specification">Specification to negate</param>
	/// <returns>New specification</returns>
	public static Specification<T>operator !(Specification<T> specification)
	{
		return new NotSpecification<T>(specification);
	}

	/// <summary>
	/// And Not specification
	/// </summary>
	/// <param name="leftSideSpecification"></param>
	/// <param name="rightSideSpecification"></param>
	/// <returns></returns>
	public static Specification<T>operator ^(Specification<T> leftSideSpecification, Specification<T> rightSideSpecification)
	{
		return new AndNotSpecification<T>(leftSideSpecification, rightSideSpecification);
	}

	/// <summary>
	/// Override operator false, only for support AND OR operators
	/// </summary>
	/// <param name="specification">Specification instance</param>
	/// <returns>See False operator in C#</returns>
	public static bool operator false(Specification<T> specification)
	{
		return false;
	}

	/// <summary>
	/// Override operator True, only for support AND OR operators
	/// </summary>
	/// <param name="specification">Specification instance</param>
	/// <returns>See True operator in C#</returns>
	public static bool operator true(Specification<T> specification)
	{
		return false;
	}

	/// <summary>
	/// Combines the current specification instance with another specification instance
	/// and returns the combined specification which represents that both the current and
	/// the given specification must be satisfied by the given object.
	/// </summary>
	/// <param name="other">The specification instance with which the current specification
	/// is combined.</param>
	/// <returns>The combined specification instance.</returns>
	public ISpecification<T> And(ISpecification<T> other)
	{
		return new AndSpecification<T>(this, other);
	}

	/// <summary>
	/// Combines the current specification instance with another specification instance
	/// and returns the combined specification which represents that either the current or
	/// the given specification should be satisfied by the given object.
	/// </summary>
	/// <param name="other">The specification instance with which the current specification
	/// is combined.</param>
	/// <returns>The combined specification instance.</returns>
	public ISpecification<T> Or(ISpecification<T> other)
	{
		return new OrSpecification<T>(this, other);
	}

	/// <summary>
	/// Combines the current specification instance with another specification instance
	/// and returns the combined specification which represents that the current specification
	/// should be satisfied by the given object but the specified specification should not.
	/// </summary>
	/// <param name="other">The specification instance with which the current specification
	/// is combined.</param>
	/// <returns>The combined specification instance.</returns>
	public ISpecification<T> AndNot(ISpecification<T> other)
	{
		return new AndNotSpecification<T>(this, other);
	}

	/// <summary>
	/// Reverses the current specification instance and returns a specification which represents
	/// the semantics opposite to the current specification.
	/// </summary>
	/// <returns>The reversed specification instance.</returns>
	public ISpecification<T> Not()
	{
		return new NotSpecification<T>(this);
	}

	/// <summary>
	/// Gets the LINQ expression which represents the current specification.
	/// </summary>
	/// <returns>The LINQ expression.</returns>
	public abstract Expression<Func<T, bool>> GetExpression();
}
