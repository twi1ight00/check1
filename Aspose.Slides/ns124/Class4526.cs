using System.Text;
using ns122;
using ns123;

namespace ns124;

internal class Class4526 : Class4521
{
	private string string_0;

	private StringBuilder stringBuilder_0;

	public string String
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Class4526(Class4700 context, Class4521 parent)
		: base(context, parent)
	{
		byte_1 = new byte[1][] { Encoding.ASCII.GetBytes("CC") };
		byte_0 = new byte[3][]
		{
			Encoding.ASCII.GetBytes("\r\n"),
			Encoding.ASCII.GetBytes("\r"),
			Encoding.ASCII.GetBytes("\n")
		};
		base.ChildScanners = new Class4520[0];
	}

	public override void vmethod_1()
	{
		string_0 = null;
		stringBuilder_0 = new StringBuilder();
		base.vmethod_1();
	}

	protected override void vmethod_6(int currentPosition)
	{
		stringBuilder_0.Append(Encoding.ASCII.GetString(new byte[1] { byte_2[currentPosition] }));
		base.vmethod_6(currentPosition);
	}

	public override void imethod_0(object sender)
	{
		base.imethod_0(sender);
	}

	protected override void vmethod_5()
	{
		string_0 = stringBuilder_0.ToString();
		base.vmethod_5();
	}
}
