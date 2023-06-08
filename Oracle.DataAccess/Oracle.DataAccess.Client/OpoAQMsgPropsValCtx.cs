using System;
using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct OpoAQMsgPropsValCtx
{
	internal int isDirty;

	internal int isNull;

	internal int msgState;

	internal int deliveryMode;

	internal int year;

	internal int month;

	internal int day;

	internal int hour;

	internal int min;

	internal int sec;

	internal int dequeueAttempts;

	internal int delay;

	internal int expiration;

	internal int priority;

	internal IntPtr pRecipients;

	internal int numRecipients;

	internal IntPtr pOrigMsgId;

	internal int origMsgIdLen;

	internal IntPtr pOrigMsgIdObject;
}
