using System;
using System.Collections;
using System.Text;
using ns218;
using ns224;
using ns235;

namespace ns237;

internal class Class6534 : Class6511
{
	private bool bool_0;

	private string string_1;

	private readonly SortedList sortedList_0 = new SortedList();

	private readonly SortedList sortedList_1 = new Class5968();

	internal Class6534(Class6672 context)
		: base(context)
	{
	}

	public override void vmethod_0(Class6679 writer)
	{
		writer.method_29(this);
		writer.method_6();
		if (bool_0)
		{
			writer.method_18("/SigFlags", 2);
		}
		writer.method_8("/Fields", method_3());
		method_1(writer, "/DR");
		writer.method_7();
		writer.method_30();
		foreach (Class6535 value in sortedList_0.GetValueList())
		{
			value.vmethod_0(writer);
		}
	}

	internal void method_1(Class6678 writer, string dictionaryName)
	{
		if (sortedList_1.Count == 0)
		{
			return;
		}
		writer.Write(dictionaryName);
		writer.method_6();
		writer.Write("/Font");
		writer.method_6();
		foreach (object value in sortedList_1.GetValueList())
		{
			Class6511 @class = (Class6511)value;
			writer.method_8($"/{@class.ResourceName}", @class.IndirectReference);
		}
		writer.method_7();
		writer.method_7();
	}

	public void Add(Class6210 item, Class6546 hostPage)
	{
		Add(new Class6538(hostPage, item));
	}

	public void Add(Class6207 item, Class6546 hostPage)
	{
		Add(new Class6536(hostPage, item));
	}

	public void Add(Class6209 item, Class6546 hostPage)
	{
		Add(new Class6537(hostPage, item));
	}

	public void method_2(Class6532 sigAnnotation)
	{
		bool_0 = true;
		string_1 = sigAnnotation.IndirectReference;
	}

	private void Add(Class6535 itemToAdd)
	{
		itemToAdd.HostPage.method_12(itemToAdd);
		if (sortedList_0.ContainsKey(itemToAdd.Name))
		{
			throw new ArgumentException("Names must be unique.");
		}
		sortedList_0.Add(itemToAdd.Name, itemToAdd);
	}

	private string method_3()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("[ ");
		foreach (Class6535 value in sortedList_0.GetValueList())
		{
			stringBuilder.Append(value.IndirectReference);
			stringBuilder.Append(" ");
		}
		if (bool_0)
		{
			stringBuilder.Append(string_1);
			stringBuilder.Append(" ");
		}
		stringBuilder.Append(" ]");
		return stringBuilder.ToString();
	}

	internal Class6527 method_4(Class5999 font)
	{
		Class6527 @class = class6672_0.Resources.method_1(font, isComposite: true, base.Context.Options.FontEmbeddingRule);
		sortedList_1[@class.ResourceName] = @class;
		return @class;
	}
}
