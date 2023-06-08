using System.Collections;
using ns46;

namespace Aspose.Cells.DigitalSignatures;

/// <summary>
///        Provides a collection of digital signatures attached to a document. 
///       </summary>
/// <example>
///        The following example shows how to create digital signature
///        <code>
///        [C#]
///        internal void ValidateSignature()
///        {
///           Workbook wb = new Workbook(@"c:\newfile.xlsx");
///           //wb.IsDigitallySigned is true when the workbook is signed already.
///           System.Console.WriteLine(wb.IsDigitallySigned);
///           //get digitalSignature collection from workbook
///           DigitalSignatureCollection dsc = wb.GetDigitalSignature();
///           foreach (DigitalSignature ds in dsc)
///           {
///               System.Console.WriteLine(ds.Comments);
///               System.Console.WriteLine(ds.SignTime);
///               System.Console.WriteLine(ds.IsValid);
///           }
///        }
///        internal void SignSignature()
///        {
///           //dsc is signature collection contains one or more signature needed to sign
///           DigitalSignatureCollection dsc = new DigitalSignatureCollection();
///           //cert must contain private key, it can be contructed from cert file or windows certificate collection.
///           //123456 is password of cert
///           X509Certificate2 cert = new X509Certificate2("c:\\mykey2.pfx", "123456");
///           DigitalSignature ds = new DigitalSignature(cert, "test for sign", DateTime.Now);
///           dsc.Add(ds);
///           Workbook wb = new Workbook();
///           //wb.SetDigitalSignature sign all signatures in dsc
///           wb.SetDigitalSignature(dsc);
///           wb.Save(@"c:\newfile.xlsx");
///        }
///
///        [Visual Basic]
///           Sub ValidateSignature()
///           Dim workbook As Workbook = New Workbook("c:\newfile.xlsx")
///           'Workbook.IsDigitallySigned is true when the workbook is signed already.
///           System.Console.WriteLine(workbook.IsDigitallySigned)
///           'get digitalSignature collection from workbook
///           Dim dsc As DigitalSignatureCollection = workbook.GetDigitalSignature()
///           Dim ds As DigitalSignature
///           For Each ds In dsc
///               System.Console.WriteLine(ds.Comments)
///               System.Console.WriteLine(ds.SignTime)
///               System.Console.WriteLine(ds.IsValid)
///           Next
///        End Sub
///
///        Sub SignSignature()
///           'dsc is signature collection contains one or more signature needed to sign
///           Dim dsc As DigitalSignatureCollection = New DigitalSignatureCollection()
///           'cert must contain private key, it can be contructed from cert file or windows certificate collection.
///           Dim cert As X509Certificate2 = New X509Certificate2("c:\mykey2.pfx", "123456")
///           'create a signature with certificate, sign purpose and sign time
///           Dim ds As DigitalSignature = New DigitalSignature(cert, "test for sign", DateTime.Now)
///           dsc.Add(ds)
///           Dim workbook As Workbook = New Workbook()
///           'workbook.SetDigitalSignature sign all signatures in dsc
///           workbook.SetDigitalSignature(dsc)
///           workbook.Save("c:\newfile.xlsx")
///        End Sub
///        </code></example>
public class DigitalSignatureCollection : IEnumerable
{
	internal ArrayList arrayList_0;

	/// <summary>
	///       The constructor of DigitalSignatureCollection.
	///       </summary>
	public DigitalSignatureCollection()
	{
		arrayList_0 = new ArrayList();
	}

	/// <summary>
	///       Add one signature to DigitalSignatureCollection.
	///       </summary>
	/// <param name="digitalSignature">Digital signature in collection.</param>
	public void Add(DigitalSignature digitalSignature)
	{
		arrayList_0.Add(digitalSignature);
	}

	/// <summary>
	///       Get the enumerator for DigitalSignatureCollection, 
	///       this enumerator allows iteration over the collection
	///       </summary>
	/// <returns>The enumerator to iteration.</returns>
	public IEnumerator GetEnumerator()
	{
		return new Class996(arrayList_0);
	}
}
