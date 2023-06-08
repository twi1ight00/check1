using Aspose.Words;
using Aspose.Words.Fields;

namespace xfbd1009a0cbb9842;

internal class xd5801a931e010963 : x5dc2b4bc740c9563
{
	private readonly string xd52b25f7f77979ad;

	internal xd5801a931e010963(Field field, string message)
		: base(field)
	{
		xd52b25f7f77979ad = message;
	}

	protected override void PerformCore()
	{
		base.xd1b40af56a8385d4.x6edce55dcd2d335b.xdd53735657fe1b6b();
		DocumentBuilder documentBuilder = new DocumentBuilder(base.x2c8c6741422a1298);
		documentBuilder.MoveTo(base.xd1b40af56a8385d4.End);
		documentBuilder.Bold = true;
		documentBuilder.Write(xd52b25f7f77979ad);
		base.xd1b40af56a8385d4.x6edce55dcd2d335b.xac51c2571643df46();
	}
}
