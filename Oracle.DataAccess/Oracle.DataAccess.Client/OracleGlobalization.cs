using System;
using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential)]
public sealed class OracleGlobalization : ICloneable, IDisposable
{
	internal OraGlobStruct m_oraGlob;

	internal IntPtr m_nlsCtx;

	internal bool m_disposed;

	private object m_lockObj = new object();

	private static object s_lockObj;

	public string Calendar
	{
		get
		{
			if (m_oraGlob.m_calendar == null)
			{
				return string.Empty;
			}
			return m_oraGlob.m_calendar;
		}
		set
		{
			if (!m_disposed)
			{
				ValidateSetting(0, value);
				m_oraGlob.m_calendar = value;
			}
		}
	}

	public string ClientCharacterSet
	{
		get
		{
			if (m_oraGlob.m_clientCharacterSet == null)
			{
				return string.Empty;
			}
			return m_oraGlob.m_clientCharacterSet;
		}
	}

	public string Comparison
	{
		get
		{
			if (m_oraGlob.m_comparison == null)
			{
				return string.Empty;
			}
			return m_oraGlob.m_comparison;
		}
		set
		{
			if (!m_disposed)
			{
				ValidateSetting(2, value);
				m_oraGlob.m_comparison = value;
				return;
			}
			throw new ObjectDisposedException(GetType().Name);
		}
	}

	public string Currency
	{
		get
		{
			if (m_oraGlob.m_currency == null)
			{
				return string.Empty;
			}
			return m_oraGlob.m_currency;
		}
		set
		{
			if (!m_disposed)
			{
				ValidateSetting(3, value);
				m_oraGlob.m_currency = value;
				return;
			}
			throw new ObjectDisposedException(GetType().Name);
		}
	}

	public string DateFormat
	{
		get
		{
			if (m_oraGlob.m_dateFormat == null)
			{
				return string.Empty;
			}
			return m_oraGlob.m_dateFormat;
		}
		set
		{
			if (!m_disposed)
			{
				ValidateSetting(4, value);
				m_oraGlob.m_dateFormat = value;
				return;
			}
			throw new ObjectDisposedException(GetType().Name);
		}
	}

	public string DateLanguage
	{
		get
		{
			if (m_oraGlob.m_dateLanguage == null)
			{
				return string.Empty;
			}
			return m_oraGlob.m_dateLanguage;
		}
		set
		{
			if (!m_disposed)
			{
				ValidateSetting(5, value);
				m_oraGlob.m_dateLanguage = value;
				return;
			}
			throw new ObjectDisposedException(GetType().Name);
		}
	}

	public string DualCurrency
	{
		get
		{
			if (m_oraGlob.m_dualCurrency == null)
			{
				return string.Empty;
			}
			return m_oraGlob.m_dualCurrency;
		}
		set
		{
			if (!m_disposed)
			{
				ValidateSetting(6, value);
				m_oraGlob.m_dualCurrency = value;
				return;
			}
			throw new ObjectDisposedException(GetType().Name);
		}
	}

	public string ISOCurrency
	{
		get
		{
			if (m_oraGlob.m_isoCurrency == null)
			{
				return string.Empty;
			}
			return m_oraGlob.m_isoCurrency;
		}
		set
		{
			if (!m_disposed)
			{
				ValidateSetting(7, value);
				m_oraGlob.m_isoCurrency = value;
				return;
			}
			throw new ObjectDisposedException(GetType().Name);
		}
	}

	public string Language
	{
		get
		{
			if (m_oraGlob.m_language == null)
			{
				return string.Empty;
			}
			return m_oraGlob.m_language;
		}
		set
		{
			if (!m_disposed)
			{
				IntPtr pOraGlob = IntPtr.Zero;
				string timeZone = m_oraGlob.m_timeZone;
				ValidateSetting(8, value);
				try
				{
					OpsCom.RefreshGlobInfo(m_nlsCtx, out pOraGlob, 0);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
					throw;
				}
				Marshal.PtrToStructure(pOraGlob, (object)m_oraGlob);
				m_oraGlob.m_timeZone = timeZone;
				return;
			}
			throw new ObjectDisposedException(GetType().Name);
		}
	}

	public string LengthSemantics
	{
		get
		{
			if (m_oraGlob.m_lengthSemantics == null)
			{
				return string.Empty;
			}
			return m_oraGlob.m_lengthSemantics;
		}
		set
		{
			if (!m_disposed)
			{
				ValidateSetting(9, value);
				m_oraGlob.m_lengthSemantics = value;
				return;
			}
			throw new ObjectDisposedException(GetType().Name);
		}
	}

	public bool NCharConversionException
	{
		get
		{
			return m_oraGlob.m_nCharConvExcp.ToLower() == "true";
		}
		set
		{
			if (!m_disposed)
			{
				ValidateSetting(10, value ? "true" : "false");
				m_oraGlob.m_nCharConvExcp = value.ToString().ToLower();
				return;
			}
			throw new ObjectDisposedException(GetType().Name);
		}
	}

	public string NumericCharacters
	{
		get
		{
			if (m_oraGlob.m_numericCharacters == null)
			{
				return string.Empty;
			}
			return m_oraGlob.m_numericCharacters;
		}
		set
		{
			if (!m_disposed)
			{
				ValidateSetting(11, value);
				m_oraGlob.m_numericCharacters = value;
				return;
			}
			throw new ObjectDisposedException(GetType().Name);
		}
	}

	public string Sort
	{
		get
		{
			if (m_oraGlob.m_sort == null)
			{
				return string.Empty;
			}
			return m_oraGlob.m_sort;
		}
		set
		{
			if (!m_disposed)
			{
				ValidateSetting(13, value);
				m_oraGlob.m_sort = value;
				return;
			}
			throw new ObjectDisposedException(GetType().Name);
		}
	}

	public string Territory
	{
		get
		{
			if (m_oraGlob.m_territory == null)
			{
				return string.Empty;
			}
			return m_oraGlob.m_territory;
		}
		set
		{
			if (!m_disposed)
			{
				IntPtr pOraGlob = IntPtr.Zero;
				string timeZone = m_oraGlob.m_timeZone;
				ValidateSetting(14, value);
				try
				{
					OpsCom.RefreshGlobInfo(m_nlsCtx, out pOraGlob, 0);
				}
				catch (Exception ex)
				{
					if (OraTrace.m_TraceLevel != 0)
					{
						OraTrace.TraceExceptionInfo(ex);
					}
					throw;
				}
				Marshal.PtrToStructure(pOraGlob, (object)m_oraGlob);
				m_oraGlob.m_timeZone = timeZone;
				return;
			}
			throw new ObjectDisposedException(GetType().Name);
		}
	}

	public string TimeStampFormat
	{
		get
		{
			if (m_oraGlob.m_timeStampFormat == null)
			{
				return string.Empty;
			}
			return m_oraGlob.m_timeStampFormat;
		}
		set
		{
			if (!m_disposed)
			{
				ValidateSetting(15, value);
				m_oraGlob.m_timeStampFormat = value;
				return;
			}
			throw new ObjectDisposedException(GetType().Name);
		}
	}

	public string TimeStampTZFormat
	{
		get
		{
			if (m_oraGlob.m_timeStampTZFormat == null)
			{
				return string.Empty;
			}
			return m_oraGlob.m_timeStampTZFormat;
		}
		set
		{
			if (!m_disposed)
			{
				ValidateSetting(16, value);
				m_oraGlob.m_timeStampTZFormat = value;
				return;
			}
			throw new ObjectDisposedException(GetType().Name);
		}
	}

	public string TimeZone
	{
		get
		{
			if (m_oraGlob.m_timeZone != null)
			{
				return m_oraGlob.m_timeZone;
			}
			return string.Empty;
		}
		set
		{
			if (!m_disposed)
			{
				m_oraGlob.m_timeZone = value;
				return;
			}
			throw new ObjectDisposedException(GetType().Name);
		}
	}

	static OracleGlobalization()
	{
		s_lockObj = new object();
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	internal OracleGlobalization()
	{
		int num = 0;
		m_oraGlob = new OraGlobStruct();
		try
		{
			num = OpsCom.AllocNlsCtx(out m_nlsCtx);
		}
		catch (Exception ex)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.TraceExceptionInfo(ex);
			}
			throw;
		}
		if (num != 0)
		{
			OracleException.HandleError(num, null, IntPtr.Zero, null);
		}
	}

	public object Clone()
	{
		OracleGlobalization oracleGlobalization = new OracleGlobalization();
		oracleGlobalization.m_oraGlob.m_calendar = m_oraGlob.m_calendar;
		oracleGlobalization.m_oraGlob.m_clientCharacterSet = m_oraGlob.m_clientCharacterSet;
		oracleGlobalization.m_oraGlob.m_comparison = m_oraGlob.m_comparison;
		oracleGlobalization.m_oraGlob.m_currency = m_oraGlob.m_currency;
		oracleGlobalization.m_oraGlob.m_dateFormat = m_oraGlob.m_dateFormat;
		oracleGlobalization.m_oraGlob.m_dateLanguage = m_oraGlob.m_dateLanguage;
		oracleGlobalization.m_oraGlob.m_dualCurrency = m_oraGlob.m_dualCurrency;
		oracleGlobalization.m_oraGlob.m_isoCurrency = m_oraGlob.m_isoCurrency;
		oracleGlobalization.m_oraGlob.m_language = m_oraGlob.m_language;
		oracleGlobalization.m_oraGlob.m_lengthSemantics = m_oraGlob.m_lengthSemantics;
		oracleGlobalization.m_oraGlob.m_nCharConvExcp = m_oraGlob.m_nCharConvExcp;
		oracleGlobalization.m_oraGlob.m_numericCharacters = m_oraGlob.m_numericCharacters;
		oracleGlobalization.m_oraGlob.m_sort = m_oraGlob.m_sort;
		oracleGlobalization.m_oraGlob.m_territory = m_oraGlob.m_territory;
		oracleGlobalization.m_oraGlob.m_timeStampFormat = m_oraGlob.m_timeStampFormat;
		oracleGlobalization.m_oraGlob.m_timeStampTZFormat = m_oraGlob.m_timeStampTZFormat;
		oracleGlobalization.m_oraGlob.m_timeZone = m_oraGlob.m_timeZone;
		return oracleGlobalization;
	}

	public static OracleGlobalization GetClientInfo()
	{
		int num = 0;
		lock (s_lockObj)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ENTRY) OracleGlobalization::GetClientInfo(1)\n");
			}
			OracleGlobalization oracleGlobalization = new OracleGlobalization();
			IntPtr pOraGlob = IntPtr.Zero;
			try
			{
				num = OpsCom.GetClientInfo(ref pOraGlob);
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
					OracleException.HandleError(num, null, IntPtr.Zero, null);
				}
			}
			Marshal.PtrToStructure(pOraGlob, (object)oracleGlobalization.m_oraGlob);
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleGlobalization::GetClientInfo(1)\n");
			}
			return oracleGlobalization;
		}
	}

	public static void GetClientInfo(OracleGlobalization oraGlob)
	{
		int num = 0;
		lock (s_lockObj)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ENTRY) OracleGlobalization::GetClientInfo(2)\n");
			}
			IntPtr pOraGlob = IntPtr.Zero;
			try
			{
				num = OpsCom.GetClientInfo(ref pOraGlob);
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
					OracleException.HandleError(num, null, IntPtr.Zero, null);
				}
			}
			Marshal.PtrToStructure(pOraGlob, (object)oraGlob.m_oraGlob);
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleGlobalization::GetClientInfo(2)\n");
			}
		}
	}

	public static OracleGlobalization GetThreadInfo()
	{
		int num = 0;
		lock (s_lockObj)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ENTRY) OracleGlobalization::GetThreadInfo(1)\n");
			}
			OracleGlobalization oracleGlobalization = new OracleGlobalization();
			IntPtr pOraGlob = IntPtr.Zero;
			try
			{
				num = OpsCom.GetThreadInfo(ref pOraGlob);
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
					OracleException.HandleError(num, null, IntPtr.Zero, null);
				}
			}
			Marshal.PtrToStructure(pOraGlob, (object)oracleGlobalization.m_oraGlob);
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleGlobalization::GetThreadInfo(1)\n");
			}
			return oracleGlobalization;
		}
	}

	public static void GetThreadInfo(OracleGlobalization oraGlob)
	{
		int num = 0;
		lock (s_lockObj)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ENTRY) OracleGlobalization::GetThreadInfo(2)\n");
			}
			IntPtr pOraGlob = IntPtr.Zero;
			try
			{
				num = OpsCom.GetThreadInfo(ref pOraGlob);
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
					OracleException.HandleError(num, null, IntPtr.Zero, null);
				}
			}
			Marshal.PtrToStructure(pOraGlob, (object)oraGlob.m_oraGlob);
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleGlobalization::GetThreadInfo(2)\n");
			}
		}
	}

	public static void SetThreadInfo(OracleGlobalization oraGlob)
	{
		int num = 0;
		lock (s_lockObj)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ENTRY) OracleGlobalization::SetThreadInfo()\n");
			}
			try
			{
				num = OpsCom.SetThreadInfo(oraGlob.m_oraGlob);
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
					OracleException.HandleError(12705, null, IntPtr.Zero, null);
				}
			}
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleGlobalization::SetThreadInfo()\n");
			}
		}
	}

	public void Dispose()
	{
		lock (m_lockObj)
		{
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (ENTRY) OracleGlobalization::Dispose()\n");
			}
			if (!m_disposed)
			{
				m_disposed = true;
				if (m_nlsCtx != IntPtr.Zero)
				{
					try
					{
						OpsCom.FreeNlsCtx(m_nlsCtx);
						m_nlsCtx = IntPtr.Zero;
					}
					catch (Exception ex)
					{
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.TraceExceptionInfo(ex);
						}
					}
				}
			}
			GC.SuppressFinalize(this);
			if (OraTrace.m_TraceLevel != 0)
			{
				OraTrace.Trace(1u, " (EXIT)  OracleGlobalization::Dispose()\n");
			}
		}
	}

	internal void ValidateSetting(int paramKey, string paramVal)
	{
		if ((paramVal == null || paramVal.Length == 0) && paramKey != 17)
		{
			OracleException.HandleError(1741, null, IntPtr.Zero, null);
		}
		int num = 0;
		try
		{
			num = OpsCom.ValidateGlobInfo(m_nlsCtx, paramKey, paramVal);
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
				OracleException.HandleError(12705, null, IntPtr.Zero, null);
			}
		}
	}

	~OracleGlobalization()
	{
		Dispose();
	}
}
