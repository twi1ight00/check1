using System.Collections.Generic;
using Aspose.Slides;
using ns63;

namespace ns15;

internal class Class880
{
	internal static void smethod_0(ITagCollection tags, Class2727 progTags)
	{
		if (progTags == null)
		{
			return;
		}
		Class2726[] progStringTags = progTags.ProgStringTags;
		foreach (Class2726 @class in progStringTags)
		{
			string text = "";
			string value = "";
			if (@class.TagNameAtom != null && @class.TagValueAtom != null)
			{
				text = @class.TagNameAtom.String;
				value = @class.TagValueAtom.String;
			}
			if (text.Length > 0)
			{
				tags.Add(text.ToUpper(), value);
			}
		}
	}

	internal static void smethod_1(ITagCollection tags, Class2727 progTags)
	{
		if (tags == null)
		{
			return;
		}
		foreach (KeyValuePair<string, string> tag in tags)
		{
			Class2726 @class = new Class2726();
			progTags.Records.Add(@class);
			Class2843 item = new Class2843(tag.Key, 0);
			@class.Records.Add(item);
			Class2843 item2 = new Class2843(tag.Value, 1);
			@class.Records.Add(item2);
		}
	}
}
