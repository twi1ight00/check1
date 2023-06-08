using System;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public sealed class OracleArrayMappingAttribute : Attribute
{
	static OracleArrayMappingAttribute()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}
}
