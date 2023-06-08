using System;
using System.Drawing;
using System.IO;
using Aspose;
using x5794c252ba25e723;

namespace x4f4df92b75ba3b67;

internal class x4d8917c8186e8cb2 : x264ba3b7aca691be
{
	private readonly MemoryStream xa49cef274042e702;

	private readonly xcd769e39c0788209 x9b287b671d592594;

	private xf22a449df9af52b7 xd17d322dc360752d;

	internal Stream x9e418ad9a56d1cf5 => xa49cef274042e702;

	internal xcd769e39c0788209 x5aa326f374b3d0ef => x9b287b671d592594;

	protected xf22a449df9af52b7 x98065e804f332442 => xd17d322dc360752d;

	public x4d8917c8186e8cb2(x4882ae789be6e2ef context)
		: base(context)
	{
		xa49cef274042e702 = new MemoryStream();
		x9b287b671d592594 = new xcd769e39c0788209(xa49cef274042e702);
	}

	internal void x6210059f049f0d48(string xb41faee6912a2313)
	{
		x9b287b671d592594.x6210059f049f0d48(xb41faee6912a2313);
	}

	public void x25d0efbd7848eeb3(string xb41faee6912a2313)
	{
		x9b287b671d592594.x25d0efbd7848eeb3(xb41faee6912a2313);
	}

	internal void x25d0efbd7848eeb3(string x5786461d089b10a0, string xec7dcb687e97a7d7)
	{
		x9b287b671d592594.x25d0efbd7848eeb3(x5786461d089b10a0, xec7dcb687e97a7d7);
	}

	internal void x25d0efbd7848eeb3(string x5786461d089b10a0, string xec7dcb687e97a7d7, string x6ffd1fa6ed343720)
	{
		x9b287b671d592594.x25d0efbd7848eeb3(x5786461d089b10a0, xec7dcb687e97a7d7, x6ffd1fa6ed343720);
	}

	internal void x241b3c2e8c3aaa86(string xb41faee6912a2313)
	{
		x9b287b671d592594.x241b3c2e8c3aaa86(xb41faee6912a2313);
	}

	internal void x241b3c2e8c3aaa86(string x5786461d089b10a0, string xec7dcb687e97a7d7)
	{
		x9b287b671d592594.x6210059f049f0d48(x5786461d089b10a0, xec7dcb687e97a7d7);
		x9b287b671d592594.xe7b920de107da0c7();
	}

	internal void x241b3c2e8c3aaa86(string x5786461d089b10a0, string xec7dcb687e97a7d7, string x6ffd1fa6ed343720)
	{
		x9b287b671d592594.x6210059f049f0d48(x5786461d089b10a0, xec7dcb687e97a7d7, x6ffd1fa6ed343720);
		x9b287b671d592594.xe7b920de107da0c7();
	}

	internal void x6210059f049f0d48(byte[] x5cafa8d49ea71ea1)
	{
		x6210059f049f0d48(x5cafa8d49ea71ea1, 0, x5cafa8d49ea71ea1.Length);
	}

	internal void x6210059f049f0d48(byte[] x5cafa8d49ea71ea1, int xc0c4c459c6ccbd00, int x10f4d88af727adbc)
	{
		x9b287b671d592594.x6210059f049f0d48(x5cafa8d49ea71ea1, xc0c4c459c6ccbd00, x10f4d88af727adbc);
	}

	internal void xc351d479ff7ee789(byte xbcea506a33cf9111)
	{
		x9b287b671d592594.xc351d479ff7ee789(xbcea506a33cf9111);
	}

	internal void xfedf842bc95b0880(PointF x2f7096dac971d6ec)
	{
		x9b287b671d592594.x6210059f049f0d48(x2f7096dac971d6ec.X);
		x9b287b671d592594.xe7b920de107da0c7();
		x9b287b671d592594.x6210059f049f0d48(x2f7096dac971d6ec.Y);
	}

	internal void xdfffe8e2cf9a7455(float[] x0788cd5a9865fc16)
	{
		x9b287b671d592594.xdfffe8e2cf9a7455(x0788cd5a9865fc16);
	}

	internal void x1f64811c8bfde335(x54366fa5f75a02f7 xa801ccff44b0c7eb, string x9c9eac3a36336680)
	{
		x9b287b671d592594.xd2768134348972b1(xa801ccff44b0c7eb);
		x9b287b671d592594.xe7b920de107da0c7();
		x9b287b671d592594.x6210059f049f0d48(x9c9eac3a36336680);
		x9b287b671d592594.xe7b920de107da0c7();
	}

	public void x3612a596c28e1b59(int xbcea506a33cf9111)
	{
		x9b287b671d592594.x3612a596c28e1b59(xbcea506a33cf9111);
	}

	[JavaThrows(true)]
	internal virtual void x0a2e1f2c2da67e52(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		writer.x7a67b9beb30292d6(this);
		writer.xafb7e6f79ed43681();
		xd17d322dc360752d = new xf22a449df9af52b7(x8cedcaa9a62c6e39);
		x0a2e1f2c2da67e52(writer);
		writer.xa4dc0ad8886e23a2("/Length", xd17d322dc360752d.x899a2110a8a35fda);
		x4c746eafc29e5079 x4c746eafc29e5080 = xf57599e513eb82be();
		x4c746eafc29e5080?.x0a2e1f2c2da67e52(writer);
		writer.x693a8d6d020474f2();
		writer.x25d0efbd7848eeb3("stream");
		Stream stream = writer.x9e418ad9a56d1cf5;
		x5babd393421dd91d x5babd393421dd91d2 = xbfbb1719d4106af2();
		if (x5babd393421dd91d2 != null)
		{
			stream = x5babd393421dd91d2.x228ae9311abe60ed(stream);
		}
		if (x4c746eafc29e5080 != null)
		{
			stream = x4c746eafc29e5080.xdd66d940acb3d138(stream);
		}
		long length = stream.Length;
		stream.Write(xa49cef274042e702.GetBuffer(), 0, (int)xa49cef274042e702.Length);
		long num = stream.Length - length;
		writer.x25d0efbd7848eeb3();
		writer.x6210059f049f0d48("endstream");
		writer.x5155d7b9dab28280();
		xd17d322dc360752d.x1be93eed8950d961 = (int)num;
		xd17d322dc360752d.WriteToPdf(writer);
	}

	internal virtual x4c746eafc29e5079 xf57599e513eb82be()
	{
		if (xa49cef274042e702.Length < 200)
		{
			return null;
		}
		return x8cedcaa9a62c6e39.x73979cef1002ed01.x5f45bae3337a9d27 switch
		{
			xa673dc764ff4eb9a.x021301649c58465b => new x9e0a988568b64551(), 
			xa673dc764ff4eb9a.x79eafe89940e5b0e => new xa73d31814e085e6d(), 
			xa673dc764ff4eb9a.x4d0b9d4447ba7566 => null, 
			xa673dc764ff4eb9a.x67749da60288d66c => new x558f25bc598c7617(), 
			_ => throw new InvalidOperationException("Unknown text compression filter type."), 
		};
	}
}
