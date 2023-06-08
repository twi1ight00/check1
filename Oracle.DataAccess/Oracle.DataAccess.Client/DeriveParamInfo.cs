using System.Data;

namespace Oracle.DataAccess.Client;

internal class DeriveParamInfo
{
	public int m_paramCount;

	public int m_allocCount;

	public int[] m_arrayBindSize;

	public OracleCollectionType[] m_oraCollType;

	public ParameterDirection[] m_direction;

	public OracleDbType[] m_oraDbType;

	public string[] m_paramName;

	public int[] m_size;

	public string[] m_typeName;

	public static Pooler m_pooler = new Pooler(10, 50);

	public DeriveParamInfo(int allocCount)
	{
		m_allocCount = allocCount;
		m_paramCount = allocCount;
		if (m_allocCount > 0)
		{
			m_arrayBindSize = new int[m_allocCount];
			m_oraCollType = new OracleCollectionType[m_allocCount];
			m_direction = new ParameterDirection[m_allocCount];
			m_oraDbType = new OracleDbType[m_allocCount];
			m_paramName = new string[m_allocCount];
			m_size = new int[m_allocCount];
			m_typeName = new string[m_allocCount];
		}
	}
}
