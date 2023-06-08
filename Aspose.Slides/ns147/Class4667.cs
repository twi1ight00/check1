using ns101;
using ns99;

namespace ns147;

internal class Class4667 : Class4666, Interface120, Interface121, Interface122
{
	private Class4412 class4412_0;

	private object object_1 = new object();

	private bool bool_2 = true;

	private Class4676 class4676_1;

	private Class4666 class4666_0;

	internal override Class4676 Offsets
	{
		get
		{
			method_3();
			return class4676_1;
		}
	}

	internal Class4667(Class4666 originalLocaTable)
		: base(originalLocaTable.Context, 0u, 0u, 0u)
	{
		class4676_1 = new Class4676(originalLocaTable.Offsets.Count);
		for (int i = 0; i < originalLocaTable.Offsets.Count; i++)
		{
			class4676_1.Add(0);
		}
		class4666_0 = originalLocaTable;
	}

	internal void method_2(Class4412 fontSubset)
	{
		class4412_0 = fontSubset;
		fontSubset.UsedGlyphs.class4501_0.Add(this);
		fontSubset.UsedGlyphs.class4500_0.Add(this);
		fontSubset.UsedGlyphs.class4499_0.Add(this);
	}

	private void method_3()
	{
		if (!bool_2)
		{
			return;
		}
		lock (object_1)
		{
			if (!bool_2)
			{
				return;
			}
			uint num = 0u;
			for (int i = 0; i < class4676_1.Count; i++)
			{
				class4676_1[i] = num;
				if (class4412_0.UsedGlyphsIndexes.Contains(i))
				{
					class4676_1[i] = num;
					uint num2 = class4666_0.Offsets[i];
					uint num3 = class4666_0.Offsets[i + 1] - num2;
					num += num3;
				}
			}
			bool_2 = false;
		}
	}

	void Interface122.imethod_0(object sender, EventArgs3 e)
	{
		bool_2 = true;
	}

	void Interface121.imethod_0(object sender)
	{
		bool_2 = true;
	}

	void Interface120.imethod_0(object sender, EventArgs3 e)
	{
		bool_2 = true;
	}
}
