using Aspose.XfaConverter.Elements;
using ns215;

namespace ns216;

internal class Class5791 : Class5783
{
	private bool bool_1;

	internal static string Tag => "break";

	internal string AfterTarget => (string)method_5("afterTarget").Value;

	internal XfaEnums.Enum688 After => (XfaEnums.Enum688)method_5("after").Value;

	internal XfaEnums.Enum688 Before
	{
		get
		{
			return (XfaEnums.Enum688)method_5("before").Value;
		}
		set
		{
			method_5("before").Value = value;
		}
	}

	internal string BeforeTarget
	{
		get
		{
			return (string)method_5("beforeTarget").Value;
		}
		set
		{
			method_5("beforeTarget").Value = value;
		}
	}

	internal bool Processed
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

	public Class5791()
	{
		Class5906.smethod_6(this, "after", XfaEnums.Enum688.const_0);
		Class5906.smethod_6(this, "before", XfaEnums.Enum688.const_0);
		Class5906.smethod_4(this, "afterTarget", string.Empty);
		Class5906.smethod_4(this, "beforeTarget", string.Empty);
		Class5906.smethod_4(this, "bookendLeader", string.Empty);
		Class5906.smethod_4(this, "bookendTrailer", string.Empty);
		Class5906.smethod_4(this, "overflowLeader", string.Empty);
		Class5906.smethod_4(this, "overflowTarget", string.Empty);
		Class5906.smethod_4(this, "overflowTrailer", string.Empty);
		Class5906.smethod_3(this, "startNew", @default: false);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_16(this);
		base.vmethod_4(visitor);
		visitor.vmethod_17(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5791();
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
