namespace System.Data.Entity.Edm.Common;

/// <summary>
///     INamedDataModelItem is implemented by model-specific base types for all types with a <see cref="P:System.Data.Entity.Edm.Common.INamedDataModelItem.Name" /> property. <seealso cref="T:System.Data.Entity.Edm.EdmNamedMetadataItem" />
/// </summary>
internal interface INamedDataModelItem
{
	/// <summary>
	///     Gets or sets the currently assigned name.
	/// </summary>
	string Name { get; set; }
}
