using System.Collections;

namespace ns154;

internal class Class4710 : CollectionBase
{
	public string this[int index] => (string)base.List[index];

	public void AddComment(string comment)
	{
		base.List.Add(comment);
	}
}
