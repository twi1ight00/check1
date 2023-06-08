using Aspose.Words;
using Aspose.Words.Fields;
using Aspose.Words.Markup;
using x6c95d9cf46ff5f25;
using xbe73d5820f7f4ae3;

namespace xa2462df43988ffad;

internal class xb4b2fa9e83be9a55
{
	private static bool xb48b0f2705e97410;

	private static bool x8fb1a6c0cacb7b7b;

	private static string xb57da2cbb90b8d4c;

	private static string xe6b1194a5c81b5f1;

	private static string xef352825cdb55c36;

	private static string xb15cb0991d3700ea;

	private static bool xd04575f5a3fb3440;

	private readonly xdb0bf9f81de4b38c x9b287b671d592594;

	private readonly x9884289168bac01e x12954a224495d3c0;

	private readonly x560f0e9efcf5b9b1 x6962cbeae4129aa3;

	private readonly xefe741166bf97418 x87311d0449340cb1;

	internal xb4b2fa9e83be9a55(xdb0bf9f81de4b38c writer)
	{
		x9b287b671d592594 = writer;
		x6962cbeae4129aa3 = new x560f0e9efcf5b9b1(x9b287b671d592594);
		x87311d0449340cb1 = new xefe741166bf97418(x9b287b671d592594);
		x12954a224495d3c0 = new x9884289168bac01e(x9b287b671d592594);
		x8fb1a6c0cacb7b7b = true;
	}

	internal VisitorAction xd4c0f67c01114dfe(FieldChar xa6315bf377f6364c)
	{
		if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x62896619d90ad964)
		{
			return VisitorAction.Continue;
		}
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		x9b287b671d592594.x52320ec9c1034d1f = true;
		if (x9b287b671d592594.xae1859ea8541d5a4 > 0)
		{
			if (xa6315bf377f6364c.FieldType != FieldType.FieldHyperlink)
			{
				x9b287b671d592594.xae1859ea8541d5a4++;
			}
			return VisitorAction.SkipThisNode;
		}
		x8fb1a6c0cacb7b7b = x25c17e668701f250(xa6315bf377f6364c);
		if (!x8fb1a6c0cacb7b7b || xa6315bf377f6364c.ParentNode is SmartTag || (xa6315bf377f6364c.FieldType == FieldType.FieldFormCheckBox && xb15ad493ee0817cd(xa6315bf377f6364c) == null))
		{
			x9b287b671d592594.x3460ec740e098e72(xa6315bf377f6364c, null);
			return VisitorAction.Continue;
		}
		if (xa6315bf377f6364c.FieldType == FieldType.FieldMergeField)
		{
			x9b287b671d592594.x1c807e6130619b41 = true;
		}
		if (xa6315bf377f6364c.FieldType == FieldType.FieldSet)
		{
			x9b287b671d592594.x1339fb7786d0cc44 = true;
		}
		xe6b1194a5c81b5f1 = "";
		xef352825cdb55c36 = "";
		Paragraph parentParagraph = xa6315bf377f6364c.ParentParagraph;
		if (parentParagraph.xc8d1bb1390d5266d || !x9b287b671d592594.x68e1404b914783c1)
		{
			x062606e399f0b45d(xa6315bf377f6364c);
			if (xa6315bf377f6364c.FieldType == FieldType.FieldMergeField)
			{
				xe6b1194a5c81b5f1 = xbb857c9fc36f5054.x193fd22ffbc988d7(xb57da2cbb90b8d4c, "\\b").Trim('"');
				xef352825cdb55c36 = xbb857c9fc36f5054.x193fd22ffbc988d7(xb57da2cbb90b8d4c, "\\f").Trim('"');
			}
			if (x9b287b671d592594.xb872fbc83a2cb9a6)
			{
				xb48b0f2705e97410 = false;
				if (xa6315bf377f6364c.FieldType == FieldType.FieldMergeField)
				{
					xb48b0f2705e97410 = true;
					if (x0d299f323d241756.x5959bccb67bbf051(xe6b1194a5c81b5f1))
					{
						x6962cbeae4129aa3.xaedce5725e456ac5(xa6315bf377f6364c);
					}
					if (x0d299f323d241756.x5959bccb67bbf051(xef352825cdb55c36))
					{
						x6962cbeae4129aa3.xaedce5725e456ac5(xa6315bf377f6364c);
					}
				}
				if (xa6315bf377f6364c.FieldType == FieldType.FieldSaveDate || xa6315bf377f6364c.FieldType == FieldType.FieldCreateDate || xa6315bf377f6364c.FieldType == FieldType.FieldPrintDate || xa6315bf377f6364c.FieldType == FieldType.FieldDate || xa6315bf377f6364c.FieldType == FieldType.FieldTime)
				{
					xb48b0f2705e97410 = true;
					x6962cbeae4129aa3.xe9a75dda66f89395(xbb857c9fc36f5054.xe4dd84dcf5c200e3(xb57da2cbb90b8d4c));
				}
				if (xa6315bf377f6364c.FieldType == FieldType.FieldFormCheckBox)
				{
					xb48b0f2705e97410 = true;
					x6962cbeae4129aa3.x7836b37ea6311ff0(x6962cbeae4129aa3.x455e44058f4e8da3(), "graphic");
					xaf19908a0dc2a02b xaf19908a0dc2a02b2 = new xaf19908a0dc2a02b();
					xaf19908a0dc2a02b2.x1792c7876d3f3359 = "top";
					xaf19908a0dc2a02b2.xd44988f225497f3a++;
					x87311d0449340cb1.x60143d798b2de7de = xaf19908a0dc2a02b2;
					x87311d0449340cb1.x6210059f049f0d48(x56f6837d0255d1c8: false);
					xe1410f585439c7d.x2dfde153f4ef96d0("style:style");
				}
				if (!x34ab594f5b904a0d(xa6315bf377f6364c.FieldType))
				{
					xb48b0f2705e97410 = true;
					x6962cbeae4129aa3.xaedce5725e456ac5(xa6315bf377f6364c);
				}
			}
			else if (x9b287b671d592594.x05ee8ce4d7312eb5 != x14bf6f47128e4438.x3231bc142724c8b3)
			{
				xb48b0f2705e97410 = true;
				switch (xa6315bf377f6364c.FieldType)
				{
				case FieldType.FieldAdvance:
					x43ce448b234e76d8();
					break;
				case FieldType.FieldRef:
				case FieldType.FieldPageRef:
					x5a0cb5b54eecfb45(xa6315bf377f6364c);
					break;
				case FieldType.FieldRevisionNum:
					xdf21d92ef56e3c40("text:editing-cycles", xda545ec845c6c8e4: false);
					break;
				case FieldType.FieldEditTime:
					xdf21d92ef56e3c40("text:editing-duration", xda545ec845c6c8e4: false);
					break;
				case FieldType.FieldKeyword:
					xdf21d92ef56e3c40("text:keywords", xda545ec845c6c8e4: false);
					break;
				case FieldType.FieldSubject:
					xdf21d92ef56e3c40("text:subject", xda545ec845c6c8e4: false);
					break;
				case FieldType.FieldComments:
					xdf21d92ef56e3c40("text:description", xda545ec845c6c8e4: false);
					break;
				case FieldType.FieldTemplate:
					x079a220bea91198b();
					break;
				case FieldType.FieldMergeRec:
					xf550074c92a44b7e();
					break;
				case FieldType.FieldNext:
					xfb1064015c096bf1();
					break;
				case FieldType.FieldMergeField:
					x82d591bf751767c7();
					break;
				case FieldType.FieldUserInitials:
					xdf21d92ef56e3c40("text:author-initials", xda545ec845c6c8e4: false);
					break;
				case FieldType.FieldUserName:
					xdf21d92ef56e3c40("text:author-name", xda545ec845c6c8e4: false);
					break;
				case FieldType.FieldFileName:
					x12954a224495d3c0.xffb053d2a78c4e1b();
					x9b287b671d592594.xe1410f585439c7d4.x5a3f5d78674f78e4("text:file-name");
					x9b287b671d592594.xe1410f585439c7d4.x19b0790c272bbe88("text:display", xbb857c9fc36f5054.x38937d073af5b8ce(xb57da2cbb90b8d4c));
					x9b287b671d592594.xe1410f585439c7d4.xd52401bdf5aacef6("/>");
					x12954a224495d3c0.x81ddb41fb70cbf68();
					break;
				case FieldType.FieldPage:
					xab857a7758835403();
					break;
				case FieldType.FieldNumWords:
					x0018954a28cf4924("text:word-count");
					break;
				case FieldType.FieldNumPages:
					x0018954a28cf4924("text:page-count");
					break;
				case FieldType.FieldSequence:
					xd99a39095a768946();
					break;
				case FieldType.FieldHyperlink:
					x65c464b3208cfa80();
					break;
				case FieldType.FieldTitle:
					xdf21d92ef56e3c40("text:title");
					break;
				case FieldType.FieldAuthor:
					xdf21d92ef56e3c40("text:initial-creator");
					break;
				case FieldType.FieldLastSavedBy:
					xdf21d92ef56e3c40("text:creator");
					break;
				case FieldType.FieldDate:
					xd53d040c6dcb9ddd("text:date");
					break;
				case FieldType.FieldTime:
					xd53d040c6dcb9ddd("text:time");
					break;
				case FieldType.FieldPrintDate:
					xd53d040c6dcb9ddd("text:print-date");
					break;
				case FieldType.FieldSaveDate:
					xd53d040c6dcb9ddd("text:modification-date");
					break;
				case FieldType.FieldCreateDate:
					xd53d040c6dcb9ddd("text:creation-date");
					break;
				case FieldType.FieldFormTextInput:
					x4124f4263e86821b(xa6315bf377f6364c.x03a9a1b8afdf52f9(NodeType.FormField) as FormField);
					break;
				case FieldType.FieldFormDropDown:
					xfb8acc6f8038a1a8(xa6315bf377f6364c.x03a9a1b8afdf52f9(NodeType.FormField) as FormField);
					break;
				case FieldType.FieldFormCheckBox:
					x22bcbaf653eebc31(xa6315bf377f6364c);
					break;
				case FieldType.FieldSet:
					xf71a727da91ba273();
					break;
				case FieldType.FieldDocProperty:
				{
					string text = xbb857c9fc36f5054.x63b8eaab6cf477b8(xb57da2cbb90b8d4c);
					switch (text.ToLower())
					{
					case "paragraphs":
						x0018954a28cf4924("text:paragraph-count");
						break;
					case "characterswithspaces":
						x0018954a28cf4924("text:character-count");
						break;
					default:
						xa49786a737a84ed7(text);
						break;
					}
					break;
				}
				default:
					xb48b0f2705e97410 = false;
					if (!x34ab594f5b904a0d(xa6315bf377f6364c.FieldType))
					{
						x12954a224495d3c0.xffb053d2a78c4e1b();
					}
					break;
				}
			}
		}
		x9b287b671d592594.x3460ec740e098e72(xa6315bf377f6364c, null);
		if (xa6315bf377f6364c.FieldType != FieldType.FieldHyperlink)
		{
			x9b287b671d592594.xae1859ea8541d5a4++;
		}
		return VisitorAction.Continue;
	}

	private void x5a0cb5b54eecfb45(FieldChar xa6315bf377f6364c)
	{
		Node previousSibling = xa6315bf377f6364c.PreviousSibling;
		string text = xf74e3e3a35a32346();
		if (previousSibling != null && previousSibling is FieldEnd && (previousSibling as FieldEnd).FieldType == FieldType.FieldSet && text == xb15cb0991d3700ea)
		{
			xd04575f5a3fb3440 = true;
			return;
		}
		xd04575f5a3fb3440 = false;
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		xe1410f585439c7d.x5a3f5d78674f78e4("text:bookmark-ref");
		if (xa6315bf377f6364c.FieldType == FieldType.FieldPageRef)
		{
			xe1410f585439c7d.x19b0790c272bbe88("text:reference-format", "page");
		}
		else if (xb57da2cbb90b8d4c.IndexOf(" \\p") != -1)
		{
			xe1410f585439c7d.x19b0790c272bbe88("text:reference-format", "direction");
		}
		else
		{
			xe1410f585439c7d.x19b0790c272bbe88("text:reference-format", "text");
		}
		xe1410f585439c7d.x53e7651cce580e9f("text:ref-name", text);
	}

	private void x06445437c34aaefd(FieldChar xed9a565596a6ae3f, FieldType x77ce91e5324df734)
	{
		Node node = xed9a565596a6ae3f.NextSibling;
		string text = "";
		while (node != null && (!(node is FieldEnd) || x77ce91e5324df734 != xed9a565596a6ae3f.FieldType))
		{
			text = $"{text}{node.GetText()}";
			node = node.xa6890a1cb2b8896e;
		}
		x9b287b671d592594.xe1410f585439c7d4.x3d1be38abe5723e3(text);
	}

	private static void x062606e399f0b45d(Node xa6315bf377f6364c)
	{
		xb57da2cbb90b8d4c = "";
		Node nextSibling = xa6315bf377f6364c.NextSibling;
		int num = 0;
		while (nextSibling != null && ((nextSibling.NodeType != NodeType.FieldSeparator && nextSibling.NodeType != NodeType.FieldEnd) || num != 0))
		{
			switch (nextSibling.NodeType)
			{
			case NodeType.FieldStart:
				num++;
				break;
			case NodeType.FieldEnd:
				num--;
				break;
			default:
				if (num == 0 && nextSibling.NodeType != NodeType.FieldSeparator && x0d299f323d241756.x5959bccb67bbf051(nextSibling.GetText().Trim(' ')))
				{
					xb57da2cbb90b8d4c += nextSibling.GetText();
				}
				break;
			}
			nextSibling = nextSibling.NextSibling;
		}
	}

	private void x079a220bea91198b()
	{
		string arg = ((xb57da2cbb90b8d4c.IndexOf("\\p") == -1) ? "name-and-extension" : "full");
		xdf21d92ef56e3c40($"text:template-name text:display=\"{arg}\"", xda545ec845c6c8e4: true);
	}

	private void x82d591bf751767c7()
	{
		string text = xbb857c9fc36f5054.x193fd22ffbc988d7(xb57da2cbb90b8d4c, "MERGEFIELD").Trim('"').Trim(' ');
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		if (x0d299f323d241756.x5959bccb67bbf051(xe6b1194a5c81b5f1))
		{
			x9b287b671d592594.x52320ec9c1034d1f = false;
			x12954a224495d3c0.x6210059f049f0d48(new Run(x9b287b671d592594.x2c8c6741422a1298, xe6b1194a5c81b5f1));
			x9b287b671d592594.x52320ec9c1034d1f = true;
		}
		x12954a224495d3c0.xffb053d2a78c4e1b();
		xe1410f585439c7d.x5a3f5d78674f78e4("text:database-display");
		xe1410f585439c7d.x19b0790c272bbe88("text:column-name", text);
		x9414e1b2544820e6();
		x9b287b671d592594.xe1410f585439c7d4.x3d1be38abe5723e3($"«{text}»");
		xe1410f585439c7d.xf3cbeec41f083290("text:database-display");
		x12954a224495d3c0.x81ddb41fb70cbf68();
	}

	private void xfb1064015c096bf1()
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		xe1410f585439c7d.x5a3f5d78674f78e4("text:database-next");
		x9414e1b2544820e6();
		xe1410f585439c7d.xf3cbeec41f083290("text:database-next");
	}

	private void xf550074c92a44b7e()
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		xe1410f585439c7d.x5a3f5d78674f78e4("text:database-row-number");
		x9414e1b2544820e6();
		xe1410f585439c7d.xf3cbeec41f083290("text:database-row-number");
	}

	private void x9414e1b2544820e6()
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		if (!x9b287b671d592594.x2b4379ecf88129a1 && !x9b287b671d592594.x386588ea37d49369)
		{
			xe1410f585439c7d.x19b0790c272bbe88("text:database-name", "");
		}
		xe1410f585439c7d.x19b0790c272bbe88("text:table-name", "");
		xe1410f585439c7d.x53e7651cce580e9f("text:table-type", "table");
	}

	private bool x34ab594f5b904a0d(FieldType x77ce91e5324df734)
	{
		if ((x77ce91e5324df734 != FieldType.FieldFormDropDown || !x9b287b671d592594.xf57de0fd37d5e97d.IsStrictSchema11) && x77ce91e5324df734 != FieldType.FieldHtmlActiveX && x77ce91e5324df734 != FieldType.FieldCannotParse && x77ce91e5324df734 != 0 && x77ce91e5324df734 != FieldType.FieldFillIn && x77ce91e5324df734 != FieldType.FieldGreetingLine && x77ce91e5324df734 != FieldType.FieldGlossary && x77ce91e5324df734 != FieldType.FieldGoToButton && x77ce91e5324df734 != FieldType.FieldIncludeText && x77ce91e5324df734 != FieldType.FieldIndex && x77ce91e5324df734 != FieldType.FieldInfo && x77ce91e5324df734 != FieldType.FieldLink && x77ce91e5324df734 != FieldType.FieldListNum && x77ce91e5324df734 != FieldType.FieldMacroButton && x77ce91e5324df734 != FieldType.FieldMergeRec && x77ce91e5324df734 != FieldType.FieldMergeSeq && x77ce91e5324df734 != FieldType.FieldNext && x77ce91e5324df734 != FieldType.FieldNextIf && x77ce91e5324df734 != FieldType.FieldNoteRef && x77ce91e5324df734 != FieldType.FieldNumChars && x77ce91e5324df734 != FieldType.FieldPrint && x77ce91e5324df734 != FieldType.FieldPrivate && x77ce91e5324df734 != FieldType.FieldQuote && x77ce91e5324df734 != FieldType.FieldRefNoKeyword && x77ce91e5324df734 != FieldType.FieldRefDoc && x77ce91e5324df734 != FieldType.FieldSkipIf && x77ce91e5324df734 != FieldType.FieldStyleRef && x77ce91e5324df734 != FieldType.FieldSymbol && x77ce91e5324df734 != FieldType.FieldTOA && x77ce91e5324df734 != FieldType.FieldTOAEntry && x77ce91e5324df734 != FieldType.FieldTOC && x77ce91e5324df734 != FieldType.FieldUserAddress && x77ce91e5324df734 != FieldType.FieldUserInitials && x77ce91e5324df734 != FieldType.FieldBarCode && x77ce91e5324df734 != FieldType.FieldBidiOutline && x77ce91e5324df734 != FieldType.FieldCompare && x77ce91e5324df734 != FieldType.FieldDocVariable && x77ce91e5324df734 != FieldType.FieldFileSize && x77ce91e5324df734 != FieldType.FieldAutoNum && x77ce91e5324df734 != FieldType.FieldAutoNumLegal && x77ce91e5324df734 != FieldType.FieldAutoNumOutline && x77ce91e5324df734 != FieldType.FieldAutoText && x77ce91e5324df734 != FieldType.FieldAutoTextList && x77ce91e5324df734 != FieldType.FieldAsk && x77ce91e5324df734 != FieldType.FieldFormula && x77ce91e5324df734 != FieldType.FieldAddressBlock && x77ce91e5324df734 != FieldType.FieldPrivate && x77ce91e5324df734 != FieldType.FieldIf && x77ce91e5324df734 != FieldType.FieldDDE && x77ce91e5324df734 != FieldType.FieldRef && x77ce91e5324df734 != FieldType.FieldPageRef && x77ce91e5324df734 != FieldType.FieldSection && x77ce91e5324df734 != FieldType.FieldSectionPages && x77ce91e5324df734 != FieldType.FieldIndexEntry && (x77ce91e5324df734 != FieldType.FieldAdvance || x5d6152611ac5fe5d()))
		{
			return x77ce91e5324df734 == FieldType.FieldTOCEntry;
		}
		return true;
	}

	private bool x961585bff35399c9(FieldType x77ce91e5324df734)
	{
		if (!x34ab594f5b904a0d(x77ce91e5324df734) && x77ce91e5324df734 != FieldType.FieldAdvance && x77ce91e5324df734 != FieldType.FieldMergeField && x77ce91e5324df734 != FieldType.FieldNumWords && x77ce91e5324df734 != FieldType.FieldRevisionNum && x77ce91e5324df734 != FieldType.FieldEditTime && x77ce91e5324df734 != FieldType.FieldKeyword && x77ce91e5324df734 != FieldType.FieldSubject && x77ce91e5324df734 != FieldType.FieldComments && x77ce91e5324df734 != FieldType.FieldTemplate && x77ce91e5324df734 != FieldType.FieldFormTextInput && x77ce91e5324df734 != FieldType.FieldFormDropDown && x77ce91e5324df734 != FieldType.FieldFormCheckBox && x77ce91e5324df734 != FieldType.FieldSet && x77ce91e5324df734 != FieldType.FieldFileName && x77ce91e5324df734 != FieldType.FieldUserInitials && x77ce91e5324df734 != FieldType.FieldUserName && x77ce91e5324df734 != FieldType.FieldTitle && x77ce91e5324df734 != FieldType.FieldAuthor && x77ce91e5324df734 != FieldType.FieldLastSavedBy && x77ce91e5324df734 != FieldType.FieldPrintDate && x77ce91e5324df734 != FieldType.FieldDate && x77ce91e5324df734 != FieldType.FieldTime && x77ce91e5324df734 != FieldType.FieldSaveDate && x77ce91e5324df734 != FieldType.FieldCreateDate && x77ce91e5324df734 != FieldType.FieldDocProperty && x77ce91e5324df734 != FieldType.FieldPage)
		{
			return x77ce91e5324df734 == FieldType.FieldNumPages;
		}
		return true;
	}

	internal VisitorAction x55225d9815813a91(FieldEnd xc87e4e475724f9c3)
	{
		if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x62896619d90ad964)
		{
			return VisitorAction.Continue;
		}
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		if (x9b287b671d592594.xae1859ea8541d5a4 <= 1 || !xb48b0f2705e97410 || x9b287b671d592594.x1c807e6130619b41)
		{
			x9b287b671d592594.x52320ec9c1034d1f = false;
		}
		if (x9b287b671d592594.xae1859ea8541d5a4 > 1 || (xc87e4e475724f9c3.FieldType == FieldType.FieldHyperlink && x9b287b671d592594.xae1859ea8541d5a4 > 0))
		{
			x9b287b671d592594.xae1859ea8541d5a4--;
			return VisitorAction.SkipThisNode;
		}
		if (xc87e4e475724f9c3.FieldType == FieldType.FieldSet)
		{
			x9b287b671d592594.x1339fb7786d0cc44 = false;
		}
		if (!x67ab9144ff652225(xc87e4e475724f9c3) || xc87e4e475724f9c3.ParentNode is SmartTag)
		{
			x9b287b671d592594.x3460ec740e098e72(xc87e4e475724f9c3, null);
			return VisitorAction.Continue;
		}
		Paragraph parentParagraph = xc87e4e475724f9c3.ParentParagraph;
		if ((parentParagraph.xc8d1bb1390d5266d || !x9b287b671d592594.x68e1404b914783c1) && !x9b287b671d592594.xb872fbc83a2cb9a6 && x9b287b671d592594.x05ee8ce4d7312eb5 != x14bf6f47128e4438.x3231bc142724c8b3)
		{
			switch (xc87e4e475724f9c3.FieldType)
			{
			case FieldType.FieldHyperlink:
				if (xbb857c9fc36f5054.xdd08ed399f8774b0(xb57da2cbb90b8d4c, x9b287b671d592594.x2c8c6741422a1298.xb93d084d48e486dd, xf4959543150451ad: false) != null)
				{
					xe1410f585439c7d.xf3cbeec41f083290("text:a");
				}
				break;
			case FieldType.FieldRef:
			case FieldType.FieldPageRef:
				if (xf74e3e3a35a32346() != xb15cb0991d3700ea || !xd04575f5a3fb3440)
				{
					xe1410f585439c7d.xf3cbeec41f083290("text:bookmark-ref");
					xd04575f5a3fb3440 = false;
				}
				break;
			case FieldType.FieldSequence:
				xe1410f585439c7d.xf3cbeec41f083290("text:sequence");
				break;
			case FieldType.FieldSet:
				x9b287b671d592594.x1339fb7786d0cc44 = false;
				break;
			}
			if (!x961585bff35399c9(xc87e4e475724f9c3.FieldType) && (xbb857c9fc36f5054.xdd08ed399f8774b0(xb57da2cbb90b8d4c, x9b287b671d592594.x2c8c6741422a1298.xb93d084d48e486dd, xf4959543150451ad: false) != null || xc87e4e475724f9c3.FieldType != FieldType.FieldHyperlink))
			{
				x12954a224495d3c0.x81ddb41fb70cbf68();
			}
			if (x0d299f323d241756.x5959bccb67bbf051(xef352825cdb55c36))
			{
				x12954a224495d3c0.x6210059f049f0d48(new Run(x9b287b671d592594.x2c8c6741422a1298, xef352825cdb55c36));
			}
		}
		x9b287b671d592594.x3460ec740e098e72(xc87e4e475724f9c3, null);
		if (xc87e4e475724f9c3.FieldType == FieldType.FieldMergeField)
		{
			x9b287b671d592594.x1c807e6130619b41 = false;
		}
		if (xc87e4e475724f9c3.FieldType != FieldType.FieldHyperlink)
		{
			x9b287b671d592594.xae1859ea8541d5a4--;
		}
		return VisitorAction.Continue;
	}

	internal VisitorAction xd646d4760b5a81b9(FieldSeparator xed9a565596a6ae3f)
	{
		if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x62896619d90ad964)
		{
			return VisitorAction.Continue;
		}
		if (x9b287b671d592594.xae1859ea8541d5a4 > 1)
		{
			return VisitorAction.SkipThisNode;
		}
		if (!xed9a565596a6ae3f.ParentParagraph.xc8d1bb1390d5266d && x9b287b671d592594.x68e1404b914783c1)
		{
			return VisitorAction.Continue;
		}
		if (!x8fb1a6c0cacb7b7b || (xed9a565596a6ae3f.FieldType != FieldType.FieldNumWords && xed9a565596a6ae3f.FieldType != FieldType.FieldRevisionNum && xed9a565596a6ae3f.FieldType != FieldType.FieldEditTime && xed9a565596a6ae3f.FieldType != FieldType.FieldSubject && xed9a565596a6ae3f.FieldType != FieldType.FieldKeyword && xed9a565596a6ae3f.FieldType != FieldType.FieldComments && xed9a565596a6ae3f.FieldType != FieldType.FieldTemplate && xed9a565596a6ae3f.FieldType != FieldType.FieldMergeRec && xed9a565596a6ae3f.FieldType != FieldType.FieldNext && xed9a565596a6ae3f.FieldType != FieldType.FieldPrivate && xed9a565596a6ae3f.FieldType != FieldType.FieldFileName && xed9a565596a6ae3f.FieldType != FieldType.FieldUserName && xed9a565596a6ae3f.FieldType != FieldType.FieldUserInitials && xed9a565596a6ae3f.FieldType != FieldType.FieldTitle && xed9a565596a6ae3f.FieldType != FieldType.FieldAuthor && xed9a565596a6ae3f.FieldType != FieldType.FieldPrintDate && xed9a565596a6ae3f.FieldType != FieldType.FieldDate && xed9a565596a6ae3f.FieldType != FieldType.FieldTime && xed9a565596a6ae3f.FieldType != FieldType.FieldSaveDate && xed9a565596a6ae3f.FieldType != FieldType.FieldLastSavedBy && xed9a565596a6ae3f.FieldType != FieldType.FieldCreateDate && xed9a565596a6ae3f.FieldType != FieldType.FieldIf && xed9a565596a6ae3f.FieldType != FieldType.FieldDDE && xed9a565596a6ae3f.FieldType != FieldType.FieldFormTextInput && xed9a565596a6ae3f.FieldType != FieldType.FieldFormDropDown && xed9a565596a6ae3f.FieldType != FieldType.FieldFormCheckBox && xed9a565596a6ae3f.FieldType != FieldType.FieldSet && xed9a565596a6ae3f.FieldType != FieldType.FieldRef && xed9a565596a6ae3f.FieldType != FieldType.FieldPageRef && xed9a565596a6ae3f.FieldType != FieldType.FieldDocProperty && xed9a565596a6ae3f.FieldType != FieldType.FieldNumPages && xed9a565596a6ae3f.FieldType != FieldType.FieldPage && xed9a565596a6ae3f.FieldType != FieldType.FieldMergeField && xed9a565596a6ae3f.FieldType != FieldType.FieldSequence))
		{
			x9b287b671d592594.x52320ec9c1034d1f = false;
		}
		else
		{
			x9b287b671d592594.x52320ec9c1034d1f = true;
		}
		if ((((xed9a565596a6ae3f.FieldType == FieldType.FieldRef || xed9a565596a6ae3f.FieldType == FieldType.FieldPageRef) && (xf74e3e3a35a32346() != xb15cb0991d3700ea || !xd04575f5a3fb3440)) || xed9a565596a6ae3f.FieldType == FieldType.FieldSequence) && !x9b287b671d592594.xb872fbc83a2cb9a6 && x9b287b671d592594.x05ee8ce4d7312eb5 != x14bf6f47128e4438.x3231bc142724c8b3)
		{
			x06445437c34aaefd(xed9a565596a6ae3f, xed9a565596a6ae3f.FieldType);
		}
		x9b287b671d592594.x3460ec740e098e72(xed9a565596a6ae3f, null);
		return VisitorAction.Continue;
	}

	private static bool x25c17e668701f250(FieldChar x2223f7db33837fbd)
	{
		Paragraph parentParagraph = x2223f7db33837fbd.ParentParagraph;
		bool result = false;
		int num = parentParagraph.ChildNodes.IndexOf(x2223f7db33837fbd);
		int num2 = 0;
		for (int i = num + 1; i < parentParagraph.ChildNodes.Count; i++)
		{
			Node node = parentParagraph.ChildNodes[i];
			if (node.NodeType == NodeType.FieldStart)
			{
				num2++;
			}
			if (node.NodeType == NodeType.FieldStart && node.xd5b26cfce8730b50(x2223f7db33837fbd))
			{
				return false;
			}
			if (node.NodeType == NodeType.FieldEnd && ((FieldEnd)node).FieldType == x2223f7db33837fbd.FieldType && num2 == 0)
			{
				result = true;
				break;
			}
			if (node.NodeType == NodeType.FieldEnd)
			{
				num2--;
			}
		}
		return result;
	}

	private static bool x67ab9144ff652225(FieldChar xc87e4e475724f9c3)
	{
		Paragraph parentParagraph = xc87e4e475724f9c3.ParentParagraph;
		bool result = false;
		int num = parentParagraph.ChildNodes.IndexOf(xc87e4e475724f9c3);
		int num2 = 0;
		for (int num3 = num - 1; num3 >= 0; num3--)
		{
			Node node = parentParagraph.ChildNodes[num3];
			if (node.NodeType == NodeType.FieldEnd)
			{
				num2++;
			}
			if (node.NodeType == NodeType.FieldEnd && node.xd5b26cfce8730b50(xc87e4e475724f9c3))
			{
				return false;
			}
			if (node.NodeType == NodeType.FieldStart && ((FieldStart)node).FieldType == xc87e4e475724f9c3.FieldType && num2 == 0)
			{
				result = true;
				break;
			}
			if (node.NodeType == NodeType.FieldStart)
			{
				num2--;
			}
		}
		return result;
	}

	private void xf71a727da91ba273()
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		string text = xbb857c9fc36f5054.xddab5435c09fa2e9(xb57da2cbb90b8d4c);
		x12954a224495d3c0.xffb053d2a78c4e1b();
		xe1410f585439c7d.x5a3f5d78674f78e4("text:variable-set");
		xe1410f585439c7d.x19b0790c272bbe88("text:name", text);
		xe1410f585439c7d.x53e7651cce580e9f("office:value-type", "string");
		xe1410f585439c7d.x3d1be38abe5723e3(xbb857c9fc36f5054.x52eb04ee57ce90fb(xb57da2cbb90b8d4c, text));
		xe1410f585439c7d.xf3cbeec41f083290("text:variable-set");
		x12954a224495d3c0.x81ddb41fb70cbf68();
		xb15cb0991d3700ea = text;
	}

	private void x4124f4263e86821b(FormField x0ab8fc6e4b8e829c)
	{
		if (x0ab8fc6e4b8e829c != null)
		{
			x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
			x12954a224495d3c0.xffb053d2a78c4e1b();
			xe1410f585439c7d.x5a3f5d78674f78e4("text:text-input");
			xe1410f585439c7d.x53e7651cce580e9f("text:description", x0ab8fc6e4b8e829c.x58bf2a36f9adf9a9.x759aa16c2016a289);
			xe1410f585439c7d.x3d1be38abe5723e3(x0ab8fc6e4b8e829c.Result);
			xe1410f585439c7d.xf3cbeec41f083290("text:text-input");
			x12954a224495d3c0.x81ddb41fb70cbf68();
		}
	}

	private void xdf21d92ef56e3c40(string x66ac3558868cc255)
	{
		xdf21d92ef56e3c40(x66ac3558868cc255, xda545ec845c6c8e4: true);
	}

	private void xdf21d92ef56e3c40(string x66ac3558868cc255, bool xda545ec845c6c8e4)
	{
		x12954a224495d3c0.xffb053d2a78c4e1b();
		string xbcea506a33cf = ((!xda545ec845c6c8e4) ? " text:fixed=\"false\"" : "");
		x9b287b671d592594.xe1410f585439c7d4.x5a3f5d78674f78e4(x66ac3558868cc255);
		x9b287b671d592594.xe1410f585439c7d4.x3d1be38abe5723e3(xbcea506a33cf);
		x9b287b671d592594.xe1410f585439c7d4.xd52401bdf5aacef6("/>");
		x12954a224495d3c0.x81ddb41fb70cbf68();
	}

	private void xfb8acc6f8038a1a8(FormField x0ab8fc6e4b8e829c)
	{
		if (x0ab8fc6e4b8e829c == null)
		{
			return;
		}
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		if (x9b287b671d592594.xf57de0fd37d5e97d.IsStrictSchema11)
		{
			return;
		}
		x12954a224495d3c0.xffb053d2a78c4e1b();
		xe1410f585439c7d.xd52401bdf5aacef6("<text:drop-down>");
		foreach (string dropDownItem in x0ab8fc6e4b8e829c.DropDownItems)
		{
			xe1410f585439c7d.x5a3f5d78674f78e4("text:label");
			xe1410f585439c7d.x53e7651cce580e9f("text:value", dropDownItem);
			xe1410f585439c7d.xf3cbeec41f083290("text:label");
		}
		xe1410f585439c7d.x3d1be38abe5723e3(x0ab8fc6e4b8e829c.x6e77c7675d1ac719);
		xe1410f585439c7d.xf3cbeec41f083290("text:drop-down");
		x12954a224495d3c0.x81ddb41fb70cbf68();
	}

	private void x22bcbaf653eebc31(FieldChar xa6315bf377f6364c)
	{
		FormField formField = xb15ad493ee0817cd(xa6315bf377f6364c);
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		string x14ce39bb4fe9496c = "0.318cm";
		if (formField.IsCheckBoxExactSize)
		{
			x14ce39bb4fe9496c = xbb857c9fc36f5054.x96d7e563211411f6(formField.CheckBoxSize);
		}
		x12954a224495d3c0.xffb053d2a78c4e1b();
		xe1410f585439c7d.x5a3f5d78674f78e4("draw:control");
		xe1410f585439c7d.x19b0790c272bbe88("draw:style-name", x6962cbeae4129aa3.x455e44058f4e8da3());
		xe1410f585439c7d.x19b0790c272bbe88("svg:width", x14ce39bb4fe9496c);
		xe1410f585439c7d.x19b0790c272bbe88("svg:height", x14ce39bb4fe9496c);
		xe1410f585439c7d.x19b0790c272bbe88("text:anchor-type", "as-char");
		xe1410f585439c7d.x53e7651cce580e9f("draw:control", $"control{x9b287b671d592594.x970d128a5aa17a0a}");
		x9b287b671d592594.x970d128a5aa17a0a++;
		xe1410f585439c7d.xf3cbeec41f083290("draw:control");
		x12954a224495d3c0.x81ddb41fb70cbf68();
	}

	private void xd53d040c6dcb9ddd(string x121383aa64985888)
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		x12954a224495d3c0.xffb053d2a78c4e1b();
		xe1410f585439c7d.x5a3f5d78674f78e4(x121383aa64985888);
		if (x0d299f323d241756.x5959bccb67bbf051(xbb857c9fc36f5054.xe4dd84dcf5c200e3(xb57da2cbb90b8d4c)))
		{
			xe1410f585439c7d.x53e7651cce580e9f("style:data-style-name", x6962cbeae4129aa3.xe2d376da6365120b());
		}
		else
		{
			xe1410f585439c7d.xd52401bdf5aacef6(">");
		}
		xe1410f585439c7d.xf3cbeec41f083290(x121383aa64985888);
		x12954a224495d3c0.x81ddb41fb70cbf68();
	}

	private void x65c464b3208cfa80()
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		string text = xbb857c9fc36f5054.xdd08ed399f8774b0(xb57da2cbb90b8d4c, x9b287b671d592594.x2c8c6741422a1298.xb93d084d48e486dd, xf4959543150451ad: false);
		if (text != null)
		{
			x12954a224495d3c0.xffb053d2a78c4e1b();
			xe1410f585439c7d.x5a3f5d78674f78e4("text:a");
			xe1410f585439c7d.x19b0790c272bbe88("xlink:type", "simple");
			string text2 = xbb857c9fc36f5054.x193fd22ffbc988d7(xb57da2cbb90b8d4c, "\\t").Trim('"').Trim(' ');
			if (x0d299f323d241756.x5959bccb67bbf051(text2))
			{
				xe1410f585439c7d.x19b0790c272bbe88("office:target-frame-name", text2);
			}
			xe1410f585439c7d.x53e7651cce580e9f("xlink:href", text);
		}
	}

	private void xd99a39095a768946()
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		string text = xbb857c9fc36f5054.x647b56f7b5fd15df(xb57da2cbb90b8d4c);
		x12954a224495d3c0.xffb053d2a78c4e1b();
		xe1410f585439c7d.x5a3f5d78674f78e4("text:sequence");
		if (text != null)
		{
			xe1410f585439c7d.x19b0790c272bbe88("text:name", text);
			xe1410f585439c7d.x19b0790c272bbe88("text:formula", $"ooow:{text}+1");
		}
		xe1410f585439c7d.x53e7651cce580e9f("style:num-format", xbb857c9fc36f5054.x804cfca39e340742(xb57da2cbb90b8d4c));
	}

	private void xab857a7758835403()
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		x12954a224495d3c0.xffb053d2a78c4e1b();
		xe1410f585439c7d.x5a3f5d78674f78e4("text:page-number");
		xe1410f585439c7d.x19b0790c272bbe88("style:num-format", xbb857c9fc36f5054.x804cfca39e340742(xb57da2cbb90b8d4c));
		xe1410f585439c7d.x53e7651cce580e9f("text:select-page", "current");
		xe1410f585439c7d.xf3cbeec41f083290("text:page-number");
		x12954a224495d3c0.x81ddb41fb70cbf68();
	}

	private void x0018954a28cf4924(string x66ac3558868cc255)
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		x12954a224495d3c0.xffb053d2a78c4e1b();
		xe1410f585439c7d.x5a3f5d78674f78e4(x66ac3558868cc255);
		xe1410f585439c7d.x53e7651cce580e9f("style:num-format", xbb857c9fc36f5054.x804cfca39e340742(xb57da2cbb90b8d4c));
		xe1410f585439c7d.xf3cbeec41f083290(x66ac3558868cc255);
		x12954a224495d3c0.x81ddb41fb70cbf68();
	}

	private void xa49786a737a84ed7(string xc3513c7f2bbafa84)
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		x12954a224495d3c0.xffb053d2a78c4e1b();
		xe1410f585439c7d.x5a3f5d78674f78e4("text:user-defined");
		xe1410f585439c7d.x53e7651cce580e9f("text:name", xc3513c7f2bbafa84);
		xe1410f585439c7d.xf3cbeec41f083290("text:user-defined");
		x12954a224495d3c0.x81ddb41fb70cbf68();
	}

	private static FormField xb15ad493ee0817cd(FieldChar xa6315bf377f6364c)
	{
		Node nextSibling = xa6315bf377f6364c.NextSibling;
		while (nextSibling != null && nextSibling.NodeType != NodeType.FormField)
		{
			if (nextSibling.NodeType == NodeType.FieldEnd)
			{
				return null;
			}
			nextSibling = nextSibling.NextSibling;
		}
		return (FormField)nextSibling;
	}

	private static string xf74e3e3a35a32346()
	{
		return xbb857c9fc36f5054.x193fd22ffbc988d7(xb57da2cbb90b8d4c, "REF").Trim('"').Trim(' ');
	}

	private void x43ce448b234e76d8()
	{
		if (x5d6152611ac5fe5d())
		{
			x12954a224495d3c0.xffb053d2a78c4e1b();
			x9b287b671d592594.xe1410f585439c7d4.x3d1be38abe5723e3(x42cea74281abb9d6());
			x12954a224495d3c0.x81ddb41fb70cbf68();
		}
	}

	private static bool x5d6152611ac5fe5d()
	{
		string text = x42cea74281abb9d6();
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			return text.IndexOf('\\') == -1;
		}
		return false;
	}

	private static string x42cea74281abb9d6()
	{
		return xb57da2cbb90b8d4c.Substring(xb57da2cbb90b8d4c.ToLower().IndexOf("advance") + 7).Trim(' ');
	}
}
