using System;
using System.Drawing;
using System.Globalization;
using ns178;

namespace ns179;

internal class Class5350 : Class5349
{
	private int int_0 = -1;

	private PointF pointF_0;

	public Class5350(string id)
		: this(id, -1, PointF.Empty)
	{
	}

	public Class5350(string id, int pageIndex, PointF targetLocation)
	{
		method_0(id);
		if (pageIndex < 0 && !targetLocation.IsEmpty)
		{
			throw new ArgumentException("Page index may not be null if target location is known!");
		}
		method_6(pageIndex);
		method_9(targetLocation);
	}

	public void method_6(int pageIndex)
	{
		int_0 = pageIndex;
	}

	public int method_7()
	{
		if (int_0 >= 0)
		{
			return int_0;
		}
		return 0;
	}

	public PointF method_8()
	{
		return pointF_0;
	}

	public void method_9(PointF location)
	{
		pointF_0 = location;
	}

	private bool method_10()
	{
		return method_7() >= 0;
	}

	public bool method_11()
	{
		return method_10();
	}

	public override bool vmethod_0(Class5349 other)
	{
		if (other == null)
		{
			throw new NullReferenceException("other must not be null");
		}
		Class5350 @class = other as Class5350;
		if (other == null)
		{
			return false;
		}
		if (int_0 != @class.int_0)
		{
			return false;
		}
		if (!method_8().Equals(@class.method_8()))
		{
			return false;
		}
		return true;
	}

	public override void imethod_0(Interface153 handler)
	{
		Class5699 @class = new Class5699();
		if (method_10())
		{
			PointF pointF = method_8();
			@class.method_1(null, "id", "id", "CDATA", method_1());
			@class.method_1(null, "page-index", "page-index", "CDATA", int_0.ToString());
			@class.method_1(null, "x", "x", "CDATA", pointF.X.ToString(CultureInfo.InvariantCulture));
			@class.method_1(null, "y", "y", "CDATA", pointF.Y.ToString(CultureInfo.InvariantCulture));
		}
		else
		{
			@class.method_1(null, "idref", "idref", "CDATA", method_1());
		}
		handler.imethod_6(Class5355.class5619_4.method_0(), Class5355.class5619_4.method_2(), Class5355.class5619_4.method_3(), @class);
		handler.imethod_7(Class5355.class5619_4.method_0(), Class5355.class5619_4.method_2(), Class5355.class5619_4.method_3());
	}

	public string method_12()
	{
		return string.Concat("GoToXY: ID=", method_1(), ", page=", method_7(), ", loc=", method_8(), ", ", method_11() ? "complete" : "INCOMPLETE");
	}
}
