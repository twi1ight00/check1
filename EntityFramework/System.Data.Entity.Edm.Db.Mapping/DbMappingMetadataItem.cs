using System.Collections.Generic;
using System.Data.Entity.Edm.Common;
using System.Data.Entity.Edm.Internal;

namespace System.Data.Entity.Edm.Db.Mapping;

/// <summary>
///     DbMappingMetadataItem is the base for all types in the EDM-to-Database Mapping construction and modification API that support annotation using <see cref="T:System.Data.Entity.Edm.Common.DataModelAnnotation" /> .
/// </summary>
internal abstract class DbMappingMetadataItem : DbMappingModelItem, IAnnotatedDataModelItem
{
	private readonly BackingList<DataModelAnnotation> annotationsList = new BackingList<DataModelAnnotation>();

	IList<DataModelAnnotation> IAnnotatedDataModelItem.Annotations
	{
		get
		{
			return Annotations;
		}
		set
		{
			Annotations = value;
		}
	}

	/// <summary>
	///     Gets or sets the currently assigned annotations.
	/// </summary>
	internal virtual IList<DataModelAnnotation> Annotations
	{
		get
		{
			return annotationsList.EnsureValue();
		}
		set
		{
			annotationsList.SetValue(value);
		}
	}
}
