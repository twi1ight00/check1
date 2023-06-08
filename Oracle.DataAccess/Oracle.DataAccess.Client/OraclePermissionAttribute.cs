using System;
using System.Data.Common;
using System.Security;
using System.Security.Permissions;

namespace Oracle.DataAccess.Client;

[Serializable]
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
public sealed class OraclePermissionAttribute : DBDataPermissionAttribute
{
	static OraclePermissionAttribute()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public OraclePermissionAttribute(SecurityAction action)
		: base(action)
	{
	}

	public override IPermission CreatePermission()
	{
		return new OraclePermission(this);
	}
}
