using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using ns60;

namespace ns63;

internal class Class2894 : Class2623
{
	internal const int int_0 = 4003;

	internal bool bool_1 = true;

	private ushort ushort_0 = ushort.MaxValue;

	private readonly List<Class2987> list_0 = new List<Class2987>();

	public ushort CLevels
	{
		get
		{
			if (ushort_0 == ushort.MaxValue)
			{
				return (ushort)Levels.Count;
			}
			return ushort_0;
		}
	}

	public bool presetStyle
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public List<Class2987> Levels => list_0;

	public Class2894()
	{
		base.Header.Type = 4003;
		base.Header.Version = 0;
		base.Header.Instance = 4;
	}

	public void method_1(Enum449 textType, bool defaultStyle)
	{
		base.Header.Instance = (short)textType;
		Levels.Clear();
		Class2987 @class = null;
		if (defaultStyle)
		{
			switch (textType)
			{
			case Enum449.const_0:
				@class = new Class2987();
				@class.ParagraphFormat.HasBullet = NullableBool.False;
				@class.ParagraphFormat.BulletHasFont = NullableBool.True;
				@class.ParagraphFormat.BulletHasColor = NullableBool.True;
				@class.ParagraphFormat.BulletHasSize = NullableBool.True;
				@class.ParagraphFormat.BulletChar = 8226;
				@class.ParagraphFormat.BulletFontRef = 0;
				@class.ParagraphFormat.BulletSize = 100;
				@class.ParagraphFormat.BulletColor = new Class2966(4278190080u);
				@class.ParagraphFormat.TextAlignment = Enum455.const_2;
				@class.ParagraphFormat.LineSpacing = 100;
				@class.ParagraphFormat.SpaceBefore = 0;
				@class.ParagraphFormat.SpaceAfter = 0;
				@class.ParagraphFormat.LeftMargin = 0;
				@class.ParagraphFormat.Indent = 0;
				@class.ParagraphFormat.DefaultTabSize = 576;
				@class.ParagraphFormat.TabStops = new Class2942();
				@class.ParagraphFormat.FontAlign = Enum380.const_0;
				@class.ParagraphFormat.CharWrap = NullableBool.True;
				@class.ParagraphFormat.WordWrap = NullableBool.True;
				@class.ParagraphFormat.Overflow = NullableBool.True;
				@class.ParagraphFormat.TextDirection = Enum445.const_0;
				@class.CharFormat.Bold = NullableBool.False;
				@class.CharFormat.Italic = NullableBool.False;
				@class.CharFormat.Underline = NullableBool.False;
				@class.CharFormat.Shadow = NullableBool.False;
				@class.CharFormat.Fehint = NullableBool.False;
				@class.CharFormat.Kumi = NullableBool.False;
				@class.CharFormat.Emboss = NullableBool.False;
				@class.CharFormat.OldEAFontRef = ushort.MaxValue;
				@class.CharFormat.AnsiFontRef = ushort.MaxValue;
				@class.CharFormat.SymbolFontRef = ushort.MaxValue;
				@class.CharFormat.FontSize = 44;
				@class.CharFormat.Color = new Class2966(50331648u);
				@class.CharFormat.Position = 0;
				Levels.Add(@class);
				break;
			case Enum449.const_1:
				@class = new Class2987();
				@class.ParagraphFormat.HasBullet = NullableBool.True;
				@class.ParagraphFormat.BulletHasFont = NullableBool.True;
				@class.ParagraphFormat.BulletHasColor = NullableBool.True;
				@class.ParagraphFormat.BulletHasSize = NullableBool.True;
				@class.ParagraphFormat.BulletChar = 8226;
				@class.ParagraphFormat.BulletFontRef = 0;
				@class.ParagraphFormat.BulletSize = 100;
				@class.ParagraphFormat.BulletColor = new Class2966(4278190080u);
				@class.ParagraphFormat.TextAlignment = Enum455.const_1;
				@class.ParagraphFormat.LineSpacing = 100;
				@class.ParagraphFormat.SpaceBefore = 20;
				@class.ParagraphFormat.SpaceAfter = 0;
				@class.ParagraphFormat.LeftMargin = 216;
				@class.ParagraphFormat.Indent = 0;
				@class.ParagraphFormat.DefaultTabSize = 576;
				@class.ParagraphFormat.TabStops = new Class2942();
				@class.ParagraphFormat.FontAlign = Enum380.const_0;
				@class.ParagraphFormat.CharWrap = NullableBool.True;
				@class.ParagraphFormat.WordWrap = NullableBool.True;
				@class.ParagraphFormat.Overflow = NullableBool.True;
				@class.ParagraphFormat.TextDirection = Enum445.const_0;
				@class.CharFormat.Bold = NullableBool.False;
				@class.CharFormat.Italic = NullableBool.False;
				@class.CharFormat.Underline = NullableBool.False;
				@class.CharFormat.Shadow = NullableBool.False;
				@class.CharFormat.Fehint = NullableBool.False;
				@class.CharFormat.Kumi = NullableBool.False;
				@class.CharFormat.Emboss = NullableBool.False;
				@class.CharFormat.FontSize = 32;
				@class.CharFormat.Color = new Class2966(16777216u);
				@class.CharFormat.Position = 0;
				Levels.Add(@class);
				break;
			case Enum449.const_2:
				@class = new Class2987();
				@class.ParagraphFormat.HasBullet = NullableBool.True;
				@class.ParagraphFormat.BulletHasFont = NullableBool.True;
				@class.ParagraphFormat.BulletHasColor = NullableBool.True;
				@class.ParagraphFormat.BulletHasSize = NullableBool.True;
				@class.ParagraphFormat.BulletChar = 8226;
				@class.ParagraphFormat.BulletFontRef = 0;
				@class.ParagraphFormat.BulletSize = 100;
				@class.ParagraphFormat.BulletColor = new Class2966(4278190080u);
				@class.ParagraphFormat.TextAlignment = Enum455.const_1;
				@class.ParagraphFormat.LineSpacing = 100;
				@class.ParagraphFormat.SpaceBefore = 30;
				@class.ParagraphFormat.SpaceAfter = 0;
				@class.ParagraphFormat.LeftMargin = 0;
				@class.ParagraphFormat.Indent = 0;
				@class.ParagraphFormat.DefaultTabSize = 576;
				@class.ParagraphFormat.TabStops = new Class2942();
				@class.ParagraphFormat.FontAlign = Enum380.const_0;
				@class.ParagraphFormat.CharWrap = NullableBool.True;
				@class.ParagraphFormat.WordWrap = NullableBool.True;
				@class.ParagraphFormat.Overflow = NullableBool.True;
				@class.ParagraphFormat.TextDirection = Enum445.const_0;
				@class.CharFormat.Bold = NullableBool.False;
				@class.CharFormat.Italic = NullableBool.False;
				@class.CharFormat.Underline = NullableBool.False;
				@class.CharFormat.Shadow = NullableBool.False;
				@class.CharFormat.Fehint = NullableBool.False;
				@class.CharFormat.Kumi = NullableBool.False;
				@class.CharFormat.Emboss = NullableBool.False;
				@class.CharFormat.FontRef = 0;
				@class.CharFormat.OldEAFontRef = ushort.MaxValue;
				@class.CharFormat.AnsiFontRef = ushort.MaxValue;
				@class.CharFormat.SymbolFontRef = ushort.MaxValue;
				@class.CharFormat.FontSize = 12;
				@class.CharFormat.Color = new Class2966(16777216u);
				@class.CharFormat.Position = 0;
				Levels.Add(@class);
				break;
			case Enum449.const_3:
				@class = new Class2987();
				@class.ParagraphFormat.HasBullet = NullableBool.False;
				@class.ParagraphFormat.BulletHasFont = NullableBool.True;
				@class.ParagraphFormat.BulletHasColor = NullableBool.True;
				@class.ParagraphFormat.BulletHasSize = NullableBool.True;
				@class.ParagraphFormat.BulletChar = 8226;
				@class.ParagraphFormat.BulletFontRef = 0;
				@class.ParagraphFormat.BulletSize = 100;
				@class.ParagraphFormat.BulletColor = new Class2966(4278190080u);
				@class.ParagraphFormat.TextAlignment = Enum455.const_1;
				@class.ParagraphFormat.LineSpacing = 100;
				@class.ParagraphFormat.SpaceBefore = 0;
				@class.ParagraphFormat.SpaceAfter = 0;
				@class.ParagraphFormat.LeftMargin = 0;
				@class.ParagraphFormat.Indent = 0;
				@class.ParagraphFormat.DefaultTabSize = 576;
				@class.ParagraphFormat.TabStops = new Class2942();
				@class.ParagraphFormat.FontAlign = Enum380.const_0;
				@class.ParagraphFormat.CharWrap = NullableBool.True;
				@class.ParagraphFormat.WordWrap = NullableBool.True;
				@class.ParagraphFormat.Overflow = NullableBool.True;
				@class.ParagraphFormat.TextDirection = Enum445.const_0;
				@class.CharFormat.Bold = NullableBool.False;
				@class.CharFormat.Italic = NullableBool.False;
				@class.CharFormat.Underline = NullableBool.False;
				@class.CharFormat.Shadow = NullableBool.False;
				@class.CharFormat.Fehint = NullableBool.False;
				@class.CharFormat.Kumi = NullableBool.False;
				@class.CharFormat.Emboss = NullableBool.False;
				@class.CharFormat.FontRef = 0;
				@class.CharFormat.OldEAFontRef = ushort.MaxValue;
				@class.CharFormat.AnsiFontRef = ushort.MaxValue;
				@class.CharFormat.SymbolFontRef = ushort.MaxValue;
				@class.CharFormat.FontSize = 18;
				@class.CharFormat.Color = new Class2966(16777216u);
				@class.CharFormat.Position = 0;
				Levels.Add(@class);
				@class = new Class2987();
				@class.ParagraphFormat.LeftMargin = 288;
				@class.ParagraphFormat.Indent = 288;
				Levels.Add(@class);
				@class = new Class2987();
				@class.ParagraphFormat.LeftMargin = 576;
				@class.ParagraphFormat.Indent = 576;
				Levels.Add(@class);
				@class = new Class2987();
				@class.ParagraphFormat.LeftMargin = 864;
				@class.ParagraphFormat.Indent = 864;
				Levels.Add(@class);
				@class = new Class2987();
				@class.ParagraphFormat.LeftMargin = 1152;
				@class.ParagraphFormat.Indent = 1152;
				Levels.Add(@class);
				break;
			case Enum449.const_4:
				@class = new Class2987();
				@class.ParagraphFormat.HasBullet = NullableBool.False;
				@class.ParagraphFormat.BulletHasFont = NullableBool.True;
				@class.ParagraphFormat.BulletHasColor = NullableBool.True;
				@class.ParagraphFormat.BulletHasSize = NullableBool.True;
				@class.ParagraphFormat.BulletChar = 8226;
				@class.ParagraphFormat.BulletFontRef = 0;
				@class.ParagraphFormat.BulletSize = 100;
				@class.ParagraphFormat.BulletColor = new Class2966(4278190080u);
				@class.ParagraphFormat.TextAlignment = Enum455.const_2;
				@class.ParagraphFormat.LineSpacing = 100;
				@class.ParagraphFormat.SpaceBefore = 20;
				@class.ParagraphFormat.SpaceAfter = 0;
				@class.ParagraphFormat.LeftMargin = 0;
				@class.ParagraphFormat.Indent = 0;
				@class.ParagraphFormat.DefaultTabSize = 576;
				@class.ParagraphFormat.TabStops = new Class2942();
				@class.ParagraphFormat.FontAlign = Enum380.const_0;
				@class.ParagraphFormat.CharWrap = NullableBool.True;
				@class.ParagraphFormat.WordWrap = NullableBool.True;
				@class.ParagraphFormat.Overflow = NullableBool.True;
				@class.ParagraphFormat.TextDirection = Enum445.const_0;
				@class.CharFormat.Bold = NullableBool.True;
				@class.CharFormat.Italic = NullableBool.False;
				@class.CharFormat.Underline = NullableBool.False;
				@class.CharFormat.Shadow = NullableBool.False;
				@class.CharFormat.Fehint = NullableBool.False;
				@class.CharFormat.Kumi = NullableBool.False;
				@class.CharFormat.Emboss = NullableBool.False;
				@class.CharFormat.OldEAFontRef = ushort.MaxValue;
				@class.CharFormat.AnsiFontRef = ushort.MaxValue;
				@class.CharFormat.SymbolFontRef = ushort.MaxValue;
				@class.CharFormat.FontSize = 32;
				@class.CharFormat.Color = new Class2966(50331648u);
				@class.CharFormat.Position = 0;
				Levels.Add(@class);
				break;
			case Enum449.const_5:
				@class = new Class2987();
				@class.ParagraphFormat.HasBullet = NullableBool.False;
				@class.ParagraphFormat.BulletHasFont = NullableBool.True;
				@class.ParagraphFormat.BulletHasColor = NullableBool.True;
				@class.ParagraphFormat.BulletHasSize = NullableBool.True;
				@class.ParagraphFormat.BulletChar = 8226;
				@class.ParagraphFormat.BulletFontRef = 0;
				@class.ParagraphFormat.BulletSize = 100;
				@class.ParagraphFormat.BulletColor = new Class2966(4278190080u);
				@class.ParagraphFormat.TextAlignment = Enum455.const_2;
				@class.ParagraphFormat.LineSpacing = 100;
				@class.ParagraphFormat.SpaceBefore = 0;
				@class.ParagraphFormat.SpaceAfter = 0;
				@class.ParagraphFormat.LeftMargin = 0;
				@class.ParagraphFormat.Indent = 0;
				@class.ParagraphFormat.DefaultTabSize = 576;
				@class.ParagraphFormat.TabStops = new Class2942();
				@class.ParagraphFormat.FontAlign = Enum380.const_0;
				@class.ParagraphFormat.CharWrap = NullableBool.True;
				@class.ParagraphFormat.WordWrap = NullableBool.True;
				@class.ParagraphFormat.Overflow = NullableBool.True;
				@class.ParagraphFormat.TextDirection = Enum445.const_0;
				@class.CharFormat.Bold = NullableBool.False;
				@class.CharFormat.Italic = NullableBool.False;
				@class.CharFormat.Underline = NullableBool.False;
				@class.CharFormat.Shadow = NullableBool.False;
				@class.CharFormat.Fehint = NullableBool.False;
				@class.CharFormat.Kumi = NullableBool.False;
				@class.CharFormat.Emboss = NullableBool.False;
				@class.CharFormat.OldEAFontRef = ushort.MaxValue;
				@class.CharFormat.AnsiFontRef = ushort.MaxValue;
				@class.CharFormat.SymbolFontRef = ushort.MaxValue;
				@class.CharFormat.FontSize = 44;
				@class.CharFormat.Color = new Class2966(50331648u);
				@class.CharFormat.Position = 0;
				Levels.Add(@class);
				break;
			case Enum449.const_6:
				@class = new Class2987();
				@class.ParagraphFormat.HasBullet = NullableBool.True;
				@class.ParagraphFormat.BulletHasFont = NullableBool.True;
				@class.ParagraphFormat.BulletHasColor = NullableBool.True;
				@class.ParagraphFormat.BulletHasSize = NullableBool.True;
				@class.ParagraphFormat.BulletChar = 8226;
				@class.ParagraphFormat.BulletFontRef = 0;
				@class.ParagraphFormat.BulletSize = 100;
				@class.ParagraphFormat.BulletColor = new Class2966(4278190080u);
				@class.ParagraphFormat.TextAlignment = Enum455.const_1;
				@class.ParagraphFormat.LineSpacing = 100;
				@class.ParagraphFormat.SpaceBefore = 20;
				@class.ParagraphFormat.SpaceAfter = 0;
				@class.ParagraphFormat.LeftMargin = 216;
				@class.ParagraphFormat.Indent = 0;
				@class.ParagraphFormat.DefaultTabSize = 576;
				@class.ParagraphFormat.TabStops = new Class2942();
				@class.ParagraphFormat.FontAlign = Enum380.const_0;
				@class.ParagraphFormat.CharWrap = NullableBool.True;
				@class.ParagraphFormat.WordWrap = NullableBool.True;
				@class.ParagraphFormat.Overflow = NullableBool.True;
				@class.ParagraphFormat.TextDirection = Enum445.const_0;
				@class.CharFormat.Bold = NullableBool.False;
				@class.CharFormat.Italic = NullableBool.False;
				@class.CharFormat.Underline = NullableBool.False;
				@class.CharFormat.Shadow = NullableBool.False;
				@class.CharFormat.Fehint = NullableBool.False;
				@class.CharFormat.Kumi = NullableBool.False;
				@class.CharFormat.Emboss = NullableBool.False;
				@class.CharFormat.FontRef = 0;
				@class.CharFormat.OldEAFontRef = ushort.MaxValue;
				@class.CharFormat.AnsiFontRef = ushort.MaxValue;
				@class.CharFormat.SymbolFontRef = ushort.MaxValue;
				@class.CharFormat.FontSize = 28;
				@class.CharFormat.Color = new Class2966(16777216u);
				@class.CharFormat.Position = 0;
				Levels.Add(@class);
				@class = new Class2987();
				@class.ParagraphFormat.BulletChar = 8211;
				@class.ParagraphFormat.LeftMargin = 468;
				@class.ParagraphFormat.Indent = 288;
				@class.CharFormat.FontSize = 24;
				Levels.Add(@class);
				@class = new Class2987();
				@class.ParagraphFormat.BulletChar = 8226;
				@class.ParagraphFormat.LeftMargin = 720;
				@class.ParagraphFormat.Indent = 576;
				@class.CharFormat.FontSize = 20;
				Levels.Add(@class);
				@class = new Class2987();
				@class.ParagraphFormat.BulletChar = 8211;
				@class.ParagraphFormat.LeftMargin = 1008;
				@class.ParagraphFormat.Indent = 864;
				@class.CharFormat.FontSize = 18;
				Levels.Add(@class);
				@class = new Class2987();
				@class.ParagraphFormat.BulletChar = 187;
				@class.ParagraphFormat.LeftMargin = 1296;
				@class.ParagraphFormat.Indent = 1152;
				@class.CharFormat.FontSize = 18;
				Levels.Add(@class);
				break;
			case Enum449.const_7:
				@class = new Class2987();
				@class.ParagraphFormat.HasBullet = NullableBool.True;
				@class.ParagraphFormat.BulletHasFont = NullableBool.True;
				@class.ParagraphFormat.BulletHasColor = NullableBool.True;
				@class.ParagraphFormat.BulletHasSize = NullableBool.True;
				@class.ParagraphFormat.BulletChar = 8226;
				@class.ParagraphFormat.BulletFontRef = 0;
				@class.ParagraphFormat.BulletSize = 100;
				@class.ParagraphFormat.BulletColor = new Class2966(4278190080u);
				@class.ParagraphFormat.TextAlignment = Enum455.const_1;
				@class.ParagraphFormat.LineSpacing = 100;
				@class.ParagraphFormat.SpaceBefore = 20;
				@class.ParagraphFormat.SpaceAfter = 0;
				@class.ParagraphFormat.LeftMargin = 216;
				@class.ParagraphFormat.Indent = 0;
				@class.ParagraphFormat.DefaultTabSize = 576;
				@class.ParagraphFormat.TabStops = new Class2942();
				@class.ParagraphFormat.FontAlign = Enum380.const_0;
				@class.ParagraphFormat.CharWrap = NullableBool.True;
				@class.ParagraphFormat.WordWrap = NullableBool.True;
				@class.ParagraphFormat.Overflow = NullableBool.True;
				@class.ParagraphFormat.TextDirection = Enum445.const_0;
				@class.CharFormat.Bold = NullableBool.False;
				@class.CharFormat.Italic = NullableBool.False;
				@class.CharFormat.Underline = NullableBool.False;
				@class.CharFormat.Shadow = NullableBool.False;
				@class.CharFormat.Fehint = NullableBool.False;
				@class.CharFormat.Kumi = NullableBool.False;
				@class.CharFormat.Emboss = NullableBool.False;
				@class.CharFormat.FontRef = 0;
				@class.CharFormat.OldEAFontRef = ushort.MaxValue;
				@class.CharFormat.AnsiFontRef = ushort.MaxValue;
				@class.CharFormat.SymbolFontRef = ushort.MaxValue;
				@class.CharFormat.FontSize = 24;
				@class.CharFormat.Color = new Class2966(16777216u);
				@class.CharFormat.Position = 0;
				Levels.Add(@class);
				break;
			}
		}
		else
		{
			switch (textType)
			{
			case Enum449.const_0:
				@class = new Class2987();
				@class.ParagraphFormat.HasBullet = NullableBool.False;
				@class.ParagraphFormat.BulletHasFont = NullableBool.True;
				@class.ParagraphFormat.BulletHasColor = NullableBool.True;
				@class.ParagraphFormat.BulletHasSize = NullableBool.True;
				@class.ParagraphFormat.BulletChar = 8226;
				@class.ParagraphFormat.BulletFontRef = 0;
				@class.ParagraphFormat.BulletSize = 100;
				@class.ParagraphFormat.BulletColor = new Class2966(4278190080u);
				@class.ParagraphFormat.TextAlignment = Enum455.const_2;
				@class.ParagraphFormat.LineSpacing = 100;
				@class.ParagraphFormat.SpaceBefore = 0;
				@class.ParagraphFormat.SpaceAfter = 0;
				@class.ParagraphFormat.LeftMargin = 0;
				@class.ParagraphFormat.Indent = 0;
				@class.ParagraphFormat.DefaultTabSize = 576;
				@class.ParagraphFormat.TabStops = new Class2942();
				@class.ParagraphFormat.FontAlign = Enum380.const_0;
				@class.ParagraphFormat.CharWrap = NullableBool.True;
				@class.ParagraphFormat.WordWrap = NullableBool.True;
				@class.ParagraphFormat.Overflow = NullableBool.True;
				@class.ParagraphFormat.TextDirection = Enum445.const_0;
				@class.CharFormat.Bold = NullableBool.False;
				@class.CharFormat.Italic = NullableBool.False;
				@class.CharFormat.Underline = NullableBool.False;
				@class.CharFormat.Shadow = NullableBool.False;
				@class.CharFormat.Fehint = NullableBool.False;
				@class.CharFormat.Kumi = NullableBool.False;
				@class.CharFormat.Emboss = NullableBool.False;
				@class.CharFormat.OldEAFontRef = ushort.MaxValue;
				@class.CharFormat.AnsiFontRef = ushort.MaxValue;
				@class.CharFormat.SymbolFontRef = ushort.MaxValue;
				@class.CharFormat.FontSize = 44;
				@class.CharFormat.Color = new Class2966(50331648u);
				@class.CharFormat.Position = 0;
				Levels.Add(@class);
				break;
			case Enum449.const_1:
				@class = new Class2987();
				@class.ParagraphFormat.HasBullet = NullableBool.True;
				@class.ParagraphFormat.BulletHasFont = NullableBool.True;
				@class.ParagraphFormat.BulletHasColor = NullableBool.True;
				@class.ParagraphFormat.BulletHasSize = NullableBool.True;
				@class.ParagraphFormat.BulletChar = 8226;
				@class.ParagraphFormat.BulletFontRef = 0;
				@class.ParagraphFormat.BulletSize = 100;
				@class.ParagraphFormat.BulletColor = new Class2966(4278190080u);
				@class.ParagraphFormat.TextAlignment = Enum455.const_1;
				@class.ParagraphFormat.LineSpacing = 100;
				@class.ParagraphFormat.SpaceBefore = 20;
				@class.ParagraphFormat.SpaceAfter = 0;
				@class.ParagraphFormat.LeftMargin = 216;
				@class.ParagraphFormat.Indent = 0;
				@class.ParagraphFormat.DefaultTabSize = 576;
				@class.ParagraphFormat.TabStops = new Class2942();
				@class.ParagraphFormat.FontAlign = Enum380.const_0;
				@class.ParagraphFormat.CharWrap = NullableBool.True;
				@class.ParagraphFormat.WordWrap = NullableBool.True;
				@class.ParagraphFormat.Overflow = NullableBool.True;
				@class.ParagraphFormat.TextDirection = Enum445.const_0;
				@class.CharFormat.Bold = NullableBool.False;
				@class.CharFormat.Italic = NullableBool.False;
				@class.CharFormat.Underline = NullableBool.False;
				@class.CharFormat.Shadow = NullableBool.False;
				@class.CharFormat.Fehint = NullableBool.False;
				@class.CharFormat.Kumi = NullableBool.False;
				@class.CharFormat.Emboss = NullableBool.False;
				@class.CharFormat.FontRef = 0;
				@class.CharFormat.OldEAFontRef = ushort.MaxValue;
				@class.CharFormat.AnsiFontRef = ushort.MaxValue;
				@class.CharFormat.SymbolFontRef = ushort.MaxValue;
				@class.CharFormat.FontSize = 32;
				@class.CharFormat.Color = new Class2966(16777216u);
				@class.CharFormat.Position = 0;
				Levels.Add(@class);
				@class = new Class2987();
				@class.ParagraphFormat.BulletChar = 8211;
				@class.ParagraphFormat.LeftMargin = 468;
				@class.ParagraphFormat.Indent = 288;
				@class.CharFormat.FontSize = 28;
				Levels.Add(@class);
				@class = new Class2987();
				@class.ParagraphFormat.BulletChar = 8226;
				@class.ParagraphFormat.LeftMargin = 720;
				@class.ParagraphFormat.Indent = 576;
				@class.CharFormat.FontSize = 24;
				Levels.Add(@class);
				@class = new Class2987();
				@class.ParagraphFormat.BulletChar = 8211;
				@class.ParagraphFormat.LeftMargin = 1008;
				@class.ParagraphFormat.Indent = 864;
				@class.CharFormat.FontSize = 20;
				Levels.Add(@class);
				@class = new Class2987();
				@class.ParagraphFormat.BulletChar = 187;
				@class.ParagraphFormat.LeftMargin = 1296;
				@class.ParagraphFormat.Indent = 1152;
				Levels.Add(@class);
				break;
			case Enum449.const_2:
				@class = new Class2987();
				@class.ParagraphFormat.HasBullet = NullableBool.False;
				@class.ParagraphFormat.BulletHasFont = NullableBool.False;
				@class.ParagraphFormat.BulletHasColor = NullableBool.False;
				@class.ParagraphFormat.BulletHasSize = NullableBool.False;
				@class.ParagraphFormat.BulletChar = 8226;
				@class.ParagraphFormat.BulletFontRef = 0;
				@class.ParagraphFormat.BulletSize = 100;
				@class.ParagraphFormat.BulletColor = new Class2966(4278190080u);
				@class.ParagraphFormat.TextAlignment = Enum455.const_1;
				@class.ParagraphFormat.LineSpacing = 100;
				@class.ParagraphFormat.SpaceBefore = 30;
				@class.ParagraphFormat.SpaceAfter = 0;
				@class.ParagraphFormat.LeftMargin = 0;
				@class.ParagraphFormat.Indent = 0;
				@class.ParagraphFormat.DefaultTabSize = 288;
				@class.ParagraphFormat.TabStops = new Class2942();
				@class.ParagraphFormat.FontAlign = Enum380.const_0;
				@class.ParagraphFormat.CharWrap = NullableBool.False;
				@class.ParagraphFormat.WordWrap = NullableBool.True;
				@class.ParagraphFormat.Overflow = NullableBool.False;
				@class.ParagraphFormat.TextDirection = Enum445.const_0;
				@class.CharFormat.Bold = NullableBool.False;
				@class.CharFormat.Italic = NullableBool.False;
				@class.CharFormat.Underline = NullableBool.False;
				@class.CharFormat.Shadow = NullableBool.False;
				@class.CharFormat.Fehint = NullableBool.False;
				@class.CharFormat.Kumi = NullableBool.False;
				@class.CharFormat.Emboss = NullableBool.False;
				@class.CharFormat.FontRef = 0;
				@class.CharFormat.OldEAFontRef = ushort.MaxValue;
				@class.CharFormat.AnsiFontRef = ushort.MaxValue;
				@class.CharFormat.SymbolFontRef = ushort.MaxValue;
				@class.CharFormat.FontSize = 12;
				@class.CharFormat.Color = new Class2966(16777216u);
				@class.CharFormat.Position = 0;
				Levels.Add(@class);
				@class = new Class2987();
				@class.ParagraphFormat.LeftMargin = 288;
				@class.ParagraphFormat.Indent = 288;
				Levels.Add(@class);
				@class = new Class2987();
				@class.ParagraphFormat.LeftMargin = 576;
				@class.ParagraphFormat.Indent = 576;
				Levels.Add(@class);
				@class = new Class2987();
				@class.ParagraphFormat.LeftMargin = 864;
				@class.ParagraphFormat.Indent = 864;
				Levels.Add(@class);
				@class = new Class2987();
				@class.ParagraphFormat.LeftMargin = 1152;
				@class.ParagraphFormat.Indent = 1152;
				Levels.Add(@class);
				break;
			case Enum449.const_3:
				@class = new Class2987();
				@class.ParagraphFormat.HasBullet = NullableBool.False;
				@class.ParagraphFormat.BulletHasFont = NullableBool.True;
				@class.ParagraphFormat.BulletHasColor = NullableBool.True;
				@class.ParagraphFormat.BulletHasSize = NullableBool.True;
				@class.ParagraphFormat.BulletChar = 8226;
				@class.ParagraphFormat.BulletFontRef = 0;
				@class.ParagraphFormat.BulletSize = 100;
				@class.ParagraphFormat.BulletColor = new Class2966(4278190080u);
				@class.ParagraphFormat.TextAlignment = Enum455.const_1;
				@class.ParagraphFormat.LineSpacing = 100;
				@class.ParagraphFormat.SpaceBefore = 0;
				@class.ParagraphFormat.SpaceAfter = 0;
				@class.ParagraphFormat.LeftMargin = 0;
				@class.ParagraphFormat.Indent = 0;
				@class.ParagraphFormat.DefaultTabSize = 576;
				@class.ParagraphFormat.TabStops = new Class2942();
				@class.ParagraphFormat.FontAlign = Enum380.const_0;
				@class.ParagraphFormat.CharWrap = NullableBool.True;
				@class.ParagraphFormat.WordWrap = NullableBool.True;
				@class.ParagraphFormat.Overflow = NullableBool.True;
				@class.ParagraphFormat.TextDirection = Enum445.const_0;
				@class.CharFormat.Bold = NullableBool.False;
				@class.CharFormat.Italic = NullableBool.False;
				@class.CharFormat.Underline = NullableBool.False;
				@class.CharFormat.Shadow = NullableBool.False;
				@class.CharFormat.Fehint = NullableBool.False;
				@class.CharFormat.Kumi = NullableBool.False;
				@class.CharFormat.Emboss = NullableBool.False;
				@class.CharFormat.FontRef = ushort.MaxValue;
				@class.CharFormat.OldEAFontRef = ushort.MaxValue;
				@class.CharFormat.AnsiFontRef = ushort.MaxValue;
				@class.CharFormat.SymbolFontRef = ushort.MaxValue;
				@class.CharFormat.FontSize = 18;
				@class.CharFormat.Color = new Class2966(16777216u);
				@class.CharFormat.Position = 0;
				Levels.Add(@class);
				@class = new Class2987();
				@class.ParagraphFormat.LeftMargin = 288;
				@class.ParagraphFormat.Indent = 288;
				Levels.Add(@class);
				@class = new Class2987();
				@class.ParagraphFormat.LeftMargin = 576;
				@class.ParagraphFormat.Indent = 576;
				Levels.Add(@class);
				@class = new Class2987();
				@class.ParagraphFormat.LeftMargin = 864;
				@class.ParagraphFormat.Indent = 864;
				Levels.Add(@class);
				@class = new Class2987();
				@class.ParagraphFormat.LeftMargin = 1152;
				@class.ParagraphFormat.Indent = 1152;
				Levels.Add(@class);
				break;
			case Enum449.const_4:
				@class = new Class2987();
				@class.ParagraphFormat.HasBullet = NullableBool.False;
				@class.ParagraphFormat.BulletHasFont = NullableBool.False;
				@class.ParagraphFormat.BulletHasColor = NullableBool.False;
				@class.ParagraphFormat.BulletHasSize = NullableBool.False;
				@class.ParagraphFormat.TextAlignment = Enum455.const_2;
				@class.ParagraphFormat.LeftMargin = 0;
				Levels.Add(@class);
				@class = new Class2987();
				@class.ParagraphFormat.TextAlignment = Enum455.const_2;
				@class.ParagraphFormat.LeftMargin = 288;
				Levels.Add(@class);
				@class = new Class2987();
				@class.ParagraphFormat.HasBullet = NullableBool.False;
				@class.ParagraphFormat.BulletHasFont = NullableBool.False;
				@class.ParagraphFormat.BulletHasColor = NullableBool.False;
				@class.ParagraphFormat.BulletHasSize = NullableBool.False;
				@class.ParagraphFormat.TextAlignment = Enum455.const_2;
				@class.ParagraphFormat.LeftMargin = 576;
				Levels.Add(@class);
				@class = new Class2987();
				@class.ParagraphFormat.HasBullet = NullableBool.False;
				@class.ParagraphFormat.BulletHasFont = NullableBool.False;
				@class.ParagraphFormat.BulletHasColor = NullableBool.False;
				@class.ParagraphFormat.BulletHasSize = NullableBool.False;
				@class.ParagraphFormat.TextAlignment = Enum455.const_2;
				@class.ParagraphFormat.LeftMargin = 864;
				Levels.Add(@class);
				@class = new Class2987();
				@class.ParagraphFormat.HasBullet = NullableBool.False;
				@class.ParagraphFormat.BulletHasFont = NullableBool.False;
				@class.ParagraphFormat.BulletHasColor = NullableBool.False;
				@class.ParagraphFormat.BulletHasSize = NullableBool.False;
				@class.ParagraphFormat.TextAlignment = Enum455.const_2;
				@class.ParagraphFormat.LeftMargin = 1152;
				Levels.Add(@class);
				break;
			case Enum449.const_5:
				@class = new Class2987();
				Levels.Add(@class);
				break;
			case Enum449.const_6:
				@class = new Class2987();
				@class.CharFormat.FontSize = 28;
				Levels.Add(@class);
				@class = new Class2987();
				@class.CharFormat.FontSize = 24;
				Levels.Add(@class);
				@class = new Class2987();
				@class.CharFormat.FontSize = 20;
				Levels.Add(@class);
				@class = new Class2987();
				@class.CharFormat.FontSize = 18;
				Levels.Add(@class);
				@class = new Class2987();
				@class.CharFormat.FontSize = 18;
				Levels.Add(@class);
				break;
			case Enum449.const_7:
				@class = new Class2987();
				@class.CharFormat.FontSize = 24;
				Levels.Add(@class);
				@class = new Class2987();
				@class.CharFormat.FontSize = 20;
				Levels.Add(@class);
				@class = new Class2987();
				@class.CharFormat.FontSize = 18;
				Levels.Add(@class);
				@class = new Class2987();
				@class.CharFormat.FontSize = 16;
				Levels.Add(@class);
				@class = new Class2987();
				@class.CharFormat.FontSize = 16;
				Levels.Add(@class);
				break;
			}
		}
		for (int i = 0; i < Levels.Count; i++)
		{
			Levels[i].Level = (ushort)i;
		}
		bool_1 = true;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		ushort_0 = reader.ReadUInt16();
		Levels.Clear();
		for (int i = 0; i < ushort_0; i++)
		{
			Class2987 @class = new Class2987();
			@class.method_2(reader, base.Header.Instance);
			Levels.Add(@class);
		}
		bool_1 = false;
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		int count = Levels.Count;
		writer.Write((short)count);
		for (int i = 0; i < count; i++)
		{
			Levels[i].method_3(writer, i, base.Header.Instance);
		}
	}

	public override int vmethod_2()
	{
		int count = Levels.Count;
		int num = 2;
		for (int i = 0; i < count; i++)
		{
			num += Levels[i].method_4(base.Header.Instance);
		}
		return num;
	}

	public void method_2(SortedList fonts)
	{
		int count = Levels.Count;
		for (int i = 0; i < count; i++)
		{
			Class2987 @class = Levels[i];
			Class2974 paragraphFormat = @class.ParagraphFormat;
			Class2971 charFormat = @class.CharFormat;
			if (((int?)paragraphFormat.BulletFontRef).HasValue && fonts.ContainsKey(paragraphFormat.BulletFontRef))
			{
				paragraphFormat.BulletFontRef = (ushort)(int)fonts[paragraphFormat.BulletFontRef];
			}
			if (charFormat.FontRef.HasValue && fonts.ContainsKey(charFormat.FontRef))
			{
				charFormat.FontRef = (ushort)(int)fonts[charFormat.FontRef];
			}
			if (charFormat.OldEAFontRef.HasValue && fonts.ContainsKey(charFormat.OldEAFontRef))
			{
				charFormat.OldEAFontRef = (ushort)(int)fonts[charFormat.OldEAFontRef];
			}
			if (charFormat.AnsiFontRef.HasValue && fonts.ContainsKey(charFormat.AnsiFontRef))
			{
				charFormat.AnsiFontRef = (ushort)(int)fonts[charFormat.AnsiFontRef];
			}
			if (charFormat.SymbolFontRef.HasValue && fonts.ContainsKey(charFormat.SymbolFontRef))
			{
				charFormat.SymbolFontRef = (ushort)(int)fonts[charFormat.SymbolFontRef];
			}
		}
	}

	public void method_3(Class2894 source)
	{
		if (source == null)
		{
			return;
		}
		if (base.Header.Instance != source.Header.Instance)
		{
			throw new ArgumentException("Current and specified TextMasterStyle atoms have different text types.");
		}
		if (base.Header.Instance != 0 && base.Header.Instance != 1 && base.Header.Instance != 4)
		{
			throw new InvalidOperationException("Only Title, Body and Other text tipes can be updated.");
		}
		for (int i = 0; i < source.CLevels; i++)
		{
			if (Levels.Count > i)
			{
				Levels[i].method_0(source.Levels[i]);
				continue;
			}
			Class2987 @class = new Class2987(0);
			@class.method_0(source.Levels[i]);
			Levels.Add(@class);
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append($"TextMasterStyleAtom: Header.Instance: {base.Header.Instance}; Levels count: {Levels.Count}");
		for (int i = 0; i < Levels.Count; i++)
		{
			stringBuilder.AppendLine();
			stringBuilder.Append($"{i}: {Levels[i]}");
		}
		return stringBuilder.ToString().Replace("\n", "\n  ");
	}
}
