using System.Collections;
using System.IO;
using Aspose.Words.Tables;
using x9db5f2e5af3d596e;

namespace x639ad3f66698fe1b;

internal class xaa6547801b39e385
{
	private readonly x21f0d20d41203be1 x8cedcaa9a62c6e39;

	private readonly x86b9c9ee57a1b517 x21fd293cf49cfe49;

	private readonly x0140989e604b5540 x0138a000010d311d;

	private readonly MemoryStream x5da75fe92ae76df2;

	private readonly x43845b10d17efb74 xed1a9293cc2e8c0e;

	private readonly Stack x6d8007d4311207cd = new Stack();

	private int xe55137f2e976e51a;

	private Row x7a562511e420a2c2;

	private int xd0a6a9fd816476f3;

	private bool x39d214d87c51f1c7;

	internal bool xb11c814ff34244eb => x772764427592d4bb > 1;

	internal int x772764427592d4bb => x6d8007d4311207cd.Count;

	private xbfd162a6d47f59a4 xe1410f585439c7d4 => x8cedcaa9a62c6e39.xe1410f585439c7d4;

	internal xaa6547801b39e385(x21f0d20d41203be1 context)
	{
		x8cedcaa9a62c6e39 = context;
		x21fd293cf49cfe49 = new x86b9c9ee57a1b517(x8cedcaa9a62c6e39);
		x0138a000010d311d = new x0140989e604b5540(x8cedcaa9a62c6e39);
		x5da75fe92ae76df2 = new MemoryStream();
		xed1a9293cc2e8c0e = new x0462f8ecc269ec42(x5da75fe92ae76df2);
	}

	internal void x5e3f44647fcfb8fc(Row xa806b754814b9ae0)
	{
		if (!xb11c814ff34244eb)
		{
			x7a562511e420a2c2 = xa806b754814b9ae0;
			xd0a6a9fd816476f3 = xe55137f2e976e51a;
			xf7e15d9938798f3d();
		}
	}

	internal void xbdbbc98113b6b783(Row xa806b754814b9ae0)
	{
		if (xb11c814ff34244eb)
		{
			xf11889b309a14c60(xa806b754814b9ae0);
		}
		else if (!x8cedcaa9a62c6e39.xf57de0fd37d5e97d.ExportCompactSize)
		{
			x88d26dff7c2fef3c();
		}
		xe55137f2e976e51a++;
	}

	internal void xbe8a2ee35737311e()
	{
		if (x39d214d87c51f1c7)
		{
			x88d26dff7c2fef3c();
			x39d214d87c51f1c7 = false;
		}
	}

	internal void x35ee6077b3c26c9f(Table x1ec770899c98a268)
	{
		x6d8007d4311207cd.Push(x1ec770899c98a268.x7ffcb3c8df4c42b3());
		xe55137f2e976e51a = 0;
		x39d214d87c51f1c7 = false;
	}

	internal void xee69ee8848255726()
	{
		x6d8007d4311207cd.Pop();
		xe55137f2e976e51a = xd0a6a9fd816476f3;
		x39d214d87c51f1c7 = x772764427592d4bb == 1;
	}

	private void xf7e15d9938798f3d()
	{
		x5da75fe92ae76df2.SetLength(0L);
		x5da75fe92ae76df2.Position = 0L;
		xe1410f585439c7d4.xbb7550bbb62a218c();
		x43845b10d17efb74 x42f4c234c = xe1410f585439c7d4.x42f4c234c9358072;
		xe1410f585439c7d4.x42f4c234c9358072 = xed1a9293cc2e8c0e;
		xf11889b309a14c60(x7a562511e420a2c2);
		xe1410f585439c7d4.xbb7550bbb62a218c();
		xe1410f585439c7d4.x42f4c234c9358072 = x42f4c234c;
		xe1410f585439c7d4.x42f4c234c9358072.x8d5c460c7f55c721(x5da75fe92ae76df2);
	}

	private void x88d26dff7c2fef3c()
	{
		xe1410f585439c7d4.xbb7550bbb62a218c();
		xe1410f585439c7d4.x42f4c234c9358072.x8d5c460c7f55c721(x5da75fe92ae76df2);
	}

	private void xf11889b309a14c60(Row xa806b754814b9ae0)
	{
		xe1410f585439c7d4.x4d14ee33f46b5913("\\trowd");
		xe1410f585439c7d4.x4d14ee33f46b5913("\\irow", xe55137f2e976e51a);
		xe1410f585439c7d4.x4d14ee33f46b5913("\\irowband", xe55137f2e976e51a);
		xe1410f585439c7d4.xb8aea59edd4060ce("\\lastrow", xa806b754814b9ae0.IsLastRow);
		xedb0eb766e25e0c9 xedb0eb766e25e0c = xa806b754814b9ae0.xedb0eb766e25e0c9;
		x21fd293cf49cfe49.x6210059f049f0d48(xedb0eb766e25e0c);
		int num = (int)x6d8007d4311207cd.Peek() + xedb0eb766e25e0c.x90aab2cbd2f48623;
		xe1410f585439c7d4.x4d14ee33f46b5913("\\trleft", num);
		for (Cell cell = xa806b754814b9ae0.FirstCell; cell != null; cell = cell.xb2e852052ab1c1be)
		{
			x0138a000010d311d.x6210059f049f0d48(cell);
			num += cell.xf8cef531dae89ea3.xdc1bf80853046136;
			xe1410f585439c7d4.x4d14ee33f46b5913("\\cellx", num);
		}
	}
}
