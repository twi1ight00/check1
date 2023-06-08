using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;
using System.Globalization;

namespace Oracle.DataAccess.Client;

[DefaultProperty("DataSource")]
public sealed class OracleConnectionStringBuilder : DbConnectionStringBuilder
{
	private const int DEFAULT_STATEMENT_CACHE_SIZE = 0;

	private Dictionary<string, object> KeyValuePairList;

	private static Hashtable m_boolMapping;

	private static Hashtable m_defaultValues;

	[DisplayName("Proxy User")]
	public string ProxyUserId
	{
		get
		{
			return (string)KeyValuePairList["PROXY USER ID"];
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException();
			}
			SetValueToBaseAndList("PROXY USER ID", value);
		}
	}

	[DisplayName("Proxy Password")]
	public string ProxyPassword
	{
		get
		{
			return (string)KeyValuePairList["PROXY PASSWORD"];
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException();
			}
			SetValueToBaseAndList("PROXY PASSWORD", value);
		}
	}

	[DisplayName("DBA Privilege")]
	public string DBAPrivilege
	{
		get
		{
			return (string)KeyValuePairList["DBA PRIVILEGE"];
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException();
			}
			if (value.ToLower() != "sysdba" && value.ToLower() != "sysoper" && value != string.Empty)
			{
				throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "DBA Privilege", value));
			}
			SetValueToBaseAndList("DBA PRIVILEGE", value);
		}
	}

	[DisplayName("User ID")]
	public string UserID
	{
		get
		{
			return (string)KeyValuePairList["USER ID"];
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException();
			}
			SetValueToBaseAndList("USER ID", value);
		}
	}

	[DisplayName("Data Source")]
	public string DataSource
	{
		get
		{
			return (string)KeyValuePairList["DATA SOURCE"];
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException();
			}
			SetValueToBaseAndList("DATA SOURCE", value);
		}
	}

	[DisplayName("Password")]
	[PasswordPropertyText(true)]
	public string Password
	{
		get
		{
			return (string)KeyValuePairList["PASSWORD"];
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException();
			}
			SetValueToBaseAndList("PASSWORD", value);
		}
	}

	[DisplayName("Max Pool Size")]
	public int MaxPoolSize
	{
		get
		{
			return (int)KeyValuePairList["MAX POOL SIZE"];
		}
		set
		{
			if (value < 1)
			{
				throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Max Pool Size", value.ToString()));
			}
			SetValueToBaseAndList("MAX POOL SIZE", value);
		}
	}

	[DisplayName("Min Pool Size")]
	public int MinPoolSize
	{
		get
		{
			return (int)KeyValuePairList["MIN POOL SIZE"];
		}
		set
		{
			if (value < 0)
			{
				throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Min Pool Size", value.ToString()));
			}
			SetValueToBaseAndList("MIN POOL SIZE", value);
		}
	}

	[DisplayName("Increment pool size")]
	public int IncrPoolSize
	{
		get
		{
			return (int)KeyValuePairList["INCR POOL SIZE"];
		}
		set
		{
			if (value < 1)
			{
				throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Increment Pool Size", value.ToString()));
			}
			SetValueToBaseAndList("INCR POOL SIZE", value);
		}
	}

	[DisplayName("Decrement pool size")]
	public int DecrPoolSize
	{
		get
		{
			return (int)KeyValuePairList["DECR POOL SIZE"];
		}
		set
		{
			if (value < 1)
			{
				throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Decrement Pool Size", value.ToString()));
			}
			SetValueToBaseAndList("DECR POOL SIZE", value);
		}
	}

	[DisplayName("Connection Life Time")]
	public int ConnectionLifeTime
	{
		get
		{
			return (int)KeyValuePairList["CONNECTION LIFETIME"];
		}
		set
		{
			if (value < 0)
			{
				throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Connection Life Time", value.ToString()));
			}
			SetValueToBaseAndList("CONNECTION LIFETIME", value);
		}
	}

	[DisplayName("Statement Cache Size")]
	public int StatementCacheSize
	{
		get
		{
			return (int)KeyValuePairList["STATEMENT CACHE SIZE"];
		}
		set
		{
			if (value < 0)
			{
				throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Statement Cache Size", value.ToString()));
			}
			SetValueToBaseAndList("STATEMENT CACHE SIZE", value);
		}
	}

	[DisplayName("Connection Timeout")]
	public int ConnectionTimeout
	{
		get
		{
			return (int)KeyValuePairList["CONNECTION TIMEOUT"];
		}
		set
		{
			if (value < 0)
			{
				throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Connection Timeout", value.ToString()));
			}
			SetValueToBaseAndList("CONNECTION TIMEOUT", value);
		}
	}

	[DisplayName("Persist Security Info")]
	public bool PersistSecurityInfo
	{
		get
		{
			return (bool)KeyValuePairList["PERSIST SECURITY INFO"];
		}
		set
		{
			SetValueToBaseAndList("PERSIST SECURITY INFO", value);
		}
	}

	[DisplayName("Enlist")]
	public string Enlist
	{
		get
		{
			return (string)KeyValuePairList["ENLIST"];
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException();
			}
			if (value.ToLowerInvariant() != "dynamic" && !m_boolMapping.ContainsKey(value.ToLower()))
			{
				throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Enlist", value));
			}
			SetValueToBaseAndList("ENLIST", value.ToLowerInvariant());
		}
	}

	[DisplayName("metadata pooling")]
	public bool MetadataPooling
	{
		get
		{
			return (bool)KeyValuePairList["METADATA POOLING"];
		}
		set
		{
			SetValueToBaseAndList("METADATA POOLING", value);
		}
	}

	[DisplayName("Self Tuning")]
	public bool SelfTuning
	{
		get
		{
			return (bool)KeyValuePairList["SELF TUNING"];
		}
		set
		{
			SetValueToBaseAndList("SELF TUNING", value);
		}
	}

	[DisplayName("Pooling")]
	public bool Pooling
	{
		get
		{
			return (bool)KeyValuePairList["POOLING"];
		}
		set
		{
			SetValueToBaseAndList("POOLING", value);
		}
	}

	[DisplayName("Validate Connection")]
	public bool ValidateConnection
	{
		get
		{
			return (bool)KeyValuePairList["VALIDATE CONNECTION"];
		}
		set
		{
			SetValueToBaseAndList("VALIDATE CONNECTION", value);
		}
	}

	[DisplayName("Statement Cache Purge")]
	public bool StatementCachePurge
	{
		get
		{
			return (bool)KeyValuePairList["STATEMENT CACHE PURGE"];
		}
		set
		{
			SetValueToBaseAndList("STATEMENT CACHE PURGE", value);
		}
	}

	[DisplayName("HAEvents")]
	public bool HAEvents
	{
		get
		{
			return (bool)KeyValuePairList["HA EVENTS"];
		}
		set
		{
			SetValueToBaseAndList("HA EVENTS", value);
		}
	}

	[DisplayName("Load Balancing")]
	public bool LoadBalancing
	{
		get
		{
			return (bool)KeyValuePairList["LOAD BALANCING"];
		}
		set
		{
			SetValueToBaseAndList("LOAD BALANCING", value);
		}
	}

	[DisplayName("Context Connection")]
	public bool ContextConnection
	{
		get
		{
			return (bool)KeyValuePairList["CONTEXT CONNECTION"];
		}
		set
		{
			SetValueToBaseAndList("CONTEXT CONNECTION", value);
		}
	}

	[DisplayName("PromotableTransaction")]
	public string PromotableTransaction
	{
		get
		{
			return (string)KeyValuePairList["PROMOTABLE TRANSACTION"];
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException();
			}
			SetValueToBaseAndList("PROMOTABLE TRANSACTION", value);
		}
	}

	public override bool IsFixedSize => true;

	public override ICollection Keys
	{
		get
		{
			ICollection<string> keys = KeyValuePairList.Keys;
			string[] array = new string[keys.Count];
			keys.CopyTo(array, 0);
			return new ReadOnlyCollection<string>(array);
		}
	}

	public override ICollection Values
	{
		get
		{
			ICollection<string> collection = (ICollection<string>)Keys;
			IEnumerator<string> enumerator = collection.GetEnumerator();
			object[] array = new object[collection.Count];
			for (int i = 0; i < array.Length; i++)
			{
				enumerator.MoveNext();
				array[i] = this[enumerator.Current];
			}
			return new ReadOnlyCollection<object>(array);
		}
	}

	public override object this[string keyword]
	{
		get
		{
			if (keyword == null)
			{
				throw new ArgumentNullException();
			}
			return KeyValuePairList[keyword];
		}
		set
		{
			if (keyword == null)
			{
				throw new ArgumentNullException();
			}
			if (value == null)
			{
				Remove(keyword);
			}
			else
			{
				SetProperty(keyword, value);
			}
		}
	}

	static OracleConnectionStringBuilder()
	{
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
		m_boolMapping = new Hashtable(4);
		m_boolMapping["true"] = true;
		m_boolMapping["false"] = false;
		m_boolMapping["yes"] = true;
		m_boolMapping["no"] = false;
		m_defaultValues = new Hashtable();
		m_defaultValues.Add("USER ID", "");
		m_defaultValues.Add("PASSWORD", "");
		m_defaultValues.Add("PROXY USER ID", "");
		m_defaultValues.Add("PROXY PASSWORD", "");
		m_defaultValues.Add("DATA SOURCE", "");
		m_defaultValues.Add("DBA PRIVILEGE", "");
		m_defaultValues.Add("PROMOTABLE TRANSACTION", "promotable");
		m_defaultValues.Add("CONNECTION LIFETIME", 0);
		m_defaultValues.Add("INCR POOL SIZE", 5);
		m_defaultValues.Add("DECR POOL SIZE", 1);
		m_defaultValues.Add("MAX POOL SIZE", 100);
		m_defaultValues.Add("MIN POOL SIZE", 1);
		if (OraTrace.m_StmtCacheSize > 0)
		{
			m_defaultValues.Add("STATEMENT CACHE SIZE", OraTrace.m_StmtCacheSize);
		}
		else
		{
			m_defaultValues.Add("STATEMENT CACHE SIZE", 0);
		}
		m_defaultValues.Add("CONNECTION TIMEOUT", 15);
		m_defaultValues.Add("ENLIST", "true");
		m_defaultValues.Add("POOLING", true);
		m_defaultValues.Add("VALIDATE CONNECTION", false);
		m_defaultValues.Add("STATEMENT CACHE PURGE", false);
		m_defaultValues.Add("PERSIST SECURITY INFO", false);
		m_defaultValues.Add("HA EVENTS", false);
		m_defaultValues.Add("LOAD BALANCING", false);
		m_defaultValues.Add("CONTEXT CONNECTION", false);
		m_defaultValues.Add("METADATA POOLING", true);
		m_defaultValues.Add("SELF TUNING", OraTrace.m_selfTuning);
	}

	private void SetProperty(string keyword, object value)
	{
		string text = keyword.ToUpperInvariant();
		switch (text)
		{
		case "USER ID":
			UserID = value.ToString();
			break;
		case "PASSWORD":
			Password = value.ToString();
			break;
		case "DATA SOURCE":
			DataSource = value.ToString();
			break;
		case "DBA PRIVILEGE":
			DBAPrivilege = value.ToString();
			break;
		case "PROXY USER ID":
			ProxyUserId = value.ToString();
			break;
		case "PROXY PASSWORD":
			ProxyPassword = Convert.ToString(value);
			break;
		case "PROMOTABLE TRANSACTION":
			PromotableTransaction = Convert.ToString(value);
			break;
		case "ENLIST":
			Enlist = value.ToString();
			break;
		case "MIN POOL SIZE":
		{
			int statementCacheSize = 0;
			try
			{
				statementCacheSize = int.Parse(value.ToString(), NumberStyles.None);
			}
			catch
			{
				throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Min Pool Size", value.ToString()));
			}
			MinPoolSize = statementCacheSize;
			break;
		}
		case "MAX POOL SIZE":
		{
			int statementCacheSize;
			try
			{
				statementCacheSize = int.Parse(value.ToString(), NumberStyles.None);
			}
			catch
			{
				throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Max Pool Size", value.ToString()));
			}
			MaxPoolSize = statementCacheSize;
			break;
		}
		case "CONNECTION LIFETIME":
		{
			int statementCacheSize;
			try
			{
				statementCacheSize = int.Parse(value.ToString(), NumberStyles.None);
			}
			catch
			{
				throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Connection Lifetime", value.ToString()));
			}
			ConnectionLifeTime = statementCacheSize;
			break;
		}
		case "CONNECTION TIMEOUT":
		case "CONNECT TIMEOUT":
		{
			int statementCacheSize;
			try
			{
				statementCacheSize = int.Parse(value.ToString(), NumberStyles.None);
			}
			catch
			{
				throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Connection Timeout", value.ToString()));
			}
			ConnectionTimeout = statementCacheSize;
			break;
		}
		case "INCR POOL SIZE":
		{
			int statementCacheSize;
			try
			{
				statementCacheSize = int.Parse(value.ToString(), NumberStyles.None);
			}
			catch
			{
				throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Incr Pool Size", value.ToString()));
			}
			IncrPoolSize = statementCacheSize;
			break;
		}
		case "DECR POOL SIZE":
		{
			int statementCacheSize;
			try
			{
				statementCacheSize = int.Parse(value.ToString(), NumberStyles.None);
			}
			catch
			{
				throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Decr Pool Size", value.ToString()));
			}
			DecrPoolSize = statementCacheSize;
			break;
		}
		case "STATEMENT CACHE SIZE":
		{
			int statementCacheSize;
			try
			{
				statementCacheSize = int.Parse(value.ToString(), NumberStyles.None);
			}
			catch
			{
				throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Statement Cache Size", value.ToString()));
			}
			StatementCacheSize = statementCacheSize;
			break;
		}
		case "PERSIST SECURITY INFO":
		{
			string text2 = value.ToString().ToLower();
			if (m_boolMapping.ContainsKey(text2))
			{
				PersistSecurityInfo = (bool)m_boolMapping[text2];
				break;
			}
			throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Persist Security Info", text2));
		}
		case "POOLING":
		{
			string text2 = value.ToString().ToLower();
			if (m_boolMapping.ContainsKey(text2))
			{
				Pooling = (bool)m_boolMapping[text2];
				break;
			}
			throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Pooling", text2));
		}
		case "VALIDATE CONNECTION":
		{
			string text2 = value.ToString().ToLower();
			if (m_boolMapping.ContainsKey(text2))
			{
				ValidateConnection = (bool)m_boolMapping[text2];
				break;
			}
			throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "validate connection", text2));
		}
		case "STATEMENT CACHE PURGE":
		{
			string text2 = value.ToString().ToLower();
			if (m_boolMapping.ContainsKey(text2))
			{
				StatementCachePurge = (bool)m_boolMapping[text2];
				break;
			}
			throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Statement Cache Purge", text2));
		}
		case "HA EVENTS":
		{
			string text2 = value.ToString().ToLower();
			if (m_boolMapping.ContainsKey(text2))
			{
				HAEvents = (bool)m_boolMapping[text2];
				break;
			}
			throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "HA events", text2));
		}
		case "LOAD BALANCING":
		{
			string text2 = value.ToString().ToLower();
			if (m_boolMapping.ContainsKey(text2))
			{
				LoadBalancing = (bool)m_boolMapping[text2];
				break;
			}
			throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "load balancing", text2));
		}
		case "CONTEXT CONNECTION":
		{
			string text2 = value.ToString().ToLower();
			if (m_boolMapping.ContainsKey(text2))
			{
				ContextConnection = (bool)m_boolMapping[text2];
				break;
			}
			throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Context Connection", text2));
		}
		case "METADATA POOLING":
		{
			string text2 = value.ToString().ToLower();
			if (m_boolMapping.ContainsKey(text2))
			{
				MetadataPooling = (bool)m_boolMapping[text2];
				break;
			}
			throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "metadata pooling", text2));
		}
		case "SELF TUNING":
		{
			string text2 = value.ToString().ToLower();
			if (m_boolMapping.ContainsKey(text2))
			{
				SelfTuning = (bool)m_boolMapping[text2];
				break;
			}
			throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_VALUE, "Self Tuning", text2));
		}
		default:
			throw new OracleException(ErrRes.CON_STR_INVALID_VALUE, string.Empty, string.Empty, OpoErrResManager.GetErrorMesg(ErrRes.CON_STR_INVALID_ATTRIB, text));
		}
	}

	private void ResetValues()
	{
		foreach (string key in m_defaultValues.Keys)
		{
			KeyValuePairList[key] = m_defaultValues[key];
		}
	}

	private void Initialize()
	{
		KeyValuePairList = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
		IDictionaryEnumerator enumerator = m_defaultValues.GetEnumerator();
		while (enumerator.MoveNext())
		{
			KeyValuePairList.Add(enumerator.Key as string, enumerator.Value);
		}
	}

	private void SetValueToBaseAndList(string keyword, object value)
	{
		base[keyword] = value;
		KeyValuePairList[keyword] = value;
	}

	public OracleConnectionStringBuilder()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnectionStringBuilder::OracleConnectionStringBuilder(1)\n");
		}
		Initialize();
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleConnectionStringBuilder::OracleConnectionStringBuilder(1)\n");
		}
	}

	public OracleConnectionStringBuilder(string connectionString)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnectionStringBuilder::OracleConnectionStringBuilder(2)\n");
		}
		if (connectionString == null)
		{
			throw new ArgumentNullException();
		}
		Initialize();
		base.ConnectionString = connectionString;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleConnectionStringBuilder::OracleConnectionStringBuilder(2)\n");
		}
	}

	public override void Clear()
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnectionStringBuilder::Clear()\n");
		}
		base.Clear();
		ResetValues();
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleConnectionStringBuilder::Clear()\n");
		}
	}

	public override bool ContainsKey(string keyword)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnectionStringBuilder::ContainsKey()\n");
		}
		if (keyword == null)
		{
			throw new ArgumentNullException();
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleConnectionStringBuilder::ContainsKey()\n");
		}
		return KeyValuePairList.ContainsKey(keyword);
	}

	public override bool Remove(string keyword)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnectionStringBuilder::Remove()\n");
		}
		if (keyword == null)
		{
			throw new ArgumentNullException();
		}
		string text = keyword.ToUpperInvariant();
		if (base.Remove(text))
		{
			KeyValuePairList[text] = m_defaultValues[text];
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleConnectionStringBuilder::Remove()\n");
			}
			return true;
		}
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleConnectionStringBuilder::Remove()\n");
		}
		return false;
	}

	public override bool TryGetValue(string keyword, out object value)
	{
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (ENTRY) OracleConnectionStringBuilder::TryGetValue()\n");
		}
		if (keyword == null)
		{
			throw new ArgumentNullException();
		}
		if (ContainsKey(keyword))
		{
			value = KeyValuePairList[keyword];
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleConnectionStringBuilder::TryGetValue()\n");
			}
			return true;
		}
		value = null;
		if (OraTrace.m_TraceLevel != 0)
		{
			OraTrace.Trace(1u, " (EXIT)  OracleConnectionStringBuilder::TryGetValue()\n");
		}
		return false;
	}

	protected override void GetProperties(Hashtable propertyDescriptors)
	{
		base.GetProperties(propertyDescriptors);
	}
}
