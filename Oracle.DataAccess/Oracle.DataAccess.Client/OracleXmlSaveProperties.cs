using System;

namespace Oracle.DataAccess.Client;

public sealed class OracleXmlSaveProperties : ICloneable
{
	private string[] m_keyColumnsList;

	private string m_rowTag;

	private string m_table;

	private string[] m_updateColumnsList;

	private string m_xslt;

	private string m_xsltParams;

	public string[] KeyColumnsList
	{
		get
		{
			return m_keyColumnsList;
		}
		set
		{
			m_keyColumnsList = value;
		}
	}

	public string RowTag
	{
		get
		{
			return m_rowTag;
		}
		set
		{
			m_rowTag = value;
		}
	}

	public string Table
	{
		get
		{
			if (m_table != null)
			{
				return m_table;
			}
			return string.Empty;
		}
		set
		{
			m_table = value;
		}
	}

	public string[] UpdateColumnsList
	{
		get
		{
			return m_updateColumnsList;
		}
		set
		{
			m_updateColumnsList = value;
		}
	}

	public string Xslt
	{
		get
		{
			return m_xslt;
		}
		set
		{
			m_xslt = value;
		}
	}

	public string XsltParams
	{
		get
		{
			return m_xsltParams;
		}
		set
		{
			m_xsltParams = value;
		}
	}

	static OracleXmlSaveProperties()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public OracleXmlSaveProperties()
	{
		m_rowTag = "ROW";
	}

	public object Clone()
	{
		OracleXmlSaveProperties oracleXmlSaveProperties = new OracleXmlSaveProperties();
		oracleXmlSaveProperties.m_keyColumnsList = m_keyColumnsList;
		oracleXmlSaveProperties.m_rowTag = m_rowTag;
		oracleXmlSaveProperties.m_table = m_table;
		oracleXmlSaveProperties.m_updateColumnsList = m_updateColumnsList;
		oracleXmlSaveProperties.m_xslt = m_xslt;
		oracleXmlSaveProperties.m_xsltParams = m_xsltParams;
		return oracleXmlSaveProperties;
	}
}
