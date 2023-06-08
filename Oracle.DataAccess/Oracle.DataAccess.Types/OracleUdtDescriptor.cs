using System;
using System.Collections;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using Oracle.DataAccess.Client;

namespace Oracle.DataAccess.Types;

internal sealed class OracleUdtDescriptor : MarshalByRefObject
{
	private static readonly string s_xmlTypeName;

	private static int s_attrMetaRefMarshalSize;

	private static Hashtable s_mapTypeNameToCustTypeCode;

	internal static Hashtable s_mapCustTypeCodeToTypeName;

	private static object s_lockObj;

	private IntPtr m_opsConCtx;

	private IntPtr m_opsErrCtx;

	internal OpoDscRefCtx m_opoDscRefCtx;

	private DataTable m_metaDataTable;

	private bool m_bAllObjAttrsDescribed;

	private bool m_bAllObjAttrMetaRefsMarshalled;

	private bool m_bFetchedNumArrElems;

	private bool m_bFetchedUdtTypeName;

	private AttrMetaRef[] m_attrMetaRefs;

	internal Hashtable m_attrNameToIndex;

	private int m_conSignature;

	internal IntPtr m_opsDscCtx;

	internal OracleConnection m_connection;

	internal OracleDbType m_oraDbType;

	internal bool m_bSetOracleDbType;

	internal unsafe OpoDscValCtx* m_pOpoDscValCtx;

	internal object m_customTypeFactory;

	internal Type m_UdtType;

	internal string m_udtTypeNameKey;

	public unsafe int AttributeCount
	{
		get
		{
			int num = 0;
			OciTypeCode ociTypeCode = ((m_pOpoDscValCtx->bDescribedUdt != 0) ? ((OciTypeCode)m_pOpoDscValCtx->TypeCode) : GetUdtTypeCode());
			if (ociTypeCode == OciTypeCode.OBJECT || ociTypeCode == OciTypeCode.OPAQUE)
			{
				if (m_pOpoDscValCtx->bFetchedNumObjAttrs == 0)
				{
					if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
					{
						throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
					}
					if (m_connection.m_conSignature != m_conSignature)
					{
						throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
					}
					try
					{
						num = OpsDsc.GetNumObjAttrs(m_opsConCtx, m_opsErrCtx, m_opsDscCtx, m_pOpoDscValCtx);
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
							OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
						}
					}
					m_pOpoDscValCtx->bFetchedNumObjAttrs = 1;
				}
				return (int)m_pOpoDscValCtx->NumAttrs;
			}
			return 0;
		}
	}

	public unsafe int MaxSize
	{
		get
		{
			int num = 0;
			OciTypeCode ociTypeCode = ((m_pOpoDscValCtx->bDescribedUdt != 0) ? ((OciTypeCode)m_pOpoDscValCtx->TypeCode) : GetUdtTypeCode());
			if (ociTypeCode == OciTypeCode.OBJECT || ociTypeCode == OciTypeCode.OPAQUE || (m_pOpoDscValCtx->CollTypeCode != 0 && m_pOpoDscValCtx->CollTypeCode == 248))
			{
				return 0;
			}
			if (!m_bFetchedNumArrElems)
			{
				if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
				{
					throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
				}
				if (m_connection.m_conSignature != m_conSignature)
				{
					throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
				}
				try
				{
					num = OpsDsc.GetNumArrElems(m_opsConCtx, m_opsErrCtx, m_opsDscCtx, m_pOpoDscValCtx);
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
						OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
					}
				}
				m_bFetchedNumArrElems = true;
			}
			return (int)m_pOpoDscValCtx->NumAttrs;
		}
	}

	public unsafe OracleDbType OracleDbType
	{
		get
		{
			if (!m_bSetOracleDbType)
			{
				m_oraDbType = OracleDbType.Object;
				switch ((OciTypeCode)((m_pOpoDscValCtx->bDescribedUdt != 0) ? ((int)m_pOpoDscValCtx->TypeCode) : ((int)GetUdtTypeCode())))
				{
				case OciTypeCode.NAMEDCOLLECTION:
					if (m_pOpoDscValCtx->CollTypeCode == 0)
					{
						GetArrTypeCode();
					}
					m_oraDbType = OracleDbType.Array;
					break;
				case OciTypeCode.OPAQUE:
					if (UdtTypeName == s_xmlTypeName)
					{
						m_oraDbType = OracleDbType.XmlType;
					}
					break;
				}
				m_bSetOracleDbType = true;
			}
			return m_oraDbType;
		}
	}

	public string SchemaName
	{
		get
		{
			if (!m_bFetchedUdtTypeName)
			{
				GetUdtTypeName();
				m_bFetchedUdtTypeName = true;
			}
			return m_opoDscRefCtx.SchemaName;
		}
	}

	public string UdtTypeName
	{
		get
		{
			if (!m_bFetchedUdtTypeName)
			{
				GetUdtTypeName();
				m_bFetchedUdtTypeName = true;
			}
			m_udtTypeNameKey = "schemaName='" + m_opoDscRefCtx.SchemaName + "' typeName='" + m_opoDscRefCtx.TypeName + "'";
			return m_opoDscRefCtx.SchemaName + "." + m_opoDscRefCtx.TypeName;
		}
	}

	public static OracleUdtDescriptor GetOracleUdtDescriptor(OracleConnection con, string udtTypeName)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleUdtDescriptor::GetOracleUdtDescriptor(OracleConnection, string)\n");
		}
		if (con == null)
		{
			throw new ArgumentNullException("con");
		}
		if (udtTypeName == null)
		{
			throw new ArgumentNullException("udtTypeName");
		}
		if (udtTypeName == string.Empty)
		{
			throw new ArgumentException("udtTypeName");
		}
		string schemaName = null;
		string typeName = udtTypeName;
		int num = udtTypeName.LastIndexOf('.');
		if (num != -1)
		{
			schemaName = udtTypeName.Substring(0, num);
			typeName = udtTypeName.Substring(num + 1);
		}
		OracleUdtDescriptor oracleUdtDescriptor = GetOracleUdtDescriptor(con, schemaName, typeName);
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleUdtDescriptor::GetOracleUdtDescriptor(OracleConnection, string)\n");
		}
		return oracleUdtDescriptor;
	}

	internal static OracleUdtDescriptor GetOracleUdtDescriptor2(OracleConnection con, OpoDscRefCtx opoDscRefCtx)
	{
		if (con == null)
		{
			throw new ArgumentNullException("con");
		}
		if (opoDscRefCtx == null)
		{
			throw new ArgumentNullException("opoDscRefCtx");
		}
		return GetOracleUdtDescriptor(con, opoDscRefCtx.SchemaName, opoDscRefCtx.TypeName);
	}

	public unsafe DataTable GetMetaDataTable()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleUdtDescriptor::GetMetaDataTable()\n");
		}
		if (m_metaDataTable == null)
		{
			lock (this)
			{
				if (m_metaDataTable == null)
				{
					int num = 0;
					OciTypeCode ociTypeCode = ((m_pOpoDscValCtx->bDescribedUdt != 0) ? ((OciTypeCode)m_pOpoDscValCtx->TypeCode) : GetUdtTypeCode());
					if (ociTypeCode == OciTypeCode.OBJECT || ociTypeCode == OciTypeCode.OPAQUE)
					{
						if (!m_bAllObjAttrMetaRefsMarshalled)
						{
							if (!m_bAllObjAttrsDescribed)
							{
								DescribeAllObjAttrs();
								m_bAllObjAttrsDescribed = true;
							}
							if (m_attrMetaRefs == null)
							{
								m_attrMetaRefs = new AttrMetaRef[m_pOpoDscValCtx->NumAttrs];
							}
							for (int i = 0; i < m_pOpoDscValCtx->NumAttrs; i++)
							{
								if (m_attrMetaRefs[i] == null)
								{
									MarshalAttrMetaRef(i);
								}
							}
							m_bAllObjAttrMetaRefsMarshalled = true;
						}
						num = (int)m_pOpoDscValCtx->NumAttrs;
					}
					else
					{
						if (m_attrMetaRefs == null)
						{
							m_attrMetaRefs = new AttrMetaRef[1];
						}
						if (m_attrMetaRefs[0] == null)
						{
							if (m_pOpoDscValCtx->pAttrMetaVals == null || m_pOpoDscValCtx->pAttrMetaVals->bDescribed == 0)
							{
								DescribeArrElem();
								m_pOpoDscValCtx->pAttrMetaVals->bDescribed = 1;
							}
							MarshalAttrMetaRef(0);
						}
						num = 1;
					}
					m_metaDataTable = new DataTable("MetaDataTable");
					m_metaDataTable.Columns.Add("Name", typeof(string));
					m_metaDataTable.Columns.Add("UdtDescriptor", typeof(OracleUdtDescriptor));
					m_metaDataTable.Columns.Add("Size", typeof(int));
					m_metaDataTable.Columns.Add("NumericPrecision", typeof(short));
					m_metaDataTable.Columns.Add("NumericScale", typeof(short));
					m_metaDataTable.Columns.Add("ProviderType", typeof(OracleDbType));
					m_metaDataTable.MinimumCapacity = num;
					for (int j = 0; j < num; j++)
					{
						DataRow dataRow = m_metaDataTable.NewRow();
						if (ociTypeCode == OciTypeCode.OBJECT)
						{
							dataRow[0] = m_attrMetaRefs[j].AttrName;
						}
						OciTypeCode typeCode = (OciTypeCode)m_pOpoDscValCtx->pAttrMetaVals[j].TypeCode;
						OraType oraType = (OraType)m_pOpoDscValCtx->pAttrMetaVals[j].OraType;
						OracleUdtDescriptor oracleUdtDescriptor = null;
						if (oraType == OraType.ORA_NDT || oraType == OraType.ORA_OCIRef)
						{
							oracleUdtDescriptor = (OracleUdtDescriptor)(dataRow[1] = GetOracleUdtDescriptor(m_connection, m_attrMetaRefs[j].AttrSchemaName, m_attrMetaRefs[j].AttrTypeName));
						}
						if (typeCode == OciTypeCode.NAMEDCOLLECTION)
						{
							dataRow[2] = oracleUdtDescriptor.MaxSize;
						}
						else if (oraType == OraType.ORA_CHAR || oraType == OraType.ORA_CHARN || oraType == OraType.ORA_RAW)
						{
							dataRow[2] = m_pOpoDscValCtx->pAttrMetaVals[j].Size;
						}
						if (oraType == OraType.ORA_NUMBER)
						{
							dataRow[3] = m_pOpoDscValCtx->pAttrMetaVals[j].Precision;
							dataRow[4] = m_pOpoDscValCtx->pAttrMetaVals[j].Scale;
						}
						OracleDbType oracleDbType;
						switch (oraType)
						{
						case OraType.ORA_NDT:
							oracleDbType = ((!oracleUdtDescriptor.m_bSetOracleDbType) ? oracleUdtDescriptor.OracleDbType : oracleUdtDescriptor.m_oraDbType);
							break;
						case OraType.ORA_OCIRef:
							oracleDbType = OracleDbType.Ref;
							break;
						case OraType.ORA_NUMBER:
							oracleDbType = OraDb_DbTypeTable.ConvertNumberToOraDbType(m_pOpoDscValCtx->pAttrMetaVals[j].Precision, m_pOpoDscValCtx->pAttrMetaVals[j].Scale);
							break;
						default:
							oracleDbType = (OracleDbType)OraDb_DbTypeTable.oraTypeToOracleDbTypeMapping[m_pOpoDscValCtx->pAttrMetaVals[j].OraType];
							if (m_pOpoDscValCtx->pAttrMetaVals[j].CharsetForm == 2)
							{
								switch (oracleDbType)
								{
								case OracleDbType.Varchar2:
									oracleDbType = OracleDbType.NVarchar2;
									break;
								case OracleDbType.Char:
									oracleDbType = OracleDbType.NChar;
									break;
								case OracleDbType.Clob:
									oracleDbType = OracleDbType.NClob;
									break;
								}
							}
							break;
						}
						dataRow[5] = oracleDbType;
						m_metaDataTable.Rows.Add(dataRow);
					}
					m_metaDataTable.AcceptChanges();
					if (ociTypeCode == OciTypeCode.OBJECT)
					{
						CalcIndOffsets();
					}
				}
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleUdtDescriptor::GetMetaDataTable()\n");
		}
		return m_metaDataTable;
	}

	internal static OracleUdtDescriptor GetOracleUdtDescriptor(OracleConnection con, string schemaName, string typeName)
	{
		if (schemaName == null)
		{
			schemaName = string.Empty;
		}
		string fqName = "schemaName='" + schemaName + "' typeName='" + typeName + "'";
		return GetOracleUdtDescriptor(con, fqName, schemaName, typeName, bRefresh: false);
	}

	internal unsafe static OracleUdtDescriptor GetOracleUdtDescriptor(OracleConnection con, IntPtr pTDO, bool bRefresh, out bool bExists)
	{
		if (con.m_contextConnection)
		{
			throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.CLR_UDT_NOTSUPPORTED_CTX_CONN));
		}
		if (pTDO == IntPtr.Zero)
		{
			throw new ArgumentException("pTDO");
		}
		OracleUdtDescriptor oracleUdtDescriptor;
		if (bRefresh || (oracleUdtDescriptor = (OracleUdtDescriptor)con.m_opoConCtx.m_udtDescPoolerByTDO.Get(pTDO)) == null || oracleUdtDescriptor.m_pOpoDscValCtx->bInvalidTDO == 1)
		{
			lock (s_lockObj)
			{
				if (bRefresh || (oracleUdtDescriptor = (OracleUdtDescriptor)con.m_opoConCtx.m_udtDescPoolerByTDO.Get(pTDO)) == null || oracleUdtDescriptor.m_pOpoDscValCtx->bInvalidTDO == 1)
				{
					oracleUdtDescriptor = new OracleUdtDescriptor(con, pTDO);
					if (con.m_opoConCtx.metaPool == 1)
					{
						con.m_opoConCtx.m_udtDescPoolerByTDO.Put(pTDO, oracleUdtDescriptor);
					}
					bExists = true;
					return oracleUdtDescriptor;
				}
			}
		}
		bExists = true;
		if (oracleUdtDescriptor.m_connection != con)
		{
			oracleUdtDescriptor.m_connection = con;
		}
		if (oracleUdtDescriptor.m_conSignature != con.m_conSignature)
		{
			oracleUdtDescriptor.m_conSignature = con.m_conSignature;
		}
		return oracleUdtDescriptor;
	}

	internal unsafe void DescribeCustomType(object customTypeFactory)
	{
		if (customTypeFactory == null)
		{
			throw new InvalidOperationException();
		}
		GetMetaDataTable();
		if ((!(customTypeFactory is IOracleCustomTypeFactory) && !(customTypeFactory is IOracleArrayTypeFactory)) || m_customTypeFactory != null)
		{
			return;
		}
		lock (this)
		{
			if (m_customTypeFactory != null)
			{
				return;
			}
			if (OracleDbType == OracleDbType.Object)
			{
				m_UdtType = ((IOracleCustomTypeFactory)customTypeFactory).CreateObject().GetType();
				MemberInfo[] members = m_UdtType.GetMembers(BindingFlags.Instance | BindingFlags.Public);
				for (int i = 0; i < members.Length; i++)
				{
					if (members[i].MemberType != MemberTypes.Field && members[i].MemberType != MemberTypes.Property)
					{
						continue;
					}
					object[] customAttributes = members[i].GetCustomAttributes(typeof(OracleObjectMappingAttribute), inherit: true);
					if (customAttributes.Length <= 0)
					{
						continue;
					}
					int num = ((OracleObjectMappingAttribute)customAttributes[0]).m_attrIndex;
					if (num == -1)
					{
						string attrName = ((OracleObjectMappingAttribute)customAttributes[0]).m_attrName;
						if (attrName == null || attrName == "")
						{
							throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, m_UdtType.FullName + "::" + members[i].Name + "::OracleObjectMappingAttribute", attrName));
						}
						object obj = m_attrNameToIndex[attrName];
						if (obj == null)
						{
							throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, m_UdtType.FullName + "::" + members[i].Name + "::OracleObjectMappingAttribute", attrName));
						}
						num = (int)obj;
					}
					else if (num < 0 || num >= m_pOpoDscValCtx->NumAttrs)
					{
						throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, m_UdtType.FullName + "::" + members[i].Name + "::OracleObjectMappingAttribute", num.ToString()));
					}
					AttrMetaVal* ptr = m_pOpoDscValCtx->pAttrMetaVals + num;
					if (ptr->OraType == 108 && ptr->TypeCode != 58)
					{
						OracleUdtDescriptor objAttrUdtDescriptor = GetObjAttrUdtDescriptor(num);
						objAttrUdtDescriptor.GetMetaDataTable();
						if (ptr->TypeCode != 108 && (objAttrUdtDescriptor.m_pOpoDscValCtx->pAttrMetaVals->OraType != 108 || objAttrUdtDescriptor.m_pOpoDscValCtx->pAttrMetaVals->TypeCode != 122) && objAttrUdtDescriptor.m_customTypeFactory == null)
						{
							object factory = OracleUdt.GetFactory(objAttrUdtDescriptor);
							objAttrUdtDescriptor.DescribeCustomType(factory);
						}
						ptr->CustTypeCode = CustomTypeCode.Udt;
						ptr->pOpoDscValCtx = objAttrUdtDescriptor.m_pOpoDscValCtx;
						continue;
					}
					Type type = ((members[i].MemberType != MemberTypes.Field) ? ((PropertyInfo)members[i]).PropertyType : ((FieldInfo)members[i]).FieldType);
					if (type.IsGenericType && type.FullName.StartsWith("System.Nullable"))
					{
						ptr->IsNullable = 1;
						Type[] genericArguments = type.GetGenericArguments();
						type = genericArguments[0];
					}
					if (s_mapTypeNameToCustTypeCode.ContainsKey(type.FullName))
					{
						ptr->CustTypeCode = (CustomTypeCode)s_mapTypeNameToCustTypeCode[type.FullName];
					}
				}
			}
			else
			{
				if (!(customTypeFactory is IOracleCustomTypeFactory))
				{
					m_pOpoDscValCtx->bIsArrayType = 1;
				}
				AttrMetaVal* ptr2 = m_pOpoDscValCtx->pAttrMetaVals;
				if (ptr2->OraType == 108 && ptr2->TypeCode != 58)
				{
					OracleUdtDescriptor arrElemUdtDescriptor = GetArrElemUdtDescriptor();
					arrElemUdtDescriptor.GetMetaDataTable();
					if (ptr2->TypeCode != 108 && arrElemUdtDescriptor.m_pOpoDscValCtx->pAttrMetaVals->OraType != 108 && arrElemUdtDescriptor.m_customTypeFactory == null)
					{
						object factory2 = OracleUdt.GetFactory(arrElemUdtDescriptor);
						arrElemUdtDescriptor.DescribeCustomType(factory2);
					}
					ptr2->CustTypeCode = CustomTypeCode.Udt;
					ptr2->pOpoDscValCtx = arrElemUdtDescriptor.m_pOpoDscValCtx;
				}
				else
				{
					m_UdtType = ((IOracleArrayTypeFactory)customTypeFactory).CreateArray(0).GetType();
					Type type2 = m_UdtType.GetElementType();
					if (type2.IsGenericType && type2.FullName.StartsWith("System.Nullable"))
					{
						m_pOpoDscValCtx->pAttrMetaVals->IsNullable = 1;
						Type[] genericArguments2 = type2.GetGenericArguments();
						type2 = genericArguments2[0];
					}
					if (s_mapTypeNameToCustTypeCode.ContainsKey(type2.FullName))
					{
						m_pOpoDscValCtx->pAttrMetaVals->CustTypeCode = (CustomTypeCode)s_mapTypeNameToCustTypeCode[type2.FullName];
					}
				}
			}
			m_customTypeFactory = customTypeFactory;
		}
	}

	internal unsafe void CalcIndOffsets()
	{
		int num = 2;
		for (int i = 0; i < m_pOpoDscValCtx->NumAttrs; i++)
		{
			m_pOpoDscValCtx->pAttrMetaVals[i].IndOffset = num;
			if (m_pOpoDscValCtx->pAttrMetaVals[i].TypeCode == 108)
			{
				OracleUdtDescriptor objAttrUdtDescriptor = GetObjAttrUdtDescriptor(i);
				objAttrUdtDescriptor.GetMetaDataTable();
				num = ((objAttrUdtDescriptor.m_pOpoDscValCtx->bIsFinalType != 1) ? (num + 2) : (num + objAttrUdtDescriptor.m_pOpoDscValCtx->IndSize));
			}
			else
			{
				num += 2;
			}
		}
		m_pOpoDscValCtx->IndSize = num;
	}

	internal OracleUdtDescriptor GetArrElemUdtDescriptor()
	{
		GetMetaDataTable();
		OracleUdtDescriptor oracleUdtDescriptor = m_metaDataTable.Rows[0]["UdtDescriptor"] as OracleUdtDescriptor;
		if (oracleUdtDescriptor.m_connection != m_connection)
		{
			oracleUdtDescriptor.m_connection = m_connection;
		}
		if (oracleUdtDescriptor.m_conSignature != m_connection.m_conSignature)
		{
			oracleUdtDescriptor.m_conSignature = m_connection.m_conSignature;
		}
		return oracleUdtDescriptor;
	}

	internal OracleUdtDescriptor GetObjAttrUdtDescriptor(int attrIndex)
	{
		GetMetaDataTable();
		OracleUdtDescriptor oracleUdtDescriptor = m_metaDataTable.Rows[attrIndex]["UdtDescriptor"] as OracleUdtDescriptor;
		if (oracleUdtDescriptor.m_connection != m_connection)
		{
			oracleUdtDescriptor.m_connection = m_connection;
		}
		if (oracleUdtDescriptor.m_conSignature != m_connection.m_conSignature)
		{
			oracleUdtDescriptor.m_conSignature = m_connection.m_conSignature;
		}
		return oracleUdtDescriptor;
	}

	internal unsafe OciTypeCode GetUdtTypeCode()
	{
		int num = 0;
		if (m_pOpoDscValCtx->bDescribedUdt == 0)
		{
			if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
			}
			if (m_connection.m_conSignature != m_conSignature)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
			}
			try
			{
				num = OpsDsc.DescribeUdt(m_opsConCtx, m_opsErrCtx, m_opsDscCtx, m_pOpoDscValCtx);
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
					OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
				}
			}
			m_pOpoDscValCtx->bDescribedUdt = 1;
		}
		return (OciTypeCode)m_pOpoDscValCtx->TypeCode;
	}

	private unsafe OracleUdtDescriptor(OracleConnection con, string schemaName, string typeName)
	{
		int num = 0;
		int num2 = 0;
		m_connection = con;
		m_opoDscRefCtx = new OpoDscRefCtx();
		m_opoDscRefCtx.SchemaName = schemaName;
		m_opoDscRefCtx.TypeName = typeName;
		m_attrNameToIndex = new Hashtable();
		m_opsConCtx = m_connection.m_opoConCtx.opsConCtx;
		m_conSignature = m_connection.m_conSignature;
		try
		{
			num2 = OpsCon.AddRef(m_opsConCtx);
			if (num2 <= 1)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
			}
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
		try
		{
			m_pOpoDscValCtx = null;
			num = OpsDsc.GetTDO(m_opsConCtx, out m_opsErrCtx, ref m_opsDscCtx, out m_pOpoDscValCtx, m_opoDscRefCtx);
		}
		catch (Exception ex2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex2);
			}
			GC.SuppressFinalize(this);
			throw;
		}
		finally
		{
			if (num != 0)
			{
				try
				{
					OpsCon.RelRef(ref m_opsConCtx);
				}
				catch (Exception ex3)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex3);
					}
				}
				try
				{
					GC.SuppressFinalize(this);
					OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
				}
				finally
				{
					if (m_opsErrCtx != IntPtr.Zero)
					{
						try
						{
							OpsErr.FreeCtx(ref m_opsErrCtx);
						}
						catch (Exception ex4)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex4);
							}
						}
					}
				}
			}
		}
	}

	private unsafe OracleUdtDescriptor(OracleConnection con, IntPtr pTDO)
	{
		int num = 0;
		int num2 = 0;
		m_connection = con;
		m_opsDscCtx = pTDO;
		m_attrNameToIndex = new Hashtable();
		m_opsConCtx = m_connection.m_opoConCtx.opsConCtx;
		m_conSignature = m_connection.m_conSignature;
		try
		{
			num2 = OpsCon.AddRef(m_opsConCtx);
			if (num2 <= 1)
			{
				throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
			}
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			GC.SuppressFinalize(this);
			throw;
		}
		try
		{
			m_pOpoDscValCtx = null;
			num = OpsDsc.GetTDO(m_opsConCtx, out m_opsErrCtx, ref m_opsDscCtx, out m_pOpoDscValCtx, m_opoDscRefCtx);
		}
		catch (Exception ex2)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex2);
			}
			GC.SuppressFinalize(this);
			throw;
		}
		finally
		{
			if (num != 0)
			{
				try
				{
					OpsCon.RelRef(ref m_opsConCtx);
				}
				catch (Exception ex3)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex3);
					}
				}
				try
				{
					GC.SuppressFinalize(this);
					OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
				}
				finally
				{
					if (m_opsErrCtx != IntPtr.Zero)
					{
						try
						{
							OpsErr.FreeCtx(ref m_opsErrCtx);
						}
						catch (Exception ex4)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex4);
							}
						}
					}
				}
			}
		}
	}

	private unsafe static OracleUdtDescriptor GetOracleUdtDescriptor(OracleConnection con, string fqName, string schemaName, string typeName, bool bRefresh)
	{
		if (con.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (con.m_contextConnection)
		{
			throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.CLR_UDT_NOTSUPPORTED_CTX_CONN));
		}
		OracleUdtDescriptor oracleUdtDescriptor;
		if (con.m_opoConCtx.metaPool == 1)
		{
			if (bRefresh || (oracleUdtDescriptor = (OracleUdtDescriptor)con.m_opoConCtx.m_udtDescPoolerByName.Get(fqName)) == null || oracleUdtDescriptor.m_pOpoDscValCtx->bInvalidTDO == 1)
			{
				lock (s_lockObj)
				{
					if (bRefresh || (oracleUdtDescriptor = (OracleUdtDescriptor)con.m_opoConCtx.m_udtDescPoolerByName.Get(fqName)) == null || oracleUdtDescriptor.m_pOpoDscValCtx->bInvalidTDO == 1)
					{
						oracleUdtDescriptor = new OracleUdtDescriptor(con, schemaName, typeName);
						con.m_opoConCtx.m_udtDescPoolerByName.Put(fqName, oracleUdtDescriptor);
						if (oracleUdtDescriptor.m_udtTypeNameKey == null)
						{
							_ = oracleUdtDescriptor.UdtTypeName;
						}
						string udtTypeNameKey = oracleUdtDescriptor.m_udtTypeNameKey;
						if (udtTypeNameKey != fqName)
						{
							con.m_opoConCtx.m_udtDescPoolerByName.Put(udtTypeNameKey, oracleUdtDescriptor);
						}
						return oracleUdtDescriptor;
					}
				}
			}
		}
		else
		{
			oracleUdtDescriptor = new OracleUdtDescriptor(con, schemaName, typeName);
		}
		if (oracleUdtDescriptor.m_connection != con)
		{
			oracleUdtDescriptor.m_connection = con;
		}
		if (oracleUdtDescriptor.m_conSignature != con.m_conSignature)
		{
			oracleUdtDescriptor.m_conSignature = con.m_conSignature;
		}
		return oracleUdtDescriptor;
	}

	private unsafe void DescribeAllObjAttrs()
	{
		int num = 0;
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		try
		{
			num = OpsDsc.DescribeAllObjAttrs(m_opsConCtx, m_opsErrCtx, m_opsDscCtx, m_pOpoDscValCtx);
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
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
	}

	private unsafe void DescribeArrElem()
	{
		int num = 0;
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		try
		{
			num = OpsDsc.DescribeArrElem(m_opsConCtx, m_opsErrCtx, m_opsDscCtx, m_pOpoDscValCtx);
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
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
	}

	private unsafe void DescribeObjAttr(int attrIndex)
	{
		int num = 0;
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		try
		{
			num = OpsDsc.DescribeObjAttr(m_opsConCtx, m_opsErrCtx, m_opsDscCtx, m_pOpoDscValCtx, attrIndex);
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
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
	}

	private unsafe void GetArrTypeCode()
	{
		int num = 0;
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		try
		{
			num = OpsDsc.GetArrTypeCode(m_opsConCtx, m_opsErrCtx, m_opsDscCtx, m_pOpoDscValCtx);
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
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
	}

	private unsafe void GetUdtTypeName()
	{
		int num = 0;
		if (m_connection.m_opoConCtx.opsConCtx == IntPtr.Zero)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_CLOSED));
		}
		if (m_connection.m_conSignature != m_conSignature)
		{
			throw new InvalidOperationException(OpoErrResManager.GetErrorMesg(ErrRes.CON_REOPENED));
		}
		if (m_opoDscRefCtx == null)
		{
			m_opoDscRefCtx = new OpoDscRefCtx();
		}
		try
		{
			num = OpsDsc.GetUdtTypeName(m_opsConCtx, m_opsErrCtx, m_opsDscCtx, m_pOpoDscValCtx, ref m_opoDscRefCtx);
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
				OracleException.HandleError(num, m_connection, m_opsErrCtx, this);
			}
		}
	}

	private unsafe void MarshalAttrMetaRef(int attrIndex)
	{
		m_attrMetaRefs[attrIndex] = new AttrMetaRef();
		try
		{
			IntPtr zero = IntPtr.Zero;
			zero = (IntPtr)((byte*)(void*)m_pOpoDscValCtx->pAttrMetaRefs + (nint)s_attrMetaRefMarshalSize * (nint)attrIndex);
			Marshal.PtrToStructure(zero, (object)m_attrMetaRefs[attrIndex]);
			if (m_attrMetaRefs[attrIndex].AttrName != null)
			{
				m_attrNameToIndex[m_attrMetaRefs[attrIndex].AttrName] = attrIndex;
			}
		}
		catch
		{
			m_attrMetaRefs[attrIndex] = null;
			throw;
		}
	}

	unsafe ~OracleUdtDescriptor()
	{
		try
		{
			OpsDsc.Dispose(m_opsConCtx, m_opsErrCtx, m_opsDscCtx, m_pOpoDscValCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
		}
		m_connection = null;
		m_opoDscRefCtx = null;
		m_metaDataTable = null;
		m_attrMetaRefs = null;
		m_attrNameToIndex = null;
	}

	static OracleUdtDescriptor()
	{
		s_xmlTypeName = "SYS.XMLTYPE";
		s_lockObj = new object();
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
		s_attrMetaRefMarshalSize = Marshal.SizeOf(typeof(AttrMetaRef));
		s_mapTypeNameToCustTypeCode = new Hashtable();
		s_mapTypeNameToCustTypeCode["System.Byte"] = CustomTypeCode.Byte;
		s_mapTypeNameToCustTypeCode["System.Byte[]"] = CustomTypeCode.Bytes;
		s_mapTypeNameToCustTypeCode["System.Char[]"] = CustomTypeCode.Chars;
		s_mapTypeNameToCustTypeCode["System.DateTime"] = CustomTypeCode.DateTime;
		s_mapTypeNameToCustTypeCode["System.Decimal"] = CustomTypeCode.Decimal;
		s_mapTypeNameToCustTypeCode["System.Double"] = CustomTypeCode.Double;
		s_mapTypeNameToCustTypeCode["System.Int16"] = CustomTypeCode.Int16;
		s_mapTypeNameToCustTypeCode["System.Int32"] = CustomTypeCode.Int32;
		s_mapTypeNameToCustTypeCode["System.Int64"] = CustomTypeCode.Int64;
		s_mapTypeNameToCustTypeCode["System.Single"] = CustomTypeCode.Single;
		s_mapTypeNameToCustTypeCode["System.String"] = CustomTypeCode.String;
		s_mapTypeNameToCustTypeCode["System.TimeSpan"] = CustomTypeCode.TimeSpan;
		s_mapTypeNameToCustTypeCode["Oracle.DataAccess.Types.OracleBFile"] = CustomTypeCode.OracleBFile;
		s_mapTypeNameToCustTypeCode["Oracle.DataAccess.Types.OracleBinary"] = CustomTypeCode.OracleBinary;
		s_mapTypeNameToCustTypeCode["Oracle.DataAccess.Types.OracleBlob"] = CustomTypeCode.OracleBlob;
		s_mapTypeNameToCustTypeCode["Oracle.DataAccess.Types.OracleClob"] = CustomTypeCode.OracleClob;
		s_mapTypeNameToCustTypeCode["Oracle.DataAccess.Types.OracleDate"] = CustomTypeCode.OracleDate;
		s_mapTypeNameToCustTypeCode["Oracle.DataAccess.Types.OracleDecimal"] = CustomTypeCode.OracleDecimal;
		s_mapTypeNameToCustTypeCode["Oracle.DataAccess.Types.OracleIntervalDS"] = CustomTypeCode.OracleIntervalDS;
		s_mapTypeNameToCustTypeCode["Oracle.DataAccess.Types.OracleIntervalYM"] = CustomTypeCode.OracleIntervalYM;
		s_mapTypeNameToCustTypeCode["Oracle.DataAccess.Types.OracleRef"] = CustomTypeCode.OracleRef;
		s_mapTypeNameToCustTypeCode["Oracle.DataAccess.Types.OracleString"] = CustomTypeCode.OracleString;
		s_mapTypeNameToCustTypeCode["Oracle.DataAccess.Types.OracleTimeStamp"] = CustomTypeCode.OracleTimeStamp;
		s_mapTypeNameToCustTypeCode["Oracle.DataAccess.Types.OracleTimeStampLTZ"] = CustomTypeCode.OracleTimeStampLTZ;
		s_mapTypeNameToCustTypeCode["Oracle.DataAccess.Types.OracleTimeStampTZ"] = CustomTypeCode.OracleTimeStampTZ;
		s_mapTypeNameToCustTypeCode["Oracle.DataAccess.Types.OracleXmlType"] = CustomTypeCode.OracleXmlType;
		s_mapCustTypeCodeToTypeName = new Hashtable();
		s_mapCustTypeCodeToTypeName[CustomTypeCode.Byte] = "System.Byte";
		s_mapCustTypeCodeToTypeName[CustomTypeCode.Bytes] = "System.Byte[]";
		s_mapCustTypeCodeToTypeName[CustomTypeCode.Chars] = "System.Char[]";
		s_mapCustTypeCodeToTypeName[CustomTypeCode.DateTime] = "System.DateTime";
		s_mapCustTypeCodeToTypeName[CustomTypeCode.Decimal] = "System.Decimal";
		s_mapCustTypeCodeToTypeName[CustomTypeCode.Double] = "System.Double";
		s_mapCustTypeCodeToTypeName[CustomTypeCode.Int16] = "System.Int16";
		s_mapCustTypeCodeToTypeName[CustomTypeCode.Int32] = "System.Int32";
		s_mapCustTypeCodeToTypeName[CustomTypeCode.Int64] = "System.Int64";
		s_mapCustTypeCodeToTypeName[CustomTypeCode.Single] = "System.Single";
		s_mapCustTypeCodeToTypeName[CustomTypeCode.String] = "System.String";
		s_mapCustTypeCodeToTypeName[CustomTypeCode.TimeSpan] = "System.TimeSpan";
		s_mapCustTypeCodeToTypeName[CustomTypeCode.OracleBFile] = "Oracle.DataAccess.Types.OracleBFile";
		s_mapCustTypeCodeToTypeName[CustomTypeCode.OracleBinary] = "Oracle.DataAccess.Types.OracleBinary";
		s_mapCustTypeCodeToTypeName[CustomTypeCode.OracleBlob] = "Oracle.DataAccess.Types.OracleBlob";
		s_mapCustTypeCodeToTypeName[CustomTypeCode.OracleClob] = "Oracle.DataAccess.Types.OracleClob";
		s_mapCustTypeCodeToTypeName[CustomTypeCode.OracleDate] = "Oracle.DataAccess.Types.OracleDate";
		s_mapCustTypeCodeToTypeName[CustomTypeCode.OracleDecimal] = "Oracle.DataAccess.Types.OracleDecimal";
		s_mapCustTypeCodeToTypeName[CustomTypeCode.OracleIntervalDS] = "Oracle.DataAccess.Types.OracleIntervalDS";
		s_mapCustTypeCodeToTypeName[CustomTypeCode.OracleIntervalYM] = "Oracle.DataAccess.Types.OracleIntervalYM";
		s_mapCustTypeCodeToTypeName[CustomTypeCode.OracleRef] = "Oracle.DataAccess.Types.OracleRef";
		s_mapCustTypeCodeToTypeName[CustomTypeCode.OracleString] = "Oracle.DataAccess.Types.OracleString";
		s_mapCustTypeCodeToTypeName[CustomTypeCode.OracleTimeStamp] = "Oracle.DataAccess.Types.OracleTimeStamp";
		s_mapCustTypeCodeToTypeName[CustomTypeCode.OracleTimeStampLTZ] = "Oracle.DataAccess.Types.OracleTimeStampLTZ";
		s_mapCustTypeCodeToTypeName[CustomTypeCode.OracleTimeStampTZ] = "Oracle.DataAccess.Types.OracleTimeStampTZ";
		s_mapCustTypeCodeToTypeName[CustomTypeCode.OracleXmlType] = "Oracle.DataAccess.Types.OracleXmlType";
	}
}
