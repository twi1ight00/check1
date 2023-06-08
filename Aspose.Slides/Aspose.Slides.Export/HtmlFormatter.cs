using System;
using System.Globalization;
using System.IO;
using System.Text;
using ns33;

namespace Aspose.Slides.Export;

public sealed class HtmlFormatter : IHtmlFormatter
{
	private class Class196 : IHtmlFormattingController
	{
		private readonly bool bool_0;

		private readonly string string_0;

		private readonly Uri uri_0;

		private string string_1;

		private string string_2;

		private string string_3;

		private string string_4 = "</div>";

		private string string_5 = "<div class=\"slideTitle\">{0}</div>";

		private string string_6;

		internal Class196(string css, bool showSlideTitle, string docHeader, string docFooter, string slideDivHeader, string slideTitleDiv)
		{
			if (css == null)
			{
				uri_0 = null;
				string_0 = null;
			}
			else
			{
				try
				{
					uri_0 = new Uri(css);
				}
				catch (Exception ex)
				{
					Class1165.smethod_28(ex);
					string_0 = css;
				}
			}
			bool_0 = showSlideTitle;
			string_1 = docHeader;
			string_2 = docFooter;
			string_3 = slideDivHeader;
			string_5 = slideTitleDiv;
		}

		private string method_0(string original)
		{
			if (original == null)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			StringWriter stringWriter = new StringWriter(stringBuilder);
			int length = original.Length;
			for (int i = 0; i < length; i++)
			{
				char c = original[i];
				if ('"' == c)
				{
					stringWriter.Write("&quot;");
				}
				else if ('&' == c)
				{
					stringWriter.Write("&amp;");
				}
				else if ('<' == c)
				{
					stringWriter.Write("&lt;");
				}
				else if ('>' == c)
				{
					stringWriter.Write("&gt;");
				}
				else if ('\u00a0' < c && 'Ā' >= c)
				{
					int num = c;
					stringWriter.Write("&#" + num.ToString(NumberFormatInfo.InvariantInfo) + ";");
				}
				else
				{
					stringWriter.Write(c);
				}
			}
			return stringBuilder.ToString();
		}

		public void WriteDocumentStart(IHtmlGenerator generator, IPresentation presentation)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string arg = "";
			if (string_0 != null)
			{
				arg = $"\n<style type=\"text/css\">\n{string_0}</style>";
			}
			else if (uri_0 != null)
			{
				arg = $"\n<link rel=StyleSheet href=\"{uri_0}\" type=\"text/css\">";
			}
			stringBuilder.AppendFormat(string_1, arg);
			generator.AddHtml(stringBuilder.ToString());
			string_6 = null;
		}

		public void WriteDocumentEnd(IHtmlGenerator generator, IPresentation presentation)
		{
			generator.AddHtml(string.Format(string_2, string_6));
		}

		public void WriteSlideStart(IHtmlGenerator generator, ISlide slide)
		{
			string text = null;
			if (string_6 == null)
			{
				string_6 = "slide" + (generator.SlideIndex + 1);
			}
			foreach (Shape shape in slide.Shapes)
			{
				if (shape is AutoShape && shape.Placeholder != null && (shape.Placeholder.Type == PlaceholderType.Title || shape.Placeholder.Type == PlaceholderType.CenteredTitle))
				{
					text = ((AutoShape)shape).TextFrameInternal.TextInternal;
					break;
				}
			}
			string arg = "";
			if (text != null && bool_0)
			{
				arg = string.Format(string_5, method_0(text));
			}
			string arg2 = ((generator.NextSlideIndex > 0) ? ("slide" + (generator.NextSlideIndex + 1)) : "slideEnd");
			generator.AddHtml(string.Format(string_3, arg, "slide" + (generator.SlideIndex + 1), arg2));
		}

		public void WriteSlideEnd(IHtmlGenerator generator, ISlide slide)
		{
			generator.AddHtml(string_4);
		}

		public void WriteShapeStart(IHtmlGenerator generator, IShape shape)
		{
		}

		public void WriteShapeEnd(IHtmlGenerator generator, IShape shape)
		{
		}
	}

	private readonly IHtmlFormattingController ihtmlFormattingController_0;

	internal IHtmlFormattingController HtmlFormattingController => ihtmlFormattingController_0;

	private HtmlFormatter(IHtmlFormattingController callback)
	{
		ihtmlFormattingController_0 = callback;
	}

	public static HtmlFormatter CreateDocumentFormatter(string css, bool showSlideTitle)
	{
		return new HtmlFormatter(new Class196(css, showSlideTitle, "<!DOCTYPE html>\n<html>\n<head>\n<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">{0}\n</head>\n<body>", "</body>\n</html>", "\n<div class=\"slide\" name=\"slide\" id=\"slide{1}\">{0}", "<div class=\"slideTitle\">{0}</div>"));
	}

	public static HtmlFormatter CreateSlideShowFormatter(string css, bool showSlideTitle)
	{
		return new HtmlFormatter(new Class196(css, showSlideTitle, "<!DOCTYPE html>\n<html>\n<head>\n<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">{0}\n<script type=\"text/javascript\">\nfunction showSlide(slideId)\n{{\nvar items = document.getElementsByName(\"slide\");\nfor(i = 0; i < items.length; i++)\nitems[i].style.display = items[i].id == slideId? \"block\" : \"none\";\n}}\n</script>\n</head>\n<body onload=\"showSlide('slide1')\">", "<div class=\"endShow\" name=\"slide\" id=\"slideEnd\" onclick=\"showSlide('{0}')\">\n<svg class=\"endShowImage\" xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" viewBox=\"0 0 720 540\"><defs></defs><g text-rendering=\"geometricPrecision\" xml:space=\"preserve\" transform=\"scale(0.125,0.125)\">\n<g transform=\"matrix(-0.2, 0, 0, 0.2, 1360, 1080)\">\n<path stroke=\"#000000\" stroke-width=\"40\" fill=\"#808080\" d=\"M3394,1741 C3138,1381,2638,1298,2279,1554 C1919,1810,1836,2310,2092,2669 C2348,3029,2848,3112,3207,2856 C3258,2820,3304,2777,3346,2730 L3768,3099 C3275,3665,2416,3724,1849,3230 C1283,2737,1224,1878,1718,1311 C2211,745,3070,686,3637,1180 C3717,1250,3789,1329,3850,1416 L3850,1416 L4127,1218 L3982,2083 L3117,1938 z \" />\n</g>\n</g>\n</svg>\n</div>\n</body>\n</html>", "\n<div class=\"slide\" name=\"slide\" id=\"{1}\" onclick=\"showSlide('{2}')\">{0}", "<div class=\"slideTitle\">{0}</div>"));
	}

	public static HtmlFormatter CreateCustomFormatter(IHtmlFormattingController formattingController)
	{
		if (formattingController == null)
		{
			throw new ArgumentNullException("formattingController");
		}
		return new HtmlFormatter(formattingController);
	}

	internal void method_0(IHtmlGenerator generator, IPresentation pres)
	{
		ihtmlFormattingController_0.WriteDocumentStart(generator, pres);
	}

	internal void method_1(IHtmlGenerator generator, ISlide slide)
	{
		ihtmlFormattingController_0.WriteSlideStart(generator, slide);
	}

	internal void method_2(IHtmlGenerator generator, ISlide slide)
	{
		ihtmlFormattingController_0.WriteSlideEnd(generator, slide);
	}

	internal void method_3(IHtmlGenerator generator, IPresentation pres)
	{
		ihtmlFormattingController_0.WriteDocumentEnd(generator, pres);
	}
}
