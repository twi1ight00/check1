using System;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public sealed class OracleObjectMappingAttribute : Attribute
{
	internal int m_attrIndex = -1;

	internal string m_attrName = "";

	public int AttributeIndex => m_attrIndex;

	public string AttributeName => m_attrName;

	static OracleObjectMappingAttribute()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public OracleObjectMappingAttribute(int attrIndex)
	{
		m_attrIndex = attrIndex;
	}

	public OracleObjectMappingAttribute(string attrName)
	{
		m_attrName = attrName;
	}
}
