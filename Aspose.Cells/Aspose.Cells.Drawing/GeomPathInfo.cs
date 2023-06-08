using System.Collections;
using ns21;

namespace Aspose.Cells.Drawing;

public class GeomPathInfo
{
	internal bool bool_0;

	internal Enum131 enum131_0 = Enum131.const_5;

	internal bool bool_1 = true;

	internal long long_0;

	internal long long_1;

	private ArrayList arrayList_0;

	public ArrayList PathSegementList => arrayList_0;

	internal int Length
	{
		get
		{
			int num = 2 * PathSegementList.Count;
			if (enum131_0 == Enum131.const_4)
			{
				num += 2;
			}
			if (!bool_1)
			{
				num += 2;
			}
			return num;
		}
	}

	public GeomPathInfo()
	{
		arrayList_0 = new ArrayList();
	}

	public void AddSegment(MsoPathInfo segment)
	{
		arrayList_0.Add(segment);
	}
}
