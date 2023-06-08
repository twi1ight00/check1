using System.Collections.Generic;
using System.Data.Entity.Edm.Common;
using System.Data.Entity.Edm.Internal;

namespace System.Data.Entity.Edm;

/// <summary>
///     The base for all all Entity Data Model (EDM) types that support annotation using <see cref="T:System.Data.Entity.Edm.Common.DataModelAnnotation" /> .
/// </summary>
internal abstract class EdmMetadataItem : EdmDataModelItem, IAnnotatedDataModelItem
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

	/// <summary>
	///     Returns all EdmItem children directly contained by this EdmItem.
	/// </summary>
	public virtual IEnumerable<EdmMetadataItem> ChildItems => GetChildItems();

	protected abstract IEnumerable<EdmMetadataItem> GetChildItems();

	internal static IEnumerable<EdmMetadataItem> Yield(params EdmMetadataItem[] items)
	{
		return items;
	}
}
