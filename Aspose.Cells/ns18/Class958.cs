using System;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class958 : Class938
{
	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	private DateTime dateTime_0;

	private DateTime dateTime_1;

	public string Title
	{
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

	public string Subject
	{
		set
		{
			string_3 = value;
		}
	}

	public string Keywords
	{
		set
		{
			string_4 = value;
		}
	}

	public Class958(Class1440 class1440_1)
		: base(class1440_1)
	{
	}

	[SpecialName]
	public DateTime method_4()
	{
		return dateTime_0;
	}

	[SpecialName]
	public void method_5(DateTime dateTime_2)
	{
		dateTime_0 = dateTime_2;
	}

	[SpecialName]
	internal string method_6()
	{
		return string_5;
	}

	[SpecialName]
	internal void method_7(string string_6)
	{
		string_5 = string_6;
	}

	public override void vmethod_1(Class1447 class1447_0)
	{
		class1447_0.method_24(this);
		class1447_0.method_9();
		if (class1440_0.method_7() != null)
		{
			class1440_0.method_7().method_10(this);
			class1447_0.method_22(class1440_0.method_7());
		}
		class1447_0.method_13("/Title", string_1);
		class1447_0.method_13("/Author", string_2);
		class1447_0.method_13("/Subject", string_3);
		class1447_0.method_13("/Keywords", string_4);
		class1447_0.method_13("/Producer", string_5);
		class1447_0.method_15("/CreationDate", dateTime_0);
		class1447_0.method_15("/ModDate", dateTime_1);
		class1447_0.method_10();
		class1447_0.method_25();
	}
}
