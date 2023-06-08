using System;
using System.Collections;
using System.IO;
using System.Text;
using ns218;
using ns235;

namespace ns238;

internal class Class6569 : Class6568
{
	public Class6569(Class6567 context)
		: base(context)
	{
	}

	public void method_0()
	{
		short num = base.Context.method_10();
		Class6584 @class = new Class6584(base.Context);
		@class.method_0();
		base.Writer.method_1(num);
		base.Writer.method_2(0);
		base.Writer.method_0(method_1());
		@class.method_1(Enum878.const_59);
		method_3(num);
	}

	private byte[] method_1()
	{
		using MemoryStream memoryStream = new MemoryStream();
		Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
		Class5946 @class = new Class5946(memoryStream, encoding, isPrettyFormat: false);
		@class.method_0("document");
		@class.method_2("locales");
		@class.method_2("locale");
		@class.method_14("name", "en_US");
		@class.method_14("font", base.Context.ToolTipFont.FullFontName + "_AW");
		smethod_1(@class, "topPane", base.Context.Options.TopPaneToolTips);
		smethod_1(@class, "leftPane", base.Context.Options.LeftPaneToolTips);
		smethod_1(@class, "bottomPane", base.Context.Options.BottomPaneToolTips);
		smethod_1(@class, "readModePane", base.Context.Options.ReadModePaneToolTips);
		smethod_1(@class, "dialogs", base.Context.Options.DialogsToolTips);
		@class.method_3();
		@class.method_3();
		method_2(@class);
		base.Context.Outline.method_1(@class);
		for (int i = 0; i < base.Context.Pages.Count; i++)
		{
			Class6579 class2 = base.Context.Pages[i];
			@class.method_2("page");
			@class.method_14("width", class2.PageWidth.ToString());
			@class.method_14("height", class2.PageHeight.ToString());
			foreach (DictionaryEntry hyperlink in class2.Hyperlinks)
			{
				Class6270 class3 = (Class6270)hyperlink.Value;
				string key = (class3.IsLocal ? class3.Target.Trim('#') : string.Empty);
				if (!class3.IsLocal || base.Context.Bookmarks[key] != null)
				{
					@class.method_2("hyperlink");
					@class.method_14("id", hyperlink.Key.ToString());
					@class.method_14("islocal", class3.IsLocal.ToString());
					@class.XmlWriter.WriteCData(class3.IsLocal ? base.Context.Bookmarks[key].ToString() : class3.Target);
					@class.method_3();
				}
			}
			@class.method_3();
		}
		@class.method_1();
		return Class5964.smethod_11(memoryStream);
	}

	private void method_2(Class5946 builder)
	{
		builder.method_2("config");
		smethod_0(builder, "showFullScreen", base.Context.Options.ShowFullScreen.ToString(), allowOverride: true);
		smethod_0(builder, "showPageStepper", base.Context.Options.ShowPageStepper.ToString(), allowOverride: true);
		smethod_0(builder, "showSearch", base.Context.Options.ShowSearch.ToString(), allowOverride: true);
		smethod_0(builder, "showTopPane", base.Context.Options.ShowTopPane.ToString(), allowOverride: true);
		smethod_0(builder, "showBottomPane", base.Context.Options.ShowBottomPane.ToString(), allowOverride: true);
		smethod_0(builder, "showLeftPane", base.Context.Options.ShowLeftPane.ToString(), allowOverride: true);
		smethod_0(builder, "startOpenLeftPane", base.Context.Options.StartOpenLeftPane.ToString(), allowOverride: true);
		smethod_0(builder, "allowReadMode", base.Context.Options.AllowReadMode.ToString(), allowOverride: true);
		smethod_0(builder, "enableContextMenu", base.Context.Options.EnableContextMenu.ToString(), allowOverride: true);
		smethod_0(builder, "controlFlags", base.Context.Options.TopPaneControlFlags.ToString(), allowOverride: true);
		smethod_0(builder, "leftPaneTabs", base.Context.Options.LeftPaneControlFlags.ToString(), allowOverride: true);
		if (base.Context.Options.LogoImageBytes != null)
		{
			smethod_0(builder, "logoImage", Convert.ToBase64String(base.Context.Options.LogoImageBytes), allowOverride: false);
		}
		if (Class5964.smethod_20(base.Context.Options.LogoLink))
		{
			smethod_0(builder, "logoLink", base.Context.Options.LogoLink, allowOverride: true);
		}
		builder.method_3();
	}

	private static void smethod_0(Class5946 builder, string paramName, string paramValue, bool allowOverride)
	{
		builder.method_2("param");
		builder.method_14("name", paramName);
		builder.method_14("allowOverride", allowOverride.ToString());
		builder.XmlWriter.WriteCData(paramValue);
		builder.method_3();
	}

	private static void smethod_1(Class5946 builder, string panelName, Hashtable tooltips)
	{
		builder.method_2("bundle");
		builder.method_14("name", panelName);
		foreach (DictionaryEntry tooltip in tooltips)
		{
			string value = (string)tooltip.Key;
			string value2 = (string)tooltip.Value;
			if (Class5964.smethod_20(value2))
			{
				builder.method_2("item");
				builder.method_14("id", value);
				builder.method_14("tip", value2);
				builder.method_3();
			}
		}
		builder.method_3();
	}

	private void method_3(short characterId)
	{
		Class6584 @class = new Class6584(base.Context);
		@class.method_0();
		base.Writer.method_2(1);
		base.Writer.method_9("DocumentDescriptor");
		base.Writer.method_0(Class6592.DocumentDescriptorAbcData);
		@class.method_1(Enum878.const_55);
		@class.method_0();
		base.Writer.method_1(1);
		base.Writer.method_1(characterId);
		base.Writer.method_9("DocumentDescriptor");
		@class.method_1(Enum878.const_52);
	}
}
