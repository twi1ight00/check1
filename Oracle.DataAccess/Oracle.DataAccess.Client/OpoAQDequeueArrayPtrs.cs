using System;
using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct OpoAQDequeueArrayPtrs
{
	internal IntPtr ppOCIAQMsgProperties;

	internal IntPtr pInd;

	internal IntPtr ppOCIInd;

	internal IntPtr ppUDTNullInd;

	internal IntPtr deqmesg;

	internal IntPtr ppUDTArray;

	internal IntPtr ppXMLArray;

	internal IntPtr ppMsgIdObject;
}
