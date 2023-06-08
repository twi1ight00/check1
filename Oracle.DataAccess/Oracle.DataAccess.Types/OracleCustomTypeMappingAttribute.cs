using System;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
public sealed class OracleCustomTypeMappingAttribute : Attribute
{
	internal string m_udtTypeName;

	public string UdtTypeName => m_udtTypeName;

	static OracleCustomTypeMappingAttribute()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public OracleCustomTypeMappingAttribute(string udtTypeName)
	{
		if (udtTypeName == null)
		{
			throw new ArgumentNullException("udtTypeName");
		}
		if (udtTypeName == "")
		{
			throw new ArgumentException();
		}
		m_udtTypeName = udtTypeName;
	}
}
