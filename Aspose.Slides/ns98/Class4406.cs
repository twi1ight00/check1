using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Threading;

namespace ns98;

internal class Class4406
{
	internal class Class4407
	{
		public static string string_0 = string.Empty;

		public static string string_1 = "..\\TestOut\\";

		public static string string_2 = "test_results.xml";

		public static string string_3 = "test_results_{0}.xml";

		public static int int_0 = 5;
	}

	public static string string_0 = "..\\TestOut\\";

	public static string string_1 = "../../Tests/input/";

	public static string string_2 = "..\\VisualTestOut\\";

	public static string string_3 = "Aspose.Pdf.Kit for .NET 4.3.0.0";

	public static string string_4 = null;

	public static Interface112 interface112_0 = null;

	private static string string_5 = "..\\TestOut\\";

	private static Thread thread_0;

	private static Thread thread_1;

	private static bool bool_0;

	public static string TestOut
	{
		get
		{
			if (interface112_0 != null)
			{
				return interface112_0.TestOut;
			}
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	public static string AdobeVerifierPath
	{
		get
		{
			if (string_4 != null)
			{
				return string_4;
			}
			return "../../Tests/input/";
		}
		set
		{
			string_4 = value;
		}
	}

	public static string smethod_0(string file)
	{
		return Path.GetFullPath($"{string_1}{file}");
	}

	public static string smethod_1(string bug, string ext)
	{
		return Path.GetFullPath($"{string_1}{bug}{ext}");
	}

	public static string smethod_2()
	{
		int num = 1;
		StackTrace stackTrace = new StackTrace();
		StackFrame frame;
		do
		{
			frame = stackTrace.GetFrame(num++);
		}
		while (frame != null && frame.GetMethod().Name.IndexOf("PDFKITNET_") == -1);
		return frame.GetMethod().Name.Replace('_', '-');
	}

	public static string smethod_3(string bug)
	{
		return smethod_1(bug, ".pdf");
	}

	public static string smethod_4()
	{
		return smethod_3(smethod_2());
	}

	public static string smethod_5(bool isTemplate)
	{
		if (isTemplate)
		{
			return smethod_3(smethod_2() + "-{0}");
		}
		return smethod_4();
	}

	public static string smethod_6(int id)
	{
		return string.Format(smethod_5(isTemplate: true), id);
	}

	public static string smethod_7(string bug)
	{
		return smethod_1(bug, ".pfx");
	}

	public static string smethod_8()
	{
		return smethod_7(smethod_2());
	}

	public static string smethod_9(string bug)
	{
		return smethod_1(bug, ".xml");
	}

	public static string smethod_10()
	{
		return smethod_9(smethod_2());
	}

	public static string smethod_11(string bug)
	{
		return smethod_1(bug, ".jpg");
	}

	public static string smethod_12()
	{
		return smethod_11(smethod_2());
	}

	public static string[] smethod_13(string bug)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 1; File.Exists(smethod_1($"{bug}-Template-{i}", ".jpg")); i++)
		{
			arrayList.Add(smethod_1($"{bug}-Template-{i}", ".jpg"));
		}
		return (string[])arrayList.ToArray(typeof(string));
	}

	public static string[] smethod_14()
	{
		return smethod_13(smethod_2());
	}

	public static string smethod_15(string bug, int id, string ext)
	{
		return Path.GetFullPath($"{TestOut}{bug}-{id}{ext}");
	}

	public static string smethod_16(string bug, string ext)
	{
		return Path.GetFullPath($"{TestOut}{bug}{ext}");
	}

	public static string smethod_17(string bug)
	{
		return smethod_16(bug, ".pdf");
	}

	public static string smethod_18(string bug)
	{
		return smethod_16(bug, ".jpg");
	}

	public static string smethod_19(string bug, int id)
	{
		return smethod_15(bug, id, ".jpg");
	}

	public static string smethod_20()
	{
		return smethod_17(smethod_2());
	}

	public static string smethod_21(bool isTemplate)
	{
		if (isTemplate)
		{
			return smethod_17(smethod_2() + "-{0}");
		}
		return smethod_17(smethod_2());
	}

	public static string smethod_22(int id)
	{
		return string.Format(smethod_21(isTemplate: true), id);
	}

	public static string smethod_23(bool isTemplate)
	{
		if (isTemplate)
		{
			return smethod_18(smethod_2() + "-{0}");
		}
		return smethod_18(smethod_2());
	}

	public static string smethod_24()
	{
		return smethod_23(isTemplate: false);
	}

	public static void smethod_25()
	{
		GC.Collect();
		GC.WaitForPendingFinalizers();
	}

	private static void smethod_26(object waitFor)
	{
		Thread.Sleep((int)waitFor);
		if (thread_1.ThreadState != System.Threading.ThreadState.Stopped)
		{
			thread_1.Abort();
		}
		thread_1 = null;
	}

	public static void smethod_27(string sourceImage, Rectangle rectToCrop, string resultImage)
	{
		using Image image = Image.FromFile(sourceImage);
		using Bitmap bitmap = new Bitmap(rectToCrop.Width, rectToCrop.Height);
		using Graphics graphics = Graphics.FromImage(bitmap);
		graphics.DrawImage(image, 0, 0, rectToCrop, GraphicsUnit.Pixel);
		graphics.Flush();
		bitmap.Save(resultImage, ImageFormat.Png);
	}

	internal static MethodBase smethod_28(StackTrace st)
	{
		StackFrame[] array = smethod_29(st);
		if (array == null)
		{
			return null;
		}
		foreach (StackFrame stackFrame in array)
		{
			MethodBase method = stackFrame.GetMethod();
			object[] customAttributes = method.GetCustomAttributes(inherit: true);
			if (customAttributes == null || customAttributes.Length <= 0)
			{
				continue;
			}
			object[] array2 = customAttributes;
			for (int j = 0; j < array2.Length; j++)
			{
				Attribute attribute = (Attribute)array2[j];
				if (attribute.GetType().Name == "TestAttribute")
				{
					return method;
				}
			}
		}
		return null;
	}

	private static StackFrame[] smethod_29(StackTrace st)
	{
		StackFrame[] array = new StackFrame[st.FrameCount];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = st.GetFrame(i);
		}
		return array;
	}
}
