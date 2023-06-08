using System.Collections.Generic;
using System.IO;
using ns55;

namespace ns53;

internal class Class1184 : Class1183
{
	private List<Class1342> list_2 = new List<Class1342>();

	private List<Class1342> list_3 = new List<Class1342>();

	private List<Class1342> list_4 = new List<Class1342>();

	private List<Class1342> list_5 = new List<Class1342>();

	private List<Class1342> list_6 = new List<Class1342>();

	private List<Class1342> list_7 = new List<Class1342>();

	private List<Class1342> list_8 = new List<Class1342>();

	private List<Class1342> list_9 = new List<Class1342>();

	private List<Class1342> list_10 = new List<Class1342>();

	private Class1342 class1342_0;

	private Class1342 class1342_1;

	private Class1342 class1342_2;

	private Class1342 class1342_3;

	private Class1342 class1342_4;

	private Class1342 class1342_5;

	private Class1342 class1342_6;

	private Class1342 class1342_7;

	private Class1342 class1342_8;

	public Class1342[] Slides => list_2.ToArray();

	public Class1342[] Layouts => list_3.ToArray();

	public Class1342[] Masters => list_4.ToArray();

	public Class1342[] Notes => list_5.ToArray();

	public Class1342[] NotesMasters => list_6.ToArray();

	public Class1342[] HandoutMasters => list_7.ToArray();

	public Class1342[] Images => list_8.ToArray();

	public Class1342[] Vmls => list_9.ToArray();

	public Class1342[] Tagses => list_10.ToArray();

	public Class1342 CustomProperties => class1342_2;

	public Class1342 CoreProperties => class1342_1;

	public Class1342 ExtendedProperties => class1342_0;

	public Class1342 Presentation => class1342_5;

	public Class1342 TableStyles => class1342_6;

	public Class1342 Theme => class1342_7;

	public Class1342 VbaProject => class1342_8;

	public Class1342 PresProps => class1342_3;

	public Class1342 ViewProps => class1342_4;

	public Class1184()
	{
	}

	public Class1184(Stream stream)
		: base(stream)
	{
	}

	public override void vmethod_0(IList<Class1342> parts)
	{
		foreach (Class1342 part in parts)
		{
			vmethod_1(part);
		}
		Class1347[] array = class1342_5.Relationships.method_0(Class1235.class1338_0);
		if (array.Length > 0)
		{
			class1342_6 = method_3(array[0].Target);
		}
		array = class1342_5.Relationships.method_0(Class1237.class1338_0);
		if (array.Length > 0)
		{
			class1342_7 = method_3(array[0].Target);
		}
	}

	public override void vmethod_1(Class1342 pentry)
	{
		if (pentry.ContentType is Class1225)
		{
			switch (pentry.ContentType.ContentType)
			{
			case "application/vnd.openxmlformats-officedocument.presentationml.slideMaster+xml":
				list_4.Add(pentry);
				break;
			case "application/vnd.openxmlformats-officedocument.presentationml.slideLayout+xml":
				list_3.Add(pentry);
				break;
			case "application/vnd.openxmlformats-officedocument.presentationml.notesSlide+xml":
				list_5.Add(pentry);
				break;
			case "application/vnd.openxmlformats-officedocument.presentationml.notesMaster+xml":
				list_6.Add(pentry);
				break;
			case "application/vnd.openxmlformats-officedocument.presentationml.handoutMaster+xml":
				list_7.Add(pentry);
				break;
			case "application/vnd.openxmlformats-officedocument.presentationml.slide+xml":
				list_2.Add(pentry);
				break;
			case "application/vnd.openxmlformats-officedocument.vmlDrawing":
				list_9.Add(pentry);
				break;
			case "application/vnd.openxmlformats-officedocument.presentationml.tags+xml":
				list_10.Add(pentry);
				break;
			case "application/vnd.openxmlformats-officedocument.extended-properties+xml":
				class1342_0 = pentry;
				break;
			case "application/vnd.openxmlformats-package.core-properties+xml":
				class1342_1 = pentry;
				break;
			case "application/vnd.openxmlformats-officedocument.custom-properties+xml":
				class1342_2 = pentry;
				break;
			case "application/vnd.openxmlformats-officedocument.presentationml.presProps+xml":
				class1342_3 = pentry;
				break;
			case "application/vnd.openxmlformats-officedocument.presentationml.viewProps+xml":
				class1342_4 = pentry;
				break;
			}
			if (pentry.ContentType is Class1250)
			{
				class1342_5 = pentry;
			}
		}
		else if (pentry.ContentType is Class1305)
		{
			list_8.Add(pentry);
		}
		else if (pentry.ContentType is Class1335)
		{
			class1342_8 = pentry;
		}
		else if (pentry.ContentType == null)
		{
			pentry.method_5(new Class1337());
		}
	}
}
