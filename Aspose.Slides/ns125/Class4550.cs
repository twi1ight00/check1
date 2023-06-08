using System.Text;
using ns122;

namespace ns125;

internal class Class4550 : Class4520
{
	private string string_0;

	private StringBuilder stringBuilder_0;

	public string Name
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

	public Class4550(Class4520 parent, byte[] file)
		: base(parent, file)
	{
		byte_1 = new byte[0][];
		byte_0 = new byte[5][]
		{
			Encoding.ASCII.GetBytes(" "),
			Encoding.ASCII.GetBytes("{"),
			Encoding.ASCII.GetBytes("["),
			Encoding.ASCII.GetBytes("\r"),
			Encoding.ASCII.GetBytes("\n")
		};
		stringBuilder_0 = new StringBuilder();
	}

	public override void vmethod_1()
	{
		string_0 = null;
		stringBuilder_0 = new StringBuilder();
		base.vmethod_1();
	}

	protected override bool vmethod_2(int startPosition, out byte[] matchedMarker, out int bodyStartPosition)
	{
		bodyStartPosition = startPosition;
		matchedMarker = new byte[0];
		return true;
	}

	protected override byte[] vmethod_3(int currentPosition, out int endPosition)
	{
		byte[] array = base.vmethod_3(currentPosition, out endPosition);
		if (array != null && byte_2[endPosition] != Encoding.ASCII.GetBytes(" ")[0] && byte_2[endPosition] != Encoding.ASCII.GetBytes("\r")[0] && byte_2[endPosition] != Encoding.ASCII.GetBytes("\n")[0])
		{
			endPosition = currentPosition - 1;
		}
		return array;
	}

	protected override void vmethod_6(int currentPosition)
	{
		if (byte_2[currentPosition] != 32)
		{
			stringBuilder_0.Append(Encoding.ASCII.GetString(new byte[1] { byte_2[currentPosition] }));
		}
		base.vmethod_6(currentPosition);
	}

	protected override void vmethod_5()
	{
		string_0 = stringBuilder_0.ToString();
		base.IsAllowed = false;
		base.vmethod_5();
	}
}
