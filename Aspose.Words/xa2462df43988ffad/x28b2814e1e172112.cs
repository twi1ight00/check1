using System;
using System.IO;
using Aspose.Words.Properties;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;
using xbe73d5820f7f4ae3;
using xf9a9481c3f63a419;

namespace xa2462df43988ffad;

internal class x28b2814e1e172112
{
	private readonly x9c77c7e782b62883 x800085dd555f7711;

	private readonly xdb0bf9f81de4b38c x9b287b671d592594;

	internal x28b2814e1e172112(xdb0bf9f81de4b38c writer)
	{
		x9b287b671d592594 = writer;
		x800085dd555f7711 = writer.x082c3925d43afdad("/meta.xml");
	}

	internal void x6210059f049f0d48()
	{
		x800085dd555f7711.xea077c7b3b428a58();
		x800085dd555f7711.x2307058321cdb62f("office:meta");
		x3d192a2c6663e616();
		x9166a0b8b2086ba0();
		x800085dd555f7711.x2dfde153f4ef96d0("office:meta");
		x800085dd555f7711.xa0dfc102c691b11f();
	}

	private void x3d192a2c6663e616()
	{
		BuiltInDocumentProperties builtInDocumentProperties = x9b287b671d592594.x2c8c6741422a1298.BuiltInDocumentProperties;
		if (x9b287b671d592594.xf57de0fd37d5e97d.xbfa4c2c3efbf56fd)
		{
			x800085dd555f7711.x6b73ce92fd8e3f2c("meta:generator", "Aspose.Words for .NET 11.9.0.0");
		}
		else
		{
			x800085dd555f7711.x6b73ce92fd8e3f2c("meta:generator", string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jpfoicnoccepoblppbcaoajaenpakpgbpaobpafcoplckadd", 568255928)));
		}
		x800085dd555f7711.x6b73ce92fd8e3f2c("dc:title", builtInDocumentProperties.Title);
		if (x0d299f323d241756.x5959bccb67bbf051(builtInDocumentProperties.Comments))
		{
			x800085dd555f7711.x6b73ce92fd8e3f2c("dc:description", builtInDocumentProperties.Comments);
		}
		if (x0d299f323d241756.x5959bccb67bbf051(builtInDocumentProperties.Subject))
		{
			x800085dd555f7711.x6b73ce92fd8e3f2c("dc:subject", builtInDocumentProperties.Subject);
		}
		if (x0d299f323d241756.x5959bccb67bbf051(builtInDocumentProperties.Keywords))
		{
			string[] array = builtInDocumentProperties.Keywords.Split(',');
			for (int i = 0; i < array.Length; i++)
			{
				x800085dd555f7711.x6b73ce92fd8e3f2c("meta:keyword", array[i]);
			}
		}
		x800085dd555f7711.x6b73ce92fd8e3f2c("meta:initial-creator", builtInDocumentProperties.Author);
		x75a1bba891c54546("CreateTime", "meta:creation-date");
		x800085dd555f7711.x6b73ce92fd8e3f2c("dc:creator", builtInDocumentProperties.LastSavedBy);
		x75a1bba891c54546("LastSavedTime", "dc:date");
		x75a1bba891c54546("LastPrinted", "meta:print-date");
		if (x0d299f323d241756.x5959bccb67bbf051(builtInDocumentProperties.Template) && Path.GetFileNameWithoutExtension(builtInDocumentProperties.Template).ToLower() != "normal")
		{
			x800085dd555f7711.xc049ea80ee267201("meta:template", "xlink:href", builtInDocumentProperties.Template, "xlink:type", "simple");
		}
		x800085dd555f7711.x6b73ce92fd8e3f2c("meta:editing-cycles", builtInDocumentProperties.RevisionNumber);
		string xbcea506a33cf = x27c5f04f09dba008(builtInDocumentProperties.TotalEditingTime);
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf))
		{
			x800085dd555f7711.x6b73ce92fd8e3f2c("meta:editing-duration", xbcea506a33cf);
		}
		x800085dd555f7711.xc049ea80ee267201("meta:document-statistic", "meta:page-count", builtInDocumentProperties.Pages, "meta:paragraph-count", builtInDocumentProperties.Paragraphs, "meta:row-count", builtInDocumentProperties.Lines, "meta:word-count", builtInDocumentProperties.Words, "meta:character-count", builtInDocumentProperties.CharactersWithSpaces, "meta:non-whitespace-character-count", builtInDocumentProperties.Characters);
	}

	private static string x27c5f04f09dba008(int x74a1d9a71b513406)
	{
		if (x74a1d9a71b513406 <= 0)
		{
			return null;
		}
		long num = 0L;
		long num2 = (long)x74a1d9a71b513406 % 60L;
		long num3 = (long)x74a1d9a71b513406 / 60L;
		string arg = ((num == 0) ? "" : $"{num}S");
		string arg2 = ((num2 == 0) ? "" : $"{num2}M");
		string arg3 = ((num3 == 0) ? "" : $"{num3}H");
		return $"PT{arg3}{arg2}{arg}";
	}

	private void x75a1bba891c54546(string xb4210be23f399019, string x121383aa64985888)
	{
		DocumentProperty documentProperty = x9b287b671d592594.x2c8c6741422a1298.BuiltInDocumentProperties[xb4210be23f399019];
		if (documentProperty.x240f22d025b60fe7 is DateTime)
		{
			DateTime dateTime = documentProperty.ToDateTime();
			if (dateTime != DateTime.MinValue)
			{
				x800085dd555f7711.x6b73ce92fd8e3f2c(x121383aa64985888, xca004f56614e2431.x4fd2cbfd96b1abdc(dateTime));
			}
		}
	}

	private void x9166a0b8b2086ba0()
	{
		foreach (DocumentProperty customDocumentProperty in x9b287b671d592594.x2c8c6741422a1298.CustomDocumentProperties)
		{
			string xbcea506a33cf;
			switch (customDocumentProperty.Type)
			{
			case PropertyType.Boolean:
				xbcea506a33cf = xca004f56614e2431.x957baa621044fc39((bool)customDocumentProperty.x240f22d025b60fe7);
				break;
			case PropertyType.DateTime:
				xbcea506a33cf = xca004f56614e2431.x4fd2cbfd96b1abdc((DateTime)customDocumentProperty.x240f22d025b60fe7);
				break;
			case PropertyType.Number:
				xbcea506a33cf = xca004f56614e2431.xc8ba948e0d631490((int)customDocumentProperty.x240f22d025b60fe7);
				break;
			case PropertyType.Double:
				xbcea506a33cf = xca004f56614e2431.xcaaeec2e96b2cecc((double)customDocumentProperty.x240f22d025b60fe7);
				break;
			case PropertyType.String:
				xbcea506a33cf = (string)customDocumentProperty.x240f22d025b60fe7;
				break;
			default:
				continue;
			}
			string xbcea506a33cf2 = x0eb9a864413f34de.x5730cdebb9d7bbb5(customDocumentProperty.Type);
			x800085dd555f7711.x2307058321cdb62f("meta:user-defined");
			x800085dd555f7711.x943f6be3acf634db("meta:name", customDocumentProperty.Name);
			x800085dd555f7711.x943f6be3acf634db("meta:value-type", xbcea506a33cf2);
			x800085dd555f7711.x3d1be38abe5723e3(xbcea506a33cf);
			x800085dd555f7711.x2dfde153f4ef96d0("meta:user-defined");
		}
	}
}
