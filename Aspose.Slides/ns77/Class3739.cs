using System.Text;
using ns73;
using ns78;

namespace ns77;

internal abstract class Class3739 : Class3737
{
	private string string_0;

	private Class3679 class3679_0;

	public override string Text
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("(");
			stringBuilder.Append(string_0);
			if (class3679_0 != null)
			{
				stringBuilder.AppendFormat(": {0}", class3679_0.CSSText);
			}
			stringBuilder.Append(")");
			return stringBuilder.ToString();
		}
	}

	protected Class3739(string feature)
	{
		string_0 = feature;
	}

	protected Class3739(string feature, Class3679 argument)
		: this(feature)
	{
		class3679_0 = argument;
	}

	public static Class3739 smethod_0(string feature)
	{
		return feature.ToLower() switch
		{
			"grid" => new Class3744(feature), 
			"monochrome" => new Class3747(feature), 
			"color-index" => new Class3743(feature), 
			"color" => new Class3742(feature), 
			_ => null, 
		};
	}

	public static Class3739 smethod_1(string feature, Class3679 argument)
	{
		return feature.ToLower() switch
		{
			"width" => new Class3759(feature, argument), 
			"min-width" => new Class3761(feature, argument), 
			"max-width" => new Class3760(feature, argument), 
			"height" => new Class3756(feature, argument), 
			"min-height" => new Class3758(feature, argument), 
			"max-height" => new Class3757(feature, argument), 
			"device-width" => new Class3753(feature, argument), 
			"min-device-width" => new Class3755(feature, argument), 
			"max-device-width" => new Class3754(feature, argument), 
			"device-height" => new Class3750(feature, argument), 
			"min-device-height" => new Class3752(feature, argument), 
			"max-device-height" => new Class3751(feature, argument), 
			"orientation" => new Class3764(feature, argument), 
			"aspect-ratio" => new Class3740(feature, argument), 
			"device-aspect-ratio" => new Class3748(feature, argument), 
			"color" => new Class3742(feature, argument), 
			"min-color" => new Class3746(feature, argument), 
			"max-color" => new Class3745(feature, argument), 
			"color-index" => new Class3743(feature, argument), 
			"monochrome" => new Class3747(feature, argument), 
			"resolution" => new Class3765(feature, argument), 
			"min-resolution" => new Class3763(feature, argument), 
			"max-resolution" => new Class3762(feature, argument), 
			"scan" => new Class3766(feature, argument), 
			"grid" => new Class3744(feature, argument), 
			_ => null, 
		};
	}
}
