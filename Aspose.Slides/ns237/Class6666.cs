using System.IO;

namespace ns237;

internal class Class6666 : Class6662
{
	private const int int_0 = 1;

	private const int int_1 = 1;

	private const int int_2 = 8;

	private const string string_0 = "/DecodeParms";

	private const string string_1 = "/Predictor";

	private const string string_2 = "/Colors";

	private const string string_3 = "/BitsPerComponent";

	private const string string_4 = "/Columns";

	private Enum886 enum886_0 = Enum886.const_2;

	private int int_3 = 1;

	private bool bool_0;

	private int int_4 = 1;

	private bool bool_1;

	private int int_5 = 8;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	internal int Colors
	{
		get
		{
			return int_3;
		}
		set
		{
			if (value != 1)
			{
				int_3 = value;
				bool_0 = true;
			}
		}
	}

	internal int Columns
	{
		get
		{
			return int_4;
		}
		set
		{
			if (value != 1)
			{
				int_4 = value;
				bool_1 = true;
			}
		}
	}

	internal int BitsPerComponent
	{
		get
		{
			return int_5;
		}
		set
		{
			if (value != 8)
			{
				int_5 = value;
				bool_2 = true;
			}
		}
	}

	public bool IsBaselinePredictor
	{
		set
		{
			bool_3 = value;
			bool_4 = true;
		}
	}

	internal override Stream vmethod_0(Stream outputStream)
	{
		method_0();
		if (enum886_0 != Enum886.const_0)
		{
			return new Stream5(outputStream, enum886_0, int_3, int_4, int_5);
		}
		return new Stream5(outputStream);
	}

	internal override void vmethod_1(Class6679 writer)
	{
		method_0();
		writer.method_8("/Filter", "/LZWDecode");
		if (enum886_0 != Enum886.const_0)
		{
			writer.Write("/DecodeParms");
			writer.method_6();
			writer.method_18("/Predictor", (int)enum886_0);
			if (bool_0)
			{
				writer.method_18("/Colors", int_3);
			}
			if (bool_1)
			{
				writer.method_18("/Columns", int_4);
			}
			if (bool_2)
			{
				writer.method_18("/BitsPerComponent", int_5);
			}
			writer.method_7();
		}
	}

	private void method_0()
	{
		if (!bool_4 && !bool_0 && !bool_2 && !bool_1)
		{
			return;
		}
		if (bool_3)
		{
			if (int_3 >= 3)
			{
				enum886_0 = Enum886.const_6;
			}
			else
			{
				enum886_0 = Enum886.const_0;
			}
		}
		else if (int_3 >= 3)
		{
			enum886_0 = Enum886.const_7;
		}
		else
		{
			enum886_0 = Enum886.const_0;
		}
	}
}
