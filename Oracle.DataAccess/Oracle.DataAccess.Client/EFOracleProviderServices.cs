using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Common.CommandTrees;
using System.Data.Common.Utils;
using System.Data.Metadata.Edm;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using Oracle.DataAccess.Client.SqlGen;

namespace Oracle.DataAccess.Client;

internal sealed class EFOracleProviderServices : DbProviderServices
{
	internal delegate void EdmInUseEvent(object sender);

	internal static readonly EFOracleProviderServices Instance = new EFOracleProviderServices();

	internal static string m_conStr = null;

	internal static Hashtable m_schemaFilterHashtable = null;

	internal static string m_filteringStrs = null;

	internal static string[] m_filteringStrArray = null;

	internal static EFOracleVersion version = EFOracleVersion.Oracle11gR2;

	internal static bool m_10202_or_later_version = false;

	internal static bool m_hasFiredEdmInUseEvent = false;

	public static bool m_GetDbProviderManifestTokenWasCalled = false;

	public static bool m_Entered_Edm_Query6 = false;

	private string query3_StartsWith = "SELECT \r\n\"Project3\".\"C4\" AS \"C1\", \r\n\"Project3\".\"C1\" AS \"C2\", \r\n\"Project3\".\"C2\" AS \"C3\", \r\n\"Project3\".\"C3\" AS \"C4\"\r\nFROM ( SELECT \r\n";

	private string Oracle_own_query3 = "select  \r\n\t1,  \r\n\tNULL,  \r\n\textent1.owner,  \r\n\tId  \r\nfrom  \r\n(  \r\nselect  \r\n\tap.owner,  \r\n\tobject_id,  \r\n\tsubprogram_id,  \r\n\t(CASE WHEN ap.procedure_name IS NULL THEN ap.object_name ELSE ap.object_name || '.' || ap.procedure_name END) Id, \r\n\toverload \r\nfrom \r\n\tall_procedures ap  \r\nwhere  \r\n\tap.owner in (SYS_CONTEXT('USERENV', 'CURRENT_USER')) and  \r\n\t(ap.object_type = 'PROCEDURE' or  \r\n         (ap.object_type = 'FUNCTION') or  \r\n         (ap.object_type='PACKAGE' and ap.procedure_name IS NOT NULL)  \r\n        ) and \r\n\t(OVERLOAD IS NULL OR OVERLOAD = '1') and \r\n\t(INSTR(object_name, '.') = 0) \r\n) extent1 \r\nleft outer join \r\n( \r\nselect  \r\n\towner, \r\n\tobject_id, \r\n\tsubprogram_id, \r\n\tdata_type, \r\n\tposition \r\nfrom  \r\n\tall_arguments aa  \r\nwhere  \r\n\taa.owner in (SYS_CONTEXT('USERENV', 'CURRENT_USER')) and  \r\n\tposition = 0 and  \r\n\tdata_type != 'REF CURSOR' \r\n) extent2 \r\non \r\n\textent1.object_id = extent2.object_id and \r\n\textent1.subprogram_id = extent2.subprogram_id \r\norder by 3 asc, 4 asc";

	private string query4_5_StartsWith = "SELECT \r\n\"Project6\".\"C2\" AS \"C1\", \r\n\"Project6\".\"CatalogName\" AS \"CatalogName\", \r\n\"Project6\".\"SchemaName\" AS \"SchemaName\", \r\n\"Project6\".\"Name\" AS \"Name\", \r\n\"Project6\".\"C1\" AS \"C2\", \r\n\"Project6\".\"C3\" AS \"C3\", \r\n\"Project6\".\"C4\" AS \"C4\", \r\n\"Project6\".\"C5\" AS \"C5\", \r\n\"Project6\".\"C6\" AS \"C6\", \r\n\"Project6\".\"C7\" AS \"C7\", \r\n\"Project6\".\"C8\" AS \"C8\", \r\n\"Project6\".\"C9\" AS \"C9\", \r\n\"Project6\".\"C10\" AS \"C10\", \r\n\"Project6\".\"C11\" AS \"C11\"\r\nFROM ( SELECT ";

	private string query4_5_framework_sp1_StartsWith = "SELECT \r\n\"UnionAll1\".\"Ordinal\" AS \"C1\", \r\n\"Extent1\".\"CatalogName\" AS \"CatalogName\", \r\n\"Extent1\".\"SchemaName\" AS \"SchemaName\", \r\n\"Extent1\".\"Name\" AS \"Name\", \r\n\"UnionAll1\".\"Name\" AS \"C2\", \r\n\"UnionAll1\".\"IsNullable\" AS \"C3\", \r\n\"UnionAll1\".\"TypeName\" AS \"C4\", \r\n\"UnionAll1\".\"MaxLength\" AS \"C5\", \r\n\"UnionAll1\".\"Precision\" AS \"C6\", \r\n\"UnionAll1\".\"DateTimePrecision\" AS \"C7\", \r\n\"UnionAll1\".\"Scale\" AS \"C8\", \r\n\"UnionAll1\".\"IsIdentity\" AS \"C9\", \r\n\"UnionAll1\".\"IsStoreGenerated\" AS \"C10\", \r\nCASE WHEN (\"Project5\".\"C2\" IS NULL) THEN 0 ELSE \"Project5\".\"C2\" END AS \"C11\"\r\nFROM   (";

	private string Oracle_own_query4_5 = "select \r\n     extent1.column_id, \r\n     NULL Catalog, \r\n     extent1.owner, \r\n     extent1.table_name, \r\n     extent1.column_name, \r\n     extent1.\"IsNullable\", \r\n     extent1.\"TypeName\", \r\n     extent1.\"data_length\", \r\n     extent1.\"Precision\", \r\n     extent1.\"DateTimePrecision\", \r\n     extent1.data_scale, \r\n     extent1.IsIdentity, \r\n     extent1.IsStoreGenerated, \r\n     (CASE \r\n         WHEN extent2.constraint_type = 'P' THEN 1 \r\n         ELSE 0 \r\n     END) constraint_type \r\nfrom \r\n( \r\n     select \r\n         atc.column_id, \r\n         atc.owner, \r\n         atc.table_name, \r\n         atc.column_name, \r\n         CASE atc.NULLABLE WHEN 'Y' THEN 1 ELSE 0 END \"IsNullable\", \r\n                 (CASE \r\n             WHEN INSTR(atc.data_type, 'INTERVAL YEAR') != 0 THEN  \r\n'interval year to month' \r\n                     WHEN INSTR(atc.data_type, 'INTERVAL DAY')  != 0 \r\nTHEN 'interval day to second' \r\n                     WHEN INSTR(atc.data_type, 'WITH TIME ZONE')  != 0 \r\nTHEN 'timestamp with time zone' \r\n                     WHEN INSTR(atc.data_type, 'WITH LOCAL TIME ZONE') \r\n!= 0 THEN 'timestamp with local time zone' \r\n                     WHEN INSTR(atc.data_type, 'TIMESTAMP') != 0 AND  \r\nINSTR(atc.data_type, 'TIME ZONE') = 0 THEN 'timestamp' \r\n                     ELSE LOWER(atc.data_type) \r\n         END) \"TypeName\", \r\n          CASE atc.data_type  \r\n          WHEN 'CHAR' THEN atc.char_length \r\n          WHEN 'VARCHAR2' THEN atc.char_length \r\n          WHEN 'NCHAR' THEN atc.char_length \r\n          WHEN 'NVARCHAR2' THEN atc.char_length  \r\n          ELSE atc.data_length END \"data_length\", \r\n         (CASE \r\n             WHEN INSTR(atc.data_type, 'INTERVAL YEAR') != 0 AND  \r\natc.DATA_PRECISION < atc.DATA_SCALE THEN atc.DATA_SCALE \r\n                 WHEN INSTR(atc.data_type, 'INTERVAL DAY') != 0 AND  \r\natc.DATA_PRECISION < atc.DATA_SCALE THEN atc.DATA_SCALE \r\n                 ELSE atc.DATA_PRECISION \r\n         END) \"Precision\", \r\n                 atc.DATA_PRECISION      \"DateTimePrecision\", \r\n         atc.data_scale, \r\n                 0 IsIdentity, \r\n                 0 IsStoreGenerated \r\n     from \r\n         all_tab_columns atc \r\n     where \r\n         ( owner in (SYS_CONTEXT('USERENV', 'CURRENT_USER')) and \r\n           [WHERECLAUSE1]  \r\n         ) \r\n) extent1 \r\nleft outer join \r\n( \r\n     select \r\n         acc.owner, \r\n         acc.table_name, \r\n         acc.column_name, \r\n                 ac.constraint_type \r\n     from \r\n         all_cons_columns acc, \r\n         all_constraints ac \r\n     where \r\n         acc.owner in (SYS_CONTEXT('USERENV', 'CURRENT_USER')) and \r\n         acc.owner = ac.owner and \r\n         acc.table_name = ac.table_name and \r\n         acc.constraint_name = ac.constraint_name and \r\n         ac.constraint_type = 'P' and  \r\n         ( \r\n           [WHERECLAUSE2]  \r\n         ) \r\n) extent2 \r\non \r\n     extent1.owner = extent2.owner and \r\n     extent1.table_name = extent2.table_name and \r\n     extent1.column_name = extent2.column_name \r\norder by extent1.owner asc, extent1.table_name asc, extent1.column_id asc \r\n";

	private string query6_StartsWith = "SELECT \r\n\"Project11\".\"C1\" AS \"C1\", \r\n\"Project11\".\"C5\" AS \"C2\", \r\n\"Project11\".\"C6\" AS \"C3\", \r\n\"Project11\".\"C4\" AS \"C4\", \r\n\"Project11\".\"C2\" AS \"C5\", \r\n\"Project11\".\"C8\" AS \"C6\", \r\n\"Project11\".\"C9\" AS \"C7\", \r\n\"Project11\".\"C7\" AS \"C8\", \r\n\"Project11\".\"C3\" AS \"C9\", \r\n\"Project11\".\"Name\" AS \"Name\", \r\n\"Project11\".\"Id\" AS \"Id\", \r\n\"Project11\".\"C10\" AS \"C10\"\r\nFROM ( SELECT ";

	private string query6_framework_sp1_StartsWith = "SELECT \r\n\"Join5\".\"Ordinal\" AS \"C1\", \r\n\"UnionAll4\".\"CatalogName\" AS \"C2\", \r\n\"UnionAll4\".\"SchemaName\" AS \"C3\", \r\n\"UnionAll4\".\"Name\" AS \"C4\", \r\n\"Join5\".\"Name1\" AS \"C5\", \r\n\"UnionAll5\".\"CatalogName\" AS \"C6\", \r\n\"UnionAll5\".\"SchemaName\" AS \"C7\", \r\n\"UnionAll5\".\"Name\" AS \"C8\", \r\n\"Join5\".\"Name2\" AS \"C9\", \r\n\"Extent2\".\"Name\" AS \"Name\", \r\n\"Extent1\".\"Id\" AS \"Id\", \r\nCASE WHEN (\"Extent1\".\"DeleteRule\" = 'CASCADE') THEN 1 WHEN (\"Extent1\".\"DeleteRule\" <> 'CASCADE') THEN 0 END AS \"C10\"\r\nFROM     (";

	private string Oracle_own_query6 = "select \r\n\textent1.fk_ordinal    \"C1\", \r\n\tNULL                  \"C2\", \r\n\textent2.pk_owner      \"C3\", \r\n\textent2.pk_table      \"C4\", \r\n\textent2.pk_column     \"C5\", \r\n\tNULL                  \"C6\", \r\n\textent1.fk_owner      \"C7\", \r\n\textent1.fk_table      \"C8\", \r\n\textent1.fk_column     \"C9\", \r\n\textent1.fk_cname      \"Name\", \r\n\textent1.id            \"Id\", \r\n\textent1.fk_deleterule \"C10\" \r\nfrom \r\n( \r\n\tselect \r\n\t\tc1.owner fk_owner, \r\n\t\tc1.table_name fk_table, \r\n\t\tc1.r_constraint_name pk_cname, \r\n\t\tc1.constraint_name fk_cname, \r\n\t\tCASE WHEN c1.delete_rule = 'CASCADE' THEN 1 ELSE 0 END fk_deleterule, \r\n\t\tacc.position fk_ordinal, \r\n\t\tacc.column_name fk_column, \r\n\t\t'''' || acc.table_name || '_' || acc.constraint_name || '''' id \r\n\tfrom \r\n\t\tall_constraints c1, \r\n\t\tall_cons_columns acc \r\n\twhere \r\n\t\tc1.owner in (SYS_CONTEXT('USERENV', 'CURRENT_USER')) and  \r\n\t\tc1.constraint_type = 'R' and \r\n\t\tc1.owner = acc.owner and \r\n\t\tc1.table_name = acc.table_name and \r\n\t\tc1.constraint_name = acc.constraint_name and \r\n\t\t( \r\n     [WHERECLAUSE1] \r\n\t\t) \r\n) extent1 \r\ninner join \r\n( \r\n\tselect \r\n\t\tc2.owner pk_owner, \r\n\t\tc2.table_name pk_table, \r\n\t\tc2.constraint_name pk_cname, \r\n\t\tc2.delete_rule pk_deleterule, \r\n\t\tacc2.column_name pk_column, \r\n   acc2.position position \r\n\tfrom \r\n\t\tall_constraints c2, \r\n\t\tall_cons_columns acc2 \r\n\twhere \r\n\t\tc2.owner in (SYS_CONTEXT('USERENV', 'CURRENT_USER')) and  \r\n\t\tc2.constraint_type = 'P' and \r\n\t\tc2.owner = acc2.owner and \r\n\t\tc2.table_name = acc2.table_name and \r\n\t\tc2.constraint_name = acc2.constraint_name and \r\n\t\t( \r\n     [WHERECLAUSE2] \r\n\t\t)\t\r\n) extent2 \r\nON \r\nextent1.pk_cname = extent2.pk_cname and extent1.fk_ordinal = extent2.position \r\norder by \"Name\", \"Id\", \"C1\" ";

	private string query7_StartsWith = "SELECT \r\n\"Project7\".\"C12\" AS \"C1\", \r\n";

	private string Oracle_own_query7 = "select  \r\n\t1 AS C1,  \r\n\textent5.owner AS C2,  \r\n\textent5.Id,  \r\n\t(CASE  \r\n\t\tWHEN INSTR(ReturnType, 'INTERVAL YEAR') != 0 THEN  'interval year to month'  \r\n\t\tWHEN INSTR(ReturnType, 'INTERVAL DAY')  != 0 THEN 'interval day to second'  \r\n\t\tWHEN INSTR(ReturnType, 'WITH TIME ZONE')  != 0 THEN 'timestamp with time zone'  \r\n\t\tWHEN INSTR(ReturnType, 'WITH LOCAL TIME ZONE') != 0 THEN 'timestamp with local time zone'  \r\n\t\tWHEN (INSTR(ReturnType, 'TIMESTAMP') != 0 AND INSTR(ReturnType, 'TIME ZONE') = 0) THEN 'timestamp'  \r\n   WHEN INSTR(ReturnType, 'UNDEFINED')  != 0 THEN LOWER(type_name)   \r\n\t\tELSE LOWER(ReturnType) END) AS C4,  \r\n\t\t0 AS C5,  \r\n\t(CASE WHEN ReturnType IS NULL THEN 0 ELSE 1 END) AS C6,  \r\n\t0 AS C7,  \r\n\t0 AS C8,  \r\n\targument_name AS C9, \r\n\t(CASE \r\n\t\tWHEN INSTR(data_type, 'INTERVAL YEAR') != 0 THEN  'interval year to month' \r\n\t\tWHEN INSTR(data_type, 'INTERVAL DAY')  != 0 THEN 'interval day to second' \r\n\t\tWHEN INSTR(data_type, 'WITH TIME ZONE')  != 0 THEN 'timestamp with time zone' \r\n\t\tWHEN INSTR(data_type, 'WITH LOCAL TIME ZONE') != 0 THEN 'timestamp with local time zone' \r\n\t\tWHEN (INSTR(data_type, 'TIMESTAMP') != 0 AND INSTR(data_type, 'TIME ZONE') = 0) THEN 'timestamp' \r\n   WHEN INSTR(data_type, 'UNDEFINED')  != 0 THEN LOWER(type_name) \r\n\t\tELSE LOWER(data_type) END) AS C10, \r\n\tdirection AS C11, \r\n type_name as C12 \r\nfrom \r\n( \r\n\tselect \r\n\t\textent3.owner, \r\n\t\textent3.object_id, \r\n\t\textent3.subprogram_id, \r\n\t\textent3.Id, \r\n\t\tReturnType \r\n\tfrom \r\n\t( \r\n\t\tselect \r\n\t\t\textent1.owner, \r\n\t\t\textent1.object_id, \r\n\t\t\textent1.subprogram_id, \r\n\t\t\textent1.Id, \r\n\t\t\textent2.ReturnType \r\n\t\tfrom \r\n\t\t( \r\n\t\t\tselect \r\n\t\t\t\towner, \r\n\t\t\t\tobject_id, \r\n\t\t\t\tsubprogram_id, \r\n\t\t\t\tId \t\r\n\t\t\tfrom \r\n\t\t\t( \r\n\t\t\t\tselect \r\n\t\t\t\t\towner, \r\n\t\t\t\t\tobject_id, \r\n\t\t\t\t\tsubprogram_id, \r\n\t\t\t\t\t(CASE WHEN ap.procedure_name IS NULL THEN ap.object_name ELSE ap.object_name || '.' || ap.procedure_name END) Id \r\n\t\t\t\tfrom \r\n\t\t\t\t\tall_procedures ap \r\n\t\t\t\twhere \r\n\t\t\t\t\tap.owner in (SYS_CONTEXT('USERENV', 'CURRENT_USER')) and \r\n\t\t\t\t\t(ap.object_type = 'PROCEDURE' or \r\n\t\t\t\t\t(ap.object_type = 'FUNCTION') or \r\n\t\t\t\t\t(ap.object_type='PACKAGE' and ap.procedure_name IS NOT NULL) \r\n\t\t\t\t\t) and \r\n\t\t\t\t\t(OVERLOAD IS NULL OR OVERLOAD = '1') and \r\n\t\t\t\t\t(INSTR(object_name, '.') = 0) \r\n\t\t\t) \r\n\t\t\twhere \r\n\t\t\t( \r\n\t\t\t\t[WHERECLAUSE] \r\n\t\t\t) \r\n\t\t) extent1 \r\n\t\tleft outer join  \r\n\t\t(  \r\n\t\t\tselect  \r\n\t\t\t\tobject_id,  \r\n\t\t\t\tsubprogram_id,  \r\n\t\t\t\tdata_type ReturnType,  \r\n       type_name  \r\n\t\t\tfrom  \r\n\t\t\t\tall_arguments aa  \r\n\t\t\twhere  \r\n\t\t\t\taa.owner in (SYS_CONTEXT('USERENV', 'CURRENT_USER')) and  \r\n\t\t\t\tposition = 0 and  \r\n\t\t\t\tdata_type != 'REF CURSOR'  \r\n\t\t) extent2  \r\n\t\ton  \r\n\t\t\textent1.object_id = extent2.object_id and  \r\n\t\t\textent1.subprogram_id = extent2.subprogram_id  \r\n\t) extent3  \r\n\tleft outer join  \r\n\t(  \r\n\t\tselect \r\n\t\t\tobject_id,  \r\n\t\t\tsubprogram_id,  \r\n\t\t\tId,  \r\n\t\t\tdata_type, \r\n     type_name \r\n \t\tfrom \r\n\t\t( \r\n\t\t\tselect  \r\n\t\t\t\towner, \r\n\t\t\t\tobject_id,  \r\n\t\t\t\tsubprogram_id,  \r\n\t\t\t\t(CASE WHEN aa.PACKAGE_NAME IS NOT NULL THEN aa.PACKAGE_NAME || '.' || aa.OBJECT_NAME ELSE aa.OBJECT_NAME END) Id,  \r\n\t\t\t\tdata_type,  \r\n       type_name \r\n\t\t\tfrom  \r\n\t\t\t\tall_arguments aa  \r\n\t\t\twhere   \r\n\t\t\t\taa.owner in (SYS_CONTEXT('USERENV', 'CURRENT_USER')) and  \r\n\t\t\t\tsequence != position and  \r\n\t\t\t\t(overload is NULL or overload ='1') and  \r\n\t\t\t\tposition = 0  \r\n\t\t) \r\n\t\twhere \r\n\t\t( \r\n\t\t\t[WHERECLAUSE] \r\n\t\t) \r\n\t) extent4  \r\n\ton  \r\n\t\textent3.object_id = extent4.object_id and  \r\n\t\textent3.subprogram_id = extent4.subprogram_id \r\n) extent5  \r\nleft outer join  \r\n(  \r\n\tselect  \r\n\t\tobject_id,  \r\n\t\tsubprogram_id,  \r\n\t\tposition,  \r\n\t\tId,  \r\n\t\tdata_type,  \r\n\t\targument_name,  \r\n\t\tdirection,  \r\n   type_name  \r\n\tfrom  \r\n\t(  \r\n\t\tselect  \r\n\t\t\towner,  \r\n\t\t\tobject_id,  \r\n\t\t\tsubprogram_id,  \r\n\t\t\tposition,  \r\n\t\t\t(CASE WHEN aa.PACKAGE_NAME IS NOT NULL THEN aa.PACKAGE_NAME || '.' || aa.OBJECT_NAME ELSE aa.OBJECT_NAME END) Id,  \r\n\t\t\tdata_type,  \r\n\t\t\targument_name,  \r\n     (CASE WHEN IN_OUT = 'IN/OUT' THEN 'INOUT' ELSE IN_OUT END) direction,  \r\n     type_name  \r\n\t\tfrom  \r\n     all_arguments aa  \r\n\t\twhere  \r\n\t\t(  \r\n\t\t\towner in (SYS_CONTEXT('USERENV', 'CURRENT_USER')) and  \r\n\t\t\taa.position > 0 and  \r\n\t\t\tdata_level = 0 and  \r\n\t\t\tdata_type != 'REF CURSOR'  \r\n\t\t) \r\n\t)  \r\n\twhere  \r\n\t(  \r\n\t\t[WHERECLAUSE] \r\n\t)  \r\n) extent6  \r\non  \r\n\textent5.object_id = extent6.object_id and  \r\n\textent5.subprogram_id = extent6.subprogram_id \r\norder by 2 asc, 3 asc, position asc";

	private string Oracle_own_query3_for_10201_or_earlier = "select  \r\n\t1,  \r\n\tNULL,  \r\n\towner,  \r\n\tId  \r\nfrom  \r\n(  \r\n  select \r\n\towner, \r\n  object_id,  \r\n\t(CASE WHEN PACKAGE_NAME IS NOT NULL THEN PACKAGE_NAME || '.' || OBJECT_NAME ELSE OBJECT_NAME END) Id, \r\n\toverload \r\n  from \r\n\tall_arguments \r\n  where  \r\n\towner in (SYS_CONTEXT('USERENV', 'CURRENT_USER')) AND \r\n\t(OVERLOAD IS NULL OR OVERLOAD = '1') AND \r\n\t(INSTR(object_name, '.') = 0) AND \r\n DATA_LEVEL = 0 AND ((POSITION = 0 AND SEQUENCE = 1) OR (POSITION = 1 AND SEQUENCE = 0) OR (SEQUENCE = 1)) \r\n) \r\norder by 3 asc, 4 asc";

	private string Oracle_own_query7_for_10201_or_earlier = "select   \r\n\t1 AS C1,   \r\n\textent5.owner AS C2,   \r\n\textent5.Id,   \r\n\t(CASE   \r\n\t\tWHEN INSTR(ReturnType, 'INTERVAL YEAR') != 0 THEN  'interval year to month'   \r\n\t\tWHEN INSTR(ReturnType, 'INTERVAL DAY')  != 0 THEN 'interval day to second'   \r\n\t\tWHEN INSTR(ReturnType, 'WITH TIME ZONE')  != 0 THEN 'timestamp with time zone'   \r\n\t\tWHEN INSTR(ReturnType, 'WITH LOCAL TIME ZONE') != 0 THEN 'timestamp with local time zone'   \r\n\t\tWHEN (INSTR(ReturnType, 'TIMESTAMP') != 0 AND INSTR(ReturnType, 'TIME ZONE') = 0) THEN 'timestamp'   \r\n   \t\tWHEN INSTR(ReturnType, 'UNDEFINED')  != 0 THEN LOWER(type_name) \r\n            WHEN INSTR(ReturnType, 'REF CURSOR')  != 0 THEN LOWER(type_name)   \r\n\t\tELSE LOWER(ReturnType) END) AS C4,   \r\n\t\t0 AS C5,   \r\n\t\t(CASE WHEN ((ReturnType IS NULL) OR (ReturnType = 'REF CURSOR')) THEN 0 ELSE 1 END) AS C6,   \r\n\t\t0 AS C7,   \r\n\t\t0 AS C8,   \r\n\t\targument_name AS C9,  \r\n\t\t(CASE  \r\n\t\tWHEN INSTR(data_type, 'INTERVAL YEAR') != 0 THEN  'interval year to month'  \r\n\t\tWHEN INSTR(data_type, 'INTERVAL DAY')  != 0 THEN 'interval day to second'  \r\n\t\tWHEN INSTR(data_type, 'WITH TIME ZONE')  != 0 THEN 'timestamp with time zone'  \r\n\t\tWHEN INSTR(data_type, 'WITH LOCAL TIME ZONE') != 0 THEN 'timestamp with local time zone'  \r\n\t\tWHEN (INSTR(data_type, 'TIMESTAMP') != 0 AND INSTR(data_type, 'TIME ZONE') = 0) THEN 'timestamp'  \r\n            WHEN INSTR(data_type, 'UNDEFINED')  != 0 THEN LOWER(type_name)  \r\n\t\tELSE LOWER(data_type) END) AS C10,  \r\n\t\tdirection AS C11,  \r\n \t\ttype_name as C12  \r\nfrom  \r\n(  \r\n\tselect  \r\n\t\textent3.owner,  \r\n\t\textent3.Id,  \r\n\t\tReturnType  \r\n\tfrom  \r\n\t(  \r\n\t\tselect  \r\n\t\t\textent1.owner,  \r\n\t\t\textent1.Id,  \r\n\t\t\textent1.ReturnType \r\n\t\tfrom  \r\n\t\t(  \r\n\t\t\tselect  \r\n\t\t\t\towner,  \r\n\t\t\t\tId, \r\n\t\t\t\tReturnType, \r\n\t\t\t\tposition \r\n\t\t\tfrom  \r\n\t\t\t(  \r\n\t\t\t\tselect  \r\n\t\t\t\t\towner, \r\n\t\t\t\t\t(CASE WHEN (position > 0) THEN NULL ELSE data_type END) ReturnType, \r\n\t\t\t\t\tposition,   \r\n\t\t\t\t\t(CASE WHEN aa.package_name IS NULL THEN aa.object_name ELSE aa.package_name || '.' || aa.object_name END) Id  \r\n\t\t\t\tfrom  \r\n\t\t\t\t\tall_arguments aa  \r\n\t\t\t\twhere  \r\n\t\t\t\t\taa.owner in (SYS_CONTEXT('USERENV', 'CURRENT_USER')) and  \r\n\t\t\t\t\t(OVERLOAD IS NULL OR OVERLOAD = '1') and  \r\n\t\t\t\t\t(INSTR(object_name, '.') = 0) and \r\n\t\t\t\t\tDATA_LEVEL = 0 and \r\n    \t\t  ((POSITION = 0 AND SEQUENCE = 1) OR (POSITION = 1 AND SEQUENCE = 0) OR (SEQUENCE = 1)) \r\n\t\t\t)  \r\n\t\t\twhere  \r\n\t\t\t(  \r\n\t\t    [WHERECLAUSE] \r\n\t\t\t)  \r\n\t\t) extent1  \r\n\t) extent3   \r\n\tleft outer join   \r\n\t(   \r\n\t\tselect   \r\n\t\t\tId,   \r\n\t\t\tdata_type,  \r\n     \ttype_name  \r\n \t\tfrom  \r\n\t\t(  \r\n\t\t\tselect   \r\n\t\t\towner,  \r\n\t\t\t(CASE WHEN aa.PACKAGE_NAME IS NOT NULL THEN aa.PACKAGE_NAME || '.' || aa.OBJECT_NAME ELSE aa.OBJECT_NAME END) Id,     \r\n\t\t\tdata_type,   \r\n       \t\t\ttype_name  \r\n\t\t\tfrom   \r\n\t\t\t\tall_arguments aa   \r\n\t\t\twhere    \r\n\t\t\t\taa.owner in (SYS_CONTEXT('USERENV', 'CURRENT_USER')) and \r\n\t\t\t\tsequence != position and   \r\n\t\t\t\t(overload is NULL or overload ='1') and \r\n\t\t\t\tposition = 0 AND data_type != 'REF CURSOR' \r\n\t\t)  \r\n\t\twhere  \r\n\t\t(  \r\n\t\t  [WHERECLAUSE] \r\n\t\t)  \r\n\t) extent4   \r\n\ton   \r\n\t\textent3.Id = extent4.Id \r\n) extent5   \r\nleft outer join   \r\n(   \r\n\tselect   \r\n\t\tposition,   \r\n\t\tId,   \r\n\t\tdata_type,   \r\n\t\targument_name,   \r\n\t\tdirection,   \r\n   \ttype_name   \r\n\tfrom   \r\n\t(   \r\n\t\tselect   \r\n\t\t\towner,   \r\n\t\t\tposition,   \r\n\t\t\t(CASE WHEN aa.PACKAGE_NAME IS NOT NULL THEN aa.PACKAGE_NAME || '.' || aa.OBJECT_NAME ELSE aa.OBJECT_NAME END) Id,   \r\n\t\t\tdata_type,   \r\n\t\t\targument_name,  \r\n\t\t\t(CASE WHEN IN_OUT = 'IN/OUT' THEN 'INOUT' ELSE IN_OUT END) direction,   \r\n     \ttype_name   \r\n\t\tfrom   \r\n     \tall_arguments aa   \r\n\t\twhere   \r\n\t\t(   \r\n\t\t\towner in (SYS_CONTEXT('USERENV', 'CURRENT_USER')) and  \r\n\t\t\t(OVERLOAD IS NULL OR OVERLOAD = '1') and   \r\n\t\t\taa.position > 0 and   \r\n\t\t\tdata_level = 0 and   \r\n\t\t\tdata_type != 'REF CURSOR'   \r\n\t\t)  \r\n\t)   \r\n\twhere   \r\n\t(   \r\n\t\t[WHERECLAUSE] \r\n\t)   \r\n) extent6   \r\non   \r\n\textent5.Id = extent6.Id \r\norder by 2 asc, 3 asc, position asc";

	internal static event EdmInUseEvent m_edmInUseEvent;

	internal static void setSchemaFilter(Hashtable schemaFilterHashtable)
	{
		if (schemaFilterHashtable != null)
		{
			m_schemaFilterHashtable = schemaFilterHashtable;
		}
	}

	internal static void FireEdmInUseEvent()
	{
		if (EFOracleProviderServices.m_edmInUseEvent != null)
		{
			EFOracleProviderServices.m_edmInUseEvent("ODP_EdmInUseEvent");
			m_hasFiredEdmInUseEvent = true;
		}
	}

	protected override DbCommandDefinition CreateDbCommandDefinition(DbProviderManifest providerManifest, DbCommandTree commandTree)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) EFOracleProviderServices::CreateDbCommandDefinition()\n");
		}
		if (!(providerManifest is EFOracleProviderManifest))
		{
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "EFOracleProviderServices"));
		}
		DbCommand prototype = CreateCommand((EFOracleProviderManifest)providerManifest, commandTree);
		DbCommandDefinition result = CreateCommandDefinition(prototype);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) EFOracleProviderServices::CreateDbCommandDefinition()\n");
		}
		return result;
	}

	private DbCommand CreateCommand(EFOracleProviderManifest providerManifest, DbCommandTree commandTree)
	{
		EntityUtils.CheckArgumentNull(providerManifest, "providerManifest");
		EntityUtils.CheckArgumentNull(commandTree, "commandTree");
		EFOracleVersion storageVersion = EFOracleVersionUtils.GetStorageVersion(providerManifest.Token);
		OracleCommand oracleCommand = new OracleCommand();
		Debugger.IsLogging();
		if (commandTree is DbQueryCommandTree dbQueryCommandTree && dbQueryCommandTree.Query is DbProjectExpression dbProjectExpression)
		{
			EdmType edmType = dbProjectExpression.Projection.ResultType.EdmType;
			if (edmType is StructuralType structuralType)
			{
				oracleCommand.ExpectedColumnTypes = new PrimitiveType[structuralType.Members.Count];
				for (int i = 0; i < structuralType.Members.Count; i++)
				{
					EdmMember edmMember = structuralType.Members[i];
					PrimitiveType primitiveType = edmMember.TypeUsage.EdmType as PrimitiveType;
					oracleCommand.ExpectedColumnTypes[i] = primitiveType;
				}
			}
		}
		if (commandTree is DbFunctionCommandTree dbFunctionCommandTree && dbFunctionCommandTree.ResultType != null)
		{
			EdmType edmType2 = MetadataHelpers.GetElementTypeUsage(dbFunctionCommandTree.ResultType).EdmType;
			if (MetadataHelpers.IsRowType(edmType2))
			{
				ReadOnlyMetadataCollection<EdmMember> members = ((RowType)edmType2).Members;
				oracleCommand.ExpectedColumnTypes = new PrimitiveType[members.Count];
				for (int j = 0; j < members.Count; j++)
				{
					EdmMember edmMember2 = members[j];
					PrimitiveType primitiveType2 = (PrimitiveType)edmMember2.TypeUsage.EdmType;
					oracleCommand.ExpectedColumnTypes[j] = primitiveType2;
				}
			}
			else if (MetadataHelpers.IsPrimitiveType(edmType2))
			{
				oracleCommand.ExpectedColumnTypes = new PrimitiveType[1];
				oracleCommand.ExpectedColumnTypes[0] = (PrimitiveType)edmType2;
			}
		}
		oracleCommand.CommandText = SqlGenerator.GenerateSql(commandTree, providerManifest, storageVersion, out var parameters, out var commandType);
		oracleCommand.CommandType = commandType;
		Debugger.IsLogging();
		EdmFunction edmFunction = null;
		if (commandTree is DbFunctionCommandTree)
		{
			edmFunction = ((DbFunctionCommandTree)commandTree).EdmFunction;
		}
		foreach (KeyValuePair<string, TypeUsage> parameter in commandTree.Parameters)
		{
			FunctionParameter item;
			OracleParameter param = ((edmFunction == null || !edmFunction.Parameters.TryGetValue(parameter.Key, ignoreCase: false, out item)) ? CreateOracleParameter(parameter.Key, parameter.Value, ParameterMode.In, DBNull.Value, storageVersion) : CreateOracleParameter(item.Name, item.TypeUsage, item.Mode, DBNull.Value, storageVersion));
			oracleCommand.Parameters.Add(param);
		}
		if (parameters != null && 0 < parameters.Count)
		{
			if (commandTree is DbFunctionCommandTree && commandTree is DbDeleteCommandTree && commandTree is DbInsertCommandTree && commandTree is DbUpdateCommandTree)
			{
				throw new InvalidOperationException();
			}
			foreach (OracleParameter item2 in parameters)
			{
				oracleCommand.Parameters.Add(item2);
			}
		}
		oracleCommand.m_isFromEF = true;
		oracleCommand.InitialLONGFetchSize = OraTrace.m_InitialLONGFetchSize;
		oracleCommand.BindByName = true;
		oracleCommand.InitialLOBFetchSize = OraTrace.m_InitialLOBFetchSize;
		if (m_GetDbProviderManifestTokenWasCalled)
		{
			m_Entered_Edm_Query6 = false;
			StringBuilder stringBuilder = new StringBuilder();
			m_filteringStrs = null;
			m_filteringStrArray = null;
			if (m_schemaFilterHashtable != null)
			{
				try
				{
					object obj = m_schemaFilterHashtable[m_conStr];
					if (obj != null)
					{
						m_filteringStrArray = (string[])obj;
					}
				}
				catch
				{
				}
			}
			if (m_filteringStrArray != null)
			{
				for (int k = 0; k < m_filteringStrArray.Length; k++)
				{
					if (!string.IsNullOrEmpty(m_filteringStrArray[k]))
					{
						if (k > 0)
						{
							stringBuilder.Append(", ");
						}
						stringBuilder.Append(":s");
						stringBuilder.Append(k.ToString());
					}
				}
				if (stringBuilder.Length > 0)
				{
					m_filteringStrs = stringBuilder.ToString();
				}
			}
			stringBuilder.Clear();
			string empty = string.Empty;
			string empty2 = string.Empty;
			if (oracleCommand.CommandText.StartsWith(query3_StartsWith))
			{
				if (m_10202_or_later_version)
				{
					oracleCommand.CommandText = Oracle_own_query3;
				}
				else
				{
					oracleCommand.CommandText = Oracle_own_query3_for_10201_or_earlier;
				}
				m_hasFiredEdmInUseEvent = false;
			}
			else if (oracleCommand.CommandText.StartsWith(query4_5_StartsWith) || oracleCommand.CommandText.StartsWith(query4_5_framework_sp1_StartsWith))
			{
				bool flag = false;
				if (oracleCommand.CommandText.Contains("IsUpdatable"))
				{
					flag = true;
				}
				empty = Oracle_own_query4_5;
				if (oracleCommand.Parameters.Count == 0)
				{
					if (!flag)
					{
						stringBuilder.Append("atc.table_name NOT IN (select object_name from all_objects where object_type='VIEW')");
					}
					else
					{
						stringBuilder.Append("atc.table_name NOT IN (select object_name from all_objects where object_type='TABLE')");
					}
				}
				else if (oracleCommand.Parameters.Count == 1)
				{
					if (oracleCommand.CommandText.Contains("WHERE ( NOT"))
					{
						stringBuilder.Append("NOT (atc.table_name like ");
						stringBuilder.Append(":");
						stringBuilder.Append(oracleCommand.Parameters[0].ToString());
						stringBuilder.Append(")");
					}
					else
					{
						stringBuilder.Append("atc.table_name like ");
						stringBuilder.Append(":");
						stringBuilder.Append(oracleCommand.Parameters[0].ToString());
						if (!flag)
						{
							stringBuilder.Append(" and atc.table_name NOT IN (select object_name from all_objects where object_type='VIEW')");
						}
						else
						{
							stringBuilder.Append(" and atc.table_name NOT IN (select object_name from all_objects where object_type='TABLE')");
						}
					}
				}
				else
				{
					bool flag2 = false;
					if (oracleCommand.CommandText.Contains("WHERE ( NOT"))
					{
						flag2 = true;
					}
					if (flag2)
					{
						stringBuilder.Append("not ");
					}
					stringBuilder.Append("(");
					for (int l = 0; l < oracleCommand.Parameters.Count; l++)
					{
						if (l % 2 == 0)
						{
							stringBuilder.Append("(atc.owner = ");
							stringBuilder.Append(":");
							stringBuilder.Append(oracleCommand.Parameters[l].ToString());
							stringBuilder.Append(" and ");
							continue;
						}
						stringBuilder.Append("atc.table_name = ");
						stringBuilder.Append(":");
						stringBuilder.Append(oracleCommand.Parameters[l].ToString());
						stringBuilder.Append(") ");
						if (l + 2 < oracleCommand.Parameters.Count)
						{
							stringBuilder.Append("or \r\n");
						}
					}
					stringBuilder.Append(")");
					if (flag2)
					{
						if (!flag)
						{
							stringBuilder.Append(" and atc.table_name NOT IN (select object_name from all_objects where object_type='VIEW')\r\n");
						}
						else
						{
							stringBuilder.Append(" and atc.table_name NOT IN (select object_name from all_objects where object_type='TABLE')\r\n");
						}
					}
				}
				if (stringBuilder.Length > 0)
				{
					empty2 = stringBuilder.ToString();
					empty = empty.Replace("[WHERECLAUSE1]", empty2);
					empty2 = empty2.Replace("atc.", "acc.");
					empty = empty.Replace("[WHERECLAUSE2]", empty2);
					oracleCommand.CommandText = empty;
				}
			}
			else if (oracleCommand.CommandText.StartsWith(query6_StartsWith) || oracleCommand.CommandText.StartsWith(query6_framework_sp1_StartsWith))
			{
				m_Entered_Edm_Query6 = true;
				empty = Oracle_own_query6;
				if (oracleCommand.Parameters.Count == 0)
				{
					stringBuilder.Append("1 = 1");
				}
				else if (oracleCommand.Parameters.Count == 2)
				{
					if (oracleCommand.CommandText.Contains("WHERE (( NOT"))
					{
						stringBuilder.Append("NOT (c1.table_name like ");
						stringBuilder.Append(":");
						stringBuilder.Append(oracleCommand.Parameters[0].ToString());
						stringBuilder.Append(" and \r\n");
						stringBuilder.Append("c1.table_name like ");
						stringBuilder.Append(":");
						stringBuilder.Append(oracleCommand.Parameters[1].ToString());
						stringBuilder.Append(")");
					}
					else
					{
						stringBuilder.Append("(");
						stringBuilder.Append("c1.table_name like ");
						stringBuilder.Append(":");
						stringBuilder.Append(oracleCommand.Parameters[0].ToString());
						stringBuilder.Append(" or \r\n");
						stringBuilder.Append("c1.table_name like ");
						stringBuilder.Append(":");
						stringBuilder.Append(oracleCommand.Parameters[1].ToString());
						stringBuilder.Append(")");
					}
				}
				else
				{
					bool flag3 = false;
					if (oracleCommand.CommandText.Contains("WHERE (( NOT"))
					{
						flag3 = true;
					}
					if (flag3)
					{
						stringBuilder.Append("not ");
					}
					stringBuilder.Append("(");
					for (int m = 0; m < oracleCommand.Parameters.Count; m++)
					{
						if (m % 2 == 0)
						{
							stringBuilder.Append("(c1.owner = ");
							stringBuilder.Append(":");
							stringBuilder.Append(oracleCommand.Parameters[m].ToString());
							stringBuilder.Append(" and ");
							continue;
						}
						stringBuilder.Append("c1.table_name = ");
						stringBuilder.Append(":");
						stringBuilder.Append(oracleCommand.Parameters[m].ToString());
						stringBuilder.Append(") ");
						if (m + 2 < oracleCommand.Parameters.Count)
						{
							stringBuilder.Append("or \r\n");
						}
					}
					stringBuilder.Append(")");
				}
				if (stringBuilder.Length > 0)
				{
					empty2 = stringBuilder.ToString();
					empty = empty.Replace("[WHERECLAUSE1]", empty2);
					empty2 = empty2.Replace("c1.", "c2.");
					empty = empty.Replace("[WHERECLAUSE2]", empty2);
					oracleCommand.CommandText = empty;
				}
			}
			else if (oracleCommand.CommandText.StartsWith(query7_StartsWith))
			{
				empty = ((!m_10202_or_later_version) ? Oracle_own_query7_for_10201_or_earlier : Oracle_own_query7);
				if (oracleCommand.Parameters.Count == 0)
				{
					stringBuilder.Append("1=1");
				}
				else if (oracleCommand.Parameters.Count == 1)
				{
					if (oracleCommand.CommandText.Contains("WHERE ( NOT"))
					{
						stringBuilder.Append("(not (Id like ");
						stringBuilder.Append(":");
						stringBuilder.Append(oracleCommand.Parameters[0].ToString());
						stringBuilder.Append(")) ");
					}
					else
					{
						stringBuilder.Append("(Id like ");
						stringBuilder.Append(":");
						stringBuilder.Append(oracleCommand.Parameters[0].ToString());
						stringBuilder.Append(") ");
					}
				}
				else
				{
					bool flag4 = false;
					if (oracleCommand.CommandText.Contains("WHERE ( NOT"))
					{
						flag4 = true;
					}
					if (flag4)
					{
						stringBuilder.Append("not ");
					}
					stringBuilder.Append("(");
					for (int n = 0; n < oracleCommand.Parameters.Count; n++)
					{
						if (n % 2 == 0)
						{
							stringBuilder.Append("(owner = ");
							stringBuilder.Append(":");
							stringBuilder.Append(oracleCommand.Parameters[n].ToString());
							stringBuilder.Append(" and ");
							continue;
						}
						stringBuilder.Append("Id = ");
						stringBuilder.Append(":");
						stringBuilder.Append(oracleCommand.Parameters[n].ToString());
						stringBuilder.Append(") ");
						if (n + 2 < oracleCommand.Parameters.Count)
						{
							stringBuilder.Append("or \r\n");
						}
					}
					stringBuilder.Append(")");
				}
				if (stringBuilder.Length > 0)
				{
					empty2 = stringBuilder.ToString();
					empty = empty.Replace("[WHERECLAUSE]", empty2);
					oracleCommand.CommandText = empty;
				}
				m_GetDbProviderManifestTokenWasCalled = false;
				m_Entered_Edm_Query6 = false;
				m_hasFiredEdmInUseEvent = false;
			}
			if (m_filteringStrArray != null && !string.IsNullOrEmpty(m_filteringStrs) && oracleCommand.CommandText.Contains("SYS_CONTEXT('USERENV', 'CURRENT_USER')"))
			{
				oracleCommand.CommandText = oracleCommand.CommandText.Replace("SYS_CONTEXT('USERENV', 'CURRENT_USER')", m_filteringStrs);
				for (int num = 0; num < m_filteringStrArray.Length; num++)
				{
					oracleCommand.Parameters.Add(":s" + num, OracleDbType.Varchar2, m_filteringStrArray[num], ParameterDirection.Input);
				}
			}
		}
		return oracleCommand;
	}

	protected override string GetDbProviderManifestToken(DbConnection connection)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) EFOracleProviderServices::GetDbProviderManifestToken()\n");
		}
		EntityUtils.CheckArgumentNull(connection, "connection");
		if (!(connection is OracleConnection oracleConnection))
		{
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, typeof(OracleConnection).ToString()));
		}
		if (string.IsNullOrEmpty(oracleConnection.ConnectionString))
		{
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, typeof(OracleConnection).ToString()));
		}
		bool flag = false;
		try
		{
			if (oracleConnection.State != ConnectionState.Open)
			{
				oracleConnection.Open();
				flag = true;
			}
			version = EFOracleVersionUtils.GetStorageVersion(oracleConnection);
			m_conStr = oracleConnection.ConnectionString;
			m_GetDbProviderManifestTokenWasCalled = true;
			if (oracleConnection.IsDBVer10gR2OrHigher)
			{
				if (oracleConnection.m_majorVersion >= 11)
				{
					m_10202_or_later_version = true;
				}
				else
				{
					m_10202_or_later_version = check10gR2_4thDigit(oracleConnection.ServerVersion);
				}
			}
			else
			{
				m_10202_or_later_version = false;
			}
			return EFOracleVersionUtils.GetVersionHint(version);
		}
		finally
		{
			if (flag)
			{
				oracleConnection.Close();
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (EXIT) EFOracleProviderServices::GetDbProviderManifestToken()\n");
				}
			}
		}
	}

	protected override DbProviderManifest GetDbProviderManifest(string versionHint)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) EFOracleProviderServices::GetDbProviderManifest()\n");
		}
		if (string.IsNullOrEmpty(versionHint))
		{
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "ProviderManifestToken"));
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT) EFOracleProviderServices::GetDbProviderManifest()\n");
		}
		return new EFOracleProviderManifest(versionHint);
	}

	internal static OracleParameter CreateOracleParameter(string name, TypeUsage type, ParameterMode mode, object value, EFOracleVersion version)
	{
		OracleParameter oracleParameter = null;
		Type type2 = value.GetType();
		oracleParameter = ((type2 == typeof(bool)) ? new OracleParameter(name, Convert.ChangeType((bool)value, TypeCode.Decimal, CultureInfo.InvariantCulture)) : ((type2 == typeof(Guid)) ? new OracleParameter(name, ((Guid)value).ToByteArray()) : ((!(type2 == typeof(DateTimeOffset))) ? new OracleParameter(name, value) : new OracleParameter(name, ((DateTimeOffset)value).DateTime))));
		ParameterDirection parameterDirection = MetadataHelpers.ParameterModeToParameterDirection(mode);
		if (oracleParameter.Direction != parameterDirection)
		{
			oracleParameter.Direction = parameterDirection;
		}
		bool flag = mode != ParameterMode.In;
		int? size;
		byte? precision;
		byte? scale;
		OracleDbType dbType = GetDbType(type, flag, version, out size, out precision, out scale);
		if (oracleParameter.OracleDbType != dbType)
		{
			oracleParameter.OracleDbType = dbType;
		}
		if (size.HasValue && (flag || oracleParameter.Size != size.Value))
		{
			oracleParameter.Size = size.Value;
		}
		if (precision.HasValue && (flag || oracleParameter.Precision != precision.Value))
		{
			oracleParameter.Precision = precision.Value;
		}
		if (scale.HasValue && (flag || oracleParameter.Scale != scale.Value))
		{
			oracleParameter.Scale = scale.Value;
		}
		bool flag2 = MetadataHelpers.IsNullable(type);
		if (flag || flag2 != oracleParameter.IsNullable)
		{
			oracleParameter.IsNullable = flag2;
		}
		if (oracleParameter.OracleDbType == OracleDbType.IntervalYM)
		{
			if (!(value is DBNull))
			{
				oracleParameter.Value = decimal.ToInt64((decimal)value);
			}
		}
		else if (oracleParameter.OracleDbType == OracleDbType.IntervalDS)
		{
			if (!(value is DBNull))
			{
				TimeSpan timeSpan = TimeSpan.FromSeconds((double)(decimal)value);
				oracleParameter.Value = timeSpan;
			}
		}
		else if (oracleParameter.OracleDbType == OracleDbType.TimeStampTZ)
		{
			oracleParameter.m_bReturnDateTimeOffset = true;
		}
		oracleParameter.OracleDbTypeEx = oracleParameter.OracleDbType;
		return oracleParameter;
	}

	private static OracleDbType GetDbType(TypeUsage type, bool isOutParam, EFOracleVersion version, out int? size, out byte? precision, out byte? scale)
	{
		PrimitiveTypeKind primitiveTypeKind = MetadataHelpers.GetPrimitiveTypeKind(type);
		size = null;
		precision = null;
		scale = null;
		switch (primitiveTypeKind)
		{
		case PrimitiveTypeKind.Binary:
		{
			size = GetParameterSize(type, isOutParam);
			if (type != null && type.EdmType != null && type.EdmType.Name != null)
			{
				if (type.EdmType.Name.ToLowerInvariant() == "blob")
				{
					return OracleDbType.Blob;
				}
				if (type.EdmType.Name.ToLowerInvariant() == "raw")
				{
					return OracleDbType.Raw;
				}
				if (type.EdmType.Name.ToLowerInvariant() == "long raw")
				{
					return OracleDbType.LongRaw;
				}
				if (type.EdmType.Name.ToLowerInvariant() == "bfile")
				{
					return OracleDbType.BFile;
				}
			}
			OracleDbType binaryDbType = GetBinaryDbType(type);
			if (!size.HasValue && (binaryDbType == OracleDbType.Blob || binaryDbType == OracleDbType.LongRaw))
			{
				return OracleDbType.Blob;
			}
			return binaryDbType;
		}
		case PrimitiveTypeKind.Boolean:
			return OracleDbType.Decimal;
		case PrimitiveTypeKind.Byte:
			return OracleDbType.Byte;
		case PrimitiveTypeKind.Time:
			return OracleDbType.TimeStamp;
		case PrimitiveTypeKind.DateTimeOffset:
			return OracleDbType.TimeStampTZ;
		case PrimitiveTypeKind.DateTime:
			if (type != null && type.EdmType != null && type.EdmType.Name != null)
			{
				if (type.EdmType.Name.ToLowerInvariant() == "date")
				{
					return OracleDbType.Date;
				}
				if (type.EdmType.Name.ToLowerInvariant() == "timestamp")
				{
					return OracleDbType.TimeStamp;
				}
				if (type.EdmType.Name.ToLowerInvariant() == "timestamp with local time zone")
				{
					return OracleDbType.TimeStampLTZ;
				}
			}
			if (type.Facets["Precision"].Value != null)
			{
				if ((byte)type.Facets["Precision"].Value > 9)
				{
					return OracleDbType.TimeStampLTZ;
				}
				return OracleDbType.TimeStamp;
			}
			return OracleDbType.Date;
		case PrimitiveTypeKind.Decimal:
			precision = GetParameterPrecision(type, null);
			scale = GetScale(type);
			if (type != null && type.EdmType != null && type.EdmType.Name != null)
			{
				if (type.EdmType.Name.ToLowerInvariant() == "number")
				{
					return OracleDbType.Decimal;
				}
				if (type.EdmType.Name.ToLowerInvariant() == "interval year to month")
				{
					return OracleDbType.IntervalYM;
				}
				if (type.EdmType.Name.ToLowerInvariant() == "interval day to second")
				{
					return OracleDbType.IntervalDS;
				}
				if (type.EdmType.Name.ToLowerInvariant() == "float")
				{
					return OracleDbType.Decimal;
				}
			}
			if (((int?)precision).HasValue && precision == 250)
			{
				return OracleDbType.IntervalYM;
			}
			if (((int?)precision).HasValue && precision == 251)
			{
				return OracleDbType.IntervalDS;
			}
			return OracleDbType.Decimal;
		case PrimitiveTypeKind.Double:
			return OracleDbType.Double;
		case PrimitiveTypeKind.Guid:
			return OracleDbType.Raw;
		case PrimitiveTypeKind.Int16:
			return OracleDbType.Int16;
		case PrimitiveTypeKind.Int32:
			return OracleDbType.Int32;
		case PrimitiveTypeKind.Int64:
			return OracleDbType.Int64;
		case PrimitiveTypeKind.SByte:
			return OracleDbType.Byte;
		case PrimitiveTypeKind.Single:
			return OracleDbType.Single;
		case PrimitiveTypeKind.String:
		{
			size = GetParameterSize(type, isOutParam);
			if (type != null && type.EdmType != null && type.EdmType.Name != null)
			{
				if (type.EdmType.Name.ToLowerInvariant() == "xmltype")
				{
					return OracleDbType.XmlType;
				}
				if (type.EdmType.Name.ToLowerInvariant() == "nvarchar2")
				{
					return OracleDbType.NVarchar2;
				}
				if (type.EdmType.Name.ToLowerInvariant() == "varchar2")
				{
					return OracleDbType.Varchar2;
				}
				if (type.EdmType.Name.ToLowerInvariant() == "nclob")
				{
					return OracleDbType.NClob;
				}
				if (type.EdmType.Name.ToLowerInvariant() == "clob")
				{
					return OracleDbType.Clob;
				}
				if (type.EdmType.Name.ToLowerInvariant() == "nchar")
				{
					return OracleDbType.NChar;
				}
				if (type.EdmType.Name.ToLowerInvariant() == "long")
				{
					return OracleDbType.Long;
				}
				if (type.EdmType.Name.ToLowerInvariant() == "char")
				{
					return OracleDbType.Char;
				}
				if (type.EdmType.Name.ToLowerInvariant() == "rowid")
				{
					return OracleDbType.Varchar2;
				}
				if (type.EdmType.Name.ToLowerInvariant() == "urowid")
				{
					return OracleDbType.Varchar2;
				}
			}
			OracleDbType stringDbType = GetStringDbType(type);
			if (!size.HasValue)
			{
				switch (stringDbType)
				{
				case OracleDbType.Char:
				case OracleDbType.Varchar2:
					return OracleDbType.Clob;
				case OracleDbType.NChar:
				case OracleDbType.NVarchar2:
					return OracleDbType.NClob;
				}
			}
			return stringDbType;
		}
		default:
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, primitiveTypeKind.ToString()));
		}
	}

	private static int? GetParameterSize(TypeUsage type, bool isOutParam)
	{
		if (MetadataHelpers.TryGetMaxLength(type, out var maxLength))
		{
			return maxLength;
		}
		if (type.EdmType.Name.ToLowerInvariant() == "varchar2")
		{
			return 4000;
		}
		if (type.EdmType.Name.ToLowerInvariant() == "nvarchar2")
		{
			return 4000;
		}
		if (type.EdmType.Name.ToLowerInvariant() == "char")
		{
			return 2000;
		}
		if (type.EdmType.Name.ToLowerInvariant() == "nchar")
		{
			return 2000;
		}
		if (type.EdmType.Name.ToLowerInvariant() == "raw")
		{
			return 2000;
		}
		if (type.EdmType.Name.ToLowerInvariant() == "rowid")
		{
			return 18;
		}
		if (type.EdmType.Name.ToLowerInvariant() == "urowid")
		{
			return 4000;
		}
		if (type.EdmType.Name.ToLowerInvariant() == "long")
		{
			return 32670;
		}
		if (type.EdmType.Name.ToLowerInvariant() == "long raw")
		{
			return 32670;
		}
		return null;
	}

	private static byte? GetParameterPrecision(TypeUsage type, byte? defaultIfUndefined)
	{
		if (MetadataHelpers.TryGetPrecision(type, out var precision))
		{
			return precision;
		}
		return defaultIfUndefined;
	}

	private static byte? GetScale(TypeUsage type)
	{
		if (MetadataHelpers.TryGetScale(type, out var scale))
		{
			return scale;
		}
		return null;
	}

	private static OracleDbType GetStringDbType(TypeUsage type)
	{
		if (type.EdmType.Name.ToLowerInvariant() == "xmltype")
		{
			return OracleDbType.XmlType;
		}
		if (!MetadataHelpers.TryGetIsFixedLength(type, out var isFixedLength))
		{
			isFixedLength = false;
		}
		if (!MetadataHelpers.TryGetIsUnicode(type, out var isUnicode))
		{
			isUnicode = true;
		}
		if (isFixedLength)
		{
			return isUnicode ? OracleDbType.NChar : OracleDbType.Char;
		}
		return isUnicode ? OracleDbType.NVarchar2 : OracleDbType.Varchar2;
	}

	private static OracleDbType GetBinaryDbType(TypeUsage type)
	{
		if (!MetadataHelpers.TryGetIsFixedLength(type, out var isFixedLength))
		{
			isFixedLength = false;
		}
		int maxLength = 0;
		if (MetadataHelpers.TryGetMaxLength(type, out maxLength))
		{
			if (maxLength <= 2000)
			{
				return OracleDbType.Raw;
			}
			if (!isFixedLength)
			{
				return OracleDbType.Blob;
			}
			return OracleDbType.LongRaw;
		}
		if (!isFixedLength)
		{
			return OracleDbType.Blob;
		}
		return OracleDbType.LongRaw;
	}

	internal static bool check10gR2_4thDigit(string dbVersion)
	{
		string text = dbVersion.Substring("10.2.0.".Length);
		int length = text.IndexOf(".");
		if (int.Parse(text.Substring(0, length)) >= 2)
		{
			return true;
		}
		return false;
	}
}
