using System.Collections;

namespace ns178;

internal class Class5699 : Interface236
{
	public ArrayList arrayList_0 = new ArrayList();

	public int imethod_0()
	{
		return arrayList_0.Count;
	}

	public string imethod_1(int index)
	{
		return ((Struct188)arrayList_0[index]).string_0;
	}

	public string imethod_2(int index)
	{
		return ((Struct188)arrayList_0[index]).string_3;
	}

	public string imethod_3(int index)
	{
		return ((Struct188)arrayList_0[index]).string_1;
	}

	public string imethod_4(int index)
	{
		return ((Struct188)arrayList_0[index]).string_2;
	}

	public string imethod_5(string qName)
	{
		foreach (Struct188 item in arrayList_0)
		{
			if (item.string_0.Equals(qName))
			{
				return item.string_2;
			}
		}
		return null;
	}

	public Interface236 method_0()
	{
		arrayList_0.TrimToSize();
		return this;
	}

	public void method_1(string uri, string localName, string qName, string type, string value)
	{
		Struct188 @struct = default(Struct188);
		@struct.string_1 = uri;
		@struct.string_3 = localName;
		@struct.string_0 = qName;
		@struct.string_2 = value;
		@struct.string_4 = type;
		arrayList_0.Add(@struct);
	}

	public void method_2()
	{
		arrayList_0.Clear();
	}
}
