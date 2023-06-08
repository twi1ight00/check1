using System.Collections;

namespace Aspose.Cells;

public class XmlMapCollection : CollectionBase
{
	internal ArrayList arrayList_0;

	internal string string_0;

	internal string string_1;

	public XmlMap this[int index] => (XmlMap)base.InnerList[index];

	internal XmlMapCollection()
	{
		arrayList_0 = new ArrayList();
		string_1 = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
	}

	internal int Add(XmlMap xmlMap_0)
	{
		base.InnerList.Add(xmlMap_0);
		return base.InnerList.Count - 1;
	}
}
