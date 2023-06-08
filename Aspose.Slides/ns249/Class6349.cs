using System;
using System.Collections.Generic;
using ns218;
using ns219;
using ns254;

namespace ns249;

internal class Class6349
{
	private Enum806 enum806_0;

	private string string_0 = string.Empty;

	private string string_1 = string.Empty;

	private List<Interface281> list_0;

	public Enum806 CompressionState
	{
		get
		{
			return enum806_0;
		}
		set
		{
			enum806_0 = value;
		}
	}

	public string EmbeddedPictureReference
	{
		get
		{
			if (string_0 == null)
			{
				string_0 = string.Empty;
			}
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public string LinkedPictureReference
	{
		get
		{
			if (string_1 == null)
			{
				string_1 = string.Empty;
			}
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public List<Interface281> Effects
	{
		get
		{
			if (list_0 == null)
			{
				list_0 = new List<Interface281>();
			}
			return list_0;
		}
		set
		{
			list_0 = value;
		}
	}

	public Class6349 Clone()
	{
		Class6349 @class = new Class6349();
		@class.CompressionState = CompressionState;
		@class.EmbeddedPictureReference = EmbeddedPictureReference;
		@class.LinkedPictureReference = LinkedPictureReference;
		return @class;
	}

	public byte[] method_0(Interface293 dataProvider)
	{
		try
		{
			if (Class5964.smethod_20(EmbeddedPictureReference))
			{
				return dataProvider.imethod_1(EmbeddedPictureReference);
			}
			if (Class5964.smethod_20(LinkedPictureReference))
			{
				return dataProvider.imethod_2(LinkedPictureReference);
			}
		}
		catch (Exception)
		{
			return null;
		}
		return null;
	}
}
