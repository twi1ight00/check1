using System.IO;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;

namespace xfbd1009a0cbb9842;

internal class x94fd89996b5d6f25 : x5dc2b4bc740c9563
{
	private readonly Stream x7492bd16e718c2a0;

	private readonly MergeFieldImageDimension x42e5c99daad7b47e;

	private readonly MergeFieldImageDimension xc870c20d40920a8c;

	internal x94fd89996b5d6f25(Field field, Stream imageStream, MergeFieldImageDimension imageWidth, MergeFieldImageDimension imageHeight, x57af31d8c74e631c cleanupAction)
		: base(field, cleanupAction)
	{
		x7492bd16e718c2a0 = imageStream;
		x42e5c99daad7b47e = imageWidth;
		xc870c20d40920a8c = imageHeight;
	}

	protected override void PerformCore()
	{
		base.xd1b40af56a8385d4.x6edce55dcd2d335b.xdd53735657fe1b6b();
		DocumentBuilder documentBuilder = new DocumentBuilder(base.x2c8c6741422a1298);
		documentBuilder.MoveTo(base.xd1b40af56a8385d4.End);
		if (x7492bd16e718c2a0 != null)
		{
			Shape shape = documentBuilder.InsertImage(x7492bd16e718c2a0);
			x7492bd16e718c2a0.Close();
			if (MergeFieldImageDimension.x2d5c1249b31d3c86(x42e5c99daad7b47e) || MergeFieldImageDimension.x2d5c1249b31d3c86(xc870c20d40920a8c))
			{
				ImageSize imageSize = shape.ImageData.ImageSize;
				double x9b0739496f8b = MergeFieldImageDimension.x3ae2efb7fb57cc6a(x42e5c99daad7b47e, imageSize.WidthPoints);
				double x4d5aabc7a55b12ba = MergeFieldImageDimension.x3ae2efb7fb57cc6a(xc870c20d40920a8c, imageSize.HeightPoints);
				shape.x2a1d93e8568f66ed(x9b0739496f8b, x4d5aabc7a55b12ba);
			}
		}
		base.xd1b40af56a8385d4.x6edce55dcd2d335b.xac51c2571643df46();
	}
}
