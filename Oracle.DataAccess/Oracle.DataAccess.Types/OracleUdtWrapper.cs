using System;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

internal class OracleUdtWrapper
{
	private const string UDTElements = "Elements";

	private const string UDTData = "Data";

	private const string UDTDataValue = "Value";

	private const string UDTName = "Name";

	private const string UDTProviderType = "ProviderType";

	private const string UDTNullValue = "NULL";

	private const int MAX_LENGTH_FOR_LARGE_TYPES = 10;

	public object m_udtData;

	public OracleUdtStatus[] m_udtStatusArray;

	public OracleUdtDescriptor m_udtDescriptor;

	public override string ToString()
	{
		string result = null;
		XmlTextWriter xmlTextWriter = null;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY)  OracleUdtWrapper::ToString()\n");
		}
		try
		{
			StringWriter stringWriter = new StringWriter();
			xmlTextWriter = new XmlTextWriter(stringWriter);
			if (m_udtDescriptor.OracleDbType == OracleDbType.Object)
			{
				GenerateXmlForObjectType(this, xmlTextWriter);
			}
			else
			{
				GenerateXmlForCollectionType(this, xmlTextWriter);
			}
			result = stringWriter.ToString();
		}
		finally
		{
			xmlTextWriter.Close();
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleUdtWrapper::ToString()\n");
		}
		return result;
	}

	internal static void GenerateXmlForObjectType(OracleUdtWrapper udtWrapper, XmlTextWriter xmlWriter)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY)  OracleUdtWrapper::GenerateXmlForObjectType()\n");
		}
		DataTable metaDataTable = udtWrapper.m_udtDescriptor.GetMetaDataTable();
		string[] array = new string[metaDataTable.Rows.Count];
		OracleDbType[] array2 = new OracleDbType[metaDataTable.Rows.Count];
		xmlWriter.WriteStartElement("Data");
		string text = "";
		for (int i = 0; i < metaDataTable.Rows.Count; i++)
		{
			array[i] = metaDataTable.Rows[i]["Name"].ToString();
			array2[i] = (OracleDbType)metaDataTable.Rows[i]["ProviderType"];
			if (udtWrapper.m_udtStatusArray[i] == OracleUdtStatus.NotNull)
			{
				if (array2[i] == OracleDbType.Object || array2[i] == OracleDbType.Array)
				{
					xmlWriter.WriteElementString(array[i], ((OracleUdtWrapper)((object[])udtWrapper.m_udtData)[i]).m_udtDescriptor.UdtTypeName);
					continue;
				}
				text = GetStringFromObject(((object[])udtWrapper.m_udtData)[i]);
				if (text.Length > 10 && IsLargeDataType(array2[i]))
				{
					text = text.Substring(0, 10);
				}
				xmlWriter.WriteElementString(array[i], text);
			}
			else
			{
				xmlWriter.WriteElementString(array[i], "NULL");
			}
		}
		xmlWriter.WriteEndElement();
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleUdtWrapper::GenerateXmlForObjectType()\n");
		}
	}

	internal static void GenerateXmlForCollectionType(OracleUdtWrapper udtWrapper, XmlTextWriter xmlWriter)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY)  OracleUdtWrapper::GenerateXmlForCollectionType()\n");
		}
		DataTable metaDataTable = udtWrapper.m_udtDescriptor.GetMetaDataTable();
		OracleDbType dbType = (OracleDbType)metaDataTable.Rows[0]["ProviderType"];
		xmlWriter.WriteStartElement("Elements");
		string text = "";
		if ((OracleDbType)metaDataTable.Rows[0]["ProviderType"] == OracleDbType.Object || (OracleDbType)metaDataTable.Rows[0]["ProviderType"] == OracleDbType.Array)
		{
			for (int i = 0; i < ((object[])udtWrapper.m_udtData).Length; i++)
			{
				xmlWriter.WriteStartElement("Data" + (i + 1));
				if (udtWrapper.m_udtStatusArray[i] == OracleUdtStatus.NotNull)
				{
					xmlWriter.WriteElementString("Value", ((OracleUdtWrapper)((object[])udtWrapper.m_udtData)[i]).m_udtDescriptor.UdtTypeName);
				}
				else
				{
					xmlWriter.WriteElementString("Value", "NULL");
				}
				xmlWriter.WriteEndElement();
			}
		}
		else
		{
			bool flag = IsLargeDataType(dbType);
			for (int j = 0; j < ((object[])udtWrapper.m_udtData).Length; j++)
			{
				xmlWriter.WriteStartElement("Data" + (j + 1));
				if (udtWrapper.m_udtStatusArray[j] == OracleUdtStatus.NotNull)
				{
					text = GetStringFromObject(((object[])udtWrapper.m_udtData)[j]);
					if (text.Length > 10 && flag)
					{
						text = text.Substring(0, 10);
					}
					xmlWriter.WriteElementString("Value", text);
				}
				else
				{
					xmlWriter.WriteElementString("Value", "NULL");
				}
				xmlWriter.WriteEndElement();
			}
		}
		xmlWriter.WriteEndElement();
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleUdtWrapper::GenerateXmlForCollectionType()\n");
		}
	}

	internal static string GetStringFromObject(object obj)
	{
		string result = string.Empty;
		if (obj is OracleBFile)
		{
			OracleBFile oracleBFile = obj as OracleBFile;
			byte[] array = new byte[10];
			if (!oracleBFile.IsNull)
			{
				int num = oracleBFile.Read(array, 0, 10);
				if (num > 0)
				{
					result = BitConverter.ToString(array, 0, num);
				}
			}
		}
		else if (obj is OracleBlob)
		{
			OracleBlob oracleBlob = obj as OracleBlob;
			byte[] array2 = new byte[10];
			if (!oracleBlob.IsNull)
			{
				int num2 = oracleBlob.Read(array2, 0, 10);
				if (num2 > 0)
				{
					result = BitConverter.ToString(array2, 0, num2);
				}
			}
		}
		else if (obj is OracleClob)
		{
			OracleClob oracleClob = obj as OracleClob;
			char[] array3 = new char[10];
			if (!oracleClob.IsNull)
			{
				int num3 = oracleClob.Read(array3, 0, 10);
				if (num3 > 0)
				{
					result = new string(array3, 0, num3);
				}
			}
		}
		else if (obj is OracleXmlType)
		{
			OracleXmlType oracleXmlType = obj as OracleXmlType;
			byte[] array4 = new byte[20];
			if (!oracleXmlType.IsNull)
			{
				int num4 = oracleXmlType.GetStream().Read(array4, 0, 20);
				if (num4 > 0)
				{
					result = new string(Encoding.Unicode.GetChars(array4), 0, num4 / 2);
				}
			}
		}
		else
		{
			result = obj.ToString();
		}
		return result;
	}

	internal static bool IsLargeDataType(OracleDbType dbType)
	{
		if (dbType == OracleDbType.BFile || dbType == OracleDbType.Blob || dbType == OracleDbType.Clob || dbType == OracleDbType.NClob || dbType == OracleDbType.Long || dbType == OracleDbType.LongRaw || dbType == OracleDbType.XmlType)
		{
			return true;
		}
		return false;
	}
}
