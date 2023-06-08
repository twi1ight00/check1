using System.Collections;
using System.Collections.Generic;
using ns53;
using ns55;

namespace ns19;

internal class Class247
{
	public static void Write(Class1342 part, Class249 unknownParts, List<object[]> relsToUnknownParts)
	{
		foreach (object[] relsToUnknownPart in relsToUnknownParts)
		{
			Class248 @class = unknownParts[(string)relsToUnknownPart[2]];
			if (@class != null)
			{
				smethod_0(part.ParentPackage, @class);
				part.Relationships.method_7((string)relsToUnknownPart[0], (string)relsToUnknownPart[1], (string)relsToUnknownPart[2], (Enum180)relsToUnknownPart[3]);
			}
		}
	}

	public static void smethod_0(Class1183 package, Class248 unknownPart)
	{
		if (package.method_3(unknownPart.PartPath) != null)
		{
			return;
		}
		Class1342 @class = package.method_5(unknownPart.PartPath, null, new Class1297(unknownPart.ContentType, unknownPart.TypeAttributeOfSourceRelationship), unknownPart.PartData);
		package.method_7(@class.PartPath);
		if (unknownPart.PartRelationships == null)
		{
			return;
		}
		foreach (Class1347 item in (IEnumerable)unknownPart.PartRelationships)
		{
			if (@class.Relationships == null)
			{
				@class.method_3();
			}
			@class.Relationships.method_7(item.Id, item.Type, item.Target, item.TargetMode);
		}
	}
}
