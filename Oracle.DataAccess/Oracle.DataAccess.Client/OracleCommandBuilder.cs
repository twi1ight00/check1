using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Oracle.DataAccess.Types;

namespace Oracle.DataAccess.Client;

[ToolboxBitmap(typeof(resfinder), "Oracle.DataAccess.src.Client.Icons.OracleCommandBuilderToolBox_hc.bmp")]
public sealed class OracleCommandBuilder : DbCommandBuilder
{
	private const string QUOTE = "\"";

	private const string SCHEMA_SEPERATOR = ".";

	private const int NO_OF_PARAMS = 10;

	private const int NAME_IN = 0;

	private const int PARAM_COUNT_IN = 1;

	private const int PARAM_COUNT_OUT = 2;

	private const int PARAM_NAME_OUT = 3;

	private const int DIRECTION_OUT = 4;

	private const int ORADBTYPE_OUT = 5;

	private const int SIZE_OUT = 6;

	private const int TYPE_NAME_OUT = 7;

	private const int POSITION_OUT = 8;

	private const int DATA_LEVEL_OUT = 9;

	private const int MAX_ARG_NAME_LENGTH = 128;

	private const int FIRST_FETCH_COUNT = 128;

	private const string DP_COMMAND_TEXT = "DECLARE TYPE NUM_TABLE IS TABLE OF NUMBER INDEX BY PLS_INTEGER; TYPE STR_TABLE IS TABLE OF VARCHAR2(128) INDEX BY PLS_INTEGER; name_in          VARCHAR2(2000); param_count_in   PLS_INTEGER; link\t     \t      VARCHAR2(2000); context          NUMBER := 1; schema           VARCHAR2(2000); part1            VARCHAR2(2000); part2            VARCHAR2(2000); dblink           VARCHAR2(2000); part1_type       NUMBER; object_number    NUMBER; refcur\t          SYS_REFCURSOR; idx\t\t          PLS_INTEGER := 0; param_count_out        PLS_INTEGER := 0; param_name_out         STR_TABLE; direction_out          NUM_TABLE; oradbtype_out          NUM_TABLE; size_out               NUM_TABLE; type_name_out          STR_TABLE; position_out           NUM_TABLE; data_level_out         NUM_TABLE; param_name_null_out    STR_TABLE; direction_null_out     NUM_TABLE; oradbtype_null_out     NUM_TABLE; size_null_out          NUM_TABLE; type_name_null_out     STR_TABLE; position_null_out      NUM_TABLE; data_level_null_out    NUM_TABLE; BEGIN name_in := :1; param_count_in := :2; link := NULL; DBMS_UTILITY.NAME_RESOLVE( name_in, context, schema, part1, part2, dblink, part1_type, object_number); WHILE (dblink IS NOT NULL) LOOP link := '@' || dblink; name_in := NULL; IF (schema IS NOT NULL) THEN name_in := '\"' || schema || '\"' || '.'; END IF; IF (part1 IS NOT NULL) THEN name_in := name_in || '\"' || part1 || '\"' || '.'; END IF; IF (part2 IS NULL) THEN name_in := RTRIM(name_in, '.'); ELSE name_in := name_in || '\"' || part2 || '\"'; END IF; EXECUTE IMMEDIATE 'BEGIN DBMS_UTILITY.NAME_RESOLVE' || link || '(:1, :2, :3, :4, :5, :6, :7, :8); END;' USING name_in, context, OUT schema, OUT part1, OUT part2, OUT dblink, OUT part1_type, OUT object_number; END LOOP; IF (param_count_out = 0) THEN OPEN refcur FOR 'SELECT  DECODE (POSITION, 0, ''RETURN_VALUE'', ARGUMENT_NAME) param_name, DECODE(IN_OUT, ''IN'', \t  1,  ''IN/OUT'', 3, ''OUT'', DECODE(ARGUMENT_NAME, NULL, 6, 2), 1) direction, DECODE(DATA_TYPE, ''BINARY_DOUBLE'',  108, ''BINARY_FLOAT'',   122, ''BINARY_INTEGER'', 112, ''BFILE'',     101, ''BLOB'',\t    102, ''CHAR'',\t    104, ''CLOB'',\t    105, ''DATE'',\t    106, ''FLOAT'',\t    107, ''INTERVAL YEAR TO MONTH'', 115, ''INTERVAL DAY TO SECOND'', 114, ''LONG'',\t    109, ''LONG RAW'',\t110, ''NCHAR'',\t    117, ''NCLOB'',\t    116, ''NUMBER'',\t  107, ''NVARCHAR2'',\t119, ''OBJECT'', \t  129, ''RAW'',\t      120, ''REF'',       130, ''REF CURSOR'',121, ''ROWID'',\t    126, ''TABLE'', \t  128, ''TIMESTAMP'',\t123, ''TIMESTAMP WITH LOCAL TIME ZONE'', 124, ''TIMESTAMP WITH TIME ZONE'', 125, ''UNDEFINED'', 100, ''UROWID'',\t  126, ''VARCHAR'', \t126, ''VARCHAR2'',\t126, ''VARRAY'', \t  128, ''PL/SQL TABLE'',1, NULL,            0, -1) oradbtype, DECODE(DATA_TYPE, ''CHAR'', \t      2000, ''LONG'',\t      4000, ''LONG RAW'',    4000, ''NCHAR'', \t    2000, ''NVARCHAR2'',   4000, ''RAW'', \t      2000, ''ROWID'', \t    4000, ''UROWID'',\t    4000, ''VARCHAR'', \t  4000, ''VARCHAR2'', \t  4000, ''PL/SQL TABLE'',  16, 0) length, (TYPE_OWNER ||  DECODE(TYPE_OWNER, NULL, NULL, ''.'') ||  TYPE_NAME ) type_name, POSITION   position, DATA_LEVEL data_level FROM ALL_ARGUMENTS' || link || ' WHERE OWNER \t\t  = :1 \t  AND (PACKAGE_NAME \t= :2 \t  OR (:3 IS NULL AND PACKAGE_NAME is null)) AND OBJECT_NAME \t  = :4 \t  AND NVL(overload, 1) = 1 ORDER BY SEQUENCE' USING schema, part1, part1, part2; FETCH refcur BULK COLLECT INTO param_name_out, direction_out, oradbtype_out, size_out, type_name_out, position_out, data_level_out; param_count_out := refcur%ROWCOUNT; CLOSE refcur; END IF; IF (part1_type = 9 AND param_count_out = 0) THEN param_count_out := -1002; END IF; :3 := param_count_out; IF (param_count_out > param_count_in OR param_count_out < 0) THEN param_name_out:= param_name_null_out; direction_out := direction_null_out; oradbtype_out := oradbtype_null_out; size_out      := size_null_out; type_name_out := type_name_null_out; position_out  := position_null_out; data_level_out:= data_level_null_out; END IF; :4 := param_name_out; :5 := direction_out; :6 := oradbtype_out; :7 := size_out; :8 := type_name_out; :9 := position_out; :10:= data_level_out; END;";

	private const string DP_COMMAND_TEXT_db9i = "DECLARE TYPE NUM_TABLE IS TABLE OF NUMBER INDEX BY BINARY_INTEGER; TYPE STR_TABLE IS TABLE OF VARCHAR2(128) INDEX BY BINARY_INTEGER; TYPE REF_CURSOR IS REF CURSOR; name_in          VARCHAR2(2000); param_count_in   BINARY_INTEGER; link                   VARCHAR2(2000); context          NUMBER := 1; schema           VARCHAR2(2000); part1            VARCHAR2(2000); part2            VARCHAR2(2000); dblink           VARCHAR2(2000); part1_type       NUMBER; object_number    NUMBER; refcur              SYS_REFCURSOR; idx                  BINARY_INTEGER := 1; param_count_out        BINARY_INTEGER := 0; param_name_out         STR_TABLE; direction_out          NUM_TABLE; oradbtype_out          NUM_TABLE; size_out               NUM_TABLE; type_name_out          STR_TABLE; position_out           NUM_TABLE; data_level_out         NUM_TABLE; param_name_null_out    STR_TABLE; direction_null_out     NUM_TABLE; oradbtype_null_out     NUM_TABLE; size_null_out          NUM_TABLE; type_name_null_out     STR_TABLE; position_null_out      NUM_TABLE; data_level_null_out    NUM_TABLE; BEGIN name_in := :1; param_count_in := :2; link := NULL; DBMS_UTILITY.NAME_RESOLVE( name_in, context, schema, part1, part2, dblink, part1_type, object_number); WHILE (dblink IS NOT NULL) LOOP link := '@' || dblink; name_in := NULL; IF (schema IS NOT NULL) THEN name_in := '\"' || schema || '\"' || '.'; END IF; IF (part1 IS NOT NULL) THEN name_in := name_in || '\"' || part1 || '\"' || '.'; END IF; IF (part2 IS NULL) THEN name_in := RTRIM(name_in, '.'); ELSE name_in := name_in || '\"' || part2 || '\"'; END IF; EXECUTE IMMEDIATE 'BEGIN DBMS_UTILITY.NAME_RESOLVE' || link || '(:1, :2, :3, :4, :5, :6, :7, :8); END;' USING name_in, context, OUT schema, OUT part1, OUT part2, OUT dblink, OUT part1_type, OUT object_number; END LOOP; IF (param_count_out = 0) THEN OPEN refcur FOR 'SELECT  DECODE (POSITION, 0, ''RETURN_VALUE'', ARGUMENT_NAME) param_name, DECODE(IN_OUT, ''IN'',       1,  ''IN/OUT'', 3, ''OUT'', DECODE(ARGUMENT_NAME, NULL, 6, 2), 1) direction, DECODE(DATA_TYPE, ''BINARY_DOUBLE'',  108, ''BINARY_FLOAT'',   122, ''BINARY_INTEGER'', 112, ''BFILE'',     101, ''BLOB'',        102, ''CHAR'',        104, ''CLOB'',        105, ''DATE'',        106, ''FLOAT'',        107, ''INTERVAL YEAR TO MONTH'', 115, ''INTERVAL DAY TO SECOND'', 114, ''LONG'',        109, ''LONG RAW'',    110, ''NCHAR'',        117, ''NCLOB'',        116, ''NUMBER'',      107, ''NVARCHAR2'',    119, ''OBJECT'',      129, ''RAW'',\t        120, ''REF'',         130, ''REF CURSOR'',121, ''ROWID'',        126, ''TABLE'',       128, ''TIMESTAMP'',    123, ''TIMESTAMP WITH LOCAL TIME ZONE'', 124, ''TIMESTAMP WITH TIME ZONE'', 125, ''UNDEFINED'', 100, ''UROWID'',      126, ''VARCHAR'',     126, ''VARCHAR2'',    126, ''VARRAY'',      128, ''PL/SQL TABLE'',1, NULL,            0, -1) oradbtype, DECODE(DATA_TYPE, ''CHAR'',           2000, ''LONG'',          4000, ''LONG RAW'',    4000, ''NCHAR'',         2000, ''NVARCHAR2'',   4000, ''RAW'',           2000, ''ROWID'',         4000, ''UROWID'',        4000, ''VARCHAR'',       4000, ''VARCHAR2'',       4000, ''PL/SQL TABLE'',  16, 0) length, (TYPE_OWNER ||  DECODE(TYPE_OWNER, NULL, NULL, ''.'') ||  TYPE_NAME ) type_name, POSITION   position, DATA_LEVEL data_level FROM ALL_ARGUMENTS' || link || ' WHERE OWNER = :1 AND  (PACKAGE_NAME = :2 OR  (:3 IS NULL AND PACKAGE_NAME = OBJECT_NAME)) AND  OBJECT_NAME = :4 AND NVL(overload, 1) = 1 ORDER BY SEQUENCE' USING schema, part1, part1, part2; FETCH refcur BULK COLLECT INTO param_name_out, direction_out, oradbtype_out, size_out, type_name_out, position_out, data_level_out; param_count_out := refcur%ROWCOUNT; CLOSE refcur; END IF; IF (part1_type = 9 AND param_count_out = 0) THEN param_count_out := -1002; END IF; :3 := param_count_out; IF (param_count_out > param_count_in OR param_count_out < 0) THEN param_name_out:= param_name_null_out; direction_out := direction_null_out; oradbtype_out := oradbtype_null_out; size_out      := size_null_out; type_name_out := type_name_null_out; position_out  := position_null_out; data_level_out:= data_level_null_out; END IF; :4 := param_name_out; :5 := direction_out; :6 := oradbtype_out; :7 := size_out; :8 := type_name_out; :9 := position_out; :10:= data_level_out; END;";

	private const string DP_COMMAND_TEXT_db8i = "DECLARE TYPE NUM_TABLE IS TABLE OF NUMBER INDEX BY BINARY_INTEGER; TYPE STR_TABLE IS TABLE OF VARCHAR2(128) INDEX BY BINARY_INTEGER; TYPE REF_CURSOR IS REF CURSOR; name_in          VARCHAR2(2000); param_count_in   PLS_INTEGER; link\t     \t      VARCHAR2(2000); context          NUMBER := 1; schema           VARCHAR2(2000); part1            VARCHAR2(2000); part2            VARCHAR2(2000); dblink           VARCHAR2(2000); part1_type       NUMBER; object_number    NUMBER; refcur           REF_CURSOR; idx\t\t          PLS_INTEGER := 1; param_count_out        PLS_INTEGER := 0; param_name_out         STR_TABLE; direction_out          NUM_TABLE; oradbtype_out          NUM_TABLE; size_out               NUM_TABLE; type_name_out          STR_TABLE; position_out           NUM_TABLE; data_level_out         NUM_TABLE; param_name_null_out    STR_TABLE; direction_null_out     NUM_TABLE; oradbtype_null_out     NUM_TABLE; size_null_out          NUM_TABLE; type_name_null_out     STR_TABLE; position_null_out      NUM_TABLE; data_level_null_out    NUM_TABLE; BEGIN name_in := :1; param_count_in := :2; link := NULL; DBMS_UTILITY.NAME_RESOLVE( name_in, context, schema, part1, part2, dblink, part1_type, object_number); WHILE (dblink IS NOT NULL) LOOP link := '@' || dblink; name_in := NULL; IF (schema IS NOT NULL) THEN name_in := '\"' || schema || '\"' || '.'; END IF; IF (part1 IS NOT NULL) THEN name_in := name_in || '\"' || part1 || '\"' || '.'; END IF; IF (part2 IS NULL) THEN name_in := RTRIM(name_in, '.'); ELSE name_in := name_in || '\"' || part2 || '\"'; END IF; EXECUTE IMMEDIATE 'BEGIN DBMS_UTILITY.NAME_RESOLVE' || link || '(:1, :2, :3, :4, :5, :6, :7, :8); END;' USING name_in, context, OUT schema, OUT part1, OUT part2, OUT dblink, OUT part1_type, OUT object_number; END LOOP; IF (param_count_out = 0) THEN OPEN refcur FOR 'SELECT  DECODE (POSITION, 0, ''RETURN_VALUE'', ARGUMENT_NAME) param_name, DECODE(IN_OUT, ''IN'', \t  1,  ''IN/OUT'', 3, ''OUT'', DECODE(ARGUMENT_NAME, NULL, 6, 2), 1) direction, DECODE(DATA_TYPE, ''BINARY_DOUBLE'',  108, ''BINARY_FLOAT'',   122, ''BINARY_INTEGER'', 112, ''BFILE'',     101, ''BLOB'',\t    102, ''CHAR'',\t    104, ''CLOB'',\t    105, ''DATE'',\t    106, ''FLOAT'',\t    107, ''INTERVAL YEAR TO MONTH'', 115, ''INTERVAL DAY TO SECOND'', 114, ''LONG'',\t    109, ''LONG RAW'',\t110, ''NCHAR'',\t    117, ''NCLOB'',\t    116, ''NUMBER'',\t  107, ''NVARCHAR2'',\t119, ''OBJECT'', \t  129, ''RAW'',\t      120, ''REF'',       130, ''REF CURSOR'',121, ''ROWID'',\t    126, ''TABLE'', \t  128, ''TIMESTAMP'',\t123, ''TIMESTAMP WITH LOCAL TIME ZONE'', 124, ''TIMESTAMP WITH TIME ZONE'', 125, ''UNDEFINED'', 100, ''UROWID'',\t  126, ''VARCHAR'', \t126, ''VARCHAR2'',\t126, ''VARRAY'', \t  128, ''PL/SQL TABLE'',1, NULL,            0, -1) oradbtype, DECODE(DATA_TYPE, ''CHAR'', \t      2000, ''LONG'',\t      4000, ''LONG RAW'',    4000, ''NCHAR'', \t    2000, ''NVARCHAR2'',   4000, ''RAW'', \t      2000, ''ROWID'', \t    4000, ''UROWID'',\t    4000, ''VARCHAR'', \t  4000, ''VARCHAR2'', \t  4000, ''PL/SQL TABLE'',  16, 0) length, (TYPE_OWNER ||  DECODE(TYPE_OWNER, NULL, NULL, ''.'') ||  TYPE_NAME ) type_name, POSITION   position, DATA_LEVEL data_level FROM ALL_ARGUMENTS' || link || ' WHERE OWNER \t\t  = :1 \t  AND (PACKAGE_NAME \t= :2 \t  OR (:3 IS NULL AND PACKAGE_NAME is null)) AND OBJECT_NAME \t  = :4 \t  AND NVL(overload, 1) = 1 ORDER BY SEQUENCE' USING schema, part1, part1, part2; LOOP   FETCH refcur INTO param_name_out(idx), direction_out(idx),     oradbtype_out(idx), size_out(idx), type_name_out(idx),     position_out(idx), data_level_out(idx);   EXIT WHEN refcur%NOTFOUND;   idx := idx + 1; END LOOP; param_count_out := refcur%ROWCOUNT; CLOSE refcur; END IF; IF (part1_type = 9 AND param_count_out = 0) THEN param_count_out := -1002; END IF; :3 := param_count_out; IF (param_count_out > param_count_in OR param_count_out < 0) THEN param_name_out:= param_name_null_out; direction_out := direction_null_out; oradbtype_out := oradbtype_null_out; size_out      := size_null_out; type_name_out := type_name_null_out; position_out  := position_null_out; data_level_out:= data_level_null_out; END IF; :4 := param_name_out; :5 := direction_out; :6 := oradbtype_out; :7 := size_out; :8 := type_name_out; :9 := position_out; :10:= data_level_out; END;";

	private OracleDataAdapter m_dataAdapter;

	private bool m_caseSensitive;

	private unsafe OpoMetValCtx* m_pOpoMetValCtx;

	private OpoMetRefCtx m_opoMetRefCtx;

	private ColMetaRef[] m_colMetaRef;

	private OracleRowUpdatingEventHandler m_hndr;

	private bool m_disposed;

	private OracleCommand m_deleteCmd;

	private OracleCommand m_insertCmd;

	private OracleCommand m_updateCmd;

	private ArrayList m_cachedInsertParams;

	private ArrayList m_cachedUpdateParams;

	private ArrayList m_cachedDeleteParams;

	private MetaData m_metaData;

	private static OracleCommand m_dpCommand;

	private static OracleParameter[] m_dpCommandParams;

	private bool m_ODTDesignMode;

	private static int m_sMaxParamNameLen;

	private static int m_sMaxExpansionRatio;

	private static object m_staticLock;

	[DefaultValue(null)]
	[Description("")]
	public new OracleDataAdapter DataAdapter
	{
		get
		{
			return m_dataAdapter;
		}
		set
		{
			if (m_dataAdapter != value)
			{
				if (m_dataAdapter != null)
				{
					m_dataAdapter.RowUpdating -= m_hndr;
				}
				m_dataAdapter = value;
				if (m_dataAdapter != null)
				{
					m_disposed = false;
					m_dataAdapter.RowUpdating += m_hndr;
				}
			}
		}
	}

	[DefaultValue(true)]
	[Description("")]
	public bool CaseSensitive
	{
		get
		{
			return m_caseSensitive;
		}
		set
		{
			m_caseSensitive = value;
		}
	}

	[DefaultValue(".")]
	public override string SchemaSeparator
	{
		get
		{
			return ".";
		}
		set
		{
			if (value != ".")
			{
				throw new NotSupportedException();
			}
		}
	}

	[DefaultValue("\"")]
	public override string QuotePrefix
	{
		get
		{
			return "\"";
		}
		set
		{
		}
	}

	[DefaultValue("\"")]
	public override string QuoteSuffix
	{
		get
		{
			return "\"";
		}
		set
		{
		}
	}

	public override CatalogLocation CatalogLocation
	{
		get
		{
			return CatalogLocation.End;
		}
		set
		{
			if (CatalogLocation.End != value)
			{
				throw new NotSupportedException();
			}
		}
	}

	public override string CatalogSeparator
	{
		get
		{
			return "@";
		}
		set
		{
			if ("@" != value)
			{
				throw new NotSupportedException();
			}
		}
	}

	private bool ODTDesignMode
	{
		get
		{
			return m_ODTDesignMode;
		}
		set
		{
			m_ODTDesignMode = value;
		}
	}

	static OracleCommandBuilder()
	{
		m_sMaxParamNameLen = 30;
		m_sMaxExpansionRatio = 3;
		m_staticLock = new object();
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public OracleCommandBuilder()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleCommandBuilder::OracleCommandBuilder()\n");
		}
		m_caseSensitive = true;
		m_hndr = RowUpdating;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleCommandBuilder::OracleCommandBuilder()\n");
		}
	}

	public OracleCommandBuilder(OracleDataAdapter da)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleCommandBuilder::OracleCommandBuilder()\n");
		}
		m_dataAdapter = da;
		m_caseSensitive = true;
		m_hndr = RowUpdating;
		if (da != null)
		{
			da.RowUpdating += m_hndr;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleCommandBuilder::OracleCommandBuilder()\n");
		}
	}

	public static void DeriveParameters(OracleCommand command)
	{
		DeriveParamInfo deriveParamInfo = null;
		if (command == null)
		{
			throw new ArgumentNullException("command");
		}
		if (command.CommandType != CommandType.StoredProcedure)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_NOT_SUPPORTED, "OracleCommandBuilder.DeriveParameters", command.CommandType.ToString()));
		}
		string commandText = command.CommandText;
		OracleConnection connection = command.Connection;
		if (connection == null || connection.m_state != ConnectionState.Open)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (commandText == null || commandText.Length == 0)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "OracleCommand.CommandText"));
		}
		if ((deriveParamInfo = (DeriveParamInfo)DeriveParamInfo.m_pooler.Get(connection.m_internalConStr, commandText)) == null)
		{
			bool flag = false;
			try
			{
				Monitor.Enter(m_staticLock);
				flag = true;
				if ((deriveParamInfo = (DeriveParamInfo)DeriveParamInfo.m_pooler.Get(connection.m_internalConStr, commandText)) == null)
				{
					if (m_dpCommand == null)
					{
						m_dpCommand = new OracleCommand();
						m_dpCommandParams = new OracleParameter[10];
						for (int i = 0; i < 10; i++)
						{
							m_dpCommandParams[i] = new OracleParameter();
							m_dpCommand.Parameters.Add(m_dpCommandParams[i]);
						}
						m_dpCommandParams[0].DbType = DbType.String;
						m_dpCommandParams[1].DbType = DbType.Int32;
						m_dpCommandParams[2].DbType = DbType.Int32;
						m_dpCommandParams[2].Direction = ParameterDirection.Output;
						m_dpCommandParams[3].DbType = DbType.String;
						m_dpCommandParams[3].Direction = ParameterDirection.Output;
						m_dpCommandParams[3].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
						m_dpCommandParams[4].DbType = DbType.Int32;
						m_dpCommandParams[4].Direction = ParameterDirection.Output;
						m_dpCommandParams[4].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
						m_dpCommandParams[5].DbType = DbType.Int32;
						m_dpCommandParams[5].Direction = ParameterDirection.Output;
						m_dpCommandParams[5].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
						m_dpCommandParams[6].DbType = DbType.Int32;
						m_dpCommandParams[6].Direction = ParameterDirection.Output;
						m_dpCommandParams[6].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
						m_dpCommandParams[7].DbType = DbType.String;
						m_dpCommandParams[7].Direction = ParameterDirection.Output;
						m_dpCommandParams[7].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
						m_dpCommandParams[8].DbType = DbType.Int32;
						m_dpCommandParams[8].Direction = ParameterDirection.Output;
						m_dpCommandParams[8].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
						m_dpCommandParams[9].DbType = DbType.Int32;
						m_dpCommandParams[9].Direction = ParameterDirection.Output;
						m_dpCommandParams[9].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
					}
					m_dpCommand.AddToStatementCache = command.AddToStatementCache;
					if (connection.m_majorVersion == 8)
					{
						m_dpCommand.CommandText = "DECLARE TYPE NUM_TABLE IS TABLE OF NUMBER INDEX BY BINARY_INTEGER; TYPE STR_TABLE IS TABLE OF VARCHAR2(128) INDEX BY BINARY_INTEGER; TYPE REF_CURSOR IS REF CURSOR; name_in          VARCHAR2(2000); param_count_in   PLS_INTEGER; link\t     \t      VARCHAR2(2000); context          NUMBER := 1; schema           VARCHAR2(2000); part1            VARCHAR2(2000); part2            VARCHAR2(2000); dblink           VARCHAR2(2000); part1_type       NUMBER; object_number    NUMBER; refcur           REF_CURSOR; idx\t\t          PLS_INTEGER := 1; param_count_out        PLS_INTEGER := 0; param_name_out         STR_TABLE; direction_out          NUM_TABLE; oradbtype_out          NUM_TABLE; size_out               NUM_TABLE; type_name_out          STR_TABLE; position_out           NUM_TABLE; data_level_out         NUM_TABLE; param_name_null_out    STR_TABLE; direction_null_out     NUM_TABLE; oradbtype_null_out     NUM_TABLE; size_null_out          NUM_TABLE; type_name_null_out     STR_TABLE; position_null_out      NUM_TABLE; data_level_null_out    NUM_TABLE; BEGIN name_in := :1; param_count_in := :2; link := NULL; DBMS_UTILITY.NAME_RESOLVE( name_in, context, schema, part1, part2, dblink, part1_type, object_number); WHILE (dblink IS NOT NULL) LOOP link := '@' || dblink; name_in := NULL; IF (schema IS NOT NULL) THEN name_in := '\"' || schema || '\"' || '.'; END IF; IF (part1 IS NOT NULL) THEN name_in := name_in || '\"' || part1 || '\"' || '.'; END IF; IF (part2 IS NULL) THEN name_in := RTRIM(name_in, '.'); ELSE name_in := name_in || '\"' || part2 || '\"'; END IF; EXECUTE IMMEDIATE 'BEGIN DBMS_UTILITY.NAME_RESOLVE' || link || '(:1, :2, :3, :4, :5, :6, :7, :8); END;' USING name_in, context, OUT schema, OUT part1, OUT part2, OUT dblink, OUT part1_type, OUT object_number; END LOOP; IF (param_count_out = 0) THEN OPEN refcur FOR 'SELECT  DECODE (POSITION, 0, ''RETURN_VALUE'', ARGUMENT_NAME) param_name, DECODE(IN_OUT, ''IN'', \t  1,  ''IN/OUT'', 3, ''OUT'', DECODE(ARGUMENT_NAME, NULL, 6, 2), 1) direction, DECODE(DATA_TYPE, ''BINARY_DOUBLE'',  108, ''BINARY_FLOAT'',   122, ''BINARY_INTEGER'', 112, ''BFILE'',     101, ''BLOB'',\t    102, ''CHAR'',\t    104, ''CLOB'',\t    105, ''DATE'',\t    106, ''FLOAT'',\t    107, ''INTERVAL YEAR TO MONTH'', 115, ''INTERVAL DAY TO SECOND'', 114, ''LONG'',\t    109, ''LONG RAW'',\t110, ''NCHAR'',\t    117, ''NCLOB'',\t    116, ''NUMBER'',\t  107, ''NVARCHAR2'',\t119, ''OBJECT'', \t  129, ''RAW'',\t      120, ''REF'',       130, ''REF CURSOR'',121, ''ROWID'',\t    126, ''TABLE'', \t  128, ''TIMESTAMP'',\t123, ''TIMESTAMP WITH LOCAL TIME ZONE'', 124, ''TIMESTAMP WITH TIME ZONE'', 125, ''UNDEFINED'', 100, ''UROWID'',\t  126, ''VARCHAR'', \t126, ''VARCHAR2'',\t126, ''VARRAY'', \t  128, ''PL/SQL TABLE'',1, NULL,            0, -1) oradbtype, DECODE(DATA_TYPE, ''CHAR'', \t      2000, ''LONG'',\t      4000, ''LONG RAW'',    4000, ''NCHAR'', \t    2000, ''NVARCHAR2'',   4000, ''RAW'', \t      2000, ''ROWID'', \t    4000, ''UROWID'',\t    4000, ''VARCHAR'', \t  4000, ''VARCHAR2'', \t  4000, ''PL/SQL TABLE'',  16, 0) length, (TYPE_OWNER ||  DECODE(TYPE_OWNER, NULL, NULL, ''.'') ||  TYPE_NAME ) type_name, POSITION   position, DATA_LEVEL data_level FROM ALL_ARGUMENTS' || link || ' WHERE OWNER \t\t  = :1 \t  AND (PACKAGE_NAME \t= :2 \t  OR (:3 IS NULL AND PACKAGE_NAME is null)) AND OBJECT_NAME \t  = :4 \t  AND NVL(overload, 1) = 1 ORDER BY SEQUENCE' USING schema, part1, part1, part2; LOOP   FETCH refcur INTO param_name_out(idx), direction_out(idx),     oradbtype_out(idx), size_out(idx), type_name_out(idx),     position_out(idx), data_level_out(idx);   EXIT WHEN refcur%NOTFOUND;   idx := idx + 1; END LOOP; param_count_out := refcur%ROWCOUNT; CLOSE refcur; END IF; IF (part1_type = 9 AND param_count_out = 0) THEN param_count_out := -1002; END IF; :3 := param_count_out; IF (param_count_out > param_count_in OR param_count_out < 0) THEN param_name_out:= param_name_null_out; direction_out := direction_null_out; oradbtype_out := oradbtype_null_out; size_out      := size_null_out; type_name_out := type_name_null_out; position_out  := position_null_out; data_level_out:= data_level_null_out; END IF; :4 := param_name_out; :5 := direction_out; :6 := oradbtype_out; :7 := size_out; :8 := type_name_out; :9 := position_out; :10:= data_level_out; END;";
					}
					else if (connection.m_majorVersion == 9 && connection.m_minorVersion == 0)
					{
						m_dpCommand.CommandText = "DECLARE TYPE NUM_TABLE IS TABLE OF NUMBER INDEX BY BINARY_INTEGER; TYPE STR_TABLE IS TABLE OF VARCHAR2(128) INDEX BY BINARY_INTEGER; TYPE REF_CURSOR IS REF CURSOR; name_in          VARCHAR2(2000); param_count_in   BINARY_INTEGER; link                   VARCHAR2(2000); context          NUMBER := 1; schema           VARCHAR2(2000); part1            VARCHAR2(2000); part2            VARCHAR2(2000); dblink           VARCHAR2(2000); part1_type       NUMBER; object_number    NUMBER; refcur              SYS_REFCURSOR; idx                  BINARY_INTEGER := 1; param_count_out        BINARY_INTEGER := 0; param_name_out         STR_TABLE; direction_out          NUM_TABLE; oradbtype_out          NUM_TABLE; size_out               NUM_TABLE; type_name_out          STR_TABLE; position_out           NUM_TABLE; data_level_out         NUM_TABLE; param_name_null_out    STR_TABLE; direction_null_out     NUM_TABLE; oradbtype_null_out     NUM_TABLE; size_null_out          NUM_TABLE; type_name_null_out     STR_TABLE; position_null_out      NUM_TABLE; data_level_null_out    NUM_TABLE; BEGIN name_in := :1; param_count_in := :2; link := NULL; DBMS_UTILITY.NAME_RESOLVE( name_in, context, schema, part1, part2, dblink, part1_type, object_number); WHILE (dblink IS NOT NULL) LOOP link := '@' || dblink; name_in := NULL; IF (schema IS NOT NULL) THEN name_in := '\"' || schema || '\"' || '.'; END IF; IF (part1 IS NOT NULL) THEN name_in := name_in || '\"' || part1 || '\"' || '.'; END IF; IF (part2 IS NULL) THEN name_in := RTRIM(name_in, '.'); ELSE name_in := name_in || '\"' || part2 || '\"'; END IF; EXECUTE IMMEDIATE 'BEGIN DBMS_UTILITY.NAME_RESOLVE' || link || '(:1, :2, :3, :4, :5, :6, :7, :8); END;' USING name_in, context, OUT schema, OUT part1, OUT part2, OUT dblink, OUT part1_type, OUT object_number; END LOOP; IF (param_count_out = 0) THEN OPEN refcur FOR 'SELECT  DECODE (POSITION, 0, ''RETURN_VALUE'', ARGUMENT_NAME) param_name, DECODE(IN_OUT, ''IN'',       1,  ''IN/OUT'', 3, ''OUT'', DECODE(ARGUMENT_NAME, NULL, 6, 2), 1) direction, DECODE(DATA_TYPE, ''BINARY_DOUBLE'',  108, ''BINARY_FLOAT'',   122, ''BINARY_INTEGER'', 112, ''BFILE'',     101, ''BLOB'',        102, ''CHAR'',        104, ''CLOB'',        105, ''DATE'',        106, ''FLOAT'',        107, ''INTERVAL YEAR TO MONTH'', 115, ''INTERVAL DAY TO SECOND'', 114, ''LONG'',        109, ''LONG RAW'',    110, ''NCHAR'',        117, ''NCLOB'',        116, ''NUMBER'',      107, ''NVARCHAR2'',    119, ''OBJECT'',      129, ''RAW'',\t        120, ''REF'',         130, ''REF CURSOR'',121, ''ROWID'',        126, ''TABLE'',       128, ''TIMESTAMP'',    123, ''TIMESTAMP WITH LOCAL TIME ZONE'', 124, ''TIMESTAMP WITH TIME ZONE'', 125, ''UNDEFINED'', 100, ''UROWID'',      126, ''VARCHAR'',     126, ''VARCHAR2'',    126, ''VARRAY'',      128, ''PL/SQL TABLE'',1, NULL,            0, -1) oradbtype, DECODE(DATA_TYPE, ''CHAR'',           2000, ''LONG'',          4000, ''LONG RAW'',    4000, ''NCHAR'',         2000, ''NVARCHAR2'',   4000, ''RAW'',           2000, ''ROWID'',         4000, ''UROWID'',        4000, ''VARCHAR'',       4000, ''VARCHAR2'',       4000, ''PL/SQL TABLE'',  16, 0) length, (TYPE_OWNER ||  DECODE(TYPE_OWNER, NULL, NULL, ''.'') ||  TYPE_NAME ) type_name, POSITION   position, DATA_LEVEL data_level FROM ALL_ARGUMENTS' || link || ' WHERE OWNER = :1 AND  (PACKAGE_NAME = :2 OR  (:3 IS NULL AND PACKAGE_NAME = OBJECT_NAME)) AND  OBJECT_NAME = :4 AND NVL(overload, 1) = 1 ORDER BY SEQUENCE' USING schema, part1, part1, part2; FETCH refcur BULK COLLECT INTO param_name_out, direction_out, oradbtype_out, size_out, type_name_out, position_out, data_level_out; param_count_out := refcur%ROWCOUNT; CLOSE refcur; END IF; IF (part1_type = 9 AND param_count_out = 0) THEN param_count_out := -1002; END IF; :3 := param_count_out; IF (param_count_out > param_count_in OR param_count_out < 0) THEN param_name_out:= param_name_null_out; direction_out := direction_null_out; oradbtype_out := oradbtype_null_out; size_out      := size_null_out; type_name_out := type_name_null_out; position_out  := position_null_out; data_level_out:= data_level_null_out; END IF; :4 := param_name_out; :5 := direction_out; :6 := oradbtype_out; :7 := size_out; :8 := type_name_out; :9 := position_out; :10:= data_level_out; END;";
					}
					else
					{
						m_dpCommand.CommandText = "DECLARE TYPE NUM_TABLE IS TABLE OF NUMBER INDEX BY PLS_INTEGER; TYPE STR_TABLE IS TABLE OF VARCHAR2(128) INDEX BY PLS_INTEGER; name_in          VARCHAR2(2000); param_count_in   PLS_INTEGER; link\t     \t      VARCHAR2(2000); context          NUMBER := 1; schema           VARCHAR2(2000); part1            VARCHAR2(2000); part2            VARCHAR2(2000); dblink           VARCHAR2(2000); part1_type       NUMBER; object_number    NUMBER; refcur\t          SYS_REFCURSOR; idx\t\t          PLS_INTEGER := 0; param_count_out        PLS_INTEGER := 0; param_name_out         STR_TABLE; direction_out          NUM_TABLE; oradbtype_out          NUM_TABLE; size_out               NUM_TABLE; type_name_out          STR_TABLE; position_out           NUM_TABLE; data_level_out         NUM_TABLE; param_name_null_out    STR_TABLE; direction_null_out     NUM_TABLE; oradbtype_null_out     NUM_TABLE; size_null_out          NUM_TABLE; type_name_null_out     STR_TABLE; position_null_out      NUM_TABLE; data_level_null_out    NUM_TABLE; BEGIN name_in := :1; param_count_in := :2; link := NULL; DBMS_UTILITY.NAME_RESOLVE( name_in, context, schema, part1, part2, dblink, part1_type, object_number); WHILE (dblink IS NOT NULL) LOOP link := '@' || dblink; name_in := NULL; IF (schema IS NOT NULL) THEN name_in := '\"' || schema || '\"' || '.'; END IF; IF (part1 IS NOT NULL) THEN name_in := name_in || '\"' || part1 || '\"' || '.'; END IF; IF (part2 IS NULL) THEN name_in := RTRIM(name_in, '.'); ELSE name_in := name_in || '\"' || part2 || '\"'; END IF; EXECUTE IMMEDIATE 'BEGIN DBMS_UTILITY.NAME_RESOLVE' || link || '(:1, :2, :3, :4, :5, :6, :7, :8); END;' USING name_in, context, OUT schema, OUT part1, OUT part2, OUT dblink, OUT part1_type, OUT object_number; END LOOP; IF (param_count_out = 0) THEN OPEN refcur FOR 'SELECT  DECODE (POSITION, 0, ''RETURN_VALUE'', ARGUMENT_NAME) param_name, DECODE(IN_OUT, ''IN'', \t  1,  ''IN/OUT'', 3, ''OUT'', DECODE(ARGUMENT_NAME, NULL, 6, 2), 1) direction, DECODE(DATA_TYPE, ''BINARY_DOUBLE'',  108, ''BINARY_FLOAT'',   122, ''BINARY_INTEGER'', 112, ''BFILE'',     101, ''BLOB'',\t    102, ''CHAR'',\t    104, ''CLOB'',\t    105, ''DATE'',\t    106, ''FLOAT'',\t    107, ''INTERVAL YEAR TO MONTH'', 115, ''INTERVAL DAY TO SECOND'', 114, ''LONG'',\t    109, ''LONG RAW'',\t110, ''NCHAR'',\t    117, ''NCLOB'',\t    116, ''NUMBER'',\t  107, ''NVARCHAR2'',\t119, ''OBJECT'', \t  129, ''RAW'',\t      120, ''REF'',       130, ''REF CURSOR'',121, ''ROWID'',\t    126, ''TABLE'', \t  128, ''TIMESTAMP'',\t123, ''TIMESTAMP WITH LOCAL TIME ZONE'', 124, ''TIMESTAMP WITH TIME ZONE'', 125, ''UNDEFINED'', 100, ''UROWID'',\t  126, ''VARCHAR'', \t126, ''VARCHAR2'',\t126, ''VARRAY'', \t  128, ''PL/SQL TABLE'',1, NULL,            0, -1) oradbtype, DECODE(DATA_TYPE, ''CHAR'', \t      2000, ''LONG'',\t      4000, ''LONG RAW'',    4000, ''NCHAR'', \t    2000, ''NVARCHAR2'',   4000, ''RAW'', \t      2000, ''ROWID'', \t    4000, ''UROWID'',\t    4000, ''VARCHAR'', \t  4000, ''VARCHAR2'', \t  4000, ''PL/SQL TABLE'',  16, 0) length, (TYPE_OWNER ||  DECODE(TYPE_OWNER, NULL, NULL, ''.'') ||  TYPE_NAME ) type_name, POSITION   position, DATA_LEVEL data_level FROM ALL_ARGUMENTS' || link || ' WHERE OWNER \t\t  = :1 \t  AND (PACKAGE_NAME \t= :2 \t  OR (:3 IS NULL AND PACKAGE_NAME is null)) AND OBJECT_NAME \t  = :4 \t  AND NVL(overload, 1) = 1 ORDER BY SEQUENCE' USING schema, part1, part1, part2; FETCH refcur BULK COLLECT INTO param_name_out, direction_out, oradbtype_out, size_out, type_name_out, position_out, data_level_out; param_count_out := refcur%ROWCOUNT; CLOSE refcur; END IF; IF (part1_type = 9 AND param_count_out = 0) THEN param_count_out := -1002; END IF; :3 := param_count_out; IF (param_count_out > param_count_in OR param_count_out < 0) THEN param_name_out:= param_name_null_out; direction_out := direction_null_out; oradbtype_out := oradbtype_null_out; size_out      := size_null_out; type_name_out := type_name_null_out; position_out  := position_null_out; data_level_out:= data_level_null_out; END IF; :4 := param_name_out; :5 := direction_out; :6 := oradbtype_out; :7 := size_out; :8 := type_name_out; :9 := position_out; :10:= data_level_out; END;";
					}
					m_dpCommand.Connection = connection;
					m_dpCommandParams[0].Value = commandText;
					m_dpCommandParams[1].Value = 128;
					m_dpCommandParams[3].Size = 128;
					if (m_dpCommandParams[3].ArrayBindSize == null)
					{
						m_dpCommandParams[3].ArrayBindSize = new int[128];
					}
					for (int j = 0; j < 128; j++)
					{
						m_dpCommandParams[3].ArrayBindSize[j] = 128;
					}
					m_dpCommandParams[4].Size = 128;
					m_dpCommandParams[5].Size = 128;
					m_dpCommandParams[6].Size = 128;
					m_dpCommandParams[7].Size = 128;
					if (m_dpCommandParams[7].ArrayBindSize == null)
					{
						m_dpCommandParams[7].ArrayBindSize = new int[128];
					}
					for (int k = 0; k < 128; k++)
					{
						m_dpCommandParams[7].ArrayBindSize[k] = 128;
					}
					m_dpCommandParams[8].Size = 128;
					m_dpCommandParams[9].Size = 128;
					if (m_dpCommand.Connection.ConnectionType == OracleConnectionType.TimesTen)
					{
						TTExecDeriveParameters(m_dpCommand);
					}
					else
					{
						m_dpCommand.ExecuteNonQuery();
					}
					int num = (int)m_dpCommandParams[2].Value;
					if (num == -1002)
					{
						throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "OracleCommand.CommandText"));
					}
					if (num > 128)
					{
						m_dpCommandParams[1].Value = num;
						m_dpCommandParams[3].Size = num;
						if (m_dpCommandParams[3].ArrayBindSize.Length < num)
						{
							m_dpCommandParams[3].ArrayBindSize = new int[num];
						}
						for (int l = 0; l < num; l++)
						{
							m_dpCommandParams[3].ArrayBindSize[l] = 128;
						}
						m_dpCommandParams[4].Size = num;
						m_dpCommandParams[5].Size = num;
						m_dpCommandParams[6].Size = num;
						m_dpCommandParams[7].Size = num;
						if (m_dpCommandParams[7].ArrayBindSize.Length < num)
						{
							m_dpCommandParams[7].ArrayBindSize = new int[num];
						}
						for (int m = 0; m < num; m++)
						{
							m_dpCommandParams[7].ArrayBindSize[m] = 128;
						}
						m_dpCommandParams[8].Size = num;
						m_dpCommandParams[9].Size = num;
						if (m_dpCommand.Connection.ConnectionType == OracleConnectionType.TimesTen)
						{
							TTExecDeriveParameters(m_dpCommand);
						}
						else
						{
							m_dpCommand.ExecuteNonQuery();
						}
						num = (int)m_dpCommandParams[2].Value;
					}
					string[] array = (string[])m_dpCommandParams[3].Value;
					int[] array2 = (int[])m_dpCommandParams[4].Value;
					int[] array3 = (int[])m_dpCommandParams[5].Value;
					int[] array4 = (int[])m_dpCommandParams[6].Value;
					string[] array5 = (string[])m_dpCommandParams[7].Value;
					int[] array6 = (int[])m_dpCommandParams[8].Value;
					int[] array7 = (int[])m_dpCommandParams[9].Value;
					Monitor.Exit(m_staticLock);
					flag = false;
					if ((deriveParamInfo = (DeriveParamInfo)DeriveParamInfo.m_pooler.Get(connection.m_internalConStr, commandText)) == null)
					{
						deriveParamInfo = new DeriveParamInfo(num);
						int num2 = 0;
						for (int n = 0; n < deriveParamInfo.m_allocCount; n++)
						{
							if (array7[n] != 0)
							{
								continue;
							}
							if (array3[n] == 0)
							{
								break;
							}
							int num3 = array6[n];
							if (array3[n] == 100)
							{
								if (array5[n] == "SYS.XMLTYPE" || array5[n] == "PUBLIC.XMLTYPE")
								{
									array3[n] = 127;
								}
								else
								{
									array3[n] = -1;
								}
							}
							if (array3[n] == -1)
							{
								throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.BLR_PRM_NOT_SUPPORTED, num3.ToString()));
							}
							deriveParamInfo.m_paramName[num2] = array[n];
							deriveParamInfo.m_direction[num2] = (ParameterDirection)array2[n];
							deriveParamInfo.m_size[num2] = array4[n];
							if (array3[n] != 1)
							{
								deriveParamInfo.m_oraCollType[num2] = OracleCollectionType.None;
								deriveParamInfo.m_oraDbType[num2] = (OracleDbType)array3[n];
								deriveParamInfo.m_typeName[num2] = array5[n];
							}
							else
							{
								deriveParamInfo.m_oraCollType[num2] = OracleCollectionType.PLSQLAssociativeArray;
								n++;
								if (array3[n] == 100)
								{
									if (array5[n] == "SYS.XMLTYPE" || array5[n] == "PUBLIC.XMLTYPE")
									{
										array3[n] = 127;
									}
									else
									{
										array3[n] = -1;
									}
								}
								if (array3[n] == -1)
								{
									throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.BLR_PRM_NOT_SUPPORTED, num3.ToString()));
								}
								deriveParamInfo.m_oraDbType[num2] = (OracleDbType)array3[n];
								deriveParamInfo.m_typeName[num2] = array5[n];
								deriveParamInfo.m_arrayBindSize[num2] = array4[n];
							}
							num2++;
						}
						deriveParamInfo.m_paramCount = num2;
						DeriveParamInfo.m_pooler.Put(connection.m_internalConStr, commandText, deriveParamInfo);
					}
				}
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(m_staticLock);
				}
			}
		}
		lock (command)
		{
			command.Parameters.Clear();
			for (int num4 = 0; num4 < deriveParamInfo.m_paramCount; num4++)
			{
				OracleParameter oracleParameter = new OracleParameter();
				oracleParameter.ParameterName = deriveParamInfo.m_paramName[num4];
				oracleParameter.Direction = deriveParamInfo.m_direction[num4];
				oracleParameter.CollectionType = deriveParamInfo.m_oraCollType[num4];
				oracleParameter.OracleDbTypeEx = deriveParamInfo.m_oraDbType[num4];
				if (deriveParamInfo.m_size[num4] != 0 && oracleParameter.Direction != ParameterDirection.Input)
				{
					oracleParameter.Size = deriveParamInfo.m_size[num4];
				}
				if (oracleParameter.CollectionType == OracleCollectionType.PLSQLAssociativeArray && oracleParameter.Size > 0)
				{
					oracleParameter.ArrayBindStatus = new OracleParameterStatus[oracleParameter.Size];
					for (int num5 = 0; num5 < oracleParameter.Size; num5++)
					{
						oracleParameter.ArrayBindStatus[num5] = OracleParameterStatus.Success;
					}
					if (deriveParamInfo.m_arrayBindSize[num4] != 0)
					{
						oracleParameter.ArrayBindSize = new int[oracleParameter.Size];
						for (int num6 = 0; num6 < oracleParameter.Size; num6++)
						{
							oracleParameter.ArrayBindSize[num6] = deriveParamInfo.m_arrayBindSize[num4];
						}
					}
				}
				if (oracleParameter.OracleDbType == OracleDbType.Object || oracleParameter.OracleDbType == OracleDbType.Ref || oracleParameter.OracleDbType == OracleDbType.Array)
				{
					oracleParameter.UdtTypeName = deriveParamInfo.m_typeName[num4];
				}
				command.Parameters.Add(oracleParameter);
			}
		}
	}

	private static void TTExecDeriveParameters(OracleCommand dpCommand)
	{
		OracleCommand oracleCommand = dpCommand.Connection.CreateCommand();
		oracleCommand.CommandText = "BEGIN DBMS_UTILITY.NAME_RESOLVE( :name, 1, :schema, :part1, :part2, :dblink, :part1_type, :object_number);END;";
		oracleCommand.Parameters.Add("name", OracleDbType.Varchar2, dpCommand.Parameters[0].Value, ParameterDirection.Input);
		oracleCommand.Parameters.Add("schema", OracleDbType.Varchar2, 128, null, ParameterDirection.Output);
		oracleCommand.Parameters.Add("part1", OracleDbType.Varchar2, 128, null, ParameterDirection.Output);
		oracleCommand.Parameters.Add("part2", OracleDbType.Varchar2, 128, null, ParameterDirection.Output);
		oracleCommand.Parameters.Add("dblink", OracleDbType.Varchar2, 128, null, ParameterDirection.Output);
		oracleCommand.Parameters.Add("part1_type", OracleDbType.Decimal, 0, ParameterDirection.Output);
		oracleCommand.Parameters.Add("object_number", OracleDbType.Decimal, 0, ParameterDirection.Output);
		oracleCommand.ExecuteNonQuery();
		OracleCommand oracleCommand2 = dpCommand.Connection.CreateCommand();
		oracleCommand2.CommandText = "SELECT   DECODE (POSITION, 0, 'RETURN_VALUE', ARGUMENT_NAME) param_name,   CAST (DECODE (IN_OUT, 'IN', 1, 'IN/OUT', 3, 'OUT',     DECODE(ARGUMENT_NAME, NULL, 6, 2), 1) AS TT_SMALLINT) direction,   CAST (DECODE(DATA_TYPE,     'BINARY_DOUBLE', 108,     'BINARY_FLOAT', 122,     'BINARY_INTEGER', 112,     'BFILE', 101,     'BLOB',\t102,     'CHAR', 104,     'CLOB',\t105,     'DATE',\t106,     'FLOAT', 107,     'INTERVAL YEAR TO MONTH', 115,     'INTERVAL DAY TO SECOND', 114,     'LONG',\t109,     'LONG RAW',\t110,     'NCHAR', 117,     'NCLOB', 116,     'NUMBER', 107,     'NVARCHAR2', 119,     'RAW', 120,     'REF', 130,     'REF CURSOR', 121,     'ROWID', 126,     'TABLE', 128,     'TIMESTAMP',\t123,     'TIMESTAMP WITH LOCAL TIME ZONE', 124,     'TIMESTAMP WITH TIME ZONE', 125,     'UNDEFINED', 100,     'UROWID', 126,     'VARCHAR', 126,     'VARCHAR2',\t126,     'VARRAY', 128,     'PL/SQL TABLE', 1,      NULL, 0,     -1) AS TT_SMALLINT) oradbtype,   CAST (DECODE(DATA_TYPE,     'CHAR', 2000,     'LONG', 4000,     'LONG RAW', 4000,     'NCHAR', 2000,     'NVARCHAR2', 4000,     'RAW', 2000,     'ROWID', 4000,     'UROWID', 4000,     'VARCHAR', 4000,     'VARCHAR2', 4000,     'PL/SQL TABLE', 16,     0) AS TT_SMALLINT) length,   (TYPE_OWNER || DECODE (TYPE_OWNER, NULL, NULL, '.') || TYPE_NAME) type_name,   CAST (POSITION AS TT_SMALLINT) position,   CAST (DATA_LEVEL AS TT_SMALLINT) data_level   FROM ALL_ARGUMENTS   WHERE OWNER = TRIM (:1)     AND (PACKAGE_NAME = TRIM (:2)       OR (CAST (TRIM (:3) AS VARCHAR2 (30)) IS NULL AND PACKAGE_NAME IS NULL))     AND OBJECT_NAME = TRIM (:4)     AND NVL (OVERLOAD, '1') = '1'   ORDER BY SEQUENCE  ";
		oracleCommand2.Parameters.Add("1", OracleDbType.Varchar2, oracleCommand.Parameters[1].Value, ParameterDirection.Input);
		oracleCommand2.Parameters.Add("2", OracleDbType.Varchar2, oracleCommand.Parameters[2].Value, ParameterDirection.Input);
		oracleCommand2.Parameters.Add("3", OracleDbType.Varchar2, oracleCommand.Parameters[2].Value, ParameterDirection.Input);
		oracleCommand2.Parameters.Add("4", OracleDbType.Varchar2, oracleCommand.Parameters[3].Value, ParameterDirection.Input);
		OracleDataReader oracleDataReader = oracleCommand2.ExecuteReader();
		int num = 0;
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList3 = new ArrayList();
		ArrayList arrayList4 = new ArrayList();
		ArrayList arrayList5 = new ArrayList();
		ArrayList arrayList6 = new ArrayList();
		ArrayList arrayList7 = new ArrayList();
		while (oracleDataReader.Read())
		{
			num++;
			if (oracleDataReader.IsDBNull(0))
			{
				arrayList.Add(null);
			}
			else
			{
				arrayList.Add(oracleDataReader.GetString(0));
			}
			arrayList2.Add(oracleDataReader.GetInt32(1));
			arrayList3.Add(oracleDataReader.GetInt32(2));
			arrayList4.Add(oracleDataReader.GetInt32(3));
			if (oracleDataReader.IsDBNull(4))
			{
				arrayList5.Add(null);
			}
			else
			{
				arrayList5.Add(oracleDataReader.GetString(4));
			}
			arrayList6.Add(oracleDataReader.GetInt32(5));
			arrayList7.Add(oracleDataReader.GetInt32(6));
		}
		oracleDataReader.Close();
		dpCommand.Parameters[2].Value = num;
		dpCommand.Parameters[3].Value = arrayList.ToArray(typeof(string));
		dpCommand.Parameters[4].Value = arrayList2.ToArray(typeof(int));
		dpCommand.Parameters[5].Value = arrayList3.ToArray(typeof(int));
		dpCommand.Parameters[6].Value = arrayList4.ToArray(typeof(int));
		dpCommand.Parameters[7].Value = arrayList5.ToArray(typeof(string));
		dpCommand.Parameters[8].Value = arrayList6.ToArray(typeof(int));
		dpCommand.Parameters[9].Value = arrayList7.ToArray(typeof(int));
		oracleDataReader.Dispose();
		oracleCommand2.Dispose();
		oracleCommand.Dispose();
	}

	public override string QuoteIdentifier(string unquotedIdentifier)
	{
		if (unquotedIdentifier == null)
		{
			throw new ArgumentNullException();
		}
		if (unquotedIdentifier.Length == 0)
		{
			return QuotePrefix + QuoteSuffix;
		}
		return string.Format("{0}{1}{2}", QuotePrefix, unquotedIdentifier.Replace("\"", "\"\""), QuoteSuffix);
	}

	public override string UnquoteIdentifier(string quotedIdentifier)
	{
		if (quotedIdentifier == null)
		{
			throw new ArgumentNullException();
		}
		int length = quotedIdentifier.Length;
		if (length < 2 || quotedIdentifier[0] != '"' || quotedIdentifier[length - 1] != '"')
		{
			throw new ArgumentException();
		}
		return quotedIdentifier.Substring(1, length - 2).Replace("\"\"", "\"");
	}

	private string GenerateParameterName(string prefix, int srcColumnLen, string srcColumn, int paramId)
	{
		string text = Regex.Replace(srcColumn, "[^\\w]", "");
		if (srcColumnLen < text.Length)
		{
			text = text.Substring(0, srcColumnLen);
		}
		StringBuilder stringBuilder = new StringBuilder(32);
		stringBuilder.Append(prefix);
		stringBuilder.Append(text);
		stringBuilder.Append("_p");
		stringBuilder.Append(paramId);
		return stringBuilder.ToString();
	}

	public new unsafe OracleCommand GetDeleteCommand()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleCommandBuilder::GetDeleteCommand()\n");
		}
		if (m_disposed)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		OracleCommand oracleCommand = new OracleCommand();
		int num = 0;
		StringBuilder stringBuilder = new StringBuilder();
		string text = null;
		bool flag = false;
		if (m_pOpoMetValCtx == null || m_pOpoMetValCtx->bPkFetched == 0)
		{
			if (m_dataAdapter == null || m_dataAdapter.SelectCommand == null || m_dataAdapter.SelectCommand.Connection == null)
			{
				throw new InvalidOperationException();
			}
			if (m_dataAdapter.SelectCommand.Connection.State == ConnectionState.Closed)
			{
				m_dataAdapter.SelectCommand.Connection.Open();
				flag = true;
			}
		}
		try
		{
			if (m_pOpoMetValCtx == null)
			{
				GetOpoMetValCtx();
			}
			CheckPrimaryKey();
		}
		finally
		{
			if (flag && m_dataAdapter.SelectCommand.Connection.State == ConnectionState.Open)
			{
				m_dataAdapter.SelectCommand.Connection.Close();
			}
		}
		int numOfColumns = GetNumOfColumns();
		int num2 = (m_sMaxParamNameLen - (6 + (2 * numOfColumns).ToString().Length)) / m_sMaxExpansionRatio;
		if (num2 < 0)
		{
			num2 = 0;
		}
		for (int i = 0; i < numOfColumns; i++)
		{
			if (m_pOpoMetValCtx->pColMetaVal[i].bIsHiddenCol == 1)
			{
				continue;
			}
			string columnName = GetColumnName(i, baseColumn: true);
			string columnName2 = GetColumnName(i, baseColumn: false);
			OracleDbType columnType = GetColumnType(i);
			if (IsOraLOB(columnType) || IsOraLONG(columnType) || IsOraXmlType(columnType) || IsOraUDT(columnType) || columnName == null)
			{
				continue;
			}
			bool flag2;
			OracleParameter oracleParameter;
			if (flag2 = IsNullableCol(i))
			{
				if (m_ODTDesignMode)
				{
					text = GenerateParameterName(":ori_", num2, columnName2, num);
					stringBuilder.Append(" ((");
					stringBuilder.Append(text);
					stringBuilder.Append(" IS NULL AND ");
					stringBuilder.Append(columnName);
					stringBuilder.Append(" IS NULL) OR");
					oracleParameter = oracleCommand.Parameters.Add(CreateParams(text, columnName2, columnType, DataRowVersion.Original, 1));
					if (columnType == OracleDbType.Ref)
					{
						oracleParameter.UdtTypeName = GetUdtTypeName(i);
					}
				}
				else
				{
					text = GenerateParameterName(":ind_", num2, columnName2, num);
					stringBuilder.Append(" ((");
					stringBuilder.Append(text);
					stringBuilder.Append(" = 1 AND ");
					stringBuilder.Append(columnName);
					stringBuilder.Append(" IS NULL) OR");
					oracleCommand.Parameters.Add(CreateParams(text, null, OracleDbType.Int32, DataRowVersion.Current, 1));
				}
				num++;
			}
			text = GenerateParameterName(":ori_", num2, columnName2, num);
			stringBuilder.Append(" ");
			stringBuilder.Append(columnName);
			stringBuilder.Append("=");
			stringBuilder.Append(text);
			if (flag2)
			{
				stringBuilder.Append(")");
			}
			stringBuilder.Append(" AND");
			DataRowVersion version = DataRowVersion.Original;
			oracleParameter = oracleCommand.Parameters.Add(CreateParams(text, columnName2, columnType, version, null));
			if (columnType == OracleDbType.Ref)
			{
				oracleParameter.UdtTypeName = GetUdtTypeName(i);
			}
			num++;
		}
		StringBuilder stringBuilder2 = new StringBuilder();
		stringBuilder2.Append("DELETE FROM ");
		stringBuilder2.Append(GetSchemaName());
		stringBuilder2.Append(GetBaseTableName());
		stringBuilder2.Append(" WHERE");
		stringBuilder2.Append(stringBuilder.ToString().TrimEnd("AND".ToCharArray()).TrimEnd());
		oracleCommand.CommandText = stringBuilder2.ToString();
		oracleCommand.Connection = DataAdapter.SelectCommand.Connection;
		oracleCommand.UpdatedRowSource = UpdateRowSource.None;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleCommandBuilder::GetDeleteCommand()\n");
		}
		return oracleCommand;
	}

	public new OracleCommand GetDeleteCommand(bool opt)
	{
		return GetDeleteCommand();
	}

	internal OracleCommand GetDeleteCommand(DataRow row)
	{
		int num = 1;
		StringBuilder stringBuilder = new StringBuilder();
		DataTable table = row.Table;
		if (!table.ExtendedProperties.Contains("REFCursorName"))
		{
			GetBaseTableName();
		}
		else
		{
			CheckDataTable(table);
		}
		CheckPrimaryKey(row);
		if (m_cachedDeleteParams == null)
		{
			m_cachedDeleteParams = new ArrayList();
		}
		if (m_deleteCmd == null || m_deleteCmd.m_disposed)
		{
			if (m_deleteCmd != null)
			{
				int num2 = 0;
				while (num2 < m_cachedDeleteParams.Count)
				{
					if (((OracleParameter)m_cachedDeleteParams[num2]).m_collRef != null)
					{
						m_cachedDeleteParams.RemoveAt(num2);
					}
					else
					{
						num2++;
					}
				}
			}
			m_deleteCmd = new OracleCommand();
		}
		else
		{
			if (m_deleteCmd.m_modified)
			{
				m_deleteCmd.ArrayBindCount = 0;
				m_deleteCmd.AddRowid = false;
				m_deleteCmd.BindByName = false;
				m_deleteCmd.CommandType = CommandType.Text;
				m_deleteCmd.FetchSize = 131072L;
				m_deleteCmd.m_initialLongFS = 0;
				m_deleteCmd.m_initialLobFS = 0;
				m_deleteCmd.CommandTimeout = 0;
			}
			m_deleteCmd.Parameters.Clear();
		}
		foreach (DataColumn column in table.Columns)
		{
			string columnName = GetColumnName(column, baseColumn: true);
			string columnName2 = GetColumnName(column, baseColumn: false);
			OracleDbType columnType = GetColumnType(column);
			if (IsOraLOB(columnType) || IsOraLONG(columnType) || IsOraXmlType(columnType) || IsOraUDT(columnType) || columnName == null)
			{
				continue;
			}
			if (!IsRowOrigValueNull(row, column))
			{
				stringBuilder.Append(" ");
				stringBuilder.Append(columnName);
				stringBuilder.Append("=:");
				stringBuilder.Append(num);
				stringBuilder.Append(" AND");
				DataRowVersion version = DataRowVersion.Original;
				OracleParameter oracleParameter = null;
				if (m_cachedDeleteParams.Count > num - 1)
				{
					oracleParameter = (OracleParameter)m_cachedDeleteParams[num - 1];
					if (oracleParameter.m_disposed)
					{
						m_cachedDeleteParams.RemoveAt(num - 1);
						oracleParameter = null;
					}
				}
				if (oracleParameter != null)
				{
					SetParam(columnName2, columnType, version, row[column, DataRowVersion.Original], oracleParameter);
				}
				else
				{
					oracleParameter = CreateParams(null, columnName2, columnType, version, row[column, DataRowVersion.Original]);
					m_cachedDeleteParams.Insert(num - 1, oracleParameter);
				}
				if (columnType == OracleDbType.Ref)
				{
					oracleParameter.UdtTypeName = GetUdtTypeName(column);
				}
				m_deleteCmd.Parameters.Add(oracleParameter);
				num++;
			}
			else
			{
				stringBuilder.Append(" ");
				stringBuilder.Append(columnName);
				stringBuilder.Append(" IS NULL AND");
			}
		}
		StringBuilder stringBuilder2 = new StringBuilder();
		stringBuilder2.Append("DELETE FROM ");
		stringBuilder2.Append(GetSchemaName(table));
		stringBuilder2.Append(GetBaseTableName(table));
		stringBuilder2.Append(" WHERE");
		stringBuilder2.Append(stringBuilder.ToString().TrimEnd("AND".ToCharArray()).TrimEnd());
		m_deleteCmd.CommandText = stringBuilder2.ToString();
		m_deleteCmd.Connection = DataAdapter.SelectCommand.Connection;
		m_deleteCmd.UpdatedRowSource = UpdateRowSource.None;
		return m_deleteCmd;
	}

	internal OracleCommand GetInsertCommand(DataRow row)
	{
		int num = 1;
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		if (m_cachedInsertParams == null)
		{
			m_cachedInsertParams = new ArrayList();
		}
		if (m_insertCmd == null || m_insertCmd.m_disposed)
		{
			if (m_insertCmd != null)
			{
				int num2 = 0;
				while (num2 < m_cachedInsertParams.Count)
				{
					if (((OracleParameter)m_cachedInsertParams[0]).m_collRef != null)
					{
						m_cachedInsertParams.RemoveAt(0);
					}
					else
					{
						num2++;
					}
				}
			}
			m_insertCmd = new OracleCommand();
		}
		else
		{
			if (m_insertCmd.m_modified)
			{
				m_insertCmd.ArrayBindCount = 0;
				m_insertCmd.AddRowid = false;
				m_insertCmd.BindByName = false;
				m_insertCmd.CommandType = CommandType.Text;
				m_insertCmd.FetchSize = 131072L;
				m_insertCmd.m_initialLongFS = 0;
				m_insertCmd.m_initialLobFS = 0;
				m_insertCmd.CommandTimeout = 0;
			}
			m_insertCmd.Parameters.Clear();
		}
		DataTable table = row.Table;
		if (!table.ExtendedProperties.Contains("REFCursorName"))
		{
			GetBaseTableName();
		}
		else
		{
			CheckDataTable(table);
		}
		foreach (DataColumn column in table.Columns)
		{
			string columnName = GetColumnName(column, baseColumn: true);
			string columnName2 = GetColumnName(column, baseColumn: false);
			OracleDbType columnType = GetColumnType(column);
			if (columnName == null)
			{
				continue;
			}
			stringBuilder.Append(" ");
			stringBuilder.Append(columnName);
			stringBuilder.Append(",");
			if (!IsRowCurrentValueNull(row, column))
			{
				stringBuilder2.Append(" :");
				stringBuilder2.Append(num);
				stringBuilder2.Append(",");
				OracleParameter oracleParameter = null;
				if (m_cachedInsertParams.Count > num - 1)
				{
					oracleParameter = (OracleParameter)m_cachedInsertParams[num - 1];
					if (oracleParameter.m_disposed)
					{
						m_cachedInsertParams.RemoveAt(num - 1);
						oracleParameter = null;
					}
				}
				if (oracleParameter != null)
				{
					SetParam(columnName2, columnType, DataRowVersion.Current, row[column, DataRowVersion.Current], oracleParameter);
				}
				else
				{
					oracleParameter = CreateParams(null, columnName2, columnType, DataRowVersion.Current, row[column, DataRowVersion.Current]);
					m_cachedInsertParams.Insert(num - 1, oracleParameter);
				}
				if (IsOraUDT(columnType) || columnType == OracleDbType.Ref)
				{
					oracleParameter.UdtTypeName = GetUdtTypeName(column);
				}
				m_insertCmd.Parameters.Add(oracleParameter);
				num++;
			}
			else
			{
				stringBuilder2.Append(" NULL,");
			}
		}
		if (stringBuilder.Length == 0)
		{
			return null;
		}
		StringBuilder stringBuilder3 = new StringBuilder();
		stringBuilder3.Append("INSERT INTO ");
		stringBuilder3.Append(GetSchemaName(table));
		stringBuilder3.Append(GetBaseTableName(table));
		stringBuilder3.Append("(");
		stringBuilder3.Append(stringBuilder.ToString().TrimEnd(','));
		stringBuilder3.Append(") VALUES (");
		stringBuilder3.Append(stringBuilder2.ToString().TrimEnd(','));
		stringBuilder3.Append(")");
		m_insertCmd.CommandText = stringBuilder3.ToString();
		m_insertCmd.Connection = DataAdapter.SelectCommand.Connection;
		m_insertCmd.UpdatedRowSource = UpdateRowSource.None;
		return m_insertCmd;
	}

	public new unsafe OracleCommand GetInsertCommand()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleCommandBuilder::GetInsertCommand()\n");
		}
		if (m_disposed)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		int num = 0;
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		string text = null;
		OracleCommand oracleCommand = new OracleCommand();
		bool flag = false;
		if (m_pOpoMetValCtx == null)
		{
			if (m_dataAdapter == null || m_dataAdapter.SelectCommand == null || m_dataAdapter.SelectCommand.Connection == null)
			{
				throw new InvalidOperationException();
			}
			if (m_dataAdapter.SelectCommand.Connection.State == ConnectionState.Closed)
			{
				m_dataAdapter.SelectCommand.Connection.Open();
				flag = true;
			}
		}
		try
		{
			if (m_pOpoMetValCtx == null)
			{
				GetOpoMetValCtx();
			}
		}
		finally
		{
			if (flag && m_dataAdapter.SelectCommand.Connection.State == ConnectionState.Open)
			{
				m_dataAdapter.SelectCommand.Connection.Close();
			}
		}
		if (m_pOpoMetValCtx == null)
		{
			return null;
		}
		int numOfColumns = GetNumOfColumns();
		int num2 = numOfColumns;
		int num3 = (m_sMaxParamNameLen - (6 + num2.ToString().Length)) / m_sMaxExpansionRatio;
		if (num3 < 0)
		{
			num3 = 0;
		}
		for (int i = 0; i < numOfColumns; i++)
		{
			if (m_pOpoMetValCtx->pColMetaVal[i].Updatable != 1 || m_pOpoMetValCtx->pColMetaVal[i].bIsHiddenCol == 1)
			{
				continue;
			}
			OracleDbType columnType = GetColumnType(i);
			string columnName = GetColumnName(i, baseColumn: true);
			string columnName2 = GetColumnName(i, baseColumn: false);
			if (columnName != null)
			{
				stringBuilder.Append(" ");
				stringBuilder.Append(columnName);
				stringBuilder.Append(",");
				text = GenerateParameterName(":cur_", num3, columnName2, num);
				stringBuilder2.Append(" ");
				stringBuilder2.Append(text);
				stringBuilder2.Append(",");
				OracleParameter oracleParameter = oracleCommand.Parameters.Add(CreateParams(text, columnName2, columnType, DataRowVersion.Current, null));
				if (IsOraUDT(columnType) || columnType == OracleDbType.Ref)
				{
					oracleParameter.UdtTypeName = GetUdtTypeName(i);
				}
				num++;
			}
		}
		if (stringBuilder.Length == 0)
		{
			return null;
		}
		StringBuilder stringBuilder3 = new StringBuilder();
		stringBuilder3.Append("INSERT INTO ");
		stringBuilder3.Append(GetSchemaName());
		stringBuilder3.Append(GetBaseTableName());
		stringBuilder3.Append("(");
		stringBuilder3.Append(stringBuilder.ToString().TrimEnd(','));
		stringBuilder3.Append(") VALUES (");
		stringBuilder3.Append(stringBuilder2.ToString().TrimEnd(','));
		stringBuilder3.Append(")");
		oracleCommand.CommandText = stringBuilder3.ToString();
		oracleCommand.Connection = DataAdapter.SelectCommand.Connection;
		oracleCommand.UpdatedRowSource = UpdateRowSource.None;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleCommandBuilder::GetInsertCommand()\n");
		}
		return oracleCommand;
	}

	public new OracleCommand GetInsertCommand(bool opt)
	{
		return GetInsertCommand();
	}

	internal OracleCommand GetUpdateCommand(DataRow row)
	{
		int num = 1;
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		if (row.RowState != DataRowState.Modified)
		{
			return null;
		}
		if (m_cachedUpdateParams == null)
		{
			m_cachedUpdateParams = new ArrayList();
		}
		if (m_updateCmd == null || m_updateCmd.m_disposed)
		{
			if (m_updateCmd != null)
			{
				int num2 = 0;
				while (num2 < m_cachedUpdateParams.Count)
				{
					if (((OracleParameter)m_cachedUpdateParams[num2]).m_collRef != null)
					{
						m_cachedUpdateParams.RemoveAt(num2);
					}
					else
					{
						num2++;
					}
				}
			}
			m_updateCmd = new OracleCommand();
		}
		else
		{
			if (m_updateCmd.m_modified)
			{
				m_updateCmd.ArrayBindCount = 0;
				m_updateCmd.AddRowid = false;
				m_updateCmd.BindByName = false;
				m_updateCmd.CommandType = CommandType.Text;
				m_updateCmd.FetchSize = 131072L;
				m_updateCmd.m_initialLongFS = 0;
				m_updateCmd.m_initialLobFS = 0;
				m_updateCmd.CommandTimeout = 0;
			}
			m_updateCmd.Parameters.Clear();
		}
		DataTable table = row.Table;
		if (!table.ExtendedProperties.Contains("REFCursorName"))
		{
			GetBaseTableName();
		}
		else
		{
			CheckDataTable(table);
		}
		CheckPrimaryKey(row);
		foreach (DataColumn column in table.Columns)
		{
			string columnName = GetColumnName(column, baseColumn: true);
			string columnName2 = GetColumnName(column, baseColumn: false);
			OracleDbType columnType = GetColumnType(column);
			if (columnName == null || !IsColumnModified(row, column))
			{
				continue;
			}
			stringBuilder.Append(" ");
			stringBuilder.Append(columnName);
			stringBuilder.Append("=:");
			stringBuilder.Append(num);
			stringBuilder.Append(",");
			OracleParameter oracleParameter = null;
			if (m_cachedUpdateParams.Count > num - 1)
			{
				oracleParameter = (OracleParameter)m_cachedUpdateParams[num - 1];
				if (oracleParameter.m_disposed)
				{
					m_cachedUpdateParams.RemoveAt(num - 1);
					oracleParameter = null;
				}
			}
			if (oracleParameter != null)
			{
				SetParam(columnName2, columnType, DataRowVersion.Current, row[column, DataRowVersion.Current], oracleParameter);
			}
			else
			{
				oracleParameter = CreateParams(null, columnName2, columnType, DataRowVersion.Current, row[column, DataRowVersion.Current]);
				m_cachedUpdateParams.Insert(num - 1, oracleParameter);
			}
			if (IsOraUDT(columnType) || columnType == OracleDbType.Ref)
			{
				oracleParameter.UdtTypeName = GetUdtTypeName(column);
			}
			m_updateCmd.Parameters.Add(oracleParameter);
			num++;
		}
		if (stringBuilder.ToString().Length == 0 && row.RowState == DataRowState.Modified)
		{
			foreach (DataColumn column2 in table.Columns)
			{
				OracleDbType columnType2 = GetColumnType(column2);
				string columnName3 = GetColumnName(column2, baseColumn: true);
				string columnName4 = GetColumnName(column2, baseColumn: false);
				if (columnName3 == null)
				{
					continue;
				}
				stringBuilder.Append(" ");
				stringBuilder.Append(columnName3);
				stringBuilder.Append("=:");
				stringBuilder.Append(num);
				stringBuilder.Append(",");
				OracleParameter oracleParameter2 = null;
				if (m_cachedUpdateParams.Count > num - 1)
				{
					oracleParameter2 = (OracleParameter)m_cachedUpdateParams[num - 1];
					if (oracleParameter2.m_disposed)
					{
						m_cachedUpdateParams.RemoveAt(num - 1);
						oracleParameter2 = null;
					}
				}
				if (oracleParameter2 != null)
				{
					SetParam(columnName4, columnType2, DataRowVersion.Current, row[column2, DataRowVersion.Current], oracleParameter2);
				}
				else
				{
					oracleParameter2 = CreateParams(null, columnName4, columnType2, DataRowVersion.Current, row[column2, DataRowVersion.Current]);
					m_cachedUpdateParams.Insert(num - 1, oracleParameter2);
				}
				if (IsOraUDT(columnType2) || columnType2 == OracleDbType.Ref)
				{
					oracleParameter2.UdtTypeName = GetUdtTypeName(column2);
				}
				m_updateCmd.Parameters.Add(oracleParameter2);
				num++;
			}
		}
		if (stringBuilder.ToString().Length == 0)
		{
			return null;
		}
		foreach (DataColumn column3 in table.Columns)
		{
			OracleDbType columnType3 = GetColumnType(column3);
			string columnName5 = GetColumnName(column3, baseColumn: true);
			string columnName6 = GetColumnName(column3, baseColumn: false);
			if (IsOraLOB(columnType3) || IsOraLONG(columnType3) || IsOraXmlType(columnType3) || IsOraUDT(columnType3) || columnName5 == null)
			{
				continue;
			}
			if (!IsRowOrigValueNull(row, column3))
			{
				stringBuilder2.Append(" ");
				stringBuilder2.Append(columnName5);
				stringBuilder2.Append("=:");
				stringBuilder2.Append(num);
				stringBuilder2.Append(" AND");
				OracleParameter oracleParameter3 = null;
				if (m_cachedUpdateParams.Count > num - 1)
				{
					oracleParameter3 = (OracleParameter)m_cachedUpdateParams[num - 1];
					if (oracleParameter3.m_disposed)
					{
						m_cachedUpdateParams.RemoveAt(num - 1);
						oracleParameter3 = null;
					}
				}
				if (oracleParameter3 != null)
				{
					SetParam(columnName6, columnType3, DataRowVersion.Original, row[column3, DataRowVersion.Original], oracleParameter3);
				}
				else
				{
					oracleParameter3 = CreateParams(null, columnName6, columnType3, DataRowVersion.Original, row[column3, DataRowVersion.Original]);
					m_cachedUpdateParams.Insert(num - 1, oracleParameter3);
				}
				if (columnType3 == OracleDbType.Ref)
				{
					oracleParameter3.UdtTypeName = GetUdtTypeName(column3);
				}
				m_updateCmd.Parameters.Add(oracleParameter3);
				num++;
			}
			else
			{
				stringBuilder2.Append(" ");
				stringBuilder2.Append(columnName5);
				stringBuilder2.Append(" IS NULL AND");
			}
		}
		StringBuilder stringBuilder3 = new StringBuilder();
		stringBuilder3.Append("UPDATE ");
		stringBuilder3.Append(GetSchemaName(table));
		stringBuilder3.Append(GetBaseTableName(table));
		stringBuilder3.Append(" SET");
		stringBuilder3.Append(stringBuilder.ToString().TrimEnd(','));
		stringBuilder3.Append(" WHERE");
		stringBuilder3.Append(stringBuilder2.ToString().TrimEnd("AND".ToCharArray()).TrimEnd());
		m_updateCmd.CommandText = stringBuilder3.ToString();
		m_updateCmd.Connection = DataAdapter.SelectCommand.Connection;
		m_updateCmd.UpdatedRowSource = UpdateRowSource.None;
		return m_updateCmd;
	}

	public new unsafe OracleCommand GetUpdateCommand()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleCommandBuilder::GetUpdateCommand()\n");
		}
		if (m_disposed)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		int num = 0;
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		string text = null;
		OracleCommand oracleCommand = new OracleCommand();
		bool flag = false;
		if (m_pOpoMetValCtx == null || m_pOpoMetValCtx->bPkFetched == 0)
		{
			if (m_dataAdapter == null || m_dataAdapter.SelectCommand == null || m_dataAdapter.SelectCommand.Connection == null)
			{
				throw new InvalidOperationException();
			}
			if (m_dataAdapter.SelectCommand.Connection.State == ConnectionState.Closed)
			{
				m_dataAdapter.SelectCommand.Connection.Open();
				flag = true;
			}
		}
		try
		{
			if (m_pOpoMetValCtx == null)
			{
				GetOpoMetValCtx();
			}
			CheckPrimaryKey();
		}
		finally
		{
			if (flag && m_dataAdapter.SelectCommand.Connection.State == ConnectionState.Open)
			{
				m_dataAdapter.SelectCommand.Connection.Close();
			}
		}
		int numOfColumns = GetNumOfColumns();
		int num2 = (m_sMaxParamNameLen - (6 + (3 * numOfColumns).ToString().Length)) / m_sMaxExpansionRatio;
		if (num2 < 0)
		{
			num2 = 0;
		}
		for (int i = 0; i < numOfColumns; i++)
		{
			if (m_pOpoMetValCtx->pColMetaVal[i].Updatable != 1 || m_pOpoMetValCtx->pColMetaVal[i].bIsHiddenCol == 1)
			{
				continue;
			}
			OracleDbType columnType = GetColumnType(i);
			string columnName = GetColumnName(i, baseColumn: true);
			string columnName2 = GetColumnName(i, baseColumn: false);
			if (columnName != null)
			{
				text = GenerateParameterName(":cur_", num2, columnName2, num);
				stringBuilder.Append(" ");
				stringBuilder.Append(columnName);
				stringBuilder.Append("=");
				stringBuilder.Append(text);
				stringBuilder.Append(",");
				OracleParameter oracleParameter = oracleCommand.Parameters.Add(CreateParams(text, columnName2, columnType, DataRowVersion.Current, null));
				if (IsOraUDT(columnType) || columnType == OracleDbType.Ref)
				{
					oracleParameter.UdtTypeName = GetUdtTypeName(i);
				}
				num++;
			}
		}
		if (stringBuilder.ToString().Length == 0)
		{
			return null;
		}
		numOfColumns = GetNumOfColumns();
		for (int j = 0; j < numOfColumns; j++)
		{
			if (m_pOpoMetValCtx->pColMetaVal[j].bIsHiddenCol == 1)
			{
				continue;
			}
			OracleDbType columnType2 = GetColumnType(j);
			string columnName3 = GetColumnName(j, baseColumn: true);
			string columnName4 = GetColumnName(j, baseColumn: false);
			if (IsOraLOB(columnType2) || IsOraLONG(columnType2) || IsOraXmlType(columnType2) || IsOraUDT(columnType2) || columnName3 == null)
			{
				continue;
			}
			bool flag2;
			OracleParameter oracleParameter;
			if (flag2 = IsNullableCol(j))
			{
				if (m_ODTDesignMode)
				{
					text = GenerateParameterName(":ori_", num2, columnName4, num);
					stringBuilder2.Append(" ((");
					stringBuilder2.Append(text);
					stringBuilder2.Append(" IS NULL AND ");
					stringBuilder2.Append(columnName3);
					stringBuilder2.Append(" IS NULL) OR");
					oracleParameter = oracleCommand.Parameters.Add(CreateParams(text, columnName4, columnType2, DataRowVersion.Original, 1));
					if (columnType2 == OracleDbType.Ref)
					{
						oracleParameter.UdtTypeName = GetUdtTypeName(j);
					}
				}
				else
				{
					text = GenerateParameterName(":ind_", num2, columnName4, num);
					stringBuilder2.Append(" ((");
					stringBuilder2.Append(text);
					stringBuilder2.Append(" = 1 AND ");
					stringBuilder2.Append(columnName3);
					stringBuilder2.Append(" IS NULL) OR");
					oracleCommand.Parameters.Add(CreateParams(text, null, OracleDbType.Int32, DataRowVersion.Current, 1));
				}
				num++;
			}
			text = GenerateParameterName(":ori_", num2, columnName4, num);
			stringBuilder2.Append(" ");
			stringBuilder2.Append(columnName3);
			stringBuilder2.Append("=");
			stringBuilder2.Append(text);
			if (flag2)
			{
				stringBuilder2.Append(")");
			}
			stringBuilder2.Append(" AND");
			oracleParameter = oracleCommand.Parameters.Add(CreateParams(text, columnName4, columnType2, DataRowVersion.Original, null));
			if (columnType2 == OracleDbType.Ref)
			{
				oracleParameter.UdtTypeName = GetUdtTypeName(j);
			}
			num++;
		}
		StringBuilder stringBuilder3 = new StringBuilder();
		stringBuilder3.Append("UPDATE ");
		stringBuilder3.Append(GetSchemaName());
		stringBuilder3.Append(GetBaseTableName());
		stringBuilder3.Append(" SET");
		stringBuilder3.Append(stringBuilder.ToString().TrimEnd(','));
		stringBuilder3.Append(" WHERE");
		stringBuilder3.Append(stringBuilder2.ToString().TrimEnd("AND".ToCharArray()).TrimEnd());
		oracleCommand.CommandText = stringBuilder3.ToString();
		oracleCommand.Connection = DataAdapter.SelectCommand.Connection;
		oracleCommand.UpdatedRowSource = UpdateRowSource.None;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleCommandBuilder::GetUpdateCommand()\n");
		}
		return oracleCommand;
	}

	public new OracleCommand GetUpdateCommand(bool opt)
	{
		return GetUpdateCommand();
	}

	protected unsafe override void Dispose(bool disposing)
	{
		if (m_disposed)
		{
			return;
		}
		try
		{
			if (disposing)
			{
				m_deleteCmd = null;
				m_insertCmd = null;
				m_updateCmd = null;
				if (m_dataAdapter != null)
				{
					try
					{
						m_dataAdapter.RowUpdating -= m_hndr;
					}
					catch
					{
					}
					m_dataAdapter = null;
				}
				m_pOpoMetValCtx = null;
				m_opoMetRefCtx = null;
				m_colMetaRef = null;
				if (m_cachedInsertParams != null)
				{
					try
					{
						m_cachedInsertParams.Clear();
					}
					catch
					{
					}
					m_cachedInsertParams = null;
				}
				if (m_cachedUpdateParams != null)
				{
					try
					{
						m_cachedUpdateParams.Clear();
					}
					catch
					{
					}
					m_cachedUpdateParams = null;
				}
				if (m_cachedDeleteParams != null)
				{
					try
					{
						m_cachedDeleteParams.Clear();
					}
					catch
					{
					}
					m_cachedDeleteParams = null;
				}
			}
			m_metaData = null;
			m_disposed = true;
		}
		finally
		{
			try
			{
				base.Dispose(disposing);
			}
			catch
			{
			}
		}
	}

	public unsafe override void RefreshSchema()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleCommandBuilder::RefreshSchema()\n");
		}
		if (m_dataAdapter != null)
		{
			m_dataAdapter.InsertCommand = null;
			m_dataAdapter.UpdateCommand = null;
			m_dataAdapter.DeleteCommand = null;
		}
		m_pOpoMetValCtx = null;
		m_metaData = null;
		m_opoMetRefCtx = null;
		m_colMetaRef = null;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleCommandBuilder::RefreshSchema()\n");
		}
	}

	private void RowUpdating(object src, OracleRowUpdatingEventArgs arg)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleCommandBuilder::RowUpdating()\n");
		}
		DataRow row = arg.Row;
		try
		{
			switch (arg.StatementType)
			{
			case StatementType.Delete:
			{
				if (DataAdapter.DeleteCommand == null)
				{
					arg.Command = GetDeleteCommand(row);
					break;
				}
				int count2 = arg.Command.Parameters.Count;
				for (int j = 0; j < count2 - 1; j++)
				{
					OracleParameter oracleParameter2 = arg.Command.Parameters[j];
					if (oracleParameter2.SourceColumn.Length == 0)
					{
						object value2 = arg.Command.Parameters[j + 1].Value;
						if (value2 == DBNull.Value || (value2 is INullable && (value2 as INullable).IsNull))
						{
							oracleParameter2.Value = 1;
						}
						else
						{
							oracleParameter2.Value = 0;
						}
					}
				}
				break;
			}
			case StatementType.Insert:
				if (DataAdapter.InsertCommand == null)
				{
					arg.Command = GetInsertCommand(row);
				}
				break;
			case StatementType.Update:
			{
				if (DataAdapter.UpdateCommand == null)
				{
					arg.Command = GetUpdateCommand(row);
					break;
				}
				int count = arg.Command.Parameters.Count;
				for (int i = 0; i < count - 1; i++)
				{
					OracleParameter oracleParameter = arg.Command.Parameters[i];
					if (oracleParameter.SourceColumn.Length == 0)
					{
						object value = arg.Command.Parameters[i + 1].Value;
						if (value == DBNull.Value || (value is INullable && (value as INullable).IsNull))
						{
							oracleParameter.Value = 1;
						}
						else
						{
							oracleParameter.Value = 0;
						}
					}
				}
				break;
			}
			default:
				throw new ArgumentException();
			}
		}
		catch (Exception ex)
		{
			row.RowError = ex.Message;
			if (!m_dataAdapter.ContinueUpdateOnError)
			{
				throw;
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleCommandBuilder::RowUpdating()\n");
		}
	}

	protected override string GetParameterName(int parameterOrdinal)
	{
		return "p" + parameterOrdinal;
	}

	protected override string GetParameterName(string parameterName)
	{
		return parameterName;
	}

	protected override void ApplyParameterInfo(DbParameter parameter, DataRow row, StatementType statementType, bool whereClause)
	{
		if (parameter is OracleParameter oracleParameter)
		{
			oracleParameter.OracleDbType = (OracleDbType)row["ProviderType"];
			oracleParameter.SourceColumn = (string)row["ColumnName"];
			if (ParameterDirection.Input == oracleParameter.Direction && parameter.Size == 0)
			{
				(parameter as OracleParameter).SetSize(-1);
			}
		}
	}

	protected override string GetParameterPlaceholder(int parameterOrdinal)
	{
		return ":p" + parameterOrdinal;
	}

	protected override DbCommand InitializeCommand(DbCommand command)
	{
		return base.InitializeCommand(command);
	}

	protected override void SetRowUpdatingHandler(DbDataAdapter adapter)
	{
		if (adapter == null)
		{
			throw new ArgumentNullException();
		}
		if (m_dataAdapter == adapter)
		{
			((OracleDataAdapter)adapter).RowUpdating -= m_hndr;
			return;
		}
		((OracleDataAdapter)adapter).RowUpdating += m_hndr;
		m_dataAdapter = adapter as OracleDataAdapter;
	}

	private unsafe int GetNumOfColumns()
	{
		return m_pOpoMetValCtx->NoOfCols;
	}

	private string GetColumnName(DataColumn col, bool baseColumn)
	{
		return GetColumnName(col, baseColumn, m_caseSensitive);
	}

	private string GetColumnName(DataColumn col, bool baseColumn, bool caseSensitive)
	{
		string text = (string)col.ExtendedProperties["BaseColumn"];
		if (text == null || !baseColumn)
		{
			int num = FindBaseColumnOrdinal(col);
			if (num == -1)
			{
				return null;
			}
			text = ((!baseColumn) ? m_colMetaRef[num].pColAlias : m_colMetaRef[num].pColName);
		}
		if (text != null && m_caseSensitive && baseColumn)
		{
			return text.Insert(text.Length, "\"").Insert(0, "\"");
		}
		return text;
	}

	private string GetColumnName(int col, bool baseColumn)
	{
		return GetColumnName(col, baseColumn, m_caseSensitive);
	}

	private string GetColumnName(int col, bool baseColumn, bool caseSensitive)
	{
		if (m_colMetaRef == null)
		{
			GetColMetaRef();
			if (m_colMetaRef == null)
			{
				return null;
			}
		}
		string text = ((!baseColumn) ? m_colMetaRef[col].pColAlias : m_colMetaRef[col].pColName);
		if (text != null && caseSensitive && baseColumn)
		{
			return text.Insert(text.Length, "\"").Insert(0, "\"");
		}
		return text;
	}

	private unsafe OpoMetValCtx* GetOpoMetValCtx()
	{
		if (m_pOpoMetValCtx == null)
		{
			if (m_dataAdapter == null)
			{
				throw new InvalidOperationException();
			}
			if (m_dataAdapter.SelectCommand == null)
			{
				throw new InvalidOperationException();
			}
			m_metaData = m_dataAdapter.SelectCommand.InternalPrepare(openCon: true);
			if (m_metaData != null)
			{
				if (!m_dataAdapter.SelectCommand.AddRowid && m_metaData.m_pOpoMetValCtx != null)
				{
					m_pOpoMetValCtx = m_metaData.m_pOpoMetValCtx;
				}
				else if (m_dataAdapter.SelectCommand.AddRowid && m_metaData.m_pOpoMetValCtxWRowid != null)
				{
					m_pOpoMetValCtx = m_metaData.m_pOpoMetValCtxWRowid;
				}
				else
				{
					m_pOpoMetValCtx = null;
				}
			}
		}
		return m_pOpoMetValCtx;
	}

	private unsafe OpoMetRefCtx GetOpoMetRefCtx()
	{
		IntPtr zero = IntPtr.Zero;
		if (m_opoMetRefCtx == null)
		{
			if (m_pOpoMetValCtx == null)
			{
				GetOpoMetValCtx();
				if (m_pOpoMetValCtx == null)
				{
					return null;
				}
			}
			zero = m_pOpoMetValCtx->pOpoMetRefCtx;
			m_opoMetRefCtx = new OpoMetRefCtx();
			Marshal.PtrToStructure(zero, (object)m_opoMetRefCtx);
		}
		return m_opoMetRefCtx;
	}

	private unsafe ColMetaRef[] GetColMetaRef()
	{
		IntPtr zero = IntPtr.Zero;
		int num = 0;
		if (m_colMetaRef == null)
		{
			if (m_pOpoMetValCtx == null)
			{
				GetOpoMetValCtx();
				if (m_pOpoMetValCtx == null)
				{
					return null;
				}
			}
			if (m_opoMetRefCtx == null)
			{
				GetOpoMetRefCtx();
				if (m_opoMetRefCtx == null)
				{
					return null;
				}
			}
			num = m_pOpoMetValCtx->NoOfCols;
			zero = m_opoMetRefCtx.pColMetaRef;
			m_colMetaRef = new ColMetaRef[num];
			for (int i = 0; i < num; i++)
			{
				m_colMetaRef[i] = new ColMetaRef();
				Marshal.PtrToStructure(zero, (object)m_colMetaRef[i]);
				zero = (IntPtr)((byte*)(void*)zero + Marshal.SizeOf((object)m_colMetaRef[i]));
			}
		}
		return m_colMetaRef;
	}

	private OracleDbType GetColumnType(DataColumn col)
	{
		OracleDbType result = OracleDbType.Varchar2;
		object obj = col.ExtendedProperties["OraDbType"];
		if (obj != null)
		{
			result = ((!(obj is string s)) ? ((OracleDbType)obj) : ((OracleDbType)int.Parse(s)));
		}
		else
		{
			int num = FindBaseColumnOrdinal(col);
			if (num != -1)
			{
				result = GetColumnType(num);
			}
		}
		return result;
	}

	private string GetUdtTypeName(DataColumn col)
	{
		object obj = col.ExtendedProperties["UdtTypeName"];
		if (obj == null)
		{
			int num = FindBaseColumnOrdinal(col);
			if (num != -1)
			{
				obj = GetUdtTypeName(num);
			}
		}
		return (string)obj;
	}

	private int FindBaseColumnOrdinal(DataColumn col)
	{
		string text = col.ColumnName;
		string tableName = col.Table.TableName;
		if (m_dataAdapter.TableMappings != null && m_dataAdapter.TableMappings.IndexOfDataSetTable(tableName) != -1)
		{
			DataTableMapping byDataSetTable = m_dataAdapter.TableMappings.GetByDataSetTable(tableName);
			if (byDataSetTable != null && byDataSetTable.ColumnMappings.IndexOfDataSetColumn(col.ColumnName) != -1)
			{
				DataColumnMapping byDataSetColumn = byDataSetTable.ColumnMappings.GetByDataSetColumn(col.ColumnName);
				if (byDataSetColumn != null)
				{
					text = byDataSetColumn.SourceColumn;
				}
			}
		}
		if (m_colMetaRef == null)
		{
			GetColMetaRef();
			if (m_colMetaRef == null)
			{
				return -1;
			}
		}
		for (int i = 0; i < m_colMetaRef.Length; i++)
		{
			if (m_colMetaRef[i].pColAlias != null && text == m_colMetaRef[i].pColAlias)
			{
				return i;
			}
		}
		return -1;
	}

	private unsafe OracleDbType GetColumnType(int col)
	{
		OracleDbType result = OracleDbType.Varchar2;
		bool flag = true;
		if (m_pOpoMetValCtx == null)
		{
			GetOpoMetValCtx();
			if (m_pOpoMetValCtx == null)
			{
				return result;
			}
		}
		ushort oraType = m_pOpoMetValCtx->pColMetaVal[col].OraType;
		if (oraType == 2)
		{
			int scale = m_pOpoMetValCtx->pColMetaVal[col].Scale;
			int precision = m_pOpoMetValCtx->pColMetaVal[col].Precision;
			return OraDb_DbTypeTable.ConvertNumberToOraDbType(precision, scale);
		}
		result = (OracleDbType)OraDb_DbTypeTable.oraTypeToOracleDbTypeMapping[oraType];
		if (m_pOpoMetValCtx->pColMetaVal[col].CharSetForm != 2)
		{
			flag = false;
		}
		switch (result)
		{
		case OracleDbType.Char:
			if (flag)
			{
				result = OracleDbType.NChar;
			}
			break;
		case OracleDbType.Varchar2:
			if (flag)
			{
				result = OracleDbType.NVarchar2;
			}
			break;
		case OracleDbType.Clob:
			if (flag)
			{
				result = OracleDbType.NClob;
			}
			break;
		case OracleDbType.XmlType:
			if (m_pOpoMetValCtx->pColMetaVal[col].bIsXmlType != 1)
			{
				result = OracleDbType.Object;
			}
			break;
		}
		return result;
	}

	private string GetUdtTypeName(int col)
	{
		if (m_colMetaRef == null)
		{
			GetColMetaRef();
			if (m_colMetaRef == null)
			{
				return null;
			}
		}
		return m_colMetaRef[col].pUdtSchemaName + "." + m_colMetaRef[col].pUdtTypeName;
	}

	private bool IsColumnModified(DataRow row, DataColumn col)
	{
		return !row[col, DataRowVersion.Current].Equals(row[col, DataRowVersion.Original]);
	}

	private bool IsRowOrigValueNull(DataRow row, DataColumn col)
	{
		object obj = row[col, DataRowVersion.Original];
		if (obj != DBNull.Value)
		{
			if (obj is INullable)
			{
				return (obj as INullable).IsNull;
			}
			return false;
		}
		return true;
	}

	private OracleParameter CreateParams(string paramName, string colName, OracleDbType colType, DataRowVersion version, object value)
	{
		int size = -1;
		if (value != null)
		{
			if (value is char)
			{
				size = 1;
			}
			else if (value is string text)
			{
				size = text.Length;
			}
			else if (value is char[] array)
			{
				size = array.Length;
			}
			else if (value is byte[] array2)
			{
				size = array2.Length;
			}
		}
		switch (colType)
		{
		case OracleDbType.Clob:
			if (!(value is OracleClob))
			{
				colType = OracleDbType.Varchar2;
			}
			break;
		case OracleDbType.NClob:
			if (!(value is OracleClob))
			{
				colType = OracleDbType.NVarchar2;
			}
			break;
		case OracleDbType.Blob:
			if (!(value is OracleBlob))
			{
				colType = OracleDbType.Raw;
			}
			break;
		}
		OracleParameter oracleParameter = new OracleParameter(paramName, colType, size, colName, version, value);
		oracleParameter.m_modified = false;
		return oracleParameter;
	}

	private void SetParam(string colName, OracleDbType colType, DataRowVersion version, object value, OracleParameter param)
	{
		if (param.m_modified)
		{
			param.Direction = ParameterDirection.Input;
			param.IsNullable = false;
			param.Offset = 0;
			param.Status = OracleParameterStatus.Success;
			param.Precision = 100;
			param.Scale = 129;
			param.UdtTypeName = null;
		}
		int size = -1;
		if (value != null)
		{
			if (value is char)
			{
				size = 1;
			}
			else if (value is string text)
			{
				size = text.Length;
			}
			else if (value is char[] array)
			{
				size = array.Length;
			}
			else if (value is byte[] array2)
			{
				size = array2.Length;
			}
		}
		switch (colType)
		{
		case OracleDbType.Clob:
			if (!(value is OracleClob))
			{
				colType = OracleDbType.Varchar2;
			}
			break;
		case OracleDbType.NClob:
			if (!(value is OracleClob))
			{
				colType = OracleDbType.NVarchar2;
			}
			break;
		case OracleDbType.Blob:
			if (!(value is OracleBlob))
			{
				colType = OracleDbType.Raw;
			}
			break;
		}
		param.ParameterName = null;
		param.OracleDbType = colType;
		param.SetSize(size);
		param.SourceColumn = colName;
		param.SourceVersion = version;
		param.Value = value;
	}

	private bool IsOraLOB(OracleDbType colType)
	{
		if (colType != OracleDbType.Blob && colType != OracleDbType.Clob && colType != OracleDbType.NClob)
		{
			return colType == OracleDbType.BFile;
		}
		return true;
	}

	private bool IsOraLONG(OracleDbType colType)
	{
		if (colType != OracleDbType.Long)
		{
			return colType == OracleDbType.LongRaw;
		}
		return true;
	}

	private bool IsOraXmlType(OracleDbType colType)
	{
		return colType == OracleDbType.XmlType;
	}

	private bool IsOraUDT(OracleDbType colType)
	{
		if (colType != OracleDbType.Object)
		{
			return colType == OracleDbType.Array;
		}
		return true;
	}

	private string GetBaseTableName()
	{
		return GetBaseTableName(m_caseSensitive);
	}

	private string GetBaseTableName(bool caseSensitive)
	{
		string text = null;
		GetOpoMetRefCtx();
		if (m_opoMetRefCtx != null)
		{
			text = m_opoMetRefCtx.pTableName;
		}
		if (text == null)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.BLR_MULTITABLE_DS));
		}
		if (caseSensitive)
		{
			return text.Insert(text.Length, "\"").Insert(0, "\"");
		}
		return text;
	}

	private string GetBaseTableName(DataTable table)
	{
		return GetBaseTableName(table, m_caseSensitive);
	}

	private string GetBaseTableName(DataTable table, bool caseSensitive)
	{
		string text = null;
		object obj = null;
		obj = table.ExtendedProperties["BaseTable.0"];
		if (obj == null)
		{
			GetOpoMetRefCtx();
			if (m_opoMetRefCtx != null)
			{
				text = m_opoMetRefCtx.pTableName;
			}
		}
		else
		{
			text = (string)obj;
		}
		if (text == null)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.BLR_MULTITABLE_DS));
		}
		if (caseSensitive)
		{
			return text.Insert(text.Length, "\"").Insert(0, "\"");
		}
		return text;
	}

	protected override DataTable GetSchemaTable(DbCommand srcCommand)
	{
		OracleCommand oracleCommand = srcCommand as OracleCommand;
		OracleDataReader oracleDataReader = oracleCommand.ExecuteReader(CommandBehavior.SchemaOnly | CommandBehavior.KeyInfo);
		return oracleDataReader.GetSchemaTable();
	}

	private string GetSchemaName()
	{
		StringBuilder stringBuilder = new StringBuilder();
		string text = null;
		GetOpoMetRefCtx();
		if (m_opoMetRefCtx != null)
		{
			text = m_opoMetRefCtx.pSchemaName;
		}
		if (text != null && text.Length != 0)
		{
			if (m_caseSensitive)
			{
				stringBuilder.Append("\"");
				stringBuilder.Append(m_opoMetRefCtx.pSchemaName);
				stringBuilder.Append("\"");
			}
			else
			{
				stringBuilder.Append(m_opoMetRefCtx.pSchemaName);
			}
			stringBuilder.Append(".");
		}
		return stringBuilder.ToString();
	}

	private string GetSchemaName(DataTable table)
	{
		StringBuilder stringBuilder = new StringBuilder();
		string text = null;
		object obj = table.ExtendedProperties["BaseSchema"];
		if (obj == null)
		{
			GetOpoMetRefCtx();
			if (m_opoMetRefCtx != null)
			{
				text = m_opoMetRefCtx.pSchemaName;
			}
		}
		else
		{
			text = (string)obj;
		}
		if (text != null && text.Length != 0)
		{
			if (m_caseSensitive)
			{
				stringBuilder.Append("\"");
				stringBuilder.Append(text);
				stringBuilder.Append("\"");
			}
			else
			{
				stringBuilder.Append(text);
			}
			stringBuilder.Append(".");
		}
		return stringBuilder.ToString();
	}

	private bool CheckDataTable(DataTable table)
	{
		if (table.ExtendedProperties["BaseTable.1"] != null)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.BLR_MULTITABLE_DS));
		}
		return true;
	}

	private unsafe void CheckPrimaryKey(DataRow row)
	{
		for (int i = 0; i < row.Table.Constraints.Count; i++)
		{
			if (row.Table.Constraints[i] is UniqueConstraint)
			{
				return;
			}
		}
		if (row.Table.ExtendedProperties.Contains("REFCursorName"))
		{
			if (m_dataAdapter != null && m_dataAdapter.SelectCommand != null)
			{
				StoredProcedureInfo storedProcInfo = RegAndConfigRdr.GetStoredProcInfo(m_dataAdapter.SelectCommand.CommandText);
				if (storedProcInfo != null)
				{
					string text = (string)row.Table.ExtendedProperties["REFCursorName"];
					int result = -1;
					if (text.Equals("REFCursor"))
					{
						result = 0;
					}
					else
					{
						int.TryParse(text.Substring("RefCursor".Length), out result);
					}
					if (result > -1)
					{
						RefCursorInfo refCursorInfo = (RefCursorInfo)storedProcInfo.refCursors[result];
						if (refCursorInfo.isPrimaryKeyPresent)
						{
							return;
						}
					}
				}
			}
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.BLR_NO_PRIMARYKEY));
		}
		if (m_pOpoMetValCtx == null)
		{
			GetOpoMetValCtx();
		}
		CheckPrimaryKey();
	}

	private unsafe void CheckPrimaryKey()
	{
		if (m_pOpoMetValCtx == null)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.BLR_NO_PRIMARYKEY));
		}
		if (m_pOpoMetValCtx->bPkFetched != 1)
		{
			m_dataAdapter.SelectCommand.GetPrimaryKey(m_metaData, openCon: true);
		}
		if (m_pOpoMetValCtx->bPkPresent != 1)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.BLR_NO_PRIMARYKEY));
		}
	}

	private unsafe bool IsNullableCol(int index)
	{
		if (m_pOpoMetValCtx->pColMetaVal[index].NullOK == 1)
		{
			return true;
		}
		return false;
	}

	private bool IsRowCurrentValueNull(DataRow row, DataColumn col)
	{
		object obj = row[col, DataRowVersion.Current];
		if (obj != DBNull.Value)
		{
			if (obj is INullable)
			{
				return (obj as INullable).IsNull;
			}
			return false;
		}
		return true;
	}
}
