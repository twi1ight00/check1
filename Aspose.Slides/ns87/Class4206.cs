using System.Collections.Generic;
using System.Text;
using ns73;
using ns84;

namespace ns87;

internal class Class4206 : Class4154
{
	public class Class4344
	{
		private readonly string string_0;

		private readonly Enum590? nullable_0;

		public Enum590? GenericVoice => nullable_0;

		public string SpecificVoice => string_0;

		internal Class4344(string specificVoice)
		{
			string_0 = specificVoice;
		}

		internal Class4344(Enum590 genericVoice)
		{
			nullable_0 = genericVoice;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (!nullable_0.HasValue)
			{
				stringBuilder.AppendFormat("'{0}'", string_0);
			}
			else
			{
				stringBuilder.Append(Class4342.smethod_0<Enum590>().imethod_2(nullable_0.Value));
			}
			return stringBuilder.ToString();
		}
	}

	private IList<Class4344> ilist_0;

	public IList<Class4344> VoiceFamilies => ilist_0;

	internal Class4206(Class3679 cssValue)
		: base(cssValue)
	{
		ilist_0 = new List<Class4344>();
		Class3691 @class = cssValue as Class3691;
		foreach (Class3680 item in @class)
		{
			if (item == Class3700.Class3702.class3689_187)
			{
				ilist_0.Add(new Class4344(Enum590.const_0));
			}
			else if (item == Class3700.Class3702.class3689_188)
			{
				ilist_0.Add(new Class4344(Enum590.const_1));
			}
			else if (item == Class3700.Class3702.class3689_189)
			{
				ilist_0.Add(new Class4344(Enum590.const_2));
			}
			else
			{
				ilist_0.Add(new Class4344(item.vmethod_3()));
			}
		}
	}
}
