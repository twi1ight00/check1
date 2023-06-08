using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Xml;
using Microsoft.Win32;

namespace Oracle.DataAccess.Client;

internal class RegAndConfigRdr
{
	internal static NameValueCollection m_configSection;

	internal static RegistryKey odpNetKey;

	internal static bool s_bFromConfigOraOpsDllPath;

	internal static bool s_bFromConfigTraceLevel;

	internal static bool s_bFromConfigTraceOption;

	internal static bool s_bFromConfigUdtCacheSize;

	internal static bool s_bFromConfigStmtCacheSize;

	internal static bool s_bFromConfigCheckConStatus;

	internal static bool s_bFromConfigDynamicEnlist;

	internal static bool s_bFromConfigFetchSize;

	internal static bool s_bFromConfigOciEvents;

	internal static bool s_bFromConfigStmtCacheWithUdts;

	internal static bool s_bFromConfigPSPE;

	internal static bool s_bFromConfigMetadataPooling;

	internal static bool s_bFromConfigDBNotificationPort;

	internal static bool s_bFromConfigPerfCounters;

	internal static bool s_bFromConfigThreadPoolMaxSize;

	internal static bool s_bFromConfigDbNtfnRegInterval;

	internal static bool s_bFromConfigDemandOrclPermission;

	internal static bool s_bFromConfigTraceFileName;

	internal static bool s_bFromConfigSelfTuning;

	internal static bool s_bFromConfigMaxStatementCacheSize;

	internal static bool s_bFromConfigAppEdition;

	internal static bool s_bFromConfigMetaDataXml;

	internal static bool s_bFromConfigFetchArrayPooling;

	internal static bool s_bFromConfigRevertBUErrHandling;

	internal static bool s_bFromConfigCPThreadPrioritization;

	internal static bool s_bFromConfigInitialLOBFetchSize;

	internal static bool s_bFromConfigInitialLONGFetchSize;

	internal static Hashtable s_edmMapping;

	internal static string[] s_edmTypes;

	internal static int[] s_maxPrecision;

	internal static string s_strReg;

	internal static string s_strCfg;

	internal static string s_strVer;

	internal static string s_strTrm;

	internal static Hashtable s_storedProcInformation;

	internal static Hashtable s_odtConfigNamesToRefCursorInfo;

	[RegistryPermission(SecurityAction.Assert, Unrestricted = true)]
	[ConfigurationPermission(SecurityAction.Assert, Unrestricted = true)]
	static RegAndConfigRdr()
	{
		odpNetKey = null;
		s_bFromConfigOraOpsDllPath = false;
		s_bFromConfigTraceLevel = false;
		s_bFromConfigTraceOption = false;
		s_bFromConfigUdtCacheSize = false;
		s_bFromConfigStmtCacheSize = false;
		s_bFromConfigCheckConStatus = false;
		s_bFromConfigDynamicEnlist = false;
		s_bFromConfigFetchSize = false;
		s_bFromConfigOciEvents = false;
		s_bFromConfigStmtCacheWithUdts = false;
		s_bFromConfigPSPE = false;
		s_bFromConfigMetadataPooling = false;
		s_bFromConfigDBNotificationPort = false;
		s_bFromConfigPerfCounters = false;
		s_bFromConfigThreadPoolMaxSize = false;
		s_bFromConfigDbNtfnRegInterval = false;
		s_bFromConfigDemandOrclPermission = false;
		s_bFromConfigTraceFileName = false;
		s_bFromConfigSelfTuning = false;
		s_bFromConfigMaxStatementCacheSize = false;
		s_bFromConfigAppEdition = false;
		s_bFromConfigMetaDataXml = false;
		s_bFromConfigFetchArrayPooling = false;
		s_bFromConfigRevertBUErrHandling = false;
		s_bFromConfigCPThreadPrioritization = false;
		s_bFromConfigInitialLOBFetchSize = false;
		s_bFromConfigInitialLONGFetchSize = false;
		s_edmMapping = new Hashtable();
		s_edmTypes = new string[5] { "BOOL", "BYTE", "INT16", "INT32", "INT64" };
		s_maxPrecision = new int[5] { -1, -1, 5, 10, 19 };
		s_strReg = " (REGISTRY)";
		s_strCfg = " (CONFIG)  ";
		s_strVer = " (VERSION) ";
		s_strTrm = ")\n";
		s_storedProcInformation = new Hashtable();
		s_odtConfigNamesToRefCursorInfo = new Hashtable();
		m_configSection = ConfigurationManager.GetSection("oracle.dataaccess.client") as NameValueCollection;
		RegistryKey localMachine = Registry.LocalMachine;
		RegistryKey registryKey = localMachine.OpenSubKey("SOFTWARE\\Oracle\\ODP.NET");
		if (registryKey == null)
		{
			return;
		}
		string[] subKeyNames = registryKey.GetSubKeyNames();
		string assemblyVersion = OracleInit.GetAssemblyVersion();
		for (int i = 0; i < subKeyNames.Length; i++)
		{
			if (assemblyVersion == subKeyNames[i])
			{
				odpNetKey = registryKey.OpenSubKey(assemblyVersion);
			}
		}
		RetrieveInfoFromConfig(m_configSection, ref s_storedProcInformation, bIsCallFromODT: false);
		ValidateEdmMapping();
	}

	private static void ValidateEdmMapping()
	{
		int num = -1;
		for (int i = 0; i < s_edmTypes.Length; i++)
		{
			int num2 = GetMaxPrecision(s_edmTypes[i]);
			if (num2 == -1)
			{
				num2 = s_maxPrecision[i];
			}
			if (num2 <= 0)
			{
				continue;
			}
			if (num > num2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (ERROR) (EDMMAPPING) " + s_edmTypes[i] + " is invalid\n");
					OraTrace.Trace(1u, " (ERROR) (EDMMAPPING) " + s_edmTypes[i] + " has a max precision that is lower than required\n");
				}
				throw new ConfigurationErrorsException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, s_edmTypes[i]));
			}
			num = num2;
		}
	}

	internal static int GetMaxPrecision(string edmType)
	{
		object obj = s_edmMapping[edmType.Trim().ToUpper()];
		if (obj == null)
		{
			return -1;
		}
		return (int)obj;
	}

	private static void RetrieveEdmMappingInfoFromConfig(string key, string value)
	{
		int result = -1;
		string text = key.Trim().ToUpper();
		string text2 = value.Trim().ToUpper();
		bool flag = false;
		int num = -1;
		int num2 = -1;
		int num3 = -1;
		if (s_edmTypes.Contains(text))
		{
			num = text2.IndexOf("NUMBER");
			if (num != -1)
			{
				num2 = text2.IndexOf('(', num);
				if (num2 != -1)
				{
					num3 = text2.IndexOf(',', num2);
					if (num3 == -1)
					{
						num3 = text2.IndexOf(')', num2);
					}
					if (num3 != -1)
					{
						flag = int.TryParse(text2.Substring(num2 + 1, num3 - (num2 + 1)).Trim(), out result);
						if (result <= 0)
						{
							flag = false;
						}
					}
				}
			}
		}
		if (!flag)
		{
			Console.WriteLine("Error : [{0},{1}]", key, result);
			if (num == -1)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (ERROR) (EDMMAPPING) " + key + " is invalid\n");
				}
				throw new ConfigurationErrorsException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, key));
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ERROR) (EDMMAPPING) " + value + " is invalid\n");
			}
			throw new ConfigurationErrorsException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, value));
		}
		s_edmMapping[text] = result;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EDMMAPPING) Adding [" + text + "," + result + "]\n");
		}
	}

	private static void RetrieveInfoFromConfig(NameValueCollection nvc, ref Hashtable schemaTable, bool bIsCallFromODT)
	{
		if (nvc == null)
		{
			return;
		}
		IEnumerator enumerator = nvc.GetEnumerator();
		while (enumerator.MoveNext())
		{
			string text = nvc[(string)enumerator.Current].Trim();
			if (text.ToUpper().StartsWith("IMPLICITREFCURSOR"))
			{
				string text2 = text.Split(' ')[1].Trim();
				int startIndex = text.IndexOf(text2);
				string text3 = text.Substring(startIndex);
				string refCursorKey = (string)enumerator.Current;
				if (text2.ToLower().StartsWith("bindinfo"))
				{
					AddBindInfoForRefCursor(refCursorKey, text3, ref schemaTable);
					continue;
				}
				if (!text2.ToLower().StartsWith("metadata"))
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.Trace(1u, " (ERROR) (REFCURSOR) " + text + " is invalid\n");
					}
					throw new ConfigurationErrorsException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, text));
				}
				AddMetadataForRefCursor(refCursorKey, text3, ref schemaTable);
			}
			else if (text.ToUpper().StartsWith("EDMMAPPING"))
			{
				string text4 = enumerator.Current.ToString();
				RetrieveEdmMappingInfoFromConfig(text4, nvc[text4]);
			}
		}
	}

	private static void AddBindInfoForRefCursor(string refCursorKey, string infoForBind, ref Hashtable schematable)
	{
		bool flag = false;
		int num = infoForBind.IndexOf("'");
		int num2 = infoForBind.LastIndexOf("'");
		if (num != -1 && num2 != -1)
		{
			string text = infoForBind.Substring(num + 1, num2 - (num + 1)).Trim();
			RefCursorInfo refCursorInfo = new RefCursorInfo();
			string text2 = refCursorKey.Substring(refCursorKey.LastIndexOf(".") + 1).Trim();
			if (!int.TryParse(text2, out refCursorInfo.position))
			{
				refCursorInfo.name = text2;
				refCursorInfo.position = -1;
				flag = true;
			}
			string[] array = text.Split('=');
			if (array.Length != 2)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (ERROR) (REFCURSOR) " + refCursorKey + " : BindInfo is invalid\n");
				}
				throw new ConfigurationErrorsException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, refCursorKey + " BindInfo"));
			}
			string text3;
			if ((text3 = array[0].Trim().ToLower()) != null && text3 == "mode")
			{
				string value = array[1].Trim();
				if (Enum.IsDefined(typeof(ParameterDirection), value))
				{
					refCursorInfo.mode = (ParameterDirection)Enum.Parse(typeof(ParameterDirection), value, ignoreCase: true);
					if (refCursorInfo.mode == ParameterDirection.Input)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.Trace(1u, " (ERROR) (REFCURSOR) " + refCursorKey + " : ParameterDirection is invalid\n");
						}
						throw new ConfigurationErrorsException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, "ParameterDirection"));
					}
					string[] array2 = refCursorKey.Split('.');
					if (array2[array2.Length - 2].Trim() != "RefCursor")
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.Trace(1u, " (ERROR) (REFCURSOR) " + refCursorKey + " : BindInfo is invalid\n");
						}
						throw new ConfigurationErrorsException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, refCursorKey + " BindInfo"));
					}
					StringBuilder stringBuilder = new StringBuilder();
					for (int i = 0; i < array2.Length - 2; i++)
					{
						stringBuilder.Append(array2[i] + ".");
					}
					stringBuilder.Remove(stringBuilder.Length - 1, 1);
					string storedProcKey = stringBuilder.ToString().Trim();
					GetKeyInProperCase(ref storedProcKey);
					if (!schematable.Contains(storedProcKey))
					{
						StoredProcedureInfo storedProcedureInfo = new StoredProcedureInfo();
						storedProcedureInfo.refCursors.Add(refCursorInfo);
						schematable.Add(storedProcKey, storedProcedureInfo);
						return;
					}
					StoredProcedureInfo storedProcedureInfo2 = (StoredProcedureInfo)schematable[storedProcKey];
					int num3 = 0;
					foreach (RefCursorInfo refCursor in storedProcedureInfo2.refCursors)
					{
						if (flag)
						{
							if (refCursor.name.Length > 0 && refCursor.name.Equals(refCursorInfo.name))
							{
								storedProcedureInfo2.refCursors.RemoveAt(num3);
								break;
							}
						}
						else if (refCursor.position >= refCursorInfo.position)
						{
							if (refCursor.position == refCursorInfo.position)
							{
								storedProcedureInfo2.refCursors.RemoveAt(num3);
							}
							storedProcedureInfo2.refCursors.Insert(num3, refCursorInfo);
							return;
						}
						num3++;
					}
					storedProcedureInfo2.refCursors.Add(refCursorInfo);
					return;
				}
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (ERROR) (REFCURSOR) " + refCursorKey + " : Mode is invalid\n");
				}
				throw new ConfigurationErrorsException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, refCursorKey + " Mode"));
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ERROR) (REFCURSOR) " + refCursorKey + " : BindInfo is invalid\n");
			}
			throw new ConfigurationErrorsException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, refCursorKey + " BindInfo"));
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ERROR) (REFCURSOR) " + refCursorKey + " : BindInfo is invalid\n");
		}
		throw new ConfigurationErrorsException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, refCursorKey + " BindInfo"));
	}

	private static void GetKeyInProperCase(ref string storedProcKey)
	{
		string[] array = storedProcKey.Split('.');
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			if (i != 0)
			{
				stringBuilder.Append(".");
			}
			string text = array[i];
			if (text[0] == '"' && text[text.Length - 1] == '"')
			{
				stringBuilder.Append(text.Trim('"', ' '));
			}
			else
			{
				stringBuilder.Append(text.ToUpper());
			}
		}
		storedProcKey = stringBuilder.ToString();
	}

	private static void AddMetadataForRefCursor(string refCursorKey, string metadataInfo, ref Hashtable schemaTable)
	{
		int num = metadataInfo.IndexOf("'");
		int num2 = metadataInfo.LastIndexOf("'");
		if (num == -1 || num2 == -1)
		{
			return;
		}
		string text = metadataInfo.Substring(num + 1, num2 - (num + 1)).Trim();
		string[] array = text.Split(';');
		string[] array2 = refCursorKey.Split('.');
		StringBuilder stringBuilder = new StringBuilder();
		int num3 = 0;
		string[] array3 = array2;
		foreach (string text2 in array3)
		{
			if (text2.Trim().Equals("RefCursorMetaData"))
			{
				break;
			}
			num3++;
			stringBuilder.Append(text2 + ".");
		}
		if (num3 == array2.Length)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ERROR) (REFCURSOR) " + refCursorKey + " : Metadata is invalid\n");
			}
			throw new ConfigurationErrorsException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, refCursorKey + " Metadata"));
		}
		stringBuilder.Remove(stringBuilder.Length - 1, 1);
		string text3 = array2[num3 + 1].Trim();
		int num4 = -1;
		try
		{
			num4 = int.Parse(array2[array2.Length - 1]);
		}
		catch (FormatException ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ERROR) (REFCURSOR) " + refCursorKey + " : Column Ordinal is invalid\n");
			}
			throw new ConfigurationErrorsException(ex.Message);
		}
		bool flag = false;
		int result = -1;
		if (int.TryParse(text3, out result))
		{
			flag = true;
		}
		string storedProcKey = stringBuilder.ToString().Trim();
		GetKeyInProperCase(ref storedProcKey);
		RefCursorInfo refCursorInfo = null;
		StoredProcedureInfo storedProcedureInfo = (StoredProcedureInfo)schemaTable[storedProcKey];
		if (storedProcedureInfo != null)
		{
			foreach (RefCursorInfo refCursor in storedProcedureInfo.refCursors)
			{
				if (flag)
				{
					if (refCursor.position == result)
					{
						refCursorInfo = refCursor;
					}
				}
				else if (refCursor.name.ToLower().Equals(text3.ToLower()))
				{
					refCursorInfo = refCursor;
				}
			}
		}
		if (refCursorInfo == null)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ERROR) (REFCURSOR) " + refCursorKey + " : Metadata is invalid\n");
			}
			throw new ConfigurationErrorsException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, refCursorKey + " Metadata"));
		}
		DataRow dataRow = refCursorInfo.columnInfo.NewRow();
		dataRow["ColumnOrdinal"] = num4;
		string[] array4 = null;
		string[] array5 = array;
		foreach (string text4 in array5)
		{
			try
			{
				array4 = text4.Split('=');
				switch (array4[0].Trim().ToUpper())
				{
				case "COLUMNNAME":
					dataRow["ColumnName"] = array4[1].Trim();
					continue;
				case "COLUMNSIZE":
					dataRow["ColumnSize"] = int.Parse(array4[1].Trim());
					continue;
				case "NUMERICPRECISION":
					dataRow["NumericPrecision"] = int.Parse(array4[1].Trim());
					continue;
				case "NUMERICSCALE":
					dataRow["NumericScale"] = int.Parse(array4[1].Trim());
					continue;
				case "ISUNIQUE":
					dataRow["IsUnique"] = bool.Parse(array4[1].Trim());
					continue;
				case "ISKEY":
					dataRow["IsKey"] = bool.Parse(array4[1].Trim());
					if ((bool)dataRow["IsKey"])
					{
						refCursorInfo.isPrimaryKeyPresent = true;
					}
					continue;
				case "ISROWID":
					dataRow["IsRowID"] = bool.Parse(array4[1].Trim());
					continue;
				case "BASECOLUMNNAME":
					dataRow["BaseColumnName"] = array4[1].Trim();
					continue;
				case "BASESCHEMANAME":
					dataRow["BaseSchemaName"] = array4[1].Trim();
					continue;
				case "BASETABLENAME":
					dataRow["BaseTableName"] = array4[1].Trim();
					continue;
				case "DATATYPE":
					dataRow["DataType"] = Type.GetType(array4[1].Trim());
					continue;
				case "PROVIDERTYPE":
					dataRow["ProviderType"] = (OracleDbType)Enum.Parse(typeof(OracleDbType), array4[1].Trim().Split('.')[array4[1].Trim().Split('.').Length - 1], ignoreCase: true);
					continue;
				case "ALLOWDBNULL":
					dataRow["AllowDBNull"] = bool.Parse(array4[1].Trim());
					continue;
				case "ISALIASED":
					dataRow["IsAliased"] = bool.Parse(array4[1].Trim());
					continue;
				case "ISBYTESEMANTIC":
					dataRow["IsByteSemantic"] = bool.Parse(array4[1].Trim());
					continue;
				case "ISEXPRESSION":
					dataRow["IsExpression"] = bool.Parse(array4[1].Trim());
					continue;
				case "ISHIDDEN":
					dataRow["IsHidden"] = bool.Parse(array4[1].Trim());
					continue;
				case "ISREADONLY":
					dataRow["IsReadOnly"] = bool.Parse(array4[1].Trim());
					continue;
				case "ISLONG":
					dataRow["IsLong"] = bool.Parse(array4[1].Trim());
					continue;
				case "UDTTYPENAME":
					dataRow["UdtTypeName"] = array4[1].Trim();
					continue;
				case "NATIVEDATATYPE":
					dataRow["NativeDataType"] = array4[1].Trim();
					continue;
				case "PROVIDERDBTYPE":
					dataRow["ProviderDBType"] = (DbType)Enum.Parse(typeof(DbType), array4[1].Trim().Split('.')[array4[1].Trim().Split('.').Length - 1], ignoreCase: true);
					continue;
				case "OBJECTNAME":
					dataRow["ObjectName"] = array4[1].Trim();
					continue;
				}
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (ERROR) (REFCURSOR) " + refCursorKey + " : " + array4[0] + " is invalid\n");
				}
				throw new ConfigurationErrorsException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, refCursorKey + " " + array4[0]));
			}
			catch (ConfigurationErrorsException)
			{
				throw;
			}
			catch (Exception)
			{
				if (OraTrace.m_TraceLevel != 0)
				{
					OraTrace.Trace(1u, " (ERROR) (REFCURSOR) " + refCursorKey + " : " + array4[0].Trim() + "=" + array4[1].Trim() + " is invalid\n");
				}
				throw new ConfigurationErrorsException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, refCursorKey + " " + array4[0].Trim() + "=" + array4[1].Trim()));
			}
		}
		if (refCursorInfo.columnInfo.Rows.Count > num4)
		{
			refCursorInfo.columnInfo.Rows.InsertAt(dataRow, num4);
		}
		else
		{
			refCursorInfo.columnInfo.Rows.Add(dataRow);
		}
		refCursorInfo.columnInfo.AcceptChanges();
	}

	internal static StoredProcedureInfo GetStoredProcInfo(string commandText)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) (REFCURSOR) GetRefCursorInfo(" + commandText + ")\n");
		}
		if (commandText == null || commandText.Length == 0)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  (REFCURSOR) GetRefCursorInfo(" + commandText + ") : no match\n");
			}
			return null;
		}
		StoredProcedureInfo storedProcedureInfo = null;
		string storedProcKey = null;
		if (s_storedProcInformation.Count > 0)
		{
			storedProcedureInfo = (StoredProcedureInfo)s_storedProcInformation[commandText.Trim()];
			if (storedProcedureInfo == null)
			{
				storedProcKey = commandText;
				GetKeyInProperCase(ref storedProcKey);
				storedProcedureInfo = (StoredProcedureInfo)s_storedProcInformation[storedProcKey];
			}
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			if (storedProcedureInfo == null)
			{
				OraTrace.Trace(1u, " (EXIT)  (REFCURSOR) GetRefCursorInfo(" + commandText + ") : no match\n");
			}
			else if (storedProcKey == null)
			{
				OraTrace.Trace(1u, " (EXIT)  (REFCURSOR) GetRefCursorInfo(" + commandText + ") : match found!\n");
			}
			else
			{
				OraTrace.Trace(1u, " (EXIT)  (REFCURSOR) GetRefCursorInfo(" + storedProcKey + ") : match found!\n");
			}
		}
		return storedProcedureInfo;
	}

	internal static StoredProcedureInfo GetStoredProcInfo(Hashtable storedProceduresList, string schemaName, string storedProcName)
	{
		string empty = string.Empty;
		StoredProcedureInfo storedProcedureInfo = null;
		if (storedProcName == null || storedProcName.Length == 0)
		{
			return null;
		}
		storedProcName = ((storedProcName[0] != '"' || storedProcName[storedProcName.Length - 1] != '"') ? storedProcName.Trim().ToUpper() : storedProcName.Trim('"', ' '));
		if (schemaName != null && schemaName.Length > 0)
		{
			schemaName = ((schemaName[0] != '"' || schemaName[schemaName.Length - 1] != '"') ? schemaName.Trim().ToUpper() : schemaName.Trim('"', ' '));
			empty = schemaName + "." + storedProcName;
			storedProcedureInfo = (StoredProcedureInfo)storedProceduresList[empty];
		}
		if (storedProcedureInfo == null)
		{
			storedProcedureInfo = (StoredProcedureInfo)storedProceduresList[storedProcName];
		}
		return storedProcedureInfo;
	}

	public static DataTable GetRefCursorInfoForSP(string configFileAlongWithFullPath, string schemaName, string storedProcName)
	{
		if (storedProcName == null || configFileAlongWithFullPath == null)
		{
			return null;
		}
		if (OraTrace.m_TraceLevel != 0 && storedProcName.Length != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) (REFCURSOR) GetRefCursorInfoForSP(" + schemaName + "." + storedProcName + ")\n");
		}
		if (storedProcName.Length != 0 && OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  (REFCURSOR) GetRefCursorInfoForSP(" + schemaName + "." + storedProcName + ") : no match\n");
		}
		string key = configFileAlongWithFullPath.Trim();
		Hashtable schemaTable = new Hashtable();
		bool flag = s_odtConfigNamesToRefCursorInfo.Contains(key);
		DateTime lastWriteTimeUtc = File.GetLastWriteTimeUtc(configFileAlongWithFullPath);
		if (flag)
		{
			ODTConfigFileInfoForRefCursors oDTConfigFileInfoForRefCursors = (ODTConfigFileInfoForRefCursors)s_odtConfigNamesToRefCursorInfo[key];
			if (oDTConfigFileInfoForRefCursors.lastModifiedTime != lastWriteTimeUtc)
			{
				flag = false;
			}
		}
		if (!flag)
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlTextReader xmlTextReader = new XmlTextReader(configFileAlongWithFullPath);
			xmlDocument.Load(xmlTextReader);
			XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("oracle.dataaccess.client");
			if (elementsByTagName.Count == 0)
			{
				xmlTextReader.Close();
				if (OraTrace.m_TraceLevel != 0 && storedProcName.Length != 0)
				{
					OraTrace.Trace(1u, " (EXIT)  (REFCURSOR) GetRefCursorInfoForSP(" + schemaName + "." + storedProcName + ") : no match\n");
				}
				return null;
			}
			NameValueCollection nameValueCollectionFromNodeList = GetNameValueCollectionFromNodeList(elementsByTagName[0]);
			s_edmMapping.Clear();
			RetrieveInfoFromConfig(nameValueCollectionFromNodeList, ref schemaTable, bIsCallFromODT: true);
			ODTConfigFileInfoForRefCursors oDTConfigFileInfoForRefCursors2 = new ODTConfigFileInfoForRefCursors();
			oDTConfigFileInfoForRefCursors2.lastModifiedTime = lastWriteTimeUtc;
			oDTConfigFileInfoForRefCursors2.storedProcList = schemaTable;
			s_odtConfigNamesToRefCursorInfo[key] = oDTConfigFileInfoForRefCursors2;
			xmlTextReader.Close();
			TraceRefCursorInfoInAppConfig(configFileAlongWithFullPath);
		}
		else
		{
			ODTConfigFileInfoForRefCursors oDTConfigFileInfoForRefCursors3 = (ODTConfigFileInfoForRefCursors)s_odtConfigNamesToRefCursorInfo[key];
			schemaTable = oDTConfigFileInfoForRefCursors3.storedProcList;
		}
		StoredProcedureInfo storedProcedureInfo = (StoredProcedureInfo)schemaTable[schemaName + "." + storedProcName];
		if (storedProcedureInfo != null && storedProcedureInfo.refCursors.Count != 0 && OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  (REFCURSOR) GetRefCursorInfoForSP(" + schemaName + "." + storedProcName + ") : no match\n");
		}
		if (OraTrace.m_TraceLevel != 0 && storedProcName.Length != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  (REFCURSOR) GetRefCursorInfoForSP(" + schemaName + "." + storedProcName + ") : match found!\n");
		}
		if (storedProcedureInfo != null && storedProcedureInfo.refCursors.Count != 0)
		{
			return ((RefCursorInfo)storedProcedureInfo.refCursors[0]).columnInfo.Copy();
		}
		return null;
	}

	private static NameValueCollection GetNameValueCollectionFromNodeList(XmlNode node)
	{
		NameValueCollection nameValueCollection = new NameValueCollection();
		ArrayList arrayList = new ArrayList();
		if (node.FirstChild == null)
		{
			return null;
		}
		XmlNode xmlNode = node;
		if (xmlNode.FirstChild.Name != "add")
		{
			xmlNode = xmlNode.FirstChild;
			if (xmlNode.FirstChild == null)
			{
				return null;
			}
		}
		foreach (XmlNode childNode in xmlNode.ChildNodes)
		{
			if (childNode.Name.ToLower() == "add")
			{
				string requiredAttribute = GetRequiredAttribute(childNode, "name");
				string requiredAttribute2 = GetRequiredAttribute(childNode, "value");
				if (!arrayList.Contains(requiredAttribute))
				{
					nameValueCollection[requiredAttribute] = requiredAttribute2;
					arrayList.Add(requiredAttribute);
				}
			}
		}
		return nameValueCollection;
	}

	internal static string GetRequiredAttribute(XmlNode node, string name)
	{
		if (!(node.Attributes.RemoveNamedItem(name) is XmlAttribute xmlAttribute) || xmlAttribute.Value == string.Empty)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ERROR) (REFCURSOR) " + name + " is invalid\n");
			}
			throw new ConfigurationErrorsException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_INVALID_VALUE, name));
		}
		return xmlAttribute.Value;
	}

	[RegistryPermission(SecurityAction.Assert, Unrestricted = true)]
	[ConfigurationPermission(SecurityAction.Assert, Unrestricted = true)]
	public static string RetrieveStringValue(string entryToBeSearched, object defaultValue, ref bool bFromConfigFile)
	{
		string text = null;
		try
		{
			if (m_configSection != null && m_configSection[entryToBeSearched] != null)
			{
				string text2 = m_configSection[entryToBeSearched];
				if (text2 != null)
				{
					string[] array = text2.Split(',');
					text = ((array.Length <= 1) ? array[0] : array[array.Length - 1]);
				}
				bFromConfigFile = true;
			}
			else if (odpNetKey != null)
			{
				text = odpNetKey.GetValue(entryToBeSearched) as string;
			}
		}
		catch
		{
		}
		if ((text == null || text == string.Empty) && defaultValue != null)
		{
			text = defaultValue.ToString();
			bFromConfigFile = false;
		}
		return text;
	}

	public static int RetrieveIntValue(string entryToBeSearched, object defaultValue, bool bAcceptNegativeValues, ref bool bFromConfigFile)
	{
		int num = 0;
		try
		{
			num = int.Parse(RetrieveStringValue(entryToBeSearched, defaultValue, ref bFromConfigFile));
			if (!bAcceptNegativeValues && num < 0)
			{
				num = (int)defaultValue;
			}
		}
		catch
		{
			num = (int)defaultValue;
		}
		return num;
	}

	internal static void ReadEntriesForRegistryAndConfig()
	{
		OraTrace.m_oraOpsDllPath = RetrieveStringValue("DllPath", "", ref s_bFromConfigOraOpsDllPath);
		OraTrace.m_traceFileName = RetrieveStringValue("TraceFileName", "", ref s_bFromConfigTraceFileName);
		OraTrace.m_TraceOption = (uint)RetrieveIntValue("TraceOption", 0, bAcceptNegativeValues: false, ref s_bFromConfigTraceOption);
		OraTrace.m_TraceLevel = (uint)RetrieveIntValue("TraceLevel", 0, bAcceptNegativeValues: false, ref s_bFromConfigTraceLevel);
		OraTrace.m_udtCacheSize = (uint)RetrieveIntValue("UdtCacheSize", 4096, bAcceptNegativeValues: false, ref s_bFromConfigUdtCacheSize);
		OraTrace.m_StmtCacheSize = RetrieveIntValue("StatementCacheSize", 0, bAcceptNegativeValues: false, ref s_bFromConfigStmtCacheSize);
		OraTrace.m_checkConStatus = (uint)RetrieveIntValue("CheckConStatus", 1, bAcceptNegativeValues: false, ref s_bFromConfigCheckConStatus);
		OraTrace.m_dynamicEnlist = (uint)RetrieveIntValue("DynamicEnlistment", 0, bAcceptNegativeValues: false, ref s_bFromConfigDynamicEnlist);
		OraTrace.m_FetchSize = RetrieveIntValue("FetchSize", 131072, bAcceptNegativeValues: false, ref s_bFromConfigFetchSize);
		OraTrace.m_ociEvents = RetrieveIntValue("OCI_EVENTS", 0, bAcceptNegativeValues: true, ref s_bFromConfigOciEvents);
		OraTrace.m_stmtCacheWithUdts = RetrieveIntValue("StatementCacheWithUdts", 1, bAcceptNegativeValues: false, ref s_bFromConfigStmtCacheWithUdts);
		OraTrace.m_MetadataPooling = RetrieveIntValue("MetadataPooling", 1, bAcceptNegativeValues: false, ref s_bFromConfigMetadataPooling);
		OraTrace.m_DBNotificationPort = RetrieveIntValue("DbNotificationPort", -1, bAcceptNegativeValues: true, ref s_bFromConfigDBNotificationPort);
		OraTrace.m_DBNotificationRegInterval = RetrieveIntValue("DbNotificationRegInterval", 0, bAcceptNegativeValues: false, ref s_bFromConfigDbNtfnRegInterval);
		OraTrace.m_demandOrclPermission = RetrieveIntValue("DemandOraclePermission", 0, bAcceptNegativeValues: false, ref s_bFromConfigDemandOrclPermission);
		OraTrace.m_selfTuning = Convert.ToBoolean(RetrieveIntValue("SelfTuning", 1, bAcceptNegativeValues: false, ref s_bFromConfigSelfTuning));
		OraTrace.m_maxStatementCacheSize = RetrieveIntValue("MaxStatementCacheSize", 100, bAcceptNegativeValues: false, ref s_bFromConfigMaxStatementCacheSize);
		OraTrace.m_InitialLOBFetchSize = RetrieveIntValue("InitialLOBFetchSize", -1, bAcceptNegativeValues: true, ref s_bFromConfigInitialLOBFetchSize);
		OraTrace.m_InitialLONGFetchSize = RetrieveIntValue("InitialLONGFetchSize", -1, bAcceptNegativeValues: true, ref s_bFromConfigInitialLONGFetchSize);
		OraTrace.m_appEdition = RetrieveStringValue("Edition", "", ref s_bFromConfigAppEdition);
		OraTrace.m_MetaDataXml = RetrieveStringValue("MetaDataXml", null, ref s_bFromConfigMetaDataXml);
		OraTrace.m_RevertBUErrHandling = RetrieveIntValue("RevertBatchUpdateErrorHandling", 0, bAcceptNegativeValues: false, ref s_bFromConfigRevertBUErrHandling);
		OraTrace.m_fetchArrayPooling = RetrieveIntValue("FetchArrayPooling", 1, bAcceptNegativeValues: false, ref s_bFromConfigFetchArrayPooling);
		int performanceCounters = RetrieveIntValue("PerformanceCounters", 0, bAcceptNegativeValues: false, ref s_bFromConfigPerfCounters);
		OraTrace.m_PerformanceCounters = (PerfCounterLevel)performanceCounters;
		string strA = RetrieveStringValue("PromotableTransaction", string.Empty, ref s_bFromConfigPSPE);
		if (string.Compare(strA, "local", ignoreCase: true) == 0)
		{
			OraTrace.m_PSPE = 0;
		}
		OraTrace.m_CPThreadPrioritization = RetrieveIntValue("CPThreadPrioritization", 1, bAcceptNegativeValues: false, ref s_bFromConfigCPThreadPrioritization);
	}

	public static void TraceRefCursorInfoInAppConfig(string configFileName)
	{
		if (OraTrace.m_TraceLevel == 0)
		{
			return;
		}
		Hashtable hashtable = null;
		if (configFileName != null && configFileName.Length > 0)
		{
			if (!s_odtConfigNamesToRefCursorInfo.Contains(configFileName))
			{
				return;
			}
			hashtable = ((ODTConfigFileInfoForRefCursors)s_odtConfigNamesToRefCursorInfo[configFileName]).storedProcList;
		}
		else
		{
			hashtable = s_storedProcInformation;
		}
		if (hashtable.Keys.Count <= 0)
		{
			return;
		}
		foreach (string key in hashtable.Keys)
		{
			StringBuilder stringBuilder = new StringBuilder();
			ArrayList refCursors = (refCursors = ((StoredProcedureInfo)hashtable[key]).refCursors);
			foreach (RefCursorInfo item in refCursors)
			{
				stringBuilder.Append(s_strCfg);
				if (configFileName != null && configFileName.Length > 0)
				{
					stringBuilder.Append(" (REFCURSOR) (Design-time Implicit Binding Info : [" + key + "]");
				}
				else
				{
					stringBuilder.Append(" (REFCURSOR) (Run-time Implicit Binding Info : [" + key + "]");
				}
				stringBuilder.Append("[param name/pos=" + ((item.name == string.Empty) ? item.position.ToString() : item.name) + ";");
				stringBuilder.Append(string.Concat("mode=", item.mode, "] Metadata : "));
				string value = stringBuilder.ToString();
				if (item.columnInfo == null)
				{
					stringBuilder.Append("[<none>])");
					OraTrace.Trace(1u, stringBuilder.ToString());
					continue;
				}
				DataTable columnInfo = item.columnInfo;
				for (int i = 0; i < columnInfo.Rows.Count; i++)
				{
					stringBuilder.Append("[");
					for (int j = 0; j < columnInfo.Columns.Count; j++)
					{
						stringBuilder.Append(((j != 0) ? ";" : string.Empty) + columnInfo.Columns[j].ToString() + "=" + columnInfo.Rows[i][j]);
					}
					stringBuilder.Append("])");
					OraTrace.Trace(1u, stringBuilder.ToString());
					stringBuilder.Length = 0;
					stringBuilder.Append(value);
				}
				stringBuilder.Length = 0;
			}
		}
	}

	public static void TraceRegistryAndConfigValues()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, s_strVer + " (" + OracleInit.m_version + s_strTrm);
			OraTrace.Trace(1u, (s_bFromConfigOraOpsDllPath ? s_strCfg : s_strReg) + " (DllPath : " + OraTrace.m_oraOpsDllPath + s_strTrm);
			OraTrace.Trace(1u, (s_bFromConfigTraceFileName ? s_strCfg : s_strReg) + " (TraceFileName : " + OraTrace.m_traceFileName + s_strTrm);
			OraTrace.Trace(1u, (s_bFromConfigTraceLevel ? s_strCfg : s_strReg) + " (TraceLevel : " + OraTrace.m_TraceLevel + s_strTrm);
			OraTrace.Trace(1u, (s_bFromConfigTraceOption ? s_strCfg : s_strReg) + " (TraceOption : " + OraTrace.m_TraceOption + s_strTrm);
			OraTrace.Trace(1u, (s_bFromConfigCheckConStatus ? s_strCfg : s_strReg) + " (CheckConStatus : " + OraTrace.m_checkConStatus + s_strTrm);
			OraTrace.Trace(1u, (s_bFromConfigUdtCacheSize ? s_strCfg : s_strReg) + " (UdtCacheSize : " + OraTrace.m_udtCacheSize + s_strTrm);
			OraTrace.Trace(1u, (s_bFromConfigStmtCacheSize ? s_strCfg : s_strReg) + " (StatementCacheSize : " + OraTrace.m_StmtCacheSize + s_strTrm);
			OraTrace.Trace(1u, (s_bFromConfigDynamicEnlist ? s_strCfg : s_strReg) + " (DynamicEnlist : " + OraTrace.m_dynamicEnlist + s_strTrm);
			OraTrace.Trace(1u, (s_bFromConfigFetchSize ? s_strCfg : s_strReg) + " (FetchSize : " + OraTrace.m_FetchSize + s_strTrm);
			OraTrace.Trace(1u, (s_bFromConfigOciEvents ? s_strCfg : s_strReg) + " (OCI_EVENTS : " + OraTrace.m_ociEvents + s_strTrm);
			OraTrace.Trace(1u, (s_bFromConfigStmtCacheWithUdts ? s_strCfg : s_strReg) + " (StatementCacheWithUdts : " + OraTrace.m_stmtCacheWithUdts + s_strTrm);
			OraTrace.Trace(1u, (s_bFromConfigMetadataPooling ? s_strCfg : s_strReg) + " (MetadataPooling : " + OraTrace.m_MetadataPooling + s_strTrm);
			OraTrace.Trace(1u, (s_bFromConfigDBNotificationPort ? s_strCfg : s_strReg) + " (DBNotificationPort : " + OraTrace.m_DBNotificationPort + s_strTrm);
			OraTrace.Trace(1u, (s_bFromConfigThreadPoolMaxSize ? s_strCfg : s_strReg) + " (ThreadPoolMaxSize : " + OraTrace.m_threadPoolMaxSize + s_strTrm);
			OraTrace.Trace(1u, (s_bFromConfigDbNtfnRegInterval ? s_strCfg : s_strReg) + " (DBNotificationRegInterval : " + OraTrace.m_DBNotificationRegInterval + s_strTrm);
			OraTrace.Trace(1u, (s_bFromConfigDemandOrclPermission ? s_strCfg : s_strReg) + " (DemandOraclePermission : " + OraTrace.m_demandOrclPermission + s_strTrm);
			OraTrace.Trace(1u, (s_bFromConfigSelfTuning ? s_strCfg : s_strReg) + " (SelfTuning : " + OraTrace.m_selfTuning + s_strTrm);
			OraTrace.Trace(1u, (s_bFromConfigMaxStatementCacheSize ? s_strCfg : s_strReg) + " (MaxStatementCacheSize : " + OraTrace.m_maxStatementCacheSize + s_strTrm);
			OraTrace.Trace(1u, (s_bFromConfigAppEdition ? s_strCfg : s_strReg) + " (AppEdition : " + OraTrace.m_appEdition + s_strTrm);
			OraTrace.Trace(1u, (s_bFromConfigMetaDataXml ? s_strCfg : s_strReg) + " (MetaDataXml : " + OraTrace.m_MetaDataXml + s_strTrm);
			OraTrace.Trace(1u, (s_bFromConfigRevertBUErrHandling ? s_strCfg : s_strReg) + " (RevertBatchUpdateErrorHandling : " + OraTrace.m_RevertBUErrHandling + s_strTrm);
			OraTrace.Trace(1u, (s_bFromConfigFetchArrayPooling ? s_strCfg : s_strReg) + " (FetchArrayPooling : " + OraTrace.m_fetchArrayPooling + s_strTrm);
			OraTrace.Trace(1u, string.Concat(s_bFromConfigPerfCounters ? s_strCfg : s_strReg, " (PerformanceCounters : ", OraTrace.m_PerformanceCounters, s_strTrm));
			OraTrace.Trace(1u, (s_bFromConfigPSPE ? s_strCfg : s_strReg) + " (PSPE : " + OraTrace.m_PSPE + s_strTrm);
			TraceRefCursorInfoInAppConfig(string.Empty);
		}
	}
}
