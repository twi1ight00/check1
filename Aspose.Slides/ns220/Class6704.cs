using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using ns218;
using ns221;
using ns235;
using ns247;
using ns271;

namespace ns220;

internal class Class6704
{
	private int int_0 = 1;

	private readonly Class6256 class6256_0;

	private Class5946 class5946_0;

	private Class6694 class6694_0;

	private Class6690 class6690_0;

	private readonly List<string> list_0 = new List<string>();

	private readonly List<string> list_1 = new List<string>();

	private readonly Hashtable hashtable_0 = new Hashtable();

	private SizeF sizeF_0 = SizeF.Empty;

	private int int_1;

	private List<Class6597> list_2 = new List<Class6597>();

	private int int_2;

	public Class6694 PageWriter => class6694_0;

	public Class5956 Info
	{
		get
		{
			return class6690_0.Info;
		}
		set
		{
			class6690_0.Info = value;
		}
	}

	public Class6596 Options
	{
		get
		{
			return class6690_0.Options;
		}
		set
		{
			class6690_0.Options = value;
		}
	}

	public IList<Class5974> Warnings => class6690_0.Warnings;

	public Class6704(Class6256 xpsPackage)
	{
		class6256_0 = xpsPackage;
		method_10();
	}

	public void method_0()
	{
		Class6260 @class = class6256_0.Parts["/Documents/1/FixedDocument.fdoc"];
		foreach (DictionaryEntry fontSubset in class6690_0.FontSubsets)
		{
			Class6730 tTFont = ((Class6733)fontSubset.Value).TTFont;
			if (tTFont.IsPrintPreview)
			{
				@class.Rels.Add("http://schemas.microsoft.com/xps/2005/06/restricted-font", (string)fontSubset.Key, isExternal: false);
			}
		}
		class5946_0.method_1();
		method_11();
		method_12();
		method_13();
		class6690_0.vmethod_1();
		Class6264.Write(class6256_0, isPrettyFormat: false);
		Class6258.Write(class6256_0, isPrettyFormat: false);
	}

	public void method_1(float width, float height)
	{
		class5946_0.method_2("PageContent");
		class5946_0.method_14("Source", $"Pages/{int_0}.fpage");
		class6690_0.method_9(int_0);
		class6694_0 = new Class6694(class6690_0, new Class5947(class6690_0.CurrentPagePart.Stream, isPrettyFormat: true), isXps: true);
		class6694_0.method_0(int_0, width, height);
	}

	public void method_2()
	{
		if (list_0 != null && list_0.Count > 0)
		{
			class5946_0.method_2("PageContent.LinkTargets");
			foreach (string item in list_0)
			{
				class5946_0.method_2("LinkTarget");
				class5946_0.method_14("Name", item);
				class5946_0.method_3();
			}
			list_0.Clear();
			class5946_0.method_3();
		}
		class5946_0.method_3();
		class6694_0.method_1();
		int_0++;
	}

	public void method_3(Class6211 bookmark)
	{
		string name = method_6(bookmark.Name, bookmark.Origin);
		if (Options.BookmarksOutlineLevel > 0 && !bookmark.IsHiddenFromOutline)
		{
			method_5(Options.BookmarksOutlineLevel, bookmark.Name, name);
		}
	}

	public void method_4(Class6221 item)
	{
		if (item.Level < Options.HeadingsOutlineLevels)
		{
			string bookmarkName = $"outline_{int_1++}";
			string name = method_6(bookmarkName, item.Origin);
			method_5(item.Level + 1, item.Title, name);
		}
	}

	internal void method_5(int level, string title, string name)
	{
		if (level > int_2)
		{
			level = int_2 + 1;
		}
		Class6597 item = new Class6597(level, title, name);
		list_2.Add(item);
		int_2 = level;
	}

	private string method_6(string bookmarkName, PointF bookmarkOrigin)
	{
		if (!list_1.Contains(bookmarkName))
		{
			string text = class6690_0.method_0(bookmarkName);
			class6694_0.method_8(text, bookmarkOrigin);
			list_0.Add(text);
			list_1.Add(bookmarkName);
			return text;
		}
		return string.Empty;
	}

	public void method_7(SizeF pageSize)
	{
		if (int_0 == 1)
		{
			sizeF_0 = pageSize;
		}
		string key = $"{pageSize.Width}{pageSize.Height}";
		string text = (string)hashtable_0[key];
		if (text == null)
		{
			text = $"/Documents/1/Metadata/Page{int_0}_PT.xml";
			hashtable_0[key] = text;
			Class6260 @class = new Class6260(text, "application/vnd.ms-printing.printticket+xml");
			class6256_0.Parts.Add(@class);
			Class6687.Write(new Class5946(@class.Stream, isPrettyFormat: true), pageSize, isPage: true);
		}
		class6690_0.CurrentPagePart.Rels.Add("http://schemas.microsoft.com/xps/2005/06/printticket", text, isExternal: false);
	}

	private void method_8(Class6260 fixedDocumentPart)
	{
		Class6260 @class = new Class6260("/Metadata/MXDC_Empty_PT.xml", "application/vnd.ms-printing.printticket+xml");
		class6256_0.Parts.Add(@class);
		Class6687.smethod_0(new Class5946(@class.Stream, isPrettyFormat: true));
		fixedDocumentPart.Rels.Add("http://schemas.microsoft.com/xps/2005/06/printticket", @class.Name, isExternal: false);
	}

	private void method_9(Class6260 fixedDocumentSequencePart)
	{
		Class6260 @class = new Class6260("/Metadata/Job_PT.xml", "application/vnd.ms-printing.printticket+xml");
		class6256_0.Parts.Add(@class);
		Class6687.Write(new Class5946(@class.Stream, isPrettyFormat: true), sizeF_0, isPage: false);
		fixedDocumentSequencePart.Rels.Add("http://schemas.microsoft.com/xps/2005/06/printticket", @class.Name, isExternal: false);
	}

	private void method_10()
	{
		class6690_0 = new Class6690(class6256_0);
		Class6260 @class = new Class6260("/Documents/1/FixedDocument.fdoc", "application/vnd.ms-package.xps-fixeddocument+xml");
		class6256_0.Parts.Add(@class);
		class5946_0 = new Class5946(@class.Stream, isPrettyFormat: false);
		class5946_0.method_0("FixedDocument");
		class5946_0.method_14("xmlns", "http://schemas.microsoft.com/xps/2005/06");
		method_8(@class);
	}

	private void method_11()
	{
		Class6260 @class = new Class6260("/FixedDocumentSequence.fdseq", "application/vnd.ms-package.xps-fixeddocumentsequence+xml");
		class6256_0.Parts.Add(@class);
		Class5946 class2 = new Class5946(@class.Stream, isPrettyFormat: false);
		class2.method_0("FixedDocumentSequence");
		class2.method_14("xmlns", "http://schemas.microsoft.com/xps/2005/06");
		class2.method_2("DocumentReference");
		class2.method_14("Source", "Documents/1/FixedDocument.fdoc");
		class2.method_3();
		class2.method_1();
		class6256_0.Rels.Add("http://schemas.microsoft.com/xps/2005/06/fixedrepresentation", "/FixedDocumentSequence.fdseq", isExternal: false);
		method_9(@class);
	}

	private void method_12()
	{
		class6690_0.method_2(Enum743.const_0, "Only built-in document properties will be output to XPS. All custom document properties will be lost");
		Class6260 @class = new Class6260("/docProps/core.xml", "application/vnd.openxmlformats-package.core-properties+xml");
		class6256_0.Parts.Add(@class);
		Class5946 builder = new Class5946(@class.Stream, isPrettyFormat: false);
		Class6259.Write(builder, class6690_0.Info.Title, class6690_0.Info.Subject, class6690_0.Info.Creator, class6690_0.Info.Keywords, class6690_0.Info.Description, class6690_0.Info.LastModifiedBy, class6690_0.Info.Revision, class6690_0.Info.LastPrinted, class6690_0.Info.CreationDate, class6690_0.Info.ModifiedDate, class6690_0.Info.Category);
		class6256_0.Rels.Add("http://schemas.openxmlformats.org/package/2006/relationships/metadata/core-properties", "/docProps/core.xml", isExternal: false);
	}

	private void method_13()
	{
		if (list_2.Count <= 0)
		{
			return;
		}
		Class6260 @class = new Class6260("/Documents/1/Structure/DocStructure.struct", "application/vnd.ms-package.xps-documentstructure+xml");
		class6256_0.Parts.Add(@class);
		Class5946 class2 = new Class5946(@class.Stream, isPrettyFormat: false);
		class2.method_0("DocumentStructure");
		class2.method_14("xmlns", "http://schemas.microsoft.com/xps/2005/06/documentstructure");
		class2.method_2("DocumentStructure.Outline");
		class2.method_2("DocumentOutline");
		class2.method_14("xml:lang", "en-US");
		foreach (Class6597 item in list_2)
		{
			class2.method_2("OutlineEntry");
			class2.method_14("OutlineLevel", item.Level.ToString());
			class2.method_14("Description", item.Title);
			class2.method_14("OutlineTarget", $"../../../FixedDocumentSequence.fdseq#{item.BookmarkName}");
			class2.method_3();
		}
		class2.method_3();
		class2.method_3();
		class2.method_1();
		Class6260 class3 = class6256_0.Parts["/Documents/1/FixedDocument.fdoc"];
		class3.Rels.Add("http://schemas.microsoft.com/xps/2005/06/documentstructure", "/Documents/1/Structure/DocStructure.struct", isExternal: false);
	}
}
