namespace Oracle.DataAccess.Client;

internal class ErrRes
{
	internal const int PC_DESC_CATEGORY = -2801;

	internal const int PC_DESC_HARDCONNECTS = -2802;

	internal const int PC_DESC_HARDDISCONNECTS = -2803;

	internal const int PC_DESC_SOFTCONNECTS = -2804;

	internal const int PC_DESC_SOFTDISCONNECTS = -2805;

	internal const int PC_DESC_ACTIVECONNPOOLS = -2806;

	internal const int PC_DESC_ACTIVECONNS = -2807;

	internal const int PC_DESC_FREECONNS = -2808;

	internal const int PC_DESC_INACTIVECONNPOOLS = -2809;

	internal const int PC_DESC_NONPOOLEDCONNS = -2810;

	internal const int PC_DESC_POOLEDCONNS = -2811;

	internal const int PC_DESC_RECLAIMEDCONNS = -2812;

	internal const int PC_DESC_STASISCONNS = -2813;

	internal const int UDT_INV_CUSTOM_TYPE_MAPPING = -2901;

	internal const int UDT_INV_CUSTOM_TYPE = -2902;

	internal const int UDT_TYPE_CONVERSION_NOTSUPPORTED = -2903;

	internal const int UDT_TYPE_MAPPING_NOTSUPPORTED = -2904;

	internal const int UDT_TYPE_MAPPING_NOTSPECIFIED = -2905;

	internal static int EVEN_VALUE_PARAM_REQUIRED = -2300;

	internal static int OS_MEMALLOC_FAIL = -10;

	internal static int INIT_DLL_VERSION_MISMATCH = -11;

	internal static int CON_TIMEOUT_EXCEEDED = -1000;

	internal static int CON_CLOSED = -1001;

	internal static int CON_INVALID_ISO_LEVEL = -1002;

	internal static int CON_STR_NOT_UPDATABLE = -1003;

	internal static int CON_REOPENED = -1004;

	internal static int CON_ALREADY_OPEN = -1005;

	internal static int CON_ALREADY_TXNED = -1006;

	internal static int CON_STR_NOT_WELL_FORMED = -1007;

	internal static int CON_STR_INVALID_ATTRIB = -1008;

	internal static int CON_STR_INVALID_VALUE = -1009;

	internal static int CON_DIFFERENT_CONNECTIONS = -1010;

	internal static int CON_PSPE_RULE_VIOLATION = -1011;

	internal static int CON_GS_COLL_NOT_DEFINED = -1030;

	internal static int CON_GS_COLL_NOT_SUPPORTED = -1031;

	internal static int CON_GS_MORE_RESTRICTIONS = -1032;

	internal static int CON_GS_QUERY_FAILED = -1033;

	internal static int CON_GS_NO_POPULATION_STRING = -1034;

	internal static int CON_GS_NO_METADATA_STREAM = -1035;

	internal static int CON_GS_NO_CUSTOM_FILE = -1036;

	internal static int CON_MTS_ENLIST_FAIL = -1050;

	internal static int CON_MTS_LOAD_FAIL = -1051;

	internal static int PRM_INVALID_BIND = -1201;

	internal static int ODP_INVALID_VALUE = -1202;

	internal static int PRMCOL_ALREADY_ADDED = -1300;

	internal static int CMD_TYPE_NOT_SUPPORTED = -1450;

	internal static int DR_NULL_COL_DATA = -1501;

	internal static int DR_INV_COL_NAME = -1502;

	internal static int DR_INV_COL_INDEX = -1503;

	internal static int DR_INV_DATA_REQ = -1504;

	internal static int DAC_PK_REQUIRED = -1556;

	internal static int DA_FORWARD_ONLY = -1600;

	internal static int DA_INV_SAFE_TYPE = -1601;

	internal static int DA_BU_BIND_VIOLATION = -1602;

	internal static int BLR_MULTITABLE_DS = -1701;

	internal static int BLR_NO_PRIMARYKEY = -1702;

	internal static int ODP_NOT_SUPPORTED = -1703;

	internal static int BLR_PRM_NOT_SUPPORTED = -1704;

	internal static int LOB_BFILE_ALREADY_OPEN = -2201;

	internal static int TYP_COMPARE_COLLATION = -2501;

	internal static int TYP_NULLVALUE = -2502;

	internal static int TYP_GETDOTNETTYPE_FAIL = -2601;

	internal static int TYP_OFFSET_NOT_SUPPORTED = -2602;

	internal static int NTFN_CMD_ALREADY_EXIST = -2651;

	internal static int NTFN_LISTENER_ALREADY_STARTED = -2652;

	internal static int NTFN_REG_NOTVALID = -2653;

	internal static int NTFN_CHGNTFN_DBVERSION = -2654;

	internal static int NTFN_DEP_NOTEXIST = -2655;

	internal static int INT_ERR = -3000;

	internal static int INT_OCI_INVALID_HANDLE = -3001;

	internal static int INT_OCI_NO_DATA = -3002;

	internal static int INT_OCI_NEED_DATA = -3003;

	internal static int INT_OCI_STILL_EXECUTING = -3004;

	internal static int INT_OCI_CONTINUE = -3005;

	internal static int INT_DAC_CTX_SIG_MISMATCH = -3006;

	internal static int INT_DAC_ROWSIZE_MISMATCH = -3007;

	internal static int INT_DAC_DEL_NOT_SUPPORTED = -3008;

	internal static int INT_DAC_INS_NOT_SUPPORTED = -3009;

	internal static int INT_DAC_UPD_NOT_SUPPORTED = -3010;

	internal static int INT_DAC_ROWNUM_INVALID = -3011;

	internal static int INT_DAC_COL_ORD_INVALID = -3012;

	internal static int INT_DAC_COL_TYPE_INVALID = -3013;

	internal static int INT_DAC_CACHE_TYPE_INVALID = -3014;

	internal static int INT_DAC_NO_TABLE_OR_SCHEMA = -3015;

	internal static int INT_OCIERRORGET_FAIL = -3016;

	internal static int INT_GETERRORCNT_FAIL = -3017;

	internal static int INT_ERR_CORE_MESG_GET = -3018;

	internal static int INT_ERR_BATCHERRGET_FAIL = -3019;

	internal static int CON_TT_MIN_VERSION = -4000;

	internal static int EF_NILADIC_FUNCTION = -5000;

	internal static int CLR_NOTSUPPORTED_NONORACLR_THREAD = -2701;

	internal static int CLR_NOTSUPPORTED_DOTNET_SP = -2702;

	internal static int CLR_NOTSUPPORTED_CTX_CONN = -2703;

	internal static int CLR_CTX_CONN_OPENED_ALREADY = -2704;

	internal static int CLR_NOTSUPPORTED_INTERNAL_CONN = -2705;

	internal static int CLR_UDT_NOTSUPPORTED_CTX_CONN = -2706;

	internal static int BC_OPER_IN_PROGRESS = -2750;

	internal static int BC_INV_COL_MAPPINGS = -2751;

	internal static int BC_INV_OPER_INSIDE_EVENT = -2752;

	internal static int BC_OPER_ABORT = -2753;

	internal static int BC_ERROR = -2754;

	internal static int BC_OPER_TIMEOUT = -2755;

	private ErrRes()
	{
	}
}
