using System.Collections.Generic;
using System.Data.Entity.Edm.Common;

namespace System.Data.Entity.Edm.Internal;

internal abstract class DataModelItemVisitor
{
	protected static void VisitCollection<T>(IEnumerable<T> collection, Action<T> visitMethod)
	{
		if (collection == null)
		{
			return;
		}
		foreach (T item in collection)
		{
			visitMethod(item);
		}
	}

	protected virtual void VisitAnnotations(DataModelItem item, IEnumerable<DataModelAnnotation> annotations)
	{
		VisitCollection(annotations, VisitAnnotation);
	}

	protected virtual void VisitAnnotation(DataModelAnnotation item)
	{
	}

	protected virtual void VisitDataModelItem(DataModelItem item)
	{
	}
}
