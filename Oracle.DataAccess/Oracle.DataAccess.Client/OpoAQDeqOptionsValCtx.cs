using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct OpoAQDeqOptionsValCtx
{
	internal int isDirty;

	internal int deqMode;

	internal int msgIdSize;

	internal int deliveryMode;

	internal int navigation;

	internal int visibility;

	internal int wait;
}
