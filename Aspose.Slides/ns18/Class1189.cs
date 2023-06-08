using System;
using System.Xml;
using Aspose.Slides;
using ns16;
using ns24;
using ns53;
using ns55;
using ns56;

namespace ns18;

internal class Class1189 : Class1188
{
	internal void method_5(IControl control)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType != XmlNodeType.Element || !(base.XmlPartReader.NamespaceURI == "http://schemas.microsoft.com/office/2006/activeX") || !(base.XmlPartReader.LocalName == "ocx"))
			{
				continue;
			}
			Class2338 @class = new Class2338(base.XmlPartReader);
			Class333 pPTXUnsupportedProps = ((Control)control).PPTXUnsupportedProps;
			pPTXUnsupportedProps.Persistence = @class.Persistence;
			pPTXUnsupportedProps.ClassId = new Guid(@class.Classid);
			if (@class.Persistence == Enum309.const_1)
			{
				Class1780[] ocxPrList = @class.OcxPrList;
				foreach (Class1780 class2 in ocxPrList)
				{
					control.Properties.Add(class2.Name, class2.Value);
				}
			}
			pPTXUnsupportedProps.License = @class.License;
			if (@class.R_Id != null)
			{
				Class1342 targetPart = base.DeserializationContext.RelationshipsOfCurrentPartEntry[@class.R_Id].TargetPart;
				pPTXUnsupportedProps.ActiveXControlBinary = targetPart.Data;
				targetPart.Processed = true;
			}
		}
		method_2();
	}

	internal void method_6(IControl control)
	{
		method_3();
		Class2338 @class = new Class2338();
		method_7(control, @class);
		if (control.Properties != null)
		{
			foreach (string namesOfProperty in control.Properties.NamesOfProperties)
			{
				Class1780 class2 = @class.delegate1219_0();
				class2.Name = namesOfProperty;
				class2.Value = control.Properties[namesOfProperty];
			}
		}
		@class.vmethod_4(null, base.XmlPartWriter, "ocx");
		method_4();
	}

	private void method_7(IControl control, Class2338 ocxElementData)
	{
		Class333 pPTXUnsupportedProps = ((Control)control).PPTXUnsupportedProps;
		ocxElementData.Persistence = pPTXUnsupportedProps.Persistence;
		ocxElementData.License = pPTXUnsupportedProps.License;
		if (pPTXUnsupportedProps.ActiveXControlBinary != null)
		{
			Class1342 @class = base.SerializationContext.Package.method_4("/ppt/activeX/activeX" + base.SerializationContext.method_20() + ".bin", null, new Class1299());
			@class.Data = pPTXUnsupportedProps.ActiveXControlBinary;
			Class1347 class2 = base.SerializationContext.RelationshipsOfCurrentPartEntry.method_4(@class);
			ocxElementData.R_Id = class2.Id;
		}
		ocxElementData.Classid = string.Concat("{", pPTXUnsupportedProps.ClassId, "}");
	}

	public Class1189(Class1342 part, Class1341 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1189(Class1342 part, Class1346 serializationContext)
		: base(part, serializationContext)
	{
	}
}
