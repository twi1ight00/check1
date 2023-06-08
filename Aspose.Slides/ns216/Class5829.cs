using ns215;

namespace ns216;

internal class Class5829 : Class5783
{
	internal static string Tag => "margin";

	public float BottomInset => (float)method_5("bottomInset").Value;

	public float LeftInset => (float)method_5("leftInset").Value;

	public float RightInset => (float)method_5("rightInset").Value;

	public float TopInset => (float)method_5("topInset").Value;

	public Class5829()
	{
		Class5906.smethod_1(this, "bottomInset", 0f);
		Class5906.smethod_1(this, "leftInset", 0f);
		Class5906.smethod_1(this, "rightInset", 0f);
		Class5906.smethod_1(this, "topInset", 0f);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_106(this);
		base.vmethod_4(visitor);
		visitor.vmethod_107(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5829();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[1] { Class5816.Tag };
	}
}
