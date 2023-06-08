using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5849 : Class5783
{
	internal static string Tag => "subformSet";

	public Class5849()
	{
		Class5906.smethod_6(this, "relation", XfaEnums.Enum726.const_0);
		Class5906.smethod_4(this, "relevant", string.Empty);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_156(this);
		base.vmethod_4(visitor);
		visitor.vmethod_157(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5849();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[10]
		{
			Class5860.Tag,
			Class5791.Tag,
			Class5807.Tag,
			Class5816.Tag,
			Class5832.Tag,
			Class5881.Tag,
			Class5792.Tag,
			Class5793.Tag,
			"subform",
			Tag
		};
	}
}
