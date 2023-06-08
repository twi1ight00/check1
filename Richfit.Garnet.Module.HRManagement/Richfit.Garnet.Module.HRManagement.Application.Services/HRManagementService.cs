using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using Oracle.DataAccess.Client;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Domain.Models;
using Richfit.Garnet.Module.HRManagement.Application.DTO;
using Richfit.Garnet.Module.HRManagement.Domain.Models;

namespace Richfit.Garnet.Module.HRManagement.Application.Services;

public class HRManagementService : ServiceBase, IHRManagementService
{
	/// <summary>
	/// 人事信息 仓储对象
	/// </summary>
	private readonly IRepository<S_TEMP_STO_HRMANAGEMENT> fromHrmanagement;

	/// <summary>
	/// 构造函数
	/// </summary>
	public HRManagementService(IRepository<S_TEMP_STO_HRMANAGEMENT> hrmanagement)
	{
		fromHrmanagement = hrmanagement;
	}

	public IList<S_TEMP_STO_HRMANAGEMENTDTO> InsertDataFromImport(IList<S_TEMP_STO_HRMANAGEMENTDTO> Listdto)
	{
		if (Listdto == null)
		{
			throw new ArgumentException("InsertDataFromImport方法参数不能为空！");
		}
		fromHrmanagement.ExecuteCommand("DELETE FROM S_TEMP_STO_HRMANAGEMENT");
		string isSuccess = ConfigurationManager.System.Settings.GetSetting<string>("connOrcleString");
		DataTable dataTable = ToDataTable(Listdto.ToList());
		dataTable.TableName = "S_TEMP_STO_HRMANAGEMENT";
		if (!BulkToDB(dataTable, isSuccess))
		{
			throw new ArgumentException("导入有误！");
		}
		SqlRepository sqlr = new SqlRepository(null);
		DbConnection connection = (DbConnection)sqlr.Connection;
		DbCommand command = connection.CreateCommand();
		connection.Open();
		command.CommandType = CommandType.StoredProcedure;
		command.CommandText = "PROC_PERSONNELINFOIMPORT";
		try
		{
			command.ExecuteNonQuery();
			return Listdto;
		}
		catch (Exception)
		{
			throw new ArgumentException("导入有误！");
		}
		finally
		{
			connection.Close();
		}
	}

	/// <summary>
	/// Orcale批量插入数据
	/// </summary>
	/// <param name="dt">要插入的数据</param>
	/// <param name="targetTable">数据库中的表</param>
	public bool BulkToDB(DataTable dt, string connOrcleString)
	{
		OracleConnection conn = new OracleConnection(connOrcleString);
		if (conn.State != ConnectionState.Open)
		{
			conn.Open();
		}
		OracleBulkCopy bulkCopy = new OracleBulkCopy(conn);
		bulkCopy.DestinationTableName = dt.TableName;
		foreach (DataColumn column in dt.Columns)
		{
			bulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
		}
		try
		{
			if (dt != null && dt.Rows.Count != 0)
			{
				bulkCopy.WriteToServer(dt);
				return true;
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
		finally
		{
			conn.Close();
			bulkCopy?.Close();
		}
	}

	private DataTable ToDataTable<T>(List<T> items)
	{
		DataTable tb = new DataTable(typeof(T).Name);
		PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
		PropertyInfo[] array = props;
		foreach (PropertyInfo prop in array)
		{
			Type t = GetCoreType(prop.PropertyType);
			tb.Columns.Add(prop.Name, t);
		}
		foreach (T item in items)
		{
			object[] values = new object[props.Length];
			for (int i = 0; i < props.Length; i++)
			{
				values[i] = props[i].GetValue(item, null);
			}
			tb.Rows.Add(values);
		}
		return tb;
	}

	public static bool IsNullable(Type t)
	{
		return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
	}

	public static Type GetCoreType(Type t)
	{
		if (t != null && IsNullable(t))
		{
			if (!t.IsValueType)
			{
				return t;
			}
			return Nullable.GetUnderlyingType(t);
		}
		return t;
	}
}
