using System.Globalization;
using System.Xml;
using Aspose.Slides;
using ns53;
using ns54;
using ns56;

namespace ns19;

internal class Class1213 : Class1187
{
	internal void method_5(IDocumentProperties documentProperties)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType == XmlNodeType.Element && base.XmlPartReader.NamespaceURI == "http://schemas.openxmlformats.org/package/2006/metadata/core-properties" && base.XmlPartReader.LocalName == "coreProperties")
			{
				Class2343 @class = new Class2343(base.XmlPartReader);
				documentProperties.Title = @class.Title;
				documentProperties.Author = @class.Creator;
				documentProperties.Subject = @class.Subject;
				documentProperties.Keywords = @class.Keywords;
				documentProperties.Comments = @class.Description.Replace("_x000d_", "");
				documentProperties.Category = @class.Category;
				documentProperties.ContentStatus = @class.ContentStatus;
				documentProperties.ContentType = @class.ContentType;
				documentProperties.CreatedTime = @class.Created;
				documentProperties.LastSavedTime = @class.Modified;
				documentProperties.LastPrinted = @class.LastPrinted;
				documentProperties.LastSavedBy = @class.LastModifiedBy;
				if (int.TryParse(@class.Revision, out var result))
				{
					documentProperties.RevisionNumber = result;
				}
			}
		}
		method_2();
	}

	internal void method_6(IDocumentProperties documentProperties)
	{
		method_3();
		Class2343 @class = new Class2343();
		@class.Title = documentProperties.Title;
		@class.Creator = documentProperties.Author;
		@class.Subject = documentProperties.Subject;
		@class.Keywords = documentProperties.Keywords;
		@class.Description = documentProperties.Comments;
		@class.Category = documentProperties.Category;
		@class.ContentStatus = documentProperties.ContentStatus;
		@class.ContentType = documentProperties.ContentType;
		@class.Created = documentProperties.CreatedTime;
		@class.Modified = documentProperties.LastSavedTime;
		@class.LastPrinted = documentProperties.LastPrinted;
		@class.LastModifiedBy = documentProperties.LastSavedBy;
		@class.Revision = documentProperties.RevisionNumber.ToString(CultureInfo.InvariantCulture);
		@class.vmethod_4(null, base.XmlPartWriter, "coreProperties");
		method_4();
	}

	public Class1213(Class1342 part, Class1339 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1213(Class1342 part, Class1344 serializationContext)
		: base(part, serializationContext)
	{
	}
}
