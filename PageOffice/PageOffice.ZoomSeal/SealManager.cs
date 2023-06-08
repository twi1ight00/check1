using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using poserverLib;

namespace PageOffice.ZoomSeal;

public class SealManager
{
	private string m__0002;

	private string m__0003;

	private string m__0005 = string.Empty;

	private string _0008 = string.Empty;

	private string _0006 = string.Empty;

	private string _000E = string.Empty;

	private int _000F = 1;

	public string DBConnectionString
	{
		set
		{
			this.m__0003 = value;
		}
	}

	public int OPUserID
	{
		set
		{
			_000F = value;
		}
	}

	public SealManager(string serverPath)
	{
		if (serverPath == null || serverPath == string.Empty)
		{
			throw new Exception(_0005_2000._0002(1402790621));
		}
		this.m__0002 = serverPath;
	}

	private int _0002()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		ServerClass val = new ServerClass();
		val.POPath = this.m__0002;
		if (val.SealCount == null)
		{
			return 0;
		}
		return int.Parse(val.SealCount, NumberStyles.HexNumber);
	}

	private void _0002(OleDbConnection _0002, string _0003, string _0005)
	{
		if (this.m__0003.ToLower().IndexOf(_0005_2000._0002(1402787302)) > -1)
		{
			this._0005(_0002, _0003, _0005);
		}
		else
		{
			this._0003(_0002, _0003, _0005);
		}
	}

	private void _0003(OleDbConnection _0002, string _0003, string _0005)
	{
		try
		{
			string text = _0005_2000._0002(1402791676);
			string cmdText = _0005_2000._0002(1402791657) + _000F;
			OleDbCommand oleDbCommand = new OleDbCommand(cmdText, _0002);
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (oleDbDataReader.Read())
			{
				text = oleDbDataReader[_0005_2000._0002(1402775114)].ToString();
			}
			oleDbDataReader.Close();
			cmdText = _0005_2000._0002(1402791479);
			cmdText = cmdText + _0005_2000._0002(1402787744) + DateTime.Now.ToString(_0005_2000._0002(1402781919)) + _0005_2000._0002(1402787043) + _000F + _0005_2000._0002(1402787011) + text + _0005_2000._0002(1402787018) + _0003 + _0005_2000._0002(1402787018) + _0005 + _0005_2000._0002(1402786868);
			oleDbCommand = new OleDbCommand(cmdText, _0002);
			oleDbCommand.ExecuteNonQuery();
		}
		catch (OleDbException ex)
		{
			throw new Exception(ex.Message);
		}
	}

	private void _0005(OleDbConnection _0002, string _0003, string _0005)
	{
		try
		{
			string text = _0005_2000._0002(1402791676);
			string cmdText = _0005_2000._0002(1402791657) + _000F;
			OleDbCommand oleDbCommand = new OleDbCommand(cmdText, _0002);
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (oleDbDataReader.Read())
			{
				text = oleDbDataReader[_0005_2000._0002(1402775114)].ToString();
			}
			oleDbDataReader.Close();
			cmdText = _0005_2000._0002(1402790416);
			cmdText = cmdText + _0005_2000._0002(1402790494) + _000F + _0005_2000._0002(1402787011) + text + _0005_2000._0002(1402787018) + _0003 + _0005_2000._0002(1402787018) + _0005 + _0005_2000._0002(1402786868);
			oleDbCommand = new OleDbCommand(cmdText, _0002);
			oleDbCommand.ExecuteNonQuery();
		}
		catch (OleDbException ex)
		{
			throw new Exception(ex.Message);
		}
	}

	private void _0002(OleDbConnection _0002, int _0003)
	{
		try
		{
			string cmdText = _0005_2000._0002(1402793376) + _0003;
			OleDbCommand oleDbCommand = new OleDbCommand(cmdText, _0002);
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (oleDbDataReader.Read())
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(_0003);
				stringBuilder.Append(oleDbDataReader[_0005_2000._0002(1402784802)].ToString());
				stringBuilder.Append(oleDbDataReader[_0005_2000._0002(1402784787)].ToString());
				stringBuilder.Append(oleDbDataReader[_0005_2000._0002(1402784768)].ToString());
				stringBuilder.Append(oleDbDataReader[_0005_2000._0002(1402784883)].ToString());
				stringBuilder.Append(oleDbDataReader[_0005_2000._0002(1402784864)].ToString());
				stringBuilder.Append(oleDbDataReader[_0005_2000._0002(1402784879)].ToString());
				stringBuilder.Append(oleDbDataReader[_0005_2000._0002(1402784860)].ToString());
				stringBuilder.Append(oleDbDataReader[_0005_2000._0002(1402784843)].ToString());
				stringBuilder.Append(oleDbDataReader[_0005_2000._0002(1402785720)].ToString());
				stringBuilder.Append(oleDbDataReader[_0005_2000._0002(1402785702)].ToString());
				stringBuilder.Append(oleDbDataReader[_0005_2000._0002(1402785684)].ToString());
				stringBuilder.Append(oleDbDataReader[_0005_2000._0002(1402785672)].ToString());
				stringBuilder.Append(oleDbDataReader[_0005_2000._0002(1402785784)].ToString());
				stringBuilder.Append(oleDbDataReader[_0005_2000._0002(1402785766)].ToString());
				if (oleDbDataReader[_0005_2000._0002(1402785750)] != DBNull.Value)
				{
					stringBuilder.Append(Convert.ToBase64String((byte[])oleDbDataReader[_0005_2000._0002(1402785750)]));
				}
				stringBuilder.Append(_0005_2000._0002(1402785734));
				SHA1 sHA = SHA1.Create();
				byte[] bytes = Encoding.UTF8.GetBytes(stringBuilder.ToString());
				byte[] array = sHA.ComputeHash(bytes);
				sHA.Clear();
				string text = string.Empty;
				for (int i = 0; i < array.Length; i++)
				{
					text += array[i].ToString(_0005_2000._0002(1402785575)).PadLeft(2, '0');
				}
				cmdText = _0005_2000._0002(1402793308) + text + _0005_2000._0002(1402793149) + _0003;
				oleDbCommand = new OleDbCommand(cmdText, _0002);
				oleDbCommand.ExecuteNonQuery();
			}
			oleDbDataReader.Close();
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

	public string GetLicOrg()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		ServerClass val = new ServerClass();
		val.POPath = this.m__0002;
		return val.Organization;
	}

	public void Grant(int sealID)
	{
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0003);
		try
		{
			string cmdText = _0005_2000._0002(1402793135) + sealID;
			OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
			oleDbConnection.Open();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (!oleDbDataReader.Read())
			{
				throw new Exception(_0005_2000._0002(1402793733) + sealID + _0005_2000._0002(1402793850));
			}
			string text = oleDbDataReader[_0005_2000._0002(1402784860)].ToString();
			if (text == _0005_2000._0002(1402783810))
			{
				throw new Exception(_0005_2000._0002(1402793156) + sealID + _0005_2000._0002(1402793017));
			}
			if (oleDbDataReader.IsDBNull(0))
			{
				throw new Exception(_0005_2000._0002(1402793156) + sealID + _0005_2000._0002(1402792964));
			}
			if (oleDbDataReader[_0005_2000._0002(1402784843)].ToString() == _0005_2000._0002(1402790608) && oleDbDataReader[_0005_2000._0002(1402785684)].ToString() == string.Empty)
			{
				throw new Exception(_0005_2000._0002(1402793156) + sealID + _0005_2000._0002(1402793049));
			}
			cmdText = _0005_2000._0002(1402793898) + sealID;
			oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
			oleDbCommand.ExecuteNonQuery();
			_0002(oleDbConnection, sealID);
			if (oleDbDataReader[_0005_2000._0002(1402784843)].ToString() == _0005_2000._0002(1402790631))
			{
				_0002(oleDbConnection, _0005_2000._0002(1402793951), _0005_2000._0002(1402793932) + oleDbDataReader[_0005_2000._0002(1402784802)].ToString() + _0005_2000._0002(1402790374) + sealID + _0005_2000._0002(1402793791));
			}
			else if (oleDbDataReader[_0005_2000._0002(1402784843)].ToString() == _0005_2000._0002(1402790608))
			{
				_0002(oleDbConnection, _0005_2000._0002(1402793951), _0005_2000._0002(1402793932) + oleDbDataReader[_0005_2000._0002(1402784802)].ToString() + _0005_2000._0002(1402790374) + sealID + _0005_2000._0002(1402793748) + oleDbDataReader[_0005_2000._0002(1402785684)].ToString() + _0005_2000._0002(1402793791));
			}
			oleDbDataReader.Close();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
		oleDbConnection.Close();
	}

	public void Revoke(int sealID)
	{
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0003);
		try
		{
			string cmdText = _0005_2000._0002(1402793135) + sealID;
			OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
			oleDbConnection.Open();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (!oleDbDataReader.Read())
			{
				throw new Exception(_0005_2000._0002(1402793512) + sealID + _0005_2000._0002(1402793850));
			}
			string text = oleDbDataReader[_0005_2000._0002(1402784860)].ToString();
			if (text != _0005_2000._0002(1402793811))
			{
				throw new Exception(_0005_2000._0002(1402793156) + sealID + _0005_2000._0002(1402793820));
			}
			cmdText = _0005_2000._0002(1402793617) + sealID;
			oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
			oleDbCommand.ExecuteNonQuery();
			_0002(oleDbConnection, sealID);
			if (oleDbDataReader[_0005_2000._0002(1402784843)].ToString() == _0005_2000._0002(1402790631))
			{
				_0002(oleDbConnection, _0005_2000._0002(1402793666), _0005_2000._0002(1402793932) + oleDbDataReader[_0005_2000._0002(1402784802)].ToString() + _0005_2000._0002(1402790374) + sealID + _0005_2000._0002(1402793523));
			}
			else if (oleDbDataReader[_0005_2000._0002(1402784843)].ToString() == _0005_2000._0002(1402790608))
			{
				_0002(oleDbConnection, _0005_2000._0002(1402793666), _0005_2000._0002(1402793932) + oleDbDataReader[_0005_2000._0002(1402784802)].ToString() + _0005_2000._0002(1402790374) + sealID + _0005_2000._0002(1402793748) + oleDbDataReader[_0005_2000._0002(1402785684)].ToString() + _0005_2000._0002(1402793523));
			}
			oleDbDataReader.Close();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
		oleDbConnection.Close();
	}

	public void Suspend(int sealID)
	{
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0003);
		try
		{
			string cmdText = _0005_2000._0002(1402793135) + sealID;
			OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
			oleDbConnection.Open();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (!oleDbDataReader.Read())
			{
				throw new Exception(_0005_2000._0002(1402792429) + sealID + _0005_2000._0002(1402793850));
			}
			string text = oleDbDataReader[_0005_2000._0002(1402784860)].ToString();
			if (text != _0005_2000._0002(1402793811))
			{
				throw new Exception(_0005_2000._0002(1402793156) + sealID + _0005_2000._0002(1402793473));
			}
			cmdText = _0005_2000._0002(1402793554) + sealID;
			oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
			oleDbCommand.ExecuteNonQuery();
			_0002(oleDbConnection, sealID);
			if (oleDbDataReader[_0005_2000._0002(1402784843)].ToString() == _0005_2000._0002(1402790631))
			{
				_0002(oleDbConnection, _0005_2000._0002(1402792327), _0005_2000._0002(1402793932) + oleDbDataReader[_0005_2000._0002(1402784802)].ToString() + _0005_2000._0002(1402790374) + sealID + _0005_2000._0002(1402792436));
			}
			else if (oleDbDataReader[_0005_2000._0002(1402784843)].ToString() == _0005_2000._0002(1402790608))
			{
				_0002(oleDbConnection, _0005_2000._0002(1402792327), _0005_2000._0002(1402793932) + oleDbDataReader[_0005_2000._0002(1402784802)].ToString() + _0005_2000._0002(1402790374) + sealID + _0005_2000._0002(1402793748) + oleDbDataReader[_0005_2000._0002(1402785684)].ToString() + _0005_2000._0002(1402792436));
			}
			oleDbDataReader.Close();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
		oleDbConnection.Close();
	}

	public bool Delete(int sealID)
	{
		bool flag = false;
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0003);
		try
		{
			string cmdText = _0005_2000._0002(1402792386) + sealID;
			OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
			oleDbConnection.Open();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (oleDbDataReader.Read())
			{
				cmdText = _0005_2000._0002(1402792306) + sealID;
				string text = oleDbDataReader[_0005_2000._0002(1402784802)].ToString();
				string text2 = oleDbDataReader[_0005_2000._0002(1402785684)].ToString();
				string text3 = oleDbDataReader[_0005_2000._0002(1402784843)].ToString();
				oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
				oleDbCommand.ExecuteNonQuery();
				flag = true;
				if (text3 == _0005_2000._0002(1402790631))
				{
					_0002(oleDbConnection, _0005_2000._0002(1402792276), _0005_2000._0002(1402793932) + text + _0005_2000._0002(1402790374) + sealID + _0005_2000._0002(1402792261));
				}
				else if (text3 == _0005_2000._0002(1402790608))
				{
					_0002(oleDbConnection, _0005_2000._0002(1402792276), _0005_2000._0002(1402793932) + text + _0005_2000._0002(1402790374) + sealID + _0005_2000._0002(1402793748) + text2 + _0005_2000._0002(1402792261));
				}
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

	public bool Exists(int sealID)
	{
		bool flag = false;
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0003);
		try
		{
			string cmdText = _0005_2000._0002(1402792122) + sealID;
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

	public int Add(Seal model)
	{
		if (this.m__0003.ToLower().IndexOf(_0005_2000._0002(1402787302)) > -1)
		{
			return _0003(model);
		}
		return _0002(model);
	}

	private int _0002(Seal _0002)
	{
		if (_0002.SealName == null || _0002.SealName == string.Empty)
		{
			throw new Exception(_0005_2000._0002(1402792065));
		}
		int num = -1;
		int num2 = -1;
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0003);
		try
		{
			OleDbCommand oleDbCommand = new OleDbCommand(_0005_2000._0002(1402792146), oleDbConnection);
			oleDbConnection.Open();
			num = (int)oleDbCommand.ExecuteScalar();
		}
		catch
		{
			return -1;
		}
		int num3 = this._0002();
		if (num >= num3)
		{
			if (num3 < 0)
			{
				throw new Exception(_0005_2000._0002(1402791995));
			}
			throw new Exception(_0005_2000._0002(1402791942) + num + _0005_2000._0002(1402792873));
		}
		try
		{
			StringBuilder stringBuilder = new StringBuilder(_0005_2000._0002(1402792848));
			stringBuilder.Append(_0005_2000._0002(1402792843));
			stringBuilder.Append(_0005_2000._0002(1402787532));
			stringBuilder.Append(_0005_2000._0002(1402792624));
			OleDbCommand oleDbCommand2 = new OleDbCommand(stringBuilder.ToString(), oleDbConnection);
			OleDbParameter[] array = new OleDbParameter[20]
			{
				new OleDbParameter(_0005_2000._0002(1402784366), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792577), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792689), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792675), OleDbType.Integer),
				new OleDbParameter(_0005_2000._0002(1402792659), OleDbType.Integer),
				new OleDbParameter(_0005_2000._0002(1402792641), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402789935), OleDbType.Date),
				new OleDbParameter(_0005_2000._0002(1402792497), OleDbType.Date),
				new OleDbParameter(_0005_2000._0002(1402792483), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402789889), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792465), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792449), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792462), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402790003), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402789990), OleDbType.Date),
				new OleDbParameter(_0005_2000._0002(1402789977), OleDbType.Date),
				new OleDbParameter(_0005_2000._0002(1402789958), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792575), OleDbType.VarBinary),
				new OleDbParameter(_0005_2000._0002(1402792558), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792517), OleDbType.VarWChar)
			};
			array[0].Value = _0002.SealName;
			array[1].Value = _0002.SealType;
			array[2].Value = _0002.SignerName;
			array[3].Value = _0002.SignerID;
			array[4].Value = _0002.DeptID;
			array[5].Value = _0002.DeptName;
			array[6].Value = DateTime.Now;
			array[7].Value = DateTime.Now;
			array[8].Value = _0002.Status;
			array[9].Value = _0002.Description;
			array[10].Value = _0002.AuthType;
			array[11].Value = _0002.IssueTo;
			array[12].Value = _0002.IssueBy;
			array[13].Value = _0002.CertSerialNum;
			if (_0002.ValidFrom == string.Empty)
			{
				array[14].Value = DBNull.Value;
			}
			else
			{
				array[14].Value = DateTime.Parse(_0002.ValidFrom);
			}
			if (_0002.ValidTo == string.Empty)
			{
				array[15].Value = DBNull.Value;
			}
			else
			{
				array[15].Value = DateTime.Parse(_0002.ValidTo);
			}
			array[16].Value = _0002.CertPKCS7;
			if (_0002.SealImage != null)
			{
				array[17].Value = _0002.SealImage;
			}
			else
			{
				array[17].Value = DBNull.Value;
			}
			array[18].Value = _0002.SealImageType;
			array[19].Value = _0005_2000._0002(1402795440);
			OleDbParameter[] array2 = array;
			foreach (OleDbParameter value in array2)
			{
				oleDbCommand2.Parameters.Add(value);
			}
			oleDbCommand2.ExecuteNonQuery();
			oleDbCommand2.CommandText = _0005_2000._0002(1402787336);
			object obj2 = oleDbCommand2.ExecuteScalar();
			oleDbCommand2.Parameters.Clear();
			if (object.Equals(obj2, null) || object.Equals(obj2, DBNull.Value))
			{
				num2 = -1;
			}
			else
			{
				num2 = int.Parse(obj2.ToString());
				this._0002(oleDbConnection, num2);
				this._0002(oleDbConnection, _0005_2000._0002(1402795453), _0005_2000._0002(1402793932) + _0002.SealName + _0005_2000._0002(1402790374) + num2 + _0005_2000._0002(1402795434));
			}
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
		oleDbConnection.Close();
		return num2;
	}

	private int _0003(Seal _0002)
	{
		if (_0002.SealName == null || _0002.SealName == string.Empty)
		{
			throw new Exception(_0005_2000._0002(1402792065));
		}
		int num = -1;
		int num2 = -1;
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0003);
		try
		{
			oleDbConnection.Open();
			OleDbCommand oleDbCommand = new OleDbCommand(_0005_2000._0002(1402792146), oleDbConnection);
			decimal num3 = (decimal)oleDbCommand.ExecuteScalar();
			num = (int)num3;
		}
		catch
		{
			return -1;
		}
		int num4 = this._0002();
		if (num >= num4)
		{
			if (num4 < 0)
			{
				throw new Exception(_0005_2000._0002(1402791995));
			}
			throw new Exception(_0005_2000._0002(1402791942) + num + _0005_2000._0002(1402792873));
		}
		try
		{
			OleDbCommand oleDbCommand2 = new OleDbCommand(_0005_2000._0002(1402795397), oleDbConnection);
			decimal num5 = (decimal)oleDbCommand2.ExecuteScalar();
			num2 = (int)num5;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
		try
		{
			StringBuilder stringBuilder = new StringBuilder(_0005_2000._0002(1402792848));
			stringBuilder.Append(_0005_2000._0002(1402795500));
			stringBuilder.Append(_0005_2000._0002(1402787532));
			stringBuilder.Append(_0005_2000._0002(1402795158));
			OleDbCommand oleDbCommand3 = new OleDbCommand(stringBuilder.ToString(), oleDbConnection);
			OleDbParameter[] array = new OleDbParameter[21]
			{
				new OleDbParameter(_0005_2000._0002(1402784366), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792577), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792689), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792675), OleDbType.Integer),
				new OleDbParameter(_0005_2000._0002(1402792659), OleDbType.Integer),
				new OleDbParameter(_0005_2000._0002(1402792641), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402789935), OleDbType.Date),
				new OleDbParameter(_0005_2000._0002(1402792497), OleDbType.Date),
				new OleDbParameter(_0005_2000._0002(1402792483), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402789889), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792465), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792449), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792462), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402790003), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402789990), OleDbType.Date),
				new OleDbParameter(_0005_2000._0002(1402789977), OleDbType.Date),
				new OleDbParameter(_0005_2000._0002(1402789958), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792575), OleDbType.VarBinary),
				new OleDbParameter(_0005_2000._0002(1402792558), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792517), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402786212), OleDbType.Integer)
			};
			array[0].Value = _0002.SealName;
			array[1].Value = _0002.SealType;
			array[2].Value = _0002.SignerName;
			array[3].Value = _0002.SignerID;
			array[4].Value = _0002.DeptID;
			array[5].Value = _0002.DeptName;
			array[6].Value = DateTime.Now;
			array[7].Value = DateTime.Now;
			array[8].Value = _0002.Status;
			array[9].Value = _0002.Description;
			array[10].Value = _0002.AuthType;
			array[11].Value = _0002.IssueTo;
			array[12].Value = _0002.IssueBy;
			array[13].Value = _0002.CertSerialNum;
			if (_0002.ValidFrom == string.Empty)
			{
				array[14].Value = DBNull.Value;
			}
			else
			{
				array[14].Value = DateTime.Parse(_0002.ValidFrom);
			}
			if (_0002.ValidTo == string.Empty)
			{
				array[15].Value = DBNull.Value;
			}
			else
			{
				array[15].Value = DateTime.Parse(_0002.ValidTo);
			}
			array[16].Value = _0002.CertPKCS7;
			if (_0002.SealImage != null)
			{
				array[17].Value = _0002.SealImage;
			}
			else
			{
				array[17].Value = DBNull.Value;
			}
			array[18].Value = _0002.SealImageType;
			array[19].Value = _0005_2000._0002(1402795440);
			array[20].Value = num2;
			OleDbParameter[] array2 = array;
			foreach (OleDbParameter value in array2)
			{
				oleDbCommand3.Parameters.Add(value);
			}
			oleDbCommand3.ExecuteNonQuery();
			oleDbCommand3.Parameters.Clear();
			this._0002(oleDbConnection, num2);
			this._0002(oleDbConnection, _0005_2000._0002(1402795453), _0005_2000._0002(1402793932) + _0002.SealName + _0005_2000._0002(1402790374) + num2 + _0005_2000._0002(1402795434));
		}
		catch (Exception ex2)
		{
			throw new Exception(ex2.Message);
		}
		oleDbConnection.Close();
		return num2;
	}

	public bool Update(Seal model)
	{
		if (model.SealName == null || model.SealName == string.Empty)
		{
			throw new Exception(_0005_2000._0002(1402795241));
		}
		bool flag = false;
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0003);
		try
		{
			oleDbConnection.Open();
			StringBuilder stringBuilder = new StringBuilder(_0005_2000._0002(1402795064));
			stringBuilder.Append(_0005_2000._0002(1402795024));
			stringBuilder.Append(_0005_2000._0002(1402795010));
			stringBuilder.Append(_0005_2000._0002(1402795124));
			stringBuilder.Append(_0005_2000._0002(1402795112));
			stringBuilder.Append(_0005_2000._0002(1402795098));
			stringBuilder.Append(_0005_2000._0002(1402795082));
			stringBuilder.Append(_0005_2000._0002(1402795964));
			stringBuilder.Append(_0005_2000._0002(1402795920));
			stringBuilder.Append(_0005_2000._0002(1402795904));
			stringBuilder.Append(_0005_2000._0002(1402796023));
			stringBuilder.Append(_0005_2000._0002(1402796009));
			stringBuilder.Append(_0005_2000._0002(1402795992));
			stringBuilder.Append(_0005_2000._0002(1402795979));
			stringBuilder.Append(_0005_2000._0002(1402795808));
			stringBuilder.Append(_0005_2000._0002(1402795797));
			stringBuilder.Append(_0005_2000._0002(1402795780));
			stringBuilder.Append(_0005_2000._0002(1402795897));
			stringBuilder.Append(_0005_2000._0002(1402795882));
			stringBuilder.Append(_0005_2000._0002(1402795843));
			stringBuilder.Append(_0005_2000._0002(1402795697) + model.ID);
			OleDbCommand oleDbCommand = new OleDbCommand(stringBuilder.ToString(), oleDbConnection);
			OleDbParameter[] array = new OleDbParameter[19]
			{
				new OleDbParameter(_0005_2000._0002(1402784366), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792577), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792689), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792675), OleDbType.Integer),
				new OleDbParameter(_0005_2000._0002(1402792659), OleDbType.Integer),
				new OleDbParameter(_0005_2000._0002(1402792641), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792497), OleDbType.Date),
				new OleDbParameter(_0005_2000._0002(1402792483), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402789889), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792465), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792449), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792462), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402790003), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402789990), OleDbType.Date),
				new OleDbParameter(_0005_2000._0002(1402789977), OleDbType.Date),
				new OleDbParameter(_0005_2000._0002(1402789958), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792575), OleDbType.VarBinary),
				new OleDbParameter(_0005_2000._0002(1402792558), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792517), OleDbType.VarWChar)
			};
			array[0].Value = model.SealName;
			array[1].Value = model.SealType;
			array[2].Value = model.SignerName;
			array[3].Value = model.SignerID;
			array[4].Value = model.DeptID;
			array[5].Value = model.DeptName;
			array[6].Value = DateTime.Now;
			array[7].Value = model.Status;
			array[8].Value = model.Description;
			array[9].Value = model.AuthType;
			array[10].Value = model.IssueTo;
			array[11].Value = model.IssueBy;
			array[12].Value = model.CertSerialNum;
			if (model.ValidFrom == string.Empty)
			{
				array[13].Value = DBNull.Value;
			}
			else
			{
				array[13].Value = DateTime.Parse(model.ValidFrom);
			}
			if (model.ValidTo == string.Empty)
			{
				array[14].Value = DBNull.Value;
			}
			else
			{
				array[14].Value = DateTime.Parse(model.ValidTo);
			}
			array[15].Value = model.CertPKCS7;
			if (model.SealImage != null)
			{
				array[16].Value = model.SealImage;
			}
			else
			{
				array[16].Value = DBNull.Value;
			}
			array[17].Value = model.SealImageType;
			array[18].Value = _0005_2000._0002(1402795440);
			OleDbParameter[] array2 = array;
			foreach (OleDbParameter value in array2)
			{
				oleDbCommand.Parameters.Add(value);
			}
			int num = oleDbCommand.ExecuteNonQuery();
			oleDbCommand.Parameters.Clear();
			if (num > 0)
			{
				flag = true;
				_0002(oleDbConnection, model.ID);
				_0002(oleDbConnection, _0005_2000._0002(1402795680), _0005_2000._0002(1402793932) + model.SealName + _0005_2000._0002(1402790374) + model.ID + _0005_2000._0002(1402795665));
			}
			else
			{
				flag = false;
			}
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
		oleDbConnection.Close();
		return flag;
	}

	public Seal GetModel(int sealID)
	{
		Seal seal = null;
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0003);
		try
		{
			string cmdText = _0005_2000._0002(1402793376) + sealID;
			OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
			oleDbConnection.Open();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (oleDbDataReader.Read())
			{
				seal = new Seal();
				seal._0002 = sealID;
				seal.SealName = oleDbDataReader[_0005_2000._0002(1402784802)].ToString();
				seal.SealType = oleDbDataReader[_0005_2000._0002(1402784787)].ToString();
				seal.SignerName = oleDbDataReader[_0005_2000._0002(1402784768)].ToString();
				seal.SignerID = int.Parse(oleDbDataReader[_0005_2000._0002(1402784883)].ToString());
				seal.DeptID = int.Parse(oleDbDataReader[_0005_2000._0002(1402784864)].ToString());
				seal.DeptName = oleDbDataReader[_0005_2000._0002(1402784879)].ToString();
				seal._0002_2000 = (DateTime)oleDbDataReader[_0005_2000._0002(1402790677)];
				seal._0003_2000 = (DateTime)oleDbDataReader[_0005_2000._0002(1402795656)];
				seal._0005_2000 = oleDbDataReader[_0005_2000._0002(1402784860)].ToString();
				seal.Description = oleDbDataReader[_0005_2000._0002(1402790660)].ToString();
				seal.AuthType = oleDbDataReader[_0005_2000._0002(1402784843)].ToString();
				seal.IssueTo = oleDbDataReader[_0005_2000._0002(1402785720)].ToString();
				seal.IssueBy = oleDbDataReader[_0005_2000._0002(1402785702)].ToString();
				seal.CertSerialNum = oleDbDataReader[_0005_2000._0002(1402785684)].ToString();
				seal.ValidFrom = oleDbDataReader[_0005_2000._0002(1402785672)].ToString();
				seal.ValidTo = oleDbDataReader[_0005_2000._0002(1402785784)].ToString();
				seal.CertPKCS7 = oleDbDataReader[_0005_2000._0002(1402785766)].ToString();
				if (oleDbDataReader[_0005_2000._0002(1402785750)] != DBNull.Value)
				{
					seal.SealImage = (byte[])oleDbDataReader[_0005_2000._0002(1402785750)];
				}
				seal.SealImageType = oleDbDataReader[_0005_2000._0002(1402795771)].ToString();
			}
			oleDbDataReader.Close();
		}
		catch (OleDbException ex)
		{
			throw new Exception(ex.Message);
		}
		oleDbConnection.Close();
		return seal;
	}

	public List<Seal> GetQueryCollection(string strWhereSql)
	{
		List<Seal> list = new List<Seal>();
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0003);
		try
		{
			string cmdText = _0005_2000._0002(1402795759) + strWhereSql;
			OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
			oleDbConnection.Open();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			while (oleDbDataReader.Read())
			{
				Seal seal = new Seal();
				seal._0002 = int.Parse(oleDbDataReader[_0005_2000._0002(1402784054)].ToString());
				seal.SealName = oleDbDataReader[_0005_2000._0002(1402784802)].ToString();
				seal.SealType = oleDbDataReader[_0005_2000._0002(1402784787)].ToString();
				seal.SignerName = oleDbDataReader[_0005_2000._0002(1402784768)].ToString();
				seal.SignerID = int.Parse(oleDbDataReader[_0005_2000._0002(1402784883)].ToString());
				seal.DeptID = int.Parse(oleDbDataReader[_0005_2000._0002(1402784864)].ToString());
				seal.DeptName = oleDbDataReader[_0005_2000._0002(1402784879)].ToString();
				seal._0002_2000 = (DateTime)oleDbDataReader[_0005_2000._0002(1402790677)];
				seal._0003_2000 = (DateTime)oleDbDataReader[_0005_2000._0002(1402795656)];
				seal._0005_2000 = oleDbDataReader[_0005_2000._0002(1402784860)].ToString();
				seal.Description = oleDbDataReader[_0005_2000._0002(1402790660)].ToString();
				seal.AuthType = oleDbDataReader[_0005_2000._0002(1402784843)].ToString();
				seal.IssueTo = oleDbDataReader[_0005_2000._0002(1402785720)].ToString();
				seal.IssueBy = oleDbDataReader[_0005_2000._0002(1402785702)].ToString();
				seal.CertSerialNum = oleDbDataReader[_0005_2000._0002(1402785684)].ToString();
				seal.ValidFrom = oleDbDataReader[_0005_2000._0002(1402785672)].ToString();
				seal.ValidTo = oleDbDataReader[_0005_2000._0002(1402785784)].ToString();
				seal.CertPKCS7 = oleDbDataReader[_0005_2000._0002(1402785766)].ToString();
				if (oleDbDataReader[_0005_2000._0002(1402785750)] != DBNull.Value)
				{
					seal.SealImage = (byte[])oleDbDataReader[_0005_2000._0002(1402785750)];
				}
				seal.SealImageType = oleDbDataReader[_0005_2000._0002(1402795771)].ToString();
				list.Add(seal);
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

	private void _0002(string _0002)
	{
		string text = string.Empty;
		int num = _0002.IndexOf(_0005_2000._0002(1402794373), 0, _0002.Length);
		if (num != -1)
		{
			this.m__0005 = _0002.Substring(0, num);
			text = _0002.Substring(num, _0002.Length - num);
		}
		string text2 = string.Empty;
		int num2 = text.IndexOf(_0005_2000._0002(1402794382), 0, text.Length);
		if (num2 != -1)
		{
			num = text.IndexOf(_0005_2000._0002(1402794489), 0, num2);
			if (num != -1)
			{
				text2 = text.Substring(0, num);
				_000E = text.Substring(num, text.Length - num);
			}
			else
			{
				num = text.IndexOf(_0005_2000._0002(1402794469), 0, num2);
				if (num != -1)
				{
					text2 = text.Substring(0, num);
					_000E = text.Substring(num, text.Length - num);
				}
				else
				{
					num = text.IndexOf(_0005_2000._0002(1402794449), 0, num2);
					if (num != -1)
					{
						text2 = text.Substring(0, num);
						_000E = text.Substring(num, text.Length - num);
					}
				}
			}
		}
		else
		{
			text2 = text;
		}
		num = text2.IndexOf(_0005_2000._0002(1402794460), 0, text2.Length);
		if (num != -1)
		{
			_0008 = text2.Substring(0, num);
			_0006 = text2.Substring(num, text2.Length - num);
		}
		else
		{
			_0008 = text2;
		}
	}

	public List<Seal> GetQueryCollection(string strWhereSql, int PageIndex, int PageSize, out int RecordCount)
	{
		if (PageIndex < 1)
		{
			throw new Exception(_0005_2000._0002(1402794440));
		}
		List<Seal> list = new List<Seal>();
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0003);
		try
		{
			string text = _0005_2000._0002(1402795759) + strWhereSql.ToLower();
			_0002(text);
			OleDbCommand oleDbCommand = new OleDbCommand(text, oleDbConnection);
			oleDbConnection.Open();
			text = _0005_2000._0002(1402794247) + _0008 + _0006;
			oleDbCommand.CommandText = text;
			RecordCount = int.Parse(oleDbCommand.ExecuteScalar().ToString());
			text = _0005_2000._0002(1402794364) + PageSize + _0005_2000._0002(1402765371) + this.m__0005.Remove(0, 6) + _0008;
			if (PageIndex > 1)
			{
				text = text + _0005_2000._0002(1402794350) + PageSize * (PageIndex - 1) + _0005_2000._0002(1402794162) + _0008 + _0006 + _000E + _0005_2000._0002(1402794175);
				if (_0006 != string.Empty)
				{
					text = text + _0005_2000._0002(1402794150) + _0006.Remove(0, 5);
				}
			}
			else
			{
				text = text + _0005_2000._0002(1402765371) + _0006;
			}
			text += _000E;
			oleDbCommand.CommandText = text;
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			while (oleDbDataReader.Read())
			{
				Seal seal = new Seal();
				seal._0002 = int.Parse(oleDbDataReader[_0005_2000._0002(1402784054)].ToString());
				seal.SealName = oleDbDataReader[_0005_2000._0002(1402784802)].ToString();
				seal.SealType = oleDbDataReader[_0005_2000._0002(1402784787)].ToString();
				seal.SignerName = oleDbDataReader[_0005_2000._0002(1402784768)].ToString();
				seal.SignerID = int.Parse(oleDbDataReader[_0005_2000._0002(1402784883)].ToString());
				seal.DeptID = int.Parse(oleDbDataReader[_0005_2000._0002(1402784864)].ToString());
				seal.DeptName = oleDbDataReader[_0005_2000._0002(1402784879)].ToString();
				seal._0002_2000 = (DateTime)oleDbDataReader[_0005_2000._0002(1402790677)];
				seal._0003_2000 = (DateTime)oleDbDataReader[_0005_2000._0002(1402795656)];
				seal._0005_2000 = oleDbDataReader[_0005_2000._0002(1402784860)].ToString();
				seal.Description = oleDbDataReader[_0005_2000._0002(1402790660)].ToString();
				seal.AuthType = oleDbDataReader[_0005_2000._0002(1402784843)].ToString();
				seal.IssueTo = oleDbDataReader[_0005_2000._0002(1402785720)].ToString();
				seal.IssueBy = oleDbDataReader[_0005_2000._0002(1402785702)].ToString();
				seal.CertSerialNum = oleDbDataReader[_0005_2000._0002(1402785684)].ToString();
				seal.ValidFrom = oleDbDataReader[_0005_2000._0002(1402785672)].ToString();
				seal.ValidTo = oleDbDataReader[_0005_2000._0002(1402785784)].ToString();
				seal.CertPKCS7 = oleDbDataReader[_0005_2000._0002(1402785766)].ToString();
				if (oleDbDataReader[_0005_2000._0002(1402785750)] != DBNull.Value)
				{
					seal.SealImage = (byte[])oleDbDataReader[_0005_2000._0002(1402785750)];
				}
				seal.SealImageType = oleDbDataReader[_0005_2000._0002(1402795771)].ToString();
				list.Add(seal);
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
