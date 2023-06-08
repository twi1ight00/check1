using System.Text;

namespace ns120;

internal class Class4517 : Interface131
{
	private StringBuilder stringBuilder_0 = new StringBuilder();

	public string Log => stringBuilder_0.ToString();

	public bool IfDebug => true;

	public bool IfFatal => true;

	public void imethod_0(string debugString)
	{
		stringBuilder_0.AppendFormat("\r\n{0}", debugString);
	}

	public void imethod_1(string fatalString)
	{
		stringBuilder_0.AppendFormat("\r\n{0}", fatalString);
	}
}
