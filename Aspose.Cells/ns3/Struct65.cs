using System.Runtime.InteropServices;
using ns14;

namespace ns3;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct65
{
	private static readonly string string_0 = "MMM|DD|YYYY|M/|/M|D/|D\\\\|/D|Y/|/Y|-M|M-|-D|D-|-Y|Y-|MM|M/D|D/M|M-D|D-M|^D$|\\[H\\]|H:MM|MM:SS|年|月|日|时|分|秒";

	internal static string smethod_0(Class516 class516_0, object object_0, string string_1)
	{
		if (string_1 != null && string_1 == "")
		{
			string_1 = null;
		}
		Class518 @class = class516_0.Format(string_1, object_0, bool_1: false);
		return @class.method_6(0, bool_1: true);
	}
}
