using System;
using System.Collections;
using System.Text;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x4f4df92b75ba3b67;

internal class x556ab440136df1a4 : x264ba3b7aca691be
{
	private bool xd2d4f73790533c35;

	private string xda1176a66dc18c6e;

	private readonly SortedList x49d994525cad56d9 = new SortedList();

	private readonly SortedList x1055f7cfb1ff8b02 = new xd345c73dd1b16b74();

	internal x556ab440136df1a4(x4882ae789be6e2ef context)
		: base(context)
	{
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		writer.x7a67b9beb30292d6(this);
		writer.xafb7e6f79ed43681();
		if (xd2d4f73790533c35)
		{
			writer.xa4dc0ad8886e23a2("/SigFlags", 2);
		}
		writer.xa4dc0ad8886e23a2("/Fields", xdfd72f4a6d1b7833());
		x54ee0eb7efc094e0(writer, "/DR");
		writer.x693a8d6d020474f2();
		writer.x5155d7b9dab28280();
		foreach (xf5cfd3a839b4ec91 value in x49d994525cad56d9.GetValueList())
		{
			value.WriteToPdf(writer);
		}
	}

	internal void x54ee0eb7efc094e0(xcd769e39c0788209 xbdfb620b7167944b, string x39f0dc9473601e5a)
	{
		if (x1055f7cfb1ff8b02.Count == 0)
		{
			return;
		}
		xbdfb620b7167944b.x6210059f049f0d48(x39f0dc9473601e5a);
		xbdfb620b7167944b.xafb7e6f79ed43681();
		xbdfb620b7167944b.x6210059f049f0d48("/Font");
		xbdfb620b7167944b.xafb7e6f79ed43681();
		foreach (object value in x1055f7cfb1ff8b02.GetValueList())
		{
			x264ba3b7aca691be x264ba3b7aca691be2 = (x264ba3b7aca691be)value;
			xbdfb620b7167944b.xa4dc0ad8886e23a2($"/{x264ba3b7aca691be2.xd160355ae2167ae9}", x264ba3b7aca691be2.x899a2110a8a35fda);
		}
		xbdfb620b7167944b.x693a8d6d020474f2();
		xbdfb620b7167944b.x693a8d6d020474f2();
	}

	public void xd6b6ed77479ef68c(x8fd773b74dcec1bc xccb63ca5f63dc470, xd6b2a42851fedfba xc4975f037b5dbaff)
	{
		xd6b6ed77479ef68c(new x7f4e95d2dea4acb5(xc4975f037b5dbaff, xccb63ca5f63dc470));
	}

	public void xd6b6ed77479ef68c(xf8b7d3491a4bc1b0 xccb63ca5f63dc470, xd6b2a42851fedfba xc4975f037b5dbaff)
	{
		xd6b6ed77479ef68c(new x15725d3105cd19bf(xc4975f037b5dbaff, xccb63ca5f63dc470));
	}

	public void xd6b6ed77479ef68c(x3a68442d168cdd44 xccb63ca5f63dc470, xd6b2a42851fedfba xc4975f037b5dbaff)
	{
		xd6b6ed77479ef68c(new x9b3cbfc2d1158bdb(xc4975f037b5dbaff, xccb63ca5f63dc470));
	}

	public void x7062f8071787723c(xf70c7bfb09d6c003 xc75f5deb35d00b12)
	{
		xd2d4f73790533c35 = true;
		xda1176a66dc18c6e = xc75f5deb35d00b12.x899a2110a8a35fda;
	}

	private void xd6b6ed77479ef68c(xf5cfd3a839b4ec91 xb2de7d13f1ea7519)
	{
		xb2de7d13f1ea7519.x839aef5610889ada.x565402b98bcb072a(xb2de7d13f1ea7519);
		if (x49d994525cad56d9.ContainsKey(xb2de7d13f1ea7519.x759aa16c2016a289))
		{
			throw new ArgumentException("Names must be unique.");
		}
		x49d994525cad56d9.Add(xb2de7d13f1ea7519.x759aa16c2016a289, xb2de7d13f1ea7519);
	}

	private string xdfd72f4a6d1b7833()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("[ ");
		foreach (xf5cfd3a839b4ec91 value in x49d994525cad56d9.GetValueList())
		{
			stringBuilder.Append(value.x899a2110a8a35fda);
			stringBuilder.Append(" ");
		}
		if (xd2d4f73790533c35)
		{
			stringBuilder.Append(xda1176a66dc18c6e);
			stringBuilder.Append(" ");
		}
		stringBuilder.Append(" ]");
		return stringBuilder.ToString();
	}

	internal xba2f911354958a68 x9059a3203c8fc855(xe39d06eee35dd23d x26094932cf7a9139)
	{
		xba2f911354958a68 xba2f911354958a69 = x8cedcaa9a62c6e39.x2107de3fc2a21893.xc81af5eb660ec310(x26094932cf7a9139);
		x1055f7cfb1ff8b02[xba2f911354958a69.xd160355ae2167ae9] = xba2f911354958a69;
		return xba2f911354958a69;
	}
}
