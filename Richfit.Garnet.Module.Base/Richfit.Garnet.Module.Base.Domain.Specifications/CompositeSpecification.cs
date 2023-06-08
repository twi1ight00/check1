namespace Richfit.Garnet.Module.Base.Domain.Specifications;

/// <summary>
/// Represents the base class for composite specifications.
/// </summary>
/// <typeparam name="T">The type of the object to which the specification is applied.</typeparam>
public abstract class CompositeSpecification<T> : Specification<T>, ICompositeSpecification<T>, ISpecification<T>
{
	private readonly ISpecification<T> left;

	private readonly ISpecification<T> right;

	/// <summary>
	/// Gets the first specification.
	/// </summary>
	public ISpecification<T> Left => left;

	/// <summary>
	/// Gets the second specification.
	/// </summary>
	public ISpecification<T> Right => right;

	/// <summary>
	/// Constructs a new instance of <c>CompositeSpecification&lt;T&gt;</c> class.
	/// </summary>
	/// <param name="left">The first specification.</param>
	/// <param name="right">The second specification.</param>
	public CompositeSpecification(ISpecification<T> left, ISpecification<T> right)
	{
		this.left = left;
		this.right = right;
	}
}
