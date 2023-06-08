using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("d9e9797f-d2e0-4d42-a802-69f41f347df1")]
public interface ITagCollection : ICollection, IEnumerable, IEnumerable<KeyValuePair<string, string>>
{
	string this[string name] { get; set; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }

	int Add(string name, string value);

	void Remove(string name);

	int IndexOfName(string name);

	bool Contains(string name);

	void RemoveAt(int index);

	void Clear();

	string GetValueByIndex(int index);

	string GetNameByIndex(int index);

	string[] GetNamesOfTags();
}
