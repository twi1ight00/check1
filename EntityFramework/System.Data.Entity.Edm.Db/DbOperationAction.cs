namespace System.Data.Entity.Edm.Db;

/// <summary>
///     Specifies the action to take on a given operation.
/// </summary>
internal enum DbOperationAction
{
	/// <summary>
	///     Default behavior
	/// </summary>
	None,
	/// <summary>
	///     Restrict the operation
	/// </summary>
	Restrict,
	/// <summary>
	///     Cascade the operation
	/// </summary>
	Cascade
}
