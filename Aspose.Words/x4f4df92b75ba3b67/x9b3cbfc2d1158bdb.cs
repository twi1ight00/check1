using System.Collections;
using System.Drawing;
using System.IO;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;

namespace x4f4df92b75ba3b67;

internal class x9b3cbfc2d1158bdb : xf5cfd3a839b4ec91
{
	private const byte x8fe2a14d9866d140 = 17;

	private const int x81b0fd81823804fb = 10;

	private const int xe63933cda5b3cd03 = 2;

	private readonly int x4574aea041dd835f;

	private readonly ArrayList x82b70567a5f68f41;

	private x8b1c15f4cec97314 x4796207f7c273e47;

	private readonly xe39d06eee35dd23d x4884fd3dc186019b;

	private readonly x26d9ecb4bdf0456d xe9a14b923f876940 = x26d9ecb4bdf0456d.x89fffa2751fdecbe;

	internal x9b3cbfc2d1158bdb(xd6b2a42851fedfba hostPage, x3a68442d168cdd44 source)
		: base(hostPage, source)
	{
		x4574aea041dd835f = source.xd2f68ee6f47e9dfb;
		x82b70567a5f68f41 = source.xe0d5f9fb50308841;
		x4884fd3dc186019b = source.xddffcb24e864cfcc;
		xaf43c45bad04ab9b();
		x109a5b5bb236ce20();
	}

	protected override x4f47636462fbf23a GetFieldType()
	{
		return x4f47636462fbf23a.xc51cd05daa1637c8;
	}

	protected override int GetFieldSpecificBitFlag()
	{
		return 0x20000 | base.GetFieldSpecificBitFlag();
	}

	protected override void WriteFieldSpecificDictionaryEntries(x4f40d990d5bf81a6 writer)
	{
		writer.x6210059f049f0d48("/Opt [");
		for (int i = 0; i < x82b70567a5f68f41.Count; i++)
		{
			writer.x50f5dc167b3269a7((string)x82b70567a5f68f41[i]);
			writer.xe7b920de107da0c7();
		}
		writer.x6210059f049f0d48("]");
		writer.x94aba205302527e1("/V", (string)x82b70567a5f68f41[x4574aea041dd835f]);
		writer.xe8d35135edabe74c(xf5cfd3a839b4ec91.x3b6357dc4bfa7820, x1183e679f352c392(x4884fd3dc186019b, xe9a14b923f876940), xf9aaf5b23109516c: false);
		writer.x6210059f049f0d48(xf5cfd3a839b4ec91.x2f83359518b6600c);
		writer.xafb7e6f79ed43681();
		writer.x241b3c2e8c3aaa86(xf5cfd3a839b4ec91.x22c40f2843e791e9);
		writer.x6210059f049f0d48(x4796207f7c273e47.x899a2110a8a35fda);
		writer.x693a8d6d020474f2();
	}

	protected override void WriteFieldSpecificObjects(x4f40d990d5bf81a6 writer)
	{
		x4796207f7c273e47.WriteToPdf(writer);
	}

	private void xaf43c45bad04ab9b()
	{
		float num = base.x2727839aafc09868.Right + 10f;
		float num2 = base.x2727839aafc09868.Bottom + 2f;
		if (num2 > x0a1aee6bd4aee6ae.xb0f146032f47c24e)
		{
			num2 = x0a1aee6bd4aee6ae.xb0f146032f47c24e;
		}
		if (num > x0a1aee6bd4aee6ae.xdc1bf80853046136)
		{
			num = x0a1aee6bd4aee6ae.xdc1bf80853046136;
		}
		base.x2727839aafc09868 = RectangleF.FromLTRB(base.x2727839aafc09868.Left, base.x2727839aafc09868.Top, num, num2);
	}

	private void x109a5b5bb236ce20()
	{
		x4796207f7c273e47 = new x8b1c15f4cec97314(x8cedcaa9a62c6e39);
		x4796207f7c273e47.x2727839aafc09868 = new RectangleF(0f, 0f, base.x2727839aafc09868.Width, base.x2727839aafc09868.Height);
		x4796207f7c273e47.xe36c96d8c564b382 = xfaf5bd9df7f945ac();
	}

	private MemoryStream xfaf5bd9df7f945ac()
	{
		MemoryStream memoryStream = new MemoryStream();
		xcd769e39c0788209 xbdfb620b7167944b = new xcd769e39c0788209(memoryStream);
		xf5cfd3a839b4ec91.x47cfb90fdeb56514(xbdfb620b7167944b, x4796207f7c273e47.x2727839aafc09868);
		xf5cfd3a839b4ec91.xc135895eb632d865(xbdfb620b7167944b);
		xf5cfd3a839b4ec91.xab68d26edfba16ac(xbdfb620b7167944b, xe9a14b923f876940);
		xba2f911354958a68 x26094932cf7a = xa36a62f286dd4144(xbdfb620b7167944b, x4884fd3dc186019b);
		xf5cfd3a839b4ec91.x39605bb716707926(xbdfb620b7167944b, base.x2727839aafc09868.Height - x4884fd3dc186019b.x53531537bb3331e6 - 1f);
		xf5cfd3a839b4ec91.x6bf9042ca9bedd31(xbdfb620b7167944b, 0f, 0f);
		xf5cfd3a839b4ec91.xd0e5bb3ded9994f0(xbdfb620b7167944b, (string)x82b70567a5f68f41[x4574aea041dd835f], x26094932cf7a);
		xf5cfd3a839b4ec91.x972b7e15e64526e4(xbdfb620b7167944b);
		return memoryStream;
	}
}
