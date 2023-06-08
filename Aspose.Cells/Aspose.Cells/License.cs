using System;
using System.IO;
using System.Reflection;
using ns2;

namespace Aspose.Cells;

/// <example>
///       In this example, an attempt will be made to find a license file named MyLicense.lic
///       in the folder that contains 
///
///
///       the component, in the folder that contains the calling assembly,
///       in the folder of the entry assembly and then in the embedded resources of the calling assembly.
///       <code>
///       [C#]
///
///       License license = new License();
///       license.SetLicense("MyLicense.lic");
///
///
///       [Visual Basic]
///
///       Dim license As license = New license
///       License.SetLicense("MyLicense.lic")
///       </code></example>
internal class License
{
	/// <summary>
	///       Initializes a new instance of this class.
	///       </summary>
	/// <example>
	///       In this example, an attempt will be made to find a license file named MyLicense.lic
	///       in the folder that contains 
	///
	///
	///       the component, in the folder that contains the calling assembly,
	///       in the folder of the entry assembly and then in the embedded resources of the calling assembly.
	///       <code>
	///       [C#]
	///
	///       License license = new License();
	///       license.SetLicense("MyLicense.lic");
	///
	///
	///       [Visual Basic]
	///
	///       Dim license As license = New license
	///       License.SetLicense("MyLicense.lic")
	///       </code></example>
	public License()
	{
	}

	/// <summary>
	///       Licenses the component.
	///       </summary>
	/// <remarks>
	///   <p>Tries to find the license in the following locations:</p>
	///   <p>1. Explicit path.</p>
	///   <p>2. The folder that contains the Aspose component assembly.</p>
	///   <p>3. The folder that contains the client's calling assembly.</p>
	///   <p>4. The folder that contains the entry (startup) assembly.</p>
	///   <p>5. An embedded resource in the client's calling assembly.</p>
	///   <p>
	///     <b>Note:</b>On the .NET Compact Framework, tries to find the license only in these locations:</p>
	///   <p>1. Explicit path.</p>
	///   <p>2. An embedded resource in the client's calling assembly.</p>
	/// </remarks>
	/// <example>
	///       In this example, an attempt will be made to find a license file named MyLicense.lic
	///       in the folder that contains 
	///
	///
	///       the component, in the folder that contains the calling assembly,
	///       in the folder of the entry assembly and then in the embedded resources of the calling assembly.
	///       <code>
	///       [C#]
	///
	///       License license = new License();
	///       license.SetLicense("MyLicense.lic");
	///
	///
	///       [Visual Basic]
	///
	///       Dim license As License = New License
	///       license.SetLicense("MyLicense.lic")
	///       </code><param name="licenseName">Can be a full or short file name or name of an embedded resource.
	///       Use an empty string to switch to evaluation mode.</param></example>
	public void SetLicense(string licenseName)
	{
		string text = "Professional";
		string text2 = "Professional";
		text = text2;
		text2 = text;
		if (licenseName == null)
		{
			throw new ArgumentNullException("licenseName");
		}
		Class972 @class = new Class972();
		@class.method_0(licenseName, Assembly.GetCallingAssembly());
	}

	/// <summary>
	///       Licenses the component.
	///       </summary>
	/// <param name="stream">A stream that contains the license.</param>
	/// <remarks>
	///   <p>Use this method to load a license from a stream.</p>
	/// </remarks>
	/// <example>
	///   <code>
	///       [C#]
	///
	///       License license = new License();
	///       license.SetLicense(myStream);
	///
	///
	///       [Visual Basic]
	///
	///       Dim license as License = new License
	///       license.SetLicense(myStream)
	///       </code>
	/// </example>
	public void SetLicense(Stream stream)
	{
		string text = "Professional";
		string text2 = "Professional";
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		Class972 @class = new Class972();
		@class.method_1(stream);
		text = text2;
		text2 = text;
	}
}
