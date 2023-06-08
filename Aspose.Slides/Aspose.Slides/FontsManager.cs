using System;
using System.Collections.Generic;
using ns4;

namespace Aspose.Slides;

public class FontsManager : IFontsManager
{
	private readonly Class48 class48_0;

	private readonly Class54 class54_0;

	private IFontSubstRuleCollection ifontSubstRuleCollection_0;

	public IFontSubstRuleCollection FontSubstRuleList
	{
		get
		{
			return ifontSubstRuleCollection_0;
		}
		set
		{
			ifontSubstRuleCollection_0 = value;
		}
	}

	internal bool UseFontsSubstitutionsList
	{
		set
		{
			if (value)
			{
				method_0();
			}
			else
			{
				method_1();
			}
		}
	}

	internal Class48 FontsList => class48_0;

	internal FontsManager(Class54 fontsManagerInternal, Class48 fontsList)
	{
		if (fontsList == null)
		{
			throw new ArgumentNullException("fontsList");
		}
		if (fontsManagerInternal == null)
		{
			throw new ArgumentNullException("fontsManagerInternal");
		}
		class54_0 = fontsManagerInternal;
		class48_0 = fontsList;
	}

	public IFontData[] GetFonts()
	{
		List<IFontData> list = new List<IFontData>();
		foreach (Class52 entry in class48_0.Entries)
		{
			if (!entry.IsFontModificator && !list.Contains(entry.FontData) && entry.LocalPresentationFont)
			{
				list.Add(entry.FontData);
			}
		}
		foreach (Class52 entry2 in Class53.DefaultFontsList.Entries)
		{
			if (!entry2.IsFontModificator && !list.Contains(entry2.FontData) && entry2.LocalPresentationFont)
			{
				list.Add(entry2.FontData);
			}
		}
		return list.ToArray();
	}

	private void method_0()
	{
		if (ifontSubstRuleCollection_0 == null)
		{
			return;
		}
		foreach (IFontSubstRule item in ifontSubstRuleCollection_0)
		{
			class48_0.method_3(item.SourceFont, item.DestFont, item.ReplaceFontCondition);
			Class53.DefaultFontsList.method_3(item.SourceFont, item.DestFont, item.ReplaceFontCondition);
		}
	}

	private void method_1()
	{
		class48_0.method_4();
		Class53.DefaultFontsList.method_4();
	}

	public void ReplaceFont(IFontData sourceFont, IFontData destFont)
	{
		class48_0.method_2(sourceFont, destFont);
		Class53.DefaultFontsList.method_2(sourceFont, destFont);
	}

	public void ReplaceFont(IFontSubstRule substRule)
	{
		class48_0.method_2(substRule.SourceFont, substRule.DestFont);
		Class53.DefaultFontsList.method_2(substRule.SourceFont, substRule.DestFont);
	}

	public void ReplaceFont(IFontSubstRuleCollection substRules)
	{
		foreach (IFontSubstRule substRule in substRules)
		{
			class48_0.method_2(substRule.SourceFont, substRule.DestFont);
			Class53.DefaultFontsList.method_2(substRule.SourceFont, substRule.DestFont);
		}
	}
}
