using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace PageOffice.ZoomSeal;

public class RootCertManager
{
	private string m__0002;

	private int _0003 = 1;

	public string DBConnectionString
	{
		get
		{
			return this.m__0002;
		}
		set
		{
			this.m__0002 = value;
		}
	}

	public int OPUserID
	{
		set
		{
			_0003 = value;
		}
	}

	private void _0002(OleDbConnection _0002, string _0003, string _0005)
	{
		try
		{
			string text = _0005_2000._0002(1402791676);
			string cmdText = _0005_2000._0002(1402791657) + this._0003;
			OleDbCommand oleDbCommand = new OleDbCommand(cmdText, _0002);
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (oleDbDataReader.Read())
			{
				text = oleDbDataReader[_0005_2000._0002(1402775114)].ToString();
			}
			oleDbDataReader.Close();
			cmdText = _0005_2000._0002(1402791479);
			cmdText = cmdText + _0005_2000._0002(1402787744) + DateTime.Now.ToString(_0005_2000._0002(1402781919)) + _0005_2000._0002(1402787043) + this._0003 + _0005_2000._0002(1402787011) + text + _0005_2000._0002(1402787018) + _0003 + _0005_2000._0002(1402787018) + _0005 + _0005_2000._0002(1402786868);
			oleDbCommand = new OleDbCommand(cmdText, _0002);
			oleDbCommand.ExecuteNonQuery();
		}
		catch (OleDbException ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public string CleanSQLParam(string Param)
	{
		return _0003_2000._0002_2000(Param);
	}

	public bool Delete(int certID)
	{
		bool flag = false;
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0002);
		try
		{
			string cmdText = _0005_2000._0002(1402791520) + certID;
			OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
			oleDbConnection.Open();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (oleDbDataReader.Read())
			{
				cmdText = _0005_2000._0002(1402790325) + certID;
				string text = oleDbDataReader[_0005_2000._0002(1402790299)].ToString();
				oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
				oleDbCommand.ExecuteNonQuery();
				flag = true;
				_0002(oleDbConnection, _0005_2000._0002(1402790280), _0005_2000._0002(1402790395) + text + _0005_2000._0002(1402790374) + certID + _0005_2000._0002(1402790359));
			}
			else
			{
				flag = false;
			}
			oleDbDataReader.Close();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
		oleDbConnection.Close();
		return flag;
	}

	public bool Exists(int certID)
	{
		bool flag = false;
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0002);
		try
		{
			string cmdText = _0005_2000._0002(1402790350) + certID;
			OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
			oleDbConnection.Open();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			flag = (oleDbDataReader.Read() ? true : false);
			oleDbDataReader.Close();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
		oleDbConnection.Close();
		return flag;
	}

	public int Exists(string certName)
	{
		int result = -1;
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0002);
		try
		{
			string cmdText = _0005_2000._0002(1402790169);
			OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
			oleDbCommand.Parameters.Add(_0005_2000._0002(1402790249), OleDbType.VarWChar).Value = certName;
			oleDbConnection.Open();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (oleDbDataReader.Read())
			{
				result = (int)oleDbDataReader[_0005_2000._0002(1402784054)];
			}
			oleDbDataReader.Close();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
		oleDbConnection.Close();
		return result;
	}

	public int Add(RootCert model)
	{
		if (model.CertName == null || model.CertName == string.Empty)
		{
			throw new Exception(_0005_2000._0002(1402790233));
		}
		int num = -1;
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0002);
		try
		{
			oleDbConnection.Open();
			StringBuilder stringBuilder = new StringBuilder(_0005_2000._0002(1402790058));
			stringBuilder.Append(_0005_2000._0002(1402790025));
			stringBuilder.Append(_0005_2000._0002(1402787532));
			stringBuilder.Append(_0005_2000._0002(1402789944));
			OleDbCommand oleDbCommand = new OleDbCommand(stringBuilder.ToString(), oleDbConnection);
			OleDbParameter[] array = new OleDbParameter[7]
			{
				new OleDbParameter(_0005_2000._0002(1402790249), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402789935), OleDbType.Date),
				new OleDbParameter(_0005_2000._0002(1402789889), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402790003), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402789990), OleDbType.Date),
				new OleDbParameter(_0005_2000._0002(1402789977), OleDbType.Date),
				new OleDbParameter(_0005_2000._0002(1402789958), OleDbType.VarWChar)
			};
			array[0].Value = model.CertName;
			array[1].Value = DateTime.Now;
			array[2].Value = model.Description;
			array[3].Value = model.CertSerialNum;
			if (model.ValidFrom == string.Empty)
			{
				array[4].Value = DBNull.Value;
			}
			else
			{
				array[4].Value = DateTime.Parse(model.ValidFrom);
			}
			if (model.ValidTo == string.Empty)
			{
				array[5].Value = DBNull.Value;
			}
			else
			{
				array[5].Value = DateTime.Parse(model.ValidTo);
			}
			array[6].Value = model.CertPKCS7;
			OleDbParameter[] array2 = array;
			foreach (OleDbParameter value in array2)
			{
				oleDbCommand.Parameters.Add(value);
			}
			oleDbCommand.ExecuteNonQuery();
			oleDbCommand.CommandText = _0005_2000._0002(1402787336);
			object obj = oleDbCommand.ExecuteScalar();
			oleDbCommand.Parameters.Clear();
			if (object.Equals(obj, null) || object.Equals(obj, DBNull.Value))
			{
				num = -1;
			}
			else
			{
				num = int.Parse(obj.ToString());
				_0002(oleDbConnection, _0005_2000._0002(1402790841), _0005_2000._0002(1402790395) + model.CertName + _0005_2000._0002(1402790374) + num + _0005_2000._0002(1402790824));
			}
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
		oleDbConnection.Close();
		return num;
	}

	public RootCert GetModel(int certID)
	{
		RootCert rootCert = null;
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0002);
		try
		{
			string cmdText = _0005_2000._0002(1402790789) + certID;
			OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
			oleDbConnection.Open();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (oleDbDataReader.Read())
			{
				rootCert = new RootCert();
				rootCert._0002 = certID;
				rootCert.CertName = oleDbDataReader[_0005_2000._0002(1402790299)].ToString();
				rootCert._0005 = (DateTime)oleDbDataReader[_0005_2000._0002(1402790677)];
				rootCert.Description = oleDbDataReader[_0005_2000._0002(1402790660)].ToString();
				rootCert.CertSerialNum = oleDbDataReader[_0005_2000._0002(1402785684)].ToString();
				rootCert.ValidFrom = oleDbDataReader[_0005_2000._0002(1402785672)].ToString();
				rootCert.ValidTo = oleDbDataReader[_0005_2000._0002(1402785784)].ToString();
				rootCert.CertPKCS7 = oleDbDataReader[_0005_2000._0002(1402785766)].ToString();
			}
			oleDbDataReader.Close();
		}
		catch (OleDbException ex)
		{
			throw new Exception(ex.Message);
		}
		oleDbConnection.Close();
		return rootCert;
	}

	public List<RootCert> GetQueryCollection(string strWhereSql)
	{
		List<RootCert> list = new List<RootCert>();
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0002);
		try
		{
			string cmdText = _0005_2000._0002(1402790774) + strWhereSql;
			OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
			oleDbConnection.Open();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			while (oleDbDataReader.Read())
			{
				RootCert rootCert = new RootCert();
				rootCert._0002 = (int)oleDbDataReader[_0005_2000._0002(1402784054)];
				rootCert.CertName = oleDbDataReader[_0005_2000._0002(1402790299)].ToString();
				rootCert._0005 = (DateTime)oleDbDataReader[_0005_2000._0002(1402790677)];
				rootCert.Description = oleDbDataReader[_0005_2000._0002(1402790660)].ToString();
				rootCert.CertSerialNum = oleDbDataReader[_0005_2000._0002(1402785684)].ToString();
				rootCert.ValidFrom = oleDbDataReader[_0005_2000._0002(1402785672)].ToString();
				rootCert.ValidTo = oleDbDataReader[_0005_2000._0002(1402785784)].ToString();
				rootCert.CertPKCS7 = oleDbDataReader[_0005_2000._0002(1402785766)].ToString();
				list.Add(rootCert);
			}
			oleDbDataReader.Close();
		}
		catch (OleDbException ex)
		{
			throw new Exception(ex.Message);
		}
		oleDbConnection.Close();
		return list;
	}
}
