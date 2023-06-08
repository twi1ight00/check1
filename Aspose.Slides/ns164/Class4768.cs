using System.Collections;
using System.Text;

namespace ns164;

internal class Class4768
{
	public class Class4769
	{
		private string string_0;

		private bool bool_0;

		public string Text
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		public bool IsRtl
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

		internal Class4769(string text, bool isRtl)
		{
			string_0 = text;
			bool_0 = isRtl;
		}
	}

	private static bool smethod_0(char c)
	{
		if ((c >= '\u0600' && c <= 'ۿ') || (c >= 'ݐ' && c <= 'ݿ') || (c >= '\u0590' && c <= '\u05ff') || (c >= 'ﹰ' && c <= '\ufeff'))
		{
			return true;
		}
		if (c >= 'ﭐ')
		{
			return c <= '\ufdff';
		}
		return false;
	}

	public static bool smethod_1(string text)
	{
		int num = 0;
		while (true)
		{
			if (num < text.Length)
			{
				char c = text[num];
				if (smethod_0(c))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	private static string smethod_2(Stack rtls)
	{
		StringBuilder stringBuilder = new StringBuilder();
		while (rtls.Count > 0)
		{
			stringBuilder.Append(rtls.Pop());
		}
		return stringBuilder.ToString();
	}

	private static string[] smethod_3(string word)
	{
		ArrayList arrayList = new ArrayList();
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = false;
		for (int i = 0; i < word.Length; i++)
		{
			if (smethod_0(word[i]) == flag)
			{
				stringBuilder.Append(word[i]);
				continue;
			}
			if (stringBuilder.Length > 0)
			{
				arrayList.Add(stringBuilder.ToString());
				stringBuilder.Remove(0, stringBuilder.Length);
			}
			flag = !flag;
			stringBuilder.Append(word[i]);
		}
		if (stringBuilder.Length > 0)
		{
			arrayList.Add(stringBuilder.ToString());
		}
		return (string[])arrayList.ToArray(typeof(string));
	}

	public static ArrayList smethod_4(string text)
	{
		ArrayList arrayList = new ArrayList();
		if (smethod_1(text))
		{
			Stack stack = new Stack();
			string[] array = text.Split(' ');
			for (int i = 0; i < array.Length; i++)
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (smethod_1(array[i]))
				{
					string[] array2 = smethod_3(array[i]);
					if (i != array.Length - 1)
					{
						stringBuilder.Append(" ");
					}
					if (array2.Length > 1)
					{
						foreach (string text2 in array2)
						{
							if (smethod_1(text2))
							{
								for (int num = text2.Length - 1; num >= 0; num--)
								{
									stringBuilder.Append(text2[num]);
								}
								stack.Push(stringBuilder.ToString());
							}
							else
							{
								stringBuilder.Append(text2);
								if (stack.Count > 0)
								{
									arrayList.Add(new Class4769(smethod_2(stack), isRtl: true));
								}
								arrayList.Add(new Class4769(stringBuilder.ToString(), isRtl: false));
							}
							stringBuilder.Remove(0, stringBuilder.Length);
						}
					}
					else
					{
						for (int num2 = array[i].Length - 1; num2 >= 0; num2--)
						{
							stringBuilder.Append(array[i][num2]);
						}
						stack.Push(stringBuilder.ToString());
					}
				}
				else
				{
					stringBuilder.Append(array[i]);
					if (i != array.Length - 1)
					{
						stringBuilder.Append(" ");
					}
					if (stack.Count > 0)
					{
						arrayList.Add(new Class4769(smethod_2(stack), isRtl: true));
					}
					arrayList.Add(new Class4769(stringBuilder.ToString(), isRtl: false));
				}
			}
			if (stack.Count > 0)
			{
				arrayList.Add(new Class4769(smethod_2(stack), isRtl: true));
			}
		}
		else
		{
			arrayList.Add(new Class4769(text, isRtl: false));
		}
		return arrayList;
	}
}
