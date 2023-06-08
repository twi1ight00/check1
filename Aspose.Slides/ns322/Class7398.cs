using System;
using System.Collections;

namespace ns322;

internal abstract class Class7398 : Class7397, IEnumerable
{
	private class Class7439 : IEnumerator
	{
		private Class7398 class7398_0;

		private IEnumerator ienumerator_0;

		private DictionaryEntry dictionaryEntry_0;

		public object Current => dictionaryEntry_0;

		public Class7439(Class7398 dictionary)
		{
			class7398_0 = dictionary;
			ienumerator_0 = dictionary.interface397_0.GetEnumerator();
		}

		public bool MoveNext()
		{
			DictionaryEntry dictionaryEntry;
			do
			{
				if (ienumerator_0.MoveNext())
				{
					dictionaryEntry = (DictionaryEntry)ienumerator_0.Current;
					continue;
				}
				return false;
			}
			while (!((Class7352)dictionaryEntry.Value).Enumerable);
			dictionaryEntry_0 = new DictionaryEntry(dictionaryEntry.Key, ((Class7352)dictionaryEntry.Value).vmethod_1(class7398_0));
			return true;
		}

		public void Reset()
		{
			ienumerator_0.Reset();
		}
	}

	private class Class7440 : IEnumerable
	{
		private class Class7441 : IEnumerator
		{
			private Class7398 class7398_0;

			private IEnumerator ienumerator_0;

			private Class7398 class7398_1;

			private string string_0;

			private bool bool_0;

			public object Current => string_0;

			public Class7441(Class7398 dictionary)
			{
				class7398_0 = dictionary;
				class7398_1 = dictionary.Prototype;
				if (class7398_1 != Class7437.class7437_0 && class7398_1 != Class7433.class7433_0 && class7398_1 != null)
				{
					ienumerator_0 = class7398_1.vmethod_19().GetEnumerator();
				}
				else
				{
					ienumerator_0 = dictionary.interface397_0.GetEnumerator();
				}
				bool_0 = false;
			}

			public bool MoveNext()
			{
				if (class7398_1 != Class7437.class7437_0 && class7398_1 != Class7433.class7433_0 && class7398_1 != null && !bool_0)
				{
					while (ienumerator_0.MoveNext())
					{
						string key = (string)((DictionaryEntry)ienumerator_0.Current).Key;
						if (!class7398_0.vmethod_8(key))
						{
							string_0 = key;
							return true;
						}
					}
					bool_0 = true;
					ienumerator_0 = class7398_0.interface397_0.GetEnumerator();
				}
				DictionaryEntry dictionaryEntry;
				do
				{
					if (ienumerator_0.MoveNext())
					{
						dictionaryEntry = (DictionaryEntry)ienumerator_0.Current;
						continue;
					}
					return false;
				}
				while (!((Class7352)dictionaryEntry.Value).Enumerable || ((Class7352)dictionaryEntry.Value).Owner != class7398_0);
				string_0 = (string)dictionaryEntry.Key;
				return true;
			}

			public void Reset()
			{
				if (class7398_1 != Class7437.class7437_0 && class7398_1 != Class7433.class7433_0 && class7398_1 != null)
				{
					ienumerator_0 = class7398_1.vmethod_19().GetEnumerator();
					ienumerator_0.Reset();
					bool_0 = false;
				}
				else
				{
					ienumerator_0 = class7398_0.interface397_0.GetEnumerator();
				}
				class7398_0.interface397_0.GetEnumerator().Reset();
			}
		}

		private Class7398 class7398_0;

		public IEnumerator GetEnumerator()
		{
			return new Class7441(class7398_0);
		}

		public Class7440(Class7398 dictionary)
		{
			class7398_0 = dictionary;
		}
	}

	private class Class7442 : IEnumerable
	{
		private class Class7443 : IEnumerator
		{
			private Class7398 class7398_0;

			private IEnumerator ienumerator_0;

			private Class7397 class7397_0;

			public object Current => class7397_0;

			public Class7443(Class7398 dictionary)
			{
				class7398_0 = dictionary;
				ienumerator_0 = dictionary.interface397_0.Values.GetEnumerator();
			}

			public bool MoveNext()
			{
				Class7352 @class;
				do
				{
					if (ienumerator_0.MoveNext())
					{
						@class = (Class7352)ienumerator_0.Current;
						continue;
					}
					return false;
				}
				while (!@class.Enumerable);
				class7397_0 = @class.vmethod_1(class7398_0);
				return true;
			}

			public void Reset()
			{
				ienumerator_0.Reset();
			}
		}

		private Class7398 class7398_0;

		public IEnumerator GetEnumerator()
		{
			return new Class7443(class7398_0);
		}

		public Class7442(Class7398 dictionary)
		{
			class7398_0 = dictionary;
		}
	}

	private bool bool_0;

	private bool bool_1;

	private int int_0;

	private Class7398 class7398_0;

	protected internal Interface397 interface397_0 = new Class7690();

	public bool Extensible
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

	public bool HasChildren => bool_1;

	public virtual int Length
	{
		get
		{
			return int_0;
		}
		set
		{
		}
	}

	private Class7398 Prototype
	{
		get
		{
			return class7398_0;
		}
		set
		{
			class7398_0 = value;
		}
	}

	public virtual Class7397 this[Class7397 key]
	{
		get
		{
			return this[key.ToString()];
		}
		set
		{
			this[key.ToString()] = value;
		}
	}

	public virtual Class7397 this[string index]
	{
		get
		{
			Class7352 @class = vmethod_11(index);
			if (@class == null)
			{
				return Class7437.class7437_0;
			}
			return @class.vmethod_1(this);
		}
		set
		{
			Class7352 @class = vmethod_11(index);
			if (@class != null && (@class.Owner == this || @class.DescriptorType != 0))
			{
				@class.vmethod_2(this, value);
			}
			else
			{
				vmethod_18(new Class7359(this, index, value));
			}
		}
	}

	public override object Value
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public virtual bool vmethod_7(string key)
	{
		Class7398 @class = this;
		do
		{
			if (!@class.vmethod_8(key))
			{
				@class = @class.Prototype;
				continue;
			}
			return true;
		}
		while (@class != Class7437.class7437_0 && @class != Class7433.class7433_0);
		return false;
	}

	public virtual bool vmethod_8(string key)
	{
		if (interface397_0.imethod_3(key, out var descriptor))
		{
			return descriptor.Owner == this;
		}
		return false;
	}

	public virtual bool vmethod_9(Class7397 key)
	{
		return vmethod_7(key.ToString());
	}

	public virtual bool vmethod_10(Class7397 key)
	{
		return vmethod_8(key.ToString());
	}

	public virtual Class7352 vmethod_11(string index)
	{
		if (interface397_0.imethod_3(index, out var descriptor))
		{
			if (!descriptor.isDeleted)
			{
				return descriptor;
			}
			interface397_0.imethod_1(index);
		}
		if ((descriptor = Prototype.vmethod_11(index)) != null)
		{
			interface397_0.imethod_0(index, descriptor);
		}
		return descriptor;
	}

	public virtual bool vmethod_12(Class7397 index, out Class7352 result)
	{
		return vmethod_13(index.ToString(), out result);
	}

	public virtual bool vmethod_13(string index, out Class7352 result)
	{
		result = vmethod_11(index);
		return result != null;
	}

	public virtual bool vmethod_14(Class7397 index, out Class7397 result)
	{
		return vmethod_15(index.ToString(), out result);
	}

	public virtual bool vmethod_15(string index, out Class7397 result)
	{
		Class7352 @class = vmethod_11(index);
		if (@class == null)
		{
			result = Class7437.class7437_0;
			return false;
		}
		result = @class.vmethod_1(this);
		return true;
	}

	public virtual void vmethod_16(Class7397 key)
	{
		vmethod_17(key.ToString());
	}

	public virtual void vmethod_17(string index)
	{
		Class7352 result = null;
		if (vmethod_13(index, out result) && result.Owner == this)
		{
			if (!result.Configurable)
			{
				throw new Exception89("Property " + index + " isn't configurable");
			}
			interface397_0.imethod_1(index);
			result.vmethod_0();
			int_0--;
		}
	}

	public void method_0(string key, Class7397 value, Enum988 propertyAttributes)
	{
		Class7359 @class = new Class7359(this, key, value);
		@class.Writable = (propertyAttributes & Enum988.flag_1) == 0;
		@class.Enumerable = (propertyAttributes & Enum988.flag_2) == 0;
		vmethod_18(@class);
	}

	public void method_1(string key, Class7397 value)
	{
		vmethod_18(new Class7359(this, key, value));
	}

	public virtual void vmethod_18(Class7352 currentDescriptor)
	{
		string name = currentDescriptor.Name;
		if (interface397_0.imethod_3(name, out var descriptor) && descriptor.Owner == this)
		{
			switch (descriptor.DescriptorType)
			{
			case Enum984.const_0:
				switch (currentDescriptor.DescriptorType)
				{
				case Enum984.const_0:
					interface397_0.imethod_2(name).vmethod_2(this, currentDescriptor.vmethod_1(this));
					break;
				case Enum984.const_1:
					interface397_0.imethod_1(name);
					interface397_0.imethod_0(name, currentDescriptor);
					break;
				}
				break;
			case Enum984.const_1:
			{
				Class7353 @class = (Class7353)descriptor;
				if (currentDescriptor.DescriptorType == Enum984.const_1)
				{
					@class.GetFunction = ((((Class7353)currentDescriptor).GetFunction != null) ? ((Class7353)currentDescriptor).GetFunction : @class.GetFunction);
					@class.SetFunction = ((((Class7353)currentDescriptor).SetFunction != null) ? ((Class7353)currentDescriptor).SetFunction : @class.SetFunction);
				}
				else
				{
					@class.vmethod_2(this, currentDescriptor.vmethod_1(this));
				}
				break;
			}
			}
		}
		else
		{
			descriptor?.Owner.method_2(descriptor.Name);
			interface397_0.imethod_0(name, currentDescriptor);
			int_0++;
		}
	}

	private void method_2(string name)
	{
		if (interface397_0.imethod_3(name, out var descriptor) && descriptor.Owner == this)
		{
			interface397_0.imethod_0(name, descriptor.Clone());
			descriptor.vmethod_0();
		}
	}

	public IEnumerator GetEnumerator()
	{
		return new Class7439(this);
	}

	public virtual IEnumerable vmethod_19()
	{
		return new Class7440(this);
	}

	public virtual IEnumerable vmethod_20()
	{
		return new Class7442(this);
	}

	public virtual Class7397 vmethod_21(Class7398 target, Class7397[] parameters)
	{
		if (parameters.Length <= 0)
		{
			throw new ArgumentException("propertyName");
		}
		if (!target.vmethod_8(parameters[0].ToString()))
		{
			return vmethod_21(target.Prototype, parameters);
		}
		if (!(target.interface397_0.imethod_2(parameters[0].ToString()) is Class7353 @class))
		{
			return Class7437.class7437_0;
		}
		if (@class.GetFunction == null)
		{
			return Class7437.class7437_0;
		}
		return @class.GetFunction;
	}

	public virtual Class7397 vmethod_22(Class7398 target, Class7397[] parameters)
	{
		if (parameters.Length <= 0)
		{
			throw new ArgumentException("propertyName");
		}
		if (!target.vmethod_8(parameters[0].ToString()))
		{
			return vmethod_22(target.Prototype, parameters);
		}
		if (!(target.interface397_0.imethod_2(parameters[0].ToString()) is Class7353 @class))
		{
			return Class7437.class7437_0;
		}
		if (@class.SetFunction == null)
		{
			return Class7437.class7437_0;
		}
		return @class.SetFunction;
	}

	public bool method_3(Class7398 target)
	{
		if (target == null)
		{
			return false;
		}
		if (target != Class7437.class7437_0 && target != Class7433.class7433_0)
		{
			if (target.Prototype == this)
			{
				return true;
			}
			return method_3(target.Prototype);
		}
		return false;
	}

	public Class7398()
	{
		Extensible = true;
		Prototype = Class7433.class7433_0;
	}

	public Class7398(Class7398 prototype)
	{
		Prototype = prototype;
		Extensible = true;
		prototype.bool_1 = true;
	}
}
