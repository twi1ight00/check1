using System.Text;

namespace ns196;

internal class Class5338 : Class5337
{
	public Class5338(int width, Class5254 pos, bool auxiliary)
		: base(width, pos, auxiliary)
	{
	}

	public override bool vmethod_0()
	{
		return true;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(64);
		if (method_3())
		{
			stringBuilder.Append("aux. ");
		}
		stringBuilder.Append("box");
		stringBuilder.Append(" w=");
		stringBuilder.Append(method_4());
		return stringBuilder.ToString();
	}
}
