namespace System.Data.Entity.Edm.Db;

/// <summary>
///     Indicates which Database Metadata concept is represented by a given item.
/// </summary>
internal enum DbItemKind
{
	/// <summary>
	///     Database Kind
	/// </summary>
	Database,
	/// <summary>
	///     Schema Kind
	/// </summary>
	Schema,
	/// <summary>
	///     Foreign Key Constraint Kind
	/// </summary>
	ForeignKeyConstraint,
	/// <summary>
	///     Function Kind
	/// </summary>
	Function,
	/// <summary>
	///     Function Parameter Kind
	/// </summary>
	FunctionParameter,
	/// <summary>
	///     Function Return or Parameter Type Kind
	/// </summary>
	FunctionType,
	/// <summary>
	///     Row Column Kind
	/// </summary>
	RowColumn,
	/// <summary>
	///     Table Kind
	/// </summary>
	Table,
	/// <summary>
	///     Table Column Kind
	/// </summary>
	TableColumn,
	/// <summary>
	///     Primitive Facets Kind
	/// </summary>
	PrimitiveTypeFacets
}
