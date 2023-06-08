using System;
using System.Data;
using System.Data.Common;
using System.Security;
using System.Security.Permissions;
using System.Text;

namespace Oracle.DataAccess.Client;

[Serializable]
public sealed class OraclePermission : DBDataPermission
{
	static OraclePermission()
	{
	}

	private OraclePermission(OraclePermission permission)
		: base(permission)
	{
	}

	internal OraclePermission(OraclePermissionAttribute attrib)
		: base(attrib)
	{
	}

	public OraclePermission(PermissionState state)
		: base(state)
	{
	}

	public sealed override IPermission Copy()
	{
		return new OraclePermission(this);
	}

	public override bool IsSubsetOf(IPermission target)
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OraclePermission::IsSubsetOf()\n");
		}
		bool flag = false;
		if (target is OraclePermission)
		{
			OraclePermission oraclePermission = target as OraclePermission;
			bool allowBlankPassword = base.AllowBlankPassword;
			bool allowBlankPassword2 = oraclePermission.AllowBlankPassword;
			base.AllowBlankPassword = false;
			oraclePermission.AllowBlankPassword = false;
			flag = base.IsSubsetOf(target);
			base.AllowBlankPassword = allowBlankPassword;
			oraclePermission.AllowBlankPassword = allowBlankPassword2;
		}
		else
		{
			flag = base.IsSubsetOf(target);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OraclePermission::IsSubsetOf()\n");
		}
		return flag;
	}

	internal new void Clear()
	{
		base.Clear();
	}

	private string EliminatePasswordValue(string conString)
	{
		string value = "password";
		string value2 = "proxy password";
		string[] array = conString.Split(';');
		StringBuilder stringBuilder = new StringBuilder();
		string text = null;
		for (int i = 0; i < array.Length; i++)
		{
			text = array[i];
			string text2 = text.ToLower();
			if (text2.IndexOf(value) == -1 && text2.IndexOf(value2) == -1)
			{
				stringBuilder.Append(text);
			}
			else
			{
				string[] array2 = text.Split('=');
				string text3 = array2[0].Trim();
				string text4 = text3.ToLower();
				if (text4.Equals(value) || text4.Equals(value2))
				{
					stringBuilder.Append(text3);
					stringBuilder.Append("=");
				}
				else
				{
					stringBuilder.Append(text);
				}
			}
			if (i < array.Length - 1)
			{
				stringBuilder.Append(";");
			}
		}
		return stringBuilder.ToString();
	}

	public override void Add(string connStr, string keyRestrict, KeyRestrictionBehavior behavior)
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OraclePermission::Add()\n");
		}
		string connectionString = connStr;
		if (connStr != null && connStr.Length != 0 && connStr.ToLower().IndexOf("password") != -1)
		{
			connectionString = EliminatePasswordValue(connStr);
		}
		base.Add(connectionString, keyRestrict, behavior);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) OraclePermission::Add()\n");
		}
	}
}
