using System;
using System.Runtime.InteropServices;
using System.Security;
using Oracle.DataAccess.Types;

namespace Oracle.DataAccess.Client;

[SuppressUnmanagedCodeSecurity]
internal class OpsAQ
{
	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQConvertByteArray")]
	public static extern int ConvertByteArray(IntPtr tgtIntPtr, byte[] srcByteArr, int len);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQEnqueue")]
	public unsafe static extern int Enqueue(IntPtr pOpsConCtx, IntPtr opsErrCtx, string queue_name, byte[] RawPayload, OpoAQEnqOptionsValCtx* pOpoAQEnqOptionsValCtx, OpoAQMsgPropsValCtx* pOpoAQMsgPropsValCtx, OpoAQMsgPropsRefCtx pOpoAQMsgPropsRefCtx, OpoAQMsgValCtx* pOpoAQMsgValCtx, ref IntPtr ppOCIAQEnqOptions, int enqOptsInfo, ref IntPtr ppOCIAQMsgProperties);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQDequeue")]
	public unsafe static extern int Dequeue(IntPtr pOpsConCtx, IntPtr opsErrCtx, string queue_name, byte[] pMsgId, OpoAQDeqOptionsValCtx* pOpoAQDeqOptionsValCtx, OpoAQDeqOptionsRefCtx pOpoAQDeqOptionsRefCtx, OpoAQMsgPropsValCtx* pOpoAQMsgPropsValCtx, ref OpoAQMsgPropsRefCtx opoAQMsgPropsRefCtx, OpoAQMsgValCtx* pOpoAQMsgValCtx, ref IntPtr ppOCIAQDeqOptions, int deqOptsInfo, ref IntPtr ppOCIAQMsgProperties);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQDequeueArray")]
	public unsafe static extern int DequeueArray(IntPtr pOpsConCtx, IntPtr opsErrCtx, string queue_name, ref int dequeueCount, byte[] pMsgId, OpoAQDeqOptionsValCtx* pOpoAQDeqOptionsValCtx, OpoAQDeqOptionsRefCtx pOpoAQDeqOptionsRefCtx, ref OpoAQMsgPropsValCtx* pOpoAQMsgPropsValCtx, ref OpoAQMsgValCtx* pOpoAQMsgValCtx, ref IntPtr ppOCIAQDeqOptions, int deqOptsInfo, out OpoAQDequeueArrayPtrs* pOpoAQDequeueArrayPtrs);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQDequeueArrayGetInfo")]
	public unsafe static extern int DequeueArrayGetInfo(IntPtr pOpsConCtx, IntPtr opsErrCtx, int dequeueCount, OpoAQMsgPropsValCtx* pOpoAQMsgPropsValCtx, IntPtr[] pOpoAQMsgPropsRefCtx, OpoAQMsgValCtx* pOpoAQMsgValCtx, ref OpoAQDequeueArrayPtrs* pOpoAQDequeueArrayPtrs);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQFreeDeqArrPtrs")]
	public unsafe static extern int FreeDeqArrPtrs(ref OpoAQDequeueArrayPtrs* pOpoAQDequeueArrayPtrs);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsAQFreeObject")]
	public static extern int FreeObject(IntPtr pOpsConCtx, IntPtr opsErrCtx, IntPtr obj);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQAllocValCtx")]
	public unsafe static extern int AllocValCtx(out OpoAQMsgPropsValCtx* pOpoAQMsgPropsValCtx, out OpoAQMsgValCtx* pOpoAQMsgValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQAllocEnqOptValCtx")]
	public unsafe static extern int AllocEnqOptValCtx(out OpoAQEnqOptionsValCtx* pOpoAQEnqOptionsValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQAllocDeqOptValCtx")]
	public unsafe static extern int AllocDeqOptValCtx(out OpoAQDeqOptionsValCtx* pOpoAQDeqOptionsValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQFreeValCtx")]
	public unsafe static extern int FreeValCtx(ref OpoAQMsgPropsValCtx* pOpoAQMsgPropsValCtx, ref OpoAQMsgValCtx* pOpoAQMsgValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQFreeEnqOptValCtx")]
	public unsafe static extern int FreeEnqOptValCtx(ref OpoAQEnqOptionsValCtx* pOpoAQEnqOptionsValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQFreeDeqOptValCtx")]
	public unsafe static extern int FreeDeqOptValCtx(ref OpoAQDeqOptionsValCtx* pOpoAQDeqOptionsValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQListen")]
	public static extern int Listen(IntPtr pOpsConCtx, IntPtr opsErrCtx, ref OpoAQAgentRefCtx[] opoAQAgentRefCtx, int numAgents, int waitTime, out IntPtr pOpoAQAgentRet);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQFreeAQAgentCtx")]
	public static extern int FreeAQAgentCtx(ref IntPtr pOpoAQAgentRefCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQFreeCachedDesc")]
	public static extern int FreeCachedDesc(ref IntPtr ppOCIAQEnqOptions, ref IntPtr ppOCIAQDeqOptions, ref IntPtr ppOCIAQMsgProperties);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQRegisterNotificationCallback")]
	public static extern int RegisterNotificationCallback(OnAQNTFNCallback onAQNTFNOpsCallback);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQAllocSubscrHandle")]
	public static extern int AllocSubscrHandle(IntPtr pOpsConCtx, IntPtr opsEnvCtx, [In][Out] IntPtr[] ppOCISubscription, [In][Out] IntPtr[] ppCtxNTFN, int size);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQSubscriptionRegister")]
	public static extern int SubscriptionRegister(IntPtr opsEnvCtx, IntPtr pOpsConCtx, IntPtr opsErrCtx, IntPtr[] ppOCISubscription, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] subscriptionName, int size, int isNotifiedOnce, int isPersistent, uint timeout, uint groupingInterval, int groupingNotificationEnabled, int groupingType, [In][Out] IntPtr[] ppCtxNTFN);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQProcessNtfn")]
	public unsafe static extern int ProcessNtfn(IntPtr pSubscrhp, IntPtr pDesc, IntPtr pCtxNTFN, OpoAQMsgValCtx* pOpoAQMsgValCtx, OpoAQMsgPropsValCtx* pOpoAQMsgPropsValCtx, ref OpoAQMsgPropsRefCtx opoAQMsgPropsRefCtx, ref OracleAQNotificationType flags, ref int availableMsgs, out OpoAQMsgIdValCtx* pOpoAQMsgIdValCtx, ref int num_msgid, ref OpoAQNtfnDataRefCtx opoAQNtfnDataRefCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQSetMsgPropsCtx")]
	public unsafe static extern int SetMsgPropsCtx(IntPtr pOpsConCtx, IntPtr pOpsEnvCtx, IntPtr opsErrCtx, IntPtr pOCIAQMsgProps, OpoAQMsgPropsValCtx* pOpoAQMsgPropsValCtx, ref OpoAQMsgPropsRefCtx opoAQMsgPropsRefCtx, int count);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQSubscriptionUnRegister")]
	public static extern int SubscriptionUnRegister(IntPtr pOpsConCtx, IntPtr opsErrCtx, int size, IntPtr[] ppOCISubscription);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQFreeCtxNTFN")]
	public static extern int FreeCtxNTFN([In][Out] IntPtr[] ppCtxNTFN, int size);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQPrepareAgentArray")]
	public static extern int PrepareAgentArray(IntPtr pOpsConCtx, IntPtr opsErrCtx, ref OpoAQAgentRefCtx[] opoAQAgentRefCtx, int numAgents, out IntPtr ppAQAgent);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQAllocValCtxArray")]
	public unsafe static extern int AllocValCtxArray(out OpoAQMsgPropsValCtx* pOpoAQMsgPropsValCtx, out OpoAQMsgValCtx* pOpoAQMsgValCtx, int numElements);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQEnqueueArray")]
	public unsafe static extern int EnqueueArray(IntPtr pOpsConCtx, IntPtr opsErrCtx, string queue_name, ref int numElements, IntPtr[] pRawPayload, OpoAQEnqOptionsValCtx* pOpoAQEnqOptionsValCtx, OpoAQMsgPropsValCtx* pOpoAQMsgPropsValCtx, IntPtr[] pOpoAQMsgPropsRefCtx, OpoAQMsgValCtx* pOpoAQMsgValCtx, ref IntPtr ppOCIAQEnqOptions, int enqOptsInfo);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQAllocMsgPropsRefCtxArray")]
	public static extern int AllocMsgPropsRefCtxArray([In][Out] IntPtr[] ppOpoAQMsgPropsRefCtx, int numElements);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQFreeMsgPropsRefCtxArray")]
	public static extern int FreeMsgPropsRefCtxArray([In][Out] IntPtr[] ppOpoAQMsgPropsRefCtx, int numElements);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQFreeValCtxArray")]
	public unsafe static extern int FreeValCtxArray(ref OpoAQMsgPropsValCtx* pOpoAQMsgPropsValCtx, ref OpoAQMsgValCtx* pOpoAQMsgValCtx, int numElements);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQFreeMsgIdValCtxArray")]
	public unsafe static extern int FreeMsgIdValCtxArray(ref OpoAQMsgIdValCtx* pOpoAQMsgIdValCtx);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpsAQFreeUdtValCtxArray")]
	public unsafe static extern int FreeUdtValCtxArray(OpoUdtValCtx* pOpoUdtValCtx, int numElements);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQAllocDescriptor")]
	public static extern int AllocDescriptor(IntPtr pOpsConCtx, IntPtr opsErrCtx, out IntPtr ppOCIAQMsgProperties, out IntPtr ppOCIAQEnqOptions, out IntPtr ppOCIAQDeqOptions);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQCacheTest")]
	public static extern int CacheTest(IntPtr pOpsConCtx, IntPtr opsErrCtx, IntPtr pOCIAQMsgProperties, IntPtr ppOCIAQEnqOptions, IntPtr ppOCIAQDeqOptions);

	[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "OpsAQNonCacheTest")]
	public static extern int NonCacheTest(IntPtr pOpsConCtx, IntPtr opsErrCtx);
}
