using System.Text;
using ns122;

namespace ns125;

internal class Class4546 : Class4520
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

	public Class4546(Class4520 parent, byte[] file)
		: base(parent, file)
	{
		base.SupportImmediateClosing = true;
		byte_1 = new byte[1][] { Encoding.ASCII.GetBytes("{") };
		byte_0 = new byte[1][] { Encoding.ASCII.GetBytes("}") };
		stringBuilder_0 = new StringBuilder();
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

	protected override void vmethod_5()
	{
		string_0 = stringBuilder_0.ToString();
		base.vmethod_5();
	}
}
