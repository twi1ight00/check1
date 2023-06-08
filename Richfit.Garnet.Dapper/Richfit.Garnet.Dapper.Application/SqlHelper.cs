using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Oracle.DataAccess.Client;
using Richfit.Garnet.Common.Configuration;

namespace Richfit.Garnet.Dapper.Application;

public static class SqlHelper
{
	public static IDbConnection CrateOracleConnection()
	{
		string connString = ConfigurationManager.System.Database.DefaultConnection.ConnectionString;
		return new OracleConnection(connString);
	}

	public static void Excute(ExcuteSql excuteSql)
	{
		using IDbConnection conn = CrateOracleConnection();
		IDbTransaction transaction = null;
		try
		{
			conn.Open();
			transaction = conn.BeginTransaction();
			excuteSql?.Invoke(conn);
			transaction.Commit();
			conn.Close();
		}
		catch (Exception ex)
		{
			try
			{
				transaction?.Rollback();
				if (conn.State == ConnectionState.Open)
				{
					conn.Close();
				}
			}
			catch (Exception)
			{
			}
			throw ex;
		}
	}

	public static int GetCount(string sql)
	{
		using IDbConnection conn = CrateOracleConnection();
		try
		{
			conn.Open();
			return conn.QuerySingle<Number>(sql).Count;
		}
		catch (Exception ex)
		{
			try
			{
				conn.Close();
			}
			catch (Exception)
			{
			}
			throw ex;
		}
		finally
		{
			try
			{
				conn.Close();
			}
			catch (Exception)
			{
			}
		}
	}

	public static void ExecuteCommand(string sql)
	{
		using IDbConnection conn = CrateOracleConnection();
		try
		{
			conn.Open();
			conn.Execute(sql);
			conn.Close();
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{
			try
			{
				conn.Close();
			}
			catch (Exception)
			{
			}
		}
	}

	public static void ExecuteCommand(IList<string> sql)
	{
		using IDbConnection conn = CrateOracleConnection();
		try
		{
			conn.Open();
			foreach (string s in sql)
			{
				conn.Execute(s);
			}
			conn.Close();
		}
		catch (Exception)
		{
			throw;
		}
	}
}
