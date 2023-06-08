using System;
using System.Data.Common;
using System.Runtime.Serialization;

namespace Oracle.DataAccess.Client;

[Serializable]
public sealed class OracleException : DbException
{
	private OracleErrorCollection m_errors;

	internal static int OCINoData;

	internal static int CoreError;

	private static int OCIWarning;

	private static int OCIError;

	private static int InternalError;

	public OracleErrorCollection Errors => m_errors;

	public string DataSource => m_errors[0].DataSource;

	public override string Message
	{
		get
		{
			string text = string.Empty;
			if (m_errors != null)
			{
				for (int i = 0; i < m_errors.Count; i++)
				{
					text = text + m_errors[i].Message + "\n";
				}
				return text.TrimEnd('\n');
			}
			return text;
		}
	}

	public string Procedure => m_errors[0].Procedure;

	public override string Source => m_errors[0].Source;

	public int Number => m_errors[0].Number;

	static OracleException()
	{
		OCINoData = 100;
		CoreError = 2;
		OCIWarning = 1;
		OCIError = -1;
		InternalError = -3000;
		if (!OracleInit.bSetDllDirectoryInvoked)
		{
			OracleInit.Initialize();
		}
	}

	internal OracleException(int errCode)
		: this(errCode, string.Empty, string.Empty, string.Empty)
	{
	}

	internal OracleException(int errCode, string dataSrc, string procedure, string errMsg)
	{
		m_errors = new OracleErrorCollection();
		m_errors.Add(new OracleError(errCode, dataSrc, procedure, errMsg));
	}

	internal unsafe OracleException(IntPtr opsErrCtx, OpoSqlValCtx* pOpoSqlValCtx, IntPtr opsConCtx, string dataSrc, string procedure, bool bCheck, Exception innerException)
		: base(null, innerException)
	{
		m_errors = GetOpoErrCtx(opsErrCtx, pOpoSqlValCtx, opsConCtx, dataSrc, procedure);
	}

	internal unsafe static void HandleError(int errCode, OracleConnection conn, string procedure, IntPtr opsErrCtx, OpoSqlValCtx* pOpoSqlValCtx, object src, bool bCheck, Exception innerException)
	{
		HandleErrorHelper(errCode, conn, opsErrCtx, pOpoSqlValCtx, src, procedure, bCheck, innerException);
	}

	internal unsafe static void HandleErrorHelper(int errCode, OracleConnection conn, IntPtr opsErrCtx, OpoSqlValCtx* pOpoSqlValCtx, object src, string procedure, bool bCheck, Exception innerException)
	{
		bool flag = ((pOpoSqlValCtx != null && (pOpoSqlValCtx->mode & 0x80) == 128) ? true : false);
		string dataSrc = ((conn == null) ? string.Empty : conn.DataSource);
		IntPtr intPtr = ((conn != null && conn.m_opoConCtx != null) ? conn.m_opoConCtx.opsConCtx : IntPtr.Zero);
		if (errCode == OCIError || errCode == OCINoData || (flag && errCode == OCIWarning))
		{
			OracleException ex = new OracleException(opsErrCtx, pOpoSqlValCtx, intPtr, dataSrc, procedure, bCheck, innerException);
			if (bCheck && conn != null && conn.m_opoConCtx != null && conn.m_opoConCtx.pOpoConValCtx != null && conn.m_opoConCtx.m_bSelfTuning)
			{
				foreach (OracleError error in ex.Errors)
				{
					if (error.Message.IndexOf("ORA-01000") != -1)
					{
						int num = (int)(0.9f * (float)conn.m_opoConCtx.pOpoConValCtx->StmtCacheSize);
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.Trace(64u, " (TUNING) OracleException::HandleErrorHelper(): Statement Cache Size change suggested from " + conn.m_opoConCtx.pOpoConValCtx->StmtCacheSize + " to " + num + " due to Exception " + error.Message + "\n");
						}
						OraTrace.SetMaxStatementCacheSize(num);
					}
				}
			}
			throw ex;
		}
		if (errCode == OCIWarning)
		{
			if (!(intPtr == IntPtr.Zero))
			{
				OracleException ex2 = new OracleException(opsErrCtx, pOpoSqlValCtx, intPtr, dataSrc, procedure);
				IssueWarning(conn, src, ex2.Errors);
			}
			return;
		}
		if (errCode <= InternalError)
		{
			if (src == null)
			{
				throw new OracleException(errCode, dataSrc, procedure, OpoErrResManager.GetErrorMesg(ErrRes.INT_ERR) + "(" + errCode + ")");
			}
			throw new OracleException(errCode, dataSrc, procedure, OpoErrResManager.GetErrorMesg(ErrRes.INT_ERR) + "(" + errCode + ") [" + src.GetType().FullName + "]");
		}
		if (errCode >= CoreError)
		{
			string oraMesg = GetOraMesg(errCode);
			throw new OracleException(errCode, dataSrc, procedure, oraMesg);
		}
		throw new OracleException(errCode, dataSrc, procedure, string.Empty);
	}

	internal OracleException(OracleErrorCollection oec)
	{
		m_errors = oec;
	}

	private OracleException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		m_errors = (OracleErrorCollection)info.GetValue(GetType().FullName, typeof(OracleErrorCollection));
	}

	internal unsafe OracleException(IntPtr opsErrCtx, OpoSqlValCtx* pOpoSqlValCtx, IntPtr opsConCtx, string dataSrc, string procedure)
	{
		m_errors = GetOpoErrCtx(opsErrCtx, pOpoSqlValCtx, opsConCtx, dataSrc, procedure);
	}

	private unsafe OracleErrorCollection GetOpoErrCtx(IntPtr opsErrCtx, OpoSqlValCtx* pOpoSqlValCtx, IntPtr opsConCtx, string dataSrc, string procedure)
	{
		int num = 0;
		if (opsErrCtx == IntPtr.Zero)
		{
			return null;
		}
		OracleErrorCollection oracleErrorCollection = new OracleErrorCollection();
		OpoErrCtx opoErr = GetOpoErr(opsErrCtx, 0, dataSrc, procedure);
		oracleErrorCollection.Add(new OracleError(opoErr, procedure, dataSrc));
		if (pOpoSqlValCtx != null && opsConCtx != IntPtr.Zero && pOpoSqlValCtx->ErrCnt != 0 && (pOpoSqlValCtx->mode & 0x80) == 128)
		{
			IntPtr[] array = new IntPtr[pOpoSqlValCtx->ErrCnt];
			int[] array2 = new int[pOpoSqlValCtx->ErrCnt];
			try
			{
				if (OpsErr.GetBatchErrCtx(opsErrCtx, opsConCtx, pOpoSqlValCtx->ErrCnt, array, array2) != 0)
				{
					throw new OracleException(ErrRes.INT_ERR_BATCHERRGET_FAIL, dataSrc, procedure, string.Empty);
				}
				for (int i = 0; i < pOpoSqlValCtx->ErrCnt; i++)
				{
					if (!(array[i] == IntPtr.Zero))
					{
						OpoErrCtx opoErr2 = GetOpoErr(array[i], array2[i], dataSrc, procedure);
						oracleErrorCollection.Add(new OracleError(opoErr2, procedure, dataSrc));
					}
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
			finally
			{
				if (array != null)
				{
					for (int j = 0; j < array.Length; j++)
					{
						if (!(array[j] != IntPtr.Zero))
						{
							continue;
						}
						try
						{
							OpsErr.FreeCtx(ref array[j]);
						}
						catch (Exception ex2)
						{
							if (OraTrace.m_TraceLevel != 0)
							{
								OraTrace.TraceExceptionInfo(ex2);
							}
							ref IntPtr reference = ref array[j];
							reference = IntPtr.Zero;
						}
					}
				}
				array = null;
			}
		}
		return oracleErrorCollection;
	}

	private OpoErrCtx GetOpoErr(IntPtr opsErrCtx, int arrayBindIndex, string dataSrc, string procedure)
	{
		int num = 0;
		OpoErrCtx opoErrCtx = new OpoErrCtx();
		try
		{
			num = OpsErr.GetOpoCtx(opsErrCtx, ref opoErrCtx);
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
			throw new OracleException(ErrRes.INT_OCIERRORGET_FAIL, dataSrc, procedure, string.Empty);
		}
		opoErrCtx.m_arrayBindIndex = arrayBindIndex;
		return opoErrCtx;
	}

	public static void IssueWarning(OracleConnection conn, object src, OracleErrorCollection c)
	{
		conn.OnInfoMessage(src, new OracleInfoMessageEventArgs(c));
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(GetType().FullName, m_errors);
	}

	public override string ToString()
	{
		if (base.InnerException != null)
		{
			return GetType().FullName + " " + Message + " " + base.InnerException.Message + StackTrace;
		}
		return GetType().FullName + " " + Message + " " + StackTrace;
	}

	internal unsafe static void HandleError(int errCode, OracleConnection conn, IntPtr opsErrCtx, object src)
	{
		HandleErrorHelper(errCode, conn, opsErrCtx, null, src, string.Empty, bCheck: false);
	}

	internal unsafe static void HandleError(int errCode, OracleConnection conn, IntPtr opsErrCtx, object src, bool bCheck)
	{
		HandleErrorHelper(errCode, conn, opsErrCtx, null, src, string.Empty, bCheck);
	}

	internal unsafe static void HandleError(int errCode, OracleConnection conn, string procedure, IntPtr opsErrCtx, OpoSqlValCtx* pOpoSqlValCtx, object src)
	{
		HandleErrorHelper(errCode, conn, opsErrCtx, pOpoSqlValCtx, src, procedure, bCheck: false);
	}

	internal unsafe static void HandleError(int errCode, OracleConnection conn, string procedure, IntPtr opsErrCtx, OpoSqlValCtx* pOpoSqlValCtx, object src, bool bCheck)
	{
		HandleErrorHelper(errCode, conn, opsErrCtx, pOpoSqlValCtx, src, procedure, bCheck);
	}

	internal unsafe static void HandleErrorHelper(int errCode, OracleConnection conn, IntPtr opsErrCtx, OpoSqlValCtx* pOpoSqlValCtx, object src, string procedure, bool bCheck)
	{
		bool flag = ((pOpoSqlValCtx != null && (pOpoSqlValCtx->mode & 0x80) == 128) ? true : false);
		string dataSrc = ((conn == null) ? string.Empty : conn.DataSource);
		IntPtr intPtr = ((conn != null && conn.m_opoConCtx != null) ? conn.m_opoConCtx.opsConCtx : IntPtr.Zero);
		if (errCode == OCIError || errCode == OCINoData || (flag && errCode == OCIWarning))
		{
			OracleException ex = new OracleException(opsErrCtx, pOpoSqlValCtx, intPtr, dataSrc, procedure);
			if (bCheck && conn != null && conn.m_opoConCtx != null && conn.m_opoConCtx.pOpoConValCtx != null && conn.m_opoConCtx.m_bSelfTuning)
			{
				foreach (OracleError error in ex.Errors)
				{
					if (error.Message.IndexOf("ORA-01000") != -1)
					{
						int num = (int)(0.9f * (float)conn.m_opoConCtx.pOpoConValCtx->StmtCacheSize);
						if (OraTrace.m_TraceLevel != 0)
						{
							OraTrace.Trace(64u, " (TUNING) OracleException::HandleErrorHelper(): Statement Cache Size change suggested from " + conn.m_opoConCtx.pOpoConValCtx->StmtCacheSize + " to " + num + " due to Exception " + error.Message + "\n");
						}
						OraTrace.SetMaxStatementCacheSize(num);
					}
				}
			}
			throw ex;
		}
		if (errCode == OCIWarning)
		{
			if (!(intPtr == IntPtr.Zero))
			{
				OracleException ex2 = new OracleException(opsErrCtx, pOpoSqlValCtx, intPtr, dataSrc, procedure);
				IssueWarning(conn, src, ex2.Errors);
			}
			return;
		}
		if (errCode <= InternalError)
		{
			if (src == null)
			{
				throw new OracleException(errCode, dataSrc, procedure, OpoErrResManager.GetErrorMesg(ErrRes.INT_ERR) + "(" + errCode + ")");
			}
			throw new OracleException(errCode, dataSrc, procedure, OpoErrResManager.GetErrorMesg(ErrRes.INT_ERR) + "(" + errCode + ") [" + src.GetType().FullName + "]");
		}
		if (errCode >= CoreError)
		{
			string oraMesg = GetOraMesg(errCode);
			throw new OracleException(errCode, dataSrc, procedure, oraMesg);
		}
		throw new OracleException(errCode, dataSrc, procedure, string.Empty);
	}

	internal static string GetOraMesg(int errNum, params string[] args)
	{
		string errMsg = "";
		int num = 0;
		try
		{
			num = OpsErr.GetOraMesg(errNum, out errMsg);
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
			errMsg = OpoErrResManager.GetErrorMesg(ErrRes.INT_ERR_CORE_MESG_GET);
		}
		return AddOraMesgPrefix(errNum, errMsg);
	}

	internal static string AddOraMesgPrefix(int errNum, string errMsg)
	{
		return "ORA-" + errNum + ": " + errMsg;
	}
}
