using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;

namespace Richfit.Garnet.Module.CMS.Application.Services;

public class Html
{
	public bool Create(string template, string path, string htmlname, Dictionary<string, string> dic, ref string message)
	{
		bool result = false;
		string templatepath = HttpContext.Current.Server.MapPath(template);
		string htmlpath = HttpContext.Current.Server.MapPath(path);
		string htmlnamepath = Path.Combine(htmlpath, htmlname);
		Encoding encode = Encoding.UTF8;
		StringBuilder html = new StringBuilder();
		try
		{
			html.Append(File.ReadAllText(templatepath, encode));
		}
		catch (FileNotFoundException ex2)
		{
			message = ex2.Message;
			return false;
		}
		foreach (KeyValuePair<string, string> d in dic)
		{
			html.Replace($"${d.Key}$", d.Value);
		}
		try
		{
			if (!Directory.Exists(htmlpath))
			{
				Directory.CreateDirectory(htmlpath);
			}
			File.WriteAllText(htmlnamepath, html.ToString(), encode);
			result = true;
		}
		catch (IOException ex)
		{
			message = ex.Message;
			return false;
		}
		return result;
	}
}
