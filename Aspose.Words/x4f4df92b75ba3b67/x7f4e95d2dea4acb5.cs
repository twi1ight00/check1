using System.Drawing;
using System.IO;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x4f4df92b75ba3b67;

internal class x7f4e95d2dea4acb5 : xf5cfd3a839b4ec91
{
	private const byte x5847ec22d06d9b69 = 12;

	private const byte x4af74e4004c84190 = 25;

	private readonly bool xe7ec03a0dc51638b;

	private readonly string x5c8bd07ae90b8968;

	private readonly xe39d06eee35dd23d x4884fd3dc186019b;

	private readonly x26d9ecb4bdf0456d xe9a14b923f876940;

	private readonly int x049c595f8783548a;

	private readonly string x9913fbaf0b91e577;

	private readonly bool xab258248e0fd6545;

	private x8b1c15f4cec97314 x4796207f7c273e47;

	internal string x08c5d9f4b0653c8d
	{
		get
		{
			if (!xe7ec03a0dc51638b)
			{
				return x5c8bd07ae90b8968;
			}
			return x9913fbaf0b91e577;
		}
	}

	internal x7f4e95d2dea4acb5(xd6b2a42851fedfba hostPage, x8fd773b74dcec1bc source)
		: base(hostPage, source)
	{
		xe7ec03a0dc51638b = source.x172ec8314cc6064b;
		x5c8bd07ae90b8968 = source.xd2f68ee6f47e9dfb;
		x4884fd3dc186019b = source.xddffcb24e864cfcc;
		xe9a14b923f876940 = source.xca02aeead29a2213;
		x049c595f8783548a = source.x7e9904b269e29b39;
		x9913fbaf0b91e577 = source.x08c5d9f4b0653c8d;
		xab258248e0fd6545 = source.xe3ccff5629a1e888;
		x109a5b5bb236ce20();
	}

	protected override x4f47636462fbf23a GetFieldType()
	{
		return x4f47636462fbf23a.x470ecea91abfd1aa;
	}

	protected override int GetFieldSpecificBitFlag()
	{
		int num = x0899f65feab10be1() << 12;
		num |= (xe7ec03a0dc51638b ? 1 : 0) << 25;
		return num | base.GetFieldSpecificBitFlag();
	}

	protected override void WriteFieldSpecificDictionaryEntries(x4f40d990d5bf81a6 writer)
	{
		if (x049c595f8783548a != 0)
		{
			writer.xa4dc0ad8886e23a2("/MaxLen", x049c595f8783548a);
		}
		if (xe7ec03a0dc51638b)
		{
			if (x5c8bd07ae90b8968 != "")
			{
				writer.x94aba205302527e1("/RV", x5c8bd07ae90b8968);
				writer.x94aba205302527e1("/DS", "font: 12pt Arial");
			}
		}
		else
		{
			writer.xe8d35135edabe74c(xf5cfd3a839b4ec91.x3b6357dc4bfa7820, x1183e679f352c392(x4884fd3dc186019b, xe9a14b923f876940), xf9aaf5b23109516c: false);
			if (x5c8bd07ae90b8968 != "")
			{
				writer.x94aba205302527e1(xf5cfd3a839b4ec91.x4d7648648a11f443, x5c8bd07ae90b8968);
			}
		}
		writer.x94aba205302527e1("/V", x08c5d9f4b0653c8d);
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

	private void x109a5b5bb236ce20()
	{
		x4796207f7c273e47 = new x8b1c15f4cec97314(x8cedcaa9a62c6e39);
		x4796207f7c273e47.x2727839aafc09868 = new RectangleF(0f, 0f, base.x2727839aafc09868.Width, base.x2727839aafc09868.Height);
		x4796207f7c273e47.xe36c96d8c564b382 = xfaf5bd9df7f945ac();
	}

	private int x0899f65feab10be1()
	{
		if (!xab258248e0fd6545)
		{
			return 0;
		}
		return 1;
	}

	private MemoryStream xfaf5bd9df7f945ac()
	{
		MemoryStream memoryStream = new MemoryStream();
		xcd769e39c0788209 xbdfb620b7167944b = new xcd769e39c0788209(memoryStream);
		float num = base.x2727839aafc09868.Height - x4884fd3dc186019b.x53531537bb3331e6 - 1f;
		xf5cfd3a839b4ec91.xc135895eb632d865(xbdfb620b7167944b);
		xf5cfd3a839b4ec91.xab68d26edfba16ac(xbdfb620b7167944b, xe9a14b923f876940);
		xba2f911354958a68 x26094932cf7a = xa36a62f286dd4144(xbdfb620b7167944b, x4884fd3dc186019b);
		xf5cfd3a839b4ec91.x39605bb716707926(xbdfb620b7167944b, num);
		string[] array = x9913fbaf0b91e577.Split(x8fd773b74dcec1bc.x4e0562cd625a1408);
		for (int i = 0; i < array.Length; i++)
		{
			if (num < 0f)
			{
				break;
			}
			if (x0d299f323d241756.x5959bccb67bbf051(array[i]))
			{
				xf5cfd3a839b4ec91.x6bf9042ca9bedd31(xbdfb620b7167944b, 0f, (i == 0) ? 0f : (0f - x4884fd3dc186019b.x53531537bb3331e6));
				xf5cfd3a839b4ec91.xd0e5bb3ded9994f0(xbdfb620b7167944b, array[i], x26094932cf7a);
			}
			num -= x4884fd3dc186019b.x53531537bb3331e6;
		}
		xf5cfd3a839b4ec91.x972b7e15e64526e4(xbdfb620b7167944b);
		return memoryStream;
	}
}
