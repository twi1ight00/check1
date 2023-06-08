using xe50b2033f0682d18;

namespace x4f4df92b75ba3b67;

internal class xb187dfc67cf2709f : x264ba3b7aca691be
{
	private readonly x0c228b6673bb03aa x742ebec19329e227;

	private readonly xa4f1070b7f6449f0 x59cf100b5aa4f4e8;

	internal xb187dfc67cf2709f(x4882ae789be6e2ef context, x0c228b6673bb03aa parentFont)
		: base(context)
	{
		x742ebec19329e227 = parentFont;
		x59cf100b5aa4f4e8 = new xdf67f08e756e4735(context, parentFont, parentFont.x25998da3963930e9, parentFont.x968fd3630f239305);
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		writer.x1c638d277561c422(xbfbb1719d4106af2());
		writer.x7a67b9beb30292d6(this);
		writer.xafb7e6f79ed43681();
		writer.xa4dc0ad8886e23a2("/Type", "/Font");
		writer.xa4dc0ad8886e23a2("/Subtype", x23c59e5c955460d4());
		writer.xa4dc0ad8886e23a2("/BaseFont", $"/{x742ebec19329e227.xd47a98a7600d6b65}");
		writer.xa4dc0ad8886e23a2("/CIDToGIDMap", "/Identity");
		writer.xa4dc0ad8886e23a2("/FontDescriptor", x59cf100b5aa4f4e8.x899a2110a8a35fda);
		writer.xa4dc0ad8886e23a2("/DW", 1000);
		writer.xa4dc0ad8886e23a2("/W", x742ebec19329e227.xf498d69a5239cf1b(1000));
		writer.x6210059f049f0d48("/CIDSystemInfo ");
		writer.xafb7e6f79ed43681();
		writer.xe8d35135edabe74c("/Ordering", "Identity", xf9aaf5b23109516c: true);
		writer.xe8d35135edabe74c("/Registry", "Adobe", xf9aaf5b23109516c: true);
		writer.xa4dc0ad8886e23a2("/Supplement", 0);
		writer.x693a8d6d020474f2();
		writer.x693a8d6d020474f2();
		writer.x5155d7b9dab28280();
		x59cf100b5aa4f4e8.WriteToPdf(writer);
	}

	private string x23c59e5c955460d4()
	{
		if (!x742ebec19329e227.x25998da3963930e9.x29f65b3e7616f6b3.xba2310b1d8e576ad)
		{
			return "/CIDFontType2";
		}
		return "/CIDFontType0";
	}
}
