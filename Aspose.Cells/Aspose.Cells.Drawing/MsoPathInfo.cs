using System.Collections;

namespace Aspose.Cells.Drawing;

public class MsoPathInfo
{
	private MsoPathType msoPathType_0;

	private ArrayList arrayList_0;

	public MsoPathType Type => msoPathType_0;

	public ArrayList PointList => arrayList_0;

	public MsoPathInfo(MsoPathType type)
	{
		msoPathType_0 = type;
		arrayList_0 = new ArrayList(4);
	}

	public MsoPathInfo(MsoPathType type, ArrayList pointList)
	{
		msoPathType_0 = type;
		if (pointList != null)
		{
			arrayList_0 = (ArrayList)pointList.Clone();
		}
		else
		{
			arrayList_0 = new ArrayList(4);
		}
	}
}
