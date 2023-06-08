using System;

namespace Oracle.DataAccess.Client;

internal unsafe delegate void OnAQNTFNCallback(IntPtr pSubscrhp, IntPtr pDesc, IntPtr ctx, OpoAQMsgPropsValCtx* pOpoAQMsgPropsValCtx, OpoAQMsgValCtx* pOpoAQMsgValCtx);
