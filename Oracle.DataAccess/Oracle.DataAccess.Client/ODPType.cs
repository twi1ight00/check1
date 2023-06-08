using System;
using Oracle.DataAccess.Types;

namespace Oracle.DataAccess.Client;

internal class ODPType
{
	public static readonly Type OraBinary = typeof(OracleBinary);

	public static readonly Type OraString = typeof(OracleString);

	public static readonly Type OraBFile = typeof(OracleBFile);

	public static readonly Type OraBlob = typeof(OracleBlob);

	public static readonly Type OraClob = typeof(OracleClob);

	public static readonly Type OraDecimal = typeof(OracleDecimal);

	public static readonly Type OraDate = typeof(OracleDate);

	public static readonly Type OraTimeStamp = typeof(OracleTimeStamp);

	public static readonly Type OraTimeStampTZ = typeof(OracleTimeStampTZ);

	public static readonly Type OraTimeStampLTZ = typeof(OracleTimeStampLTZ);

	public static readonly Type OraXmlType = typeof(OracleXmlType);

	public static readonly Type OraIntervalDS = typeof(OracleIntervalDS);

	public static readonly Type OraIntervalYM = typeof(OracleIntervalYM);

	public static readonly Type OraRefCursor = typeof(OracleRefCursor);

	public static readonly Type OraRef = typeof(OracleRef);
}
