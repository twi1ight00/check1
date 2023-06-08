using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Client;

[SuppressUnmanagedCodeSecurity]
internal class OpsCom
{
	public const string ORAOPS_DLL = "OraOps11w.dll";

	private OpsCom()
	{
	}

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsComGetClientInfo")]
	public static extern int GetClientInfo(ref IntPtr pOraGlob);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsComGetThreadInfo")]
	public static extern int GetThreadInfo(ref IntPtr pOraGlob);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsComSetThreadInfo")]
	public static extern int SetThreadInfo(OraGlobStruct pGlob);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "OpsComValidateGlobInfo")]
	public static extern int ValidateGlobInfo(IntPtr pNLSCtx, int paramName, string paramValue);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsComRefreshGlobInfo")]
	public static extern int RefreshGlobInfo(IntPtr pNLSCtx, out IntPtr pOraGlob, int type);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsComAllocNlsCtx")]
	public static extern int AllocNlsCtx(out IntPtr nlsCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsComFreeNlsCtx")]
	public static extern int FreeNlsCtx(IntPtr nlsCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsComExtProcFlag")]
	public static extern int GetExtProcFlag();

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsComExf")]
	public static extern void Exf();

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsParseTnsnamesFile")]
	public static extern int ParseTnsnamesFile(out string tnsAliases, out string port, out string server, out string service, out string protocol);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsGetSystemMemoryInfo")]
	public static extern int GetSystemMemoryInfo(ref long availUsableMem, ref long totalPhysMem);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsGetAvailPhysMemory")]
	public static extern int GetAvailPhysMemory(ref long availPhysMem);
}
