using System;

namespace Oracle.DataAccess.Client;

public sealed class OracleXmlQueryProperties : ICloneable
{
	private int m_maxRows;

	private string m_rootTag;

	private string m_rowTag;

	private string m_xslt;

	private string m_xsltParams;

	public int MaxRows
	{
		get
		{
			return m_maxRows;
		}
		set
		{
			if (value < -1)
			{
				throw new ArgumentException();
			}
			m_maxRows = value;
		}
	}

	public string RootTag
	{
		get
		{
			return m_rootTag;
		}
		set
		{
			m_rootTag = value;
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

	static OracleXmlQueryProperties()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public OracleXmlQueryProperties()
	{
		m_maxRows = -1;
		m_rootTag = "ROWSET";
		m_rowTag = "ROW";
	}

	public object Clone()
	{
		OracleXmlQueryProperties oracleXmlQueryProperties = new OracleXmlQueryProperties();
		oracleXmlQueryProperties.m_maxRows = m_maxRows;
		oracleXmlQueryProperties.m_rootTag = m_rootTag;
		oracleXmlQueryProperties.m_rowTag = m_rowTag;
		oracleXmlQueryProperties.m_xslt = m_xslt;
		oracleXmlQueryProperties.m_xsltParams = m_xsltParams;
		return oracleXmlQueryProperties;
	}
}
