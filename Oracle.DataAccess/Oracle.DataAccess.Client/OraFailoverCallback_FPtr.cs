using System;

namespace Oracle.DataAccess.Client;

internal delegate int OraFailoverCallback_FPtr(IntPtr svchp, IntPtr envhp, IntPtr fo_ctx, int fo_type, int fo_event);
