using System;
using ns25;
using ns56;

namespace ns17;

internal class Class922
{
	public static void smethod_0(Class312 layout, Class2080 layoutElementData)
	{
		if (layoutElementData == null)
		{
			return;
		}
		Class2090 manualLayout = layoutElementData.ManualLayout;
		if (manualLayout == null)
		{
			return;
		}
		if (manualLayout.X != null)
		{
			layout.X = (float)manualLayout.X.Val;
		}
		if (manualLayout.Y != null)
		{
			layout.Y = (float)manualLayout.Y.Val;
		}
		if (manualLayout.W != null)
		{
			if (manualLayout.WMode != null && manualLayout.WMode.Val == Enum318.const_1)
			{
				if (manualLayout.X == null)
				{
					throw new NotImplementedException();
				}
				layout.Width = (float)(manualLayout.X.Val + manualLayout.W.Val);
			}
			else
			{
				layout.Width = (float)manualLayout.W.Val;
			}
		}
		if (manualLayout.H != null)
		{
			if (manualLayout.HMode != null && manualLayout.HMode.Val == Enum318.const_1)
			{
				if (manualLayout.Y == null)
				{
					throw new NotImplementedException();
				}
				layout.Height = (float)(manualLayout.Y.Val + manualLayout.H.Val);
			}
			else
			{
				layout.Height = (float)manualLayout.H.Val;
			}
		}
		layout.XMode = manualLayout.XMode;
		layout.YMode = manualLayout.YMode;
		layout.HMode = manualLayout.HMode;
		layout.WMode = manualLayout.WMode;
		if (layout is Class313 && manualLayout.LayoutTarget != null)
		{
			((Class313)layout).LayoutByOutside = manualLayout.LayoutTarget.Val == Enum319.const_2;
		}
		layout.ExtensionListOfLayout = layoutElementData.ExtLst;
		layout.ExtensionListOfManualLayout = manualLayout.ExtLst;
	}

	public static void smethod_1(Class312 layout, Class2080.Delegate1955 addLayout)
	{
		if (smethod_2(layout))
		{
			Class2080 @class = addLayout();
			Class2090 class2 = @class.delegate1988_0();
			if (!float.IsNaN(layout.X))
			{
				class2.delegate1923_0().Val = layout.X;
			}
			if (!float.IsNaN(layout.Y))
			{
				class2.delegate1923_1().Val = layout.Y;
			}
			if (!float.IsNaN(layout.Width))
			{
				class2.delegate1923_2().Val = layout.Width;
			}
			if (!float.IsNaN(layout.Height))
			{
				class2.delegate1923_3().Val = layout.Height;
			}
			class2.delegate1960_0(layout.XMode);
			class2.delegate1960_1(layout.YMode);
			class2.delegate1960_3(layout.HMode);
			class2.delegate1960_2(layout.WMode);
			if (layout is Class313 && !((Class313)layout).LayoutByOutside)
			{
				class2.delegate1961_0().Val = Enum319.const_1;
			}
			@class.delegate1535_0(layout.ExtensionListOfLayout);
			class2.delegate1535_0(layout.ExtensionListOfManualLayout);
		}
	}

	internal static bool smethod_2(Class312 layout)
	{
		if (float.IsNaN(layout.X) && float.IsNaN(layout.Y) && float.IsNaN(layout.Width))
		{
			return !float.IsNaN(layout.Height);
		}
		return true;
	}
}
