using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides.Charts;
using ns36;

namespace ns37;

internal class Class752 : Interface15
{
	private Class759 class759_0;

	private double double_0;

	private ErrorBarType errorBarType_0;

	private IList ilist_0 = new ArrayList();

	private IList ilist_1 = new ArrayList();

	private ErrorBarValueType errorBarValueType_0;

	private bool bool_0;

	private bool bool_1 = true;

	private bool bool_2;

	private Class755 class755_0;

	internal IList<Struct19> ilist_2 = new List<Struct19>();

	internal Class755 BorderInternal => class755_0;

	public Interface18 Border => class755_0;

	internal Class759 ParentInternal => class759_0;

	public Interface21 Parent => class759_0;

	public double Amount
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public ErrorBarType DisplayType
	{
		get
		{
			return errorBarType_0;
		}
		set
		{
			errorBarType_0 = value;
		}
	}

	public IList MinusValue
	{
		get
		{
			return ilist_0;
		}
		set
		{
			ilist_0 = value;
		}
	}

	public IList PlusValue
	{
		get
		{
			return ilist_1;
		}
		set
		{
			ilist_1 = value;
		}
	}

	public ErrorBarValueType Type
	{
		get
		{
			return errorBarValueType_0;
		}
		set
		{
			errorBarValueType_0 = value;
		}
	}

	public bool YDirection
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public bool ShowMarkerTTop
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	internal bool IsVisible
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	internal void method_0(PointF originPoint, float minusHeight, float plusHeight)
	{
		Struct19 item = new Struct19(originPoint, minusHeight, plusHeight);
		ilist_2.Add(item);
	}

	public Class752(Class740 chart, Class759 parent)
	{
		class755_0 = new Class755(chart, Enum145.const_18);
		class759_0 = parent;
		double_0 = 0.0;
		errorBarType_0 = ErrorBarType.Both;
		errorBarValueType_0 = ErrorBarValueType.Fixed;
		bool_0 = true;
	}

	public void imethod_0(params object[] vals)
	{
		foreach (object value in vals)
		{
			ilist_0.Add(value);
		}
	}

	public void imethod_1(params object[] vals)
	{
		foreach (object value in vals)
		{
			ilist_1.Add(value);
		}
	}
}
