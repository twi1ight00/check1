using ns24;
using ns56;

namespace ns18;

internal class Class963
{
	public static void smethod_0(Class494 hf, Class2238 hfElementData)
	{
		if (hfElementData == null)
		{
			hf.Remove();
			return;
		}
		hf.IsHeaderVisible = hfElementData.Hdr;
		hf.IsDateTimeVisible = hfElementData.Dt;
		hf.IsFooterVisible = hfElementData.Ftr;
		hf.IsSlideNumberVisible = hfElementData.SldNum;
		hf.ExtensionList = hfElementData.ExtLst;
	}

	public static void smethod_1(Class494 hf, Class2238.Delegate2458 hfAdd)
	{
		if (hf.IsHeaderVisible || hf.IsFooterVisible || hf.IsSlideNumberVisible || hf.IsDateTimeVisible || hf.ExtensionList != null)
		{
			Class2238 @class = hfAdd();
			@class.Hdr = hf.IsHeaderVisible;
			@class.Dt = hf.IsDateTimeVisible;
			@class.Ftr = hf.IsFooterVisible;
			@class.SldNum = hf.IsSlideNumberVisible;
			@class.delegate1535_0(hf.ExtensionList);
		}
	}
}
