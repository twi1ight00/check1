using System.Text;
using ns122;
using ns127;

namespace ns125;

internal class Class4549 : Class4520
{
	private string string_0;

	private StringBuilder stringBuilder_0;

	private int int_1;

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

	public Class4549(Class4520 parent, byte[] file)
		: base(parent, file)
	{
		base.SupportImmediateClosing = true;
		byte_1 = new byte[1][] { Encoding.ASCII.GetBytes("(") };
		byte_0 = new byte[0][];
		stringBuilder_0 = new StringBuilder();
	}

	public override void vmethod_1()
	{
		string_0 = null;
		int_1 = 0;
		stringBuilder_0 = new StringBuilder();
		base.vmethod_1();
	}

	protected override byte[] vmethod_3(int currentPosition, out int endPosition)
	{
		endPosition = -1;
		byte[] bytes = Encoding.ASCII.GetBytes(")");
		if (Class4554.smethod_4(byte_2, currentPosition, bytes) && int_1 == 0)
		{
			endPosition = currentPosition;
			return bytes;
		}
		return null;
	}

	protected override void vmethod_6(int currentPosition)
	{
		if (byte_2[currentPosition] == 40)
		{
			int_1++;
		}
		else if (byte_2[currentPosition] == 41)
		{
			int_1--;
		}
		stringBuilder_0.Append(Encoding.ASCII.GetString(new byte[1] { byte_2[currentPosition] }));
		base.vmethod_6(currentPosition);
	}

	protected override void vmethod_5()
	{
		string_0 = stringBuilder_0.ToString();
		base.vmethod_5();
	}
}
