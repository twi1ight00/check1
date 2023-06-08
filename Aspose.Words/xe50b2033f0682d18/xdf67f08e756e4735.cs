using x4f4df92b75ba3b67;
using x66dd9eaee57cfba4;

namespace xe50b2033f0682d18;

internal class xdf67f08e756e4735 : xa4f1070b7f6449f0
{
	private readonly xcd986872cf3bcf68 xe65db51216614d6f;

	private readonly x3ced9c2339e31e7e xe2a0e5ad744b4e4a;

	internal xdf67f08e756e4735(x4882ae789be6e2ef context, xba2f911354958a68 parentFont, xcb3d00e64f2216e5 fontData, xcd986872cf3bcf68 fontSubset)
		: base(context, parentFont, fontData)
	{
		xe65db51216614d6f = fontSubset;
		if (!fontSubset.IsFullFontEmbedded && context.x5ba9693d4c3c102e)
		{
			xe2a0e5ad744b4e4a = new x3ced9c2339e31e7e(context);
		}
	}

	protected override void WriteDictionaryEntries(x4f40d990d5bf81a6 writer)
	{
		base.WriteDictionaryEntries(writer);
		if (xe2a0e5ad744b4e4a != null)
		{
			writer.xa4dc0ad8886e23a2("/CIDSet", xe2a0e5ad744b4e4a.x899a2110a8a35fda);
		}
	}

	protected override void WriteUsedObjects(x4f40d990d5bf81a6 writer)
	{
		base.WriteUsedObjects(writer);
		if (xe2a0e5ad744b4e4a != null)
		{
			xe2a0e5ad744b4e4a.xf75ec8ea0d9dfa32(xe65db51216614d6f.x8f0b229fb69d4269);
			xe2a0e5ad744b4e4a.WriteToPdf(writer);
		}
	}
}
