using System;
using ns305;

namespace ns81;

internal abstract class Class4029 : Class4021
{
	protected static class Class4067
	{
		public static class Class4068
		{
			public const string string_0 = "form";

			public const string string_1 = "input";

			public const string string_2 = "textarea";

			public const string string_3 = "label";

			public const string string_4 = "fieldset";

			public const string string_5 = "legend";

			public const string string_6 = "select";

			public const string string_7 = "optgroup";

			public const string string_8 = "option";

			public const string string_9 = "button";

			public static bool smethod_0(string tagName)
			{
				tagName = tagName.ToLowerInvariant();
				if (!("form" == tagName) && !("input" == tagName) && !("textarea" == tagName) && !("label" == tagName) && !("fieldset" == tagName) && !("legend" == tagName) && !("select" == tagName) && !("optgroup" == tagName) && !("option" == tagName))
				{
					return "button" == tagName;
				}
				return true;
			}
		}
	}

	protected static class Class4069
	{
		public static class Class4070
		{
			public const string string_0 = "disabled";

			public const string string_1 = "enabled";

			public const string string_2 = "checked";

			public const string string_3 = "checkbox";

			public const string string_4 = "radio";

			public const string string_5 = "number";
		}

		public const string string_0 = "disabled";

		public const string string_1 = "checked";

		public const string string_2 = "type";

		public const string string_3 = "pattern";

		public const string string_4 = "value";

		public const string string_5 = "required";

		public const string string_6 = "min";

		public const string string_7 = "max";

		public const string string_8 = "readonly";

		public const string string_9 = "dir";

		public const string string_10 = "indeterminate";
	}

	protected Class4029(string className)
		: base(className)
	{
	}

	protected static bool smethod_0(Class6981 e)
	{
		return Class4067.Class4068.smethod_0(e.TagName);
	}

	protected static bool smethod_1(Class6981 e, string attribute, string value)
	{
		if (!e.method_34(attribute))
		{
			return false;
		}
		string value2 = e.method_20(attribute);
		if (string.IsNullOrEmpty(value))
		{
			return string.IsNullOrEmpty(value2);
		}
		return value.Equals(value2, StringComparison.OrdinalIgnoreCase);
	}
}
