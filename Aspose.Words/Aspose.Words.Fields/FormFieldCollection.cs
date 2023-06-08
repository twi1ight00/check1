using System;
using System.Collections;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace Aspose.Words.Fields;

[JavaGenericArguments("Iterable<FormField>")]
public class FormFieldCollection : IEnumerable
{
	private readonly INodeCollection x82b70567a5f68f41;

	public int Count => x82b70567a5f68f41.Count;

	public FormField this[int index] => (FormField)x82b70567a5f68f41[index];

	public FormField this[string bookmarkName]
	{
		get
		{
			x0d299f323d241756.x48501aec8e48c869(bookmarkName, "bookmarkName");
			for (int i = 0; i < Count; i++)
			{
				if (x0d299f323d241756.x90637a473b1ceaaa(this[i].Name, bookmarkName))
				{
					return this[i];
				}
			}
			return null;
		}
	}

	internal FormFieldCollection(Node parent)
	{
		if (parent.IsComposite)
		{
			x82b70567a5f68f41 = ((CompositeNode)parent).GetChildNodes(NodeType.FormField, isDeep: true);
		}
		else
		{
			x82b70567a5f68f41 = x2c229a2f278462bd.x9834ddb0e0bd5996;
		}
	}

	public void Remove(FormField formField)
	{
		if (formField == null)
		{
			throw new ArgumentNullException("formField");
		}
		formField.x8d26c876d3c390f2();
	}

	public void Remove(string formField)
	{
		x0d299f323d241756.x48501aec8e48c869(formField, "formField");
		Remove(this[formField]);
	}

	public void RemoveAt(int index)
	{
		Remove(this[index]);
	}

	public void Clear()
	{
		for (int num = Count; num > 0; num--)
		{
			RemoveAt(0);
		}
	}

	public IEnumerator GetEnumerator()
	{
		return x82b70567a5f68f41.GetEnumerator();
	}
}
