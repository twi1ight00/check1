using System;
using System.Collections;
using System.IO;
using System.Text;
using Aspose.Words;
using Aspose.Words.Lists;
using x5794c252ba25e723;
using xd2754ae26d400653;

namespace x583d72a986201ed7;

internal class xe4fc4f6e9a5490eb
{
	private readonly DocumentBuilder x3b4f374f0aa4599b;

	private readonly xf6f0ba749cb43b9a x91f8cff35aaa235f;

	private x754c5b323f287239 xc731ef3a4be83ee0;

	private readonly Hashtable xe95c935b90f2b211;

	private double xc234945b958dc332;

	internal xe4fc4f6e9a5490eb(Stream stream, Document document, Encoding encoding)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (document == null)
		{
			throw new ArgumentNullException("document");
		}
		if (encoding == null)
		{
			throw new ArgumentNullException("encoding");
		}
		x3b4f374f0aa4599b = new DocumentBuilder(document);
		x91f8cff35aaa235f = new xf6f0ba749cb43b9a(new StreamReader(stream, encoding));
		xe95c935b90f2b211 = new Hashtable();
		xc234945b958dc332 = -1.0;
	}

	internal void x06b0e25aa6ad68a9()
	{
		x754c5b323f287239[] array = x91f8cff35aaa235f.x06b0e25aa6ad68a9();
		x754c5b323f287239[] array2 = array;
		foreach (x754c5b323f287239 x31e6518f5e08db6c in array2)
		{
			x6210059f049f0d48(x31e6518f5e08db6c);
		}
		xd60ab6c6e61b3011();
	}

	internal double x046a8a5776020954(int x274ed464afca013e)
	{
		if (xc234945b958dc332 < 0.0)
		{
			xc234945b958dc332 = xaee1c0588639d742("w");
		}
		return xc234945b958dc332 * (double)x274ed464afca013e;
	}

	private void x6210059f049f0d48(x754c5b323f287239 x31e6518f5e08db6c)
	{
		if (x31e6518f5e08db6c.x17dbe5d89173a7b0 != null)
		{
			x43a6cd780ee8d38f(x31e6518f5e08db6c);
		}
		else
		{
			xd60ab6c6e61b3011();
			xd4df9c523ca4bca1(x31e6518f5e08db6c);
		}
		xc731ef3a4be83ee0 = x31e6518f5e08db6c;
	}

	private void xd4df9c523ca4bca1(x754c5b323f287239 x31e6518f5e08db6c)
	{
		string text = x31e6518f5e08db6c.x633d57e35b6715a4();
		if (text != "")
		{
			x3b4f374f0aa4599b.ParagraphFormat.LeftIndent = x046a8a5776020954(x31e6518f5e08db6c.xc0741c7ff92cf1aa);
			x3b4f374f0aa4599b.ParagraphFormat.FirstLineIndent = x046a8a5776020954(x31e6518f5e08db6c.xc7d7e186f0ace1e0);
			x3b4f374f0aa4599b.Writeln(text);
		}
		else
		{
			x3b4f374f0aa4599b.Writeln();
		}
	}

	private void xd60ab6c6e61b3011()
	{
		if (xc731ef3a4be83ee0 != null && xc731ef3a4be83ee0.x17dbe5d89173a7b0 != null)
		{
			x3b4f374f0aa4599b.ListFormat.RemoveNumbers();
		}
	}

	private double xaee1c0588639d742(string xb41faee6912a2313)
	{
		Font font = x3b4f374f0aa4599b.Font;
		xe39d06eee35dd23d xe39d06eee35dd23d = x3b4f374f0aa4599b.Document.FontInfos.x26ee10d60756aeab.x491f5a7224612753(font.Name, (float)font.Size, font.xfa47517dba72fd20);
		return xe39d06eee35dd23d.xee2b4ba51feab3ca(xb41faee6912a2313);
	}

	private void x43a6cd780ee8d38f(x754c5b323f287239 x31e6518f5e08db6c)
	{
		xc1119a77de9a33ec(x31e6518f5e08db6c);
		x95b28e376f7db460(x31e6518f5e08db6c.x17dbe5d89173a7b0);
		double num = x046a8a5776020954(x31e6518f5e08db6c.x17dbe5d89173a7b0.x9d3073c05209cae2);
		double num2 = xaee1c0588639d742(x31e6518f5e08db6c.x17dbe5d89173a7b0.xf9ad6fb78355fe13 + "  ");
		x3b4f374f0aa4599b.ParagraphFormat.LeftIndent = num + num2;
		x3b4f374f0aa4599b.ParagraphFormat.FirstLineIndent = 0.0 - num2;
		x3b4f374f0aa4599b.Writeln(x31e6518f5e08db6c.x633d57e35b6715a4());
	}

	private void xc1119a77de9a33ec(x754c5b323f287239 x31e6518f5e08db6c)
	{
		List list = ((x31e6518f5e08db6c.x17dbe5d89173a7b0.x6d1fa38f0423e11b != null) ? ((List)xe95c935b90f2b211[x31e6518f5e08db6c.x17dbe5d89173a7b0.x6d1fa38f0423e11b]) : ((x31e6518f5e08db6c.x17dbe5d89173a7b0.x283d882f626f891a == null) ? x3b4f374f0aa4599b.Document.Lists.xcf5f82306ceb0bff(x31e6518f5e08db6c.x17dbe5d89173a7b0.xdcf9aad638f5cf6f.xf80e8a13daebb8f4 ? x902c8ac86fbaf048.x7e86ac926e2dc940 : x902c8ac86fbaf048.xabed123f43874357) : ((List)xe95c935b90f2b211[x31e6518f5e08db6c.x17dbe5d89173a7b0.x283d882f626f891a])));
		xe95c935b90f2b211.Add(x31e6518f5e08db6c, list);
		x3b4f374f0aa4599b.ListFormat.List = list;
	}

	private void x95b28e376f7db460(x02344c8663635c5d x5b0e49f41ffdca3a)
	{
		x3b4f374f0aa4599b.ListFormat.ListLevelNumber = x5b0e49f41ffdca3a.xb303fade4d4c5a50;
		x3b4f374f0aa4599b.ListFormat.ListLevel.NumberStyle = x5b0e49f41ffdca3a.xdcf9aad638f5cf6f.x41e9d5f906ecbec1;
		x3b4f374f0aa4599b.ListFormat.ListLevel.NumberFormat = x5b0e49f41ffdca3a.xdcf9aad638f5cf6f.x54f56e2c447eeea2(x5b0e49f41ffdca3a.xb303fade4d4c5a50);
	}
}
