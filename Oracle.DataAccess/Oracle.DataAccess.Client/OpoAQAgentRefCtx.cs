using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct OpoAQAgentRefCtx
{
	internal string name;

	internal string address;
}
