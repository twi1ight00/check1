using System;
using System.Xml;
using Aspose.Slides;
using ns53;
using ns54;
using ns56;

namespace ns19;

internal class Class1215 : Class1187
{
	internal void method_5(IDocumentProperties documentProperties)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType == XmlNodeType.Element && base.XmlPartReader.NamespaceURI == "http://schemas.openxmlformats.org/officeDocument/2006/extended-properties" && base.XmlPartReader.LocalName == "Properties")
			{
				Class2193 @class = new Class2193(base.XmlPartReader);
				documentProperties.NameOfApplication = @class.Application;
				documentProperties.Company = @class.Company;
				documentProperties.Manager = @class.Manager;
				documentProperties.PresentationFormat = @class.PresentationFormat;
				documentProperties.SharedDoc = @class.SharedDoc == NullableBool.True;
				documentProperties.ApplicationTemplate = @class.Template;
				documentProperties.TotalEditingTime = TimeSpan.FromMinutes(@class.TotalTime);
				documentProperties.HyperlinkBase = @class.HyperlinkBase;
				((DocumentProperties)documentProperties).string_15 = @class.AppVersion;
			}
		}
		method_2();
	}

	internal void method_6(IDocumentProperties documentProperties)
	{
		method_3();
		Class2193 @class = new Class2193();
		@class.Application = ((documentProperties.NameOfApplication == "") ? null : documentProperties.NameOfApplication);
		@class.Company = ((documentProperties.Company == "") ? null : documentProperties.Company);
		@class.Manager = ((documentProperties.Manager == "") ? null : documentProperties.Manager);
		@class.PresentationFormat = ((documentProperties.PresentationFormat == "") ? null : documentProperties.PresentationFormat);
		@class.SharedDoc = (documentProperties.SharedDoc ? NullableBool.True : NullableBool.False);
		@class.Template = ((documentProperties.ApplicationTemplate == "") ? null : documentProperties.ApplicationTemplate);
		@class.TotalTime = (int)documentProperties.TotalEditingTime.TotalMinutes;
		@class.HyperlinkBase = documentProperties.HyperlinkBase;
		@class.AppVersion = "14.0000";
		@class.vmethod_4(null, base.XmlPartWriter, "Properties");
		method_4();
	}

	public Class1215(Class1342 part, Class1339 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1215(Class1342 part, Class1344 serializationContext)
		: base(part, serializationContext)
	{
	}
}
