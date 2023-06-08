using Aspose;

namespace x4f4df92b75ba3b67;

internal class xa4f1070b7f6449f0 : x264ba3b7aca691be
{
	private readonly xba2f911354958a68 x742ebec19329e227;

	private readonly xcb3d00e64f2216e5 xfcd01e1d46e15910;

	internal xa4f1070b7f6449f0(x4882ae789be6e2ef context, xba2f911354958a68 parentFont, xcb3d00e64f2216e5 fontData)
		: base(context)
	{
		x742ebec19329e227 = parentFont;
		xfcd01e1d46e15910 = fontData;
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		x51cf2b3953f93541(writer);
		WriteUsedObjects(writer);
	}

	private void x51cf2b3953f93541(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.x7a67b9beb30292d6(this);
		xbdfb620b7167944b.xafb7e6f79ed43681();
		WriteDictionaryEntries(xbdfb620b7167944b);
		xbdfb620b7167944b.x693a8d6d020474f2();
		xbdfb620b7167944b.x5155d7b9dab28280();
	}

	protected virtual void WriteDictionaryEntries(x4f40d990d5bf81a6 writer)
	{
		writer.xa4dc0ad8886e23a2("/Type", "/FontDescriptor");
		writer.xa4dc0ad8886e23a2("/FontName", $"/{x742ebec19329e227.xd47a98a7600d6b65}");
		writer.xa4dc0ad8886e23a2("/StemV", 80);
		writer.xa4dc0ad8886e23a2("/Descent", x742ebec19329e227.xc9f7bec53c29c691);
		writer.xa4dc0ad8886e23a2("/Ascent", x742ebec19329e227.x3f80ed349f729542);
		writer.xa4dc0ad8886e23a2("/CapHeight", x742ebec19329e227.x912ee4c8583acc0f);
		writer.xa4dc0ad8886e23a2("/Flags", x742ebec19329e227.x586b7652ac7cefe0);
		writer.xa4dc0ad8886e23a2("/ItalicAngle", x742ebec19329e227.xb874556d20cb64ce);
		writer.xa4dc0ad8886e23a2("/FontBBox", x742ebec19329e227.x3560592fd0c9f0ea);
		xfcd01e1d46e15910.xb98ce8f1ed7517e8(writer);
	}

	[JavaThrows(true)]
	protected virtual void WriteUsedObjects(x4f40d990d5bf81a6 writer)
	{
	}
}
