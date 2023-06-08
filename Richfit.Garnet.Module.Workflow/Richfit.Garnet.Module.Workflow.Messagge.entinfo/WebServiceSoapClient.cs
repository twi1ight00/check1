using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Richfit.Garnet.Module.Workflow.Messagge.entinfo;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class WebServiceSoapClient : ClientBase<WebServiceSoap>, WebServiceSoap
{
	public WebServiceSoapClient()
	{
	}

	public WebServiceSoapClient(string endpointConfigurationName)
		: base(endpointConfigurationName)
	{
	}

	public WebServiceSoapClient(string endpointConfigurationName, string remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public WebServiceSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public WebServiceSoapClient(Binding binding, EndpointAddress remoteAddress)
		: base(binding, remoteAddress)
	{
	}

	public string SendSMS(string sn, string pwd, string mobile, string content)
	{
		return base.Channel.SendSMS(sn, pwd, mobile, content);
	}

	public Task<string> SendSMSAsync(string sn, string pwd, string mobile, string content)
	{
		return base.Channel.SendSMSAsync(sn, pwd, mobile, content);
	}

	public string SendSMS_R(string sn, string pwd, string mobile, string content, string rrid)
	{
		return base.Channel.SendSMS_R(sn, pwd, mobile, content, rrid);
	}

	public Task<string> SendSMS_RAsync(string sn, string pwd, string mobile, string content, string rrid)
	{
		return base.Channel.SendSMS_RAsync(sn, pwd, mobile, content, rrid);
	}

	public string SendSMSEx(string sn, string pwd, string mobile, string content, string subcode)
	{
		return base.Channel.SendSMSEx(sn, pwd, mobile, content, subcode);
	}

	public Task<string> SendSMSExAsync(string sn, string pwd, string mobile, string content, string subcode)
	{
		return base.Channel.SendSMSExAsync(sn, pwd, mobile, content, subcode);
	}

	public string SendSMSEx_R(string sn, string pwd, string mobile, string content, string subcode, string rrid)
	{
		return base.Channel.SendSMSEx_R(sn, pwd, mobile, content, subcode, rrid);
	}

	public Task<string> SendSMSEx_RAsync(string sn, string pwd, string mobile, string content, string subcode, string rrid)
	{
		return base.Channel.SendSMSEx_RAsync(sn, pwd, mobile, content, subcode, rrid);
	}

	public string UnRegister(string sn, string pwd)
	{
		return base.Channel.UnRegister(sn, pwd);
	}

	public Task<string> UnRegisterAsync(string sn, string pwd)
	{
		return base.Channel.UnRegisterAsync(sn, pwd);
	}

	public string ChargUp(string sn, string pwd, string cardno, string cardpwd)
	{
		return base.Channel.ChargUp(sn, pwd, cardno, cardpwd);
	}

	public Task<string> ChargUpAsync(string sn, string pwd, string cardno, string cardpwd)
	{
		return base.Channel.ChargUpAsync(sn, pwd, cardno, cardpwd);
	}

	public string GetBalance(string sn, string pwd)
	{
		return base.Channel.GetBalance(sn, pwd);
	}

	public Task<string> GetBalanceAsync(string sn, string pwd)
	{
		return base.Channel.GetBalanceAsync(sn, pwd);
	}

	public string GetStatus(string sn, string pwd)
	{
		return base.Channel.GetStatus(sn, pwd);
	}

	public Task<string> GetStatusAsync(string sn, string pwd)
	{
		return base.Channel.GetStatusAsync(sn, pwd);
	}

	public string GetCode(string sn, string pwd)
	{
		return base.Channel.GetCode(sn, pwd);
	}

	public Task<string> GetCodeAsync(string sn, string pwd)
	{
		return base.Channel.GetCodeAsync(sn, pwd);
	}

	public string UDPPwd(string sn, string pwd, string newpwd)
	{
		return base.Channel.UDPPwd(sn, pwd, newpwd);
	}

	public Task<string> UDPPwdAsync(string sn, string pwd, string newpwd)
	{
		return base.Channel.UDPPwdAsync(sn, pwd, newpwd);
	}

	public string UDPSIGN(string sn, string pwd, string sign)
	{
		return base.Channel.UDPSIGN(sn, pwd, sign);
	}

	public Task<string> UDPSIGNAsync(string sn, string pwd, string sign)
	{
		return base.Channel.UDPSIGNAsync(sn, pwd, sign);
	}

	public string UDPSIGNEX(string sn, string pwd, string subcode, string sign, string comName)
	{
		return base.Channel.UDPSIGNEX(sn, pwd, subcode, sign, comName);
	}

	public Task<string> UDPSIGNEXAsync(string sn, string pwd, string subcode, string sign, string comName)
	{
		return base.Channel.UDPSIGNEXAsync(sn, pwd, subcode, sign, comName);
	}

	public MOBody[] RECSMS(string sn, string pwd)
	{
		return base.Channel.RECSMS(sn, pwd);
	}

	public Task<MOBody[]> RECSMSAsync(string sn, string pwd)
	{
		return base.Channel.RECSMSAsync(sn, pwd);
	}

	public MOBody[] RECSMSEx(string sn, string pwd, string subcode)
	{
		return base.Channel.RECSMSEx(sn, pwd, subcode);
	}

	public Task<MOBody[]> RECSMSExAsync(string sn, string pwd, string subcode)
	{
		return base.Channel.RECSMSExAsync(sn, pwd, subcode);
	}

	public MOBody[] RECSMS_UTF8(string sn, string pwd)
	{
		return base.Channel.RECSMS_UTF8(sn, pwd);
	}

	public Task<MOBody[]> RECSMS_UTF8Async(string sn, string pwd)
	{
		return base.Channel.RECSMS_UTF8Async(sn, pwd);
	}

	public MOBody[] RECSMSEx_UTF8(string sn, string pwd, string subcode)
	{
		return base.Channel.RECSMSEx_UTF8(sn, pwd, subcode);
	}

	public Task<MOBody[]> RECSMSEx_UTF8Async(string sn, string pwd, string subcode)
	{
		return base.Channel.RECSMSEx_UTF8Async(sn, pwd, subcode);
	}

	public string Register(string sn, string pwd, string province, string city, string trade, string entname, string linkman, string phone, string mobile, string email, string fax, string address, string postcode, string sign)
	{
		return base.Channel.Register(sn, pwd, province, city, trade, entname, linkman, phone, mobile, email, fax, address, postcode, sign);
	}

	public Task<string> RegisterAsync(string sn, string pwd, string province, string city, string trade, string entname, string linkman, string phone, string mobile, string email, string fax, string address, string postcode, string sign)
	{
		return base.Channel.RegisterAsync(sn, pwd, province, city, trade, entname, linkman, phone, mobile, email, fax, address, postcode, sign);
	}

	public string GetFlag(string sn, string pwd)
	{
		return base.Channel.GetFlag(sn, pwd);
	}

	public Task<string> GetFlagAsync(string sn, string pwd)
	{
		return base.Channel.GetFlagAsync(sn, pwd);
	}

	public string SMSTest(string sn, string pwd, string mobile)
	{
		return base.Channel.SMSTest(sn, pwd, mobile);
	}

	public Task<string> SMSTestAsync(string sn, string pwd, string mobile)
	{
		return base.Channel.SMSTestAsync(sn, pwd, mobile);
	}

	public string TestCode(string content, string code, string type)
	{
		return base.Channel.TestCode(content, code, type);
	}

	public Task<string> TestCodeAsync(string content, string code, string type)
	{
		return base.Channel.TestCodeAsync(content, code, type);
	}

	public RegistryInfo GetAllInfo(string sn, string pwd)
	{
		return base.Channel.GetAllInfo(sn, pwd);
	}

	public Task<RegistryInfo> GetAllInfoAsync(string sn, string pwd)
	{
		return base.Channel.GetAllInfoAsync(sn, pwd);
	}

	public RegistryInfo2 GetAllInfo2(string sn, string pwd, string ver, string oem)
	{
		return base.Channel.GetAllInfo2(sn, pwd, ver, oem);
	}

	public Task<RegistryInfo2> GetAllInfo2Async(string sn, string pwd, string ver, string oem)
	{
		return base.Channel.GetAllInfo2Async(sn, pwd, ver, oem);
	}

	public double SetGaoDuan(string sn, string pwd, string gd)
	{
		return base.Channel.SetGaoDuan(sn, pwd, gd);
	}

	public Task<double> SetGaoDuanAsync(string sn, string pwd, string gd)
	{
		return base.Channel.SetGaoDuanAsync(sn, pwd, gd);
	}

	public string GetGaoDuan(string sn, string pwd)
	{
		return base.Channel.GetGaoDuan(sn, pwd);
	}

	public Task<string> GetGaoDuanAsync(string sn, string pwd)
	{
		return base.Channel.GetGaoDuanAsync(sn, pwd);
	}

	public string mt(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid)
	{
		return base.Channel.mt(sn, pwd, mobile, content, ext, stime, rrid);
	}

	public Task<string> mtAsync(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid)
	{
		return base.Channel.mtAsync(sn, pwd, mobile, content, ext, stime, rrid);
	}

	public string mdSmsSend(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid)
	{
		return base.Channel.mdSmsSend(sn, pwd, mobile, content, ext, stime, rrid);
	}

	public Task<string> mdSmsSendAsync(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid)
	{
		return base.Channel.mdSmsSendAsync(sn, pwd, mobile, content, ext, stime, rrid);
	}

	public string mdSmsSend_u(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid)
	{
		return base.Channel.mdSmsSend_u(sn, pwd, mobile, content, ext, stime, rrid);
	}

	public Task<string> mdSmsSend_uAsync(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid)
	{
		return base.Channel.mdSmsSend_uAsync(sn, pwd, mobile, content, ext, stime, rrid);
	}

	public string mdSmsSend_DES(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid)
	{
		return base.Channel.mdSmsSend_DES(sn, pwd, mobile, content, ext, stime, rrid);
	}

	public Task<string> mdSmsSend_DESAsync(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid)
	{
		return base.Channel.mdSmsSend_DESAsync(sn, pwd, mobile, content, ext, stime, rrid);
	}

	public string mdSmsSend_AES(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid)
	{
		return base.Channel.mdSmsSend_AES(sn, pwd, mobile, content, ext, stime, rrid);
	}

	public Task<string> mdSmsSend_AESAsync(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid)
	{
		return base.Channel.mdSmsSend_AESAsync(sn, pwd, mobile, content, ext, stime, rrid);
	}

	public string mdSmsSend_g(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid)
	{
		return base.Channel.mdSmsSend_g(sn, pwd, mobile, content, ext, stime, rrid);
	}

	public Task<string> mdSmsSend_gAsync(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid)
	{
		return base.Channel.mdSmsSend_gAsync(sn, pwd, mobile, content, ext, stime, rrid);
	}

	public string mo(string sn, string pwd)
	{
		return base.Channel.mo(sn, pwd);
	}

	public Task<string> moAsync(string sn, string pwd)
	{
		return base.Channel.moAsync(sn, pwd);
	}

	public string mo2(string sn, string pwd, int maxID)
	{
		return base.Channel.mo2(sn, pwd, maxID);
	}

	public Task<string> mo2Async(string sn, string pwd, int maxID)
	{
		return base.Channel.mo2Async(sn, pwd, maxID);
	}

	public string report(string sn, string pwd, long maxid)
	{
		return base.Channel.report(sn, pwd, maxid);
	}

	public Task<string> reportAsync(string sn, string pwd, long maxid)
	{
		return base.Channel.reportAsync(sn, pwd, maxid);
	}

	public string report2(string sn, string pwd, long maxid, string rrid)
	{
		return base.Channel.report2(sn, pwd, maxid, rrid);
	}

	public Task<string> report2Async(string sn, string pwd, long maxid, string rrid)
	{
		return base.Channel.report2Async(sn, pwd, maxid, rrid);
	}

	public string report2DES(string sn, string pwd, long maxid, string rrid)
	{
		return base.Channel.report2DES(sn, pwd, maxid, rrid);
	}

	public Task<string> report2DESAsync(string sn, string pwd, long maxid, string rrid)
	{
		return base.Channel.report2DESAsync(sn, pwd, maxid, rrid);
	}

	public string msgid(string sn, string pwd)
	{
		return base.Channel.msgid(sn, pwd);
	}

	public Task<string> msgidAsync(string sn, string pwd)
	{
		return base.Channel.msgidAsync(sn, pwd);
	}

	public string balance(string sn, string pwd)
	{
		return base.Channel.balance(sn, pwd);
	}

	public Task<string> balanceAsync(string sn, string pwd)
	{
		return base.Channel.balanceAsync(sn, pwd);
	}

	public string gxmt(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid)
	{
		return base.Channel.gxmt(sn, pwd, mobile, content, ext, stime, rrid);
	}

	public Task<string> gxmtAsync(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid)
	{
		return base.Channel.gxmtAsync(sn, pwd, mobile, content, ext, stime, rrid);
	}

	public string fileMT(string sn, string pwd, string fname, string rrid, int sort, int total, int ftype, string content)
	{
		return base.Channel.fileMT(sn, pwd, fname, rrid, sort, total, ftype, content);
	}

	public Task<string> fileMTAsync(string sn, string pwd, string fname, string rrid, int sort, int total, int ftype, string content)
	{
		return base.Channel.fileMTAsync(sn, pwd, fname, rrid, sort, total, ftype, content);
	}

	public string mmsFileMT(string sn, string pwd, string rrid, string content)
	{
		return base.Channel.mmsFileMT(sn, pwd, rrid, content);
	}

	public Task<string> mmsFileMTAsync(string sn, string pwd, string rrid, string content)
	{
		return base.Channel.mmsFileMTAsync(sn, pwd, rrid, content);
	}

	public string mdMmsSend(string sn, string pwd, string title, string mobile, string content, string stime)
	{
		return base.Channel.mdMmsSend(sn, pwd, title, mobile, content, stime);
	}

	public Task<string> mdMmsSendAsync(string sn, string pwd, string title, string mobile, string content, string stime)
	{
		return base.Channel.mdMmsSendAsync(sn, pwd, title, mobile, content, stime);
	}

	public string mdMmsSend_ex(string sn, string pwd, string title, string mobile, string content, string stime, string ext)
	{
		return base.Channel.mdMmsSend_ex(sn, pwd, title, mobile, content, stime, ext);
	}

	public Task<string> mdMmsSend_exAsync(string sn, string pwd, string title, string mobile, string content, string stime, string ext)
	{
		return base.Channel.mdMmsSend_exAsync(sn, pwd, title, mobile, content, stime, ext);
	}

	public string mdMmsSend_uex(string sn, string pwd, string title, string mobile, string content, string stime, string ext)
	{
		return base.Channel.mdMmsSend_uex(sn, pwd, title, mobile, content, stime, ext);
	}

	public Task<string> mdMmsSend_uexAsync(string sn, string pwd, string title, string mobile, string content, string stime, string ext)
	{
		return base.Channel.mdMmsSend_uexAsync(sn, pwd, title, mobile, content, stime, ext);
	}

	public string mdMmsSendF(string sn, string pwd, string mobile, string content, string stime)
	{
		return base.Channel.mdMmsSendF(sn, pwd, mobile, content, stime);
	}

	public Task<string> mdMmsSendFAsync(string sn, string pwd, string mobile, string content, string stime)
	{
		return base.Channel.mdMmsSendFAsync(sn, pwd, mobile, content, stime);
	}

	public string mdAudioSend(string sn, string pwd, string title, string mobile, string txt, string content, string srcnumber, string stime)
	{
		return base.Channel.mdAudioSend(sn, pwd, title, mobile, txt, content, srcnumber, stime);
	}

	public Task<string> mdAudioSendAsync(string sn, string pwd, string title, string mobile, string txt, string content, string srcnumber, string stime)
	{
		return base.Channel.mdAudioSendAsync(sn, pwd, title, mobile, txt, content, srcnumber, stime);
	}

	public string mdFaxSend(string sn, string pwd, string title, string mobile, string content, string srcnumber, string stime)
	{
		return base.Channel.mdFaxSend(sn, pwd, title, mobile, content, srcnumber, stime);
	}

	public Task<string> mdFaxSendAsync(string sn, string pwd, string title, string mobile, string content, string srcnumber, string stime)
	{
		return base.Channel.mdFaxSendAsync(sn, pwd, title, mobile, content, srcnumber, stime);
	}

	public string mdMmsReceive(string sn, string pwd)
	{
		return base.Channel.mdMmsReceive(sn, pwd);
	}

	public Task<string> mdMmsReceiveAsync(string sn, string pwd)
	{
		return base.Channel.mdMmsReceiveAsync(sn, pwd);
	}

	public string MongateCsSpSendSmsNew(string userId, string password, string pszMobis, string pszMsg, int iMobiCount, string pszSubPort)
	{
		return base.Channel.MongateCsSpSendSmsNew(userId, password, pszMobis, pszMsg, iMobiCount, pszSubPort);
	}

	public Task<string> MongateCsSpSendSmsNewAsync(string userId, string password, string pszMobis, string pszMsg, int iMobiCount, string pszSubPort)
	{
		return base.Channel.MongateCsSpSendSmsNewAsync(userId, password, pszMobis, pszMsg, iMobiCount, pszSubPort);
	}

	public string[] MongateCsGetSmsExEx(string userId, string password)
	{
		return base.Channel.MongateCsGetSmsExEx(userId, password);
	}

	public Task<string[]> MongateCsGetSmsExExAsync(string userId, string password)
	{
		return base.Channel.MongateCsGetSmsExExAsync(userId, password);
	}

	public string[] MongateCsGetStatusReportExEx(string userId, string password)
	{
		return base.Channel.MongateCsGetStatusReportExEx(userId, password);
	}

	public Task<string[]> MongateCsGetStatusReportExExAsync(string userId, string password)
	{
		return base.Channel.MongateCsGetStatusReportExExAsync(userId, password);
	}

	public string bianliang(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid, string bcode)
	{
		return base.Channel.bianliang(sn, pwd, mobile, content, ext, stime, rrid, bcode);
	}

	public Task<string> bianliangAsync(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid, string bcode)
	{
		return base.Channel.bianliangAsync(sn, pwd, mobile, content, ext, stime, rrid, bcode);
	}
}
