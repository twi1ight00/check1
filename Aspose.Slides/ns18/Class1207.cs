using System.Xml;
using Aspose.Slides;
using ns16;
using ns53;
using ns56;

namespace ns18;

internal class Class1207 : Class1188
{
	internal void method_5(ITagCollection tags)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType == XmlNodeType.Element && base.XmlPartReader.LocalName == "tagLst")
			{
				Class2317 @class = new Class2317(base.XmlPartReader);
				Class2262[] tagList = @class.TagList;
				foreach (Class2262 class2 in tagList)
				{
					tags.Add(class2.Name, class2.Val);
				}
			}
		}
		method_2();
	}

	internal void method_6(ITagCollection tags)
	{
		method_3();
		Class2317 @class = new Class2317();
		string[] namesOfTags = tags.GetNamesOfTags();
		foreach (string name in namesOfTags)
		{
			Class2262 class2 = @class.delegate2533_0();
			class2.Name = name;
			class2.Val = tags[name];
		}
		@class.vmethod_4(null, base.XmlPartWriter, "tagLst");
		method_4();
	}

	public Class1207(Class1342 part, Class1341 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1207(Class1342 part, Class1346 serializationContext)
		: base(part, serializationContext)
	{
	}
}
