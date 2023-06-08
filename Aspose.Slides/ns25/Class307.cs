using System;
using ns16;
using ns24;
using ns56;

namespace ns25;

internal class Class307 : Class278
{
	private double double_0;

	private Enum267 enum267_0 = Enum267.const_1;

	private bool bool_0 = true;

	private Enum269 enum269_0 = Enum269.const_0;

	private Class1885 class1885_0;

	private Class1885 class1885_1;

	private Class1885 class1885_2;

	private ushort ushort_0 = 100;

	private ushort ushort_1;

	private bool bool_1;

	private Enum268 enum268_0 = Enum268.const_0;

	private int int_0;

	private int int_1;

	public double DisplayUnitCustomValue
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

	public Enum267 CategoryAxisType
	{
		get
		{
			return enum267_0;
		}
		set
		{
			if (value == Enum267.const_0)
			{
				throw new NotImplementedException();
			}
			enum267_0 = value;
		}
	}

	public Class1885 ExtensionList
	{
		get
		{
			return class1885_0;
		}
		set
		{
			class1885_0 = value;
		}
	}

	public Class1885 ExtensionListOfScaling
	{
		get
		{
			return class1885_1;
		}
		set
		{
			class1885_1 = value;
		}
	}

	public Class1885 ExtensionListOfDispUnits
	{
		get
		{
			return class1885_2;
		}
		set
		{
			class1885_2 = value;
		}
	}

	public Enum269 LabelAlignment
	{
		get
		{
			return enum269_0;
		}
		set
		{
			enum269_0 = value;
		}
	}

	public ushort LabelOffset
	{
		get
		{
			return ushort_0;
		}
		set
		{
			ushort_0 = value;
		}
	}

	public ushort TickMarksToSkip
	{
		get
		{
			return ushort_1;
		}
		set
		{
			ushort_1 = value;
		}
	}

	public bool NoMultiLevelLabels
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

	public Enum268 CrossBetween
	{
		get
		{
			return enum268_0;
		}
		set
		{
			enum268_0 = value;
		}
	}

	public int AxisId
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public int CrossAxId
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public bool Auto
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

	private int method_0()
	{
		string text = Guid.NewGuid().ToString();
		int hashCode = text.GetHashCode();
		return Math.Abs(hashCode);
	}

	public Class307()
	{
		int_0 = method_0();
	}
}
