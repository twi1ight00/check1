using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ns72;
using ns73;
using ns84;

namespace ns76;

internal abstract class Class3716 : IEnumerable, IEnumerable<string>, Interface58
{
	private class Class3721
	{
		public class Class3722 : IDisposable, IEnumerator, IEnumerator<string>
		{
			private IEnumerator<Class3721> ienumerator_0;

			public string Current => ienumerator_0.Current.Value.ToString();

			object IEnumerator.Current => Current;

			public Class3722(IList<Class3721> tuples)
			{
				ienumerator_0 = tuples.GetEnumerator();
			}

			public void Dispose()
			{
				ienumerator_0.Dispose();
			}

			public bool MoveNext()
			{
				return ienumerator_0.MoveNext();
			}

			public void Reset()
			{
				ienumerator_0.Reset();
			}
		}

		private Class3679 class3679_0;

		private int int_0;

		private bool bool_0;

		public Class3679 Value
		{
			get
			{
				return class3679_0;
			}
			set
			{
				class3679_0 = value;
			}
		}

		public int Index
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

		public bool Priority
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
	}

	private List<Class3721> list_0;

	private Class3546<int, int> class3546_0;

	private Class3726 class3726_0;

	public virtual string CSSText
	{
		get
		{
			if (Length == 0)
			{
				return string.Empty;
			}
			Class3721 @class = list_0[0];
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("{0}: {1}", Engine.GetPropertyName(@class.Index), @class.Value);
			if (@class.Priority)
			{
				stringBuilder.Append(" !important");
			}
			stringBuilder.Append(";");
			for (int i = 1; i < Length; i++)
			{
				@class = list_0[i];
				stringBuilder.AppendFormat(" {0}: {1}", Engine.GetPropertyName(@class.Index), @class.Value);
				if (@class.Priority)
				{
					stringBuilder.Append(" !important");
				}
				stringBuilder.Append(";");
			}
			return stringBuilder.ToString();
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				return;
			}
			Class3716 @class = vmethod_0(value);
			if (@class.Length != 0)
			{
				for (int i = 0; i < @class.Length; i++)
				{
					int propertyIndex = @class.method_2(i);
					vmethod_2(propertyIndex, @class.method_1(i), @class.method_3(i));
				}
			}
		}
	}

	public int Length => list_0.Count;

	public string this[int index]
	{
		get
		{
			int num = class3546_0.method_1(index);
			if (num == -1)
			{
				return null;
			}
			return list_0[num].Value.CSSText;
		}
	}

	Interface59 Interface58.ParentRule => ParentRule;

	public virtual Class3707 ParentRule => null;

	protected Class3726 Engine => class3726_0;

	protected Class3716(Class3726 engine)
	{
		class3726_0 = engine;
		int capacity = engine.method_3();
		list_0 = new List<Class3721>(capacity);
		class3546_0 = new Class3546<int, int>(-1);
	}

	public IEnumerator<string> GetEnumerator()
	{
		return new Class3721.Class3722(list_0);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public string imethod_244(string propertyName)
	{
		int key = Engine.method_0(propertyName);
		key = class3546_0.method_1(key);
		if (key == -1)
		{
			return null;
		}
		return list_0[key].Value.CSSText;
	}

	public Class3679 method_0(Enum600 type)
	{
		int key = Engine.method_1(type);
		key = class3546_0.method_1(key);
		if (key == -1)
		{
			return null;
		}
		return list_0[key].Value;
	}

	public Class3679 imethod_245(string propertyName)
	{
		int key = Engine.method_0(propertyName);
		key = class3546_0.method_1(key);
		if (key == -1)
		{
			return null;
		}
		return list_0[key].Value;
	}

	public virtual string imethod_246(string propertyName)
	{
		int key = Engine.method_0(propertyName);
		int num = class3546_0.method_1(key);
		if (num == -1)
		{
			return null;
		}
		string cSSText = list_0[num].Value.CSSText;
		list_0.RemoveAt(num);
		class3546_0.Remove(key);
		return cSSText;
	}

	public string imethod_247(string propertyName)
	{
		int num = Engine.method_0(propertyName);
		if (num == -1)
		{
			return null;
		}
		int num2 = class3546_0.method_1(num);
		if (num2 == -1)
		{
			return string.Empty;
		}
		if (list_0[num2].Priority)
		{
			return "important";
		}
		return string.Empty;
	}

	public virtual void imethod_248(string propertyName, string value, string priority)
	{
		int num = Engine.method_0(propertyName);
		if (num == -1 || string.IsNullOrEmpty(value))
		{
			return;
		}
		priority = priority ?? string.Empty;
		string content = $"{propertyName}: {value} {priority}";
		Class3716 @class = vmethod_0(content);
		if (@class.Length != 0)
		{
			for (int i = 0; i < @class.Length; i++)
			{
				int propertyIndex = @class.method_2(i);
				vmethod_2(propertyIndex, @class.method_1(i), @class.method_3(i));
			}
		}
	}

	protected virtual Class3716 vmethod_0(string content)
	{
		return (Class3716)Engine.imethod_6(content, null);
	}

	public Class3679 method_1(int index)
	{
		return list_0[index].Value;
	}

	public int method_2(int index)
	{
		return list_0[index].Index;
	}

	public bool method_3(int index)
	{
		return list_0[index].Priority;
	}

	public virtual void vmethod_1(Enum600 property, Class3679 value, bool important)
	{
		vmethod_2(class3726_0.method_1(property), value, important);
	}

	public virtual void vmethod_2(int propertyIndex, Class3679 value, bool important)
	{
		Class3721 @class = new Class3721();
		@class.Priority = important;
		@class.Index = propertyIndex;
		@class.Value = value;
		if (!class3546_0.ContainsKey(propertyIndex))
		{
			list_0.Add(@class);
			class3546_0.method_0(propertyIndex, list_0.Count - 1);
		}
		else
		{
			int index = class3546_0.method_1(propertyIndex);
			list_0[index] = @class;
		}
	}

	public void method_4(string propertyName, Class3679 value, bool important)
	{
		vmethod_2(Engine.method_0(propertyName), value, important);
	}

	public override string ToString()
	{
		return CSSText;
	}
}
