using Aspose.Words.Fields;

namespace xfbd1009a0cbb9842;

internal class x6b27a7334c00da94 : x57af31d8c74e631c
{
	internal x6b27a7334c00da94(bool applyToContainingField, bool removeParentParagraph)
		: base(applyToContainingField, removeParentParagraph)
	{
	}

	protected override void PerformCore(Field field)
	{
		field.Remove();
	}
}
