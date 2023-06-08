using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using ns277;
using ns284;
using ns285;
using ns287;
using ns289;
using ns294;
using ns298;
using ns301;
using ns305;
using ns322;
using ns323;
using ns324;
using ns73;
using ns84;

namespace ns286;

internal class Class6772 : Class6770
{
	private readonly Class6890 class6890_0;

	private readonly Interface355 interface355_0;

	private readonly Class6889 class6889_0;

	private readonly Class6779 class6779_0;

	private readonly Interface322 interface322_0;

	private static readonly CultureInfo cultureInfo_0 = Class6872.HtmlCulture;

	private readonly Class6800 class6800_0;

	private Class7047 class7047_0;

	private Class6785 class6785_0;

	private Uri uri_0;

	private int int_0;

	private readonly List<string> list_0 = new List<string>();

	public Class6800 Binder => class6800_0;

	public Class6772(Interface355 settings, Class6890 writer, Class6779 options, Interface322 resourceLoadingCallback, Class6800 binder)
	{
		interface355_0 = settings;
		if (!string.IsNullOrEmpty(settings.BasePath))
		{
			uri_0 = new Uri(settings.BasePath, UriKind.RelativeOrAbsolute);
		}
		class6890_0 = writer;
		class6779_0 = options;
		if (options.GlyphSize != null)
		{
			class6785_0 = new Class6785(options.GlyphSize.Value / 2f, options.GlyphSize.Unit);
		}
		else
		{
			class6785_0 = new Class6785(5f, Enum920.const_4);
		}
		class6800_0 = binder;
		class6889_0 = new Class6889(this, writer, settings);
		interface322_0 = resourceLoadingCallback;
	}

	public override object imethod_102()
	{
		return class6890_0;
	}

	private void method_0(Class6983 element)
	{
		switch (element.StyleDeclarationInternal.Display.Value)
		{
		case Enum630.const_14:
			imethod_32(element);
			break;
		case Enum630.const_11:
			imethod_30(element);
			break;
		case Enum630.const_0:
			if (element.StyleDeclarationInternal.Position == Enum633.const_2)
			{
				Class6886 class2 = new Class6886(this);
				class2.Position = "absolute";
				class2.Top = element.StyleDeclarationInternal.Top.ToString();
				class2.Right = element.StyleDeclarationInternal.Right.ToString();
				class2.Bottom = element.StyleDeclarationInternal.Bottom.ToString();
				class2.Left = element.StyleDeclarationInternal.Left.ToString();
				class6889_0.method_12(class2).method_13();
			}
			if (element.StyleDeclarationInternal.WhiteSpace == Enum611.const_1)
			{
				class6889_0.method_15(element);
			}
			else
			{
				class6889_0.method_37(element);
			}
			break;
		case Enum630.const_1:
			class6889_0.method_15(element);
			break;
		case Enum630.const_2:
			if (element.StyleDeclarationInternal.Float == Enum627.const_2)
			{
				class6889_0.method_25(element);
				method_8(element);
				break;
			}
			if (element.StyleDeclarationInternal.Position == Enum633.const_2)
			{
				Class6886 class3 = new Class6886(this);
				class3.Position = "absolute";
				class3.Top = element.StyleDeclarationInternal.Top.ToString();
				class3.Right = element.StyleDeclarationInternal.Right.ToString();
				class3.Bottom = element.StyleDeclarationInternal.Bottom.ToString();
				class3.Left = element.StyleDeclarationInternal.Left.ToString();
				class6889_0.method_12(class3).method_13();
			}
			if (element.StyleDeclarationInternal.WhiteSpace == Enum611.const_1)
			{
				class6889_0.method_15(element);
			}
			else
			{
				class6889_0.method_37(element);
			}
			break;
		case Enum630.const_3:
			if (element.StyleDeclarationInternal.Position == Enum633.const_2)
			{
				Class6886 @class = new Class6886(this);
				@class.Position = "absolute";
				@class.Top = element.StyleDeclarationInternal.Top.ToString();
				@class.Right = element.StyleDeclarationInternal.Right.ToString();
				@class.Bottom = element.StyleDeclarationInternal.Bottom.ToString();
				@class.Left = element.StyleDeclarationInternal.Left.ToString();
				class6889_0.method_12(@class).method_13();
			}
			class6889_0.method_33(element).method_13();
			break;
		default:
			class6889_0.method_37(element);
			break;
		case Enum630.const_6:
			imethod_28(element);
			break;
		}
		if (element.StyleDeclarationInternal.Before == null)
		{
			return;
		}
		Class4347 before = element.StyleDeclarationInternal.Before;
		if (before.Display.Value == Enum630.const_0 || before.Display.Value == Enum630.const_1)
		{
			Class6883 class4 = new Class6883(element);
			if (class4.HasBeforeContent)
			{
				class6889_0.method_35().method_59(class4.method_0()).method_7();
			}
		}
	}

	private void method_1(Class6983 element)
	{
		if (element.StyleDeclarationInternal.After != null)
		{
			Class4347 after = element.StyleDeclarationInternal.After;
			if (after.Display.Value == Enum630.const_0 || after.Display.Value == Enum630.const_1)
			{
				Class6883 @class = new Class6883(element);
				if (@class.HasAfterContent)
				{
					class6889_0.method_35().method_59(@class.method_1()).method_7();
				}
			}
		}
		switch (element.StyleDeclarationInternal.Display.Value)
		{
		case Enum630.const_14:
			imethod_33(element);
			break;
		case Enum630.const_11:
			imethod_31(element);
			break;
		case Enum630.const_0:
			class6889_0.method_7();
			if (element.StyleDeclarationInternal.Position == Enum633.const_2)
			{
				class6889_0.method_7().method_7();
			}
			break;
		case Enum630.const_1:
			class6889_0.method_7();
			break;
		case Enum630.const_2:
			if (element.StyleDeclarationInternal.Float == Enum627.const_2)
			{
				method_9();
				class6889_0.method_7();
				break;
			}
			class6889_0.method_7();
			if (element.StyleDeclarationInternal.Position == Enum633.const_2)
			{
				class6889_0.method_7().method_7();
			}
			break;
		case Enum630.const_3:
			class6889_0.method_7().method_7();
			if (element.StyleDeclarationInternal.Position == Enum633.const_2)
			{
				class6889_0.method_7().method_7();
			}
			break;
		default:
			class6889_0.method_7();
			break;
		case Enum630.const_6:
			imethod_29(element);
			break;
		}
	}

	private void method_2(Class6983 element)
	{
		switch (element.StyleDeclarationInternal.Display.Value)
		{
		case Enum630.const_0:
			if (int_0 != 0 && element.ParentElement != null && (element.ParentElement.TagName == "OL" || element.ParentElement.TagName == "UL"))
			{
				Class6886 @class = new Class6886(this);
				@class.StartIndent = "0";
				Class6886 class2 = new Class6886(this);
				Class6886 class3 = new Class6886(this);
				class2.EndIndent = "label-end()";
				class3.StartIndent = "body-start()";
				class2.TextAlign = "right";
				class6889_0.method_27(@class).method_29(class2).method_7()
					.method_31(class3)
					.method_9()
					.method_13();
			}
			if (element.StyleDeclarationInternal.Position == Enum633.const_2)
			{
				Class6886 class4 = new Class6886(this);
				Class6976 previousSibling = element.PreviousSibling;
				if (previousSibling != null && previousSibling.NodeType == Enum969.const_0)
				{
					if (previousSibling is Class6983 class5 && class5.StyleDeclarationInternal.Display.Value == Enum630.const_0)
					{
						class4.Position = "inlineabsolute";
					}
					else
					{
						class4.Position = "absolute";
					}
				}
				else
				{
					class4.Position = "absolute";
				}
				class4.Top = element.StyleDeclarationInternal.Top.ToString();
				class4.Right = element.StyleDeclarationInternal.Right.ToString();
				class4.Bottom = element.StyleDeclarationInternal.Bottom.ToString();
				class4.Left = element.StyleDeclarationInternal.Left.ToString();
				class6889_0.method_12(class4).method_13();
			}
			if (!element.StyleDeclarationInternal.LineHeight.IsNormal && element.StyleDeclarationInternal.LineHeight.Size.Type != Enum634.const_1)
			{
				Class4337 class6 = new Class4337(element.StyleDeclarationInternal.LineHeight.Size.Value / 2f, element.StyleDeclarationInternal.LineHeight.Size.Type);
				Class6886 class7 = new Class6886(this);
				class7.BaselineShift = class6.ToString();
				class7.FontSize = "0";
				Class6886 class8 = new Class6886(this);
				class8.LeaderLength = "0";
				class6889_0.method_36(class7).method_42(class8).method_7()
					.method_7();
			}
			if (!element.StyleDeclarationInternal.Margin.Left.Auto && element.StyleDeclarationInternal.Margin.Left.Value.Value != 0f)
			{
				Class6886 class9 = new Class6886(this);
				class9.FontSize = "0";
				Class6886 class10 = new Class6886(this);
				class10.LeaderLength = element.StyleDeclarationInternal.Margin.Left.ToString();
				class6889_0.method_36(class9).method_42(class10).method_7()
					.method_7();
			}
			class6889_0.method_37(element);
			break;
		case Enum630.const_1:
			if (element.StyleDeclarationInternal.Float != Enum627.const_2)
			{
				class6889_0.method_9().method_13().method_19(element.StyleDeclarationInternal.Float);
			}
			if (element.StyleDeclarationInternal.Position == Enum633.const_1)
			{
				class6889_0.method_9();
			}
			if (element.ParentElement != null && element.ParentElement.NodeType == Enum969.const_0 && element.ParentElement.StyleDeclarationInternal.Display.Value == Enum630.const_0)
			{
				if (element.FirstElementChild == null)
				{
					class6889_0.method_15(element);
					if ((element.FirstChild == null || (element.FirstChild != null && element.FirstChild.NodeType == Enum969.const_2 && ((Class6980)element.FirstChild).IsElementContentWhitespace)) && element.method_9(element.NamespaceURI))
					{
						class6889_0.method_60("&nbsp;");
					}
				}
				else
				{
					class6889_0.method_15(element);
				}
			}
			else
			{
				class6889_0.method_10(element).method_13();
			}
			break;
		case Enum630.const_2:
			class6889_0.method_24();
			method_8(element);
			break;
		case Enum630.const_3:
			class6889_0.method_33(element).method_13();
			break;
		case Enum630.const_6:
		case Enum630.const_7:
			imethod_28(element);
			break;
		default:
			class6889_0.method_37(element);
			break;
		case Enum630.const_11:
		case Enum630.const_14:
			break;
		}
		if (element.StyleDeclarationInternal.Before == null)
		{
			return;
		}
		Class4347 before = element.StyleDeclarationInternal.Before;
		Class6883 class11 = new Class6883(element);
		Class6983 class12 = (Class6983)element.OwnerDocument.CreateElement("span");
		class12.imethod_1(null, element.imethod_0("before"));
		if (class11.HasBeforeContent)
		{
			switch (before.Display.Value)
			{
			case Enum630.const_2:
			{
				Class6980 newChild = element.OwnerDocument.method_21(before.Content.method_3());
				class12.vmethod_1(newChild);
				class12.vmethod_5(this);
				break;
			}
			case Enum630.const_0:
			case Enum630.const_3:
			case Enum630.const_7:
				class6889_0.method_37(class12).method_59(class11.method_0()).method_7();
				break;
			case Enum630.const_1:
			case Enum630.const_6:
			case Enum630.const_8:
			case Enum630.const_9:
			case Enum630.const_10:
			case Enum630.const_11:
			case Enum630.const_14:
				class6889_0.method_10(class12).method_13().method_59(class11.method_0())
					.method_7()
					.method_7();
				break;
			case Enum630.const_4:
			case Enum630.const_5:
			case Enum630.const_12:
			case Enum630.const_13:
				break;
			}
		}
	}

	private void method_3(Class6983 element)
	{
		if (element.StyleDeclarationInternal.After != null)
		{
			Class4347 after = element.StyleDeclarationInternal.After;
			Class6883 @class = new Class6883(element);
			Class6983 class2 = (Class6983)element.OwnerDocument.CreateElement("span");
			class2.imethod_1(null, element.imethod_0("after"));
			if (@class.HasAfterContent)
			{
				switch (after.Display.Value)
				{
				case Enum630.const_2:
				{
					Class6980 newChild = element.OwnerDocument.method_21(after.Content.method_3());
					class2.vmethod_1(newChild);
					class2.vmethod_5(this);
					break;
				}
				case Enum630.const_0:
				case Enum630.const_3:
				case Enum630.const_7:
					class6889_0.method_37(class2).method_59(@class.method_1()).method_7();
					break;
				case Enum630.const_1:
				case Enum630.const_6:
				case Enum630.const_8:
				case Enum630.const_9:
				case Enum630.const_10:
				case Enum630.const_11:
				case Enum630.const_14:
					class6889_0.method_10(class2).method_13().method_59(@class.method_1())
						.method_7()
						.method_7();
					break;
				}
			}
		}
		switch (element.StyleDeclarationInternal.Display.Value)
		{
		case Enum630.const_0:
			class6889_0.method_7();
			if (element.StyleDeclarationInternal.Position == Enum633.const_2)
			{
				class6889_0.method_7().method_7();
			}
			if (!element.StyleDeclarationInternal.LineHeight.IsNormal && element.StyleDeclarationInternal.LineHeight.Size.Type != Enum634.const_1)
			{
				Class4337 class3 = new Class4337(element.StyleDeclarationInternal.LineHeight.Size.Value / 2f, element.StyleDeclarationInternal.LineHeight.Size.Type);
				Class6886 class4 = new Class6886(this);
				class4.BaselineShift = "-" + class3;
				class4.FontSize = "0";
				Class6886 class5 = new Class6886(this);
				class5.LeaderLength = "0";
				class6889_0.method_36(class4).method_42(class5).method_7()
					.method_7();
			}
			if (!element.StyleDeclarationInternal.Margin.Right.Auto && element.StyleDeclarationInternal.Margin.Right.Value.Value != 0f)
			{
				class6889_0.method_39(element.StyleDeclarationInternal.Margin.Right.Value);
			}
			if (int_0 != 0 && element.ParentElement != null && (element.ParentElement.TagName == "OL" || element.ParentElement.TagName == "UL"))
			{
				class6889_0.method_7().method_7().method_7()
					.method_7();
			}
			break;
		case Enum630.const_1:
			if (element.StyleDeclarationInternal.Position == Enum633.const_1)
			{
				class6889_0.method_7();
			}
			if (element.ParentElement != null && element.ParentElement.NodeType == Enum969.const_0 && element.ParentElement.StyleDeclarationInternal.Display.Value == Enum630.const_0)
			{
				class6889_0.method_7();
			}
			else
			{
				class6889_0.method_7().method_7();
			}
			if (element.StyleDeclarationInternal.Float != Enum627.const_2)
			{
				class6889_0.method_7().method_7().method_7();
			}
			break;
		case Enum630.const_2:
			method_9();
			class6889_0.method_7();
			break;
		case Enum630.const_3:
			class6889_0.method_7().method_7();
			break;
		case Enum630.const_6:
		case Enum630.const_7:
			imethod_29(element);
			break;
		default:
			class6889_0.method_7();
			break;
		case Enum630.const_11:
		case Enum630.const_14:
			break;
		}
	}

	private void method_4(Class6983 body)
	{
		Class6886 @class = new Class6886(this);
		@class.HtmlBody = "true";
		if (!body.StyleDeclarationInternal.Background.Image.None)
		{
			@class.BackgroundAllPage = "true";
		}
		class6889_0.method_6().method_10(body.ParentNode as Class6983).method_13()
			.method_11(body, @class)
			.method_13();
	}

	private void method_5()
	{
		class6889_0.method_7().method_7().method_7()
			.method_7()
			.method_7()
			.method_7();
	}

	private static string smethod_0(string[] dimensions, int index)
	{
		string result = "auto";
		if (dimensions.Length > index)
		{
			string text = dimensions[index];
			if (text != "*" && text.Length > 0)
			{
				result = text;
			}
		}
		return result;
	}

	public override void imethod_54(Class7016 iframe)
	{
		Class6886 @class = new Class6886(this);
		if (!string.IsNullOrEmpty(iframe.Width))
		{
			@class.Width = iframe.Width;
		}
		if (!string.IsNullOrEmpty(iframe.Height))
		{
			@class.Height = iframe.Height;
		}
		if (iframe.FrameBorder == "1")
		{
			@class.BorderColor = "#cccccc";
			@class.BorderWidth = "1pt";
			@class.BorderStyle = "solid";
			@class.Overflow = "hidden";
		}
		class6889_0.method_17(@class);
		method_6(iframe.ContentDocument);
		class6889_0.method_7();
	}

	public override void imethod_56(Class7011 frameset)
	{
		method_4(frameset);
		string[] array = (string.IsNullOrEmpty(frameset.Cols) ? new string[0] : frameset.Cols.Split(','));
		string[] array2 = (string.IsNullOrEmpty(frameset.Rows) ? new string[0] : frameset.Rows.Split(','));
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = array[i].Trim();
		}
		for (int j = 0; j < array2.Length; j++)
		{
			array2[j] = array2[j].Trim();
		}
		Class6886 @class = new Class6886(this);
		@class.Width = "100%";
		@class.Height = "100%";
		@class.TableLayout = "auto";
		class6889_0.method_44(@class).method_46();
		IList<Class7010> frames = frameset.Frames;
		if (frames.Count == 0)
		{
			return;
		}
		int num = 0;
		for (int k = 0; k < Math.Max(array2.Length, 1); k++)
		{
			Class6886 class2 = new Class6886(this);
			class2.Height = smethod_0(array2, k);
			class6889_0.method_49(class2);
			for (int l = 0; l < Math.Max(array.Length, 1); l++)
			{
				Class6886 class3 = new Class6886(this);
				class3.Width = smethod_0(array, l);
				class3.BorderColor = "#cccccc";
				class3.BorderWidth = "1pt";
				class3.BorderStyle = "solid";
				class3.NumberColumnsSpanned = "1";
				class3.NumberRowsSpanned = "1";
				Class6886 properties = new Class6886(this);
				class6889_0.method_53(class3).method_17(properties);
				method_6(frames[num].ContentDocument);
				class6889_0.method_7().method_7();
				num++;
				if (frames.Count == num)
				{
					break;
				}
			}
			class6889_0.method_7();
			if (frames.Count == num)
			{
				break;
			}
		}
	}

	private void method_6(Class7047 document)
	{
		if (document == null)
		{
			return;
		}
		Class7001 body = document.Body;
		if (body != null)
		{
			class6889_0.method_10(body).method_13();
			foreach (Class6976 childNode in body.ChildNodes)
			{
				if (childNode is Class6983 @class)
				{
					@class.vmethod_5(this);
				}
			}
			class6889_0.method_7().method_7();
		}
		else
		{
			document.FrameSet?.vmethod_5(this);
		}
	}

	public override void imethod_57(Class7011 frameset)
	{
		class6889_0.method_7().method_7();
		method_5();
	}

	public override void imethod_55(Class7010 frame)
	{
	}

	public override void imethod_9(Class7015 page)
	{
		class6889_0.method_1(class6779_0, page);
	}

	public override void imethod_10(Class7015 page)
	{
		class6889_0.method_8();
	}

	public override void imethod_17(Class7001 body)
	{
		method_4(body);
	}

	public override void imethod_18(Class7001 body)
	{
		method_5();
	}

	public override void imethod_11(Class6983 htmlElement)
	{
		method_2(htmlElement);
	}

	public override void imethod_12(Class6983 htmlElement)
	{
		method_3(htmlElement);
	}

	public void method_7(Class7047 document)
	{
		if (document == null)
		{
			throw new ArgumentNullException("document");
		}
		Class7685 @class = new Class7685();
		using (new Class6805(interface355_0, interface322_0, @class))
		{
			class7047_0 = document;
			@class.method_5(new Class7449());
			@class.method_5(new Class7455("document", class7047_0));
			document.method_46(this);
			class7047_0 = null;
		}
		list_0.Clear();
	}

	public override void imethod_62(Class7034 script)
	{
		if (class7047_0 == null)
		{
			throw new InvalidOperationException("No processing document set.");
		}
		if (!Class6805.smethod_0(script.Type))
		{
			return;
		}
		Class6805 current = Class6805.Current;
		current.CurrentProcessingElement = script;
		try
		{
			current.ScriptEngine.method_3(script.Text);
		}
		catch (Exception89 exception)
		{
			list_0.Add(exception.Message);
		}
	}

	public override void imethod_19(Class6980 text)
	{
		class6889_0.method_59(text.Data);
	}

	public override void imethod_58(Class6996 htmlA)
	{
		Class6886 @class = new Class6886(this);
		if (htmlA.method_34("href"))
		{
			@class.ExternalDestination = htmlA.Href;
		}
		class6889_0.method_21(htmlA, @class);
	}

	public override void imethod_60(Class6996 htmlA)
	{
		class6889_0.method_7();
	}

	public override void imethod_5(Class6983 element)
	{
		method_0(element);
	}

	public override void imethod_6(Class6983 element)
	{
		method_1(element);
	}

	public override void imethod_7(Class6983 element)
	{
		method_0(element);
	}

	public override void imethod_8(Class6983 element)
	{
		method_1(element);
	}

	public override void imethod_0(Class7033 element)
	{
		method_0(element);
	}

	public override void imethod_1(Class7033 element)
	{
		method_1(element);
	}

	public override void imethod_2(Class7032 element)
	{
		Class6886 @class = new Class6886(this);
		@class.WhiteSpaceCollapse = "false";
		@class.WrapOption = "no-wrap";
		@class.LinefeedTreatment = "preserve";
		@class.WhiteSpaceTreatment = "preserve";
		class6889_0.method_18(element, @class);
	}

	public override void imethod_46(Class7017 img)
	{
		if (img.StyleDeclarationInternal.Display.Value == Enum630.const_1)
		{
			class6889_0.method_43().method_46().method_47()
				.method_52()
				.method_13();
		}
		string src = method_10(img.Src);
		Class6886 @class = new Class6886(this);
		@class.Src = src;
		@class.Scaling = "non-uniform";
		if (img.method_34("width") && !img.StyleDeclarationInternal.Contains(Enum600.const_284))
		{
			@class.ContentWidth = img.Width + "px";
		}
		if (img.method_34("height") && !img.StyleDeclarationInternal.Contains(Enum600.const_141))
		{
			@class.ContentHeight = img.Height + "px";
		}
		class6889_0.method_23(img, @class).method_7();
		if (img.StyleDeclarationInternal.Display.Value == Enum630.const_1)
		{
			class6889_0.method_7().method_7().method_7()
				.method_7()
				.method_7();
		}
	}

	public override bool imethod_52(Class6994 obj)
	{
		switch (obj.Type.ToLowerInvariant())
		{
		case "image/svg+xml":
		{
			if (obj.Data == null)
			{
				break;
			}
			string text = method_10(obj.Data);
			Class6814 class3 = interface322_0.imethod_0(this, new EventArgs13(text));
			if (class3.ExceptionIfAny == null && class3.Data != null)
			{
				Encoding encoding = class3.EncodingIfKnown ?? Encoding.Default;
				using (MemoryStream stream = new MemoryStream(class3.Data))
				{
					using StreamReader streamReader = new StreamReader(stream, encoding);
					string text2 = streamReader.ReadToEnd();
					class6889_0.method_40().method_4("base-dir", Path.GetDirectoryName(text)).method_60(text2)
						.method_7();
				}
				return true;
			}
			return false;
		}
		case "image/png":
		case "image/jpeg":
		{
			if (obj.Data == null)
			{
				break;
			}
			string uri = method_10(obj.Data);
			Class6814 @class = interface322_0.imethod_0(this, new EventArgs13(uri));
			if (@class.ExceptionIfAny == null && @class.Data != null)
			{
				Class6886 class2 = new Class6886(this);
				class2.Src = method_10(obj.Data);
				class2.Scaling = "non-uniform";
				if (obj.Width != null)
				{
					class2.ContentWidth = obj.Width + "px";
				}
				if (obj.Height != null)
				{
					class2.ContentHeight = obj.Height + "px";
				}
				class6889_0.method_23(obj, class2).method_7();
				return true;
			}
			return false;
		}
		}
		return false;
	}

	public override void imethod_53(Class6994 obj)
	{
	}

	public override void imethod_49(Class6986 svg)
	{
		class6889_0.method_40().method_60(svg.OuterHtml).method_7();
	}

	public override void imethod_14(Class7002 htmlBr)
	{
		class6889_0.method_13();
		if (htmlBr.ParentNode.NodeType == Enum969.const_0 && ((Class6983)htmlBr.ParentNode).StyleDeclarationInternal.Display.Value != 0)
		{
			Class6983 @class = htmlBr.PreviousElementSibling as Class6983;
			if (htmlBr.ParentElement is Class7001 && htmlBr.PreviousSibling == null)
			{
				class6889_0.method_60("&nbsp;");
			}
			else if (htmlBr.NextSibling == null && htmlBr.PreviousSibling == null)
			{
				class6889_0.method_60("&nbsp;");
			}
			else if (htmlBr.NextSibling != null && htmlBr.NextSibling.NodeType == Enum969.const_0 && htmlBr.NextSibling.LocalName.Equals("BR", StringComparison.OrdinalIgnoreCase))
			{
				class6889_0.method_60("&nbsp;");
			}
			else if (htmlBr.NextElementSibling != null && ((Class6983)htmlBr.NextElementSibling).StyleDeclarationInternal.Display.Value == Enum630.const_1)
			{
				class6889_0.method_60("&nbsp;");
			}
			else if (htmlBr.NextElementSibling != null && htmlBr.NextElementSibling.TagName == "TABLE" && @class != null && (@class.StyleDeclarationInternal.Display.Value != 0 || @class.TagName == "BR"))
			{
				class6889_0.method_60("&nbsp;");
			}
			else if (htmlBr.PreviousElementSibling != null && htmlBr.PreviousElementSibling.TagName == "TABLE")
			{
				class6889_0.method_60("&nbsp;");
			}
		}
		else if (htmlBr.NextElementSibling != null && htmlBr.NextElementSibling.TagName == "TABLE")
		{
			class6889_0.method_60("&nbsp;");
		}
		else if (htmlBr.PreviousElementSibling != null && htmlBr.PreviousElementSibling.TagName == "TABLE")
		{
			class6889_0.method_60("&nbsp;");
		}
		class6889_0.method_8();
	}

	public override void imethod_24(Class7027 ol)
	{
		class6889_0.method_25(ol);
		int_0++;
	}

	public override void imethod_25(Class7027 ol)
	{
		class6889_0.method_7();
		int_0--;
	}

	public override void imethod_20(Class7043 ul)
	{
		class6889_0.method_25(ul);
		int_0++;
	}

	public override void imethod_21(Class7043 ul)
	{
		class6889_0.method_7();
		int_0--;
	}

	public override void imethod_22(Class7021 li)
	{
		method_8(li);
	}

	public override void imethod_23(Class7021 li)
	{
		method_9();
	}

	private void method_8(Class6983 element)
	{
		Class6886 @class = new Class6886(this);
		Class6886 class2 = new Class6886(this);
		if (element.StyleDeclarationInternal.ListStyle.Position == Enum621.const_1)
		{
			@class.StartIndent = "body-start()";
			class2.StartIndent = "body-start()+24pt";
		}
		else
		{
			@class.EndIndent = "label-end()";
			class2.StartIndent = "body-start()";
		}
		@class.TextAlign = "right";
		int num = 1;
		Class6983 class3 = element;
		while (class3.PreviousElementSibling != null)
		{
			class3 = class3.PreviousElementSibling as Class6983;
			if (class3.StyleDeclarationInternal.Display.Value == Enum630.const_2)
			{
				num++;
			}
		}
		Class6886 class4 = new Class6886(this);
		class4.StartIndent = "0";
		class6889_0.method_27(class4).method_29(@class).method_14(writeEndIndent: false);
		if (element.StyleDeclarationInternal.ListStyle.Type != Enum620.const_14)
		{
			if (element.StyleDeclarationInternal.ListStyle.Image.None)
			{
				string name = Class4342.smethod_2(element.StyleDeclarationInternal.ListStyle.Type);
				Class4260 class5 = element.CSSEngine.CounterStyles[name];
				if (class5 != null)
				{
					string text = class5.Converter.vmethod_0(num);
					if (class5.Type == Class4260.Enum500.const_1)
					{
						text += ".";
					}
					class6889_0.method_59(text);
				}
			}
			else
			{
				string src = method_10(element.StyleDeclarationInternal.ListStyle.Image.Uri);
				Class6886 class6 = new Class6886(this);
				class6.Src = src;
				class6.Scaling = "non-uniform";
				class6889_0.method_23(element, class6).method_7();
			}
		}
		class6889_0.method_7().method_7().method_31(class2)
			.method_9()
			.method_13()
			.method_10(element)
			.method_13();
	}

	private void method_9()
	{
		class6889_0.method_7().method_7().method_7()
			.method_7()
			.method_7()
			.method_7();
	}

	public override void imethod_91(Class7006 htmlDl)
	{
		class6889_0.method_15(htmlDl);
	}

	public override void imethod_92(Class7006 htmlDl)
	{
		class6889_0.method_7();
	}

	public override void imethod_95(Class6983 htmlDt)
	{
		method_0(htmlDt);
	}

	public override void imethod_96(Class6983 htmlDt)
	{
		class6889_0.method_7();
	}

	public override void imethod_93(Class6983 htmlDd)
	{
		method_0(htmlDd);
	}

	public override void imethod_94(Class6983 htmlDd)
	{
		class6889_0.method_7();
	}

	public override Interface325 imethod_28(Class6983 element)
	{
		Class6983 parentElement = element.ParentElement;
		if (parentElement != null && parentElement.StyleDeclarationInternal.Display.Value == Enum630.const_0)
		{
			class6889_0.method_59(" ").method_32().method_13();
		}
		Class6802 @class = new Class6802(this, element, this, class6889_0);
		@class.Write();
		if (parentElement != null && parentElement.StyleDeclarationInternal.Display.Value == Enum630.const_0)
		{
			class6889_0.method_7().method_7();
		}
		return new Class6771();
	}

	public override void imethod_32(Class6983 element)
	{
		Class6886 @class = new Class6886(this);
		if (element is Class7038 class2)
		{
			@class.NumberColumnsSpanned = class2.ColSpan.ToString();
			int num = class2.RowSpan;
			if (num > 1)
			{
				Class7040 class3 = class2.ParentElement as Class7040;
				int rowIndex = class3.RowIndex;
				Class6983 parentElement = class3.ParentElement;
				Class6993 class4 = null;
				while (element != null)
				{
					class4 = parentElement as Class6993;
					if (class4 != null)
					{
						break;
					}
					parentElement = parentElement.ParentElement;
				}
				if (class4 != null)
				{
					int length = class4.Rows.Length;
					int num2 = length - rowIndex;
					if (num > num2)
					{
						num = num2;
					}
				}
				else
				{
					num = 1;
				}
			}
			@class.NumberRowsSpanned = num.ToString();
		}
		if (element.StyleDeclarationInternal.EmptyCells == Enum628.const_1)
		{
			string text2 = (@class.BorderBottomColor = "transparent");
			string text4 = (@class.BorderTopColor = text2);
			string text6 = (@class.BorderLeftColor = text4);
			string text8 = (@class.BorderRightColor = text6);
			string text10 = (@class.BorderColor = text8);
			string backgroundColor = (@class.Color = text10);
			@class.BackgroundColor = backgroundColor;
		}
		class6889_0.method_54(element, @class).method_13();
	}

	public override void imethod_33(Class6983 td)
	{
		class6889_0.method_7().method_7();
	}

	public override void imethod_34(Class6983 element)
	{
		Class6886 @class = new Class6886(this);
		string text = element.method_20("rowspan");
		if (text != null)
		{
			@class.NumberRowsSpanned = text;
		}
		text = element.method_20("colspan");
		if (text != null)
		{
			@class.NumberColumnsSpanned = text;
		}
		class6889_0.method_54(element, @class).method_17(@class);
	}

	public override void imethod_35(Class6983 th)
	{
		class6889_0.method_7().method_7();
	}

	public override void imethod_70(Class6995 button)
	{
		method_11();
		Class6886 @class = new Class6886(this);
		@class.ControlType = "button";
		@class.DominantBaseline = "central";
		string text = button.Value;
		if (string.IsNullOrEmpty(text))
		{
			text = " ";
		}
		bool flag;
		if (flag = button.Type != null && "file".Equals(button.Type, StringComparison.OrdinalIgnoreCase))
		{
			text = "Choose File";
		}
		SizeF sizeF = Class6971.Instance.method_0(text, button.Style.FontFamilyName, button.Style.FontSize, button.Style.FontStyle);
		sizeF.Height = button.Style.FontSize;
		sizeF.Width = (float)Math.Ceiling(sizeF.Width + 12f);
		if (!button.StyleDeclarationInternal.Width.IsAuto && !flag)
		{
			@class.ControlWidth = button.StyleDeclarationInternal.Width.ToString();
		}
		else
		{
			@class.ControlWidth = sizeF.Width.ToString(cultureInfo_0);
		}
		float unitValue = (float)Math.Ceiling(Class6969.smethod_15(sizeF.Height));
		Class4337 class2 = ((!button.StyleDeclarationInternal.Height.IsAuto) ? new Class4337(button.StyleDeclarationInternal.Height.Value.Value, button.StyleDeclarationInternal.Height.Value.Type) : new Class4337(unitValue, Enum634.const_4));
		@class.ControlHeight = new Class4337(class2.Value, class2.Type).ToString();
		class2 = new Class4337(class2.Value / 2f, class2.Type);
		Class6886 class3 = new Class6886(this);
		class3.LeaderLength = @class.ControlWidth;
		class6889_0.method_38(button, @class).method_42(class3).method_7();
		Class6886 class4 = new Class6886(this);
		class4.BaselineShift = class2.ToString();
		class4.FontSize = "0";
		class3.LeaderLength = "0";
		class6889_0.method_36(class4).method_42(class3).method_7()
			.method_7();
		class4 = new Class6886(this);
		class4.BaselineShift = "-" + class2;
		class4.FontSize = "0";
		class3.LeaderLength = "0";
		class6889_0.method_36(class4).method_42(class3).method_7()
			.method_7();
		Class6886 class5 = new Class6886(this);
		class5.ControlValue = "true";
		class5.FontSize = "0";
		class6889_0.method_36(class5).method_59(Class6968.smethod_0(text)).method_7();
		Class6886 class6 = new Class6886(this);
		class6.ControlType = "end";
		class3.LeaderLength = "0";
		class6889_0.method_36(class6).method_42(class3).method_7()
			.method_7();
		if (flag)
		{
			class6889_0.method_35().method_59("No file chosen").method_7();
		}
		class6889_0.method_7();
		method_11();
	}

	public override void imethod_69(Class7003 htmlButton)
	{
		method_11();
		Class6886 @class = new Class6886(this);
		@class.ControlType = "button";
		@class.DominantBaseline = "central";
		string text = htmlButton.Value;
		if (string.IsNullOrEmpty(text))
		{
			text = " ";
		}
		SizeF sizeF = ((!(htmlButton.Style.FontSize > 0f)) ? SizeF.Empty : Class6971.Instance.method_0(text, htmlButton.Style.FontFamilyName, htmlButton.Style.FontSize, htmlButton.Style.FontStyle));
		if (htmlButton.StyleDeclarationInternal.Width.IsAuto)
		{
			@class.ControlWidth = sizeF.Width.ToString(cultureInfo_0);
		}
		else
		{
			@class.ControlWidth = htmlButton.StyleDeclarationInternal.Width.ToString();
		}
		if (htmlButton.StyleDeclarationInternal.Height.IsAuto)
		{
			@class.ControlHeight = sizeF.Height.ToString(cultureInfo_0);
		}
		else
		{
			@class.ControlHeight = htmlButton.StyleDeclarationInternal.Height.ToString();
		}
		Class6886 class2 = new Class6886(this);
		class2.LeaderLength = @class.ControlWidth;
		class6889_0.method_38(htmlButton, @class).method_42(class2).method_7();
		Class6886 class3 = new Class6886(this);
		class3.BaselineShift = "10pt";
		class3.FontSize = "0";
		class2.LeaderLength = "0";
		class6889_0.method_36(class3).method_42(class2).method_7()
			.method_7();
		class3 = new Class6886(this);
		class3.BaselineShift = "-10pt";
		class3.FontSize = "0";
		class2.LeaderLength = "0";
		class6889_0.method_36(class3).method_42(class2).method_7()
			.method_7();
		Class6886 class4 = new Class6886(this);
		class4.ControlValue = "true";
		class4.FontSize = "0";
		class6889_0.method_36(class4).method_59(Class6968.smethod_0(text)).method_7();
		Class6886 class5 = new Class6886(this);
		class5.ControlType = "content";
		class6889_0.method_36(class5);
		htmlButton.method_48(this);
		class6889_0.method_7();
		Class6886 class6 = new Class6886(this);
		class6.ControlType = "end";
		class2.LeaderLength = "0";
		class6889_0.method_36(class6).method_42(class2).method_7()
			.method_7();
		class6889_0.method_7();
		method_11();
	}

	public override void imethod_88(Class6995 htmlRadio)
	{
		method_11();
		Class6886 @class = new Class6886(this);
		@class.ControlType = "radiobutton";
		@class.DominantBaseline = "central";
		string text = htmlRadio.Value;
		if (string.IsNullOrEmpty(text))
		{
			text = " ";
		}
		if (htmlRadio.StyleDeclarationInternal.Width.IsAuto)
		{
			@class.ControlWidth = class6779_0.GlyphSize.ToString();
		}
		else
		{
			@class.ControlWidth = htmlRadio.StyleDeclarationInternal.Width.ToString();
		}
		Class6886 class2 = new Class6886(this);
		if (htmlRadio.StyleDeclarationInternal.Width.IsAuto)
		{
			@class.ControlWidth = class6779_0.GlyphSize.ToString();
			class2.LeaderLength = new Class6785(class6779_0.GlyphSize.Value + 2f, class6779_0.GlyphSize.Unit).ToString();
		}
		else
		{
			@class.ControlWidth = htmlRadio.StyleDeclarationInternal.Width.ToString();
			class2.LeaderLength = new Class4337(htmlRadio.StyleDeclarationInternal.Width.Value.Value + 2f, htmlRadio.StyleDeclarationInternal.Width.Value.Type).ToString();
		}
		if (htmlRadio.StyleDeclarationInternal.Height.IsAuto)
		{
			@class.ControlHeight = class6779_0.GlyphSize.ToString();
		}
		else
		{
			@class.ControlHeight = htmlRadio.StyleDeclarationInternal.Height.ToString();
		}
		class6889_0.method_38(htmlRadio, @class).method_42(class2).method_7();
		Class6886 class3 = new Class6886(this);
		class3.BaselineShift = class6785_0.ToString();
		class3.FontSize = "0";
		class2.LeaderLength = "0";
		class6889_0.method_36(class3).method_42(class2).method_7()
			.method_7();
		class3 = new Class6886(this);
		class3.BaselineShift = "-" + class6785_0;
		class3.FontSize = "0";
		class2.LeaderLength = "0";
		class6889_0.method_36(class3).method_42(class2).method_7()
			.method_7();
		Class6886 class4 = new Class6886(this);
		class4.ControlSelected = (htmlRadio.Checked ? bool.TrueString : bool.FalseString);
		class4.FontSize = "0";
		class6889_0.method_36(class4).method_59(Class6968.smethod_0(text)).method_7();
		class4 = new Class6886(this);
		class4.ControlValue = "true";
		class4.FontSize = "0";
		class6889_0.method_36(class4).method_59(Class6968.smethod_0(text)).method_7();
		Class6886 class5 = new Class6886(this);
		class5.ControlType = "end";
		class2.LeaderLength = "0";
		class6889_0.method_36(class5).method_42(class2).method_7()
			.method_7();
		class6889_0.method_7();
		method_11();
	}

	public override void imethod_65(Class7007 htmlFieldSet)
	{
		method_2(htmlFieldSet);
	}

	public override void imethod_66(Class7007 htmlFieldSet)
	{
		method_3(htmlFieldSet);
	}

	public override void imethod_74(Class6995 textField)
	{
		imethod_87(textField);
	}

	public override void imethod_87(Class6995 textField)
	{
		method_11();
		Class6886 @class = new Class6886(this);
		@class.ControlType = "editbox";
		@class.DominantBaseline = "central";
		SizeF sizeF = Class6971.Instance.method_1(textField.Style.FontFamilyName, textField.Style.FontSize, textField.Style.FontStyle);
		sizeF.Height = textField.Style.FontSize;
		sizeF.Width = (float)Math.Ceiling(sizeF.Width);
		Class7045 class2 = textField.method_23("cols");
		Class7045 class3 = textField.method_23("size");
		int result = 1;
		if (class2 != null && !int.TryParse(class2.Value, out result))
		{
			result = 1;
		}
		else if (class3 != null && !int.TryParse(class3.Value, out result))
		{
			result = 1;
		}
		if (textField.StyleDeclarationInternal.Width.IsAuto)
		{
			@class.ControlWidth = "155px";
		}
		else
		{
			@class.ControlWidth = textField.StyleDeclarationInternal.Width.ToString();
		}
		float num = (float)Math.Ceiling(Class6969.smethod_15(sizeF.Height));
		Class4337 class4;
		if (textField.StyleDeclarationInternal.Height.IsAuto)
		{
			@class.ControlHeight = new Class4337(num, Enum634.const_4).ToString();
			class4 = new Class4337(num / 2f, Enum634.const_4);
		}
		else
		{
			@class.ControlHeight = textField.StyleDeclarationInternal.Height.ToString();
			class4 = new Class4337(textField.StyleDeclarationInternal.Height.Value.Value / 2f, textField.StyleDeclarationInternal.Height.Value.Type);
		}
		Class6886 class5 = new Class6886(this);
		class5.LeaderLength = @class.ControlWidth;
		class6889_0.method_38(textField, @class).method_42(class5).method_7();
		Class6886 class6 = new Class6886(this);
		class6.BaselineShift = class4.ToString();
		class6.FontSize = "0";
		class5.LeaderLength = "0";
		class6889_0.method_36(class6).method_42(class5).method_7()
			.method_7();
		class6 = new Class6886(this);
		class6.BaselineShift = "-" + class4;
		class6.FontSize = "0";
		class5.LeaderLength = "0";
		class6889_0.method_36(class6).method_42(class5).method_7()
			.method_7();
		Class6886 class7 = new Class6886(this);
		class7.ControlValue = "true";
		class7.FontSize = "0";
		class6889_0.method_36(class7).method_59((textField.Value != null) ? Class6968.smethod_0(textField.Value) : string.Empty).method_7();
		Class6886 class8 = new Class6886(this);
		class5 = new Class6886(this);
		class8.ControlType = "end";
		class5.LeaderLength = "0";
		class6889_0.method_36(class8).method_42(class5).method_7()
			.method_7();
		class6889_0.method_7();
		method_11();
	}

	public override void imethod_71(Class6995 checkbox)
	{
		method_11();
		Class6886 @class = new Class6886(this);
		@class.ControlType = "checkbox";
		@class.DominantBaseline = "central";
		string text = checkbox.Value;
		if (string.IsNullOrEmpty(text))
		{
			text = " ";
		}
		Class6886 class2 = new Class6886(this);
		if (checkbox.StyleDeclarationInternal.Width.IsAuto)
		{
			@class.ControlWidth = class6779_0.GlyphSize.ToString();
			class2.LeaderLength = new Class6785(class6779_0.GlyphSize.Value + 2f, class6779_0.GlyphSize.Unit).ToString();
		}
		else
		{
			@class.ControlWidth = checkbox.StyleDeclarationInternal.Width.ToString();
			class2.LeaderLength = new Class4337(checkbox.StyleDeclarationInternal.Width.Value.Value + 2f, checkbox.StyleDeclarationInternal.Width.Value.Type).ToString();
		}
		if (checkbox.StyleDeclarationInternal.Height.IsAuto)
		{
			@class.ControlHeight = class6779_0.GlyphSize.ToString();
		}
		else
		{
			@class.ControlHeight = checkbox.StyleDeclarationInternal.Height.ToString();
		}
		class6889_0.method_38(checkbox, @class).method_42(class2).method_7();
		Class6886 class3 = new Class6886(this);
		class3.BaselineShift = class6785_0.ToString();
		class3.FontSize = "0";
		class2.LeaderLength = "0";
		class6889_0.method_36(class3).method_42(class2).method_7()
			.method_7();
		class3 = new Class6886(this);
		class3.BaselineShift = "-" + class6785_0;
		class3.FontSize = "0";
		class2.LeaderLength = "0";
		class6889_0.method_36(class3).method_42(class2).method_7()
			.method_7();
		Class6886 class4 = new Class6886(this);
		class4.ControlSelected = (checkbox.Checked ? bool.TrueString : bool.FalseString);
		class4.FontSize = "0";
		class6889_0.method_36(class4).method_59(Class6968.smethod_0(text)).method_7();
		class4 = new Class6886(this);
		class4.ControlValue = "true";
		class4.FontSize = "0";
		class6889_0.method_36(class4).method_59(Class6968.smethod_0(text)).method_7();
		Class6886 class5 = new Class6886(this);
		class5.ControlType = "end";
		class2.LeaderLength = "0";
		class6889_0.method_36(class5).method_42(class2).method_7()
			.method_7();
		class6889_0.method_7();
		method_11();
	}

	public override void imethod_13(Class7014 htmlHr)
	{
		string leaderLength = (htmlHr.StyleDeclarationInternal.Width.IsAuto ? "100%" : htmlHr.StyleDeclarationInternal.Width.ToString());
		Class6886 @class = new Class6886(this);
		@class.LeaderPattern = "rule";
		@class.LeaderLength = leaderLength;
		@class.TextAlign = Class4342.smethod_2(htmlHr.StyleDeclarationInternal.TextAlign);
		@class.RuleStyle = "double";
		@class.RuleThickness = "1pt";
		Class6886 class2 = new Class6886(this);
		class2.TextAlign = @class.TextAlign;
		class6889_0.method_17(class2).method_42(@class).method_7()
			.method_7();
	}

	public override Interface325 imethod_89(Class7042 htmlTextarea)
	{
		method_11();
		Class6886 @class = new Class6886(this);
		@class.ControlType = "editbox";
		@class.DominantBaseline = "central";
		SizeF sizeF = Class6971.Instance.method_1(htmlTextarea.Style.FontFamilyName, htmlTextarea.Style.FontSize, htmlTextarea.Style.FontStyle);
		float num = (float)Math.Ceiling(Class6969.smethod_15(sizeF.Height));
		if (htmlTextarea.StyleDeclarationInternal.Width.IsAuto)
		{
			@class.ControlWidth = (sizeF.Width * (float)htmlTextarea.Cols).ToString(cultureInfo_0);
		}
		else
		{
			@class.ControlWidth = htmlTextarea.StyleDeclarationInternal.Width.ToString();
		}
		Class4337 class2;
		if (htmlTextarea.StyleDeclarationInternal.Height.IsAuto)
		{
			float num2 = (float)htmlTextarea.Rows * num;
			@class.ControlHeight = new Class4337(num2, Enum634.const_4).ToString();
			class2 = new Class4337(num2 / 2f, Enum634.const_4);
		}
		else
		{
			@class.ControlHeight = htmlTextarea.StyleDeclarationInternal.Height.ToString();
			class2 = new Class4337(htmlTextarea.StyleDeclarationInternal.Height.Value.Value / 2f, htmlTextarea.StyleDeclarationInternal.Height.Value.Type);
		}
		Class6886 class3 = new Class6886(this);
		class3.LeaderLength = @class.ControlWidth;
		class6889_0.method_38(htmlTextarea, @class).method_42(class3).method_7();
		Class6886 class4 = new Class6886(this);
		class4.BaselineShift = class2.ToString();
		class4.FontSize = "0";
		class3.LeaderLength = "0";
		class6889_0.method_36(class4).method_42(class3).method_7()
			.method_7();
		class4 = new Class6886(this);
		class4.BaselineShift = "-" + class2;
		class4.FontSize = "0";
		class3.LeaderLength = "0";
		class6889_0.method_36(class4).method_42(class3).method_7()
			.method_7();
		Class6886 class5 = new Class6886(this);
		class5.ControlValue = "true";
		class5.FontSize = "0";
		string[] array = Class6968.smethod_0(htmlTextarea.TextContent).Split('\n');
		foreach (string text in array)
		{
			string text2 = text.Trim('\r');
			class6889_0.method_36(class5);
			if (text2.Length != 0)
			{
				class6889_0.method_59(text2);
			}
			else
			{
				class6889_0.method_59(new string('\u200b', 1));
			}
			class6889_0.method_7();
		}
		return new Class6771();
	}

	public override void imethod_90(Class7042 htmlTextarea, Interface325 textareaVisitor)
	{
		Class6886 @class = new Class6886(this);
		Class6886 class2 = new Class6886(this);
		@class.ControlType = "end";
		class2.LeaderLength = "0";
		class6889_0.method_36(@class).method_42(class2).method_7()
			.method_7();
		class6889_0.method_7();
		method_11();
	}

	public override Interface325 imethod_63(Class7035 htmlSelect)
	{
		method_11();
		List<string> list = new List<string>();
		int num = -1;
		for (Class6983 @class = htmlSelect.FirstElementChild as Class6983; @class != null; @class = @class.NextElementSibling as Class6983)
		{
			if (@class.NodeType == Enum969.const_0 && @class.LocalName.Equals("option", StringComparison.OrdinalIgnoreCase))
			{
				Class7029 class2 = @class as Class7029;
				string text = @class.NodeValue;
				if (string.IsNullOrEmpty(text))
				{
					if (@class.NextSibling != null && @class.NextSibling.NodeType == Enum969.const_2)
					{
						text = @class.NextSibling.NodeValue;
					}
					else if (text == null)
					{
						text = string.Empty;
					}
				}
				if (class2.Selected)
				{
					num = list.Count;
				}
				list.Add(text);
			}
		}
		Class6886 class3 = new Class6886(this);
		class3.ControlType = "combobox";
		class3.DominantBaseline = "central";
		SizeF sizeF = Class6971.Instance.method_1(htmlSelect.Style.FontFamilyName, htmlSelect.Style.FontSize, htmlSelect.Style.FontStyle);
		sizeF.Height = htmlSelect.Style.FontSize;
		sizeF.Width = (float)Math.Ceiling(sizeF.Width);
		float num2 = (float)Math.Ceiling(Class6969.smethod_15(sizeF.Height));
		Class4337 class4;
		if (htmlSelect.StyleDeclarationInternal.Height.IsAuto)
		{
			class3.ControlHeight = new Class4337(num2, Enum634.const_4).ToString();
			class4 = new Class4337(num2 / 2f, Enum634.const_4);
		}
		else
		{
			class3.ControlHeight = htmlSelect.StyleDeclarationInternal.Height.ToString();
			class4 = new Class4337(htmlSelect.StyleDeclarationInternal.Height.Value.Value / 2f, htmlSelect.StyleDeclarationInternal.Height.Value.Type);
		}
		if (!htmlSelect.StyleDeclarationInternal.Width.IsAuto)
		{
			class3.ControlWidth = htmlSelect.StyleDeclarationInternal.Width.ToString();
		}
		else if (list.Count != 0)
		{
			string text2 = string.Empty;
			foreach (string item in list)
			{
				if (item.Length > text2.Length)
				{
					text2 = item;
				}
			}
			sizeF = Class6971.Instance.method_0(text2, htmlSelect.Style.FontFamilyName, htmlSelect.Style.FontSize, htmlSelect.Style.FontStyle);
			sizeF.Height = htmlSelect.Style.FontSize;
			sizeF.Width = (float)Math.Ceiling(sizeF.Width);
			class3.ControlWidth = sizeF.Width.ToString(cultureInfo_0);
		}
		else
		{
			class3.ControlWidth = "0pt";
		}
		Class6886 class5 = new Class6886(this);
		class5.LeaderLength = class3.ControlWidth;
		class6889_0.method_38(htmlSelect, class3).method_42(class5).method_7();
		Class6886 class6 = new Class6886(this);
		class6.BaselineShift = class4.ToString();
		class6.FontSize = "0";
		class5.LeaderLength = "0";
		class6889_0.method_36(class6).method_42(class5).method_7()
			.method_7();
		class6 = new Class6886(this);
		class6.BaselineShift = "-" + class4;
		class6.FontSize = "0";
		class5.LeaderLength = "0";
		class6889_0.method_36(class6).method_42(class5).method_7()
			.method_7();
		for (int i = 0; i < list.Count; i++)
		{
			Class6886 class7 = new Class6886(this);
			class7.ControlValue = "true";
			class7.FontSize = "0";
			if (i == num)
			{
				class7.ControlSelected = "true";
			}
			class6889_0.method_36(class7).method_59(Class6968.smethod_0(list[i])).method_7();
		}
		return new Class6771();
	}

	public override void imethod_64(Class7035 htmlSelect, Interface325 optionsVisitor)
	{
		Class6886 @class = new Class6886(this);
		Class6886 class2 = new Class6886(this);
		@class.ControlType = "end";
		class2.LeaderLength = "0";
		class6889_0.method_36(@class).method_42(class2).method_7()
			.method_7();
		class6889_0.method_7();
		method_11();
	}

	public override void imethod_101(Class6999 baseElement)
	{
		if (!string.IsNullOrEmpty(baseElement.Href) && Uri.TryCreate(baseElement.Href, UriKind.RelativeOrAbsolute, out var result))
		{
			uri_0 = result;
		}
	}

	public string method_10(string path)
	{
		if (uri_0 != null && uri_0.OriginalString == ".")
		{
			return path;
		}
		if (Uri.TryCreate(path, UriKind.RelativeOrAbsolute, out var result))
		{
			if (result.IsAbsoluteUri)
			{
				return path;
			}
			if (uri_0 != null)
			{
				if (uri_0.HostNameType != UriHostNameType.Dns && uri_0.HostNameType != UriHostNameType.IPv4 && uri_0.HostNameType != UriHostNameType.IPv6)
				{
					result = new Uri(Path.Combine(uri_0.LocalPath, path), UriKind.RelativeOrAbsolute);
					if (result.IsAbsoluteUri && result.IsFile)
					{
						return result.LocalPath;
					}
					return result.ToString();
				}
				if (Uri.TryCreate(uri_0, result, out result))
				{
					return result.ToString();
				}
			}
		}
		path = ((!string.IsNullOrEmpty(interface355_0.BasePath)) ? Path.Combine(interface355_0.BasePath, path) : path);
		path = path.Replace("\\", "/");
		return path;
	}

	private void method_11()
	{
		Class6886 @class = new Class6886(this);
		@class.LeaderLength = "4px";
		class6889_0.method_35().method_42(@class).method_7()
			.method_7();
	}
}
