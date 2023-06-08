using System;
using System.Collections;
using Oracle.DataAccess.Types;

namespace Oracle.DataAccess.Client;

internal class OraDb_DbTypeTable
{
	internal static Hashtable s_table;

	internal static int[] dbTypeToOracleDbTypeMapping;

	internal static int[] oraTypeToOracleDbTypeMapping;

	private OraDb_DbTypeTable()
	{
	}

	static OraDb_DbTypeTable()
	{
		s_table = new Hashtable(91);
		dbTypeToOracleDbTypeMapping = new int[134];
		oraTypeToOracleDbTypeMapping = new int[242];
		dbTypeToOracleDbTypeMapping[0] = 126;
		dbTypeToOracleDbTypeMapping[22] = 104;
		dbTypeToOracleDbTypeMapping[1] = 120;
		dbTypeToOracleDbTypeMapping[2] = 103;
		dbTypeToOracleDbTypeMapping[5] = 106;
		dbTypeToOracleDbTypeMapping[6] = 123;
		dbTypeToOracleDbTypeMapping[7] = 107;
		dbTypeToOracleDbTypeMapping[8] = 108;
		dbTypeToOracleDbTypeMapping[10] = 111;
		dbTypeToOracleDbTypeMapping[11] = 112;
		dbTypeToOracleDbTypeMapping[12] = 113;
		dbTypeToOracleDbTypeMapping[15] = 122;
		dbTypeToOracleDbTypeMapping[16] = 126;
		dbTypeToOracleDbTypeMapping[23] = 104;
		dbTypeToOracleDbTypeMapping[17] = 123;
		dbTypeToOracleDbTypeMapping[13] = 129;
		dbTypeToOracleDbTypeMapping[101] = 13;
		dbTypeToOracleDbTypeMapping[102] = 13;
		dbTypeToOracleDbTypeMapping[103] = 2;
		dbTypeToOracleDbTypeMapping[104] = 23;
		dbTypeToOracleDbTypeMapping[105] = 13;
		dbTypeToOracleDbTypeMapping[106] = 5;
		dbTypeToOracleDbTypeMapping[107] = 7;
		dbTypeToOracleDbTypeMapping[108] = 8;
		dbTypeToOracleDbTypeMapping[132] = 8;
		dbTypeToOracleDbTypeMapping[111] = 10;
		dbTypeToOracleDbTypeMapping[112] = 11;
		dbTypeToOracleDbTypeMapping[113] = 12;
		dbTypeToOracleDbTypeMapping[114] = 13;
		dbTypeToOracleDbTypeMapping[115] = 12;
		dbTypeToOracleDbTypeMapping[109] = 16;
		dbTypeToOracleDbTypeMapping[110] = 1;
		dbTypeToOracleDbTypeMapping[117] = 23;
		dbTypeToOracleDbTypeMapping[116] = 13;
		dbTypeToOracleDbTypeMapping[119] = 16;
		dbTypeToOracleDbTypeMapping[120] = 1;
		dbTypeToOracleDbTypeMapping[121] = 13;
		dbTypeToOracleDbTypeMapping[122] = 15;
		dbTypeToOracleDbTypeMapping[133] = 15;
		dbTypeToOracleDbTypeMapping[123] = 6;
		dbTypeToOracleDbTypeMapping[124] = 6;
		dbTypeToOracleDbTypeMapping[125] = 6;
		dbTypeToOracleDbTypeMapping[126] = 16;
		dbTypeToOracleDbTypeMapping[127] = 16;
		dbTypeToOracleDbTypeMapping[129] = 13;
		dbTypeToOracleDbTypeMapping[130] = 13;
		dbTypeToOracleDbTypeMapping[128] = 13;
		oraTypeToOracleDbTypeMapping[96] = 104;
		oraTypeToOracleDbTypeMapping[1] = 126;
		oraTypeToOracleDbTypeMapping[12] = 106;
		oraTypeToOracleDbTypeMapping[189] = 115;
		oraTypeToOracleDbTypeMapping[190] = 114;
		oraTypeToOracleDbTypeMapping[8] = 109;
		oraTypeToOracleDbTypeMapping[24] = 110;
		oraTypeToOracleDbTypeMapping[2] = 107;
		oraTypeToOracleDbTypeMapping[101] = 132;
		oraTypeToOracleDbTypeMapping[100] = 133;
		oraTypeToOracleDbTypeMapping[22] = 132;
		oraTypeToOracleDbTypeMapping[21] = 133;
		oraTypeToOracleDbTypeMapping[114] = 101;
		oraTypeToOracleDbTypeMapping[113] = 102;
		oraTypeToOracleDbTypeMapping[112] = 105;
		oraTypeToOracleDbTypeMapping[104] = 126;
		oraTypeToOracleDbTypeMapping[23] = 120;
		oraTypeToOracleDbTypeMapping[187] = 123;
		oraTypeToOracleDbTypeMapping[188] = 125;
		oraTypeToOracleDbTypeMapping[232] = 124;
		oraTypeToOracleDbTypeMapping[108] = 127;
		oraTypeToOracleDbTypeMapping[110] = 130;
		oraTypeToOracleDbTypeMapping[122] = 128;
		InsertTableEntries();
	}

	internal static void InsertTableEntries()
	{
		s_table.Add(typeof(byte), OracleDbType.Byte);
		s_table.Add(typeof(byte[]), OracleDbType.Raw);
		s_table.Add(typeof(char), OracleDbType.Varchar2);
		s_table.Add(typeof(char[]), OracleDbType.Varchar2);
		s_table.Add(typeof(DateTime), OracleDbType.TimeStamp);
		s_table.Add(typeof(short), OracleDbType.Int16);
		s_table.Add(typeof(int), OracleDbType.Int32);
		s_table.Add(typeof(long), OracleDbType.Int64);
		s_table.Add(typeof(float), OracleDbType.Single);
		s_table.Add(typeof(double), OracleDbType.Double);
		s_table.Add(typeof(decimal), OracleDbType.Decimal);
		s_table.Add(typeof(string), OracleDbType.Varchar2);
		s_table.Add(typeof(TimeSpan), OracleDbType.IntervalDS);
		s_table.Add(typeof(OracleBFile), OracleDbType.BFile);
		s_table.Add(typeof(OracleBinary), OracleDbType.Raw);
		s_table.Add(typeof(OracleBlob), OracleDbType.Blob);
		s_table.Add(typeof(OracleClob), OracleDbType.Clob);
		s_table.Add(typeof(OracleDate), OracleDbType.Date);
		s_table.Add(typeof(OracleDecimal), OracleDbType.Decimal);
		s_table.Add(typeof(OracleIntervalDS), OracleDbType.IntervalDS);
		s_table.Add(typeof(OracleIntervalYM), OracleDbType.IntervalYM);
		s_table.Add(typeof(OracleRefCursor), OracleDbType.RefCursor);
		s_table.Add(typeof(OracleString), OracleDbType.Varchar2);
		s_table.Add(typeof(OracleTimeStamp), OracleDbType.TimeStamp);
		s_table.Add(typeof(OracleTimeStampLTZ), OracleDbType.TimeStampLTZ);
		s_table.Add(typeof(OracleTimeStampTZ), OracleDbType.TimeStampTZ);
		s_table.Add(typeof(OracleXmlType), OracleDbType.XmlType);
		s_table.Add(typeof(OracleRef), OracleDbType.Ref);
	}

	internal static OracleDbType ConvertNumberToOraDbType(int precision, int scale)
	{
		OracleDbType result = OracleDbType.Decimal;
		if (scale <= 0 && precision - scale < 5)
		{
			result = OracleDbType.Int16;
		}
		else if (scale <= 0 && precision - scale < 10)
		{
			result = OracleDbType.Int32;
		}
		else if (scale <= 0 && precision - scale < 19)
		{
			result = OracleDbType.Int64;
		}
		else if (precision < 8 && ((scale <= 0 && precision - scale <= 38) || (scale > 0 && scale <= 44)))
		{
			result = OracleDbType.Single;
		}
		else if (precision < 16)
		{
			result = OracleDbType.Double;
		}
		return result;
	}
}
