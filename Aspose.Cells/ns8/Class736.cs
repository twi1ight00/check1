using System.IO;
using System.Runtime.CompilerServices;
using Aspose.Cells.Drawing;

namespace ns8;

internal class Class736
{
	private Stream stream_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private PlacementType placementType_0 = PlacementType.MoveAndSize;

	private bool bool_0 = true;

	private bool bool_1 = true;

	public int Left
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

	public int Top
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

	public int Width
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public int Height
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	public PlacementType Placement
	{
		get
		{
			return placementType_0;
		}
		set
		{
			placementType_0 = value;
		}
	}

	public bool IsLocked
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

	public bool IsPrintable
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

	[SpecialName]
	public string method_0()
	{
		return string_2;
	}

	[SpecialName]
	public void method_1(string string_3)
	{
		string_2 = string_3;
	}

	[SpecialName]
	public Stream method_2()
	{
		return stream_0;
	}

	[SpecialName]
	public void method_3(Stream stream_1)
	{
		stream_0 = stream_1;
	}

	[SpecialName]
	public string method_4()
	{
		return string_0;
	}

	[SpecialName]
	public void method_5(string string_3)
	{
		string_0 = string_3;
	}

	[SpecialName]
	public string method_6()
	{
		return string_1;
	}

	[SpecialName]
	public void method_7(string string_3)
	{
		string_1 = string_3;
	}
}
