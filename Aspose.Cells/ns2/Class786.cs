using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text;
using Aspose.Cells;

namespace ns2;

internal class Class786
{
	internal static DataSet smethod_0(WorkbookDesigner workbookDesigner_0, object object_0)
	{
		if (object_0 != null)
		{
			Hashtable hashtable = smethod_3(workbookDesigner_0);
			if (hashtable.Count > 0)
			{
				if (object_0 is SqlConnection)
				{
					return smethod_2(hashtable, object_0);
				}
				return smethod_1(hashtable, object_0);
			}
		}
		return null;
	}

	private static DataSet smethod_1(Hashtable hashtable_0, object object_0)
	{
		OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter();
		oleDbDataAdapter.SelectCommand = new OleDbCommand();
		oleDbDataAdapter.SelectCommand.Connection = (OleDbConnection)object_0;
		DataSet dataSet = new DataSet();
		foreach (string key in hashtable_0.Keys)
		{
			StringBuilder stringBuilder = new StringBuilder("select ");
			Hashtable hashtable = (Hashtable)hashtable_0[key];
			foreach (string key2 in hashtable.Keys)
			{
				stringBuilder.Append(key2);
				stringBuilder.Append(',');
			}
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
			stringBuilder.Append(" from ");
			stringBuilder.Append(key);
			oleDbDataAdapter.SelectCommand.CommandText = stringBuilder.ToString();
			oleDbDataAdapter.Fill(dataSet);
			dataSet.Tables[dataSet.Tables.Count - 1].TableName = key;
		}
		return dataSet;
	}

	private static DataSet smethod_2(Hashtable hashtable_0, object object_0)
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
		sqlDataAdapter.SelectCommand = new SqlCommand();
		sqlDataAdapter.SelectCommand.Connection = (SqlConnection)object_0;
		DataSet dataSet = new DataSet();
		foreach (string key in hashtable_0.Keys)
		{
			StringBuilder stringBuilder = new StringBuilder("select ");
			Hashtable hashtable = (Hashtable)hashtable_0[key];
			foreach (string key2 in hashtable.Keys)
			{
				stringBuilder.Append(key2);
				stringBuilder.Append(',');
			}
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
			stringBuilder.Append(" from ");
			stringBuilder.Append(key);
			sqlDataAdapter.SelectCommand.CommandText = stringBuilder.ToString();
			sqlDataAdapter.Fill(dataSet);
		}
		return dataSet;
	}

	private static Hashtable smethod_3(WorkbookDesigner workbookDesigner_0)
	{
		string[] smartMarkers = workbookDesigner_0.GetSmartMarkers();
		Hashtable hashtable = new Hashtable();
		string[] array = smartMarkers;
		foreach (string text in array)
		{
			string[] array2 = text.Substring(2).Split('.');
			if (array2.Length != 2)
			{
				continue;
			}
			string text2 = array2[0];
			if (text2[0] == '[' && text2[text2.Length - 1] == ']')
			{
				text2 = text2.Substring(1, text2.Length - 2);
				if (text2 == null || text2 == "")
				{
					continue;
				}
			}
			string text3 = array2[1];
			if (text3[0] == '[' && text3[text3.Length - 1] == ']')
			{
				text3 = text3.Substring(1, text3.Length - 2);
				if (text3 == null || text3 == "")
				{
					continue;
				}
			}
			Hashtable hashtable2 = null;
			hashtable2 = (Hashtable)((hashtable[text2] != null) ? ((Hashtable)hashtable[text2]) : (hashtable[text2] = new Hashtable()));
			if (hashtable2[text3] == null)
			{
				hashtable2[text3] = text3;
			}
		}
		return hashtable;
	}
}
