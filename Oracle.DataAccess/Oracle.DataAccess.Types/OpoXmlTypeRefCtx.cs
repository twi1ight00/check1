using System;
using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Types;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal class OpoXmlTypeRefCtx
{
	public string rootElement;

	public string schemaUrl;

	public IntPtr schema_opsXmlTypeCtx;
}
