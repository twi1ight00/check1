using System.IO;
using Aspose.Words.Drawing;
using x011d489fb9df7027;

namespace x5af3f327d745698a;

internal class x8844513eda0a5d2e : x320b28ae68e47317
{
	private readonly string x35c30f877ecc4e7a;

	private readonly string x1356b481f33e39f3;

	private readonly string x5ed39e49ec23297a;

	private readonly bool x6a131679d19aface;

	private readonly x59772113b8075329 xd828dede45258e23;

	internal override x1ba6afab4f42a0ee xcfc06e7ce72a0f0b => x1ba6afab4f42a0ee.x1891c445b78b044b;

	internal string xbd11df86767e08a3 => x35c30f877ecc4e7a;

	internal string x73cf5fe9b727ba52 => x1356b481f33e39f3;

	internal string x1b8a2f0d7dc814f1 => x5ed39e49ec23297a;

	internal bool xe8ae08e6819999f9 => x6a131679d19aface;

	internal x59772113b8075329 x59772113b8075329 => xd828dede45258e23;

	internal x8844513eda0a5d2e(OleFormat oleFormat, byte[] metafileData)
	{
		x93168ed101bbb044 = oleFormat.ProgId;
		x35c30f877ecc4e7a = oleFormat.SourceFullName;
		x1356b481f33e39f3 = oleFormat.SourceItem;
		x6a131679d19aface = oleFormat.AutoUpdate;
		xd828dede45258e23 = ((metafileData != null) ? ((x59772113b8075329)new x103f5cc254d14402(metafileData)) : ((x59772113b8075329)new xd19c736ea89ed0bc()));
	}

	internal x8844513eda0a5d2e(xf0002907cfe93bb4 objectHeader, BinaryReader reader)
	{
		x93168ed101bbb044 = objectHeader.x570858a97a5a2c4a;
		x35c30f877ecc4e7a = objectHeader.xbd11df86767e08a3;
		x1356b481f33e39f3 = objectHeader.x73cf5fe9b727ba52;
		x5ed39e49ec23297a = x9ac0da7388ceac43.x58db9aaa4a730e59(reader);
		reader.ReadInt32();
		int num = reader.ReadInt32();
		x6a131679d19aface = num == 0;
		xd828dede45258e23 = x59772113b8075329.x06b0e25aa6ad68a9(reader);
	}

	internal override void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		xf0002907cfe93bb4 xf0002907cfe93bb5 = new xf0002907cfe93bb4(x1ba6afab4f42a0ee.x1891c445b78b044b, x93168ed101bbb044, x35c30f877ecc4e7a, x1356b481f33e39f3);
		xf0002907cfe93bb5.x6210059f049f0d48(xbdfb620b7167944b);
		x9ac0da7388ceac43.x41d7feb042ee43f7(xbdfb620b7167944b, x5ed39e49ec23297a);
		xbdfb620b7167944b.Write(0);
		xbdfb620b7167944b.Write((!x6a131679d19aface) ? 2 : 0);
		xd828dede45258e23.x6210059f049f0d48(xbdfb620b7167944b);
	}
}
