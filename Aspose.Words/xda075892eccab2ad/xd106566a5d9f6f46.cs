using Aspose.Words;
using Aspose.Words.Tables;

namespace xda075892eccab2ad;

internal class xd106566a5d9f6f46
{
	internal static TableAlignment x285a29cfd1b91f80(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"left" => TableAlignment.Left, 
			"start" => TableAlignment.Left, 
			"center" => TableAlignment.Center, 
			"right" => TableAlignment.Right, 
			"end" => TableAlignment.Right, 
			_ => TableAlignment.Left, 
		};
	}

	internal static string x0e594440b71cd978(TableAlignment xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			TableAlignment.Left => "left", 
			TableAlignment.Center => "center", 
			TableAlignment.Right => "right", 
			_ => "", 
		};
	}

	internal static HeightRule xe39d51b7fd3464b5(string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "auto":
			return HeightRule.Auto;
		case "exact":
			return HeightRule.Exactly;
		case "atLeast":
		case "at-least":
			return HeightRule.AtLeast;
		default:
			return HeightRule.Auto;
		}
	}

	internal static string xe450fbc63c45b368(HeightRule xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		switch (xbcea506a33cf9111)
		{
		case HeightRule.Auto:
			return "auto";
		case HeightRule.Exactly:
			return "exact";
		case HeightRule.AtLeast:
			if (!x5fbb1a9c98604ef5)
			{
				return "at-least";
			}
			return "atLeast";
		default:
			return "";
		}
	}

	internal static CellMerge x7186e130a3665f42(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"continue" => CellMerge.Previous, 
			"restart" => CellMerge.First, 
			_ => CellMerge.None, 
		};
	}

	internal static string x658fb4df5e4d113a(CellMerge xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			CellMerge.Previous => "continue", 
			CellMerge.First => "restart", 
			_ => "", 
		};
	}

	internal static CellVerticalAlignment x0e2868a293beb06a(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"top" => CellVerticalAlignment.Top, 
			"center" => CellVerticalAlignment.Center, 
			"bottom" => CellVerticalAlignment.Bottom, 
			_ => CellVerticalAlignment.Top, 
		};
	}

	internal static string x66809280b09b6f05(CellVerticalAlignment xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			CellVerticalAlignment.Top => "top", 
			CellVerticalAlignment.Center => "center", 
			CellVerticalAlignment.Bottom => "bottom", 
			_ => "", 
		};
	}
}
