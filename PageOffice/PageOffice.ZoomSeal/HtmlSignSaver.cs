using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Xml;

namespace PageOffice.ZoomSeal;

public class HtmlSignSaver
{
	private string _0002;

	private string _0003;

	public string DBConnectionString
	{
		get
		{
			return _0002;
		}
		set
		{
			_0002 = value;
		}
	}

	public HtmlSignSaver(string pageID)
	{
		if (pageID == null || pageID == string.Empty)
		{
			throw new Exception(_0005_2000._0002(1402791693));
		}
		_0003 = pageID;
	}

	public List<Seal> GetSignCollection()
	{
		List<Seal> list = new List<Seal>();
		OleDbConnection oleDbConnection = new OleDbConnection(_0002);
		try
		{
			string cmdText = _0005_2000._0002(1402791768);
			OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
			oleDbCommand.Parameters.Add(_0005_2000._0002(1402787593), OleDbType.VarWChar).Value = _0003;
			oleDbConnection.Open();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			while (oleDbDataReader.Read())
			{
				Seal seal = new Seal();
				string xml = _0003_2000._0003(oleDbDataReader[_0005_2000._0002(1402787519)].ToString());
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(xml);
				XmlNode xmlNode = null;
				XmlNode documentElement = xmlDocument.DocumentElement;
				xmlNode = documentElement.SelectSingleNode(_0005_2000._0002(1402784054));
				if (xmlNode != null)
				{
					seal._0002 = int.Parse(xmlNode.InnerText);
				}
				xmlNode = documentElement.SelectSingleNode(_0005_2000._0002(1402767411));
				if (xmlNode != null)
				{
					seal.SealName = xmlNode.InnerText;
				}
				xmlNode = documentElement.SelectSingleNode(_0005_2000._0002(1402784787));
				if (xmlNode != null)
				{
					seal.SealType = xmlNode.InnerText;
				}
				xmlNode = documentElement.SelectSingleNode(_0005_2000._0002(1402791554));
				if (xmlNode != null)
				{
					seal.SignerName = xmlNode.InnerText;
				}
				xmlNode = documentElement.SelectSingleNode(_0005_2000._0002(1402784843));
				if (xmlNode != null)
				{
					seal.AuthType = xmlNode.InnerText;
				}
				xmlNode = documentElement.SelectSingleNode(_0005_2000._0002(1402784879));
				if (xmlNode != null)
				{
					seal.DeptName = xmlNode.InnerText;
				}
				xmlNode = documentElement.SelectSingleNode(_0005_2000._0002(1402791665));
				if (xmlNode != null)
				{
					seal.CertSerialNum = xmlNode.InnerText;
				}
				xmlNode = documentElement.SelectSingleNode(_0005_2000._0002(1402788508));
				if (xmlNode != null)
				{
					seal.SealImage = Convert.FromBase64String(xmlNode.InnerText);
				}
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
