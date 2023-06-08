using System;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("c509302a-0fd1-4187-b1e6-bcb1c3776b4e")]
[ComVisible(true)]
public interface IDocumentProperties
{
	string NameOfApplication { get; set; }

	string Company { get; set; }

	string Manager { get; set; }

	string PresentationFormat { get; set; }

	bool SharedDoc { get; set; }

	string ApplicationTemplate { get; set; }

	TimeSpan TotalEditingTime { get; set; }

	string Title { get; set; }

	string Subject { get; set; }

	string Author { get; set; }

	string Keywords { get; set; }

	string Comments { get; set; }

	string Category { get; set; }

	DateTime CreatedTime { get; set; }

	DateTime LastSavedTime { get; set; }

	DateTime LastPrinted { get; set; }

	string LastSavedBy { get; set; }

	int RevisionNumber { get; set; }

	string ContentStatus { get; set; }

	string ContentType { get; set; }

	string HyperlinkBase { get; set; }

	int Count { get; }

	object this[string name] { get; set; }

	string GetPropertyName(int index);

	bool Remove(string name);

	bool Contains(string name);
}
