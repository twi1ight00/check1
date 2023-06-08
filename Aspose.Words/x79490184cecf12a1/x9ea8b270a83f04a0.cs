using Aspose.Words;
using x1495530f35d79681;
using x909757d9fd2dd6ae;
using xfc5388ad7dff404f;

namespace x79490184cecf12a1;

internal class x9ea8b270a83f04a0 : x3c85359e1389ad43
{
	private readonly xa2f1c3dcbd86f20a x9fb0e9c0b1bdc4b3;

	internal xa2f1c3dcbd86f20a x398b3bd0acd94b61 => x9fb0e9c0b1bdc4b3;

	internal x9ea8b270a83f04a0(xa2f1c3dcbd86f20a part)
		: this(part, null, WarningSource.Docx)
	{
	}

	internal x9ea8b270a83f04a0(xa2f1c3dcbd86f20a part, IWarningCallback warningCallback, WarningSource warningSource)
		: base(part.xb8a774e0111d0fbe, warningCallback, warningSource)
	{
		x9fb0e9c0b1bdc4b3 = part;
	}

	protected override LineStyle ReadLineStyle()
	{
		return xc62574be95c1c918.xf5a81b2292447eb3(base.xd2f68ee6f47e9dfb);
	}
}
