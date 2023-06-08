using System.Text;
using ns178;

namespace ns194;

internal class Class5777 : Class5174.Interface166
{
	public void imethod_0(StringBuilder sb, object obj)
	{
		Interface243 @interface = (Interface243)obj;
		sb.Append(@interface.imethod_0()).Append(":").Append(@interface.imethod_1());
	}

	public bool imethod_1(object obj)
	{
		return obj is Interface243;
	}
}
