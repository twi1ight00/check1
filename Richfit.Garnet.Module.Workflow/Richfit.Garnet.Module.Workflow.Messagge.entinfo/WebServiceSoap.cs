using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Richfit.Garnet.Module.Workflow.Messagge.entinfo;

[ServiceContract(ConfigurationName = "Messagge.entinfo.WebServiceSoap")]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public interface WebServiceSoap
{
	[OperationContract(Action = "http://tempuri.org/SendSMS", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string SendSMS(string sn, string pwd, string mobile, string content);

	[OperationContract(Action = "http://tempuri.org/SendSMS", ReplyAction = "*")]
	Task<string> SendSMSAsync(string sn, string pwd, string mobile, string content);

	[OperationContract(Action = "http://tempuri.org/SendSMS_R", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string SendSMS_R(string sn, string pwd, string mobile, string content, string rrid);

	[OperationContract(Action = "http://tempuri.org/SendSMS_R", ReplyAction = "*")]
	Task<string> SendSMS_RAsync(string sn, string pwd, string mobile, string content, string rrid);

	[OperationContract(Action = "http://tempuri.org/SendSMSEx", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string SendSMSEx(string sn, string pwd, string mobile, string content, string subcode);

	[OperationContract(Action = "http://tempuri.org/SendSMSEx", ReplyAction = "*")]
	Task<string> SendSMSExAsync(string sn, string pwd, string mobile, string content, string subcode);

	[OperationContract(Action = "http://tempuri.org/SendSMSEx_R", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string SendSMSEx_R(string sn, string pwd, string mobile, string content, string subcode, string rrid);

	[OperationContract(Action = "http://tempuri.org/SendSMSEx_R", ReplyAction = "*")]
	Task<string> SendSMSEx_RAsync(string sn, string pwd, string mobile, string content, string subcode, string rrid);

	[OperationContract(Action = "http://tempuri.org/UnRegister", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string UnRegister(string sn, string pwd);

	[OperationContract(Action = "http://tempuri.org/UnRegister", ReplyAction = "*")]
	Task<string> UnRegisterAsync(string sn, string pwd);

	[XmlSerializerFormat(SupportFaults = true)]
	[OperationContract(Action = "http://tempuri.org/ChargUp", ReplyAction = "*")]
	string ChargUp(string sn, string pwd, string cardno, string cardpwd);

	[OperationContract(Action = "http://tempuri.org/ChargUp", ReplyAction = "*")]
	Task<string> ChargUpAsync(string sn, string pwd, string cardno, string cardpwd);

	[OperationContract(Action = "http://tempuri.org/GetBalance", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string GetBalance(string sn, string pwd);

	[OperationContract(Action = "http://tempuri.org/GetBalance", ReplyAction = "*")]
	Task<string> GetBalanceAsync(string sn, string pwd);

	[OperationContract(Action = "http://tempuri.org/GetStatus", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string GetStatus(string sn, string pwd);

	[OperationContract(Action = "http://tempuri.org/GetStatus", ReplyAction = "*")]
	Task<string> GetStatusAsync(string sn, string pwd);

	[XmlSerializerFormat(SupportFaults = true)]
	[OperationContract(Action = "http://tempuri.org/GetCode", ReplyAction = "*")]
	string GetCode(string sn, string pwd);

	[OperationContract(Action = "http://tempuri.org/GetCode", ReplyAction = "*")]
	Task<string> GetCodeAsync(string sn, string pwd);

	[OperationContract(Action = "http://tempuri.org/UDPPwd", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string UDPPwd(string sn, string pwd, string newpwd);

	[OperationContract(Action = "http://tempuri.org/UDPPwd", ReplyAction = "*")]
	Task<string> UDPPwdAsync(string sn, string pwd, string newpwd);

	[OperationContract(Action = "http://tempuri.org/UDPSIGN", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string UDPSIGN(string sn, string pwd, string sign);

	[OperationContract(Action = "http://tempuri.org/UDPSIGN", ReplyAction = "*")]
	Task<string> UDPSIGNAsync(string sn, string pwd, string sign);

	[OperationContract(Action = "http://tempuri.org/UDPSIGNEX", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string UDPSIGNEX(string sn, string pwd, string subcode, string sign, string comName);

	[OperationContract(Action = "http://tempuri.org/UDPSIGNEX", ReplyAction = "*")]
	Task<string> UDPSIGNEXAsync(string sn, string pwd, string subcode, string sign, string comName);

	[OperationContract(Action = "http://tempuri.org/RECSMS", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	MOBody[] RECSMS(string sn, string pwd);

	[OperationContract(Action = "http://tempuri.org/RECSMS", ReplyAction = "*")]
	Task<MOBody[]> RECSMSAsync(string sn, string pwd);

	[XmlSerializerFormat(SupportFaults = true)]
	[OperationContract(Action = "http://tempuri.org/RECSMSEx", ReplyAction = "*")]
	MOBody[] RECSMSEx(string sn, string pwd, string subcode);

	[OperationContract(Action = "http://tempuri.org/RECSMSEx", ReplyAction = "*")]
	Task<MOBody[]> RECSMSExAsync(string sn, string pwd, string subcode);

	[XmlSerializerFormat(SupportFaults = true)]
	[OperationContract(Action = "http://tempuri.org/RECSMS_UTF8", ReplyAction = "*")]
	MOBody[] RECSMS_UTF8(string sn, string pwd);

	[OperationContract(Action = "http://tempuri.org/RECSMS_UTF8", ReplyAction = "*")]
	Task<MOBody[]> RECSMS_UTF8Async(string sn, string pwd);

	[OperationContract(Action = "http://tempuri.org/RECSMSEx_UTF8", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	MOBody[] RECSMSEx_UTF8(string sn, string pwd, string subcode);

	[OperationContract(Action = "http://tempuri.org/RECSMSEx_UTF8", ReplyAction = "*")]
	Task<MOBody[]> RECSMSEx_UTF8Async(string sn, string pwd, string subcode);

	[OperationContract(Action = "http://tempuri.org/Register", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string Register(string sn, string pwd, string province, string city, string trade, string entname, string linkman, string phone, string mobile, string email, string fax, string address, string postcode, string sign);

	[OperationContract(Action = "http://tempuri.org/Register", ReplyAction = "*")]
	Task<string> RegisterAsync(string sn, string pwd, string province, string city, string trade, string entname, string linkman, string phone, string mobile, string email, string fax, string address, string postcode, string sign);

	[XmlSerializerFormat(SupportFaults = true)]
	[OperationContract(Action = "http://tempuri.org/GetFlag", ReplyAction = "*")]
	string GetFlag(string sn, string pwd);

	[OperationContract(Action = "http://tempuri.org/GetFlag", ReplyAction = "*")]
	Task<string> GetFlagAsync(string sn, string pwd);

	[OperationContract(Action = "http://tempuri.org/SMSTest", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string SMSTest(string sn, string pwd, string mobile);

	[OperationContract(Action = "http://tempuri.org/SMSTest", ReplyAction = "*")]
	Task<string> SMSTestAsync(string sn, string pwd, string mobile);

	[XmlSerializerFormat(SupportFaults = true)]
	[OperationContract(Action = "http://tempuri.org/TestCode", ReplyAction = "*")]
	string TestCode(string content, string code, string type);

	[OperationContract(Action = "http://tempuri.org/TestCode", ReplyAction = "*")]
	Task<string> TestCodeAsync(string content, string code, string type);

	[OperationContract(Action = "http://tempuri.org/GetAllInfo", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	RegistryInfo GetAllInfo(string sn, string pwd);

	[OperationContract(Action = "http://tempuri.org/GetAllInfo", ReplyAction = "*")]
	Task<RegistryInfo> GetAllInfoAsync(string sn, string pwd);

	[XmlSerializerFormat(SupportFaults = true)]
	[OperationContract(Action = "http://tempuri.org/GetAllInfo2", ReplyAction = "*")]
	RegistryInfo2 GetAllInfo2(string sn, string pwd, string ver, string oem);

	[OperationContract(Action = "http://tempuri.org/GetAllInfo2", ReplyAction = "*")]
	Task<RegistryInfo2> GetAllInfo2Async(string sn, string pwd, string ver, string oem);

	[OperationContract(Action = "http://tempuri.org/SetGaoDuan", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	double SetGaoDuan(string sn, string pwd, string gd);

	[OperationContract(Action = "http://tempuri.org/SetGaoDuan", ReplyAction = "*")]
	Task<double> SetGaoDuanAsync(string sn, string pwd, string gd);

	[OperationContract(Action = "http://tempuri.org/GetGaoDuan", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string GetGaoDuan(string sn, string pwd);

	[OperationContract(Action = "http://tempuri.org/GetGaoDuan", ReplyAction = "*")]
	Task<string> GetGaoDuanAsync(string sn, string pwd);

	[OperationContract(Action = "http://tempuri.org/mt", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string mt(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid);

	[OperationContract(Action = "http://tempuri.org/mt", ReplyAction = "*")]
	Task<string> mtAsync(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid);

	[XmlSerializerFormat(SupportFaults = true)]
	[OperationContract(Action = "http://tempuri.org/mdSmsSend", ReplyAction = "*")]
	string mdSmsSend(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid);

	[OperationContract(Action = "http://tempuri.org/mdSmsSend", ReplyAction = "*")]
	Task<string> mdSmsSendAsync(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid);

	[OperationContract(Action = "http://tempuri.org/mdSmsSend_u", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string mdSmsSend_u(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid);

	[OperationContract(Action = "http://tempuri.org/mdSmsSend_u", ReplyAction = "*")]
	Task<string> mdSmsSend_uAsync(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid);

	[XmlSerializerFormat(SupportFaults = true)]
	[OperationContract(Action = "http://tempuri.org/mdSmsSend_DES", ReplyAction = "*")]
	string mdSmsSend_DES(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid);

	[OperationContract(Action = "http://tempuri.org/mdSmsSend_DES", ReplyAction = "*")]
	Task<string> mdSmsSend_DESAsync(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid);

	[OperationContract(Action = "http://tempuri.org/mdSmsSend_AES", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string mdSmsSend_AES(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid);

	[OperationContract(Action = "http://tempuri.org/mdSmsSend_AES", ReplyAction = "*")]
	Task<string> mdSmsSend_AESAsync(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid);

	[XmlSerializerFormat(SupportFaults = true)]
	[OperationContract(Action = "http://tempuri.org/mdSmsSend_g", ReplyAction = "*")]
	string mdSmsSend_g(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid);

	[OperationContract(Action = "http://tempuri.org/mdSmsSend_g", ReplyAction = "*")]
	Task<string> mdSmsSend_gAsync(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid);

	[OperationContract(Action = "http://tempuri.org/mo", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string mo(string sn, string pwd);

	[OperationContract(Action = "http://tempuri.org/mo", ReplyAction = "*")]
	Task<string> moAsync(string sn, string pwd);

	[OperationContract(Action = "http://tempuri.org/mo2", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string mo2(string sn, string pwd, int maxID);

	[OperationContract(Action = "http://tempuri.org/mo2", ReplyAction = "*")]
	Task<string> mo2Async(string sn, string pwd, int maxID);

	[OperationContract(Action = "http://tempuri.org/report", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string report(string sn, string pwd, long maxid);

	[OperationContract(Action = "http://tempuri.org/report", ReplyAction = "*")]
	Task<string> reportAsync(string sn, string pwd, long maxid);

	[XmlSerializerFormat(SupportFaults = true)]
	[OperationContract(Action = "http://tempuri.org/report2", ReplyAction = "*")]
	string report2(string sn, string pwd, long maxid, string rrid);

	[OperationContract(Action = "http://tempuri.org/report2", ReplyAction = "*")]
	Task<string> report2Async(string sn, string pwd, long maxid, string rrid);

	[XmlSerializerFormat(SupportFaults = true)]
	[OperationContract(Action = "http://tempuri.org/report2DES", ReplyAction = "*")]
	string report2DES(string sn, string pwd, long maxid, string rrid);

	[OperationContract(Action = "http://tempuri.org/report2DES", ReplyAction = "*")]
	Task<string> report2DESAsync(string sn, string pwd, long maxid, string rrid);

	[OperationContract(Action = "http://tempuri.org/msgid", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string msgid(string sn, string pwd);

	[OperationContract(Action = "http://tempuri.org/msgid", ReplyAction = "*")]
	Task<string> msgidAsync(string sn, string pwd);

	[OperationContract(Action = "http://tempuri.org/balance", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string balance(string sn, string pwd);

	[OperationContract(Action = "http://tempuri.org/balance", ReplyAction = "*")]
	Task<string> balanceAsync(string sn, string pwd);

	[OperationContract(Action = "http://tempuri.org/gxmt", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string gxmt(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid);

	[OperationContract(Action = "http://tempuri.org/gxmt", ReplyAction = "*")]
	Task<string> gxmtAsync(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid);

	[OperationContract(Action = "http://tempuri.org/fileMT", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string fileMT(string sn, string pwd, string fname, string rrid, int sort, int total, int ftype, string content);

	[OperationContract(Action = "http://tempuri.org/fileMT", ReplyAction = "*")]
	Task<string> fileMTAsync(string sn, string pwd, string fname, string rrid, int sort, int total, int ftype, string content);

	[OperationContract(Action = "http://tempuri.org/mmsFileMT", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string mmsFileMT(string sn, string pwd, string rrid, string content);

	[OperationContract(Action = "http://tempuri.org/mmsFileMT", ReplyAction = "*")]
	Task<string> mmsFileMTAsync(string sn, string pwd, string rrid, string content);

	[OperationContract(Action = "http://tempuri.org/mdMmsSend", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string mdMmsSend(string sn, string pwd, string title, string mobile, string content, string stime);

	[OperationContract(Action = "http://tempuri.org/mdMmsSend", ReplyAction = "*")]
	Task<string> mdMmsSendAsync(string sn, string pwd, string title, string mobile, string content, string stime);

	[XmlSerializerFormat(SupportFaults = true)]
	[OperationContract(Action = "http://tempuri.org/mdMmsSend_ex", ReplyAction = "*")]
	string mdMmsSend_ex(string sn, string pwd, string title, string mobile, string content, string stime, string ext);

	[OperationContract(Action = "http://tempuri.org/mdMmsSend_ex", ReplyAction = "*")]
	Task<string> mdMmsSend_exAsync(string sn, string pwd, string title, string mobile, string content, string stime, string ext);

	[XmlSerializerFormat(SupportFaults = true)]
	[OperationContract(Action = "http://tempuri.org/mdMmsSend_uex", ReplyAction = "*")]
	string mdMmsSend_uex(string sn, string pwd, string title, string mobile, string content, string stime, string ext);

	[OperationContract(Action = "http://tempuri.org/mdMmsSend_uex", ReplyAction = "*")]
	Task<string> mdMmsSend_uexAsync(string sn, string pwd, string title, string mobile, string content, string stime, string ext);

	[OperationContract(Action = "http://tempuri.org/mdMmsSendF", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string mdMmsSendF(string sn, string pwd, string mobile, string content, string stime);

	[OperationContract(Action = "http://tempuri.org/mdMmsSendF", ReplyAction = "*")]
	Task<string> mdMmsSendFAsync(string sn, string pwd, string mobile, string content, string stime);

	[XmlSerializerFormat(SupportFaults = true)]
	[OperationContract(Action = "http://tempuri.org/mdAudioSend", ReplyAction = "*")]
	string mdAudioSend(string sn, string pwd, string title, string mobile, string txt, string content, string srcnumber, string stime);

	[OperationContract(Action = "http://tempuri.org/mdAudioSend", ReplyAction = "*")]
	Task<string> mdAudioSendAsync(string sn, string pwd, string title, string mobile, string txt, string content, string srcnumber, string stime);

	[OperationContract(Action = "http://tempuri.org/mdFaxSend", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string mdFaxSend(string sn, string pwd, string title, string mobile, string content, string srcnumber, string stime);

	[OperationContract(Action = "http://tempuri.org/mdFaxSend", ReplyAction = "*")]
	Task<string> mdFaxSendAsync(string sn, string pwd, string title, string mobile, string content, string srcnumber, string stime);

	[OperationContract(Action = "http://tempuri.org/mdMmsReceive", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string mdMmsReceive(string sn, string pwd);

	[OperationContract(Action = "http://tempuri.org/mdMmsReceive", ReplyAction = "*")]
	Task<string> mdMmsReceiveAsync(string sn, string pwd);

	[OperationContract(Action = "http://tempuri.org/MongateCsSpSendSmsNew", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string MongateCsSpSendSmsNew(string userId, string password, string pszMobis, string pszMsg, int iMobiCount, string pszSubPort);

	[OperationContract(Action = "http://tempuri.org/MongateCsSpSendSmsNew", ReplyAction = "*")]
	Task<string> MongateCsSpSendSmsNewAsync(string userId, string password, string pszMobis, string pszMsg, int iMobiCount, string pszSubPort);

	[OperationContract(Action = "http://tempuri.org/MongateCsGetSmsExEx", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string[] MongateCsGetSmsExEx(string userId, string password);

	[OperationContract(Action = "http://tempuri.org/MongateCsGetSmsExEx", ReplyAction = "*")]
	Task<string[]> MongateCsGetSmsExExAsync(string userId, string password);

	[OperationContract(Action = "http://tempuri.org/MongateCsGetStatusReportExEx", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string[] MongateCsGetStatusReportExEx(string userId, string password);

	[OperationContract(Action = "http://tempuri.org/MongateCsGetStatusReportExEx", ReplyAction = "*")]
	Task<string[]> MongateCsGetStatusReportExExAsync(string userId, string password);

	[OperationContract(Action = "http://tempuri.org/bianliang", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string bianliang(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid, string bcode);

	[OperationContract(Action = "http://tempuri.org/bianliang", ReplyAction = "*")]
	Task<string> bianliangAsync(string sn, string pwd, string mobile, string content, string ext, string stime, string rrid, string bcode);
}
