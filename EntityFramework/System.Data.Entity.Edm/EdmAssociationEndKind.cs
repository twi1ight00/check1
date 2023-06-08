namespace System.Data.Entity.Edm;

/// <summary>
///     Indicates the multiplicity of an <see cref="T:System.Data.Entity.Edm.EdmAssociationEnd" /> and whether or not it is required.
/// </summary>
internal enum EdmAssociationEndKind
{
	Optional,
	Required,
	Many
}
