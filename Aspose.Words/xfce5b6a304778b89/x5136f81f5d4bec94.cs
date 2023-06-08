using System;
using Aspose.Words;
using Aspose.Words.Fields;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xbe73d5820f7f4ae3;
using xfbd1009a0cbb9842;

namespace xfce5b6a304778b89;

internal class x5136f81f5d4bec94
{
	private x5136f81f5d4bec94()
	{
	}

	internal static bool x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, Paragraph x9c79b5ad7b769b12, xeedad81aaed42a76 x789564759d365819, Style xce987d84406b1bfc, x38c672d671ef22c7 x5173842427610357, CompositeNode xbe8ce7206677d91d)
	{
		switch (xe134235b3526fa75.xca994afbcb9073a2.xa66385d80d4d296f)
		{
		case "bookmark-ref":
			x95cafe3515aa0190(xe134235b3526fa75, x9c79b5ad7b769b12, x789564759d365819, xce987d84406b1bfc);
			return true;
		case "editing-cycles":
			xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, FieldType.FieldRevisionNum, "REVNUM", x789564759d365819, xce987d84406b1bfc);
			return true;
		case "editing-duration":
			xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, FieldType.FieldEditTime, "EDITTIME", x789564759d365819, xce987d84406b1bfc);
			return true;
		case "keywords":
			xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, FieldType.FieldKeyword, "KEYWORDS", x789564759d365819, xce987d84406b1bfc);
			return true;
		case "subject":
			xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, FieldType.FieldSubject, "SUBJECT", x789564759d365819, xce987d84406b1bfc);
			return true;
		case "description":
			xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, FieldType.FieldComments, "COMMENTS", x789564759d365819, xce987d84406b1bfc);
			return true;
		case "a":
			xb3cbf39b03c7986e(xe134235b3526fa75, x9c79b5ad7b769b12, x5173842427610357, xbe8ce7206677d91d, x789564759d365819, xce987d84406b1bfc);
			return true;
		case "database-display":
			xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, FieldType.FieldMergeField, string.Format("MERGEFIELD {0}", xe134235b3526fa75.xca994afbcb9073a2.xd68abcd61e368af9("column-name", null)), x789564759d365819, xce987d84406b1bfc);
			return true;
		case "database-next":
			xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, FieldType.FieldNext, "NEXT", x789564759d365819, xce987d84406b1bfc);
			return true;
		case "database-row-number":
			xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, FieldType.FieldMergeRec, "MERGEREC", x789564759d365819, xce987d84406b1bfc);
			return true;
		case "sequence":
			xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, FieldType.FieldSequence, string.Format("SEQ {0}", xe134235b3526fa75.xca994afbcb9073a2.xd68abcd61e368af9("name", "")), x789564759d365819, xce987d84406b1bfc);
			return true;
		case "file-name":
		{
			string x5cae0492911d = xe134235b3526fa75.xca994afbcb9073a2.xd68abcd61e368af9("display", "name-and-extension");
			xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, FieldType.FieldFileName, xbb857c9fc36f5054.x1df4eb4d918afe39(x5cae0492911d), x789564759d365819, xce987d84406b1bfc);
			return true;
		}
		case "template-name":
		{
			string text = xe134235b3526fa75.xca994afbcb9073a2.xd68abcd61e368af9("display", "name-and-extension");
			xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, FieldType.FieldTemplate, (text == "full") ? "\\p" : "", x789564759d365819, xce987d84406b1bfc);
			return true;
		}
		case "variable-set":
			x9a934a26f31a27ec(xe134235b3526fa75, x9c79b5ad7b769b12, x789564759d365819, xce987d84406b1bfc);
			return true;
		case "variable-get":
			x2214941c12765829(xe134235b3526fa75, x9c79b5ad7b769b12, x789564759d365819, xce987d84406b1bfc);
			return true;
		case "page-number":
			xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, FieldType.FieldPage, "PAGE", x789564759d365819, xce987d84406b1bfc);
			return true;
		case "author-name":
			xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, FieldType.FieldUserName, "USERNAME", x789564759d365819, xce987d84406b1bfc);
			return true;
		case "author-initials":
			xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, FieldType.FieldUserInitials, "USERINITIALS", x789564759d365819, xce987d84406b1bfc);
			return true;
		case "initial-creator":
			xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, FieldType.FieldAuthor, "AUTHOR", x789564759d365819, xce987d84406b1bfc);
			return true;
		case "date":
			xf1a5675dddec7694(xe134235b3526fa75, x9c79b5ad7b769b12, "DATE", x789564759d365819, xce987d84406b1bfc);
			return true;
		case "time":
			xf1a5675dddec7694(xe134235b3526fa75, x9c79b5ad7b769b12, "TIME", x789564759d365819, xce987d84406b1bfc);
			return true;
		case "print-date":
		case "print-time":
			xf1a5675dddec7694(xe134235b3526fa75, x9c79b5ad7b769b12, "PRINTDATE", x789564759d365819, xce987d84406b1bfc);
			return true;
		case "creation-date":
		case "creation-time":
			xf1a5675dddec7694(xe134235b3526fa75, x9c79b5ad7b769b12, "CREATEDATE", x789564759d365819, xce987d84406b1bfc);
			return true;
		case "title":
			xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, FieldType.FieldTitle, "TITLE", x789564759d365819, xce987d84406b1bfc);
			return true;
		case "modification-time":
		case "modification-date":
			xf1a5675dddec7694(xe134235b3526fa75, x9c79b5ad7b769b12, "SAVEDATE", x789564759d365819, xce987d84406b1bfc);
			return true;
		case "creator":
			xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, FieldType.FieldLastSavedBy, "LASTSAVEDBY", x789564759d365819, xce987d84406b1bfc);
			return true;
		case "paragraph-count":
			xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, FieldType.FieldDocProperty, "DOCPROPERTY PARAGRAPHS", x789564759d365819, xce987d84406b1bfc);
			return true;
		case "character-count":
			xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, FieldType.FieldDocProperty, "DOCPROPERTY CHARACTERSWITHSPACES", x789564759d365819, xce987d84406b1bfc);
			return true;
		case "page-count":
			xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, FieldType.FieldNumPages, string.Format("NUMPAGES{0}", xbb857c9fc36f5054.xfc7542210cd3a6d0(xe134235b3526fa75.xca994afbcb9073a2.xd68abcd61e368af9("num-format", ""))), x789564759d365819, xce987d84406b1bfc);
			return true;
		case "word-count":
			xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, FieldType.FieldNumWords, string.Format("NUMWORDS{0}", xbb857c9fc36f5054.xfc7542210cd3a6d0(xe134235b3526fa75.xca994afbcb9073a2.xd68abcd61e368af9("num-format", ""))), x789564759d365819, xce987d84406b1bfc);
			return true;
		case "text-input":
			xae61105ec4f607a4(xe134235b3526fa75, x9c79b5ad7b769b12, x789564759d365819, xce987d84406b1bfc);
			return true;
		case "drop-down":
			x40f888329312fd72(xe134235b3526fa75, x9c79b5ad7b769b12, x789564759d365819, xce987d84406b1bfc);
			return true;
		case "user-defined":
		{
			string arg = xe134235b3526fa75.xca994afbcb9073a2.xd68abcd61e368af9("name", "");
			xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, FieldType.FieldDocProperty, $"DOCPROPERTY \"{arg}\"", x789564759d365819, xce987d84406b1bfc);
			return true;
		}
		default:
			return false;
		}
	}

	private static void x95cafe3515aa0190(xf871da68decec406 xe134235b3526fa75, Paragraph x9c79b5ad7b769b12, xeedad81aaed42a76 x789564759d365819, Style xce987d84406b1bfc)
	{
		string text = xe134235b3526fa75.xca994afbcb9073a2.xd68abcd61e368af9("reference-format", "text");
		string arg = xe134235b3526fa75.xca994afbcb9073a2.xd68abcd61e368af9("ref-name", "");
		FieldType x77ce91e5324df = FieldType.FieldRef;
		string x0e59413709b;
		if (!(text == "page") && !text.StartsWith("number"))
		{
			x0e59413709b = ((!(text == "direction")) ? $"REF {arg}" : $"REF {arg} \\p");
		}
		else
		{
			x0e59413709b = $"PAGEREF {arg}";
			x77ce91e5324df = FieldType.FieldPageRef;
		}
		xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, x77ce91e5324df, x0e59413709b, x789564759d365819, xce987d84406b1bfc);
	}

	internal static void xb3cbf39b03c7986e(xf871da68decec406 xe134235b3526fa75, Paragraph x9c79b5ad7b769b12, x38c672d671ef22c7 x5173842427610357, CompositeNode xbe8ce7206677d91d, xeedad81aaed42a76 x789564759d365819, Style xce987d84406b1bfc)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		string xd8a1c7c41bfbcde = xca994afbcb9073a.xd8a1c7c41bfbcde0;
		if (xd8a1c7c41bfbcde == "text")
		{
			x00220d40d1a5427b(x9c79b5ad7b769b12, xce987d84406b1bfc, new FieldStart(xe134235b3526fa75.x2c8c6741422a1298, x789564759d365819, FieldType.FieldHyperlink));
		}
		string text = "";
		string text2 = "";
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "href":
				text = xbb857c9fc36f5054.x573fbc1b32ee4645(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			case "target-frame-name":
				text2 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			}
		}
		if (xd8a1c7c41bfbcde == "text")
		{
			if (x0d299f323d241756.x5959bccb67bbf051(text))
			{
				string text3 = $"HYPERLINK \"{text}\"";
				if (x0d299f323d241756.x5959bccb67bbf051(text2))
				{
					text3 = $"{text3} \\t \"{text2}\"";
				}
				xea2f7776a29d24ac(xe134235b3526fa75, x9c79b5ad7b769b12, text3, x789564759d365819, xce987d84406b1bfc);
			}
			x00220d40d1a5427b(x9c79b5ad7b769b12, xce987d84406b1bfc, new FieldSeparator(xe134235b3526fa75.x2c8c6741422a1298, x789564759d365819, FieldType.FieldHyperlink));
		}
		if (xd8a1c7c41bfbcde == "draw")
		{
			xe134235b3526fa75.x58c712b0d1d1c39b = text;
			xe134235b3526fa75.x42f4c234c9358072 = text2;
		}
		xef3217fa00e6d2ba.x4b7c2f007465fd90(xe134235b3526fa75, x9c79b5ad7b769b12, "a", x5173842427610357, xbe8ce7206677d91d);
		if (xd8a1c7c41bfbcde == "draw")
		{
			xe134235b3526fa75.x58c712b0d1d1c39b = null;
			xe134235b3526fa75.x42f4c234c9358072 = null;
		}
		if (xd8a1c7c41bfbcde == "text")
		{
			x00220d40d1a5427b(x9c79b5ad7b769b12, xce987d84406b1bfc, new FieldEnd(xe134235b3526fa75.x2c8c6741422a1298, x789564759d365819, FieldType.FieldHyperlink, hasSeparator: true));
		}
	}

	private static void x9a934a26f31a27ec(xf871da68decec406 xe134235b3526fa75, Paragraph x9c79b5ad7b769b12, xeedad81aaed42a76 x789564759d365819, Style xce987d84406b1bfc)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		Document x2c8c6741422a = xe134235b3526fa75.x2c8c6741422a1298;
		string text = xca994afbcb9073a.xd68abcd61e368af9("name", null);
		string text2 = xca994afbcb9073a.xd68abcd61e368af9("string-value", null);
		if (!x0d299f323d241756.x5959bccb67bbf051(text2))
		{
			text2 = xca994afbcb9073a.x2a1ea9d24e62bf84();
		}
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, FieldType.FieldSet, $"SET {text} \"{text2}\"", text2, x789564759d365819, xce987d84406b1bfc);
			xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, FieldType.FieldRef, $"REF \"{text}\"", text2, x789564759d365819, xce987d84406b1bfc);
			if (x2c8c6741422a.Range.Bookmarks.x2ee5ad3d826ed0fe(text) == -1)
			{
				x9c79b5ad7b769b12.AppendChild(new BookmarkStart(x2c8c6741422a, text));
				x9c79b5ad7b769b12.AppendChild(new BookmarkEnd(x2c8c6741422a, text));
			}
		}
	}

	private static void x2214941c12765829(xf871da68decec406 xe134235b3526fa75, Paragraph x9c79b5ad7b769b12, xeedad81aaed42a76 x789564759d365819, Style xce987d84406b1bfc)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		string text = xca994afbcb9073a.xd68abcd61e368af9("name", null);
		string x5fc53c4ffd3eb8c = xca994afbcb9073a.x2a1ea9d24e62bf84();
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, FieldType.FieldRef, $"REF \"{text}\"", x5fc53c4ffd3eb8c, x789564759d365819, xce987d84406b1bfc);
		}
	}

	private static void x40f888329312fd72(xf871da68decec406 xe134235b3526fa75, Paragraph x9c79b5ad7b769b12, xeedad81aaed42a76 x789564759d365819, Style xce987d84406b1bfc)
	{
		if (x789564759d365819 == null)
		{
			x789564759d365819 = x9c79b5ad7b769b12.x344511c4e4ce09da;
		}
		FormField formField = new FormField(xe134235b3526fa75.x2c8c6741422a1298, new x58bf2a36f9adf9a9(), x789564759d365819);
		x9c79b5ad7b769b12.AppendChild(new FieldStart(xe134235b3526fa75.x2c8c6741422a1298, x789564759d365819, FieldType.FieldFormDropDown));
		xea2f7776a29d24ac(xe134235b3526fa75, x9c79b5ad7b769b12, "FORMDROPDOWN", x789564759d365819, xce987d84406b1bfc);
		x9c79b5ad7b769b12.AppendChild(formField);
		x9c79b5ad7b769b12.AppendChild(new FieldEnd(xe134235b3526fa75.x2c8c6741422a1298, x789564759d365819, FieldType.FieldFormDropDown, hasSeparator: false));
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x416ea3123144a39f("drop-down", x764dfdef5d60f7e6.x278cc3fa1e8f2bcd))
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "":
				formField.x6e77c7675d1ac719 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "label":
				formField.DropDownItems.Add(xca994afbcb9073a.xd68abcd61e368af9("value", ""));
				break;
			default:
				xe134235b3526fa75.xca994afbcb9073a2.IgnoreElement();
				break;
			}
		}
	}

	internal static void x8602df7130e8ca26(xf871da68decec406 xe134235b3526fa75, CompositeNode x9c79b5ad7b769b12, xdc86c0f058b433d5 x583d4fd38d642188, xeedad81aaed42a76 x789564759d365819, Style xce987d84406b1bfc)
	{
		if (x789564759d365819 == null)
		{
			x789564759d365819 = ((x9c79b5ad7b769b12 is Paragraph) ? ((Paragraph)x9c79b5ad7b769b12).x344511c4e4ce09da : new xeedad81aaed42a76());
		}
		FormField formField = new FormField(xe134235b3526fa75.x2c8c6741422a1298, new x58bf2a36f9adf9a9(), x789564759d365819);
		if (x0d299f323d241756.x5959bccb67bbf051(x583d4fd38d642188.x83dec78bc96b9b92) && x583d4fd38d642188.x83dec78bc96b9b92 == "checked")
		{
			formField.Checked = true;
		}
		formField.CheckBoxSize = Math.Round(Math.Max(x583d4fd38d642188.xdc1bf80853046136, x583d4fd38d642188.xb0f146032f47c24e));
		formField.IsCheckBoxExactSize = true;
		x9c79b5ad7b769b12.AppendChild(new FieldStart(xe134235b3526fa75.x2c8c6741422a1298, x789564759d365819, FieldType.FieldFormCheckBox));
		xea2f7776a29d24ac(xe134235b3526fa75, x9c79b5ad7b769b12, "FORMCHECKBOX", x789564759d365819, xce987d84406b1bfc);
		x9c79b5ad7b769b12.AppendChild(formField);
		x9c79b5ad7b769b12.AppendChild(new FieldSeparator(xe134235b3526fa75.x2c8c6741422a1298, x789564759d365819, FieldType.FieldFormCheckBox));
		x9c79b5ad7b769b12.AppendChild(new FieldEnd(xe134235b3526fa75.x2c8c6741422a1298, x789564759d365819, FieldType.FieldFormCheckBox, hasSeparator: true));
	}

	private static void xae61105ec4f607a4(xf871da68decec406 xe134235b3526fa75, Paragraph x9c79b5ad7b769b12, xeedad81aaed42a76 x789564759d365819, Style xce987d84406b1bfc)
	{
		if (x789564759d365819 == null)
		{
			x789564759d365819 = x9c79b5ad7b769b12.x344511c4e4ce09da;
		}
		FormField formField = new FormField(xe134235b3526fa75.x2c8c6741422a1298, new x58bf2a36f9adf9a9(), x789564759d365819);
		formField.x58bf2a36f9adf9a9.x98ed2e2b5602a6f1 = TextFormFieldType.Regular;
		formField.x58bf2a36f9adf9a9.x759aa16c2016a289 = xe134235b3526fa75.xca994afbcb9073a2.xd68abcd61e368af9("description", null);
		x9c79b5ad7b769b12.AppendChild(new FieldStart(xe134235b3526fa75.x2c8c6741422a1298, x789564759d365819, FieldType.FieldFormTextInput));
		xea2f7776a29d24ac(xe134235b3526fa75, x9c79b5ad7b769b12, "FORMTEXT", x789564759d365819, xce987d84406b1bfc);
		x9c79b5ad7b769b12.AppendChild(formField);
		x9c79b5ad7b769b12.AppendChild(new FieldSeparator(xe134235b3526fa75.x2c8c6741422a1298, x789564759d365819, FieldType.FieldFormTextInput));
		xea2f7776a29d24ac(xe134235b3526fa75, x9c79b5ad7b769b12, xe134235b3526fa75.xca994afbcb9073a2.x2a1ea9d24e62bf84(), x789564759d365819, xce987d84406b1bfc);
		x9c79b5ad7b769b12.AppendChild(new FieldEnd(xe134235b3526fa75.x2c8c6741422a1298, x789564759d365819, FieldType.FieldFormTextInput, hasSeparator: true));
	}

	private static void xf1a5675dddec7694(xf871da68decec406 xe134235b3526fa75, Paragraph x9c79b5ad7b769b12, string x0e59413709b18038, xeedad81aaed42a76 x789564759d365819, Style xce987d84406b1bfc)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		string xbd5a2e7a4ff749c = xca994afbcb9073a.xd68abcd61e368af9("data-style-name", null);
		xe3843707a08acbb0 xe3843707a08acbb = (xe3843707a08acbb0)xe134235b3526fa75.x37eb83f4e2a8fe56.get_xe6d4b1b411ed94b5(xbd5a2e7a4ff749c, (string)null, xe134235b3526fa75.xb9e32c79bd755ad8, xafd04c36a00d5bcf: true);
		string arg = "";
		if (xe3843707a08acbb != null)
		{
			if (xe3843707a08acbb.xeedad81aaed42a76 != null)
			{
				xe3843707a08acbb.xeedad81aaed42a76.xab3af626b1405ee8(x789564759d365819);
			}
			arg = $" \\@ \"{xe3843707a08acbb.xacc0cf2788d5c15a}\"";
		}
		xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, x5c29822913be33c1.x338a5159d9aa7162(x0e59413709b18038), $"{x0e59413709b18038}{arg}", xca994afbcb9073a.x2a1ea9d24e62bf84(), x789564759d365819, xce987d84406b1bfc);
	}

	private static void xfa06e4222bd52463(xf871da68decec406 xe134235b3526fa75, Paragraph x9c79b5ad7b769b12, FieldType x77ce91e5324df734, string x0e59413709b18038, xeedad81aaed42a76 x789564759d365819, Style xce987d84406b1bfc)
	{
		string x5fc53c4ffd3eb8c = xe134235b3526fa75.xca994afbcb9073a2.x2a1ea9d24e62bf84();
		xfa06e4222bd52463(xe134235b3526fa75, x9c79b5ad7b769b12, x77ce91e5324df734, x0e59413709b18038, x5fc53c4ffd3eb8c, x789564759d365819, xce987d84406b1bfc);
	}

	private static void xfa06e4222bd52463(xf871da68decec406 xe134235b3526fa75, Paragraph x9c79b5ad7b769b12, FieldType x77ce91e5324df734, string x0e59413709b18038, string x5fc53c4ffd3eb8c9, xeedad81aaed42a76 x789564759d365819, Style xce987d84406b1bfc)
	{
		if (x789564759d365819 == null)
		{
			x789564759d365819 = x9c79b5ad7b769b12.x344511c4e4ce09da;
		}
		x00220d40d1a5427b(x9c79b5ad7b769b12, xce987d84406b1bfc, new FieldStart(xe134235b3526fa75.x2c8c6741422a1298, x789564759d365819, x77ce91e5324df734));
		xea2f7776a29d24ac(xe134235b3526fa75, x9c79b5ad7b769b12, x0e59413709b18038, x789564759d365819, xce987d84406b1bfc);
		x00220d40d1a5427b(x9c79b5ad7b769b12, xce987d84406b1bfc, new FieldSeparator(xe134235b3526fa75.x2c8c6741422a1298, x789564759d365819, x77ce91e5324df734));
		xea2f7776a29d24ac(xe134235b3526fa75, x9c79b5ad7b769b12, x5fc53c4ffd3eb8c9, x789564759d365819, xce987d84406b1bfc);
		x00220d40d1a5427b(x9c79b5ad7b769b12, xce987d84406b1bfc, new FieldEnd(xe134235b3526fa75.x2c8c6741422a1298, x789564759d365819, x77ce91e5324df734, hasSeparator: true));
		xe134235b3526fa75.xca994afbcb9073a2.IgnoreElement();
	}

	private static void x00220d40d1a5427b(Paragraph x9c79b5ad7b769b12, Style xce987d84406b1bfc, FieldChar x2223f7db33837fbd)
	{
		xf871da68decec406.x7440208dce82f530(x2223f7db33837fbd, xce987d84406b1bfc);
		x9c79b5ad7b769b12.AppendChild(x2223f7db33837fbd);
	}

	private static void xea2f7776a29d24ac(xf871da68decec406 xe134235b3526fa75, CompositeNode x8b2c3c076d5a7daf, string xb41faee6912a2313, xeedad81aaed42a76 x789564759d365819, Style xce987d84406b1bfc)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xb41faee6912a2313))
		{
			Run run = new Run(xe134235b3526fa75.x2c8c6741422a1298, xb41faee6912a2313, x789564759d365819);
			xf871da68decec406.x7440208dce82f530(run, xce987d84406b1bfc);
			x8b2c3c076d5a7daf.AppendChild(run);
		}
	}
}
