using Aspose.Slides;
using ns43;
using ns56;

namespace ns34;

internal class Class736
{
	private NullableBool nullableBool_0 = NullableBool.NotDefined;

	private NullableBool nullableBool_1 = NullableBool.NotDefined;

	private NullableBool nullableBool_2 = NullableBool.NotDefined;

	private NullableBool nullableBool_3 = NullableBool.NotDefined;

	private NullableBool nullableBool_4 = NullableBool.NotDefined;

	private NullableBool nullableBool_5 = NullableBool.NotDefined;

	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	private uint uint_3;

	private bool bool_0;

	private bool bool_1;

	private uint uint_4;

	private Class1393 class1393_0;

	private Class1396 class1396_0;

	private Class1502 class1502_0;

	public uint XfId
	{
		get
		{
			return uint_4;
		}
		set
		{
			uint_4 = value;
		}
	}

	public bool QuotePrefix
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

	public bool PivotButton
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

	public uint NumFmtId
	{
		get
		{
			return uint_3;
		}
		set
		{
			uint_3 = value;
		}
	}

	public uint FontId
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	public uint FillId
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	public uint BorderId
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public NullableBool ApplyProtection
	{
		get
		{
			return nullableBool_5;
		}
		set
		{
			nullableBool_5 = value;
		}
	}

	public NullableBool ApplyNumberFormat
	{
		get
		{
			return nullableBool_4;
		}
		set
		{
			nullableBool_4 = value;
		}
	}

	public NullableBool ApplyFont
	{
		get
		{
			return nullableBool_3;
		}
		set
		{
			nullableBool_3 = value;
		}
	}

	public NullableBool ApplyFill
	{
		get
		{
			return nullableBool_2;
		}
		set
		{
			nullableBool_2 = value;
		}
	}

	public NullableBool ApplyBorder
	{
		get
		{
			return nullableBool_1;
		}
		set
		{
			nullableBool_1 = value;
		}
	}

	public NullableBool ApplyAlignment
	{
		get
		{
			return nullableBool_0;
		}
		set
		{
			nullableBool_0 = value;
		}
	}

	internal Class1393 Alignment
	{
		get
		{
			return class1393_0;
		}
		set
		{
			class1393_0 = value;
		}
	}

	internal Class1396 Protection
	{
		get
		{
			return class1396_0;
		}
		set
		{
			class1396_0 = value;
		}
	}

	internal Class1502 ExtLst
	{
		get
		{
			return class1502_0;
		}
		set
		{
			class1502_0 = value;
		}
	}

	internal void method_0(Class820 xfElement)
	{
		if (xfElement != null)
		{
			nullableBool_0 = xfElement.ApplyAlignment;
			nullableBool_1 = xfElement.ApplyBorder;
			nullableBool_2 = xfElement.ApplyFill;
			nullableBool_3 = xfElement.ApplyFont;
			nullableBool_4 = xfElement.ApplyNuberFormat;
			nullableBool_5 = xfElement.ApplyProtection;
			uint_0 = xfElement.BorderId;
			uint_1 = xfElement.FillId;
			uint_2 = xfElement.FontId;
			uint_3 = xfElement.NumFmtId;
			bool_0 = xfElement.PivotButton;
			bool_1 = xfElement.QuotePrefix;
			uint_4 = xfElement.XfId;
		}
	}

	internal void Save(Class820 xfElement)
	{
		xfElement.ApplyAlignment = nullableBool_0;
		xfElement.ApplyBorder = nullableBool_1;
		xfElement.ApplyFill = nullableBool_2;
		xfElement.ApplyFont = nullableBool_3;
		xfElement.ApplyNuberFormat = nullableBool_4;
		xfElement.ApplyProtection = nullableBool_5;
		xfElement.BorderId = uint_0;
		xfElement.FillId = uint_1;
		xfElement.FontId = uint_2;
		xfElement.NumFmtId = uint_3;
		xfElement.PivotButton = bool_0;
		xfElement.QuotePrefix = bool_1;
		xfElement.XfId = uint_4;
	}
}
