using System;
using System.IO;
using System.Runtime.CompilerServices;
using ns60;

namespace ns63;

internal class Class2967 : ICloneable, Interface40
{
	[Flags]
	public enum Enum443
	{
		flag_0 = 1,
		flag_1 = 2,
		flag_2 = 4
	}

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private bool bool_1;

	[CompilerGenerated]
	private bool bool_2;

	public bool Error
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public bool Clean
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public bool Grammar
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	public Class2967()
	{
		Error = false;
		Clean = false;
		Grammar = false;
	}

	public Class2967(BinaryReader reader)
	{
		method_0(reader);
	}

	public Class2967(bool error, bool clean, bool grammar)
	{
		Error = error;
		Clean = clean;
		Grammar = grammar;
	}

	internal void method_0(BinaryReader reader)
	{
		Enum443 @enum = (Enum443)reader.ReadInt16();
		Error = (@enum & Enum443.flag_0) != 0;
		Clean = (@enum & Enum443.flag_1) != 0;
		Grammar = (@enum & Enum443.flag_2) != 0;
	}

	internal void method_1(BinaryWriter writer)
	{
		Enum443 @enum = (Enum443)0;
		if (Error)
		{
			@enum |= Enum443.flag_0;
		}
		if (Clean)
		{
			@enum |= Enum443.flag_1;
		}
		if (Grammar)
		{
			@enum |= Enum443.flag_2;
		}
		writer.Write((ushort)@enum);
	}

	internal int method_2()
	{
		return 2;
	}

	internal bool method_3(Class2967 spellInfoStruct)
	{
		if (Error != spellInfoStruct.Error)
		{
			return false;
		}
		if (Clean != spellInfoStruct.Clean)
		{
			return false;
		}
		if (Grammar != spellInfoStruct.Grammar)
		{
			return false;
		}
		return true;
	}

	public object Clone()
	{
		return new Class2967(Error, Clean, Grammar);
	}
}
