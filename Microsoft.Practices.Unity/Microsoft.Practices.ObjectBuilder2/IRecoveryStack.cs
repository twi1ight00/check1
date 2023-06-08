namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// Data structure that stores the set of <see cref="T:Microsoft.Practices.ObjectBuilder2.IRequiresRecovery" />
/// objects and executes them when requested.
/// </summary>
public interface IRecoveryStack
{
	/// <summary>
	/// Return the number of recovery objects currently in the stack.
	/// </summary>
	int Count { get; }

	/// <summary>
	/// Add a new <see cref="T:Microsoft.Practices.ObjectBuilder2.IRequiresRecovery" /> object to this
	/// list.
	/// </summary>
	/// <param name="recovery">Object to add.</param>
	void Add(IRequiresRecovery recovery);

	/// <summary>
	/// Execute the <see cref="M:Microsoft.Practices.ObjectBuilder2.IRequiresRecovery.Recover" /> method
	/// of everything in the recovery list. Recoveries will execute
	/// in the opposite order of add - it's a stack.
	/// </summary>
	void ExecuteRecovery();
}
