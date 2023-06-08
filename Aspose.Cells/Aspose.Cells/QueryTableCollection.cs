using System.Collections;

namespace Aspose.Cells;

public class QueryTableCollection : CollectionBase
{
	public QueryTable this[int index] => (QueryTable)base.InnerList[index];

	internal QueryTableCollection()
	{
	}

	internal int Add(QueryTable queryTable_0)
	{
		base.InnerList.Add(queryTable_0);
		return base.InnerList.Count - 1;
	}
}
