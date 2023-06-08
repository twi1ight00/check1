using System;
using System.Collections.Generic;
using System.IO;
using ns60;

namespace ns63;

internal class Class2951 : Interface40
{
	private enum Enum407
	{
		const_0 = 1,
		const_1 = 2,
		const_2 = 4,
		const_3 = 8,
		const_4 = 0x10,
		const_5 = 0x20
	}

	private enum Enum408
	{
		const_0 = 1,
		const_1 = 2,
		const_2 = 4,
		const_3 = 8,
		const_4 = 16,
		const_5 = 32,
		const_6 = 64,
		const_7 = 128,
		const_8 = 256,
		const_9 = 512,
		const_10 = 1024,
		const_11 = 2048,
		const_12 = 12
	}

	private Class2982 class2982_0;

	private Class2623 class2623_0;

	private ushort ushort_0;

	private ushort ushort_1;

	private Class2855 class2855_0;

	private Class2859 class2859_0;

	private Class2845 class2845_0;

	private Class2856 class2856_0;

	private Class2861 class2861_0;

	private Class2853 class2853_0;

	private Class2860 class2860_0;

	private List<Class2863> list_0 = new List<Class2863>();

	private List<Class2846> list_1 = new List<Class2846>();

	private List<Interface45> list_2 = new List<Interface45>();

	public Class2623 ParentContainer => class2623_0;

	public Class2982 ParentList
	{
		get
		{
			return class2982_0;
		}
		set
		{
			class2982_0 = value;
		}
	}

	public bool IsEmpty
	{
		get
		{
			return ushort_0 == 0;
		}
		set
		{
			if (value)
			{
				Clear();
			}
		}
	}

	public bool HaveSlidePersist => method_7(Enum408.const_0);

	public bool HaveOutlinedText => method_7(Enum408.const_3);

	public bool HaveTextHeader => method_7(Enum408.const_1);

	public bool HaveTextData => method_7(Enum408.const_2);

	public bool HaveStyleTextProp
	{
		get
		{
			return method_7(Enum408.const_4);
		}
		set
		{
			if (value != method_7(Enum408.const_4))
			{
				if (value)
				{
					Add(new Class2856(this));
					return;
				}
				method_8(Enum408.const_4, condition: false);
				class2856_0.ParentFrame = null;
				class2856_0.ParentRecord = null;
			}
		}
	}

	public bool HaveMetaCharRecords
	{
		get
		{
			return method_7(Enum408.const_10);
		}
		set
		{
			if (value != method_7(Enum408.const_10) && !value)
			{
				for (int i = 0; i < list_1.Count; i++)
				{
					list_1[i].ParentFrame = null;
					list_1[i].ParentRecord = null;
				}
				method_8(Enum408.const_10, condition: false);
				ushort_1 = 0;
				list_1.Clear();
			}
		}
	}

	public bool HaveTextBookmarks => method_7(Enum408.const_8);

	public bool HaveTextSpecialInfo => method_7(Enum408.const_5);

	public bool HaveInteractiveInfo
	{
		get
		{
			return method_7(Enum408.const_9);
		}
		set
		{
			if (value != method_7(Enum408.const_9) && !value)
			{
				for (int i = 0; i < list_2.Count; i++)
				{
					list_2[i].ParentFrame = null;
					((Class2623)list_2[i]).ParentRecord = null;
				}
				method_8(Enum408.const_9, condition: false);
				list_2.Clear();
			}
		}
	}

	public bool HaveTextRuler => method_7(Enum408.const_7);

	public bool HaveMasterTextProp => method_7(Enum408.const_6);

	public bool HaveSlideNumberMC => method_9(Enum407.const_0);

	public bool HaveDateTimeMC => method_9(Enum407.const_1);

	public bool HaveGenericDateMC => method_9(Enum407.const_2);

	public bool HaveHeaderMC => method_9(Enum407.const_3);

	public bool HaveFooterMC => method_9(Enum407.const_4);

	public bool HaveRTFDateTimeMC => method_9(Enum407.const_5);

	public Class2855 SlidePersist => class2855_0;

	public Class2859 TextHeader => class2859_0;

	public Class2860 TextRuler => class2860_0;

	public string ChildText
	{
		get
		{
			if (HaveTextData)
			{
				if (class2845_0 is Class2858 @class)
				{
					return @class.Text;
				}
				return ((Class2857)class2845_0).Text;
			}
			return null;
		}
	}

	public int ChildTextLength
	{
		get
		{
			if (HaveTextData)
			{
				if (class2845_0 is Class2858 @class)
				{
					return @class.Text.Length;
				}
				return ((Class2857)class2845_0).Text.Length;
			}
			return 0;
		}
	}

	public Class2623 TextData
	{
		get
		{
			if (HaveTextData)
			{
				return class2845_0;
			}
			return null;
		}
	}

	public int OutlineTextRef
	{
		get
		{
			if (HaveOutlinedText)
			{
				return ((Class2854)class2845_0).Index;
			}
			return -1;
		}
	}

	public Class2856 StyleTextProp => class2856_0;

	public Class2861 TextSpecialInfo => class2861_0;

	public List<Class2846> RTFDateTimeMCList => method_4(4117);

	public List<Class2863> TextBookmarks => list_0;

	public List<Class2846> TextMCAtoms => list_1;

	public List<Interface45> InteractiveInfoList => list_2;

	public Class2853 MasterTextProp => class2853_0;

	public List<Class2623> AllRecordsList
	{
		get
		{
			List<Class2623> list = new List<Class2623>();
			if (HaveSlidePersist)
			{
				list.Add(class2855_0);
			}
			if (HaveOutlinedText)
			{
				list.Add(class2845_0);
			}
			if (HaveTextHeader)
			{
				list.Add(class2859_0);
			}
			if (HaveTextData)
			{
				list.Add(class2845_0);
			}
			if (HaveStyleTextProp)
			{
				list.Add(class2856_0);
			}
			if (HaveMetaCharRecords)
			{
				for (int i = 0; i < list_1.Count; i++)
				{
					list.Add(list_1[i]);
				}
			}
			if (HaveTextBookmarks)
			{
				for (int j = 0; j < list_0.Count; j++)
				{
					list.Add(list_0[j]);
				}
			}
			if (HaveTextSpecialInfo)
			{
				list.Add(class2861_0);
			}
			if (HaveInteractiveInfo)
			{
				for (int k = 0; k < list_2.Count; k++)
				{
					list.Add((Class2623)list_2[k]);
				}
			}
			if (HaveTextRuler)
			{
				list.Add(class2860_0);
			}
			if (HaveMasterTextProp)
			{
				list.Add(class2853_0);
			}
			return list;
		}
	}

	public Class2951(Class2982 parentList)
	{
		class2982_0 = parentList;
		class2623_0 = class2982_0.ParentContainer;
	}

	private void Clear()
	{
		if (ushort_0 == 0)
		{
			return;
		}
		List<Class2623> allRecordsList = AllRecordsList;
		foreach (Class2623 item in allRecordsList)
		{
			((Interface45)item).ParentFrame = null;
		}
		class2855_0 = null;
		class2859_0 = null;
		class2845_0 = null;
		class2856_0 = null;
		class2861_0 = null;
		class2853_0 = null;
		class2860_0 = null;
		list_0.Clear();
		list_1.Clear();
		list_2.Clear();
		ushort_0 = 0;
	}

	internal bool method_0(ushort recordType)
	{
		switch (recordType)
		{
		case 3999:
			if (HaveTextHeader || method_7(Enum408.const_12))
			{
				return false;
			}
			break;
		case 3998:
		case 4000:
		case 4008:
			if (method_7(Enum408.const_12))
			{
				return false;
			}
			break;
		case 1011:
			if (ushort_0 != 0)
			{
				return false;
			}
			break;
		}
		return true;
	}

	private void method_1(Class2623 childRecord)
	{
		switch (childRecord.Header.Type)
		{
		case 3998:
			class2845_0 = (Class2845)childRecord;
			method_8(Enum408.const_3, condition: true);
			break;
		case 3999:
			class2859_0 = (Class2859)childRecord;
			method_8(Enum408.const_1, condition: true);
			break;
		case 4001:
			class2856_0 = (Class2856)childRecord;
			method_8(Enum408.const_4, condition: true);
			break;
		case 4002:
			class2853_0 = (Class2853)childRecord;
			method_8(Enum408.const_6, condition: true);
			break;
		case 4006:
			class2860_0 = (Class2860)childRecord;
			method_8(Enum408.const_7, condition: true);
			break;
		case 4007:
			list_0.Add((Class2863)childRecord);
			method_8(Enum408.const_8, condition: true);
			break;
		case 4000:
		case 4008:
			class2845_0 = (Class2845)childRecord;
			method_8(Enum408.const_2, condition: true);
			break;
		case 4010:
			class2861_0 = (Class2861)childRecord;
			method_8(Enum408.const_5, condition: true);
			break;
		case 1011:
			class2855_0 = (Class2855)childRecord;
			method_8(Enum408.const_0, condition: true);
			break;
		default:
			method_8(Enum408.const_11, condition: true);
			throw new NotImplementedException();
		case 4056:
		case 4087:
		case 4088:
		case 4089:
		case 4090:
		case 4117:
			list_1.Add((Class2846)childRecord);
			method_8(Enum408.const_10, condition: true);
			method_10(method_2(childRecord.Header.Type), condition: true);
			break;
		case 4063:
		case 4082:
			list_2.Add((Interface45)childRecord);
			method_8(Enum408.const_9, condition: true);
			break;
		}
	}

	private Enum407 method_2(ushort recordSIDN)
	{
		return recordSIDN switch
		{
			4117 => Enum407.const_5, 
			4087 => Enum407.const_1, 
			4088 => Enum407.const_2, 
			4089 => Enum407.const_3, 
			4090 => Enum407.const_4, 
			4056 => Enum407.const_0, 
			_ => (Enum407)0, 
		};
	}

	public void Add(Interface45 textContainerOrAtom)
	{
		method_1((Class2623)textContainerOrAtom);
		textContainerOrAtom.ParentFrame = this;
		((Class2623)textContainerOrAtom).ParentRecord = class2623_0;
	}

	public void method_3(Class2882 interactiveInfoAtom)
	{
		if (!HaveInteractiveInfo)
		{
			return;
		}
		int num = 0;
		while (true)
		{
			if (num >= list_2.Count)
			{
				return;
			}
			if (list_2[num] is Class2711)
			{
				Class2711 @class = list_2[num] as Class2711;
				if (@class.InteractiveInfoAtom == interactiveInfoAtom)
				{
					break;
				}
			}
			num++;
		}
		if (num + 1 < list_2.Count && list_2[num + 1] is Class2862)
		{
			list_2.RemoveAt(num + 1);
		}
		list_2.RemoveAt(num);
	}

	private List<Class2846> method_4(int recordType)
	{
		List<Class2846> list = new List<Class2846>();
		for (int i = 0; i < list_1.Count; i++)
		{
			if (list_1[i].Header.Type == recordType)
			{
				list.Add(list_1[i]);
			}
		}
		if (list.Count > 0)
		{
			return list;
		}
		return null;
	}

	internal void method_5(BinaryWriter writer)
	{
		List<Class2623> allRecordsList = AllRecordsList;
		for (int i = 0; i < allRecordsList.Count; i++)
		{
			allRecordsList[i].Write(writer);
		}
	}

	internal int method_6()
	{
		int num = 0;
		List<Class2623> allRecordsList = AllRecordsList;
		for (int i = 0; i < allRecordsList.Count; i++)
		{
			num += 8 + allRecordsList[i].vmethod_2();
		}
		return num;
	}

	private bool method_7(Enum408 mask)
	{
		return ((uint)ushort_0 & (uint)mask) != 0;
	}

	private void method_8(Enum408 mask, bool condition)
	{
		ushort_0 &= (ushort)(0xFFFF ^ (ushort)mask);
		if (condition)
		{
			ushort_0 |= (ushort)mask;
		}
	}

	private bool method_9(Enum407 mask)
	{
		return ((uint)ushort_1 & (uint)mask) != 0;
	}

	private void method_10(Enum407 mask, bool condition)
	{
		ushort_1 &= (ushort)(0xFFFF ^ (ushort)mask);
		if (condition)
		{
			ushort_1 |= (ushort)mask;
		}
	}
}
