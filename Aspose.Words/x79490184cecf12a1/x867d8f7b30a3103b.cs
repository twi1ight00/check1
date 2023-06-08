using System.Text;
using Aspose.Words.Properties;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x79490184cecf12a1;

internal class x867d8f7b30a3103b
{
	private x867d8f7b30a3103b()
	{
	}

	internal static void x06b0e25aa6ad68a9(xae13d15563a3a703 xe134235b3526fa75)
	{
		x9ea8b270a83f04a0 x9ea8b270a83f04a = xe134235b3526fa75.x953c9e9688085b0b("http://schemas.openxmlformats.org/package/2006/relationships/metadata/core-properties");
		if (x9ea8b270a83f04a == null)
		{
			return;
		}
		BuiltInDocumentProperties builtInDocumentProperties = xe134235b3526fa75.x2c8c6741422a1298.BuiltInDocumentProperties;
		while (x9ea8b270a83f04a.x152cbadbfa8061b1("coreProperties"))
		{
			switch (x9ea8b270a83f04a.xa66385d80d4d296f)
			{
			case "title":
				builtInDocumentProperties.Title = x9ea8b270a83f04a.x2a1ea9d24e62bf84();
				break;
			case "subject":
				builtInDocumentProperties.Subject = x9ea8b270a83f04a.x2a1ea9d24e62bf84();
				break;
			case "creator":
				builtInDocumentProperties.Author = x9ea8b270a83f04a.x2a1ea9d24e62bf84();
				break;
			case "keywords":
				xfe7b7335413411d3(builtInDocumentProperties, x9ea8b270a83f04a);
				break;
			case "description":
				builtInDocumentProperties.Comments = x9ea8b270a83f04a.x2a1ea9d24e62bf84();
				break;
			case "lastModifiedBy":
				builtInDocumentProperties.LastSavedBy = x9ea8b270a83f04a.x2a1ea9d24e62bf84();
				break;
			case "revision":
				builtInDocumentProperties.RevisionNumber = x9ea8b270a83f04a.xab461f3453328cf7();
				break;
			case "lastPrinted":
				builtInDocumentProperties.LastPrinted = xca004f56614e2431.x70982613fd6240f9(x9ea8b270a83f04a.x2a1ea9d24e62bf84());
				break;
			case "created":
				builtInDocumentProperties.CreatedTime = xca004f56614e2431.x70982613fd6240f9(x9ea8b270a83f04a.x2a1ea9d24e62bf84());
				break;
			case "modified":
				builtInDocumentProperties.LastSavedTime = xca004f56614e2431.x70982613fd6240f9(x9ea8b270a83f04a.x2a1ea9d24e62bf84());
				break;
			case "category":
				builtInDocumentProperties.Category = x9ea8b270a83f04a.x2a1ea9d24e62bf84();
				break;
			case "contentStatus":
				builtInDocumentProperties.ContentStatus = x9ea8b270a83f04a.x2a1ea9d24e62bf84();
				break;
			case "contentType":
				builtInDocumentProperties.ContentType = x9ea8b270a83f04a.x2a1ea9d24e62bf84();
				break;
			default:
				x9ea8b270a83f04a.IgnoreElement();
				break;
			}
		}
	}

	private static void xfe7b7335413411d3(BuiltInDocumentProperties xa5ea04da0b735c3b, x9ea8b270a83f04a0 x97bf2eeabd4abc7b)
	{
		StringBuilder stringBuilder = new StringBuilder();
		while (x97bf2eeabd4abc7b.x416ea3123144a39f("keywords", x764dfdef5d60f7e6.x96ad199d34a16ce4))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x97bf2eeabd4abc7b.xa66385d80d4d296f) != null && xa66385d80d4d296f == "value")
			{
				stringBuilder.Append(x97bf2eeabd4abc7b.x2a1ea9d24e62bf84());
				stringBuilder.Append(", ");
			}
			else
			{
				xa5ea04da0b735c3b.Keywords = x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb;
			}
		}
		if (stringBuilder.Length != 0)
		{
			xa5ea04da0b735c3b.Keywords = ((xa5ea04da0b735c3b.Keywords.Length > 0) ? (stringBuilder.ToString() + xa5ea04da0b735c3b.Keywords) : stringBuilder.ToString(0, stringBuilder.Length - 2));
		}
	}
}
