namespace System.Data.Entity.Edm;

/// <summary>
///     Specifies the action to take on a given operation. <seealso cref="P:System.Data.Entity.Edm.EdmAssociationEnd.DeleteAction" />
/// </summary>
internal enum EdmOperationAction
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
