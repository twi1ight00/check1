using System;
using System.Collections;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
[Guid("a08571ce-0ebb-45e5-acbf-54ce6ab0b2de")]
public class DocumentProperties : IDocumentProperties
{
	internal string string_0 = "";

	internal string string_1 = "";

	internal string string_2 = "";

	internal string string_3 = "";

	internal string string_4 = "";

	internal DateTime dateTime_0 = DateTime.Now;

	internal DateTime dateTime_1 = DateTime.Now;

	internal DateTime dateTime_2 = DateTime.Now;

	internal string string_5 = "";

	internal string string_6 = "";

	internal string string_7 = "";

	internal string string_8 = "";

	internal int int_0;

	internal string string_9 = "";

	internal string string_10 = "";

	internal string string_11 = "";

	internal string string_12 = "";

	internal bool bool_0;

	internal string string_13 = "";

	internal TimeSpan timeSpan_0 = TimeSpan.Zero;

	internal string string_14 = string.Empty;

	internal string string_15 = string.Empty;

	internal SortedList sortedList_0 = CollectionsUtil.CreateCaseInsensitiveSortedList();

	public string NameOfApplication
	{
		get
		{
			return string_9;
		}
		set
		{
			string_9 = value;
		}
	}

	public string Company
	{
		get
		{
			return string_10;
		}
		set
		{
			string_10 = value;
		}
	}

	public string Manager
	{
		get
		{
			return string_11;
		}
		set
		{
			string_11 = value;
		}
	}

	public string PresentationFormat
	{
		get
		{
			return string_12;
		}
		set
		{
			string_12 = value;
		}
	}

	public bool SharedDoc
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public string ApplicationTemplate
	{
		get
		{
			return string_13;
		}
		set
		{
			string_13 = value;
		}
	}

	public TimeSpan TotalEditingTime
	{
		get
		{
			return timeSpan_0;
		}
		set
		{
			timeSpan_0 = value;
		}
	}

	public string Title
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public string Subject
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public string Author
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public string Keywords
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public string Comments
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	public string Category
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	public DateTime CreatedTime
	{
		get
		{
			return dateTime_0;
		}
		set
		{
			dateTime_0 = value;
		}
	}

	public DateTime LastSavedTime
	{
		get
		{
			return dateTime_1;
		}
		set
		{
			dateTime_1 = value;
		}
	}

	public DateTime LastPrinted
	{
		get
		{
			return dateTime_2;
		}
		set
		{
			dateTime_2 = value;
		}
	}

	public string LastSavedBy
	{
		get
		{
			return string_8;
		}
		set
		{
			string_8 = value;
		}
	}

	public int RevisionNumber
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public string ContentStatus
	{
		get
		{
			return string_6;
		}
		set
		{
			string_6 = value;
		}
	}

	public string ContentType
	{
		get
		{
			return string_7;
		}
		set
		{
			string_7 = value;
		}
	}

	public int Count => sortedList_0.Count;

	public string HyperlinkBase
	{
		get
		{
			return string_14;
		}
		set
		{
			string_14 = value;
		}
	}

	public object this[string name]
	{
		get
		{
			return sortedList_0[name];
		}
		set
		{
			if (!(value is bool) && !(value is int) && !(value is DateTime) && !(value is string) && !(value is float) && !(value is double))
			{
				throw new PptxEditException("Wrong value type of the custom property. The type can be bool, int, DateTime and string.");
			}
			sortedList_0[name] = value;
		}
	}

	public string GetPropertyName(int index)
	{
		if (index < 0 || index >= Count)
		{
			throw new ArgumentOutOfRangeException("index", index, "Property index is out of range.");
		}
		return (string)sortedList_0.GetKey(index);
	}

	public bool Remove(string name)
	{
		if (!sortedList_0.ContainsKey(name))
		{
			return false;
		}
		sortedList_0.Remove(name);
		return true;
	}

	public bool Contains(string name)
	{
		return sortedList_0.ContainsKey(name);
	}
}
