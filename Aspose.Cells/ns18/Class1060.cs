using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns47;

namespace ns18;

internal class Class1060
{
	private int int_0 = 1;

	private readonly Class1050 class1050_0;

	private Class1009 class1009_0;

	private Class1061 class1061_0;

	private Class1058 class1058_0;

	private readonly ArrayList arrayList_0 = new ArrayList();

	private readonly ArrayList arrayList_1 = new ArrayList();

	private readonly Hashtable hashtable_0 = new Hashtable();

	private SizeF sizeF_0;

	public Class1060(Class1050 class1050_1)
	{
		class1050_0 = class1050_1;
		method_6();
	}

	public void method_0()
	{
		Class1051 @class = class1050_0.method_0()["/Documents/1/FixedDocument.fdoc"];
		foreach (object key in class1058_0.method_9().Keys)
		{
			Class1460 class2 = ((Class1077)class1058_0.method_9()[key]).method_2();
			if (class2.method_59())
			{
				@class.method_3().Add("http://schemas.microsoft.com/xps/2005/06/restricted-font", (string)key, bool_0: false);
			}
		}
		class1009_0.method_2();
		method_7();
		method_8();
		class1058_0.vmethod_2();
		Class1055.Write(class1050_0, bool_0: false);
		Class1047.Write(class1050_0, bool_0: false);
	}

	public void method_1(float float_0, float float_1)
	{
		class1009_0.method_3("PageContent");
		class1009_0.method_9("Source", $"Pages/{int_0}.fpage");
		class1058_0.method_11(int_0);
		class1061_0 = new Class1061(class1058_0, new Class1009(class1058_0.method_13().method_1(), bool_0: true), bool_2: true);
		class1061_0.method_0(int_0, float_0, float_1);
	}

	public void method_2()
	{
		if (arrayList_0 != null && arrayList_0.Count > 0)
		{
			class1009_0.method_3("PageContent.LinkTargets");
			foreach (string item in arrayList_0)
			{
				class1009_0.method_3("LinkTarget");
				class1009_0.method_9("Name", item);
				class1009_0.method_4();
			}
			arrayList_0.Clear();
			class1009_0.method_4();
		}
		class1009_0.method_4();
		class1061_0.method_1();
		class1058_0.method_12();
		int_0++;
	}

	public void method_3(SizeF sizeF_1)
	{
		if (int_0 == 1)
		{
			sizeF_0 = sizeF_1;
		}
		string key = $"{sizeF_1.Width}{sizeF_1.Height}";
		string text = (string)hashtable_0[key];
		if (text == null)
		{
			text = $"/Documents/1/Metadata/Page{int_0}_PT.xml";
			hashtable_0[key] = text;
			Class1051 @class = new Class1051(text, "application/vnd.ms-printing.printticket+xml");
			Class1066.Write(new Class1009(@class.method_1(), bool_0: true), sizeF_1, bool_0: true);
			class1050_0.method_0().Add(@class);
		}
		class1058_0.method_13().method_3().Add("http://schemas.microsoft.com/xps/2005/06/printticket", text, bool_0: false);
	}

	private void method_4(Class1051 class1051_0)
	{
		Class1051 @class = new Class1051("/Metadata/MXDC_Empty_PT.xml", "application/vnd.ms-printing.printticket+xml");
		Class1066.smethod_0(new Class1009(@class.method_1(), bool_0: true));
		class1051_0.method_3().Add("http://schemas.microsoft.com/xps/2005/06/printticket", @class.Name, bool_0: false);
		class1050_0.method_0().Add(@class);
	}

	private void method_5(Class1051 class1051_0)
	{
		Class1051 @class = new Class1051("/Metadata/Job_PT.xml", "application/vnd.ms-printing.printticket+xml");
		Class1066.Write(new Class1009(@class.method_1(), bool_0: true), sizeF_0, bool_0: false);
		class1051_0.method_3().Add("http://schemas.microsoft.com/xps/2005/06/printticket", @class.Name, bool_0: false);
		class1050_0.method_0().Add(@class);
	}

	private void method_6()
	{
		class1058_0 = new Class1058(class1050_0);
		Class1051 @class = new Class1051("/Documents/1/FixedDocument.fdoc", "application/vnd.ms-package.xps-fixeddocument+xml");
		class1009_0 = new Class1009(@class.method_1(), bool_0: false);
		class1009_0.method_1("FixedDocument");
		class1009_0.method_9("xmlns", "http://schemas.microsoft.com/xps/2005/06");
		method_4(@class);
		class1050_0.method_0().method_0(@class);
	}

	private void method_7()
	{
		Class1051 @class = new Class1051("/FixedDocumentSequence.fdseq", "application/vnd.ms-package.xps-fixeddocumentsequence+xml");
		Class1009 class2 = new Class1009(@class.method_1(), bool_0: false);
		class2.method_1("FixedDocumentSequence");
		class2.method_9("xmlns", "http://schemas.microsoft.com/xps/2005/06");
		class2.method_3("DocumentReference");
		class2.method_9("Source", "Documents/1/FixedDocument.fdoc");
		class2.method_4();
		class2.method_2();
		class1050_0.method_2().Add("http://schemas.microsoft.com/xps/2005/06/fixedrepresentation", "/FixedDocumentSequence.fdseq", bool_0: false);
		method_5(@class);
		class1050_0.method_0().Add(@class);
	}

	private void method_8()
	{
		Class1051 @class = new Class1051("/docProps/core.xml", "application/vnd.openxmlformats-package.core-properties+xml");
		Class1009 class2 = new Class1009(@class.method_1(), bool_0: false);
		Class1048.Write(class2, class1058_0.method_8().Title, class1058_0.method_8().Subject, class1058_0.method_8().method_1(), class1058_0.method_8().Keywords, class1058_0.method_8().method_2(), class1058_0.method_8().method_3(), class1058_0.method_8().method_4(), class1058_0.method_8().LastPrinted, class1058_0.method_8().method_5(), class1058_0.method_8().method_6(), class1058_0.method_8().Category);
		class1050_0.method_2().Add("http://schemas.openxmlformats.org/package/2006/relationships/metadata/core-properties", "/docProps/core.xml", bool_0: false);
		class1050_0.method_0().Add(@class);
	}

	[SpecialName]
	public Class1061 method_9()
	{
		return class1061_0;
	}
}
