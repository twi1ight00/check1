using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Types;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal class OpoDscRefCtx
{
	public string SchemaName;

	public string TypeName;

	public OpoDscRefCtx()
	{
		SchemaName = null;
		TypeName = null;
	}
}
