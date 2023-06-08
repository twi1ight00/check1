using ns99;

namespace ns101;

internal class Class4477 : Class4476
{
	public override void Save()
	{
		Class4412 @class = (Class4412)class4408_0;
		if (!@class.UsedGlyphs.Contains(Class4508.class4508_0))
		{
			@class.UsedGlyphs.Add(Class4508.class4508_0);
		}
		Class4505 class2 = new Class4505();
		Class4505 class3 = new Class4505();
		foreach (Class4506 usedGlyph in @class.UsedGlyphs)
		{
			class2.Clear();
			((Class4411)@class.OriginalFont).vmethod_0(usedGlyph, class2);
			if (class2.Count <= 0)
			{
				continue;
			}
			foreach (Class4506 item in class2)
			{
				if (!@class.UsedGlyphs.Contains(item) && !class3.Contains(item))
				{
					class3.Add(item);
				}
			}
		}
		foreach (Class4506 item2 in class3)
		{
			if (!@class.UsedGlyphs.Contains(item2))
			{
				@class.UsedGlyphs.Add(item2);
			}
		}
		base.Save();
	}
}
