using System;
using System.Collections;

namespace Oracle.DataAccess.Client;

internal class OracleTypeMapper
{
	public static Hashtable m_OraToOraDb;

	public static Hashtable m_OraToNET;

	private OracleTypeMapper()
	{
	}

	static OracleTypeMapper()
	{
		m_OraToOraDb = new Hashtable(19);
		m_OraToNET = new Hashtable(19);
		m_OraToNET.Add(OraType.ORA_CHAR, typeof(string));
		m_OraToNET.Add(OraType.ORA_CHARN, typeof(string));
		m_OraToNET.Add(OraType.ORA_DATE, typeof(DateTime));
		m_OraToNET.Add(OraType.ORA_INTERVAL_DS, typeof(TimeSpan));
		m_OraToNET.Add(OraType.ORA_INTERVAL_YM, typeof(long));
		m_OraToNET.Add(OraType.ORA_LONG, typeof(string));
		m_OraToNET.Add(OraType.ORA_LONGRAW, typeof(byte[]));
		m_OraToNET.Add(OraType.ORA_NUMBER, typeof(decimal));
		m_OraToNET.Add(OraType.ORA_OCIBFileLocator, typeof(byte[]));
		m_OraToNET.Add(OraType.ORA_OCIBLobLocator, typeof(byte[]));
		m_OraToNET.Add(OraType.ORA_OCICLobLocator, typeof(string));
		m_OraToNET.Add(OraType.ORA_OCIRowid, typeof(string));
		m_OraToNET.Add(OraType.ORA_RAW, typeof(byte[]));
		m_OraToNET.Add(OraType.ORA_TIMESTAMP, typeof(DateTime));
		m_OraToNET.Add(OraType.ORA_TIMESTAMP_TZ, typeof(DateTime));
		m_OraToNET.Add(OraType.ORA_TIMESTAMP_LTZ, typeof(DateTime));
		m_OraToNET.Add(OraType.ORA_NDT, typeof(string));
		m_OraToNET.Add(OraType.ORA_IBFLOAT, typeof(float));
		m_OraToNET.Add(OraType.ORA_IBDOUBLE, typeof(double));
		m_OraToNET.Add(OraType.ORA_BFLOAT, typeof(float));
		m_OraToNET.Add(OraType.ORA_BDOUBLE, typeof(double));
		m_OraToNET.Add(OraType.ORA_OCIRef, typeof(string));
		m_OraToOraDb.Add(OraType.ORA_CHAR, OracleDbType.Char);
		m_OraToOraDb.Add(OraType.ORA_CHARN, OracleDbType.Varchar2);
		m_OraToOraDb.Add(OraType.ORA_DATE, OracleDbType.Date);
		m_OraToOraDb.Add(OraType.ORA_INTERVAL_YM, OracleDbType.IntervalYM);
		m_OraToOraDb.Add(OraType.ORA_INTERVAL_DS, OracleDbType.IntervalDS);
		m_OraToOraDb.Add(OraType.ORA_LONG, OracleDbType.Long);
		m_OraToOraDb.Add(OraType.ORA_LONGRAW, OracleDbType.LongRaw);
		m_OraToOraDb.Add(OraType.ORA_NUMBER, OracleDbType.Decimal);
		m_OraToOraDb.Add(OraType.ORA_OCIBFileLocator, OracleDbType.BFile);
		m_OraToOraDb.Add(OraType.ORA_OCIBLobLocator, OracleDbType.Blob);
		m_OraToOraDb.Add(OraType.ORA_OCICLobLocator, OracleDbType.Clob);
		m_OraToOraDb.Add(OraType.ORA_OCIRowid, OracleDbType.Varchar2);
		m_OraToOraDb.Add(OraType.ORA_RAW, OracleDbType.Raw);
		m_OraToOraDb.Add(OraType.ORA_TIMESTAMP, OracleDbType.TimeStamp);
		m_OraToOraDb.Add(OraType.ORA_TIMESTAMP_TZ, OracleDbType.TimeStampTZ);
		m_OraToOraDb.Add(OraType.ORA_TIMESTAMP_LTZ, OracleDbType.TimeStampLTZ);
		m_OraToOraDb.Add(OraType.ORA_NDT, OracleDbType.XmlType);
		m_OraToOraDb.Add(OraType.ORA_IBFLOAT, OracleDbType.BinaryFloat);
		m_OraToOraDb.Add(OraType.ORA_IBDOUBLE, OracleDbType.BinaryDouble);
		m_OraToOraDb.Add(OraType.ORA_BFLOAT, OracleDbType.BinaryFloat);
		m_OraToOraDb.Add(OraType.ORA_BDOUBLE, OracleDbType.BinaryDouble);
		m_OraToOraDb.Add(OraType.ORA_OCIRef, OracleDbType.Ref);
	}
}
