namespace System.Data.Entity.Edm;

/// <summary>
///     Indicates which Entity Data Model (EDM) concept is represented by a given item.
/// </summary>
internal enum EdmItemKind
{
	/// <summary>
	///     Association End Kind
	/// </summary>
	AssociationEnd,
	/// <summary>
	///     Association Set Kind
	/// </summary>
	AssociationSet,
	/// <summary>
	///     Association Type Kind
	/// </summary>
	AssociationType,
	/// <summary>
	///     Collection Type Kind
	/// </summary>
	CollectionType,
	/// <summary>
	///     Complex Type Kind
	/// </summary>
	ComplexType,
	/// <summary>
	///     Entity Container Kind
	/// </summary>
	EntityContainer,
	/// <summary>
	///     Entity Set Kind
	/// </summary>
	EntitySet,
	/// <summary>
	///     Entity Type Kind
	/// </summary>
	EntityType,
	/// <summary>
	///     Function Group Kind
	/// </summary>
	FunctionGroup,
	/// <summary>
	///     Function Overload Kind
	/// </summary>
	FunctionOverload,
	/// <summary>
	///     Function Import Kind
	/// </summary>
	FunctionImport,
	/// <summary>
	///     Function Parameter Kind
	/// </summary>
	FunctionParameter,
	/// <summary>
	///     Navigation Property Kind
	/// </summary>
	NavigationProperty,
	/// <summary>
	///     EdmProperty Type Kind
	/// </summary>
	Property,
	/// <summary>
	///     Association Constraint Type Kind
	/// </summary>
	AssociationConstraint,
	/// <summary>
	///     Ref Type Kind
	/// </summary>
	RefType,
	/// <summary>
	///     Row Column Kind
	/// </summary>
	RowColumn,
	/// <summary>
	///     Row Type Kind
	/// </summary>
	RowType,
	/// <summary>
	///     Type Reference Kind
	/// </summary>
	TypeReference,
	/// <summary>
	///     Model Kind
	/// </summary>
	Model,
	/// <summary>
	///     Namespace Kind
	/// </summary>
	Namespace,
	/// <summary>
	///     Primitive Facets Kind
	/// </summary>
	PrimitiveFacets,
	/// <summary>
	///     Primitive Type Kind
	/// </summary>
	PrimitiveType
}
