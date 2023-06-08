using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace PageOffice.ZoomSeal;

public class UserManager
{
	private string m__0002;

	private string m__0003 = string.Empty;

	private string m__0005 = string.Empty;

	private string _0008 = string.Empty;

	private string _0006 = string.Empty;

	private int _000E = 1;

	private bool _000F;

	public string DBConnectionString
	{
		get
		{
			return this.m__0002;
		}
		set
		{
			this.m__0002 = value;
			string text = value.ToLower();
			if (text.IndexOf(_0005_2000._0002(1402785166)) > -1 || text.IndexOf(_0005_2000._0002(1402785256)) > -1 || text.IndexOf(_0005_2000._0002(1402785218)) > -1)
			{
				_000F = true;
			}
		}
	}

	public int OPUserID
	{
		set
		{
			_000E = value;
		}
	}

	private void _0002(OleDbConnection _0002, string _0003, string _0005)
	{
		if (this.m__0002.ToLower().IndexOf(_0005_2000._0002(1402787302)) > -1)
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
			string cmdText = _0005_2000._0002(1402791657) + _000E;
			OleDbCommand oleDbCommand = new OleDbCommand(cmdText, _0002);
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (oleDbDataReader.Read())
			{
				text = oleDbDataReader[_0005_2000._0002(1402775114)].ToString();
			}
			oleDbDataReader.Close();
			cmdText = _0005_2000._0002(1402791479);
			cmdText = cmdText + _0005_2000._0002(1402787744) + DateTime.Now.ToString(_0005_2000._0002(1402781919)) + _0005_2000._0002(1402787043) + _000E + _0005_2000._0002(1402787011) + text + _0005_2000._0002(1402787018) + _0003 + _0005_2000._0002(1402787018) + _0005 + _0005_2000._0002(1402786868);
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
			string cmdText = _0005_2000._0002(1402791657) + _000E;
			OleDbCommand oleDbCommand = new OleDbCommand(cmdText, _0002);
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (oleDbDataReader.Read())
			{
				text = oleDbDataReader[_0005_2000._0002(1402775114)].ToString();
			}
			oleDbDataReader.Close();
			cmdText = _0005_2000._0002(1402790416);
			cmdText = cmdText + _0005_2000._0002(1402790494) + _000E + _0005_2000._0002(1402787011) + text + _0005_2000._0002(1402787018) + _0003 + _0005_2000._0002(1402787018) + _0005 + _0005_2000._0002(1402786868);
			oleDbCommand = new OleDbCommand(cmdText, _0002);
			oleDbCommand.ExecuteNonQuery();
		}
		catch (OleDbException ex)
		{
			throw new Exception(ex.Message);
		}
	}

	private string _0002(string _0002)
	{
		return _0003_2000._0003_2000(_0002);
	}

	public string CleanSQLParam(string Param)
	{
		return _0003_2000._0002_2000(Param);
	}

	public bool Delete(int userID)
	{
		bool flag = false;
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0002);
		try
		{
			string cmdText = _0005_2000._0002(1402794118) + userID;
			OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
			oleDbConnection.Open();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (oleDbDataReader.Read())
			{
				cmdText = _0005_2000._0002(1402794199) + userID;
				string text = oleDbDataReader[_0005_2000._0002(1402775114)].ToString();
				oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
				oleDbCommand.ExecuteNonQuery();
				flag = true;
				_0002(oleDbConnection, _0005_2000._0002(1402794041), _0005_2000._0002(1402794022) + text + _0005_2000._0002(1402790374) + userID + _0005_2000._0002(1402794009));
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

	public bool Exists(int userID)
	{
		bool flag = false;
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0002);
		try
		{
			string cmdText = _0005_2000._0002(1402793998) + userID;
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

	public int Exists(string userName)
	{
		int result = -1;
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0002);
		try
		{
			string cmdText = _0005_2000._0002(1402785455);
			OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
			oleDbCommand.Parameters.Add(_0005_2000._0002(1402785395), OleDbType.VarWChar).Value = userName;
			oleDbConnection.Open();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (oleDbDataReader.Read())
			{
				result = int.Parse(oleDbDataReader[_0005_2000._0002(1402784054)].ToString());
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

	public int Add(User model)
	{
		if (this.m__0002.ToLower().IndexOf(_0005_2000._0002(1402787302)) > -1)
		{
			return _0003(model);
		}
		return _0002(model);
	}

	private int _0002(User _0002)
	{
		if (_0002.UserName == null || _0002.UserName == string.Empty)
		{
			throw new Exception(_0005_2000._0002(1402794069));
		}
		int num = -1;
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0002);
		try
		{
			oleDbConnection.Open();
			StringBuilder stringBuilder = new StringBuilder(_0005_2000._0002(1402794918));
			if (_000F)
			{
				stringBuilder.Append(_0005_2000._0002(1402794881));
			}
			else
			{
				stringBuilder.Append(_0005_2000._0002(1402794764));
			}
			stringBuilder.Append(_0005_2000._0002(1402794745));
			OleDbCommand oleDbCommand = new OleDbCommand(stringBuilder.ToString(), oleDbConnection);
			OleDbParameter[] array = new OleDbParameter[17]
			{
				new OleDbParameter(_0005_2000._0002(1402785395), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402785379), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792659), OleDbType.Integer),
				new OleDbParameter(_0005_2000._0002(1402792641), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402789935), OleDbType.Date),
				new OleDbParameter(_0005_2000._0002(1402792497), OleDbType.Date),
				new OleDbParameter(_0005_2000._0002(1402794696), OleDbType.Integer),
				new OleDbParameter(_0005_2000._0002(1402794550), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402794534), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402794518), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402794498), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402794511), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402794616), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402794599), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402794584), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402789958), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792483), OleDbType.VarWChar)
			};
			array[0].Value = _0002.UserName;
			array[1].Value = this._0002((_0002._0005 == string.Empty) ? _0005_2000._0002(1402794562) : (_0002._0005 + _0005_2000._0002(1402785363)));
			array[2].Value = _0002.DeptID;
			array[3].Value = _0002.DeptName;
			array[4].Value = DateTime.Now;
			array[5].Value = DateTime.Now;
			array[6].Value = _0002.RoleID;
			array[7].Value = _0002.RoleName;
			array[8].Value = _0002.EmployNo;
			array[9].Value = _0002.Duty;
			array[10].Value = _0002.Sex;
			array[11].Value = _0002.Tel;
			array[12].Value = _0002.Email;
			array[13].Value = _0002.Description;
			array[14].Value = _0002.IP;
			array[15].Value = _0002.CertPKCS7;
			array[16].Value = _0002.Status;
			OleDbParameter[] array2 = array;
			foreach (OleDbParameter value in array2)
			{
				oleDbCommand.Parameters.Add(value);
			}
			oleDbCommand.ExecuteNonQuery();
			oleDbCommand.Parameters.Clear();
			oleDbCommand.CommandText = _0005_2000._0002(1402787336);
			object obj = oleDbCommand.ExecuteScalar();
			if (object.Equals(obj, null) || object.Equals(obj, DBNull.Value))
			{
				num = -1;
			}
			else
			{
				num = int.Parse(obj.ToString());
				this._0002(oleDbConnection, _0005_2000._0002(1402797489), _0005_2000._0002(1402794022) + _0002.UserName + _0005_2000._0002(1402790374) + num + _0005_2000._0002(1402797502));
			}
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
		oleDbConnection.Close();
		return num;
	}

	private int _0003(User _0002)
	{
		if (_0002.UserName == null || _0002.UserName == string.Empty)
		{
			throw new Exception(_0005_2000._0002(1402794069));
		}
		int num = -1;
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0002);
		try
		{
			oleDbConnection.Open();
			OleDbCommand oleDbCommand = new OleDbCommand(_0005_2000._0002(1402797465), oleDbConnection);
			decimal num2 = (decimal)oleDbCommand.ExecuteScalar();
			num = (int)num2;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
		try
		{
			StringBuilder stringBuilder = new StringBuilder(_0005_2000._0002(1402794918));
			stringBuilder.Append(_0005_2000._0002(1402797536));
			stringBuilder.Append(_0005_2000._0002(1402797422));
			OleDbCommand oleDbCommand2 = new OleDbCommand(stringBuilder.ToString(), oleDbConnection);
			OleDbParameter[] array = new OleDbParameter[18]
			{
				new OleDbParameter(_0005_2000._0002(1402785395), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402785379), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792659), OleDbType.Integer),
				new OleDbParameter(_0005_2000._0002(1402792641), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402789935), OleDbType.Date),
				new OleDbParameter(_0005_2000._0002(1402792497), OleDbType.Date),
				new OleDbParameter(_0005_2000._0002(1402794696), OleDbType.Integer),
				new OleDbParameter(_0005_2000._0002(1402794550), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402794534), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402794518), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402794498), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402794511), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402794616), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402794599), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402794584), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402789958), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792483), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402786212), OleDbType.Integer)
			};
			array[0].Value = _0002.UserName;
			array[1].Value = this._0002((_0002._0005 == string.Empty) ? _0005_2000._0002(1402794562) : (_0002._0005 + _0005_2000._0002(1402785363)));
			array[2].Value = _0002.DeptID;
			array[3].Value = _0002.DeptName;
			array[4].Value = DateTime.Now;
			array[5].Value = DateTime.Now;
			array[6].Value = _0002.RoleID;
			array[7].Value = _0002.RoleName;
			array[8].Value = _0002.EmployNo;
			array[9].Value = _0002.Duty;
			array[10].Value = _0002.Sex;
			array[11].Value = _0002.Tel;
			array[12].Value = _0002.Email;
			array[13].Value = _0002.Description;
			array[14].Value = _0002.IP;
			array[15].Value = _0002.CertPKCS7;
			array[16].Value = _0002.Status;
			array[17].Value = num;
			OleDbParameter[] array2 = array;
			foreach (OleDbParameter value in array2)
			{
				oleDbCommand2.Parameters.Add(value);
			}
			oleDbCommand2.ExecuteNonQuery();
			oleDbCommand2.Parameters.Clear();
			this._0002(oleDbConnection, _0005_2000._0002(1402797489), _0005_2000._0002(1402794022) + _0002.UserName + _0005_2000._0002(1402790374) + num + _0005_2000._0002(1402797502));
		}
		catch (Exception ex2)
		{
			throw new Exception(ex2.Message);
		}
		oleDbConnection.Close();
		return num;
	}

	public bool Update(User model)
	{
		if (model.UserName == null || model.UserName == string.Empty)
		{
			throw new Exception(_0005_2000._0002(1402797219));
		}
		bool flag = false;
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0002);
		try
		{
			oleDbConnection.Open();
			StringBuilder stringBuilder = new StringBuilder(_0005_2000._0002(1402797298));
			stringBuilder.Append(_0005_2000._0002(1402797290));
			if (_000F)
			{
				stringBuilder.Append(_0005_2000._0002(1402797276));
			}
			else
			{
				stringBuilder.Append(_0005_2000._0002(1402797104));
			}
			stringBuilder.Append(_0005_2000._0002(1402795098));
			stringBuilder.Append(_0005_2000._0002(1402795082));
			stringBuilder.Append(_0005_2000._0002(1402795964));
			stringBuilder.Append(_0005_2000._0002(1402797090));
			stringBuilder.Append(_0005_2000._0002(1402797074));
			stringBuilder.Append(_0005_2000._0002(1402797060));
			stringBuilder.Append(_0005_2000._0002(1402797174));
			stringBuilder.Append(_0005_2000._0002(1402797156));
			stringBuilder.Append(_0005_2000._0002(1402797139));
			stringBuilder.Append(_0005_2000._0002(1402797150));
			stringBuilder.Append(_0005_2000._0002(1402795904));
			stringBuilder.Append(_0005_2000._0002(1402797135));
			stringBuilder.Append(_0005_2000._0002(1402795780));
			stringBuilder.Append(_0005_2000._0002(1402798011));
			stringBuilder.Append(_0005_2000._0002(1402795697) + model.ID);
			OleDbCommand oleDbCommand = new OleDbCommand(stringBuilder.ToString(), oleDbConnection);
			OleDbParameter[] array = new OleDbParameter[16]
			{
				new OleDbParameter(_0005_2000._0002(1402785395), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402785379), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792659), OleDbType.Integer),
				new OleDbParameter(_0005_2000._0002(1402792641), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792497), OleDbType.Date),
				new OleDbParameter(_0005_2000._0002(1402794696), OleDbType.Integer),
				new OleDbParameter(_0005_2000._0002(1402794550), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402794534), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402794518), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402794498), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402794511), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402794616), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402794599), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402794584), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402789958), OleDbType.VarWChar),
				new OleDbParameter(_0005_2000._0002(1402792483), OleDbType.VarWChar)
			};
			array[0].Value = model.UserName;
			if (model._0005 != string.Empty)
			{
				array[1].Value = _0002(model._0005 + _0005_2000._0002(1402785363));
			}
			else
			{
				array[1].Value = model._0008;
			}
			array[2].Value = model.DeptID;
			array[3].Value = model.DeptName;
			array[4].Value = DateTime.Now;
			array[5].Value = model.RoleID;
			array[6].Value = model.RoleName;
			array[7].Value = model.EmployNo;
			array[8].Value = model.Duty;
			array[9].Value = model.Sex;
			array[10].Value = model.Tel;
			array[11].Value = model.Email;
			array[12].Value = model.Description;
			array[13].Value = model.IP;
			array[14].Value = model.CertPKCS7;
			array[15].Value = model.Status;
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
				_0002(oleDbConnection, _0005_2000._0002(1402797992), _0005_2000._0002(1402794022) + model.UserName + _0005_2000._0002(1402790374) + model.ID + _0005_2000._0002(1402797977));
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

	public User GetModel(int userId)
	{
		User user = null;
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0002);
		try
		{
			string empty = string.Empty;
			empty = ((!_000F) ? (_0005_2000._0002(1402797912) + userId) : (_0005_2000._0002(1402798064) + userId));
			OleDbCommand oleDbCommand = new OleDbCommand(empty, oleDbConnection);
			oleDbConnection.Open();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (oleDbDataReader.Read())
			{
				user = new User();
				user._0002 = userId;
				user.UserName = oleDbDataReader[_0005_2000._0002(1402775114)].ToString();
				user._0008 = oleDbDataReader[_0005_2000._0002(1402797630)].ToString();
				user.DeptID = int.Parse(oleDbDataReader[_0005_2000._0002(1402784864)].ToString());
				user.DeptName = oleDbDataReader[_0005_2000._0002(1402784879)].ToString();
				user._000F = (DateTime)oleDbDataReader[_0005_2000._0002(1402790677)];
				user._0002_2000 = (DateTime)oleDbDataReader[_0005_2000._0002(1402795656)];
				user.RoleID = int.Parse(oleDbDataReader[_0005_2000._0002(1402797615)].ToString());
				user.RoleName = oleDbDataReader[_0005_2000._0002(1402797594)].ToString();
				user.EmployNo = oleDbDataReader[_0005_2000._0002(1402797579)].ToString();
				user.Duty = oleDbDataReader[_0005_2000._0002(1402797688)].ToString();
				user.Sex = oleDbDataReader[_0005_2000._0002(1402797669)].ToString();
				user.Tel = oleDbDataReader[_0005_2000._0002(1402797679)].ToString();
				user.Email = oleDbDataReader[_0005_2000._0002(1402797657)].ToString();
				user.Description = oleDbDataReader[_0005_2000._0002(1402790660)].ToString();
				user.IP = oleDbDataReader[_0005_2000._0002(1402797637)].ToString();
				user.CertPKCS7 = oleDbDataReader[_0005_2000._0002(1402785766)].ToString();
				user.Status = oleDbDataReader[_0005_2000._0002(1402784860)].ToString();
			}
			oleDbDataReader.Close();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
		oleDbConnection.Close();
		return user;
	}

	public bool ChangeUserPassword(int UserID, string OldPassword, string NewPassword)
	{
		bool flag = false;
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0002);
		try
		{
			string text = UserID.ToString();
			string empty = string.Empty;
			empty = ((!_000F) ? (_0005_2000._0002(1402793998) + text + _0005_2000._0002(1402796452)) : (_0005_2000._0002(1402793998) + text + _0005_2000._0002(1402797644)));
			OleDbCommand oleDbCommand = new OleDbCommand(empty, oleDbConnection);
			oleDbCommand.Parameters.Add(_0005_2000._0002(1402785379), OleDbType.VarWChar).Value = _0002(OldPassword + _0005_2000._0002(1402785363));
			oleDbConnection.Open();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (oleDbDataReader.Read())
			{
				empty = ((!_000F) ? (_0005_2000._0002(1402787830) + text) : (_0005_2000._0002(1402787752) + text));
				oleDbCommand = new OleDbCommand(empty, oleDbConnection);
				oleDbCommand.Parameters.Add(_0005_2000._0002(1402785379), OleDbType.VarWChar).Value = _0002(NewPassword + _0005_2000._0002(1402785363));
				oleDbCommand.ExecuteNonQuery();
				flag = true;
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

	public int Login(string UserName, string Password)
	{
		int num = -1;
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0002);
		try
		{
			string empty = string.Empty;
			empty = ((!_000F) ? _0005_2000._0002(1402785334) : _0005_2000._0002(1402785531));
			OleDbCommand oleDbCommand = new OleDbCommand(empty, oleDbConnection);
			oleDbCommand.Parameters.Add(_0005_2000._0002(1402785395), OleDbType.VarWChar).Value = UserName;
			oleDbCommand.Parameters.Add(_0005_2000._0002(1402785379), OleDbType.VarWChar).Value = _0002(Password + _0005_2000._0002(1402785363));
			oleDbConnection.Open();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			num = ((!oleDbDataReader.Read()) ? (-1) : int.Parse(oleDbDataReader[_0005_2000._0002(1402784054)].ToString()));
			oleDbDataReader.Close();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
		oleDbConnection.Close();
		return num;
	}

	public List<User> GetQueryCollection(string strWhereSql)
	{
		List<User> list = new List<User>();
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0002);
		try
		{
			string empty = string.Empty;
			empty = ((!_000F) ? (_0005_2000._0002(1402796412) + strWhereSql) : (_0005_2000._0002(1402796442) + strWhereSql));
			OleDbCommand oleDbCommand = new OleDbCommand(empty, oleDbConnection);
			oleDbConnection.Open();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			while (oleDbDataReader.Read())
			{
				User user = new User();
				user._0002 = int.Parse(oleDbDataReader[_0005_2000._0002(1402784054)].ToString());
				user.UserName = oleDbDataReader[_0005_2000._0002(1402775114)].ToString();
				user._0008 = oleDbDataReader[_0005_2000._0002(1402797630)].ToString();
				user.DeptID = int.Parse(oleDbDataReader[_0005_2000._0002(1402784864)].ToString());
				user.DeptName = oleDbDataReader[_0005_2000._0002(1402784879)].ToString();
				user._000F = (DateTime)oleDbDataReader[_0005_2000._0002(1402790677)];
				user._0002_2000 = (DateTime)oleDbDataReader[_0005_2000._0002(1402795656)];
				user.RoleID = int.Parse(oleDbDataReader[_0005_2000._0002(1402797615)].ToString());
				user.RoleName = oleDbDataReader[_0005_2000._0002(1402797594)].ToString();
				user.EmployNo = oleDbDataReader[_0005_2000._0002(1402797579)].ToString();
				user.Duty = oleDbDataReader[_0005_2000._0002(1402797688)].ToString();
				user.Sex = oleDbDataReader[_0005_2000._0002(1402797669)].ToString();
				user.Tel = oleDbDataReader[_0005_2000._0002(1402797679)].ToString();
				user.Email = oleDbDataReader[_0005_2000._0002(1402797657)].ToString();
				user.Description = oleDbDataReader[_0005_2000._0002(1402790660)].ToString();
				user.IP = oleDbDataReader[_0005_2000._0002(1402797637)].ToString();
				user.CertPKCS7 = oleDbDataReader[_0005_2000._0002(1402785766)].ToString();
				user.Status = oleDbDataReader[_0005_2000._0002(1402784860)].ToString();
				list.Add(user);
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
			this.m__0003 = _0002.Substring(0, num);
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
				_0006 = text.Substring(num, text.Length - num);
			}
			else
			{
				num = text.IndexOf(_0005_2000._0002(1402794469), 0, num2);
				if (num != -1)
				{
					text2 = text.Substring(0, num);
					_0006 = text.Substring(num, text.Length - num);
				}
				else
				{
					num = text.IndexOf(_0005_2000._0002(1402794449), 0, num2);
					if (num != -1)
					{
						text2 = text.Substring(0, num);
						_0006 = text.Substring(num, text.Length - num);
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
			this.m__0005 = text2.Substring(0, num);
			_0008 = text2.Substring(num, text2.Length - num);
		}
		else
		{
			this.m__0005 = text2;
		}
	}

	public List<User> GetQueryCollection(string strWhereSql, int PageIndex, int PageSize, out int RecordCount)
	{
		if (PageIndex < 1)
		{
			throw new Exception(_0005_2000._0002(1402794440));
		}
		RecordCount = 0;
		List<User> list = new List<User>();
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0002);
		try
		{
			string empty = string.Empty;
			empty = ((!_000F) ? (_0005_2000._0002(1402796412) + strWhereSql.ToLower()) : (_0005_2000._0002(1402796442) + strWhereSql.ToLower()));
			_0002(empty);
			OleDbCommand oleDbCommand = new OleDbCommand(empty, oleDbConnection);
			oleDbConnection.Open();
			empty = _0005_2000._0002(1402794247) + this.m__0005 + _0008;
			oleDbCommand.CommandText = empty;
			RecordCount = int.Parse(oleDbCommand.ExecuteScalar().ToString());
			empty = _0005_2000._0002(1402794364) + PageSize + _0005_2000._0002(1402765371) + this.m__0003.Remove(0, 6) + this.m__0005;
			if (PageIndex > 1)
			{
				empty = empty + _0005_2000._0002(1402794350) + PageSize * (PageIndex - 1) + _0005_2000._0002(1402794162) + this.m__0005 + _0008 + _0006 + _0005_2000._0002(1402794175);
				if (_0008 != string.Empty)
				{
					empty = empty + _0005_2000._0002(1402794150) + _0008.Remove(0, 5);
				}
			}
			else
			{
				empty = empty + _0005_2000._0002(1402765371) + _0008;
			}
			empty += _0006;
			oleDbCommand.CommandText = empty;
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			while (oleDbDataReader.Read())
			{
				User user = new User();
				user._0002 = int.Parse(oleDbDataReader[_0005_2000._0002(1402784054)].ToString());
				user.UserName = oleDbDataReader[_0005_2000._0002(1402775114)].ToString();
				user._0008 = oleDbDataReader[_0005_2000._0002(1402797630)].ToString();
				user.DeptID = int.Parse(oleDbDataReader[_0005_2000._0002(1402784864)].ToString());
				user.DeptName = oleDbDataReader[_0005_2000._0002(1402784879)].ToString();
				user._000F = (DateTime)oleDbDataReader[_0005_2000._0002(1402790677)];
				user._0002_2000 = (DateTime)oleDbDataReader[_0005_2000._0002(1402795656)];
				user.RoleID = int.Parse(oleDbDataReader[_0005_2000._0002(1402797615)].ToString());
				user.RoleName = oleDbDataReader[_0005_2000._0002(1402797594)].ToString();
				user.EmployNo = oleDbDataReader[_0005_2000._0002(1402797579)].ToString();
				user.Duty = oleDbDataReader[_0005_2000._0002(1402797688)].ToString();
				user.Sex = oleDbDataReader[_0005_2000._0002(1402797669)].ToString();
				user.Tel = oleDbDataReader[_0005_2000._0002(1402797679)].ToString();
				user.Email = oleDbDataReader[_0005_2000._0002(1402797657)].ToString();
				user.Description = oleDbDataReader[_0005_2000._0002(1402790660)].ToString();
				user.IP = oleDbDataReader[_0005_2000._0002(1402797637)].ToString();
				user.CertPKCS7 = oleDbDataReader[_0005_2000._0002(1402785766)].ToString();
				user.Status = oleDbDataReader[_0005_2000._0002(1402784860)].ToString();
				list.Add(user);
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
