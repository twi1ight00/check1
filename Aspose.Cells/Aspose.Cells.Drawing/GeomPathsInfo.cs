using System.Collections;
using System.Drawing;
using ns52;

namespace Aspose.Cells.Drawing;

public class GeomPathsInfo
{
	private Shape shape_0;

	private ArrayList arrayList_0;

	internal long long_0;

	internal long long_1;

	internal bool bool_0 = true;

	public ArrayList PathList
	{
		get
		{
			if (arrayList_0 == null)
			{
				arrayList_0 = shape_0.method_27().method_10();
				if (arrayList_0 == null)
				{
					arrayList_0 = new ArrayList();
				}
				else
				{
					method_2();
				}
			}
			return arrayList_0;
		}
	}

	internal int Length
	{
		get
		{
			int num = 0;
			for (int i = 0; i < PathList.Count; i++)
			{
				num += ((GeomPathInfo)PathList[i]).Length;
			}
			return num;
		}
	}

	internal GeomPathsInfo(Shape shape_1)
	{
		shape_0 = shape_1;
		Class1136 @class = shape_0.method_27().method_2()[323];
		if (@class != null)
		{
			long_0 = (int)@class.method_4();
		}
		Class1136 class2 = shape_0.method_27().method_2()[322];
		if (class2 != null)
		{
			long_1 = (int)class2.method_4();
		}
	}

	internal ArrayList method_0()
	{
		return arrayList_0;
	}

	internal void method_1()
	{
		long_0 = 0L;
		long_1 = 0L;
		if (arrayList_0 == null)
		{
			return;
		}
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			GeomPathInfo geomPathInfo = (GeomPathInfo)arrayList_0[i];
			for (int j = 0; j < geomPathInfo.PathSegementList.Count; j++)
			{
				MsoPathInfo msoPathInfo = (MsoPathInfo)geomPathInfo.PathSegementList[j];
				ArrayList pointList = msoPathInfo.PointList;
				if (pointList.Count <= 0)
				{
					continue;
				}
				for (int k = 0; k < pointList.Count; k++)
				{
					Point point = (Point)pointList[k];
					if (point.X > 65535 || point.X < 0 || point.Y > 65535 || point.Y < 0)
					{
						bool_0 = false;
					}
					if (point.X > long_1)
					{
						long_1 = point.X;
					}
					if (point.Y > long_0)
					{
						long_0 = point.Y;
					}
					if (point.X > geomPathInfo.long_1)
					{
						geomPathInfo.long_1 = point.X;
					}
					if (point.Y > geomPathInfo.long_0)
					{
						geomPathInfo.long_0 = point.Y;
					}
				}
			}
		}
	}

	internal void method_2()
	{
		if (arrayList_0 != null && arrayList_0.Count != 0)
		{
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				GeomPathInfo geomPathInfo = (GeomPathInfo)arrayList_0[i];
				geomPathInfo.long_1 = long_1;
				geomPathInfo.long_0 = long_0;
			}
		}
	}
}
