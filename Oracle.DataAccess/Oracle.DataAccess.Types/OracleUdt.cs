using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Xml;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

[ReflectionPermission(SecurityAction.Assert, Unrestricted = true)]
[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
public class OracleUdt
{
	internal const string CustomTypeName = "customTypeName";

	private static object s_lockObj;

	internal static Hashtable s_mapUdtNameToMappingObj;

	internal static Hashtable s_mapUdtNameToFactory;

	internal static Hashtable s_mapCustomTypeNameToUdtName;

	static OracleUdt()
	{
		s_lockObj = new object();
		s_mapUdtNameToFactory = new Hashtable();
		s_mapCustomTypeNameToUdtName = new Hashtable();
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	public unsafe static bool IsDBNull(OracleConnection con, IntPtr pUdt, int attrIndex)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleUdt::IsDBNull(0)\n");
		}
		if (con == null)
		{
			throw new ArgumentNullException("con");
		}
		if (pUdt == IntPtr.Zero)
		{
			throw new ArgumentException("pUdt");
		}
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		OpoUdtValCtx* ptr3;
		if (ptr->pOpoDscValCtx->TypeCode == 108)
		{
			if (attrIndex < 0 || attrIndex >= ptr->pOpoDscValCtx->NumAttrs)
			{
				throw new ArgumentOutOfRangeException("attrIndex");
			}
			AttrMetaVal* ptr2 = ptr->pOpoDscValCtx->pAttrMetaVals + attrIndex;
			if (ptr2->CustTypeCode == (CustomTypeCode)0)
			{
				throw new ArgumentException(OpoErrResManager.GetErrorMesg(-2905));
			}
			ptr3 = ptr->pOpoUdtValCtx + attrIndex;
		}
		else
		{
			if (attrIndex != 0)
			{
				throw new ArgumentOutOfRangeException("attrIndex");
			}
			ptr3 = ptr;
		}
		bool result = ptr3->bIsNull == 1;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleUdt::IsDBNull(0)\n");
		}
		return result;
	}

	public unsafe static bool IsDBNull(OracleConnection con, IntPtr pUdt, string attrName)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleUdt::IsDBNull(1)\n");
		}
		if (con == null)
		{
			throw new ArgumentNullException("con");
		}
		if (pUdt == IntPtr.Zero)
		{
			throw new ArgumentException("pUdt");
		}
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		int attrIndex;
		if (ptr->pOpoDscValCtx->TypeCode == 108)
		{
			if (attrName == null)
			{
				throw new ArgumentNullException("attrName");
			}
			if (attrName == "")
			{
				throw new ArgumentException("attrName");
			}
			bool bExists;
			OracleUdtDescriptor oracleUdtDescriptor = OracleUdtDescriptor.GetOracleUdtDescriptor(con, (IntPtr)(*(void**)(void*)ptr->pTDO), bRefresh: false, out bExists);
			oracleUdtDescriptor.GetMetaDataTable();
			object obj = oracleUdtDescriptor.m_attrNameToIndex[attrName];
			if (obj == null)
			{
				throw new ArgumentException("attrName");
			}
			attrIndex = (int)obj;
		}
		else
		{
			if (attrName != null && !(attrName == ""))
			{
				throw new ArgumentException("attrName");
			}
			attrIndex = 0;
		}
		bool result = IsDBNull(con, pUdt, attrIndex);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleUdt::IsDBNull(1)\n");
		}
		return result;
	}

	public unsafe static object GetValue(OracleConnection con, IntPtr pUdt, int attrIndex)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleUdt::GetValue(0)\n");
		}
		if (con == null)
		{
			throw new ArgumentNullException("con");
		}
		if (pUdt == IntPtr.Zero)
		{
			throw new ArgumentException("pUdt");
		}
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		ptr->bIgnoreElemStatus = 1;
		object value;
		try
		{
			value = GetValue(con, pUdt, attrIndex, out var _);
		}
		finally
		{
			ptr->bIgnoreElemStatus = 0;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleUdt::GetValue(0)\n");
		}
		return value;
	}

	public unsafe static object GetValue(OracleConnection con, IntPtr pUdt, int attrIndex, out object statusArray)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleUdt::GetValue(1)\n");
		}
		if (con == null)
		{
			throw new ArgumentNullException("con");
		}
		if (pUdt == IntPtr.Zero)
		{
			throw new ArgumentException("pUdt");
		}
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		object result;
		OracleUdtStatus status;
		if (ptr->pOpoDscValCtx->TypeCode == 108)
		{
			if (attrIndex < 0 || attrIndex >= ptr->pOpoDscValCtx->NumAttrs)
			{
				throw new ArgumentOutOfRangeException("attrIndex");
			}
			result = GetData(con, pUdt, attrIndex, out status, out statusArray);
		}
		else
		{
			if (attrIndex != 0)
			{
				throw new ArgumentOutOfRangeException("attrIndex");
			}
			result = GetArrData(con, pUdt, out status, out statusArray);
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleUdt::GetValue(1)\n");
		}
		return result;
	}

	public unsafe static object GetValue(OracleConnection con, IntPtr pUdt, string attrName)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleUdt::GetValue(2)\n");
		}
		if (con == null)
		{
			throw new ArgumentNullException("con");
		}
		if (pUdt == IntPtr.Zero)
		{
			throw new ArgumentException("pUdt");
		}
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		ptr->bIgnoreElemStatus = 1;
		object value;
		try
		{
			value = GetValue(con, pUdt, attrName, out var _);
		}
		finally
		{
			ptr->bIgnoreElemStatus = 0;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleUdt::GetValue(2)\n");
		}
		return value;
	}

	public unsafe static object GetValue(OracleConnection con, IntPtr pUdt, string attrName, out object statusArray)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleUdt::GetValue(3)\n");
		}
		if (con == null)
		{
			throw new ArgumentNullException("con");
		}
		if (pUdt == IntPtr.Zero)
		{
			throw new ArgumentException("pUdt");
		}
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		int attrIndex;
		if (ptr->pOpoDscValCtx->TypeCode == 108)
		{
			if (attrName == null)
			{
				throw new ArgumentNullException("attrName");
			}
			if (attrName == "")
			{
				throw new ArgumentException("attrName");
			}
			bool bExists;
			OracleUdtDescriptor oracleUdtDescriptor = OracleUdtDescriptor.GetOracleUdtDescriptor(con, (IntPtr)(*(void**)(void*)ptr->pTDO), bRefresh: false, out bExists);
			oracleUdtDescriptor.GetMetaDataTable();
			object obj = oracleUdtDescriptor.m_attrNameToIndex[attrName];
			if (obj == null)
			{
				throw new ArgumentException("attrName");
			}
			attrIndex = (int)obj;
		}
		else
		{
			if (attrName != null && !(attrName == ""))
			{
				throw new ArgumentException("attrName");
			}
			attrIndex = 0;
		}
		object value = GetValue(con, pUdt, attrIndex, out statusArray);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleUdt::GetValue(2)\n");
		}
		return value;
	}

	internal unsafe static object GetData(OracleConnection con, IntPtr pUdt, int index, out OracleUdtStatus status, out object statusArray)
	{
		int num = 0;
		statusArray = null;
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		AttrMetaVal* ptr2;
		if (ptr->pOpoDscValCtx->TypeCode == 108)
		{
			ptr2 = ptr->pOpoDscValCtx->pAttrMetaVals + index;
			if (ptr->bIsOdtConnection == 0 && ptr2->CustTypeCode == (CustomTypeCode)0)
			{
				throw new ArgumentException(OpoErrResManager.GetErrorMesg(-2905));
			}
		}
		else
		{
			ptr2 = ptr->pOpoDscValCtx->pAttrMetaVals;
		}
		object result;
		switch ((SQLT)ptr2->OraType)
		{
		case SQLT.NUM:
		case SQLT.INT:
		case SQLT.FLT:
		case SQLT.VNU:
		case SQLT.UIN:
			result = GetNumData(con, pUdt, index, out status);
			break;
		case SQLT.CHR:
		case SQLT.STR:
		case SQLT.LNG:
		case SQLT.VCS:
		case SQLT.LVC:
		case SQLT.AFC:
		case SQLT.AVC:
		case SQLT.VST:
			result = GetStrData(con, pUdt, index, out status);
			break;
		case SQLT.NTY:
		case SQLT.NCO:
		case SQLT.PNTY:
		{
			if (ptr2->TypeCode == 108)
			{
				result = GetObjData(con, pUdt, index, out status);
				break;
			}
			if (ptr2->TypeCode == 58)
			{
				result = GetXmlData(con, pUdt, index, out status);
				break;
			}
			OpoUdtValCtx* ptr3 = ptr->pOpoUdtValCtx + index;
			ptr3->pOpsErrCtx = ptr->pOpsErrCtx;
			ptr3->bIgnoreElemStatus = ptr->bIgnoreElemStatus;
			ptr3->pOpoDscValCtx = ptr2->pOpoDscValCtx;
			AttrMetaVal* ptr4 = ((ptr->pOpoDscValCtx->TypeCode != 108) ? ptr2 : ptr3->pOpoDscValCtx->pAttrMetaVals);
			if (ptr3->pOpoDscValCtx->bIsArrayType == 1 && ptr4->OraType == 2 && (ptr4->CustTypeCode == CustomTypeCode.Int32 || ptr4->CustTypeCode == CustomTypeCode.Double))
			{
				result = GetArrData(con, (IntPtr)ptr3, out status, out statusArray);
				break;
			}
			bool bExists;
			OracleUdtDescriptor oracleUdtDescriptor = OracleUdtDescriptor.GetOracleUdtDescriptor(con, (IntPtr)(*(void**)(void*)ptr->pTDO), bRefresh: false, out bExists);
			OracleUdtDescriptor oracleUdtDescriptor2 = ((ptr->pOpoDscValCtx->TypeCode != 108) ? oracleUdtDescriptor.GetArrElemUdtDescriptor() : oracleUdtDescriptor.GetObjAttrUdtDescriptor(index));
			if (oracleUdtDescriptor2.m_customTypeFactory == null)
			{
				object factory = GetFactory(oracleUdtDescriptor2);
				if (factory != null)
				{
					oracleUdtDescriptor2.DescribeCustomType(factory);
				}
			}
			ptr3->pTDO = oracleUdtDescriptor2.m_opsDscCtx;
			ptr3->ppRefTDO = ptr->ppRefTDO;
			ptr3->pOpoDscValCtx = oracleUdtDescriptor2.m_pOpoDscValCtx;
			if (ptr4->OraType == 108 && ptr3->bIsNull != 1)
			{
				try
				{
					num = OpsUdt.GetArr(con.m_opoConCtx.opsConCtx, ptr3);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
					num = ErrRes.INT_ERR;
					throw;
				}
				finally
				{
					if (num != 0 && num != ErrRes.INT_ERR)
					{
						OracleException.HandleError(num, con, ptr3->pOpsErrCtx, null);
					}
				}
			}
			if (oracleUdtDescriptor2.m_pOpoDscValCtx->bIsArrayType == 0)
			{
				IOracleCustomTypeFactory oracleCustomTypeFactory = (IOracleCustomTypeFactory)oracleUdtDescriptor2.m_customTypeFactory;
				IOracleCustomType oracleCustomType = oracleCustomTypeFactory.CreateObject();
				if (ptr3->bIsNull == 1)
				{
					status = OracleUdtStatus.Null;
					Type type = oracleCustomType.GetType();
					PropertyInfo property = type.GetProperty("Null");
					result = property.GetValue(null, null);
				}
				else
				{
					status = OracleUdtStatus.NotNull;
					ptr3->bIgnoreElemStatus = 0;
					oracleCustomType.ToCustomObject(con, (IntPtr)ptr3);
					result = oracleCustomType;
				}
			}
			else
			{
				result = GetArrData(con, (IntPtr)ptr3, out status, out statusArray);
			}
			GC.KeepAlive(oracleUdtDescriptor2);
			break;
		}
		case SQLT.DAT:
		case SQLT.ODT:
		case SQLT.DATE:
			result = GetDatData(con, pUdt, index, out status);
			break;
		case SQLT.INTERVAL_DS:
			result = GetIDSData(con, pUdt, index, out status);
			break;
		case SQLT.INTERVAL_YM:
			result = GetIYMData(con, pUdt, index, out status);
			break;
		case SQLT.TIME:
		case SQLT.TIME_TZ:
		case SQLT.TIMESTAMP:
		case SQLT.TIMESTAMP_TZ:
		case SQLT.TIMESTAMP_LTZ:
			result = GetTSData(con, pUdt, index, out status);
			break;
		case SQLT.BFLT:
		case SQLT.IBFL:
			result = GetFltData(con, pUdt, index, out status);
			break;
		case SQLT.BDBL:
		case SQLT.IBDL:
			result = GetDblData(con, pUdt, index, out status);
			break;
		case SQLT.BFILEE:
			result = GetBFileData(con, pUdt, index, out status);
			break;
		case SQLT.BLOB:
			result = GetBlobData(con, pUdt, index, out status);
			break;
		case SQLT.CLOB:
		case SQLT.CFILEE:
			result = GetClobData(con, pUdt, index, out status);
			break;
		case SQLT.VBI:
		case SQLT.BIN:
		case SQLT.LBI:
		case SQLT.LVB:
			result = GetRawData(con, pUdt, index, out status);
			break;
		case SQLT.REF:
			result = GetRefData(con, pUdt, index, out status);
			break;
		case SQLT.PDN:
		case SQLT.NON:
		case SQLT.RID:
		case SQLT.SLS:
		case SQLT.CUR:
		case SQLT.RDD:
		case SQLT.LAB:
		case SQLT.OSL:
		case SQLT.RSET:
			throw new NotSupportedException();
		default:
			result = null;
			status = OracleUdtStatus.Null;
			break;
		}
		return result;
	}

	internal unsafe static object GetArrData(OracleConnection con, IntPtr pUdt, out OracleUdtStatus status, out object statusArray)
	{
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		AttrMetaVal* ptr2 = ptr->pOpoDscValCtx->pAttrMetaVals;
		if (ptr->bIsNull == 1)
		{
			status = OracleUdtStatus.Null;
			statusArray = null;
			return null;
		}
		if (ptr2->OraType == 2 && (ptr2->CustTypeCode == CustomTypeCode.Int32 || ptr2->CustTypeCode == CustomTypeCode.Double))
		{
			SQLT oraType = (SQLT)ptr2->OraType;
			if (oraType == SQLT.NUM)
			{
				return GetNumArrData(con, pUdt, out status, out statusArray);
			}
			status = OracleUdtStatus.NotNull;
			statusArray = null;
			return null;
		}
		bool bExists;
		OracleUdtDescriptor oracleUdtDescriptor = OracleUdtDescriptor.GetOracleUdtDescriptor(con, (IntPtr)(*(void**)(void*)ptr->pTDO), bRefresh: false, out bExists);
		if (oracleUdtDescriptor.m_customTypeFactory == null)
		{
			object factory = GetFactory(oracleUdtDescriptor);
			if (factory != null)
			{
				oracleUdtDescriptor.DescribeCustomType(factory);
			}
		}
		IOracleArrayTypeFactory oracleArrayTypeFactory = (IOracleArrayTypeFactory)oracleUdtDescriptor.m_customTypeFactory;
		Array array = oracleArrayTypeFactory.CreateArray(ptr->NumOfArrElems);
		Array array2 = null;
		if (ptr->bIgnoreElemStatus == 0)
		{
			array2 = oracleArrayTypeFactory.CreateStatusArray(ptr->NumOfArrElems);
		}
		for (int i = 0; i < ptr->NumOfArrElems; i++)
		{
			OracleUdtStatus status2;
			object statusArray2;
			object data = GetData(con, pUdt, i, out status2, out statusArray2);
			if (status2 != OracleUdtStatus.NotNull)
			{
				continue;
			}
			array.SetValue(data, i);
			if (ptr->bIgnoreElemStatus == 0)
			{
				if (statusArray2 != null)
				{
					array2.SetValue(statusArray2, i);
				}
				else
				{
					array2.SetValue(OracleUdtStatus.NotNull, i);
				}
			}
		}
		status = OracleUdtStatus.NotNull;
		statusArray = array2;
		return array;
	}

	internal unsafe static object GetNumData(OracleConnection con, IntPtr pUdt, int index, out OracleUdtStatus status)
	{
		status = OracleUdtStatus.Null;
		object obj = null;
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		OpoUdtValCtx* ptr2 = ptr->pOpoUdtValCtx + index;
		AttrMetaVal* ptr3 = ((ptr->pOpoDscValCtx->TypeCode != 108) ? ptr->pOpoDscValCtx->pAttrMetaVals : (ptr->pOpoDscValCtx->pAttrMetaVals + index));
		CustomTypeCode customTypeCode = ptr3->CustTypeCode;
		if (ptr->bIsOdtConnection == 1)
		{
			customTypeCode = CustomTypeCode.OracleDecimal;
		}
		switch (customTypeCode)
		{
		case CustomTypeCode.Byte:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				obj = ((ptr3->IsNullable != 1) ? ((ptr->pOpoDscValCtx->TypeCode != 108) ? ((object)0) : DBNull.Value) : null);
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				obj = ptr2->opoUdtAttrValCtx.m_byte;
			}
			break;
		case CustomTypeCode.Int16:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				obj = ((ptr3->IsNullable != 1) ? ((ptr->pOpoDscValCtx->TypeCode != 108) ? ((object)0) : DBNull.Value) : null);
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				obj = ptr2->opoUdtAttrValCtx.m_short;
			}
			break;
		case CustomTypeCode.Int32:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				obj = ((ptr3->IsNullable != 1) ? ((ptr->pOpoDscValCtx->TypeCode != 108) ? ((object)0) : DBNull.Value) : null);
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				obj = ptr2->opoUdtAttrValCtx.m_int;
			}
			break;
		case CustomTypeCode.Int64:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				obj = ((ptr3->IsNullable != 1) ? ((ptr->pOpoDscValCtx->TypeCode != 108) ? ((object)0L) : DBNull.Value) : null);
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				obj = ptr2->opoUdtAttrValCtx.m_long;
			}
			break;
		case CustomTypeCode.Single:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				obj = ((ptr3->IsNullable != 1) ? ((ptr->pOpoDscValCtx->TypeCode != 108) ? ((object)0) : DBNull.Value) : null);
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				obj = ptr2->opoUdtAttrValCtx.m_float;
			}
			break;
		case CustomTypeCode.Double:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				obj = ((ptr3->IsNullable != 1) ? ((ptr->pOpoDscValCtx->TypeCode != 108) ? ((object)0) : DBNull.Value) : null);
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				obj = ptr2->opoUdtAttrValCtx.m_double;
			}
			break;
		case CustomTypeCode.Decimal:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				obj = ((ptr3->IsNullable != 1) ? ((ptr->pOpoDscValCtx->TypeCode != 108) ? ((object)0) : DBNull.Value) : null);
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				obj = DecimalConv.GetDecimal(ptr2->pUDT);
			}
			break;
		case CustomTypeCode.OracleDecimal:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				obj = OracleDecimal.Null;
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				obj = new OracleDecimal(ptr2->pDataTmpBuffer);
				ptr2->pDataTmpBuffer = IntPtr.Zero;
			}
			break;
		default:
			status = OracleUdtStatus.Null;
			obj = null;
			break;
		}
		return obj;
	}

	internal unsafe static object GetStrData(OracleConnection con, IntPtr pUdt, int index, out OracleUdtStatus status)
	{
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		OpoUdtValCtx* ptr2 = ptr->pOpoUdtValCtx + index;
		AttrMetaVal* ptr3 = ((ptr->pOpoDscValCtx->TypeCode != 108) ? ptr->pOpoDscValCtx->pAttrMetaVals : (ptr->pOpoDscValCtx->pAttrMetaVals + index));
		CustomTypeCode customTypeCode = ptr3->CustTypeCode;
		if (ptr->bIsOdtConnection == 1)
		{
			customTypeCode = CustomTypeCode.OracleString;
		}
		switch (customTypeCode)
		{
		case CustomTypeCode.String:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				return null;
			}
			status = OracleUdtStatus.NotNull;
			return Marshal.PtrToStringUni(ptr2->pDataMarshalBuffer, ptr2->DataLen);
		case CustomTypeCode.Chars:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				return null;
			}
			status = OracleUdtStatus.NotNull;
			return Marshal.PtrToStringUni(ptr2->pDataMarshalBuffer, ptr2->DataLen).ToCharArray();
		case CustomTypeCode.OracleString:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				return OracleString.Null;
			}
			status = OracleUdtStatus.NotNull;
			return new OracleString(Marshal.PtrToStringUni(ptr2->pDataMarshalBuffer, ptr2->DataLen));
		default:
			status = OracleUdtStatus.Null;
			return null;
		}
	}

	internal unsafe static object GetRawData(OracleConnection con, IntPtr pUdt, int index, out OracleUdtStatus status)
	{
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		OpoUdtValCtx* ptr2 = ptr->pOpoUdtValCtx + index;
		AttrMetaVal* ptr3 = ((ptr->pOpoDscValCtx->TypeCode != 108) ? ptr->pOpoDscValCtx->pAttrMetaVals : (ptr->pOpoDscValCtx->pAttrMetaVals + index));
		CustomTypeCode customTypeCode = ptr3->CustTypeCode;
		if (ptr->bIsOdtConnection == 1)
		{
			customTypeCode = CustomTypeCode.OracleBinary;
		}
		object obj;
		switch (customTypeCode)
		{
		case CustomTypeCode.Bytes:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				obj = null;
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				obj = new byte[ptr2->DataLen];
				Marshal.Copy(ptr2->pUDT, (byte[])obj, 0, ptr2->DataLen);
			}
			break;
		case CustomTypeCode.OracleBinary:
		{
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				obj = OracleBinary.Null;
				break;
			}
			status = OracleUdtStatus.NotNull;
			byte[] array = new byte[ptr2->DataLen];
			Marshal.Copy(ptr2->pUDT, array, 0, ptr2->DataLen);
			obj = new OracleBinary(array, bCopy: false);
			break;
		}
		default:
			status = OracleUdtStatus.Null;
			obj = null;
			break;
		}
		return obj;
	}

	internal unsafe static object GetRefData(OracleConnection con, IntPtr pUdt, int index, out OracleUdtStatus status)
	{
		int num = 0;
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		OpoUdtValCtx* ptr2 = ptr->pOpoUdtValCtx + index;
		AttrMetaVal* ptr3 = ((ptr->pOpoDscValCtx->TypeCode != 108) ? ptr->pOpoDscValCtx->pAttrMetaVals : (ptr->pOpoDscValCtx->pAttrMetaVals + index));
		CustomTypeCode customTypeCode = ptr3->CustTypeCode;
		if (ptr->bIsOdtConnection == 1)
		{
			customTypeCode = CustomTypeCode.OracleRef;
		}
		if (ptr2->bIsNull != 1)
		{
			try
			{
				num = OpsUdt.GetRef(con.m_opoConCtx.opsConCtx, ptr, index);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
			finally
			{
				if (num != 0)
				{
					OracleException.HandleError(num, con, ptr->pOpsErrCtx, null);
				}
			}
		}
		object result;
		switch (customTypeCode)
		{
		case CustomTypeCode.String:
		{
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				result = null;
				break;
			}
			status = OracleUdtStatus.NotNull;
			OracleRef oracleRef = new OracleRef(con, new OpoUdtCtx(con.m_opoConCtx.opsConCtx, IntPtr.Zero, ptr2->pDataTmpBuffer, IntPtr.Zero));
			ptr2->pDataTmpBuffer = IntPtr.Zero;
			result = oracleRef.Value;
			oracleRef.Dispose();
			oracleRef = null;
			break;
		}
		case CustomTypeCode.OracleRef:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				result = OracleRef.Null;
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				result = new OracleRef(con, new OpoUdtCtx(con.m_opoConCtx.opsConCtx, IntPtr.Zero, ptr2->pDataTmpBuffer, IntPtr.Zero));
				ptr2->pDataTmpBuffer = IntPtr.Zero;
			}
			break;
		default:
			status = OracleUdtStatus.Null;
			result = null;
			break;
		}
		return result;
	}

	internal unsafe static object GetXmlData(OracleConnection con, IntPtr pUdt, int index, out OracleUdtStatus status)
	{
		int num = 0;
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		OpoUdtValCtx* ptr2 = ptr->pOpoUdtValCtx + index;
		AttrMetaVal* ptr3 = ((ptr->pOpoDscValCtx->TypeCode != 108) ? ptr->pOpoDscValCtx->pAttrMetaVals : (ptr->pOpoDscValCtx->pAttrMetaVals + index));
		CustomTypeCode customTypeCode = ptr3->CustTypeCode;
		if (ptr->bIsOdtConnection == 1)
		{
			customTypeCode = CustomTypeCode.OracleXmlType;
		}
		if (ptr2->bIsNull != 1)
		{
			try
			{
				num = OpsUdt.GetXml(con.m_opoConCtx.opsConCtx, ptr, index);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
			finally
			{
				if (num != 0)
				{
					OracleException.HandleError(num, con, ptr->pOpsErrCtx, null);
				}
			}
		}
		object result;
		switch (customTypeCode)
		{
		case CustomTypeCode.String:
		{
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				result = null;
				break;
			}
			status = OracleUdtStatus.NotNull;
			OracleXmlType oracleXmlType2 = new OracleXmlType(con, ptr2->pDataTmpBuffer, flag: false);
			ptr2->pDataTmpBuffer = IntPtr.Zero;
			result = oracleXmlType2.Value;
			oracleXmlType2.Dispose();
			break;
		}
		case CustomTypeCode.Chars:
		{
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				result = null;
				break;
			}
			status = OracleUdtStatus.NotNull;
			OracleXmlType oracleXmlType = new OracleXmlType(con, ptr2->pDataTmpBuffer, flag: false);
			ptr2->pDataTmpBuffer = IntPtr.Zero;
			result = oracleXmlType.Value.ToCharArray();
			oracleXmlType.Dispose();
			break;
		}
		case CustomTypeCode.OracleXmlType:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				result = OracleXmlType.Null;
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				result = new OracleXmlType(con, ptr2->pDataTmpBuffer, flag: false);
				ptr2->pDataTmpBuffer = IntPtr.Zero;
			}
			break;
		default:
			status = OracleUdtStatus.Null;
			result = null;
			break;
		}
		return result;
	}

	internal unsafe static object GetDatData(OracleConnection con, IntPtr pUdt, int index, out OracleUdtStatus status)
	{
		object obj = null;
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		OpoUdtValCtx* ptr2 = ptr->pOpoUdtValCtx + index;
		AttrMetaVal* ptr3 = ((ptr->pOpoDscValCtx->TypeCode != 108) ? ptr->pOpoDscValCtx->pAttrMetaVals : (ptr->pOpoDscValCtx->pAttrMetaVals + index));
		CustomTypeCode customTypeCode = ptr3->CustTypeCode;
		if (ptr->bIsOdtConnection == 1)
		{
			customTypeCode = CustomTypeCode.OracleDate;
		}
		switch (customTypeCode)
		{
		case CustomTypeCode.DateTime:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				obj = ((ptr3->IsNullable != 1) ? ((ptr->pOpoDscValCtx->TypeCode != 108) ? ((object)new DateTime(0L)) : DBNull.Value) : null);
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				obj = DateTimeConv.GetDateTime((OpoDatValCtx*)(void*)ptr2->pUDT, OracleDbType.Date, bCheck: false);
			}
			break;
		case CustomTypeCode.OracleDate:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				obj = OracleDate.Null;
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				obj = new OracleDate(ptr2->pDataTmpBuffer);
				ptr2->pDataTmpBuffer = IntPtr.Zero;
			}
			break;
		default:
			status = OracleUdtStatus.Null;
			obj = null;
			break;
		}
		return obj;
	}

	internal unsafe static object GetTSData(OracleConnection con, IntPtr pUdt, int index, out OracleUdtStatus status)
	{
		object obj = null;
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		OpoUdtValCtx* ptr2 = ptr->pOpoUdtValCtx + index;
		AttrMetaVal* ptr3 = ((ptr->pOpoDscValCtx->TypeCode != 108) ? ptr->pOpoDscValCtx->pAttrMetaVals : (ptr->pOpoDscValCtx->pAttrMetaVals + index));
		CustomTypeCode customTypeCode = ptr3->CustTypeCode;
		if (ptr->bIsOdtConnection == 1)
		{
			customTypeCode = ((ptr3->OraType == 232) ? CustomTypeCode.OracleTimeStampLTZ : ((ptr3->OraType != 188) ? CustomTypeCode.OracleTimeStamp : CustomTypeCode.OracleTimeStampTZ));
		}
		switch (customTypeCode)
		{
		case CustomTypeCode.DateTime:
		{
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				if (ptr3->IsNullable == 1)
				{
					return null;
				}
				if (ptr->pOpoDscValCtx->TypeCode == 108)
				{
					return DBNull.Value;
				}
				return new DateTime(0L);
			}
			status = OracleUdtStatus.NotNull;
			OracleDbType oraType = (OracleDbType)0;
			if (ptr3->OraType == 187)
			{
				oraType = OracleDbType.TimeStamp;
			}
			else if (ptr3->OraType == 232)
			{
				oraType = OracleDbType.TimeStampLTZ;
			}
			else if (ptr3->OraType == 188)
			{
				oraType = OracleDbType.TimeStampTZ;
			}
			return DateTimeConv.GetDateTime((OpoTSValCtx*)(void*)ptr2->pUDT, oraType, bCheck: false);
		}
		case CustomTypeCode.OracleTimeStamp:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				return OracleTimeStamp.Null;
			}
			status = OracleUdtStatus.NotNull;
			return new OracleTimeStamp(ptr2->pUDT);
		case CustomTypeCode.OracleTimeStampLTZ:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				return OracleTimeStampLTZ.Null;
			}
			status = OracleUdtStatus.NotNull;
			return new OracleTimeStampLTZ(ptr2->pUDT);
		case CustomTypeCode.OracleTimeStampTZ:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				return OracleTimeStampTZ.Null;
			}
			status = OracleUdtStatus.NotNull;
			return new OracleTimeStampTZ(ptr2->pUDT);
		default:
			status = OracleUdtStatus.Null;
			return null;
		}
	}

	internal unsafe static object GetIDSData(OracleConnection con, IntPtr pUdt, int index, out OracleUdtStatus status)
	{
		object obj = null;
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		OpoUdtValCtx* ptr2 = ptr->pOpoUdtValCtx + index;
		AttrMetaVal* ptr3 = ((ptr->pOpoDscValCtx->TypeCode != 108) ? ptr->pOpoDscValCtx->pAttrMetaVals : (ptr->pOpoDscValCtx->pAttrMetaVals + index));
		CustomTypeCode customTypeCode = ptr3->CustTypeCode;
		if (ptr->bIsOdtConnection == 1)
		{
			customTypeCode = CustomTypeCode.OracleIntervalDS;
		}
		switch (customTypeCode)
		{
		case CustomTypeCode.TimeSpan:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				obj = ((ptr3->IsNullable != 1) ? ((ptr->pOpoDscValCtx->TypeCode != 108) ? ((object)new TimeSpan(0L)) : DBNull.Value) : null);
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				obj = TimeSpanConv.GetTimeSpan((OpoITLValCtx*)(void*)ptr2->pUDT, OracleDbType.IntervalDS);
			}
			break;
		case CustomTypeCode.OracleIntervalDS:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				obj = OracleIntervalDS.Null;
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				obj = new OracleIntervalDS((OpoITLValCtx*)(void*)ptr2->pDataTmpBuffer);
				ptr2->pDataTmpBuffer = IntPtr.Zero;
			}
			break;
		default:
			status = OracleUdtStatus.Null;
			obj = null;
			break;
		}
		return obj;
	}

	internal unsafe static object GetIYMData(OracleConnection con, IntPtr pUdt, int index, out OracleUdtStatus status)
	{
		object obj = null;
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		OpoUdtValCtx* ptr2 = ptr->pOpoUdtValCtx + index;
		AttrMetaVal* ptr3 = ((ptr->pOpoDscValCtx->TypeCode != 108) ? ptr->pOpoDscValCtx->pAttrMetaVals : (ptr->pOpoDscValCtx->pAttrMetaVals + index));
		CustomTypeCode customTypeCode = ptr3->CustTypeCode;
		if (ptr->bIsOdtConnection == 1)
		{
			customTypeCode = CustomTypeCode.OracleIntervalYM;
		}
		switch (customTypeCode)
		{
		case CustomTypeCode.Int64:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				obj = ((ptr3->IsNullable != 1) ? ((ptr->pOpoDscValCtx->TypeCode != 108) ? ((object)0L) : DBNull.Value) : null);
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				obj = LongConv.GetLong((OpoITLValCtx*)(void*)ptr2->pUDT, OracleDbType.IntervalYM);
			}
			break;
		case CustomTypeCode.OracleIntervalYM:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				obj = OracleIntervalYM.Null;
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				obj = new OracleIntervalYM((OpoITLValCtx*)(void*)ptr2->pDataTmpBuffer);
				ptr2->pDataTmpBuffer = IntPtr.Zero;
			}
			break;
		default:
			status = OracleUdtStatus.Null;
			obj = null;
			break;
		}
		return obj;
	}

	internal unsafe static object GetFltData(OracleConnection con, IntPtr pUdt, int index, out OracleUdtStatus status)
	{
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		OpoUdtValCtx* ptr2 = ptr->pOpoUdtValCtx + index;
		AttrMetaVal* ptr3 = ((ptr->pOpoDscValCtx->TypeCode != 108) ? ptr->pOpoDscValCtx->pAttrMetaVals : (ptr->pOpoDscValCtx->pAttrMetaVals + index));
		CustomTypeCode customTypeCode = ptr3->CustTypeCode;
		if (ptr->bIsOdtConnection == 1)
		{
			customTypeCode = CustomTypeCode.OracleDecimal;
		}
		object result;
		switch (customTypeCode)
		{
		case CustomTypeCode.Byte:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				result = ((ptr3->IsNullable != 1) ? ((ptr->pOpoDscValCtx->TypeCode != 108) ? ((object)0) : DBNull.Value) : null);
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				result = (byte)ptr2->opoUdtAttrValCtx.m_float;
			}
			break;
		case CustomTypeCode.Int16:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				result = ((ptr3->IsNullable != 1) ? ((ptr->pOpoDscValCtx->TypeCode != 108) ? ((object)0) : DBNull.Value) : null);
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				result = (short)ptr2->opoUdtAttrValCtx.m_float;
			}
			break;
		case CustomTypeCode.Int32:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				result = ((ptr3->IsNullable != 1) ? ((ptr->pOpoDscValCtx->TypeCode != 108) ? ((object)0) : DBNull.Value) : null);
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				result = (int)ptr2->opoUdtAttrValCtx.m_float;
			}
			break;
		case CustomTypeCode.Int64:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				result = ((ptr3->IsNullable != 1) ? ((ptr->pOpoDscValCtx->TypeCode != 108) ? ((object)0L) : DBNull.Value) : null);
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				result = (long)ptr2->opoUdtAttrValCtx.m_float;
			}
			break;
		case CustomTypeCode.Single:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				result = ((ptr3->IsNullable != 1) ? ((ptr->pOpoDscValCtx->TypeCode != 108) ? ((object)0) : DBNull.Value) : null);
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				result = ptr2->opoUdtAttrValCtx.m_float;
			}
			break;
		case CustomTypeCode.Double:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				result = ((ptr3->IsNullable != 1) ? ((ptr->pOpoDscValCtx->TypeCode != 108) ? ((object)0) : DBNull.Value) : null);
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				result = (double)ptr2->opoUdtAttrValCtx.m_float;
			}
			break;
		case CustomTypeCode.Decimal:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				result = ((ptr3->IsNullable != 1) ? ((ptr->pOpoDscValCtx->TypeCode != 108) ? ((object)0) : DBNull.Value) : null);
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				result = (decimal)ptr2->opoUdtAttrValCtx.m_float;
			}
			break;
		case CustomTypeCode.OracleDecimal:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				result = OracleDecimal.Null;
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				result = new OracleDecimal(ptr2->pDataTmpBuffer);
				ptr2->pDataTmpBuffer = IntPtr.Zero;
			}
			break;
		default:
			status = OracleUdtStatus.Null;
			result = null;
			break;
		}
		return result;
	}

	internal unsafe static object GetDblData(OracleConnection con, IntPtr pUdt, int index, out OracleUdtStatus status)
	{
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		OpoUdtValCtx* ptr2 = ptr->pOpoUdtValCtx + index;
		AttrMetaVal* ptr3 = ((ptr->pOpoDscValCtx->TypeCode != 108) ? ptr->pOpoDscValCtx->pAttrMetaVals : (ptr->pOpoDscValCtx->pAttrMetaVals + index));
		CustomTypeCode customTypeCode = ptr3->CustTypeCode;
		if (ptr->bIsOdtConnection == 1)
		{
			customTypeCode = CustomTypeCode.OracleDecimal;
		}
		object result;
		switch (customTypeCode)
		{
		case CustomTypeCode.Byte:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				result = ((ptr3->IsNullable != 1) ? ((ptr->pOpoDscValCtx->TypeCode != 108) ? ((object)0) : DBNull.Value) : null);
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				result = (byte)ptr2->opoUdtAttrValCtx.m_double;
			}
			break;
		case CustomTypeCode.Int16:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				result = ((ptr3->IsNullable != 1) ? ((ptr->pOpoDscValCtx->TypeCode != 108) ? ((object)0) : DBNull.Value) : null);
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				result = (short)ptr2->opoUdtAttrValCtx.m_double;
			}
			break;
		case CustomTypeCode.Int32:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				result = ((ptr3->IsNullable != 1) ? ((ptr->pOpoDscValCtx->TypeCode != 108) ? ((object)0) : DBNull.Value) : null);
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				result = (int)ptr2->opoUdtAttrValCtx.m_double;
			}
			break;
		case CustomTypeCode.Int64:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				result = ((ptr3->IsNullable != 1) ? ((ptr->pOpoDscValCtx->TypeCode != 108) ? ((object)0L) : DBNull.Value) : null);
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				result = (long)ptr2->opoUdtAttrValCtx.m_double;
			}
			break;
		case CustomTypeCode.Single:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				result = ((ptr3->IsNullable != 1) ? ((ptr->pOpoDscValCtx->TypeCode != 108) ? ((object)0) : DBNull.Value) : null);
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				result = (float)ptr2->opoUdtAttrValCtx.m_double;
			}
			break;
		case CustomTypeCode.Double:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				result = ((ptr3->IsNullable != 1) ? ((ptr->pOpoDscValCtx->TypeCode != 108) ? ((object)0) : DBNull.Value) : null);
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				result = ptr2->opoUdtAttrValCtx.m_double;
			}
			break;
		case CustomTypeCode.Decimal:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				result = ((ptr3->IsNullable != 1) ? ((ptr->pOpoDscValCtx->TypeCode != 108) ? ((object)0) : DBNull.Value) : null);
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				result = (decimal)ptr2->opoUdtAttrValCtx.m_double;
			}
			break;
		case CustomTypeCode.OracleDecimal:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				result = OracleDecimal.Null;
			}
			else
			{
				status = OracleUdtStatus.NotNull;
				result = new OracleDecimal(ptr2->pDataTmpBuffer);
				ptr2->pDataTmpBuffer = IntPtr.Zero;
			}
			break;
		default:
			status = OracleUdtStatus.Null;
			result = null;
			break;
		}
		return result;
	}

	internal unsafe static object GetBFileData(OracleConnection con, IntPtr pUdt, int index, out OracleUdtStatus status)
	{
		int num = 0;
		object obj = null;
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		OpoUdtValCtx* ptr2 = ptr->pOpoUdtValCtx + index;
		AttrMetaVal* ptr3 = ((ptr->pOpoDscValCtx->TypeCode != 108) ? ptr->pOpoDscValCtx->pAttrMetaVals : (ptr->pOpoDscValCtx->pAttrMetaVals + index));
		CustomTypeCode customTypeCode = ptr3->CustTypeCode;
		if (ptr->bIsOdtConnection == 1)
		{
			customTypeCode = CustomTypeCode.OracleBFile;
		}
		if (ptr2->bIsNull != 1)
		{
			try
			{
				num = OpsUdt.GetBFile(con.m_opoConCtx.opsConCtx, ptr, index);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
			finally
			{
				if (num != 0)
				{
					OracleException.HandleError(num, con, ptr->pOpsErrCtx, null);
				}
			}
		}
		switch (customTypeCode)
		{
		case CustomTypeCode.Bytes:
		{
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				obj = null;
				break;
			}
			status = OracleUdtStatus.NotNull;
			OracleBFile oracleBFile = new OracleBFile(con, ptr2->pDataTmpBuffer, 0);
			oracleBFile.m_allocOciLobLoc = 1;
			ptr2->pDataTmpBuffer = IntPtr.Zero;
			obj = oracleBFile.Value;
			oracleBFile.Dispose();
			break;
		}
		case CustomTypeCode.OracleBFile:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				obj = OracleBFile.Null;
				break;
			}
			status = OracleUdtStatus.NotNull;
			obj = new OracleBFile(con, ptr2->pDataTmpBuffer, 0);
			((OracleBFile)obj).m_allocOciLobLoc = 1;
			ptr2->pDataTmpBuffer = IntPtr.Zero;
			break;
		default:
			status = OracleUdtStatus.Null;
			obj = null;
			break;
		}
		return obj;
	}

	internal unsafe static object GetBlobData(OracleConnection con, IntPtr pUdt, int index, out OracleUdtStatus status)
	{
		int num = 0;
		object obj = null;
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		OpoUdtValCtx* ptr2 = ptr->pOpoUdtValCtx + index;
		AttrMetaVal* ptr3 = ((ptr->pOpoDscValCtx->TypeCode != 108) ? ptr->pOpoDscValCtx->pAttrMetaVals : (ptr->pOpoDscValCtx->pAttrMetaVals + index));
		CustomTypeCode customTypeCode = ptr3->CustTypeCode;
		if (ptr->bIsOdtConnection == 1)
		{
			customTypeCode = CustomTypeCode.OracleBlob;
		}
		if (ptr2->bIsNull != 1)
		{
			try
			{
				num = OpsUdt.GetLob(con.m_opoConCtx.opsConCtx, ptr, index);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
			finally
			{
				if (num != 0)
				{
					OracleException.HandleError(num, con, ptr->pOpsErrCtx, null);
				}
			}
		}
		switch (customTypeCode)
		{
		case CustomTypeCode.Bytes:
		{
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				obj = null;
				break;
			}
			status = OracleUdtStatus.NotNull;
			OracleBlob oracleBlob = new OracleBlob(con, ptr2->pDataTmpBuffer, bCaching: false, bTempLob: false, 0);
			oracleBlob.m_allocOciLobLoc = 1;
			ptr2->pDataTmpBuffer = IntPtr.Zero;
			obj = oracleBlob.Value;
			oracleBlob.Dispose();
			break;
		}
		case CustomTypeCode.OracleBlob:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				obj = OracleBlob.Null;
				break;
			}
			status = OracleUdtStatus.NotNull;
			obj = new OracleBlob(con, ptr2->pDataTmpBuffer, bCaching: false, bTempLob: false, 0);
			((OracleBlob)obj).m_allocOciLobLoc = 1;
			ptr2->pDataTmpBuffer = IntPtr.Zero;
			break;
		default:
			status = OracleUdtStatus.Null;
			obj = null;
			break;
		}
		return obj;
	}

	internal unsafe static object GetClobData(OracleConnection con, IntPtr pUdt, int index, out OracleUdtStatus status)
	{
		int num = 0;
		object obj = null;
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		OpoUdtValCtx* ptr2 = ptr->pOpoUdtValCtx + index;
		AttrMetaVal* ptr3 = ((ptr->pOpoDscValCtx->TypeCode != 108) ? ptr->pOpoDscValCtx->pAttrMetaVals : (ptr->pOpoDscValCtx->pAttrMetaVals + index));
		bool bNClob = false;
		if (ptr3->CharsetForm == 2)
		{
			bNClob = true;
		}
		CustomTypeCode customTypeCode = ptr3->CustTypeCode;
		if (ptr->bIsOdtConnection == 1)
		{
			customTypeCode = CustomTypeCode.OracleClob;
		}
		if (ptr2->bIsNull != 1)
		{
			try
			{
				num = OpsUdt.GetLob(con.m_opoConCtx.opsConCtx, ptr, index);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
			finally
			{
				if (num != 0)
				{
					OracleException.HandleError(num, con, ptr->pOpsErrCtx, null);
				}
			}
		}
		switch (customTypeCode)
		{
		case CustomTypeCode.Chars:
		{
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				obj = null;
				break;
			}
			status = OracleUdtStatus.NotNull;
			OracleClob oracleClob2 = new OracleClob(con, ptr2->pDataTmpBuffer, bCaching: false, bNClob, bTempLob: false, 0);
			oracleClob2.m_allocOciLobLoc = 1;
			ptr2->pDataTmpBuffer = IntPtr.Zero;
			obj = oracleClob2.Value.ToCharArray();
			oracleClob2.Dispose();
			break;
		}
		case CustomTypeCode.String:
		{
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				obj = null;
				break;
			}
			status = OracleUdtStatus.NotNull;
			OracleClob oracleClob = new OracleClob(con, ptr2->pDataTmpBuffer, bCaching: false, bNClob, bTempLob: false, 0);
			oracleClob.m_allocOciLobLoc = 1;
			ptr2->pDataTmpBuffer = IntPtr.Zero;
			obj = oracleClob.Value;
			oracleClob.Dispose();
			break;
		}
		case CustomTypeCode.OracleClob:
			if (ptr2->bIsNull == 1)
			{
				status = OracleUdtStatus.Null;
				obj = OracleClob.Null;
				break;
			}
			status = OracleUdtStatus.NotNull;
			obj = new OracleClob(con, ptr2->pDataTmpBuffer, bCaching: false, bNClob, bTempLob: false, 0);
			((OracleClob)obj).m_allocOciLobLoc = 1;
			ptr2->pDataTmpBuffer = IntPtr.Zero;
			break;
		default:
			status = OracleUdtStatus.Null;
			obj = null;
			break;
		}
		return obj;
	}

	internal unsafe static object GetObjData(OracleConnection con, IntPtr pUdt, int attrIndex, out OracleUdtStatus status)
	{
		int num = 0;
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		OpoUdtValCtx* ptr2 = ptr->pOpoUdtValCtx + attrIndex;
		AttrMetaVal* ptr3 = ((ptr->pOpoDscValCtx->TypeCode != 108) ? ptr->pOpoDscValCtx->pAttrMetaVals : (ptr->pOpoDscValCtx->pAttrMetaVals + attrIndex));
		if (ptr3->pOpoDscValCtx->bIsFinalType != 1 && ptr2->bIsNull != 1)
		{
			try
			{
				num = OpsUdt.GetUdt(con.m_opoConCtx.opsConCtx, ptr, attrIndex);
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex);
				}
				throw;
			}
			finally
			{
				if (num != 0)
				{
					OracleException.HandleError(num, con, ptr->pOpsErrCtx, null);
				}
			}
		}
		OracleUdtDescriptor oracleUdtDescriptor2;
		if (ptr3->pOpoDscValCtx->bIsFinalType == 1 || ptr2->bIsNull == 1)
		{
			bool bExists;
			OracleUdtDescriptor oracleUdtDescriptor = OracleUdtDescriptor.GetOracleUdtDescriptor(con, (IntPtr)(*(void**)(void*)ptr->pTDO), bRefresh: false, out bExists);
			oracleUdtDescriptor2 = ((ptr->pOpoDscValCtx->TypeCode != 108) ? oracleUdtDescriptor.GetArrElemUdtDescriptor() : oracleUdtDescriptor.GetObjAttrUdtDescriptor(attrIndex));
		}
		else
		{
			oracleUdtDescriptor2 = OracleUdtDescriptor.GetOracleUdtDescriptor(con, ptr2->pTDO, bRefresh: false, out var bExists2);
			if (bExists2)
			{
				try
				{
					OpsDsc.UnpinTDO(con.m_opoConCtx.opsConCtx, ptr2->pTDO);
				}
				catch (Exception ex2)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex2);
					}
				}
			}
		}
		if (oracleUdtDescriptor2.m_customTypeFactory == null)
		{
			object factory = GetFactory(oracleUdtDescriptor2);
			if (factory != null)
			{
				oracleUdtDescriptor2.DescribeCustomType(factory);
			}
		}
		IOracleCustomTypeFactory oracleCustomTypeFactory = (IOracleCustomTypeFactory)oracleUdtDescriptor2.m_customTypeFactory;
		IOracleCustomType oracleCustomType = oracleCustomTypeFactory.CreateObject();
		if (ptr2->bIsNull == 1)
		{
			status = OracleUdtStatus.Null;
			Type type = oracleCustomType.GetType();
			PropertyInfo property = type.GetProperty("Null");
			if (property != null)
			{
				return property.GetValue(null, null);
			}
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(-2902, "'" + type.FullName + "'", "'Null'"));
		}
		ptr2->pOpoDscValCtx = oracleUdtDescriptor2.m_pOpoDscValCtx;
		ptr2->pOpsErrCtx = ptr->pOpsErrCtx;
		ptr2->pTDO = oracleUdtDescriptor2.m_opsDscCtx;
		ptr2->ppRefTDO = ptr->ppRefTDO;
		try
		{
			num = OpsUdt.GetObj(con.m_opoConCtx.opsConCtx, ptr2);
		}
		catch (Exception ex3)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex3);
			}
			throw;
		}
		finally
		{
			if (num != 0)
			{
				OracleException.HandleError(num, con, ptr2->pOpsErrCtx, null);
			}
		}
		ptr2->bIgnoreElemStatus = 0;
		oracleCustomType.ToCustomObject(con, (IntPtr)ptr2);
		object result = oracleCustomType;
		status = OracleUdtStatus.NotNull;
		GC.KeepAlive(oracleUdtDescriptor2);
		return result;
	}

	internal unsafe static object GetNumArrData(OracleConnection con, IntPtr pUdt, out OracleUdtStatus status, out object statusArray)
	{
		status = OracleUdtStatus.NotNull;
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		AttrMetaVal* ptr2 = ptr->pOpoDscValCtx->pAttrMetaVals;
		OracleUdtStatus[] array = ((ptr->bIgnoreElemStatus != 0) ? null : new OracleUdtStatus[ptr->NumOfArrElems]);
		object result;
		switch ((ptr->bIsOdtConnection != 1) ? ptr2->CustTypeCode : CustomTypeCode.OracleDecimal)
		{
		case CustomTypeCode.Int32:
		{
			if (ptr2->IsNullable == 1)
			{
				int?[] array4 = new int?[ptr->NumOfArrElems];
				for (int k = 0; k < ptr->NumOfArrElems; k++)
				{
					if (*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)k * (nint)4) == 0)
					{
						if (ptr->bIgnoreElemStatus == 0)
						{
							array[k] = OracleUdtStatus.NotNull;
						}
						ref int? reference2 = ref array4[k];
						reference2 = *(int*)((byte*)(void*)ptr->pDataMarshalBuffer + (nint)k * (nint)4);
					}
					else
					{
						array4[k] = null;
					}
				}
				result = array4;
				break;
			}
			int[] array5 = new int[ptr->NumOfArrElems];
			if (ptr->bIgnoreElemStatus == 0)
			{
				for (int l = 0; l < ptr->NumOfArrElems; l++)
				{
					if (*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)l * (nint)4) == 0)
					{
						array[l] = OracleUdtStatus.NotNull;
						array5[l] = *(int*)((byte*)(void*)ptr->pDataMarshalBuffer + (nint)l * (nint)4);
					}
				}
			}
			else
			{
				Marshal.Copy(ptr->pDataMarshalBuffer, array5, 0, ptr->NumOfArrElems);
			}
			result = array5;
			break;
		}
		case CustomTypeCode.Double:
		{
			if (ptr2->IsNullable == 1)
			{
				double?[] array2 = new double?[ptr->NumOfArrElems];
				for (int i = 0; i < ptr->NumOfArrElems; i++)
				{
					if (*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)i * (nint)4) == 0)
					{
						if (ptr->bIgnoreElemStatus == 0)
						{
							array[i] = OracleUdtStatus.NotNull;
						}
						ref double? reference = ref array2[i];
						reference = *(double*)((byte*)(void*)ptr->pDataMarshalBuffer + (nint)i * (nint)8);
					}
					else
					{
						array2[i] = null;
					}
				}
				result = array2;
				break;
			}
			double[] array3 = new double[ptr->NumOfArrElems];
			if (ptr->bIgnoreElemStatus == 0)
			{
				for (int j = 0; j < ptr->NumOfArrElems; j++)
				{
					if (*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)j * (nint)4) == 0)
					{
						array[j] = OracleUdtStatus.NotNull;
						array3[j] = *(double*)((byte*)(void*)ptr->pDataMarshalBuffer + (nint)j * (nint)8);
					}
				}
			}
			else
			{
				Marshal.Copy(ptr->pDataMarshalBuffer, array3, 0, ptr->NumOfArrElems);
			}
			result = array3;
			break;
		}
		default:
			result = null;
			break;
		}
		statusArray = array;
		return result;
	}

	[ConfigurationPermission(SecurityAction.Assert, Unrestricted = true)]
	internal static void SetCustomTypeMappings()
	{
		if (s_mapUdtNameToMappingObj != null)
		{
			return;
		}
		lock (s_lockObj)
		{
			if (s_mapUdtNameToMappingObj != null)
			{
				return;
			}
			Hashtable hashtable = new Hashtable();
			if (RegAndConfigRdr.m_configSection != null)
			{
				IEnumerator enumerator = RegAndConfigRdr.m_configSection.GetEnumerator();
				while (enumerator.MoveNext())
				{
					string text = RegAndConfigRdr.m_configSection[(string)enumerator.Current].Trim();
					XmlDataDocument xmlDataDocument = new XmlDataDocument();
					int num;
					for (num = text.LastIndexOf("udtMapping", StringComparison.InvariantCultureIgnoreCase); num > -1; num = text.LastIndexOf("udtMapping", num, StringComparison.InvariantCultureIgnoreCase))
					{
						string text2 = null;
						if (num > 0 && text[num - 1] == ',')
						{
							text2 = text.Substring(num);
						}
						else if (num == 0)
						{
							text2 = text;
						}
						if (text2 != null)
						{
							try
							{
								xmlDataDocument.LoadXml("<" + text2 + "/>");
							}
							catch
							{
								continue;
							}
							break;
						}
					}
					if (num == -1)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.Trace(1u, " (UDT)   Skipped Config Entry: [{%s} => {%s}]\n", enumerator.Current.ToString(), text);
						}
						continue;
					}
					if (xmlDataDocument.ChildNodes.Count != 1 || xmlDataDocument.FirstChild.HasChildNodes)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.Trace(1u, " (UDT)   Processing Config Entry: [{%s} => {%s}]\n", enumerator.Current.ToString(), text);
						}
						throw new ConfigurationErrorsException(OpoErrResManager.GetErrorMesg(-2901, string.Concat("'", enumerator.Current, "'")), xmlDataDocument);
					}
					NameValueCollection nameValueCollection = new NameValueCollection(StringComparer.CurrentCulture);
					string text3 = string.Empty;
					string text4 = null;
					string text5 = null;
					string text6 = null;
					foreach (XmlAttribute attribute in xmlDataDocument.FirstChild.Attributes)
					{
						nameValueCollection.Add(attribute.Name, attribute.Value);
						if (string.Compare(attribute.Name, "dataSource", ignoreCase: true) == 0)
						{
							text3 = attribute.Value;
							continue;
						}
						if (string.Compare(attribute.Name, "schemaName", ignoreCase: true) == 0)
						{
							text4 = attribute.Value;
							continue;
						}
						if (string.Compare(attribute.Name, "typeName", ignoreCase: true) == 0)
						{
							text5 = attribute.Value;
							continue;
						}
						if (string.Compare(attribute.Name, "factoryName", ignoreCase: true) == 0)
						{
							text6 = attribute.Value;
							continue;
						}
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.Trace(1u, " (UDT)   Processing Config Entry: [{%s} => {%s}]\n", enumerator.Current.ToString(), text);
						}
						throw new ConfigurationErrorsException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_NOT_SUPPORTED, "'udtMapping'", "'" + attribute.Name + "'"), xmlDataDocument.FirstChild);
					}
					if (text5 == null || text5 == "")
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.Trace(1u, " (UDT)   Processing Config Entry: [{%s} => {%s}]\n", enumerator.Current.ToString(), text);
						}
						throw new ConfigurationErrorsException(OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "typeName", text5), xmlDataDocument.FirstChild);
					}
					if (text6 == null || text6 == "")
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.Trace(1u, " (UDT)   Processing Config Entry: [{%s} => {%s}]\n", enumerator.Current.ToString(), text);
						}
						throw new ConfigurationErrorsException(OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "factoryName", text6), xmlDataDocument.FirstChild);
					}
					string text7 = "typeName='" + text5 + "'";
					if (text4 != null && text4.Length > 0)
					{
						text7 = "schemaName='" + text4 + "' " + text7;
					}
					if (text3 != null && text3.Length > 0)
					{
						text7 = "dataSource='" + text3.ToUpper() + "' " + text7;
					}
					hashtable[text7] = nameValueCollection;
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.Trace(1u, " (UDT)   UdtToFactoryMapping(0): [{%s} => {%s}]\n", text7, text6);
					}
				}
				if (hashtable.Count > 0)
				{
					s_mapUdtNameToMappingObj = hashtable;
					return;
				}
			}
			ArrayList allReferencedAssemblies = GetAllReferencedAssemblies();
			foreach (Assembly item in allReferencedAssemblies)
			{
				Type[] array = null;
				try
				{
					array = item.GetTypes();
				}
				catch (ReflectionTypeLoadException ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex, bCreateMiniDump: false);
					}
					Exception[] loaderExceptions = ex.LoaderExceptions;
					Exception[] array2 = loaderExceptions;
					foreach (Exception ex2 in array2)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex2, bCreateMiniDump: false);
						}
					}
					array = ex.Types;
				}
				catch (Exception ex3)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex3, bCreateMiniDump: false);
					}
				}
				if (array == null)
				{
					continue;
				}
				Type[] array3 = array;
				foreach (Type type in array3)
				{
					if (!(type != null) || (!(type.GetInterface("IOracleCustomTypeFactory") != null) && !(type.GetInterface("IOracleArrayTypeFactory") != null)))
					{
						continue;
					}
					object[] customAttributes = type.GetCustomAttributes(typeof(OracleCustomTypeMappingAttribute), inherit: false);
					if (customAttributes.Length > 0)
					{
						OracleCustomTypeMappingAttribute oracleCustomTypeMappingAttribute = (OracleCustomTypeMappingAttribute)customAttributes[0];
						NameValueCollection nameValueCollection2 = new NameValueCollection();
						nameValueCollection2["factoryName"] = type.AssemblyQualifiedName;
						object value = nameValueCollection2;
						string udtTypeName = oracleCustomTypeMappingAttribute.UdtTypeName;
						int num2 = udtTypeName.LastIndexOf('.');
						if (num2 != -1)
						{
							string text8 = oracleCustomTypeMappingAttribute.UdtTypeName.Substring(0, num2);
							string text9 = oracleCustomTypeMappingAttribute.UdtTypeName.Substring(num2 + 1);
							nameValueCollection2["schemaName"] = text8;
							nameValueCollection2["typeName"] = text9;
							udtTypeName = "schemaName='" + text8 + "' typeName='" + text9 + "'";
						}
						else
						{
							string text10 = (nameValueCollection2["typeName"] = oracleCustomTypeMappingAttribute.UdtTypeName);
							udtTypeName = "typeName='" + text10 + "'";
						}
						hashtable[udtTypeName] = value;
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.Trace(1u, " (UDT)   UdtToFactoryMapping(1): [{%s} => {%s}]\n", udtTypeName, type.AssemblyQualifiedName);
						}
					}
				}
			}
			s_mapUdtNameToMappingObj = hashtable;
		}
	}

	private static ArrayList GetAllReferencedAssemblies()
	{
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		Stack stack = new Stack();
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		Assembly[] array = assemblies;
		foreach (Assembly assembly in array)
		{
			if (!assembly.FullName.StartsWith("System") && !assembly.FullName.StartsWith("Microsoft") && !assembly.FullName.StartsWith("mscorlib"))
			{
				arrayList2.Add(assembly.FullName);
				stack.Push(assembly.FullName);
			}
		}
		while (stack.Count > 0)
		{
			try
			{
				string assemblyString = (string)stack.Pop();
				Assembly assembly2 = Assembly.Load(assemblyString);
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (UDT)   OracleUdt::GetAllReferencedAssemblies(): {%s}\n", assembly2.FullName);
				}
				arrayList.Add(assembly2);
				AssemblyName[] referencedAssemblies = assembly2.GetReferencedAssemblies();
				AssemblyName[] array2 = referencedAssemblies;
				foreach (AssemblyName assemblyName in array2)
				{
					if (!arrayList2.Contains(assemblyName.ToString()) && !assemblyName.ToString().StartsWith("System") && !assemblyName.ToString().StartsWith("Microsoft") && !assemblyName.ToString().StartsWith("mscorlib"))
					{
						arrayList2.Add(assemblyName.ToString());
						stack.Push(assemblyName.ToString());
					}
				}
			}
			catch (Exception ex)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex, bCreateMiniDump: false);
				}
			}
		}
		return arrayList;
	}

	internal unsafe static object GetFactory(OracleUdtDescriptor udtDesc)
	{
		if (udtDesc.m_udtTypeNameKey == null)
		{
			_ = udtDesc.UdtTypeName;
		}
		string text = "typeName='" + udtDesc.m_opoDscRefCtx.TypeName + "'";
		string udtTypeNameKey = udtDesc.m_udtTypeNameKey;
		string text2 = udtDesc.m_connection.DataSource.ToUpper();
		string text3 = "dataSource='" + text2 + "' " + udtTypeNameKey;
		string key = "dataSource='" + text2 + "' " + text;
		object obj = s_mapUdtNameToFactory[text3];
		if (obj == null)
		{
			lock (s_lockObj)
			{
				obj = s_mapUdtNameToFactory[text3];
				if (obj == null)
				{
					if (s_mapUdtNameToMappingObj == null)
					{
						SetCustomTypeMappings();
					}
					object obj2 = s_mapUdtNameToMappingObj[text3];
					if (obj2 == null)
					{
						obj2 = s_mapUdtNameToMappingObj[udtTypeNameKey];
					}
					if (obj2 == null)
					{
						obj2 = s_mapUdtNameToMappingObj[key];
					}
					if (obj2 == null)
					{
						obj2 = s_mapUdtNameToMappingObj[text];
					}
					if (obj2 == null)
					{
						if (udtDesc.m_pOpoDscValCtx->bIsInstantiableType == 0)
						{
							return new object();
						}
						throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(-2901, "'" + text3 + "'"));
					}
					string text4 = ((NameValueCollection)obj2)["factoryName"];
					obj = Activator.CreateInstance(Type.GetType(text4, throwOnError: true));
					s_mapUdtNameToFactory[text3] = obj;
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.Trace(1u, " (UDT)   UdtToFactoryMapping(2): [{%s} => {%s}]\n", text3, text4);
					}
				}
			}
		}
		return obj;
	}

	internal static object GetUdtName(string customTypeName, string dataSource)
	{
		dataSource = dataSource.ToUpper();
		string text = "dataSource='" + dataSource + "' customTypeName='" + customTypeName + "'";
		object obj = s_mapCustomTypeNameToUdtName[text];
		if (obj == null)
		{
			lock (s_lockObj)
			{
				obj = s_mapCustomTypeNameToUdtName[text];
				if (obj == null)
				{
					if (s_mapUdtNameToMappingObj == null)
					{
						SetCustomTypeMappings();
					}
					IDictionaryEnumerator enumerator = s_mapUdtNameToMappingObj.GetEnumerator();
					bool flag = true;
					bool flag2 = false;
					bool flag3 = enumerator.MoveNext();
					while (flag3)
					{
						_ = ((DictionaryEntry)enumerator.Current).Key;
						object value = ((DictionaryEntry)enumerator.Current).Value;
						NameValueCollection nameValueCollection = (NameValueCollection)value;
						string text2 = nameValueCollection["factoryName"];
						string text3 = nameValueCollection["dataSource"];
						if (text3 != null)
						{
							text3 = text3.ToUpper();
						}
						if ((flag && text3 == dataSource) || (!flag && (text3 == null || text3 == "")))
						{
							Type type = null;
							try
							{
								type = Type.GetType(text2);
							}
							catch (Exception ex)
							{
								if (OraTrace.m_TraceLevel != 0)
								{
									OraTrace.Trace(1u, " (UDT)   Exception loading Factory '%s': %s\n", text2, ex.Message);
								}
							}
							if (type != null)
							{
								object obj2 = Activator.CreateInstance(type);
								if (obj2 is IOracleCustomTypeFactory && ((IOracleCustomTypeFactory)obj2).CreateObject().GetType().FullName == customTypeName)
								{
									flag2 = true;
									OpoDscRefCtx opoDscRefCtx = new OpoDscRefCtx();
									opoDscRefCtx.SchemaName = nameValueCollection["schemaName"];
									opoDscRefCtx.TypeName = nameValueCollection["typeName"];
									obj = opoDscRefCtx;
									if (OraTrace.m_TraceLevel != 0)
									{
										OraTrace.Trace(1u, " (UDT)   CustomTypeToUdtMapping: [{%s} => {%s}]\n", text, "schemaName='" + opoDscRefCtx.SchemaName + "' typeName='" + opoDscRefCtx.TypeName + "'");
									}
									try
									{
										s_mapCustomTypeNameToUdtName.Add(text, obj);
									}
									catch
									{
										if (s_mapCustomTypeNameToUdtName[text] != obj)
										{
											s_mapCustomTypeNameToUdtName.Remove(text);
											throw;
										}
									}
								}
							}
						}
						if (!(flag3 = enumerator.MoveNext()) && flag)
						{
							if (flag2)
							{
								return obj;
							}
							enumerator.Reset();
							flag = false;
							flag3 = enumerator.MoveNext();
						}
					}
					if (!flag2)
					{
						throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(-2901, "'" + customTypeName + "'"));
					}
				}
			}
		}
		return obj;
	}

	internal unsafe static void SetArrayValue(OracleConnection con, IntPtr pUdt, int attrIndex, object value, object statusArray)
	{
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		AttrMetaVal* ptr2 = ptr->pOpoDscValCtx->pAttrMetaVals + attrIndex;
		_ = ptr2->CustTypeCode;
		object obj = null;
		switch ((SQLT)ptr2->OraType)
		{
		case SQLT.NUM:
		case SQLT.INT:
		case SQLT.FLT:
		case SQLT.VNU:
		case SQLT.BFLT:
		case SQLT.BDBL:
		case SQLT.UIN:
		case SQLT.IBFL:
		case SQLT.IBDL:
			SetNumArrData(pUdt, attrIndex, value, (IntPtr)ptr2, statusArray);
			return;
		case SQLT.CHR:
		case SQLT.STR:
		case SQLT.LNG:
		case SQLT.VCS:
		case SQLT.LVC:
		case SQLT.AFC:
		case SQLT.AVC:
		case SQLT.VST:
			SetStringArrData(pUdt, attrIndex, value, (IntPtr)ptr2, statusArray);
			return;
		case SQLT.NTY:
		case SQLT.NCO:
		case SQLT.PNTY:
		{
			Array array = (Array)value;
			int num = 0;
			ptr->NumOfArrElems = array.Length;
			if ((IntPtr)ptr->pOpoUdtValCtx == IntPtr.Zero)
			{
				try
				{
					num = OpsUdt.AllocValCtx(out ptr->pOpoUdtValCtx, ptr->NumOfArrElems);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
					num = ErrRes.INT_ERR;
					throw;
				}
				finally
				{
					if (num == 0)
					{
						ptr->NumOpoUdtValCtx = ptr->NumOfArrElems;
					}
					else if (num != 0 && num != ErrRes.INT_ERR)
					{
						OracleException.HandleError(num, con, ptr->pOpsErrCtx, null);
					}
				}
			}
			else if (ptr->NumOpoUdtValCtx < ptr->NumOfArrElems)
			{
				try
				{
					num = OpsUdt.ReAllocValCtx(ref ptr->pOpoUdtValCtx, ptr->NumOpoUdtValCtx, ptr->NumOfArrElems);
				}
				catch (Exception ex2)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex2);
					}
					num = ErrRes.INT_ERR;
					throw;
				}
				finally
				{
					if (num == 0)
					{
						ptr->NumOpoUdtValCtx = ptr->NumOfArrElems;
					}
					else if (num != 0 && num != ErrRes.INT_ERR)
					{
						OracleException.HandleError(num, con, ptr->pOpsErrCtx, null);
					}
				}
			}
			if (ptr2->TypeCode == 108)
			{
				for (int i = 0; i < ptr->NumOfArrElems; i++)
				{
					obj = array.GetValue(i);
					if (obj == null || obj == DBNull.Value || (obj is INullable && ((INullable)obj).IsNull))
					{
						ptr->pOpoUdtValCtx[i].bIsNull = 1;
					}
					else
					{
						SetObjData(con, (IntPtr)(ptr->pOpoUdtValCtx + i), attrIndex, obj, statusArray);
					}
				}
				return;
			}
			if (ptr2->TypeCode == 58)
			{
				for (int j = 0; j < ptr->NumOfArrElems; j++)
				{
					obj = array.GetValue(j);
					if (obj == null || obj == DBNull.Value)
					{
						ptr->pOpoUdtValCtx[j].bIsNull = 1;
					}
					else
					{
						SetXml(con, (IntPtr)(ptr->pOpoUdtValCtx + j), attrIndex, obj, (IntPtr)ptr2, statusArray);
					}
				}
				return;
			}
			bool bExists;
			OracleUdtDescriptor oracleUdtDescriptor = OracleUdtDescriptor.GetOracleUdtDescriptor(con, (IntPtr)(*(void**)(void*)ptr->pTDO), bRefresh: false, out bExists);
			oracleUdtDescriptor.GetMetaDataTable();
			OracleUdtDescriptor arrElemUdtDescriptor = oracleUdtDescriptor.GetArrElemUdtDescriptor();
			for (int k = 0; k < ptr->NumOfArrElems; k++)
			{
				obj = array.GetValue(k);
				if (obj == null || obj == DBNull.Value)
				{
					ptr->pOpoUdtValCtx[k].bIsNull = 1;
					continue;
				}
				OpoUdtValCtx* ptr3 = ptr->pOpoUdtValCtx + k;
				ptr3->pTDO = arrElemUdtDescriptor.m_opsDscCtx;
				SetArrayData(con, (IntPtr)ptr3, attrIndex, obj, statusArray);
			}
			GC.KeepAlive(oracleUdtDescriptor);
			return;
		}
		}
		Array array2 = (Array)value;
		int num2 = 0;
		ptr->NumOfArrElems = array2.Length;
		if ((IntPtr)ptr->pOpoUdtValCtx == IntPtr.Zero)
		{
			try
			{
				num2 = OpsUdt.AllocValCtx(out ptr->pOpoUdtValCtx, ptr->NumOfArrElems);
			}
			catch (Exception ex3)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex3);
				}
				num2 = ErrRes.INT_ERR;
				throw;
			}
			finally
			{
				if (num2 == 0)
				{
					ptr->NumOpoUdtValCtx = ptr->NumOfArrElems;
				}
				else if (num2 != 0 && num2 != ErrRes.INT_ERR)
				{
					OracleException.HandleError(num2, con, ptr->pOpsErrCtx, null);
				}
			}
		}
		else if (ptr->NumOpoUdtValCtx < ptr->NumOfArrElems)
		{
			try
			{
				num2 = OpsUdt.ReAllocValCtx(ref ptr->pOpoUdtValCtx, ptr->NumOpoUdtValCtx, ptr->NumOfArrElems);
			}
			catch (Exception ex4)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.TraceExceptionInfo(ex4);
				}
				num2 = ErrRes.INT_ERR;
				throw;
			}
			finally
			{
				if (num2 == 0)
				{
					ptr->NumOpoUdtValCtx = ptr->NumOfArrElems;
				}
				else if (num2 != 0 && num2 != ErrRes.INT_ERR)
				{
					OracleException.HandleError(num2, con, ptr->pOpsErrCtx, null);
				}
			}
		}
		for (int l = 0; l < ptr->NumOfArrElems; l++)
		{
			obj = array2.GetValue(l);
			if (obj == null || obj == DBNull.Value)
			{
				ptr->pOpoUdtValCtx[l].bIsNull = 1;
			}
			else
			{
				SetData(con, (IntPtr)(ptr->pOpoUdtValCtx + l), attrIndex, (OraType)ptr2->OraType, (IntPtr)ptr2, obj, statusArray);
			}
		}
	}

	internal unsafe static void SetNumArrData(IntPtr pUdt, int attrIndex, object value, IntPtr pAttrMeta, object statusArray)
	{
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		AttrMetaVal* ptr2 = (AttrMetaVal*)(void*)pAttrMeta;
		CustomTypeCode custTypeCode = ptr2->CustTypeCode;
		int num = 0;
		switch (custTypeCode)
		{
		case CustomTypeCode.Byte:
			num = ((ptr2->IsNullable != 1) ? ((byte[])value).Length : ((byte?[])value).Length);
			ptr->pStatusMarshalBuffer = Marshal.AllocCoTaskMem(num * 4);
			if (ptr->pDataMarshalBuffer == IntPtr.Zero || ptr->DataBufferSize < num)
			{
				ptr->pDataMarshalBuffer = Marshal.ReAllocCoTaskMem(ptr->pDataMarshalBuffer, num);
				ptr->DataBufferSize = num;
			}
			if (statusArray != null)
			{
				for (int num2 = 0; num2 < num; num2++)
				{
					if (((OracleUdtStatus[])statusArray)[num2] == OracleUdtStatus.Null)
					{
						*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num2 * (nint)4) = 1;
					}
					else
					{
						*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num2 * (nint)4) = 0;
					}
				}
			}
			else
			{
				for (int num3 = 0; num3 < num; num3++)
				{
					*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num3 * (nint)4) = 0;
				}
			}
			if (ptr2->IsNullable == 1)
			{
				for (int num4 = 0; num4 < num; num4++)
				{
					if (((int?)((byte?[])value)[num4]).HasValue)
					{
						if (*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num4 * (nint)4) == 0)
						{
							((byte*)(void*)ptr->pDataMarshalBuffer)[num4] = ((byte?[])value)[num4].Value;
						}
					}
					else
					{
						*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num4 * (nint)4) = 1;
					}
				}
			}
			else
			{
				Marshal.Copy((byte[])value, 0, ptr->pDataMarshalBuffer, num);
			}
			ptr->NumOfArrElems = num;
			break;
		case CustomTypeCode.Int32:
			num = ((ptr2->IsNullable != 1) ? ((int[])value).Length : ((int?[])value).Length);
			ptr->pStatusMarshalBuffer = Marshal.AllocCoTaskMem(num * 4);
			if (ptr->pDataMarshalBuffer == IntPtr.Zero || ptr->DataBufferSize < num * 4)
			{
				ptr->pDataMarshalBuffer = Marshal.ReAllocCoTaskMem(ptr->pDataMarshalBuffer, num * 4);
				ptr->DataBufferSize = num * 4;
			}
			if (statusArray != null)
			{
				for (int num18 = 0; num18 < num; num18++)
				{
					if (((OracleUdtStatus[])statusArray)[num18] == OracleUdtStatus.Null)
					{
						*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num18 * (nint)4) = 1;
					}
					else
					{
						*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num18 * (nint)4) = 0;
					}
				}
			}
			else
			{
				for (int num19 = 0; num19 < num; num19++)
				{
					*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num19 * (nint)4) = 0;
				}
			}
			if (ptr2->IsNullable == 1)
			{
				for (int num20 = 0; num20 < num; num20++)
				{
					if (((int?[])value)[num20].HasValue)
					{
						if (*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num20 * (nint)4) == 0)
						{
							*(int*)((byte*)(void*)ptr->pDataMarshalBuffer + (nint)num20 * (nint)4) = ((int?[])value)[num20].Value;
						}
					}
					else
					{
						*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num20 * (nint)4) = 1;
					}
				}
			}
			else
			{
				Marshal.Copy((int[])value, 0, ptr->pDataMarshalBuffer, num);
			}
			ptr->NumOfArrElems = num;
			break;
		case CustomTypeCode.Int16:
			num = ((ptr2->IsNullable != 1) ? ((short[])value).Length : ((short?[])value).Length);
			ptr->pStatusMarshalBuffer = Marshal.AllocCoTaskMem(num * 4);
			if (statusArray != null)
			{
				for (int num12 = 0; num12 < num; num12++)
				{
					if (((OracleUdtStatus[])statusArray)[num12] == OracleUdtStatus.Null)
					{
						*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num12 * (nint)4) = 1;
					}
					else
					{
						*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num12 * (nint)4) = 0;
					}
				}
			}
			else
			{
				for (int num13 = 0; num13 < num; num13++)
				{
					*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num13 * (nint)4) = 0;
				}
			}
			if (ptr->pDataMarshalBuffer == IntPtr.Zero || ptr->DataBufferSize < num * 2)
			{
				ptr->pDataMarshalBuffer = Marshal.ReAllocCoTaskMem(ptr->pDataMarshalBuffer, num * 2);
				ptr->DataBufferSize = num * 2;
			}
			if (ptr2->IsNullable == 1)
			{
				for (int num14 = 0; num14 < num; num14++)
				{
					if (((int?)((short?[])value)[num14]).HasValue)
					{
						if (*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num14 * (nint)4) == 0)
						{
							*(short*)((byte*)(void*)ptr->pDataMarshalBuffer + (nint)num14 * (nint)2) = ((short?[])value)[num14].Value;
						}
					}
					else
					{
						*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num14 * (nint)4) = 1;
					}
				}
			}
			else
			{
				Marshal.Copy((short[])value, 0, ptr->pDataMarshalBuffer, num);
			}
			ptr->NumOfArrElems = num;
			break;
		case CustomTypeCode.Int64:
			num = ((ptr2->IsNullable != 1) ? ((long[])value).Length : ((long?[])value).Length);
			ptr->pStatusMarshalBuffer = Marshal.AllocCoTaskMem(num * 4);
			if (ptr->pDataMarshalBuffer == IntPtr.Zero || ptr->DataBufferSize < num * 8)
			{
				ptr->pDataMarshalBuffer = Marshal.ReAllocCoTaskMem(ptr->pDataMarshalBuffer, num * 8);
				ptr->DataBufferSize = num * 8;
			}
			if (statusArray != null)
			{
				for (int num9 = 0; num9 < num; num9++)
				{
					if (((OracleUdtStatus[])statusArray)[num9] == OracleUdtStatus.Null)
					{
						*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num9 * (nint)4) = 1;
					}
					else
					{
						*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num9 * (nint)4) = 0;
					}
				}
			}
			else
			{
				for (int num10 = 0; num10 < num; num10++)
				{
					*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num10 * (nint)4) = 0;
				}
			}
			if (ptr2->IsNullable == 1)
			{
				for (int num11 = 0; num11 < num; num11++)
				{
					if (((long?[])value)[num11].HasValue)
					{
						if (*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num11 * (nint)4) == 0)
						{
							*(long*)((byte*)(void*)ptr->pDataMarshalBuffer + (nint)num11 * (nint)8) = ((long?[])value)[num11].Value;
						}
					}
					else
					{
						*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num11 * (nint)4) = 1;
					}
				}
			}
			else
			{
				Marshal.Copy((long[])value, 0, ptr->pDataMarshalBuffer, num);
			}
			ptr->NumOfArrElems = num;
			break;
		case CustomTypeCode.Single:
			num = ((ptr2->IsNullable != 1) ? ((float[])value).Length : ((float?[])value).Length);
			ptr->pStatusMarshalBuffer = Marshal.AllocCoTaskMem(num * 4);
			if (ptr->pDataMarshalBuffer == IntPtr.Zero || ptr->DataBufferSize < num * 4)
			{
				ptr->pDataMarshalBuffer = Marshal.ReAllocCoTaskMem(ptr->pDataMarshalBuffer, num * 4);
				ptr->DataBufferSize = num * 4;
			}
			if (statusArray != null)
			{
				for (int num15 = 0; num15 < num; num15++)
				{
					if (((OracleUdtStatus[])statusArray)[num15] == OracleUdtStatus.Null)
					{
						*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num15 * (nint)4) = 1;
					}
					else
					{
						*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num15 * (nint)4) = 0;
					}
				}
			}
			else
			{
				for (int num16 = 0; num16 < num; num16++)
				{
					*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num16 * (nint)4) = 0;
				}
			}
			if (ptr2->IsNullable == 1)
			{
				for (int num17 = 0; num17 < num; num17++)
				{
					if (((float?[])value)[num17].HasValue)
					{
						if (*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num17 * (nint)4) == 0)
						{
							*(float*)((byte*)(void*)ptr->pDataMarshalBuffer + (nint)num17 * (nint)4) = ((float?[])value)[num17].Value;
						}
					}
					else
					{
						*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num17 * (nint)4) = 1;
					}
				}
			}
			else
			{
				Marshal.Copy((float[])value, 0, ptr->pDataMarshalBuffer, num);
			}
			ptr->NumOfArrElems = num;
			break;
		case CustomTypeCode.Double:
			num = ((ptr2->IsNullable != 1) ? ((double[])value).Length : ((double?[])value).Length);
			ptr->pStatusMarshalBuffer = Marshal.AllocCoTaskMem(num * 4);
			if (ptr->pDataMarshalBuffer == IntPtr.Zero || ptr->DataBufferSize < num * 8)
			{
				ptr->pDataMarshalBuffer = Marshal.ReAllocCoTaskMem(ptr->pDataMarshalBuffer, num * 8);
				ptr->DataBufferSize = num * 8;
			}
			if (statusArray != null)
			{
				for (int l = 0; l < num; l++)
				{
					if (((OracleUdtStatus[])statusArray)[l] == OracleUdtStatus.Null)
					{
						*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)l * (nint)4) = 1;
					}
					else
					{
						*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)l * (nint)4) = 0;
					}
				}
			}
			else
			{
				for (int m = 0; m < num; m++)
				{
					*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)m * (nint)4) = 0;
				}
			}
			if (ptr2->IsNullable == 1)
			{
				for (int n = 0; n < num; n++)
				{
					if (((double?[])value)[n].HasValue)
					{
						if (*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)n * (nint)4) == 0)
						{
							*(double*)((byte*)(void*)ptr->pDataMarshalBuffer + (nint)n * (nint)8) = ((double?[])value)[n].Value;
						}
					}
					else
					{
						*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)n * (nint)4) = 1;
					}
				}
			}
			else
			{
				Marshal.Copy((double[])value, 0, ptr->pDataMarshalBuffer, num);
			}
			ptr->NumOfArrElems = num;
			break;
		case CustomTypeCode.Decimal:
			num = ((ptr2->IsNullable != 1) ? ((decimal[])value).Length : ((decimal?[])value).Length);
			ptr->pStatusMarshalBuffer = Marshal.AllocCoTaskMem(num * 4);
			if (ptr->pDataMarshalBuffer == IntPtr.Zero || ptr->DataBufferSize < num * 22)
			{
				ptr->pDataMarshalBuffer = Marshal.ReAllocCoTaskMem(ptr->pDataMarshalBuffer, num * 22);
				ptr->DataBufferSize = num * 22;
			}
			if (statusArray != null)
			{
				for (int num5 = 0; num5 < num; num5++)
				{
					if (((OracleUdtStatus[])statusArray)[num5] == OracleUdtStatus.Null)
					{
						*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num5 * (nint)4) = 1;
					}
					else
					{
						*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num5 * (nint)4) = 0;
					}
				}
			}
			else
			{
				for (int num6 = 0; num6 < num; num6++)
				{
					*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num6 * (nint)4) = 0;
				}
			}
			if (ptr2->IsNullable == 1)
			{
				for (int num7 = 0; num7 < num; num7++)
				{
					if (((decimal?[])value)[num7].HasValue)
					{
						if (*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num7 * (nint)4) == 0)
						{
							DecimalConv.GetBytes(((decimal?[])value)[num7].Value, (IntPtr)((byte*)(void*)ptr->pDataMarshalBuffer + (nint)num7 * (nint)22));
						}
					}
					else
					{
						*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num7 * (nint)4) = 1;
					}
				}
			}
			else
			{
				for (int num8 = 0; num8 < num; num8++)
				{
					DecimalConv.GetBytes(((decimal[])value)[num8], (IntPtr)((byte*)(void*)ptr->pDataMarshalBuffer + (nint)num8 * (nint)22));
				}
			}
			ptr->NumOfArrElems = num;
			break;
		case CustomTypeCode.OracleDecimal:
		{
			num = ((OracleDecimal[])value).Length;
			ptr->pStatusMarshalBuffer = Marshal.AllocCoTaskMem(num * 4);
			if (ptr->pDataMarshalBuffer == IntPtr.Zero || ptr->DataBufferSize < num * 22)
			{
				ptr->pDataMarshalBuffer = Marshal.ReAllocCoTaskMem(ptr->pDataMarshalBuffer, num * 22);
				ptr->DataBufferSize = num * 22;
			}
			if (statusArray != null)
			{
				for (int i = 0; i < num; i++)
				{
					if (((OracleUdtStatus[])statusArray)[i] == OracleUdtStatus.Null)
					{
						*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)i * (nint)4) = 1;
					}
					else
					{
						*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)i * (nint)4) = 0;
					}
				}
			}
			else
			{
				for (int j = 0; j < num; j++)
				{
					*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)j * (nint)4) = 0;
				}
			}
			for (int k = 0; k < num; k++)
			{
				if (((OracleDecimal[])value)[k].IsNull)
				{
					*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)k * (nint)4) = 1;
				}
				else if (*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)k * (nint)4) == 0)
				{
					DecimalConv.GetBytes(((OracleDecimal[])value)[k].Value, (IntPtr)((byte*)(void*)ptr->pDataMarshalBuffer + (nint)k * (nint)22));
				}
			}
			ptr->NumOfArrElems = num;
			break;
		}
		}
	}

	internal unsafe static void SetStringArrData(IntPtr pUdt, int attrIndex, object value, IntPtr pAttrMeta, object statusArray)
	{
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		AttrMetaVal* ptr2 = (AttrMetaVal*)(void*)pAttrMeta;
		int num = 0;
		switch (ptr2->CustTypeCode)
		{
		case CustomTypeCode.String:
		{
			num = ((string[])value).Length;
			int num4 = 0;
			if (ptr->pDataLen == null || ptr->NumOfArrElems < num)
			{
				ptr->pDataLen = (int*)(void*)Marshal.ReAllocCoTaskMem((IntPtr)ptr->pDataLen, num * 4);
			}
			ptr->pStatusMarshalBuffer = Marshal.AllocCoTaskMem(num * 4);
			for (int num5 = 0; num5 < num; num5++)
			{
				if (((string[])value)[num5] == null || (statusArray != null && ((OracleUdtStatus[])statusArray)[num5] == OracleUdtStatus.Null))
				{
					*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num5 * (nint)4) = 1;
				}
				else
				{
					*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num5 * (nint)4) = 0;
				}
			}
			for (int num6 = 0; num6 < num; num6++)
			{
				if (*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num6 * (nint)4) == 0)
				{
					ptr->pDataLen[num6] = ((string[])value)[num6].Length;
					num4 += ptr->pDataLen[num6];
				}
			}
			num4 *= 2;
			if (ptr->pDataMarshalBuffer == IntPtr.Zero || ptr->DataBufferSize < num4)
			{
				ptr->pDataMarshalBuffer = Marshal.ReAllocCoTaskMem(ptr->pDataMarshalBuffer, num4);
				ptr->DataBufferSize = num4;
			}
			IntPtr intPtr3 = ptr->pDataMarshalBuffer;
			for (int num7 = 0; num7 < num; num7++)
			{
				if (*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)num7 * (nint)4) == 0)
				{
					Marshal.Copy(((string[])value)[num7].ToCharArray(), 0, intPtr3, ptr->pDataLen[num7]);
					intPtr3 = (IntPtr)((byte*)(void*)intPtr3 + (nint)ptr->pDataLen[num7] * (nint)2);
				}
			}
			ptr->NumOfArrElems = num;
			break;
		}
		case CustomTypeCode.Chars:
		{
			num = ((char[][])value).Length;
			int num3 = 0;
			if (ptr->pDataLen == null || ptr->NumOfArrElems < num)
			{
				ptr->pDataLen = (int*)(void*)Marshal.ReAllocCoTaskMem((IntPtr)ptr->pDataLen, num * 4);
			}
			ptr->pStatusMarshalBuffer = Marshal.AllocCoTaskMem(num * 4);
			for (int l = 0; l < num; l++)
			{
				if (((char[][])value)[l] == null || (statusArray != null && ((OracleUdtStatus[])statusArray)[l] == OracleUdtStatus.Null))
				{
					*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)l * (nint)4) = 1;
				}
				else
				{
					*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)l * (nint)4) = 0;
				}
			}
			for (int m = 0; m < num; m++)
			{
				if (*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)m * (nint)4) == 0)
				{
					ptr->pDataLen[m] = ((char[][])value)[m].Length;
					num3 += ptr->pDataLen[m];
				}
			}
			num3 *= 2;
			if (ptr->pDataMarshalBuffer == IntPtr.Zero || ptr->DataBufferSize < num3)
			{
				ptr->pDataMarshalBuffer = Marshal.ReAllocCoTaskMem(ptr->pDataMarshalBuffer, num3);
				ptr->DataBufferSize = num3;
			}
			IntPtr intPtr2 = ptr->pDataMarshalBuffer;
			for (int n = 0; n < num; n++)
			{
				if (*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)n * (nint)4) == 0)
				{
					Marshal.Copy(((char[][])value)[n], 0, intPtr2, ptr->pDataLen[n]);
					intPtr2 = (IntPtr)((byte*)(void*)intPtr2 + (nint)ptr->pDataLen[n] * (nint)2);
				}
			}
			ptr->NumOfArrElems = num;
			break;
		}
		case CustomTypeCode.OracleString:
		{
			num = ((OracleString[])value).Length;
			int num2 = 0;
			if (ptr->pDataLen == null || ptr->NumOfArrElems < num)
			{
				ptr->pDataLen = (int*)(void*)Marshal.ReAllocCoTaskMem((IntPtr)ptr->pDataLen, num * 4);
			}
			ptr->pStatusMarshalBuffer = Marshal.AllocCoTaskMem(num * 4);
			for (int i = 0; i < num; i++)
			{
				if (((OracleString[])value)[i] == null || ((OracleString[])value)[i].IsNull || (statusArray != null && ((OracleUdtStatus[])statusArray)[i] == OracleUdtStatus.Null))
				{
					*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)i * (nint)4) = 1;
				}
				else
				{
					*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)i * (nint)4) = 0;
				}
			}
			for (int j = 0; j < num; j++)
			{
				if (*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)j * (nint)4) == 0)
				{
					ptr->pDataLen[j] = ((OracleString[])value)[j].Value.Length;
					num2 += ptr->pDataLen[j];
				}
			}
			num2 *= 2;
			if (ptr->pDataMarshalBuffer == IntPtr.Zero || ptr->DataBufferSize < num2)
			{
				ptr->pDataMarshalBuffer = Marshal.ReAllocCoTaskMem(ptr->pDataMarshalBuffer, num2);
				ptr->DataBufferSize = num2;
			}
			IntPtr intPtr = ptr->pDataMarshalBuffer;
			for (int k = 0; k < num; k++)
			{
				if (*(int*)((byte*)(void*)ptr->pStatusMarshalBuffer + (nint)k * (nint)4) == 0)
				{
					Marshal.Copy(((OracleString[])value)[k].Value.ToCharArray(), 0, intPtr, ptr->pDataLen[k]);
					intPtr = (IntPtr)((byte*)(void*)intPtr + (nint)ptr->pDataLen[k] * (nint)2);
				}
			}
			ptr->NumOfArrElems = num;
			break;
		}
		}
	}

	internal unsafe static void SetNumData(IntPtr pUdt, int attrIndex, object value, IntPtr pAttrMeta, object statusArray)
	{
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		AttrMetaVal* ptr2 = (AttrMetaVal*)(void*)pAttrMeta;
		CustomTypeCode custTypeCode = ptr2->CustTypeCode;
		if (statusArray != null && ((OracleUdtStatus[])statusArray)[attrIndex] == OracleUdtStatus.Null)
		{
			ptr->bIsNull = 1;
			return;
		}
		switch (custTypeCode)
		{
		case CustomTypeCode.Byte:
			ptr->opoUdtAttrValCtx.m_byte = (byte)value;
			break;
		case CustomTypeCode.Int32:
			ptr->opoUdtAttrValCtx.m_int = (int)value;
			break;
		case CustomTypeCode.Int16:
			ptr->opoUdtAttrValCtx.m_short = (short)value;
			break;
		case CustomTypeCode.Int64:
			ptr->opoUdtAttrValCtx.m_long = (long)value;
			break;
		case CustomTypeCode.Single:
			ptr->opoUdtAttrValCtx.m_float = (float)value;
			break;
		case CustomTypeCode.Double:
			ptr->opoUdtAttrValCtx.m_double = (double)value;
			break;
		case CustomTypeCode.Decimal:
			if (ptr->pDataMarshalBuffer == IntPtr.Zero)
			{
				ptr->pDataMarshalBuffer = Marshal.AllocCoTaskMem(22);
				ptr->DataBufferSize = 22L;
			}
			else if (ptr->DataBufferSize < 22)
			{
				ptr->pDataMarshalBuffer = Marshal.ReAllocCoTaskMem(ptr->pDataMarshalBuffer, 22);
				ptr->DataBufferSize = 22L;
			}
			DecimalConv.GetBytes((decimal)value, ptr->pDataMarshalBuffer);
			break;
		case CustomTypeCode.OracleDecimal:
			if (((OracleDecimal)value).IsNull)
			{
				ptr->bIsNull = 1;
				break;
			}
			if (ptr->pDataMarshalBuffer == IntPtr.Zero)
			{
				ptr->pDataMarshalBuffer = Marshal.AllocCoTaskMem(22);
				ptr->DataBufferSize = 22L;
			}
			else if (ptr->DataBufferSize < 22)
			{
				ptr->pDataMarshalBuffer = Marshal.ReAllocCoTaskMem(ptr->pDataMarshalBuffer, 22);
				ptr->DataBufferSize = 22L;
			}
			DecimalConv.GetBytes(((OracleDecimal)value).Value, ptr->pDataMarshalBuffer);
			break;
		}
	}

	internal unsafe static void SetArrayData(OracleConnection conn, IntPtr pUdt, int attrIndex, object value, object statusArray)
	{
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		int num = 0;
		bool bExists;
		OracleUdtDescriptor oracleUdtDescriptor = OracleUdtDescriptor.GetOracleUdtDescriptor(conn, (IntPtr)(*(void**)(void*)ptr->pTDO), bRefresh: false, out bExists);
		if (oracleUdtDescriptor == null)
		{
			throw new InvalidOperationException();
		}
		if (oracleUdtDescriptor.m_customTypeFactory == null)
		{
			object factory = GetFactory(oracleUdtDescriptor);
			oracleUdtDescriptor.DescribeCustomType(factory);
		}
		try
		{
			ptr->pOpsErrCtx = conn.m_opoConCtx.opsErrCtx;
			ptr->pTDO = oracleUdtDescriptor.m_opsDscCtx;
			ptr->pOpoDscValCtx = oracleUdtDescriptor.m_pOpoDscValCtx;
			if (oracleUdtDescriptor.m_pOpoDscValCtx->bIsArrayType == 0)
			{
				ptr->NumOfArrElems = 0;
				((IOracleCustomType)value).FromCustomObject(conn, (IntPtr)ptr);
			}
			else
			{
				SetValue(conn, (IntPtr)ptr, 0, value, statusArray);
			}
			num = OpsUdt.SetArrayData(conn.m_opoConCtx.opsConCtx, ptr);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
		finally
		{
			if (num != 0)
			{
				OracleException.HandleError(num, conn, conn.m_opoConCtx.opsErrCtx, null);
			}
		}
		GC.KeepAlive(oracleUdtDescriptor);
	}

	internal unsafe static void SetObjData(OracleConnection conn, IntPtr pUdt, int attrIndex, object value, object statusArray)
	{
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		int num = 0;
		OracleUdtDescriptor oracleUdtDescriptor = OracleUdtDescriptor.GetOracleUdtDescriptor2(conn, (OpoDscRefCtx)GetUdtName(value.GetType().FullName, conn.DataSource));
		if (oracleUdtDescriptor == null)
		{
			throw new InvalidOperationException();
		}
		if (oracleUdtDescriptor.m_customTypeFactory == null)
		{
			object factory = GetFactory(oracleUdtDescriptor);
			oracleUdtDescriptor.DescribeCustomType(factory);
		}
		try
		{
			if ((IntPtr)ptr->pOpoUdtValCtx == IntPtr.Zero)
			{
				try
				{
					num = OpsUdt.AllocValCtx(out ptr->pOpoUdtValCtx, oracleUdtDescriptor.AttributeCount);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
					num = ErrRes.INT_ERR;
					throw;
				}
				finally
				{
					if (num == 0)
					{
						ptr->NumOpoUdtValCtx = oracleUdtDescriptor.AttributeCount;
					}
					else if (num != 0 && num != ErrRes.INT_ERR)
					{
						OracleException.HandleError(num, conn, ptr->pOpsErrCtx, null);
					}
				}
			}
			else if (ptr->NumOpoUdtValCtx < oracleUdtDescriptor.AttributeCount)
			{
				try
				{
					num = OpsUdt.ReAllocValCtx(ref ptr->pOpoUdtValCtx, ptr->NumOpoUdtValCtx, oracleUdtDescriptor.AttributeCount);
				}
				catch (Exception ex2)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex2);
					}
					num = ErrRes.INT_ERR;
					throw;
				}
				finally
				{
					if (num == 0)
					{
						ptr->NumOpoUdtValCtx = oracleUdtDescriptor.AttributeCount;
					}
					else if (num != 0 && num != ErrRes.INT_ERR)
					{
						OracleException.HandleError(num, conn, ptr->pOpsErrCtx, null);
					}
				}
			}
			ptr->pOpsErrCtx = conn.m_opoConCtx.opsErrCtx;
			ptr->pTDO = oracleUdtDescriptor.m_opsDscCtx;
			ptr->pOpoDscValCtx = oracleUdtDescriptor.m_pOpoDscValCtx;
			for (int i = 0; i < oracleUdtDescriptor.AttributeCount; i++)
			{
				ptr->pOpoUdtValCtx[i].bIsNull = 1;
			}
			((IOracleCustomType)value).FromCustomObject(conn, (IntPtr)ptr);
			num = ((oracleUdtDescriptor.m_pOpoDscValCtx->TypeCode != 122) ? OpsUdt.SetData(conn.m_opoConCtx.opsConCtx, ptr) : OpsUdt.SetArrayData(conn.m_opoConCtx.opsConCtx, ptr));
		}
		catch (Exception ex3)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex3);
			}
			throw;
		}
		finally
		{
			if (num != 0)
			{
				OracleException.HandleError(num, conn, conn.m_opoConCtx.opsErrCtx, null);
			}
		}
		GC.KeepAlive(oracleUdtDescriptor);
	}

	internal unsafe static void SetDate(IntPtr pUdt, int attrIndex, object value, IntPtr pAttrMeta, object statusArray)
	{
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		AttrMetaVal* ptr2 = (AttrMetaVal*)(void*)pAttrMeta;
		CustomTypeCode custTypeCode = ptr2->CustTypeCode;
		if (statusArray != null && ((OracleUdtStatus[])statusArray)[attrIndex] == OracleUdtStatus.Null)
		{
			ptr->bIsNull = 1;
			return;
		}
		switch (custTypeCode)
		{
		case CustomTypeCode.DateTime:
			if (ptr2->IsNullable == 1 && value == null)
			{
				ptr->bIsNull = 1;
				break;
			}
			ptr->bIsNull = 0;
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			ptr->pDataMarshalBuffer = new OracleDate((DateTime)value).AllocValCtxFromCtx();
			break;
		case CustomTypeCode.OracleDate:
			if (((OracleDate)value).IsNull)
			{
				ptr->bIsNull = 1;
				break;
			}
			ptr->bIsNull = 0;
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			ptr->pDataMarshalBuffer = ((OracleDate)value).AllocValCtxFromCtx();
			break;
		}
	}

	internal unsafe static void SetIntervalDS(IntPtr pUdt, int attrIndex, object value, IntPtr pAttrMeta, object statusArray)
	{
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		AttrMetaVal* ptr2 = (AttrMetaVal*)(void*)pAttrMeta;
		CustomTypeCode custTypeCode = ptr2->CustTypeCode;
		if (statusArray != null && ((OracleUdtStatus[])statusArray)[attrIndex] == OracleUdtStatus.Null)
		{
			ptr->bIsNull = 1;
			return;
		}
		switch (custTypeCode)
		{
		case CustomTypeCode.TimeSpan:
		{
			if (ptr2->IsNullable == 1 && value == null)
			{
				ptr->bIsNull = 1;
				break;
			}
			ptr->bIsNull = 0;
			object obj = new OracleIntervalDS((TimeSpan)value);
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			ptr->pDataMarshalBuffer = ((OracleIntervalDS)obj).DupValCtx();
			break;
		}
		case CustomTypeCode.OracleIntervalDS:
			if (((OracleIntervalDS)value).IsNull)
			{
				ptr->bIsNull = 1;
				break;
			}
			ptr->bIsNull = 0;
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			ptr->pDataMarshalBuffer = ((OracleIntervalDS)value).DupValCtx();
			break;
		}
	}

	internal unsafe static void SetIntervalYM(IntPtr pUdt, int attrIndex, object value, IntPtr pAttrMeta, object statusArray)
	{
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		AttrMetaVal* ptr2 = (AttrMetaVal*)(void*)pAttrMeta;
		CustomTypeCode custTypeCode = ptr2->CustTypeCode;
		if (statusArray != null && ((OracleUdtStatus[])statusArray)[attrIndex] == OracleUdtStatus.Null)
		{
			ptr->bIsNull = 1;
			return;
		}
		switch (custTypeCode)
		{
		case CustomTypeCode.Int64:
		{
			if (ptr2->IsNullable == 1 && value == null)
			{
				ptr->bIsNull = 1;
				break;
			}
			ptr->bIsNull = 0;
			object obj = new OracleIntervalYM((long)value);
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			ptr->pDataMarshalBuffer = ((OracleIntervalYM)obj).DupValCtx();
			break;
		}
		case CustomTypeCode.OracleIntervalYM:
			if (((OracleIntervalYM)value).IsNull)
			{
				ptr->bIsNull = 1;
				break;
			}
			ptr->bIsNull = 0;
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			ptr->pDataMarshalBuffer = ((OracleIntervalYM)value).DupValCtx();
			break;
		}
	}

	internal unsafe static void SetBinary(IntPtr pUdt, int attrIndex, object value, IntPtr pAttrMeta, object statusArray)
	{
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		AttrMetaVal* ptr2 = (AttrMetaVal*)(void*)pAttrMeta;
		CustomTypeCode custTypeCode = ptr2->CustTypeCode;
		if (statusArray != null && ((OracleUdtStatus[])statusArray)[attrIndex] == OracleUdtStatus.Null)
		{
			ptr->bIsNull = 1;
			return;
		}
		switch (custTypeCode)
		{
		case CustomTypeCode.Bytes:
		{
			ptr->bIsNull = 0;
			int num2 = ((byte[])value).Length;
			if (ptr->pDataMarshalBuffer == IntPtr.Zero || ptr->DataBufferSize < num2)
			{
				ptr->pDataMarshalBuffer = Marshal.ReAllocCoTaskMem(ptr->pDataMarshalBuffer, num2);
				ptr->DataBufferSize = num2;
			}
			Marshal.Copy((byte[])value, 0, ptr->pDataMarshalBuffer, num2);
			ptr->DataLen = num2;
			break;
		}
		case CustomTypeCode.OracleBinary:
		{
			if (((OracleBinary)value).IsNull)
			{
				ptr->bIsNull = 1;
				break;
			}
			ptr->bIsNull = 0;
			int num = ((OracleBinary)value).Value.Length;
			if (ptr->pDataMarshalBuffer == IntPtr.Zero || ptr->DataBufferSize < num)
			{
				ptr->pDataMarshalBuffer = Marshal.ReAllocCoTaskMem(ptr->pDataMarshalBuffer, num);
				ptr->DataBufferSize = num;
			}
			Marshal.Copy(((OracleBinary)value).Value, 0, ptr->pDataMarshalBuffer, num);
			ptr->DataLen = num;
			break;
		}
		}
	}

	internal unsafe static void SetClob(OracleConnection con, IntPtr pUdt, int attrIndex, object value, IntPtr pAttrMeta, object statusArray)
	{
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		AttrMetaVal* ptr2 = (AttrMetaVal*)(void*)pAttrMeta;
		CustomTypeCode custTypeCode = ptr2->CustTypeCode;
		bool bNClob = false;
		if (ptr2->CharsetForm == 2)
		{
			bNClob = true;
		}
		if (statusArray != null && ((OracleUdtStatus[])statusArray)[attrIndex] == OracleUdtStatus.Null)
		{
			ptr->bIsNull = 1;
			return;
		}
		switch (custTypeCode)
		{
		case CustomTypeCode.OracleClob:
		{
			if (((OracleClob)value).IsNull)
			{
				ptr->bIsNull = 1;
				break;
			}
			ptr->bIsNull = 0;
			OracleClob oracleClob3 = (OracleClob)((OracleClob)value).Clone();
			oracleClob3.m_allocOciLobLoc = 0;
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			int lobLocator3 = oracleClob3.GetLobLocator(out ptr->pDataMarshalBuffer);
			oracleClob3.Dispose();
			oracleClob3 = null;
			if (lobLocator3 == 0)
			{
				break;
			}
			throw new OracleException(lobLocator3);
		}
		case CustomTypeCode.Chars:
		{
			ptr->bIsNull = 0;
			OracleClob oracleClob2 = new OracleClob(con, bCaching: false, bNClob);
			oracleClob2.m_allocOciLobLoc = 0;
			oracleClob2.Write((char[])value, 0, ((char[])value).Length);
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			int lobLocator2 = oracleClob2.GetLobLocator(out ptr->pDataMarshalBuffer);
			oracleClob2.Dispose();
			oracleClob2 = null;
			if (lobLocator2 != 0)
			{
				throw new OracleException(lobLocator2);
			}
			break;
		}
		case CustomTypeCode.String:
		{
			ptr->bIsNull = 0;
			OracleClob oracleClob = new OracleClob(con, bCaching: false, bNClob);
			oracleClob.m_allocOciLobLoc = 0;
			oracleClob.Write(((string)value).ToCharArray(), 0, ((string)value).Length);
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			int lobLocator = oracleClob.GetLobLocator(out ptr->pDataMarshalBuffer);
			oracleClob.Dispose();
			oracleClob = null;
			if (lobLocator != 0)
			{
				throw new OracleException(lobLocator);
			}
			break;
		}
		}
	}

	internal unsafe static void SetXml(OracleConnection con, IntPtr pUdt, int attrIndex, object value, IntPtr pAttrMeta, object statusArray)
	{
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		AttrMetaVal* ptr2 = (AttrMetaVal*)(void*)pAttrMeta;
		CustomTypeCode custTypeCode = ptr2->CustTypeCode;
		if (statusArray != null && ((OracleUdtStatus[])statusArray)[attrIndex] == OracleUdtStatus.Null)
		{
			ptr->bIsNull = 1;
			return;
		}
		switch (custTypeCode)
		{
		case CustomTypeCode.OracleXmlType:
		{
			if (((OracleXmlType)value).IsNull)
			{
				ptr->bIsNull = 1;
				break;
			}
			ptr->bIsNull = 0;
			OracleXmlType oracleXmlType3 = new OracleXmlType(con, ((OracleXmlType)value).Value);
			oracleXmlType3.KeepOciXmlType();
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			int oCIXMLType3 = oracleXmlType3.GetOCIXMLType(out ptr->pDataMarshalBuffer);
			oracleXmlType3.Dispose();
			oracleXmlType3 = null;
			if (oCIXMLType3 == 0)
			{
				break;
			}
			throw new OracleException(oCIXMLType3);
		}
		case CustomTypeCode.Chars:
		{
			ptr->bIsNull = 0;
			OracleXmlType oracleXmlType2 = new OracleXmlType(con, ((char[])value).ToString());
			oracleXmlType2.KeepOciXmlType();
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			int oCIXMLType2 = oracleXmlType2.GetOCIXMLType(out ptr->pDataMarshalBuffer);
			oracleXmlType2.Dispose();
			oracleXmlType2 = null;
			if (oCIXMLType2 != 0)
			{
				throw new OracleException(oCIXMLType2);
			}
			break;
		}
		case CustomTypeCode.String:
		{
			ptr->bIsNull = 0;
			OracleXmlType oracleXmlType = new OracleXmlType(con, (string)value);
			oracleXmlType.KeepOciXmlType();
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			int oCIXMLType = oracleXmlType.GetOCIXMLType(out ptr->pDataMarshalBuffer);
			oracleXmlType.Dispose();
			oracleXmlType = null;
			if (oCIXMLType != 0)
			{
				throw new OracleException(oCIXMLType);
			}
			break;
		}
		}
	}

	internal unsafe static void SetBlob(OracleConnection con, IntPtr pUdt, int attrIndex, object value, IntPtr pAttrMeta, object statusArray)
	{
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		AttrMetaVal* ptr2 = (AttrMetaVal*)(void*)pAttrMeta;
		CustomTypeCode custTypeCode = ptr2->CustTypeCode;
		if (statusArray != null && ((OracleUdtStatus[])statusArray)[attrIndex] == OracleUdtStatus.Null)
		{
			ptr->bIsNull = 1;
			return;
		}
		switch (custTypeCode)
		{
		case CustomTypeCode.OracleBlob:
		{
			if (((OracleBlob)value).IsNull)
			{
				ptr->bIsNull = 1;
				break;
			}
			ptr->bIsNull = 0;
			OracleBlob oracleBlob2 = (OracleBlob)((OracleBlob)value).Clone();
			oracleBlob2.m_allocOciLobLoc = 0;
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			int lobLocator2 = oracleBlob2.GetLobLocator(out ptr->pDataMarshalBuffer);
			oracleBlob2.Dispose();
			oracleBlob2 = null;
			if (lobLocator2 == 0)
			{
				break;
			}
			throw new OracleException(lobLocator2);
		}
		case CustomTypeCode.Bytes:
		{
			ptr->bIsNull = 0;
			OracleBlob oracleBlob = new OracleBlob(con);
			oracleBlob.m_allocOciLobLoc = 0;
			oracleBlob.Write((byte[])value, 0, ((byte[])value).Length);
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			int lobLocator = oracleBlob.GetLobLocator(out ptr->pDataMarshalBuffer);
			oracleBlob.Dispose();
			oracleBlob = null;
			if (lobLocator != 0)
			{
				throw new OracleException(lobLocator);
			}
			break;
		}
		}
	}

	internal unsafe static void SetBFile(IntPtr pUdt, int attrIndex, object value, IntPtr pAttrMeta, object statusArray)
	{
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		AttrMetaVal* ptr2 = (AttrMetaVal*)(void*)pAttrMeta;
		CustomTypeCode custTypeCode = ptr2->CustTypeCode;
		if (statusArray != null && ((OracleUdtStatus[])statusArray)[attrIndex] == OracleUdtStatus.Null)
		{
			ptr->bIsNull = 1;
			return;
		}
		switch (custTypeCode)
		{
		case CustomTypeCode.OracleBFile:
		{
			if (((OracleBFile)value).IsNull)
			{
				ptr->bIsNull = 1;
				break;
			}
			ptr->bIsNull = 0;
			OracleBFile oracleBFile = (OracleBFile)((OracleBFile)value).Clone();
			oracleBFile.m_allocOciLobLoc = 0;
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			int lobLocator = oracleBFile.GetLobLocator(out ptr->pDataMarshalBuffer);
			oracleBFile.Dispose();
			oracleBFile = null;
			if (lobLocator == 0)
			{
				break;
			}
			throw new OracleException(lobLocator);
		}
		case CustomTypeCode.Bytes:
			ptr->bIsNull = 0;
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(-2903, "'" + value.GetType().FullName + "'", "'BFILE'"));
		}
	}

	internal unsafe static void SetREF(OracleConnection con, IntPtr pUdt, int attrIndex, object value, IntPtr pAttrMeta, object statusArray)
	{
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		AttrMetaVal* ptr2 = (AttrMetaVal*)(void*)pAttrMeta;
		CustomTypeCode custTypeCode = ptr2->CustTypeCode;
		if (statusArray != null && ((OracleUdtStatus[])statusArray)[attrIndex] == OracleUdtStatus.Null)
		{
			ptr->bIsNull = 1;
			return;
		}
		switch (custTypeCode)
		{
		case CustomTypeCode.OracleRef:
			if (((OracleRef)value).IsNull)
			{
				ptr->bIsNull = 1;
				break;
			}
			ptr->bIsNull = 0;
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			ptr->pDataMarshalBuffer = Marshal.StringToCoTaskMemUni(((OracleRef)value).Value);
			ptr->DataLen = ((OracleRef)value).Value.Length;
			ptr->DataBufferSize = ptr->DataLen;
			break;
		case CustomTypeCode.String:
			ptr->bIsNull = 0;
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			ptr->pDataMarshalBuffer = Marshal.StringToCoTaskMemUni((string)value);
			ptr->DataLen = ((string)value).Length;
			ptr->DataBufferSize = ptr->DataLen;
			break;
		}
	}

	internal unsafe static void SetTimeStamp(IntPtr pUdt, int attrIndex, object value, IntPtr pAttrMeta, object statusArray)
	{
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		AttrMetaVal* ptr2 = (AttrMetaVal*)(void*)pAttrMeta;
		CustomTypeCode custTypeCode = ptr2->CustTypeCode;
		if (statusArray != null && ((OracleUdtStatus[])statusArray)[attrIndex] == OracleUdtStatus.Null)
		{
			ptr->bIsNull = 1;
			return;
		}
		switch (custTypeCode)
		{
		case CustomTypeCode.DateTime:
		{
			if (ptr2->IsNullable == 1 && value == null)
			{
				ptr->bIsNull = 1;
				break;
			}
			ptr->bIsNull = 0;
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			object obj = new OracleTimeStamp((DateTime)value);
			ptr->pDataMarshalBuffer = ((OracleTimeStamp)obj).DupValCtx();
			break;
		}
		case CustomTypeCode.OracleTimeStamp:
			if (((OracleTimeStamp)value).IsNull)
			{
				ptr->bIsNull = 1;
				break;
			}
			ptr->bIsNull = 0;
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			ptr->pDataMarshalBuffer = ((OracleTimeStamp)value).DupValCtx();
			break;
		}
	}

	internal unsafe static void SetTimeStampLTZ(IntPtr pUdt, int attrIndex, object value, IntPtr pAttrMeta, object statusArray)
	{
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		AttrMetaVal* ptr2 = (AttrMetaVal*)(void*)pAttrMeta;
		CustomTypeCode custTypeCode = ptr2->CustTypeCode;
		if (statusArray != null && ((OracleUdtStatus[])statusArray)[attrIndex] == OracleUdtStatus.Null)
		{
			ptr->bIsNull = 1;
			return;
		}
		switch (custTypeCode)
		{
		case CustomTypeCode.DateTime:
		{
			if (ptr2->IsNullable == 1 && value == null)
			{
				ptr->bIsNull = 1;
				break;
			}
			ptr->bIsNull = 0;
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			object obj = new OracleTimeStampLTZ((DateTime)value);
			ptr->pDataMarshalBuffer = ((OracleTimeStampLTZ)obj).DupValCtx();
			break;
		}
		case CustomTypeCode.OracleTimeStampLTZ:
			if (((OracleTimeStampLTZ)value).IsNull)
			{
				ptr->bIsNull = 1;
				break;
			}
			ptr->bIsNull = 0;
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			ptr->pDataMarshalBuffer = ((OracleTimeStampLTZ)value).DupValCtx();
			break;
		}
	}

	internal unsafe static void SetTimeStampTZ(IntPtr pUdt, int attrIndex, object value, IntPtr pAttrMeta, object statusArray)
	{
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		AttrMetaVal* ptr2 = (AttrMetaVal*)(void*)pAttrMeta;
		CustomTypeCode custTypeCode = ptr2->CustTypeCode;
		if (statusArray != null && ((OracleUdtStatus[])statusArray)[attrIndex] == OracleUdtStatus.Null)
		{
			ptr->bIsNull = 1;
			return;
		}
		switch (custTypeCode)
		{
		case CustomTypeCode.DateTime:
		{
			if (ptr2->IsNullable == 1 && value == null)
			{
				ptr->bIsNull = 1;
				break;
			}
			ptr->bIsNull = 0;
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			object obj = new OracleTimeStampTZ((DateTime)value);
			ptr->pDataMarshalBuffer = ((OracleTimeStampTZ)obj).DupValCtx();
			break;
		}
		case CustomTypeCode.OracleTimeStampTZ:
			if (((OracleTimeStampTZ)value).IsNull)
			{
				ptr->bIsNull = 1;
				break;
			}
			ptr->bIsNull = 0;
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			ptr->pDataMarshalBuffer = ((OracleTimeStampTZ)value).DupValCtx();
			break;
		}
	}

	internal unsafe static void SetStringData(IntPtr pUdt, int attrIndex, object value, IntPtr pAttrMeta, object statusArray)
	{
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		AttrMetaVal* ptr2 = (AttrMetaVal*)(void*)pAttrMeta;
		CustomTypeCode custTypeCode = ptr2->CustTypeCode;
		if (statusArray != null && ((OracleUdtStatus[])statusArray)[attrIndex] == OracleUdtStatus.Null)
		{
			ptr->bIsNull = 1;
			return;
		}
		switch (custTypeCode)
		{
		case CustomTypeCode.String:
		{
			ptr->bIsNull = 0;
			int length = ((string)value).Length;
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			ptr->pDataMarshalBuffer = Marshal.StringToCoTaskMemUni((string)value);
			ptr->DataBufferSize = length;
			ptr->DataLen = length;
			break;
		}
		case CustomTypeCode.OracleString:
		{
			if (((OracleString)value).IsNull)
			{
				ptr->bIsNull = 1;
				break;
			}
			ptr->bIsNull = 0;
			string value2 = ((OracleString)value).Value;
			int length2 = value2.Length;
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			ptr->pDataMarshalBuffer = Marshal.StringToCoTaskMemUni(value2);
			ptr->DataBufferSize = length2;
			ptr->DataLen = length2;
			break;
		}
		case CustomTypeCode.Chars:
		{
			ptr->bIsNull = 0;
			int num = ((char[])value).Length;
			if (ptr->pDataMarshalBuffer != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(ptr->pDataMarshalBuffer);
				ptr->pDataMarshalBuffer = IntPtr.Zero;
			}
			ptr->pDataMarshalBuffer = Marshal.AllocCoTaskMem(num * 2);
			ptr->DataBufferSize = num;
			Marshal.Copy((char[])value, 0, ptr->pDataMarshalBuffer, num);
			ptr->DataLen = num;
			break;
		}
		}
	}

	internal unsafe static void SetData(OracleConnection con, IntPtr pUdt, int attrIndex, OraType oraType, IntPtr pAttrMetaVal, object value, object statusArray)
	{
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		switch ((SQLT)oraType)
		{
		case SQLT.DAT:
		case SQLT.ODT:
		case SQLT.DATE:
			SetDate((IntPtr)ptr, attrIndex, value, pAttrMetaVal, statusArray);
			break;
		case SQLT.INTERVAL_DS:
			SetIntervalDS((IntPtr)ptr, attrIndex, value, pAttrMetaVal, statusArray);
			break;
		case SQLT.TIMESTAMP:
			SetTimeStamp((IntPtr)ptr, attrIndex, value, pAttrMetaVal, statusArray);
			break;
		case SQLT.TIMESTAMP_LTZ:
			SetTimeStampLTZ((IntPtr)ptr, attrIndex, value, pAttrMetaVal, statusArray);
			break;
		case SQLT.TIMESTAMP_TZ:
			SetTimeStampTZ((IntPtr)ptr, attrIndex, value, pAttrMetaVal, statusArray);
			break;
		case SQLT.INTERVAL_YM:
			SetIntervalYM((IntPtr)ptr, attrIndex, value, pAttrMetaVal, statusArray);
			break;
		case SQLT.VBI:
		case SQLT.BIN:
		case SQLT.LBI:
		case SQLT.LVB:
			SetBinary((IntPtr)ptr, attrIndex, value, pAttrMetaVal, statusArray);
			break;
		case SQLT.BLOB:
			SetBlob(con, (IntPtr)ptr, attrIndex, value, pAttrMetaVal, statusArray);
			break;
		case SQLT.CLOB:
		case SQLT.CFILEE:
			SetClob(con, (IntPtr)ptr, attrIndex, value, pAttrMetaVal, statusArray);
			break;
		case SQLT.BFILEE:
			SetBFile((IntPtr)ptr, attrIndex, value, pAttrMetaVal, statusArray);
			break;
		case SQLT.REF:
			SetREF(con, (IntPtr)ptr, attrIndex, value, pAttrMetaVal, statusArray);
			break;
		}
	}

	public unsafe static void SetValue(OracleConnection con, IntPtr pUdt, int attrIndex, object value, object statusArray)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleUdt::SetValue(2)\n");
		}
		if (con == null)
		{
			throw new ArgumentNullException("con");
		}
		if (pUdt == IntPtr.Zero)
		{
			throw new ArgumentException("pUdt");
		}
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		if (ptr->pStatusMarshalBuffer != IntPtr.Zero)
		{
			Marshal.FreeCoTaskMem(ptr->pStatusMarshalBuffer);
			ptr->pStatusMarshalBuffer = IntPtr.Zero;
		}
		if (ptr->pOpoDscValCtx->TypeCode == 122)
		{
			if (attrIndex != 0)
			{
				throw new ArgumentOutOfRangeException("attrIndex");
			}
			if (value == null || value == DBNull.Value)
			{
				ptr->bIsNull = 1;
				return;
			}
			ptr->bIsNull = 0;
			SetArrayValue(con, pUdt, attrIndex, value, statusArray);
			return;
		}
		if (attrIndex < 0 || attrIndex >= ptr->pOpoDscValCtx->NumAttrs)
		{
			throw new ArgumentOutOfRangeException("attrIndex");
		}
		OpoUdtValCtx* ptr2 = ptr->pOpoUdtValCtx + attrIndex;
		AttrMetaVal* ptr3 = ptr->pOpoDscValCtx->pAttrMetaVals + attrIndex;
		if (ptr3->CustTypeCode == (CustomTypeCode)0)
		{
			throw new ArgumentException(OpoErrResManager.GetErrorMesg(-2905));
		}
		if (value == null || value == DBNull.Value)
		{
			ptr2->bIsNull = 1;
			return;
		}
		if (value is INullable && ((INullable)value).IsNull)
		{
			ptr2->bIsNull = 1;
			return;
		}
		ptr2->bIsNull = 0;
		_ = ptr3->CustTypeCode;
		switch ((SQLT)ptr3->OraType)
		{
		case SQLT.NUM:
		case SQLT.INT:
		case SQLT.FLT:
		case SQLT.VNU:
		case SQLT.BFLT:
		case SQLT.BDBL:
		case SQLT.UIN:
		case SQLT.IBFL:
		case SQLT.IBDL:
			SetNumData((IntPtr)ptr2, attrIndex, value, (IntPtr)ptr3, statusArray);
			break;
		case SQLT.CHR:
		case SQLT.STR:
		case SQLT.LNG:
		case SQLT.VCS:
		case SQLT.LVC:
		case SQLT.AFC:
		case SQLT.AVC:
		case SQLT.VST:
			SetStringData((IntPtr)ptr2, attrIndex, value, (IntPtr)ptr3, statusArray);
			break;
		case SQLT.DAT:
		case SQLT.ODT:
		case SQLT.DATE:
			SetDate((IntPtr)ptr2, attrIndex, value, (IntPtr)ptr3, statusArray);
			break;
		case SQLT.INTERVAL_DS:
			SetIntervalDS((IntPtr)ptr2, attrIndex, value, (IntPtr)ptr3, statusArray);
			break;
		case SQLT.TIMESTAMP:
			SetTimeStamp((IntPtr)ptr2, attrIndex, value, (IntPtr)ptr3, statusArray);
			break;
		case SQLT.TIMESTAMP_LTZ:
			SetTimeStampLTZ((IntPtr)ptr2, attrIndex, value, (IntPtr)ptr3, statusArray);
			break;
		case SQLT.TIMESTAMP_TZ:
			SetTimeStampTZ((IntPtr)ptr2, attrIndex, value, (IntPtr)ptr3, statusArray);
			break;
		case SQLT.INTERVAL_YM:
			SetIntervalYM((IntPtr)ptr2, attrIndex, value, (IntPtr)ptr3, statusArray);
			break;
		case SQLT.VBI:
		case SQLT.BIN:
		case SQLT.LBI:
		case SQLT.LVB:
			SetBinary((IntPtr)ptr2, attrIndex, value, (IntPtr)ptr3, statusArray);
			break;
		case SQLT.BLOB:
			SetBlob(con, (IntPtr)ptr2, attrIndex, value, (IntPtr)ptr3, statusArray);
			break;
		case SQLT.CLOB:
		case SQLT.CFILEE:
			SetClob(con, (IntPtr)ptr2, attrIndex, value, (IntPtr)ptr3, statusArray);
			break;
		case SQLT.BFILEE:
			SetBFile((IntPtr)ptr2, attrIndex, value, (IntPtr)ptr3, statusArray);
			break;
		case SQLT.REF:
			SetREF(con, (IntPtr)ptr2, attrIndex, value, (IntPtr)ptr3, statusArray);
			break;
		case SQLT.NTY:
		case SQLT.NCO:
		case SQLT.PNTY:
		{
			if (ptr3->TypeCode == 108)
			{
				SetObjData(con, (IntPtr)ptr2, attrIndex, value, statusArray);
				break;
			}
			if (ptr3->TypeCode == 58)
			{
				SetXml(con, (IntPtr)ptr2, attrIndex, value, (IntPtr)ptr3, statusArray);
				break;
			}
			bool bExists;
			OracleUdtDescriptor oracleUdtDescriptor = OracleUdtDescriptor.GetOracleUdtDescriptor(con, (IntPtr)(*(void**)(void*)ptr->pTDO), bRefresh: false, out bExists);
			OracleUdtDescriptor oracleUdtDescriptor2 = ((ptr->pOpoDscValCtx->TypeCode != 108) ? oracleUdtDescriptor.GetArrElemUdtDescriptor() : oracleUdtDescriptor.GetObjAttrUdtDescriptor(attrIndex));
			ptr2->pTDO = oracleUdtDescriptor2.m_opsDscCtx;
			SetArrayData(con, (IntPtr)ptr2, 0, value, statusArray);
			GC.KeepAlive(oracleUdtDescriptor);
			break;
		}
		case SQLT.PDN:
		case SQLT.NON:
		case SQLT.RID:
		case SQLT.SLS:
		case SQLT.CUR:
		case SQLT.RDD:
		case SQLT.LAB:
		case SQLT.OSL:
		case SQLT.RSET:
			throw new NotSupportedException();
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleUdt::SetValue(2)\n");
		}
	}

	public static void SetValue(OracleConnection con, IntPtr pUdt, string attrName, object value)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleUdt::SetValue(1)\n");
		}
		SetValue(con, pUdt, attrName, value, null);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleUdt::SetValue(1)\n");
		}
	}

	public static void SetValue(OracleConnection con, IntPtr pUdt, int attrIndex, object value)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleUdt::SetValue(0)\n");
		}
		SetValue(con, pUdt, attrIndex, value, null);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleUdt::SetValue(0)\n");
		}
	}

	public unsafe static void SetValue(OracleConnection con, IntPtr pUdt, string attrName, object value, object statusArray)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleUdt::SetValue(3)\n");
		}
		if (con == null)
		{
			throw new ArgumentNullException("con");
		}
		if (pUdt == IntPtr.Zero)
		{
			throw new ArgumentException("pUdt");
		}
		OpoUdtValCtx* ptr = (OpoUdtValCtx*)(void*)pUdt;
		int attrIndex;
		if (ptr->pOpoDscValCtx->TypeCode == 108)
		{
			if (attrName == null)
			{
				throw new ArgumentNullException("attrName");
			}
			if (attrName == "")
			{
				throw new ArgumentException("attrName");
			}
			bool bExists;
			OracleUdtDescriptor oracleUdtDescriptor = OracleUdtDescriptor.GetOracleUdtDescriptor(con, (IntPtr)(*(void**)(void*)ptr->pTDO), bRefresh: false, out bExists);
			oracleUdtDescriptor.GetMetaDataTable();
			object obj = oracleUdtDescriptor.m_attrNameToIndex[attrName];
			if (obj == null)
			{
				throw new ArgumentException("attrName");
			}
			attrIndex = (int)obj;
		}
		else
		{
			if (attrName != null && !(attrName == ""))
			{
				throw new ArgumentException("attrName");
			}
			attrIndex = 0;
		}
		SetValue(con, pUdt, attrIndex, value, statusArray);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleUdt::SetValue(3)\n");
		}
	}
}
