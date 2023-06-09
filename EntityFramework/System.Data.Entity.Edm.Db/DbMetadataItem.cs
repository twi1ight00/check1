using System.Collections.Generic;
using System.Data.Entity.Edm.Common;
using System.Data.Entity.Edm.Internal;

namespace System.Data.Entity.Edm.Db;

/// <summary>
///     The base for all all Database Metadata types that support annotation using <see cref="T:System.Data.Entity.Edm.Common.DataModelAnnotation" /> .
/// </summary>
internal abstract class DbMetadataItem : DbDataModelItem, IAnnotatedDataModelItem
{
	private readonly BackingList<DataModelAnnotation> annotationsList = new BackingList<DataModelAnnotation>();

	/// <summary>
	///     Gets or sets the currently assigned annotations.
	/// </summary>
	public virtual IList<DataModelAnnotation> Annotations
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

	internal bool HasAnnotations => annotationsList.HasValue;
}
