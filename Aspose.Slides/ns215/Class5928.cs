using ns216;
using ns217;

namespace ns215;

internal class Class5928
{
	internal static Class5916 smethod_0(Interface249 element, bool isCommon)
	{
		Class5916 @class = Class5929.Instance.method_0((element is Class5834) ? new Class5848() : element);
		foreach (Class5781 item in ((Class5781)element).Nodes.List)
		{
			if (!isCommon || !(item is Class5834))
			{
				if (item is Interface249 element2)
				{
					@class.method_3(smethod_0(element2, isCommon));
				}
				else if (item is Interface252 nativeObj)
				{
					@class.method_3((item is Class5802) ? new Class5915(nativeObj) : new Class5914(nativeObj));
				}
			}
		}
		return @class;
	}
}
