using System.Collections.Generic;

namespace System.Data.Entity.Edm.Common;

/// <summary>
///     IAnnotatedDataModelItem is implemented by model-specific base types for all types with an <see cref="P:System.Data.Entity.Edm.Common.IAnnotatedDataModelItem.Annotations" /> property. <seealso cref="T:System.Data.Entity.Edm.EdmDataModelItem" />
/// </summary>
internal interface IAnnotatedDataModelItem
{
	/// <summary>
	///     Gets or sets the currently assigned annotations.
	/// </summary>
	IList<DataModelAnnotation> Annotations { get; set; }
}
