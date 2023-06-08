using System;
using System.Data;
using Quartz.Impl.AdoJobStore.Common;

namespace Quartz.Impl.AdoJobStore;

/// <summary>
/// Common helper methods for working with ADO.NET.
/// </summary>
/// <author>Marko Lahma</author>
public class AdoUtil
{
	private readonly IDbProvider dbProvider;

	public AdoUtil(IDbProvider dbProvider)
	{
		this.dbProvider = dbProvider;
	}

	public void AddCommandParameter(IDbCommand cmd, string paramName, object paramValue)
	{
		AddCommandParameter(cmd, paramName, paramValue, null);
	}

	public void AddCommandParameter(IDbCommand cmd, string paramName, object paramValue, Enum dataType)
	{
		IDbDataParameter param = cmd.CreateParameter();
		if (dataType != null)
		{
			SetDataTypeToCommandParameter(param, dataType);
		}
		param.ParameterName = dbProvider.Metadata.GetParameterName(paramName);
		param.Value = paramValue ?? DBNull.Value;
		cmd.Parameters.Add(param);
		if (!dbProvider.Metadata.BindByName)
		{
			cmd.CommandText = cmd.CommandText.Replace("@" + paramName, dbProvider.Metadata.ParameterNamePrefix);
		}
		else if (dbProvider.Metadata.ParameterNamePrefix != "@")
		{
			cmd.CommandText = cmd.CommandText.Replace("@" + paramName, dbProvider.Metadata.ParameterNamePrefix + paramName);
		}
	}

	private void SetDataTypeToCommandParameter(IDbDataParameter param, object parameterType)
	{
		dbProvider.Metadata.ParameterDbTypeProperty.GetSetMethod().Invoke(param, new object[1] { parameterType });
	}

	public IDbCommand PrepareCommand(ConnectionAndTransactionHolder cth, string commandText)
	{
		IDbCommand cmd = dbProvider.CreateCommand();
		cmd.CommandText = commandText;
		cmd.Connection = cth.Connection;
		cmd.Transaction = cth.Transaction;
		return cmd;
	}
}
