using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Client;

[SuppressUnmanagedCodeSecurity]
internal class OpsCon
{
	private OpsCon()
	{
	}

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsConOpenUsingExtProcContext")]
	public unsafe static extern int OpenUsingExtProcContext(IntPtr ociExtProcContext, ref IntPtr opsConCtx, ref IntPtr opsErrCtx, OpoConValCtx* pOpoConValCtx, ref OpoConRefCtx pOpoConRefCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsConOpen")]
	public unsafe static extern int Open(ref IntPtr opsConCtx, ref IntPtr opsErrCtx, OpoConValCtx* pOpoConValCtx, ref OpoConRefCtx pOpoConRefCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConRegisterFailoverCallback")]
	public static extern int RegisterFailoverCallback(IntPtr opsConCtx, IntPtr opsErrCtx, OraFailoverCallback_FPtr cb);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConAllocValCtx")]
	public unsafe static extern int AllocValCtx(ref OpoConValCtx* pOpoConValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConFreeValCtx")]
	public unsafe static extern int FreeValCtx(ref OpoConValCtx* pOpoConValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConClose")]
	public unsafe static extern int Close(ref IntPtr opsConCtx, ref IntPtr opsErrCtx, OpoConValCtx* pOpoConValCtx, OpoConRefCtx pOpoConRefCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConDispose")]
	public unsafe static extern int Dispose(ref IntPtr opsConCtx, ref IntPtr opsErrCtx, ref OpoConValCtx* pOpoConValCtx, OpoConRefCtx pOpoConRefCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConEnlist")]
	public unsafe static extern int Enlist(IntPtr opsConCtx, OpoConValCtx* pOpoConValCtx, OpoConRefCtx pOpoConRefCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConPromote")]
	public unsafe static extern int Promote(IntPtr opsConCtx, OpoConValCtx* pOpoConValCtx, OpoConRefCtx pOpoConRefCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConCommitPromotedTxn")]
	public unsafe static extern int CommitPromotedTxn(IntPtr opsConCtx, OpoConValCtx* pOpoConValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConAbortPromotedTxn")]
	public unsafe static extern int AbortPromotedTxn(IntPtr opsConCtx, OpoConValCtx* pOpoConValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConDelistPromotedTxn")]
	public static extern int DelistPromotedTxn(IntPtr opsConCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConCheckConStatus")]
	public static extern int CheckConStatus(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, int bDistTxnEnd, ref int bAlive, int bFromPool, int bValidateCon);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConOpenProxyAuthUserSession")]
	public unsafe static extern int OpenProxyAuthUserSession(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, OpoConValCtx* pOpoConValCtx, OpoConRefCtx pOpoConRefCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConCloseProxyAuthUserSession")]
	public unsafe static extern int CloseProxyAuthUserSession(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, OpoConValCtx* pOpoConValCtx, OpoConRefCtx pOpoConRefCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsConSetSessionInfo")]
	public static extern int SetSessionInfo(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, IntPtr pSql);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConGetSessionInfo")]
	public static extern int GetSessionInfo(IntPtr pOpsConCtx, ref IntPtr intPtrOraGlob);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConPurgeStatementCache")]
	public unsafe static extern int PurgeStatementCache(IntPtr opsConCtx, IntPtr opsErrCtx, OpoConValCtx* pOpoConValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConSetStatementCacheSize")]
	public unsafe static extern int SetStatementCacheSize(IntPtr opsConCtx, ref IntPtr opsErrCtx, OpoConValCtx* pOpoConValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsConStartupDB")]
	public unsafe static extern int StartupDB(IntPtr opsConCtx, IntPtr opsErrCtx, OpoConValCtx* pOpoConValCtx, string pfile, out int errorNumber);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsConShutdownDB")]
	public unsafe static extern int ShutdownDB(IntPtr opsConCtx, IntPtr opsErrCtx, OpoConValCtx* pOpoConValCtx, out int errorNumber);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConAddRef")]
	public static extern int AddRef(IntPtr pOpsConCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConRelRef")]
	public static extern void RelRef(ref IntPtr ppOpsConCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConSetClientId")]
	public static extern int SetClientId(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, OpoConRefCtx pOpoConRefCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConSetModuleName")]
	public static extern int SetModuleName(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, OpoConRefCtx pOpoConRefCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConSetActionName")]
	public static extern int SetActionName(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, OpoConRefCtx pOpoConRefCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConSetClientInfo")]
	public static extern int SetClientInfo(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, OpoConRefCtx pOpoConRefCtx);

	[DllImport("kernel32.dll")]
	public static extern IntPtr CreateSemaphore(IntPtr lpSemaphoreAttributes, int InitialCount, int MaximumCount, string pName);

	[DllImport("kernel32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReleaseSemaphore(IntPtr hSemaphore, int ReleaseCount, ref int PreviousCount);

	[DllImport("kernel32.dll")]
	public static extern int WaitForSingleObject(IntPtr hObject, int milliSeconds);

	[DllImport("kernel32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CloseHandle(IntPtr hObject);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConInitSubscrEnv")]
	public static extern int InitSubscrEnv(OraHACallbackFuncPtr HACallback, OraRLBCallbackFuncPtr RLBCallback);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConRegisterCallbacks")]
	public unsafe static extern int RegisterCallbacks(ref IntPtr opsConCtx, ref IntPtr opsErrCtx, OpoConValCtx* pOpoConValCtx, ref OpoConRefCtx pOpoConRefCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConUnRegisterCallbacks")]
	public unsafe static extern int UnRegisterCallbacks(ref IntPtr opsConCtx, ref IntPtr opsErrCtx, OpoConValCtx* pOpoConValCtx, ref OpoConRefCtx pOpoConRefCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConReRegisterCallbacks")]
	public unsafe static extern int ReRegisterCallbacks(ref IntPtr opsConCtx, ref IntPtr opsErrCtx, OpoConValCtx* pOpoConValCtx, ref OpoConRefCtx pOpoConRefCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConGetAttributes")]
	public static extern int GetAttributes(IntPtr pOpsConCtx, IntPtr pOpsErrCtx, OpoConRefCtx pOpoConRefCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConFlushCache")]
	public static extern int FlushCache(IntPtr pOpsConCtx, IntPtr pOpsErrCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsConSetFetchArrayGetFuncPtr")]
	public static extern int SetFetchArrayGetFuncPtr(IntPtr opsConCtx, FetchArrayGetCallbackFuncPtr pFetchArrayGetFuncPtr);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsConEncrypt")]
	public static extern int Encrypt(out IntPtr encrypted, out int encryptedLen, string original, int originalLen);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsConDecrypt")]
	public static extern int Decrypt(out IntPtr decryptPwdBuffer, out int originalLen, IntPtr encrypted, int encryptedLen);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsConClearDecryptBuff")]
	public static extern int ClearDecryptBuff(ref IntPtr decryptBuffer, int length);

	[DllImport("MSVCRT.DLL", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "memcpy")]
	public static extern IntPtr MemCopy(IntPtr dest, IntPtr src, int count);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsConGetMaxBytesPerNChar")]
	public static extern int GetMaxBytesPerNChar(IntPtr opsConCtx);
}
