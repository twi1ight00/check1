using System;
using System.Collections;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using ns30;
using ns57;

namespace Aspose.Cells.Properties;

/// <summary>
///       A collection of built-in document properties.
///       </summary>
/// <remarks>
///   <p>Provides access to <see cref="T:Aspose.Cells.Properties.DocumentProperty" /> objects by their names (using an indexer) and
///       via a set of typed properties that return values of appropriate types.</p>
/// </remarks>
public class BuiltInDocumentPropertyCollection : DocumentPropertyCollection
{
	private static Hashtable hashtable_0;

	private static ArrayList arrayList_1;

	/// <overloads>Returns a <see cref="T:Aspose.Cells.Properties.DocumentProperty" /> object.</overloads>
	/// <summary>
	///       Returns a <see cref="T:Aspose.Cells.Properties.DocumentProperty" /> object by the name of the property.
	///       </summary>
	/// <remarks>
	///   <p>The string names of the properties correspond to the names of the typed
	///       properties available from <see cref="T:Aspose.Cells.Properties.BuiltInDocumentPropertyCollection" />.</p>
	///   <p>If you request a property that is not present in the document, but the name
	///       of the property is recognized as a valid built-in name, a new <see cref="T:Aspose.Cells.Properties.DocumentProperty" /> 
	///       is created, added to the collection and returned. The newly created property is assigned
	///       a default value (empty string, zero, false or DateTime.MinValue depending on the type
	///       of the built-in property).</p>
	///   <p>If you request a property that is not present in the document and the name
	///       is not recognized as a built-in name, a null is returned.</p>
	/// </remarks>
	/// <param name="name">The case-insensitive name of the property to retrieve.</param>
	public override DocumentProperty this[string name]
	{
		get
		{
			Class1321.smethod_7(name, "name");
			string text = (string)hashtable_0[name];
			if (text == null)
			{
				text = name;
			}
			DocumentProperty documentProperty = base[text];
			if (documentProperty == null)
			{
				Class1634 @class = smethod_1(name);
				if (@class != null)
				{
					documentProperty = Add(@class.enum218_0, @class.int_0, @class.string_0, @class.method_0(), bool_0: false);
				}
			}
			return documentProperty;
		}
	}

	/// <summary>
	///       Gets or sets the name of the document's author.
	///       </summary>
	public string Author
	{
		get
		{
			return this["Author"].ToString();
		}
		set
		{
			this["Author"].Value = value;
		}
	}

	/// <summary>
	///       Represents an estimate of the number of bytes in the document.
	///       </summary>
	public int Bytes
	{
		get
		{
			return this["Bytes"].ToInt();
		}
		set
		{
			this["Bytes"].Value = value;
		}
	}

	/// <summary>
	///       Represents an estimate of the number of characters in the document.
	///       </summary>
	public int Characters
	{
		get
		{
			return this["Characters"].ToInt();
		}
		set
		{
			this["Characters"].Value = value;
		}
	}

	/// <summary>
	///       Represents an estimate of the number of characters (including spaces) in the document.
	///       </summary>
	public int CharactersWithSpaces
	{
		get
		{
			return this["CharactersWithSpaces"].ToInt();
		}
		set
		{
			this["CharactersWithSpaces"].Value = value;
		}
	}

	/// <summary>
	///       Gets or sets the document comments.
	///       </summary>
	public string Comments
	{
		get
		{
			return this["Comments"].ToString();
		}
		set
		{
			this["Comments"].Value = value;
		}
	}

	/// <summary>
	///       Gets or sets the category of the document.
	///       </summary>
	public string Category
	{
		get
		{
			return this["Category"].ToString();
		}
		set
		{
			this["Category"].Value = value;
		}
	}

	/// <summary>
	///       Gets or sets the content type of the document.
	///       </summary>
	public string ContentType
	{
		get
		{
			return this["ContentType"].ToString();
		}
		set
		{
			this["ContentType"].Value = value;
		}
	}

	/// <summary>
	///       Gets or sets the content status of the document.
	///       </summary>
	public string ContentStatus
	{
		get
		{
			return this["ContentStatus"].ToString();
		}
		set
		{
			this["ContentStatus"].Value = value;
		}
	}

	/// <summary>
	///       Gets or sets the company property.
	///       </summary>
	public string Company
	{
		get
		{
			return this["Company"].ToString();
		}
		set
		{
			this["Company"].Value = value;
		}
	}

	/// <summary>
	///       Gets or sets the hyperlinkbase property.
	///       </summary>
	public string HyperlinkBase
	{
		get
		{
			return this["HyperlinkBase"].ToString();
		}
		set
		{
			this["HyperlinkBase"].Value = value;
		}
	}

	/// <summary>
	///       Gets or sets date of the document creation in UTC.
	///       </summary>
	/// <remarks>
	///   <p>Aspose.Cells does not update this property when you modify the document.</p>
	/// </remarks>
	public DateTime CreatedTime
	{
		get
		{
			return this["CreateTime"].ToDateTime();
		}
		set
		{
			this["CreateTime"].Value = value;
		}
	}

	/// <summary>
	///       Gets or sets the document keywords.
	///       </summary>
	public string Keywords
	{
		get
		{
			return this["Keywords"].ToString();
		}
		set
		{
			this["Keywords"].Value = value;
		}
	}

	/// <summary>
	///       Gets or sets the date when the document was last printed in UTC.
	///       </summary>
	/// <remarks>
	///   <p>If the document was never printed, this property will return DateTime.MinValue.</p>
	///   <p>Aspose.Cells does not update this property when you modify the document.</p>
	/// </remarks>
	public DateTime LastPrinted
	{
		get
		{
			return this["LastPrinted"].ToDateTime();
		}
		set
		{
			this["LastPrinted"].Value = value;
		}
	}

	/// <summary>
	///       Gets or sets the name of the last author.
	///       </summary>
	/// <remarks>
	///   <p>Aspose.Cells does not update this property when you modify the document.</p>
	/// </remarks>
	public string LastSavedBy
	{
		get
		{
			return this["LastSavedBy"].ToString();
		}
		set
		{
			this["LastSavedBy"].Value = value;
		}
	}

	/// <summary>
	///       Gets or sets the time of the last save in UTC.
	///       </summary>
	/// <remarks>
	///   <p>Aspose.Cells does not update this property when you modify the document.</p>
	/// </remarks>
	public DateTime LastSavedTime
	{
		get
		{
			return this["LastSavedTime"].ToDateTime();
		}
		set
		{
			this["LastSavedTime"].Value = value;
		}
	}

	/// <summary>
	///       Represents an estimate of the number of lines in the document.
	///       </summary>
	/// <remarks>
	///   <p>Aspose.Cells does not update this property when you modify the document.</p>
	/// </remarks>
	public int Lines
	{
		get
		{
			return this["Lines"].ToInt();
		}
		set
		{
			this["Lines"].Value = value;
		}
	}

	/// <summary>
	///       Gets or sets the manager property.
	///       </summary>
	public string Manager
	{
		get
		{
			return this["Manager"].ToString();
		}
		set
		{
			this["Manager"].Value = value;
		}
	}

	/// <summary>
	///       Gets or sets the name of the application.
	///       </summary>
	public string NameOfApplication
	{
		get
		{
			return this["NameOfApplication"].ToString();
		}
		set
		{
			this["NameOfApplication"].Value = value;
		}
	}

	/// <summary>
	///       Represents an estimate of the number of pages in the document.
	///       </summary>
	public int Pages
	{
		get
		{
			return this["Pages"].ToInt();
		}
		set
		{
			this["Pages"].Value = value;
		}
	}

	/// <summary>
	///       Represents an estimate of the number of paragraphs in the document.
	///       </summary>
	public int Paragraphs
	{
		get
		{
			return this["Paragraphs"].ToInt();
		}
		set
		{
			this["Paragraphs"].Value = value;
		}
	}

	/// <summary>
	///       Gets or sets the document revision number. 
	///       </summary>
	/// <remarks>
	///   <p>Aspose.Cells does not update this property when you modify the document.</p>
	/// </remarks>
	public int RevisionNumber
	{
		get
		{
			return this["RevisionNumber"].ToInt();
		}
		set
		{
			this["RevisionNumber"].Value = value;
		}
	}

	/// <summary>
	///       Gets or sets the subject of the document.
	///       </summary>
	public string Subject
	{
		get
		{
			return this["Subject"].ToString();
		}
		set
		{
			this["Subject"].Value = value;
		}
	}

	/// <summary>
	///       Gets or sets the informational name of the document template.
	///       </summary>
	public string Template
	{
		get
		{
			return this["Template"].ToString();
		}
		set
		{
			this["Template"].Value = value;
		}
	}

	/// <summary>
	///       Gets or sets the title of the document.
	///       </summary>
	public string Title
	{
		get
		{
			return this["Title"].ToString();
		}
		set
		{
			this["Title"].Value = value;
		}
	}

	/// <summary>
	///       Gets or sets the total editing time in minutes.
	///       </summary>
	public double TotalEditingTime
	{
		get
		{
			return this["TotalEditingTime"].ToDouble();
		}
		set
		{
			this["TotalEditingTime"].Value = value;
		}
	}

	/// <summary>
	///       Represents the version number of the application that created the document.
	///       </summary>
	public int Version
	{
		get
		{
			return this["Version"].ToInt();
		}
		set
		{
			this["Version"].Value = value;
		}
	}

	/// <summary>
	///       Represents an estimate of the number of words in the document.
	///       </summary>
	public int Words
	{
		get
		{
			return this["Words"].ToInt();
		}
		set
		{
			this["Words"].Value = value;
		}
	}

	internal BuiltInDocumentPropertyCollection()
	{
	}

	[SpecialName]
	internal int method_0()
	{
		return this["Security"].ToInt();
	}

	[SpecialName]
	internal void method_1(int int_0)
	{
		this["Security"].Value = int_0;
	}

	internal static string smethod_0(int int_0, Enum218 enum218_0)
	{
		int num = 0;
		Class1634 @class;
		while (true)
		{
			if (num < arrayList_1.Count)
			{
				@class = (Class1634)arrayList_1[num];
				if (@class.int_0 == int_0 && @class.enum218_0 == enum218_0)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return @class.string_0;
	}

	private static Class1634 smethod_1(string string_0)
	{
		int num = 0;
		Class1634 @class;
		while (true)
		{
			if (num < arrayList_1.Count)
			{
				@class = (Class1634)arrayList_1[num];
				if (string.Compare(@class.string_0, string_0, ignoreCase: true) == 0)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return @class;
	}

	static BuiltInDocumentPropertyCollection()
	{
		arrayList_1 = new ArrayList();
		arrayList_1.Add(new Class1634(Enum218.const_0, 2, "Title", PropertyType.String));
		arrayList_1.Add(new Class1634(Enum218.const_0, 3, "Subject", PropertyType.String));
		arrayList_1.Add(new Class1634(Enum218.const_0, 4, "Author", PropertyType.String));
		arrayList_1.Add(new Class1634(Enum218.const_0, 5, "Keywords", PropertyType.String));
		arrayList_1.Add(new Class1634(Enum218.const_0, 6, "Comments", PropertyType.String));
		arrayList_1.Add(new Class1634(Enum218.const_0, 7, "Template", PropertyType.String));
		arrayList_1.Add(new Class1634(Enum218.const_0, 8, "LastSavedBy", PropertyType.String));
		arrayList_1.Add(new Class1634(Enum218.const_0, 9, "RevisionNumber", PropertyType.Number));
		arrayList_1.Add(new Class1634(Enum218.const_0, 10, "TotalEditingTime", PropertyType.Double));
		arrayList_1.Add(new Class1634(Enum218.const_0, 11, "LastPrinted", PropertyType.DateTime));
		arrayList_1.Add(new Class1634(Enum218.const_0, 12, "CreateTime", PropertyType.DateTime));
		arrayList_1.Add(new Class1634(Enum218.const_0, 13, "LastSavedTime", PropertyType.DateTime));
		arrayList_1.Add(new Class1634(Enum218.const_0, 14, "Pages", PropertyType.Number));
		arrayList_1.Add(new Class1634(Enum218.const_0, 15, "Words", PropertyType.Number));
		arrayList_1.Add(new Class1634(Enum218.const_0, 16, "Characters", PropertyType.Number));
		arrayList_1.Add(new Class1634(Enum218.const_0, 19, "Security", PropertyType.Number));
		arrayList_1.Add(new Class1634(Enum218.const_0, 18, "NameOfApplication", PropertyType.String));
		arrayList_1.Add(new Class1634(Enum218.const_1, 2, "Category", PropertyType.String));
		arrayList_1.Add(new Class1634(Enum218.const_1, 2, "ContentType", PropertyType.String));
		arrayList_1.Add(new Class1634(Enum218.const_1, 2, "ContentStatus", PropertyType.String));
		arrayList_1.Add(new Class1634(Enum218.const_1, 3, "Format", PropertyType.String));
		arrayList_1.Add(new Class1634(Enum218.const_1, 4, "Bytes", PropertyType.Number));
		arrayList_1.Add(new Class1634(Enum218.const_1, 5, "Lines", PropertyType.Number));
		arrayList_1.Add(new Class1634(Enum218.const_1, 6, "Paragraphs", PropertyType.Number));
		arrayList_1.Add(new Class1634(Enum218.const_1, 7, "Slides", PropertyType.Number));
		arrayList_1.Add(new Class1634(Enum218.const_1, 8, "Notes", PropertyType.Number));
		arrayList_1.Add(new Class1634(Enum218.const_1, 9, "HiddenSlides", PropertyType.Number));
		arrayList_1.Add(new Class1634(Enum218.const_1, 10, "MultimediaClips", PropertyType.Number));
		arrayList_1.Add(new Class1634(Enum218.const_1, 11, "ScaleCrop", PropertyType.Boolean));
		arrayList_1.Add(new Class1634(Enum218.const_1, 14, "Manager", PropertyType.String));
		arrayList_1.Add(new Class1634(Enum218.const_1, 15, "Company", PropertyType.String));
		arrayList_1.Add(new Class1634(Enum218.const_1, 20, "HyperlinkBase", PropertyType.String));
		arrayList_1.Add(new Class1634(Enum218.const_1, 16, "LinksUpToDate", PropertyType.Boolean));
		arrayList_1.Add(new Class1634(Enum218.const_1, 17, "CharactersWithSpaces", PropertyType.Number));
		arrayList_1.Add(new Class1634(Enum218.const_1, 23, "Version", PropertyType.Number));
		hashtable_0 = CollectionsUtil.CreateCaseInsensitiveHashtable();
		hashtable_0.Add("Last Author", "LastSavedBy");
		hashtable_0.Add("Revision Number", "RevisionNumber");
		hashtable_0.Add("Total Editing Time", "TotalEditingTime");
		hashtable_0.Add("Last Print Date", "LastPrinted");
		hashtable_0.Add("Creation Date", "CreateTime");
		hashtable_0.Add("Last Save Time", "LastSavedTime");
		hashtable_0.Add("Number of Pages", "Pages");
		hashtable_0.Add("Number of Words", "Words");
		hashtable_0.Add("Number of Characters", "Characters");
		hashtable_0.Add("Application Name", "NameOfApplication");
		hashtable_0.Add("Number of Bytes", "Bytes");
		hashtable_0.Add("Number of Lines", "Lines");
		hashtable_0.Add("Number of Paragraphs", "Paragraphs");
	}
}
