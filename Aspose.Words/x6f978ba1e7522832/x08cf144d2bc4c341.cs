using Aspose.Words;
using Aspose.Words.Tables;
using x9db5f2e5af3d596e;
using xa604c4d210ae0581;

namespace x6f978ba1e7522832;

internal class x08cf144d2bc4c341
{
	private readonly int x64a52bf9b524db1d;

	private readonly int xd9ef7ff717ca930d;

	private readonly bool xe39682656207f056;

	internal int x4e12a7dca3260989 => x64a52bf9b524db1d;

	internal int x34bbd3e888646999 => xd9ef7ff717ca930d;

	internal bool xdb8d101b58051732 => xe39682656207f056;

	internal x08cf144d2bc4c341(int tableLeft, int revisedTableLeft, bool writeExpanded)
	{
		x64a52bf9b524db1d = tableLeft;
		xd9ef7ff717ca930d = revisedTableLeft;
		xe39682656207f056 = writeExpanded;
	}

	internal x08cf144d2bc4c341(Document doc, Table table)
	{
		xe39682656207f056 = false;
		if (doc.OriginalLoadFormat == LoadFormat.Doc || doc.OriginalLoadFormat == LoadFormat.Dot)
		{
			xedb0eb766e25e0c9 xedb0eb766e25e0c = table.Rows[0].xedb0eb766e25e0c9;
			if (doc.Styles.x1976fb6958cf7237(xedb0eb766e25e0c.x8301ab10c226b0c2, x988fcf605f8efa7e: false) is TableStyle x13eeaa19b4289a)
			{
				xe39682656207f056 |= xa188b1d3d8eee54e.xbd743ca2a349e5c4(x13eeaa19b4289a);
			}
			TableStyleOptions x4be85718a3fc5cac = xedb0eb766e25e0c.x4be85718a3fc5cac;
			xe39682656207f056 |= (x4be85718a3fc5cac & TableStyleOptions.RowBands) == 0 || (x4be85718a3fc5cac & TableStyleOptions.ColumnBands) == 0;
		}
		else
		{
			xe39682656207f056 = true;
		}
		x64a52bf9b524db1d = table.x7ffcb3c8df4c42b3();
		xd9ef7ff717ca930d = 0;
	}
}
