using System.Collections;
using ns139;
using ns145;
using ns152;
using ns99;

namespace ns144;

internal class Class4642
{
	internal Class4641.Enum651 enum651_0;

	internal int int_0;

	internal int int_1;

	internal bool bool_0;

	internal double double_0;

	internal double[] double_1;

	internal Class4707 class4707_0 = new Class4707();

	internal Hashtable hashtable_0 = new Hashtable();

	internal Class4644 class4644_0;

	internal Class4644 class4644_1;

	internal Class4647 class4647_0;

	internal Class4647 class4647_1;

	internal Class4644 class4644_2;

	internal double double_2;

	internal double double_3;

	internal bool bool_1;

	internal int int_2;

	internal int int_3;

	internal int int_4;

	internal int int_5;

	internal Class4643 class4643_0;

	internal Class4643 class4643_1;

	internal Class4643 class4643_2;

	internal Class4643 class4643_3;

	internal Class4643 class4643_4;

	public Class4642()
	{
		double_1 = new double[4];
		for (int i = 0; i < 4; i++)
		{
			double_1[i] = 0.0;
		}
		class4644_0 = new Class4644();
		class4644_0.method_1(1.0, 0.0);
		class4644_1 = new Class4644();
		class4644_1.method_1(1.0, 0.0);
		class4644_2 = new Class4644();
		class4644_2.method_1(1.0, 0.0);
		class4647_0 = new Class4650();
		class4647_1 = new Class4650();
		double_2 = 0.0;
		double_3 = 0.0;
		bool_1 = true;
		int_2 = 1;
		int_1 = 1;
		enum651_0 = Class4641.Enum651.const_1;
	}

	public void method_0(Class4480 glyph)
	{
		class4643_1 = new Class4643((Class4616)glyph.PathDefinition);
		class4643_0 = class4643_1;
		class4643_2 = class4643_1;
		class4643_3 = class4643_1;
		class4643_4 = class4643_1;
	}
}
