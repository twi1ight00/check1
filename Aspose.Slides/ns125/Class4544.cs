using System.Text;
using System.Text.RegularExpressions;
using ns122;

namespace ns125;

internal class Class4544 : Class4520
{
	private string string_0;

	private StringBuilder stringBuilder_0;

	private static Regex regex_0 = new Regex("[a-zA-Z]", RegexOptions.Compiled);

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

	public Class4544(Class4520 parent, byte[] file)
		: base(parent, file)
	{
		byte_1 = new byte[0][];
		byte_0 = new byte[1][] { Encoding.ASCII.GetBytes(" ") };
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
		if (regex_0.IsMatch(Encoding.ASCII.GetString(new byte[1] { byte_2[startPosition] })))
		{
			bodyStartPosition = startPosition;
			matchedMarker = new byte[0];
			return true;
		}
		return base.vmethod_2(startPosition, out matchedMarker, out bodyStartPosition);
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
