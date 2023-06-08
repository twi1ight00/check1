using System;
using System.Runtime.InteropServices;

namespace Oracle.DataAccess.Client;

internal delegate void OnChangeCallback([MarshalAs(UnmanagedType.LPWStr)] string id, IntPtr opsErrCtx, IntPtr opsChgNTFNDesc, NotiVal notiVal);
