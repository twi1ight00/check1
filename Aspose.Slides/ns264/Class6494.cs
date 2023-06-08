namespace ns264;

internal class Class6494 : Interface318
{
	private Class6503[] class6503_0;

	private int int_0;

	public int Handle
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

	Enum866 Interface318.Type => Enum866.const_10;

	internal Class6503[] PaletteEntries => class6503_0;

	internal Class6494()
	{
	}

	internal void method_0(Class6498 reader)
	{
		int_0 = reader.ReadInt32();
		reader.ReadInt16();
		int num = reader.ReadInt16();
		class6503_0 = new Class6503[num];
		for (int i = 0; i < num; i++)
		{
			class6503_0[i] = new Class6503(reader.ReadInt32());
		}
	}
}
