using System;
using System.Data.OleDb;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using poserverLib;

namespace PageOffice.POServer;

public class Server
{
	private HttpRequest m__0002;

	private HttpResponse m__0003;

	private HttpServerUtility m__0005;

	private string m__0008;

	private string m__0006;

	private string m__000E;

	private string m__000F;

	private string m__0002_2000;

	private string m__0003_2000;

	private bool _0005_2000;

	public string SerialNumber => this.m__0006;

	public string VersionInfo => this.m__000E;

	public string ServerVersion => global::_0003_2000._0002;

	public string Organization => this.m__000F;

	public string TrialEndTime => this.m__0002_2000;

	public string DBConnectionString
	{
		get
		{
			return this.m__0003_2000;
		}
		set
		{
			this.m__0003_2000 = value;
			string text = value.ToLower();
			if (text.IndexOf(global::_0005_2000._0002(1402785166)) > -1 || text.IndexOf(global::_0005_2000._0002(1402785256)) > -1 || text.IndexOf(global::_0005_2000._0002(1402785218)) > -1)
			{
				_0005_2000 = true;
			}
		}
	}

	public Server()
	{
		this.m__0008 = string.Empty;
		this.m__0006 = string.Empty;
		this.m__000E = string.Empty;
		this.m__000F = string.Empty;
		this.m__0002_2000 = string.Empty;
		this.m__0003_2000 = string.Empty;
	}

	private string _0002(string _0002)
	{
		byte[] array = new byte[30]
		{
			86, 0, 101, 0, 114, 0, 115, 0, 105, 0,
			111, 0, 110, 0, 58, 0, 32, 0, 66, 0,
			117, 0, 105, 0, 108, 0, 100, 0, 32, 0
		};
		byte[] array2 = new byte[4] { 161, 32, 128, 30 };
		string text = string.Empty;
		FileStream fileStream = new FileStream(_0002, FileMode.Open, FileAccess.Read);
		int num = (int)fileStream.Length;
		fileStream.Seek(num - 6000, SeekOrigin.Begin);
		bool flag = false;
		int num2 = 6000;
		byte[] array3 = new byte[num2];
		num2 = fileStream.Read(array3, 0, num2 - 10);
		for (int i = 0; i < num2; i++)
		{
			int num3 = 0;
			while (array3[i] == array[num3])
			{
				num3++;
				i++;
				if (num3 != 29)
				{
					continue;
				}
				string text2 = string.Empty;
				for (; array3[i] != array2[0]; i++)
				{
					if (array3[i] != 32 && array3[i] != 0)
					{
						text2 += (char)array3[i];
					}
				}
				text = text2;
				flag = true;
				break;
			}
			if (flag)
			{
				break;
			}
		}
		fileStream.Close();
		return text.Replace('.', ',');
	}

	public void Run()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		this.m__0002 = HttpContext.Current.Request;
		this.m__0003 = HttpContext.Current.Response;
		this.m__0005 = HttpContext.Current.Server;
		ServerClass val = new ServerClass();
		val.POPath = this.m__0005.MapPath(global::_0005_2000._0002(1402782116));
		string text = this.m__0002.Form.ToString();
		if (text != string.Empty)
		{
			if (text == global::_0005_2000._0002(1402782124))
			{
				this.m__0003.Clear();
				if (!File.Exists(this.m__0005.MapPath(global::_0005_2000._0002(1402782116)) + global::_0005_2000._0002(1402782196)))
				{
					this.m__0003.Write(global::_0005_2000._0002(1402782186));
				}
				else
				{
					this.m__0003.Write(File.ReadAllText(this.m__0005.MapPath(global::_0005_2000._0002(1402782116)) + global::_0005_2000._0002(1402782196)));
				}
				this.m__0003.End();
			}
			else if (text.StartsWith(global::_0005_2000._0002(1402782171)))
			{
				string text2 = global::_0003_2000._0002(text, global::_0005_2000._0002(1402782005), global::_0005_2000._0002(1402781987));
				if (text2 != null)
				{
					string text3 = string.Empty;
					for (int i = 0; i < this.m__0002.Cookies.Count; i++)
					{
						text3 = text3 + this.m__0002.Cookies[i].Name + global::_0005_2000._0002(1402769483);
						text3 = text3 + this.m__0002.Cookies[i].Value + global::_0005_2000._0002(1402772225);
					}
					if (text3 != string.Empty)
					{
						text3 = global::_0005_2000._0002(1402772233) + global::_0003_2000._0006(text3);
					}
					text2 = HttpUtility.UrlDecode(text2);
					string text4 = text2;
					string text5 = global::_0003_2000._0002(text, global::_0005_2000._0002(1402781995), global::_0005_2000._0002(1402781987));
					text5 = ((text5 != null) ? HttpUtility.UrlDecode(text5) : string.Empty);
					string text6 = global::_0003_2000._0002(text, global::_0005_2000._0002(1402781977), global::_0005_2000._0002(1402781987));
					text6 = ((text6 != null) ? HttpUtility.UrlDecode(text6) : string.Empty);
					this.m__0003.Clear();
					this.m__0003.ContentType = global::_0005_2000._0002(1402781956);
					this.m__0003.Write(global::_0005_2000._0002(1402781301) + text4 + global::_0005_2000._0002(1402781288) + text5.ToLower() + global::_0005_2000._0002(1402782071));
					this.m__0003.Write(global::_0005_2000._0002(1402782048) + global::_0003_2000._0006(text6) + global::_0005_2000._0002(1402782058) + global::_0003_2000._0002(text3) + global::_0005_2000._0002(1402772225));
					this.m__0003.End();
				}
			}
			else
			{
				val.Input = this.m__0005.UrlDecode(text);
				if (val.Output != string.Empty)
				{
					this.m__0003.Clear();
					this.m__0003.Write(val.Output);
					this.m__0003.End();
				}
			}
			return;
		}
		if (this.m__0002.InputStream.Length > 0)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.m__0002.InputStream);
			XmlNode xmlNode = xmlDocument.SelectSingleNode(global::_0005_2000._0002(1402782039));
			if (xmlNode == null)
			{
				return;
			}
			string innerText = xmlNode.InnerText;
			innerText = global::_0003_2000._0003(innerText);
			string[] array = Regex.Split(innerText, global::_0005_2000._0002(1402768257));
			string text7 = array[0].ToUpper();
			string text8 = global::_0005_2000._0002(1402782031);
			if (text7 == global::_0005_2000._0002(1402781883))
			{
				text8 = global::_0005_2000._0002(1402781869);
			}
			else if (text7 == global::_0005_2000._0002(1402781844))
			{
				text8 = _0002(array);
			}
			else if (text7 == global::_0005_2000._0002(1402781826))
			{
				text8 = _0003(array);
			}
			else if (text7 == global::_0005_2000._0002(1402781942))
			{
				text8 = global::_0005_2000._0002(1402781933);
				text8 = text8 + DateTime.Now.ToString(global::_0005_2000._0002(1402781919)) + global::_0005_2000._0002(1402772225);
				text8 = text8 + global::_0005_2000._0002(1402781753) + _0002() + global::_0005_2000._0002(1402772225);
				string verInfo = val.VerInfo2;
				string[] array2 = verInfo.Split(';');
				text8 = text8 + global::_0005_2000._0002(1402781736) + array2[0] + global::_0005_2000._0002(1402772225);
				text8 = text8 + global::_0005_2000._0002(1402781718) + array2[1] + global::_0005_2000._0002(1402772225);
				text8 = ((val.TrialEndTime != null) ? (text8 + global::_0005_2000._0002(1402781703)) : ((val.Organization == null) ? (text8 + global::_0005_2000._0002(1402781703)) : (text8 + global::_0005_2000._0002(1402781801))));
				text8 = text8 + global::_0005_2000._0002(1402782653) + global::_0003_2000._0006(val.Organization) + global::_0005_2000._0002(1402772225);
				text8 = text8 + global::_0005_2000._0002(1402782630) + _0005(this.m__0005.MapPath(global::_0005_2000._0002(1402782116)) + global::_0005_2000._0002(1402782611)) + global::_0005_2000._0002(1402772225);
				string text9 = this.m__0005.MapPath(global::_0005_2000._0002(1402782116)) + global::_0005_2000._0002(1402782600);
				string text10 = global::_0005_2000._0002(1402782719);
				if (!File.Exists(text9))
				{
					text10 = _0002(text9);
				}
				text8 = text8 + global::_0005_2000._0002(1402782701) + text10 + global::_0005_2000._0002(1402772225);
			}
			else if (text7 == global::_0005_2000._0002(1402782659))
			{
				text8 = _0005(array);
			}
			else if (text7 == global::_0005_2000._0002(1402782519))
			{
				text8 = _0008(array);
			}
			else if (text7 == global::_0005_2000._0002(1402782506))
			{
				text8 = _0006(array);
			}
			else if (text7 == global::_0005_2000._0002(1402782468))
			{
				text8 = _000E(array);
			}
			else if (text7 == global::_0005_2000._0002(1402782591))
			{
				text8 = _0003_2000(array);
			}
			char[] array3 = text8.ToCharArray();
			StringBuilder stringBuilder = new StringBuilder();
			char[] array4 = array3;
			foreach (char c in array4)
			{
				if (c < '\u0080')
				{
					stringBuilder.Append(c);
				}
			}
			text8 = stringBuilder.ToString();
			text8 = global::_0003_2000._0002(text8);
			this.m__0003.Clear();
			this.m__0003.Write(text8);
			this.m__0003.End();
			return;
		}
		string text11 = this.m__0002.QueryString[global::_0005_2000._0002(1402782552)];
		string text12 = this.m__0002.QueryString[global::_0005_2000._0002(1402782533)];
		if (text12 != null && text12.Length > 0)
		{
			text12 = text12.Replace(global::_0005_2000._0002(1402775068), global::_0005_2000._0002(1402775060)).Replace(global::_0005_2000._0002(1402775055), global::_0005_2000._0002(1402775047)).Replace(global::_0005_2000._0002(1402775158), global::_0005_2000._0002(1402769483));
			text12 = global::_0003_2000._0003(text12);
			if (text11 != null && text11.Equals(global::_0005_2000._0002(1402782540)))
			{
				string text13 = global::_0003_2000._0002(text12, global::_0005_2000._0002(1402782369), global::_0005_2000._0002(1402781987));
				string text14 = global::_0003_2000._0002(text12, global::_0005_2000._0002(1402782378), global::_0005_2000._0002(1402781987));
				string text15 = global::_0003_2000._0002(text12, global::_0005_2000._0002(1402782363), global::_0005_2000._0002(1402781987));
				if (text13.Length > 0 && text15.Length > 0 && text14.Length > 0)
				{
					this.m__0003.ContentType = text15;
					this.m__0003.AddHeader(global::_0005_2000._0002(1402782349), global::_0005_2000._0002(1402782439) + text14);
					text13 = text13.Replace(global::_0005_2000._0002(1402775274), string.Empty);
					text13 = text13.Replace(global::_0005_2000._0002(1402775047), string.Empty);
					text13 = this.m__0005.MapPath(global::_0005_2000._0002(1402782403) + text13);
					if (!File.Exists(text13))
					{
						throw new Exception(global::_0005_2000._0002(1402782259) + text13 + global::_0005_2000._0002(1402782244));
					}
					FileStream fileStream = new FileStream(text13, FileMode.Open, FileAccess.Read);
					int num = (int)fileStream.Length;
					this.m__0003.AddHeader(global::_0005_2000._0002(1402782231), num.ToString());
					byte[] buffer = new byte[num];
					fileStream.Read(buffer, 0, num);
					fileStream.Close();
					this.m__0003.Clear();
					this.m__0003.OutputStream.Write(buffer, 0, num);
					this.m__0003.End();
					return;
				}
			}
			else if (text11 != null && text11.Equals(global::_0005_2000._0002(1402782218)))
			{
				string text16 = global::_0003_2000._0002(text12, global::_0005_2000._0002(1402782369), global::_0005_2000._0002(1402781987));
				string text17 = global::_0003_2000._0002(text12, global::_0005_2000._0002(1402782378), global::_0005_2000._0002(1402781987));
				string text18 = global::_0003_2000._0002(text12, global::_0005_2000._0002(1402782363), global::_0005_2000._0002(1402781987));
				if (text16.Length > 0 && text18.Length > 0 && text17.Length > 0)
				{
					this.m__0003.ContentType = text18;
					this.m__0003.AddHeader(global::_0005_2000._0002(1402782349), global::_0005_2000._0002(1402782439) + this.m__0005.UrlEncode(text17));
					FileStream fileStream2 = new FileStream(text16, FileMode.Open, FileAccess.Read);
					int num2 = (int)fileStream2.Length;
					this.m__0003.AddHeader(global::_0005_2000._0002(1402782231), num2.ToString());
					byte[] buffer2 = new byte[num2];
					fileStream2.Read(buffer2, 0, num2);
					fileStream2.Close();
					this.m__0003.Clear();
					this.m__0003.OutputStream.Write(buffer2, 0, num2);
					this.m__0003.End();
					return;
				}
			}
		}
		this.m__0008 = val.StatusLog;
		if (val.SerialNumber != null)
		{
			this.m__0006 = val.SerialNumber;
			this.m__000E = val.VerInfo.Replace(global::_0005_2000._0002(1402782332), global::_0005_2000._0002(1402782310));
			this.m__000E = this.m__000E.Replace(global::_0005_2000._0002(1402782296), global::_0005_2000._0002(1402782274));
			this.m__000E = this.m__000E.Replace(global::_0005_2000._0002(1402785202), global::_0005_2000._0002(1402785212));
			this.m__000E = this.m__000E.Replace(global::_0005_2000._0002(1402785168), global::_0005_2000._0002(1402785178));
			this.m__000F = val.Organization;
			if (val.TrialEndTime != null)
			{
				this.m__0002_2000 = DateTime.Parse(val.TrialEndTime).ToString();
			}
		}
	}

	public string GetStatusLog()
	{
		return this.m__0008;
	}

	private string _0003(string _0002)
	{
		return global::_0003_2000._0003_2000(_0002);
	}

	private string _0005(string _0002)
	{
		string empty = string.Empty;
		try
		{
			FileStream stream = new FileStream(_0002, FileMode.Open, FileAccess.Read, FileShare.Read);
			StreamReader streamReader = new StreamReader(stream);
			empty = streamReader.ReadToEnd();
			empty = empty.Substring(0, empty.Length - 34);
			streamReader.Close();
			return empty;
		}
		catch
		{
			return string.Empty;
		}
	}

	private int _0002()
	{
		int num = -1;
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0003_2000);
		try
		{
			OleDbCommand oleDbCommand = new OleDbCommand(global::_0005_2000._0002(1402785083), oleDbConnection);
			oleDbConnection.Open();
			num = int.Parse(oleDbCommand.ExecuteScalar().ToString());
		}
		catch
		{
			return -1;
		}
		oleDbConnection.Close();
		return num;
	}

	private bool _0002(OleDbConnection _0002, int _0003)
	{
		bool result = false;
		try
		{
			string cmdText = global::_0005_2000._0002(1402785024) + _0003;
			OleDbCommand oleDbCommand = new OleDbCommand(cmdText, _0002);
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (oleDbDataReader.Read())
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(_0003.ToString());
				stringBuilder.Append(oleDbDataReader[global::_0005_2000._0002(1402784802)].ToString());
				stringBuilder.Append(oleDbDataReader[global::_0005_2000._0002(1402784787)].ToString());
				stringBuilder.Append(oleDbDataReader[global::_0005_2000._0002(1402784768)].ToString());
				stringBuilder.Append(oleDbDataReader[global::_0005_2000._0002(1402784883)].ToString());
				stringBuilder.Append(oleDbDataReader[global::_0005_2000._0002(1402784864)].ToString());
				stringBuilder.Append(oleDbDataReader[global::_0005_2000._0002(1402784879)].ToString());
				stringBuilder.Append(oleDbDataReader[global::_0005_2000._0002(1402784860)].ToString());
				stringBuilder.Append(oleDbDataReader[global::_0005_2000._0002(1402784843)].ToString());
				stringBuilder.Append(oleDbDataReader[global::_0005_2000._0002(1402785720)].ToString());
				stringBuilder.Append(oleDbDataReader[global::_0005_2000._0002(1402785702)].ToString());
				stringBuilder.Append(oleDbDataReader[global::_0005_2000._0002(1402785684)].ToString());
				stringBuilder.Append(oleDbDataReader[global::_0005_2000._0002(1402785672)].ToString());
				stringBuilder.Append(oleDbDataReader[global::_0005_2000._0002(1402785784)].ToString());
				stringBuilder.Append(oleDbDataReader[global::_0005_2000._0002(1402785766)].ToString());
				if (oleDbDataReader[global::_0005_2000._0002(1402785750)] != DBNull.Value)
				{
					stringBuilder.Append(Convert.ToBase64String((byte[])oleDbDataReader[global::_0005_2000._0002(1402785750)]));
				}
				stringBuilder.Append(global::_0005_2000._0002(1402785734));
				SHA1 sHA = SHA1.Create();
				byte[] bytes = Encoding.UTF8.GetBytes(stringBuilder.ToString());
				byte[] array = sHA.ComputeHash(bytes);
				sHA.Clear();
				string text = string.Empty;
				for (int i = 0; i < array.Length; i++)
				{
					text += array[i].ToString(global::_0005_2000._0002(1402785575)).PadLeft(2, '0');
				}
				if (text == oleDbDataReader[global::_0005_2000._0002(1402785583)].ToString())
				{
					result = true;
				}
				else
				{
					cmdText = global::_0005_2000._0002(1402785563) + _0003;
					oleDbCommand = new OleDbCommand(cmdText, _0002);
					oleDbCommand.ExecuteNonQuery();
				}
			}
			oleDbDataReader.Close();
			return result;
		}
		catch (OleDbException ex)
		{
			throw new Exception(ex.Message);
		}
	}

	private string _0002(string[] _0002)
	{
		string text = global::_0005_2000._0002(1402782031);
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0003_2000);
		try
		{
			string value = global::_0003_2000._000E(_0002[1]);
			string text2 = _0002[2];
			string empty = string.Empty;
			empty = (text2.Equals(global::_0005_2000._0002(1402785612)) ? global::_0005_2000._0002(1402785455) : ((!_0005_2000) ? global::_0005_2000._0002(1402785334) : global::_0005_2000._0002(1402785531)));
			OleDbCommand oleDbCommand = new OleDbCommand(empty, oleDbConnection);
			oleDbCommand.Parameters.Add(global::_0005_2000._0002(1402785395), OleDbType.VarWChar).Value = value;
			if (!text2.Equals(global::_0005_2000._0002(1402785612)))
			{
				oleDbCommand.Parameters.Add(global::_0005_2000._0002(1402785379), OleDbType.VarWChar).Value = _0003(text2 + global::_0005_2000._0002(1402785363));
			}
			oleDbConnection.Open();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (oleDbDataReader.Read())
			{
				empty = global::_0005_2000._0002(1402785347) + oleDbDataReader[global::_0005_2000._0002(1402784054)].ToString() + global::_0005_2000._0002(1402784033);
				oleDbDataReader.Close();
				oleDbCommand = new OleDbCommand(empty, oleDbConnection);
				oleDbDataReader = oleDbCommand.ExecuteReader();
				StringBuilder stringBuilder = new StringBuilder(global::_0005_2000._0002(1402784008));
				stringBuilder.Append(global::_0005_2000._0002(1402784088));
				stringBuilder.Append(global::_0005_2000._0002(1402784073));
				while (oleDbDataReader.Read())
				{
					stringBuilder.Append(global::_0005_2000._0002(1402783934));
					stringBuilder.Append(global::_0005_2000._0002(1402783889) + oleDbDataReader[global::_0005_2000._0002(1402784054)].ToString() + global::_0005_2000._0002(1402783881));
					stringBuilder.Append(global::_0005_2000._0002(1402783990) + global::_0003_2000._0006(oleDbDataReader[global::_0005_2000._0002(1402784802)].ToString()) + global::_0005_2000._0002(1402783881));
					stringBuilder.Append(global::_0005_2000._0002(1402783952) + global::_0003_2000._0006(oleDbDataReader[global::_0005_2000._0002(1402784787)].ToString()) + global::_0005_2000._0002(1402783881));
					stringBuilder.Append(global::_0005_2000._0002(1402783950) + global::_0003_2000._0006(oleDbDataReader[global::_0005_2000._0002(1402784768)].ToString()) + global::_0005_2000._0002(1402783881));
					stringBuilder.Append(global::_0005_2000._0002(1402783786) + global::_0003_2000._0006(oleDbDataReader[global::_0005_2000._0002(1402784843)].ToString()) + global::_0005_2000._0002(1402783881));
					stringBuilder.Append(global::_0005_2000._0002(1402783752) + global::_0003_2000._0006(oleDbDataReader[global::_0005_2000._0002(1402784879)].ToString()) + global::_0005_2000._0002(1402783881));
					if (this._0002(oleDbConnection, int.Parse(oleDbDataReader[global::_0005_2000._0002(1402784054)].ToString())))
					{
						stringBuilder.Append(global::_0005_2000._0002(1402783846) + global::_0003_2000._0006(oleDbDataReader[global::_0005_2000._0002(1402784860)].ToString()) + global::_0005_2000._0002(1402783881));
					}
					else
					{
						stringBuilder.Append(global::_0005_2000._0002(1402783846) + global::_0003_2000._0006(global::_0005_2000._0002(1402783810)) + global::_0005_2000._0002(1402783881));
					}
					stringBuilder.Append(global::_0005_2000._0002(1402783823) + oleDbDataReader[global::_0005_2000._0002(1402785684)].ToString() + global::_0005_2000._0002(1402783881));
					stringBuilder.Append(global::_0005_2000._0002(1402784656) + oleDbDataReader[global::_0005_2000._0002(1402785672)].ToString() + global::_0005_2000._0002(1402783881));
					stringBuilder.Append(global::_0005_2000._0002(1402784753) + oleDbDataReader[global::_0005_2000._0002(1402785784)].ToString() + global::_0005_2000._0002(1402783881));
					stringBuilder.Append(global::_0005_2000._0002(1402784748) + global::_0003_2000._0006(oleDbDataReader[global::_0005_2000._0002(1402785720)].ToString()) + global::_0005_2000._0002(1402783881));
					string text3 = string.Empty;
					if (!oleDbDataReader.IsDBNull(0))
					{
						long bytes = oleDbDataReader.GetBytes(0, 0L, null, 0, int.MaxValue);
						byte[] array = new byte[bytes];
						oleDbDataReader.GetBytes(0, 0L, array, 0, array.Length);
						text3 = Convert.ToBase64String(array);
					}
					stringBuilder.Append(global::_0005_2000._0002(1402784715) + text3 + global::_0005_2000._0002(1402783881));
					stringBuilder.Append(global::_0005_2000._0002(1402784552));
				}
				stringBuilder.Append(global::_0005_2000._0002(1402784540));
				oleDbDataReader.Close();
				stringBuilder.Append(global::_0005_2000._0002(1402784628));
				text = stringBuilder.ToString();
			}
			else
			{
				oleDbDataReader.Close();
				text = global::_0005_2000._0002(1402782186);
			}
		}
		catch (Exception ex)
		{
			return global::_0005_2000._0002(1402784612) + ex.Message;
		}
		oleDbConnection.Close();
		return text;
	}

	private string _0003(string[] _0002)
	{
		string text = global::_0005_2000._0002(1402782031);
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0003_2000);
		try
		{
			string value = global::_0003_2000._000E(_0002[1]);
			_ = _0002[2];
			string cmdText = global::_0005_2000._0002(1402784595);
			OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
			oleDbCommand.Parameters.Add(global::_0005_2000._0002(1402784366), OleDbType.VarWChar).Value = value;
			oleDbConnection.Open();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (oleDbDataReader.Read())
			{
				StringBuilder stringBuilder = new StringBuilder(global::_0005_2000._0002(1402784008));
				stringBuilder.Append(global::_0005_2000._0002(1402784088));
				stringBuilder.Append(global::_0005_2000._0002(1402784073));
				stringBuilder.Append(global::_0005_2000._0002(1402783934));
				stringBuilder.Append(global::_0005_2000._0002(1402783889) + oleDbDataReader[global::_0005_2000._0002(1402784054)].ToString() + global::_0005_2000._0002(1402783881));
				stringBuilder.Append(global::_0005_2000._0002(1402783990) + global::_0003_2000._0006(oleDbDataReader[global::_0005_2000._0002(1402784802)].ToString()) + global::_0005_2000._0002(1402783881));
				stringBuilder.Append(global::_0005_2000._0002(1402783952) + global::_0003_2000._0006(oleDbDataReader[global::_0005_2000._0002(1402784787)].ToString()) + global::_0005_2000._0002(1402783881));
				stringBuilder.Append(global::_0005_2000._0002(1402783950) + global::_0003_2000._0006(oleDbDataReader[global::_0005_2000._0002(1402784768)].ToString()) + global::_0005_2000._0002(1402783881));
				stringBuilder.Append(global::_0005_2000._0002(1402783786) + global::_0003_2000._0006(oleDbDataReader[global::_0005_2000._0002(1402784843)].ToString()) + global::_0005_2000._0002(1402783881));
				stringBuilder.Append(global::_0005_2000._0002(1402783752) + global::_0003_2000._0006(oleDbDataReader[global::_0005_2000._0002(1402784879)].ToString()) + global::_0005_2000._0002(1402783881));
				if (this._0002(oleDbConnection, int.Parse(oleDbDataReader[global::_0005_2000._0002(1402784054)].ToString())))
				{
					stringBuilder.Append(global::_0005_2000._0002(1402783846) + global::_0003_2000._0006(oleDbDataReader[global::_0005_2000._0002(1402784860)].ToString()) + global::_0005_2000._0002(1402783881));
				}
				else
				{
					stringBuilder.Append(global::_0005_2000._0002(1402783846) + global::_0003_2000._0006(global::_0005_2000._0002(1402783810)) + global::_0005_2000._0002(1402783881));
				}
				stringBuilder.Append(global::_0005_2000._0002(1402783823) + oleDbDataReader[global::_0005_2000._0002(1402785684)].ToString() + global::_0005_2000._0002(1402783881));
				stringBuilder.Append(global::_0005_2000._0002(1402784656) + oleDbDataReader[global::_0005_2000._0002(1402785672)].ToString() + global::_0005_2000._0002(1402783881));
				stringBuilder.Append(global::_0005_2000._0002(1402784753) + oleDbDataReader[global::_0005_2000._0002(1402785784)].ToString() + global::_0005_2000._0002(1402783881));
				stringBuilder.Append(global::_0005_2000._0002(1402784748) + global::_0003_2000._0006(oleDbDataReader[global::_0005_2000._0002(1402785720)].ToString()) + global::_0005_2000._0002(1402783881));
				string text2 = string.Empty;
				if (!oleDbDataReader.IsDBNull(0))
				{
					long bytes = oleDbDataReader.GetBytes(0, 0L, null, 0, int.MaxValue);
					byte[] array = new byte[bytes];
					oleDbDataReader.GetBytes(0, 0L, array, 0, array.Length);
					text2 = Convert.ToBase64String(array);
				}
				stringBuilder.Append(global::_0005_2000._0002(1402784715) + text2 + global::_0005_2000._0002(1402783881));
				stringBuilder.Append(global::_0005_2000._0002(1402784552));
				stringBuilder.Append(global::_0005_2000._0002(1402784540));
				oleDbDataReader.Close();
				stringBuilder.Append(global::_0005_2000._0002(1402784628));
				text = stringBuilder.ToString();
			}
			else
			{
				oleDbDataReader.Close();
				text = global::_0005_2000._0002(1402782186);
			}
		}
		catch (Exception ex)
		{
			return global::_0005_2000._0002(1402784612) + ex.Message;
		}
		oleDbConnection.Close();
		return text;
	}

	private string _0005(string[] _0002)
	{
		string text = _0002[1];
		string text2 = _0002[2];
		string text3 = global::_0003_2000._000E(_0002[3]);
		string text4 = global::_0003_2000._000E(_0002[4]);
		string text5 = global::_0005_2000._0002(1402782031);
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0003_2000);
		try
		{
			string cmdText = global::_0005_2000._0002(1402784350) + text;
			OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
			oleDbConnection.Open();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (oleDbDataReader.Read())
			{
				if (this.m__0003_2000.ToLower().IndexOf(global::_0005_2000._0002(1402787302)) > -1)
				{
					cmdText = global::_0005_2000._0002(1402787285);
					cmdText = cmdText + global::_0005_2000._0002(1402787163) + text2 + global::_0005_2000._0002(1402787007);
					cmdText = ((!(text4 == global::_0005_2000._0002(1402786945))) ? (cmdText + global::_0005_2000._0002(1402787050) + oleDbDataReader[global::_0005_2000._0002(1402784802)].ToString() + global::_0005_2000._0002(1402787043)) : (cmdText + global::_0005_2000._0002(1402786954) + oleDbDataReader[global::_0005_2000._0002(1402784802)].ToString() + global::_0005_2000._0002(1402787043)));
					cmdText = cmdText + text + global::_0005_2000._0002(1402773301) + oleDbDataReader[global::_0005_2000._0002(1402784864)].ToString() + global::_0005_2000._0002(1402787011) + oleDbDataReader[global::_0005_2000._0002(1402784879)].ToString() + global::_0005_2000._0002(1402787018) + oleDbDataReader[global::_0005_2000._0002(1402784768)].ToString() + global::_0005_2000._0002(1402787018) + oleDbDataReader[global::_0005_2000._0002(1402785684)].ToString() + global::_0005_2000._0002(1402787018) + oleDbDataReader[global::_0005_2000._0002(1402785720)].ToString() + global::_0005_2000._0002(1402787018) + oleDbDataReader[global::_0005_2000._0002(1402785702)].ToString() + global::_0005_2000._0002(1402787018) + text3 + global::_0005_2000._0002(1402786868);
				}
				else
				{
					cmdText = global::_0005_2000._0002(1402786879);
					cmdText = cmdText + global::_0005_2000._0002(1402787744) + text2 + global::_0005_2000._0002(1402787043);
					cmdText = ((!(text4 == global::_0005_2000._0002(1402786945))) ? (cmdText + global::_0005_2000._0002(1402787050) + oleDbDataReader[global::_0005_2000._0002(1402784802)].ToString() + global::_0005_2000._0002(1402787043)) : (cmdText + global::_0005_2000._0002(1402786954) + oleDbDataReader[global::_0005_2000._0002(1402784802)].ToString() + global::_0005_2000._0002(1402787043)));
					cmdText = cmdText + text + global::_0005_2000._0002(1402773301) + oleDbDataReader[global::_0005_2000._0002(1402784864)].ToString() + global::_0005_2000._0002(1402787011) + oleDbDataReader[global::_0005_2000._0002(1402784879)].ToString() + global::_0005_2000._0002(1402787018) + oleDbDataReader[global::_0005_2000._0002(1402784768)].ToString() + global::_0005_2000._0002(1402787018) + oleDbDataReader[global::_0005_2000._0002(1402785684)].ToString() + global::_0005_2000._0002(1402787018) + oleDbDataReader[global::_0005_2000._0002(1402785720)].ToString() + global::_0005_2000._0002(1402787018) + oleDbDataReader[global::_0005_2000._0002(1402785702)].ToString() + global::_0005_2000._0002(1402787018) + text3 + global::_0005_2000._0002(1402786868);
				}
				oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
				oleDbCommand.ExecuteNonQuery();
			}
			oleDbDataReader.Close();
			text5 = global::_0005_2000._0002(1402781869);
		}
		catch (OleDbException ex)
		{
			throw new Exception(ex.Message);
		}
		oleDbConnection.Close();
		return text5;
	}

	private string _0008(string[] _0002)
	{
		string text = global::_0005_2000._0002(1402782031);
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0003_2000);
		try
		{
			string value = global::_0003_2000._000E(_0002[1]);
			string text2 = _0002[2];
			string text3 = _0002[3];
			string empty = string.Empty;
			empty = ((!_0005_2000) ? global::_0005_2000._0002(1402785334) : global::_0005_2000._0002(1402785531));
			OleDbCommand oleDbCommand = new OleDbCommand(empty, oleDbConnection);
			oleDbCommand.Parameters.Add(global::_0005_2000._0002(1402785395), OleDbType.VarWChar).Value = value;
			oleDbCommand.Parameters.Add(global::_0005_2000._0002(1402785379), OleDbType.VarWChar).Value = _0003(text2 + global::_0005_2000._0002(1402785363));
			oleDbConnection.Open();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			if (oleDbDataReader.Read())
			{
				empty = ((!_0005_2000) ? (global::_0005_2000._0002(1402787830) + oleDbDataReader[global::_0005_2000._0002(1402784054)].ToString()) : (global::_0005_2000._0002(1402787752) + oleDbDataReader[global::_0005_2000._0002(1402784054)].ToString()));
				oleDbCommand = new OleDbCommand(empty, oleDbConnection);
				oleDbCommand.Parameters.Add(global::_0005_2000._0002(1402785379), OleDbType.VarWChar).Value = _0003(text3 + global::_0005_2000._0002(1402785363));
				oleDbCommand.ExecuteNonQuery();
				text = global::_0005_2000._0002(1402781869);
			}
			else
			{
				text = global::_0005_2000._0002(1402782186);
			}
			oleDbDataReader.Close();
		}
		catch (Exception ex)
		{
			return global::_0005_2000._0002(1402784612) + ex.Message;
		}
		oleDbConnection.Close();
		return text;
	}

	private string _0006(string[] _0002)
	{
		string text = global::_0005_2000._0002(1402782031);
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0003_2000);
		try
		{
			string value = _0002[1];
			string cmdText = global::_0005_2000._0002(1402787778);
			oleDbConnection.Open();
			OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
			oleDbCommand.Parameters.Add(global::_0005_2000._0002(1402787593), OleDbType.VarWChar).Value = value;
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			StringBuilder stringBuilder = new StringBuilder(global::_0005_2000._0002(1402784008));
			stringBuilder.Append(global::_0005_2000._0002(1402784088));
			stringBuilder.Append(global::_0005_2000._0002(1402784073));
			while (oleDbDataReader.Read())
			{
				stringBuilder.Append(global::_0005_2000._0002(1402783934));
				stringBuilder.Append(global::_0005_2000._0002(1402783889) + oleDbDataReader[global::_0005_2000._0002(1402784054)].ToString() + global::_0005_2000._0002(1402783881));
				stringBuilder.Append(global::_0005_2000._0002(1402787703) + oleDbDataReader[global::_0005_2000._0002(1402787667)].ToString() + global::_0005_2000._0002(1402783881));
				stringBuilder.Append(global::_0005_2000._0002(1402787678) + oleDbDataReader[global::_0005_2000._0002(1402787519)].ToString() + global::_0005_2000._0002(1402783881));
				stringBuilder.Append(global::_0005_2000._0002(1402784552));
			}
			stringBuilder.Append(global::_0005_2000._0002(1402787503));
			oleDbDataReader.Close();
			stringBuilder.Append(global::_0005_2000._0002(1402784628));
			text = stringBuilder.ToString();
		}
		catch (Exception ex)
		{
			return global::_0005_2000._0002(1402784612) + ex.Message;
		}
		oleDbConnection.Close();
		return text;
	}

	private string _000E(string[] _0002)
	{
		if (this.m__0003_2000.ToLower().IndexOf(global::_0005_2000._0002(1402787302)) > -1)
		{
			return _0002_2000(_0002);
		}
		return _000F(_0002);
	}

	private string _000F(string[] _0002)
	{
		string text = global::_0005_2000._0002(1402782031);
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0003_2000);
		try
		{
			string value = _0002[1];
			string value2 = _0002[2];
			_ = _0002[3];
			string text2 = _0002[4];
			string value3 = _0002[5];
			oleDbConnection.Open();
			if (text2.Equals(global::_0005_2000._0002(1402787461)))
			{
				StringBuilder stringBuilder = new StringBuilder(global::_0005_2000._0002(1402787468));
				stringBuilder.Append(global::_0005_2000._0002(1402787567));
				stringBuilder.Append(global::_0005_2000._0002(1402787532));
				stringBuilder.Append(global::_0005_2000._0002(1402787388));
				OleDbCommand oleDbCommand = new OleDbCommand(stringBuilder.ToString(), oleDbConnection);
				OleDbParameter[] array = new OleDbParameter[3]
				{
					new OleDbParameter(global::_0005_2000._0002(1402787371), OleDbType.Integer),
					new OleDbParameter(global::_0005_2000._0002(1402787593), OleDbType.VarWChar),
					new OleDbParameter(global::_0005_2000._0002(1402787353), OleDbType.VarWChar)
				};
				array[0].Value = value;
				array[1].Value = value2;
				array[2].Value = value3;
				OleDbParameter[] array2 = array;
				foreach (OleDbParameter value4 in array2)
				{
					oleDbCommand.Parameters.Add(value4);
				}
				oleDbCommand.ExecuteNonQuery();
				oleDbCommand.CommandText = global::_0005_2000._0002(1402787336);
				object obj = oleDbCommand.ExecuteScalar();
				oleDbCommand.Parameters.Clear();
				int num = -1;
				text = ((!object.Equals(obj, null) && !object.Equals(obj, DBNull.Value)) ? int.Parse(obj.ToString()) : (-1)).ToString();
			}
			else
			{
				StringBuilder stringBuilder2 = new StringBuilder(global::_0005_2000._0002(1402787424));
				stringBuilder2.Append(global::_0005_2000._0002(1402787392));
				stringBuilder2.Append(global::_0005_2000._0002(1402786226));
				OleDbCommand oleDbCommand2 = new OleDbCommand(stringBuilder2.ToString(), oleDbConnection);
				OleDbParameter[] array3 = new OleDbParameter[2]
				{
					new OleDbParameter(global::_0005_2000._0002(1402787353), OleDbType.VarWChar),
					new OleDbParameter(global::_0005_2000._0002(1402786212), OleDbType.Integer)
				};
				array3[0].Value = value3;
				array3[1].Value = text2;
				OleDbParameter[] array4 = array3;
				foreach (OleDbParameter value5 in array4)
				{
					oleDbCommand2.Parameters.Add(value5);
				}
				oleDbCommand2.ExecuteNonQuery();
				oleDbCommand2.Parameters.Clear();
				text = text2;
			}
		}
		catch (Exception ex)
		{
			return global::_0005_2000._0002(1402784612) + ex.Message;
		}
		oleDbConnection.Close();
		return text;
	}

	private string _0002_2000(string[] _0002)
	{
		string text = global::_0005_2000._0002(1402782031);
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0003_2000);
		try
		{
			string value = _0002[1];
			string value2 = _0002[2];
			_ = _0002[3];
			string text2 = _0002[4];
			string value3 = _0002[5];
			oleDbConnection.Open();
			if (text2.Equals(global::_0005_2000._0002(1402787461)))
			{
				OleDbCommand oleDbCommand = null;
				int num = -1;
				try
				{
					oleDbCommand = new OleDbCommand(global::_0005_2000._0002(1402786222), oleDbConnection);
					decimal num2 = (decimal)oleDbCommand.ExecuteScalar();
					num = (int)num2;
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}
				StringBuilder stringBuilder = new StringBuilder(global::_0005_2000._0002(1402787468));
				stringBuilder.Append(global::_0005_2000._0002(1402786273));
				stringBuilder.Append(global::_0005_2000._0002(1402787532));
				stringBuilder.Append(global::_0005_2000._0002(1402786243));
				oleDbCommand = new OleDbCommand(stringBuilder.ToString(), oleDbConnection);
				OleDbParameter[] array = new OleDbParameter[4]
				{
					new OleDbParameter(global::_0005_2000._0002(1402787371), OleDbType.Integer),
					new OleDbParameter(global::_0005_2000._0002(1402787593), OleDbType.VarWChar),
					new OleDbParameter(global::_0005_2000._0002(1402787353), OleDbType.VarWChar),
					new OleDbParameter(global::_0005_2000._0002(1402786212), OleDbType.Integer)
				};
				array[0].Value = value;
				array[1].Value = value2;
				array[2].Value = value3;
				array[3].Value = num;
				OleDbParameter[] array2 = array;
				foreach (OleDbParameter value4 in array2)
				{
					oleDbCommand.Parameters.Add(value4);
				}
				oleDbCommand.ExecuteNonQuery();
				oleDbCommand.Parameters.Clear();
				text = num.ToString();
			}
			else
			{
				StringBuilder stringBuilder2 = new StringBuilder(global::_0005_2000._0002(1402787424));
				stringBuilder2.Append(global::_0005_2000._0002(1402787392));
				stringBuilder2.Append(global::_0005_2000._0002(1402786226));
				OleDbCommand oleDbCommand2 = new OleDbCommand(stringBuilder2.ToString(), oleDbConnection);
				OleDbParameter[] array3 = new OleDbParameter[2]
				{
					new OleDbParameter(global::_0005_2000._0002(1402787353), OleDbType.VarWChar),
					new OleDbParameter(global::_0005_2000._0002(1402786212), OleDbType.Integer)
				};
				array3[0].Value = value3;
				array3[1].Value = text2;
				OleDbParameter[] array4 = array3;
				foreach (OleDbParameter value5 in array4)
				{
					oleDbCommand2.Parameters.Add(value5);
				}
				oleDbCommand2.ExecuteNonQuery();
				oleDbCommand2.Parameters.Clear();
				text = text2;
			}
		}
		catch (Exception ex2)
		{
			return global::_0005_2000._0002(1402784612) + ex2.Message;
		}
		oleDbConnection.Close();
		return text;
	}

	private string _0003_2000(string[] _0002)
	{
		string text = global::_0005_2000._0002(1402782031);
		OleDbConnection oleDbConnection = new OleDbConnection(this.m__0003_2000);
		try
		{
			oleDbConnection.Open();
			_ = _0002[1];
			string value = _0002[2];
			StringBuilder stringBuilder = new StringBuilder(global::_0005_2000._0002(1402786096));
			stringBuilder.Append(global::_0005_2000._0002(1402786226));
			OleDbCommand oleDbCommand = new OleDbCommand(stringBuilder.ToString(), oleDbConnection);
			oleDbCommand.Parameters.Add(global::_0005_2000._0002(1402786212), OleDbType.Integer).Value = value;
			oleDbCommand.ExecuteNonQuery();
			oleDbCommand.Parameters.Clear();
			text = global::_0005_2000._0002(1402781869);
		}
		catch (Exception ex)
		{
			return global::_0005_2000._0002(1402784612) + ex.Message;
		}
		oleDbConnection.Close();
		return text;
	}
}
