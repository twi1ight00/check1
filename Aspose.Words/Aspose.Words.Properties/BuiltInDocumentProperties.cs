using System;
using System.Collections;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace Aspose.Words.Properties;

public class BuiltInDocumentProperties : DocumentPropertyCollection
{
	private static readonly IDictionary x33d8ad81a0e8b951;

	private static readonly IDictionary xbba919600221c03b;

	public override DocumentProperty this[string name]
	{
		get
		{
			x0d299f323d241756.x48501aec8e48c869(name, "name");
			object obj = x33d8ad81a0e8b951[name];
			DocumentProperty documentProperty = base[(obj == null) ? name : ((string)obj)];
			if (documentProperty == null)
			{
				object obj2 = xbba919600221c03b[name];
				if (obj2 != null)
				{
					documentProperty = xd6b6ed77479ef68c(name, DocumentProperty.xd47ff1a4896c949c((PropertyType)obj2));
				}
			}
			return documentProperty;
		}
	}

	public string Author
	{
		get
		{
			return this["Author"].ToString();
		}
		set
		{
			this["Author"].xb0c325557cbfd6d3(value);
		}
	}

	public int Bytes
	{
		get
		{
			return this["Bytes"].ToInt();
		}
		set
		{
			this["Bytes"].x711de48f6502f1f4(value);
		}
	}

	public int Characters
	{
		get
		{
			return this["Characters"].ToInt();
		}
		set
		{
			this["Characters"].x711de48f6502f1f4(value);
		}
	}

	public int CharactersWithSpaces
	{
		get
		{
			return this["CharactersWithSpaces"].ToInt();
		}
		set
		{
			this["CharactersWithSpaces"].x711de48f6502f1f4(value);
		}
	}

	public string Comments
	{
		get
		{
			return this["Comments"].ToString();
		}
		set
		{
			this["Comments"].xb0c325557cbfd6d3(value);
		}
	}

	public string Category
	{
		get
		{
			return this["Category"].ToString();
		}
		set
		{
			this["Category"].xb0c325557cbfd6d3(value);
		}
	}

	public string Company
	{
		get
		{
			return this["Company"].ToString();
		}
		set
		{
			this["Company"].xb0c325557cbfd6d3(value);
		}
	}

	public DateTime CreatedTime
	{
		get
		{
			return this["CreateTime"].ToDateTime();
		}
		set
		{
			this["CreateTime"].xa04a1d7c78d1cb54(value);
		}
	}

	public string HyperlinkBase
	{
		get
		{
			return this["HyperlinkBase"].ToString();
		}
		set
		{
			this["HyperlinkBase"].xb0c325557cbfd6d3(value);
		}
	}

	public string Keywords
	{
		get
		{
			return this["Keywords"].ToString();
		}
		set
		{
			this["Keywords"].xb0c325557cbfd6d3(value);
		}
	}

	public DateTime LastPrinted
	{
		get
		{
			return this["LastPrinted"].ToDateTime();
		}
		set
		{
			this["LastPrinted"].xa04a1d7c78d1cb54(value);
		}
	}

	public string LastSavedBy
	{
		get
		{
			return this["LastSavedBy"].ToString();
		}
		set
		{
			this["LastSavedBy"].xb0c325557cbfd6d3(value);
		}
	}

	public DateTime LastSavedTime
	{
		get
		{
			return this["LastSavedTime"].ToDateTime();
		}
		set
		{
			this["LastSavedTime"].xa04a1d7c78d1cb54(value);
		}
	}

	public int Lines
	{
		get
		{
			return this["Lines"].ToInt();
		}
		set
		{
			this["Lines"].x711de48f6502f1f4(value);
		}
	}

	public bool LinksUpToDate
	{
		get
		{
			return this["LinksUpToDate"].ToBool();
		}
		set
		{
			this["LinksUpToDate"].x1e5f5c3e4c508bf0(value);
		}
	}

	public string Manager
	{
		get
		{
			return this["Manager"].ToString();
		}
		set
		{
			this["Manager"].xb0c325557cbfd6d3(value);
		}
	}

	public string NameOfApplication
	{
		get
		{
			return this["NameOfApplication"].ToString();
		}
		set
		{
			this["NameOfApplication"].xb0c325557cbfd6d3(value);
		}
	}

	public int Pages
	{
		get
		{
			return this["Pages"].ToInt();
		}
		set
		{
			this["Pages"].x711de48f6502f1f4(value);
		}
	}

	public int Paragraphs
	{
		get
		{
			return this["Paragraphs"].ToInt();
		}
		set
		{
			this["Paragraphs"].x711de48f6502f1f4(value);
		}
	}

	public int RevisionNumber
	{
		get
		{
			return this["RevisionNumber"].ToInt();
		}
		set
		{
			this["RevisionNumber"].x711de48f6502f1f4(value);
		}
	}

	public DocumentSecurity Security
	{
		get
		{
			return (DocumentSecurity)this["Security"].ToInt();
		}
		set
		{
			this["Security"].x711de48f6502f1f4((int)value);
		}
	}

	public string Subject
	{
		get
		{
			return this["Subject"].ToString();
		}
		set
		{
			this["Subject"].xb0c325557cbfd6d3(value);
		}
	}

	public string Template
	{
		get
		{
			return this["Template"].ToString();
		}
		set
		{
			this["Template"].xb0c325557cbfd6d3(value);
		}
	}

	public byte[] Thumbnail
	{
		get
		{
			return this["Thumbnail"].ToByteArray();
		}
		set
		{
			this["Thumbnail"].xd68e8b1863c583b7(value);
		}
	}

	public string Title
	{
		get
		{
			return this["Title"].ToString();
		}
		set
		{
			this["Title"].xb0c325557cbfd6d3(value);
		}
	}

	public int TotalEditingTime
	{
		get
		{
			return this["TotalEditingTime"].ToInt();
		}
		set
		{
			this["TotalEditingTime"].x711de48f6502f1f4(value);
		}
	}

	public string ContentType
	{
		get
		{
			return this["ContentType"].ToString();
		}
		set
		{
			this["ContentType"].xb0c325557cbfd6d3(value);
		}
	}

	public string ContentStatus
	{
		get
		{
			return this["ContentStatus"].ToString();
		}
		set
		{
			this["ContentStatus"].xb0c325557cbfd6d3(value);
		}
	}

	public int Version
	{
		get
		{
			return this["Version"].ToInt();
		}
		set
		{
			this["Version"].x711de48f6502f1f4(value);
		}
	}

	public int Words
	{
		get
		{
			return this["Words"].ToInt();
		}
		set
		{
			this["Words"].x711de48f6502f1f4(value);
		}
	}

	public object[] HeadingPairs
	{
		get
		{
			return (object[])this["HeadingPairs"].x240f22d025b60fe7;
		}
		set
		{
			this["HeadingPairs"].x240f22d025b60fe7 = value;
		}
	}

	public string[] TitlesOfParts
	{
		get
		{
			return (string[])this["TitlesOfParts"].x240f22d025b60fe7;
		}
		set
		{
			this["TitlesOfParts"].x240f22d025b60fe7 = value;
		}
	}

	internal BuiltInDocumentProperties()
	{
	}

	internal void xcc3f5a7a232023b9(int xbcea506a33cf9111)
	{
		TotalEditingTime = ((xbcea506a33cf9111 > 0 && xbcea506a33cf9111 < int.MaxValue) ? xbcea506a33cf9111 : 0);
	}

	internal void x3c02714b73cc8076()
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				DocumentProperty documentProperty = (DocumentProperty)enumerator.Current;
				switch (documentProperty.Type)
				{
				case PropertyType.String:
					documentProperty.xb0c325557cbfd6d3(documentProperty.ToString().Trim());
					break;
				case PropertyType.StringArray:
				{
					string[] array2 = (string[])documentProperty.x240f22d025b60fe7;
					for (int j = 0; j < array2.Length; j++)
					{
						array2[j] = x1f43ef49a8273aef(array2[j]);
					}
					break;
				}
				case PropertyType.ObjectArray:
				{
					object[] array = (object[])documentProperty.x240f22d025b60fe7;
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i] is string)
						{
							array[i] = x1f43ef49a8273aef((string)array[i]);
						}
					}
					break;
				}
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	private static string x1f43ef49a8273aef(string xbcea506a33cf9111)
	{
		for (int i = 0; i < xbcea506a33cf9111.Length; i++)
		{
			if (xbcea506a33cf9111[i] != ' ')
			{
				return xbcea506a33cf9111;
			}
		}
		return string.Empty;
	}

	static BuiltInDocumentProperties()
	{
		x33d8ad81a0e8b951 = xd51c34d05311eee3.xdb04a310bbb29cff();
		x33d8ad81a0e8b951.Add("Last Author", "LastSavedBy");
		x33d8ad81a0e8b951.Add("Revision Number", "RevisionNumber");
		x33d8ad81a0e8b951.Add("Total Editing Time", "TotalEditingTime");
		x33d8ad81a0e8b951.Add("Last Print Date", "LastPrinted");
		x33d8ad81a0e8b951.Add("Creation Date", "CreateTime");
		x33d8ad81a0e8b951.Add("Last Save Time", "LastSavedTime");
		x33d8ad81a0e8b951.Add("Number of Pages", "Pages");
		x33d8ad81a0e8b951.Add("Number of Words", "Words");
		x33d8ad81a0e8b951.Add("Number of Characters", "Characters");
		x33d8ad81a0e8b951.Add("Application Name", "NameOfApplication");
		x33d8ad81a0e8b951.Add("Number of Bytes", "Bytes");
		x33d8ad81a0e8b951.Add("Number of Lines", "Lines");
		x33d8ad81a0e8b951.Add("Number of Paragraphs", "Paragraphs");
		xbba919600221c03b = xd51c34d05311eee3.xdb04a310bbb29cff();
		xbba919600221c03b.Add("Title", PropertyType.String);
		xbba919600221c03b.Add("Subject", PropertyType.String);
		xbba919600221c03b.Add("Author", PropertyType.String);
		xbba919600221c03b.Add("Keywords", PropertyType.String);
		xbba919600221c03b.Add("Comments", PropertyType.String);
		xbba919600221c03b.Add("Template", PropertyType.String);
		xbba919600221c03b.Add("LastSavedBy", PropertyType.String);
		xbba919600221c03b.Add("RevisionNumber", PropertyType.Number);
		xbba919600221c03b.Add("TotalEditingTime", PropertyType.Number);
		xbba919600221c03b.Add("LastPrinted", PropertyType.DateTime);
		xbba919600221c03b.Add("CreateTime", PropertyType.DateTime);
		xbba919600221c03b.Add("LastSavedTime", PropertyType.DateTime);
		xbba919600221c03b.Add("Pages", PropertyType.Number);
		xbba919600221c03b.Add("Words", PropertyType.Number);
		xbba919600221c03b.Add("Characters", PropertyType.Number);
		xbba919600221c03b.Add("Security", PropertyType.Number);
		xbba919600221c03b.Add("NameOfApplication", PropertyType.String);
		xbba919600221c03b.Add("Category", PropertyType.String);
		xbba919600221c03b.Add("Bytes", PropertyType.Number);
		xbba919600221c03b.Add("Lines", PropertyType.Number);
		xbba919600221c03b.Add("Paragraphs", PropertyType.Number);
		xbba919600221c03b.Add("HeadingPairs", PropertyType.ObjectArray);
		xbba919600221c03b.Add("TitlesOfParts", PropertyType.StringArray);
		xbba919600221c03b.Add("Manager", PropertyType.String);
		xbba919600221c03b.Add("Company", PropertyType.String);
		xbba919600221c03b.Add("LinksUpToDate", PropertyType.Boolean);
		xbba919600221c03b.Add("CharactersWithSpaces", PropertyType.Number);
		xbba919600221c03b.Add("HyperlinkBase", PropertyType.String);
		xbba919600221c03b.Add("Version", PropertyType.Number);
		xbba919600221c03b.Add("ContentStatus", PropertyType.String);
		xbba919600221c03b.Add("ContentType", PropertyType.String);
		xbba919600221c03b.Add("Thumbnail", PropertyType.ByteArray);
	}

	internal override DocumentPropertyCollection xebcf83b00134300b()
	{
		return new BuiltInDocumentProperties();
	}
}
