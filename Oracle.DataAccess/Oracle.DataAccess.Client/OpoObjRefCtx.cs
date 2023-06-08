using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal class OpoObjRefCtx
{
	public string xmlStr;

	public string hexStr;

	public string attrname;

	public string objTableName;

	public string schemaName;

	public OpoObjRefCtx()
	{
		xmlStr = null;
		hexStr = null;
		attrname = null;
		objTableName = null;
	}
}
