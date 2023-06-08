using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Oracle.DataAccess.Client;

[SuppressUnmanagedCodeSecurity]
internal class OpsLob
{
	private OpsLob()
	{
	}

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsAllocAllLobCtx")]
	public unsafe static extern int AllocAllLobCtx(IntPtr opsConCtx, ref IntPtr opsErrCtx, ref OpoLobValCtx* popsValCtx, ref IntPtr opsLobCtx, int isBFILE, IntPtr pOciLobLoc, int allocLobLoc);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsFreeAllLobCtx")]
	public unsafe static extern int FreeAllLobCtx(IntPtr opsErrCtx, OpoLobValCtx* pOpoLobValCtx, IntPtr popsLobCtx, int isBFILE, int freeLobLoc, int freeOciHandles);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsAllocLobCtx")]
	public static extern int AllocLobCtx(IntPtr opsConCtx, ref IntPtr opsLobCtx, int isBFILE);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsFreeLobCtx")]
	public static extern int FreeLobCtx(IntPtr popsLobCtx, int isBFILE);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsGetLobLocator")]
	public static extern int GetLobLocator(IntPtr opsLobCtx, ref IntPtr ppopsLobCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsLobCheckNClob")]
	public unsafe static extern int LobCheckNClob(IntPtr opsLobCtx, OpoLobValCtx* popoLobValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsLobAppend")]
	public static extern int Append(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsLobCtx_dst, IntPtr opsLobCtx_src);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsLobClose")]
	public static extern int Close(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsLobCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsLobCloseFile")]
	public static extern int CloseFile(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsLobCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsLobCopy")]
	public unsafe static extern int Copy(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsLobCtx_dst, IntPtr opsLobCtx_src, OpoLobValCtx* popoLobValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsLobCreateTemporary")]
	public unsafe static extern int CreateTemporary(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsLobCtx, OpoLobValCtx* popoLobValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsLobErase")]
	public unsafe static extern int Erase(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsLobCtx, OpoLobValCtx* popoLobValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsLobFileExists")]
	public unsafe static extern int FileExists(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsLobCtx, OpoLobValCtx* popoLobValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsLobFileGetName")]
	public unsafe static extern int FileGetName(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsLobCtx, IntPtr directoryName, int* dLength, IntPtr fileName, int* fLength);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsLobFileSetName")]
	public static extern int FileSetName(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsLobCtx, string directoryName, int dLength, string fileName, int fLength);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsLobFreeTemporary")]
	public static extern int FreeTemporary(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsLobCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsLobGetLength")]
	public unsafe static extern int GetLength(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsLobCtx, OpoLobValCtx* popoLobValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsLobGetOptimumChunkSize")]
	public unsafe static extern int GetOptimumChunkSize(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsLobCtx, OpoLobValCtx* popoLobValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsLobIsEqual")]
	public unsafe static extern int IsEqual(IntPtr opsConCtx, IntPtr opsLobCtx1, IntPtr opsLobCtx2, OpoLobValCtx* popoLobValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsLobIsTemporary")]
	public unsafe static extern int IsTemporary(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsLobCtx, OpoLobValCtx* popoLobValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsLobLoadFromFile")]
	public unsafe static extern int LoadFromFile(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsLobCtx_dst, IntPtr opsLobCtx_src, OpoLobValCtx* popoLobValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsLobLocatorAssign")]
	public static extern int LocatorAssign(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsLobCtx_src, IntPtr opsLobCtx_dst);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsLobOpen")]
	public unsafe static extern int Open(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsLobCtx, OpoLobValCtx* popoLobValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsLobOpenFile")]
	public unsafe static extern int OpenFile(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsLobCtx, OpoLobValCtx* popoLobValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsLobRead")]
	public unsafe static extern int Read(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsLobCtx, OpoLobValCtx* popoLobValCtx, IntPtr opoLobRefCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsLobTrim")]
	public unsafe static extern int Trim(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsLobCtx, OpoLobValCtx* popoLobValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsLobWrite")]
	public unsafe static extern int Write(IntPtr opsConCtx, IntPtr opsErrCtx, IntPtr opsLobCtx, OpoLobValCtx* popoLobValCtx, IntPtr opoLobRefCtx);
}
