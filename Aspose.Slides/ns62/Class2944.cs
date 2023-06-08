using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace ns62;

internal class Class2944 : ICollection, IEnumerable, IEnumerable<Class2910>
{
	private SortedList<Enum426, Class2910> sortedList_0;

	public Class2910 this[Enum426 key]
	{
		get
		{
			if (!sortedList_0.ContainsKey(key))
			{
				return null;
			}
			return sortedList_0[key];
		}
		set
		{
			sortedList_0[key] = value;
		}
	}

	public int Count => sortedList_0.Count;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	public Class2944()
	{
		sortedList_0 = new SortedList<Enum426, Class2910>();
	}

	public void CopyTo(Array array, int index)
	{
		((ICollection)sortedList_0).CopyTo(array, index);
	}

	public void Add(Class2910 property)
	{
		sortedList_0.Add(property.Id, property);
	}

	public void method_0(Class2910 property)
	{
		if (!sortedList_0.ContainsKey(property.Id))
		{
			Add(property);
		}
		else
		{
			sortedList_0[property.Id] = property;
		}
	}

	public void Clear()
	{
		sortedList_0.Clear();
	}

	public bool Contains(Enum426 property)
	{
		return sortedList_0.ContainsKey(property);
	}

	IEnumerator<Class2910> IEnumerable<Class2910>.GetEnumerator()
	{
		return sortedList_0.Values.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return sortedList_0.Values.GetEnumerator();
	}

	public void Remove(Enum426 property)
	{
		sortedList_0.Remove(property);
	}

	internal void Read(BinaryReader reader, int length, int numProps)
	{
		long num = reader.BaseStream.Position + length;
		bool flag = false;
		for (int i = 0; i < numProps; i++)
		{
			int num2 = reader.ReadUInt16();
			Enum426 @enum = (Enum426)(num2 & 0x3FFF);
			bool isBid = (num2 & 0x4000) != 0;
			bool flag2 = (num2 & 0x8000) != 0;
			uint num3 = reader.ReadUInt32();
			if (flag2)
			{
				flag = true;
				int num4 = (int)num3;
				switch (@enum)
				{
				case Enum426.const_424:
					Add(new Class2932(@enum, num4));
					break;
				case Enum426.const_420:
					Add(new Class2931(@enum, num4));
					break;
				case Enum426.const_18:
					Add(new Class2933(@enum, num4));
					break;
				case Enum426.const_48:
					Add(new Class2935(@enum, num4));
					break;
				default:
					Add(new Class2930(@enum, num4));
					break;
				case Enum426.const_62:
				case Enum426.const_63:
				case Enum426.const_72:
				case Enum426.const_73:
				case Enum426.const_76:
				case Enum426.const_77:
				case Enum426.const_78:
				case Enum426.const_104:
				case Enum426.const_135:
				case Enum426.const_21:
				case Enum426.const_46:
				case Enum426.const_383:
				case Enum426.const_387:
				case Enum426.const_170:
				case Enum426.const_205:
				case Enum426.const_240:
				case Enum426.const_275:
					Add(new Class2934(@enum, num4));
					break;
				}
				num -= num4;
			}
			else if (!sortedList_0.ContainsKey(@enum))
			{
				switch (@enum)
				{
				case Enum426.const_419:
					Add(new Class2918(num3));
					break;
				case Enum426.const_410:
					Add(new Class2928(num3));
					break;
				case Enum426.const_404:
					Add(new Class2924(num3));
					break;
				case Enum426.const_426:
					Add(new Class2914(num3));
					break;
				case Enum426.const_422:
					Add(new Class2926(num3));
					break;
				case Enum426.const_423:
					Add(new Class2927(num3));
					break;
				case Enum426.const_80:
					Add(new Class2921(num3));
					break;
				case Enum426.const_82:
					Add(new Class2912(num3));
					break;
				case Enum426.const_456:
					Add(new Class2919(num3));
					break;
				case Enum426.const_154:
					Add(new Class2923(num3));
					break;
				case Enum426.const_119:
					Add(new Class2920(num3));
					break;
				case Enum426.const_352:
					Add(new Class2915(num3));
					break;
				case Enum426.const_324:
					Add(new Class2916(num3));
					break;
				case Enum426.const_10:
					Add(new Class2925(num3));
					break;
				case Enum426.const_380:
					Add(new Class2917(num3));
					break;
				default:
					Add(new Class2911(@enum, isBid, num3));
					break;
				case Enum426.const_50:
					Add(new Class2922(num3));
					break;
				case Enum426.const_45:
					Add(new Class2929(num3));
					break;
				}
			}
		}
		if (!flag)
		{
			return;
		}
		foreach (KeyValuePair<Enum426, Class2910> item in sortedList_0)
		{
			if (item.Value is Class2930 @class)
			{
				@class.vmethod_1(reader);
			}
		}
	}

	internal int Write(BinaryWriter writer)
	{
		int num = (int)writer.BaseStream.Position;
		foreach (KeyValuePair<Enum426, Class2910> item in sortedList_0)
		{
			Class2910 value = item.Value;
			value.Write(writer);
		}
		foreach (KeyValuePair<Enum426, Class2910> item2 in sortedList_0)
		{
			if (item2.Value is Class2930 @class)
			{
				@class.vmethod_2(writer);
			}
		}
		return (int)writer.BaseStream.Position - num;
	}

	internal virtual int vmethod_0()
	{
		int num = 0;
		foreach (KeyValuePair<Enum426, Class2910> item in sortedList_0)
		{
			Class2910 value = item.Value;
			num += value.vmethod_0();
		}
		return num;
	}

	internal static bool smethod_0(Enum426 propId)
	{
		switch (propId)
		{
		default:
			return false;
		case Enum426.const_420:
		case Enum426.const_424:
		case Enum426.const_425:
		case Enum426.const_431:
		case Enum426.const_432:
		case Enum426.const_441:
		case Enum426.const_442:
		case Enum426.const_444:
		case Enum426.const_62:
		case Enum426.const_63:
		case Enum426.const_72:
		case Enum426.const_73:
		case Enum426.const_76:
		case Enum426.const_77:
		case Enum426.const_78:
		case Enum426.const_87:
		case Enum426.const_88:
		case Enum426.const_104:
		case Enum426.const_125:
		case Enum426.const_126:
		case Enum426.const_135:
		case Enum426.const_9:
		case Enum426.const_18:
		case Enum426.const_19:
		case Enum426.const_20:
		case Enum426.const_21:
		case Enum426.const_28:
		case Enum426.const_29:
		case Enum426.const_38:
		case Enum426.const_40:
		case Enum426.const_46:
		case Enum426.const_47:
		case Enum426.const_48:
		case Enum426.const_457:
		case Enum426.const_458:
		case Enum426.const_459:
		case Enum426.const_460:
		case Enum426.const_461:
		case Enum426.const_462:
		case Enum426.const_463:
		case Enum426.const_464:
		case Enum426.const_465:
		case Enum426.const_466:
		case Enum426.const_467:
		case Enum426.const_468:
		case Enum426.const_469:
		case Enum426.const_383:
		case Enum426.const_387:
		case Enum426.const_160:
		case Enum426.const_161:
		case Enum426.const_170:
		case Enum426.const_195:
		case Enum426.const_196:
		case Enum426.const_205:
		case Enum426.const_230:
		case Enum426.const_231:
		case Enum426.const_240:
		case Enum426.const_265:
		case Enum426.const_266:
		case Enum426.const_275:
		case Enum426.const_471:
		case Enum426.const_472:
		case Enum426.const_473:
		case Enum426.const_475:
		case Enum426.const_477:
		case Enum426.const_478:
		case Enum426.const_479:
		case Enum426.const_480:
		case Enum426.const_481:
		case Enum426.const_482:
		case Enum426.const_483:
		case Enum426.const_484:
			return true;
		}
	}
}
