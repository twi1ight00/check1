using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using Richfit.Garnet.Module.Authorization.Application.DTO;
using Richfit.Garnet.Module.Authorization.Domain.Models;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Domain.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Base.Infrastructure.Session;

namespace Richfit.Garnet.Module.Authorization.Application.Services;

public class AuthorizationService : ServiceBase, IAuthorizationService
{
	private readonly IRepository<SYS_AUTHORIZATION_DETAILS> amAuthorizationDetails;

	private readonly IRepository<SYS_AUTHORIZATION> amAuthorization;

	private readonly IRepository<SYS_AUTHORIZATION_SPECIAL> amAuthorizationUserList;

	public AuthorizationService(IRepository<SYS_AUTHORIZATION_DETAILS> amAuthorizationDetails, IRepository<SYS_AUTHORIZATION> amAuthorization, IRepository<SYS_AUTHORIZATION_SPECIAL> amAuthorizationUserList)
	{
		this.amAuthorization = amAuthorization;
		this.amAuthorizationDetails = amAuthorizationDetails;
		this.amAuthorizationUserList = amAuthorizationUserList;
	}

	public QueryResult<SYS_AUTHORIZATION_PERSONDTO> GetAuthorizationPersonList(SYS_AUTHORIZATION_PERSONDTO trDTO)
	{
		return SqlQueryPager<SYS_AUTHORIZATION_PERSONDTO>("GetAuthorizationPersonListByUserId", trDTO);
	}

	public IList<AUTHORIZATION_ROLEDTO> GetRoleByUserID(AUTHORIZATION_ROLEDTO trDTO)
	{
		return SqlQuery<AUTHORIZATION_ROLEDTO>("GetWorkflowRoleByUser", trDTO);
	}

	public IList<AUTHORIZATION_BUSINESSDTO> GetBusinessList(AUTHORIZATION_BUSINESSDTO trDTO)
	{
		SqlRepository repository = new SqlRepository();
		string WhereSql = "";
		if (!string.IsNullOrEmpty(trDTO.ROLE_NAME))
		{
			string[] rids = trDTO.ROLE_NAME.Split(',');
			for (int i = 0; i < rids.Length; i++)
			{
				WhereSql = WhereSql + " C.PARTICIPANT_ID = f_guidtoraw('" + rids[i] + "') OR ";
			}
			WhereSql = WhereSql.Substring(0, WhereSql.Length - 3) + ") ORDER BY ROLE_NAME, BUSINESS_NAME";
		}
		else
		{
			WhereSql = " C.PARTICIPANT_ID='')";
		}
		string sql = $"SELECT DISTINCT A.TEMPLATE_ID AS RESOURCES_ID,A.PACKAGE_ID AS RESOURCES_TYPE ,A.TEMPLATE_NAME AS BUSINESS_NAME,C.PARTICIPANT_ID AS ROLE_ID,D.ROLE_NAME FROM WF_TEMPLATE A LEFT JOIN WF_ACTIVITY B ON A.TEMPLATE_ID=B.TEMPLATE_ID LEFT JOIN WF_ACTIVITY_PARTICIPANT C ON B.ACTIVITY_ID=C.ACTIVITY_ID LEFT JOIN SYS_ROLE D ON C.PARTICIPANT_ID=D.ROLE_ID WHERE  A.ISACTIVE=1 AND B.ACTIVITY_TYPE=0 AND ({WhereSql}";
		IList<AUTHORIZATION_BUSINESSDTO> litVal = new List<AUTHORIZATION_BUSINESSDTO>();
		return litVal = repository.ExecuteQuery<AUTHORIZATION_BUSINESSDTO>(sql, new object[0]);
	}

	public IList<AUTHORIZATION_BUSINESSDTO> GetBusinessListByAuthID(AUTHORIZATION_BUSINESSDTO trDTO)
	{
		return SqlQuery<AUTHORIZATION_BUSINESSDTO>("GetBusinessListByAuthID", trDTO);
	}

	public IList<AUTHORIZATION_BUSINESSDTO> GetRoleByAuthID(AUTHORIZATION_BUSINESSDTO trDTO)
	{
		return SqlQuery<AUTHORIZATION_BUSINESSDTO>("GetBusinessRoleByAuthID", trDTO);
	}

	public QueryResult<AUTHORIZATION_USERLISTDTO> QueryUserList(AUTHORIZATION_USERLISTDTO trDTO)
	{
		return SqlQueryPager<AUTHORIZATION_USERLISTDTO>("GetAuthorizationUserList", trDTO);
	}

	public QueryResult<SYS_AUTHORIZATIONDTO> GetAuthorizationListByUserID(SYS_AUTHORIZATIONDTO trDTO)
	{
		return SqlQueryPager<SYS_AUTHORIZATIONDTO>("GetAuthorizationListByUserID", trDTO);
	}

	public SYS_AUTHORIZATIONDTO SaveBusinessInfo(SYS_AUTHORIZATIONDTO trDTO)
	{
		if (trDTO.IsValid())
		{
			SYS_AUTHORIZATION trPOCO = trDTO.AdaptAsEntity<SYS_AUTHORIZATION>();
			if (trDTO.IsCreate)
			{
				try
				{
					amAuthorization.AddCommit(trPOCO);
				}
				catch (DbEntityValidationException dbEx2)
				{
					throw dbEx2;
				}
			}
			else
			{
				SYS_AUTHORIZATION auPOCO = amAuthorization.GetByKey(trDTO.SYS_AUTHORIZATION_ID);
				if (auPOCO != null)
				{
					auPOCO.SYS_AUTHORIZATION_ID = trDTO.SYS_AUTHORIZATION_ID;
					auPOCO.USER_ID = trDTO.USER_ID.Value;
					auPOCO.TO_USER_ID = trDTO.TO_USER_ID;
					auPOCO.TO_ORG_ID = trDTO.TO_ORG_ID;
					auPOCO.START_TIME = trDTO.START_TIME;
					auPOCO.END_TIME = trDTO.END_TIME;
					auPOCO.ORG_ID = trDTO.ORG_ID;
					auPOCO.STATUS = trDTO.STATUS;
					auPOCO.NOTE = trDTO.NOTE;
					IList<SYS_AUTHORIZATION_DETAILS> deleteDetails = amAuthorizationDetails.FindAll((SYS_AUTHORIZATION_DETAILS d) => d.AUTHORIZATION_ID == trPOCO.SYS_AUTHORIZATION_ID);
					foreach (SYS_AUTHORIZATION_DETAILS details in trPOCO.SYS_AUTHORIZATION_DETAILS)
					{
						details.AUTHORIZATION_ID = trDTO.SYS_AUTHORIZATION_ID;
					}
					try
					{
						amAuthorization.UpdateCommit(auPOCO);
						amAuthorizationDetails.RemoveCommit(deleteDetails);
						amAuthorizationDetails.AddCommit(trPOCO.SYS_AUTHORIZATION_DETAILS);
					}
					catch (DbEntityValidationException dbEx2)
					{
						throw dbEx2;
					}
				}
			}
			return trDTO;
		}
		throw new ValidationException(trDTO.GetInvalidMessages());
	}

	public SYS_AUTHORIZATION_SPECIALDTO SaveUserList(IList<SYS_AUTHORIZATION_SPECIALDTO> trDTOList, Guid userID)
	{
		SYS_AUTHORIZATION_SPECIALDTO trDTO = new SYS_AUTHORIZATION_SPECIALDTO();
		List<SYS_AUTHORIZATION_SPECIAL> pocoList = new List<SYS_AUTHORIZATION_SPECIAL>();
		try
		{
			List<SYS_AUTHORIZATION_SPECIAL> deleteList = amAuthorizationUserList.FindAll((SYS_AUTHORIZATION_SPECIAL t) => t.USER_ID == userID).ToList();
			if (deleteList != null && deleteList.Count > 0)
			{
				amAuthorizationUserList.RemoveCommit(deleteList);
			}
			for (int i = 0; trDTOList.Count > i; i++)
			{
				SYS_AUTHORIZATION_SPECIAL trPOCO = trDTOList[i].AdaptAsEntity<SYS_AUTHORIZATION_SPECIAL>();
				pocoList.Add(trPOCO);
				trDTO = trDTOList[i];
			}
			amAuthorizationUserList.Add(pocoList);
			amAuthorizationUserList.DbContext.Commit();
		}
		catch (DbEntityValidationException dbEx)
		{
			throw dbEx;
		}
		return trDTO;
	}

	public void EditAuthInfo(Dictionary<string, string> dataparams)
	{
		if (dataparams.Count == 4)
		{
			Guid authorizationID = Guid.Parse(dataparams["SYS_AUTHORIZATION_ID"]);
			DateTime endTime = Convert.ToDateTime(dataparams["ENDTIME"]);
			int status = Convert.ToInt16(dataparams["STATUS"]);
			Guid userID = Guid.Parse(dataparams["MODIFIER"]);
			SYS_AUTHORIZATION authorizationPOCO = amAuthorization.GetByKey(authorizationID);
			authorizationPOCO.END_TIME = endTime;
			authorizationPOCO.STATUS = status;
			authorizationPOCO.MODIFIER = userID;
			authorizationPOCO.MODIFYTIME = DateTime.Now;
			amAuthorization.Update(authorizationPOCO);
			try
			{
				amAuthorization.DbContext.Commit();
			}
			catch (DbEntityValidationException dbEx)
			{
				throw dbEx;
			}
		}
	}

	public void RemoveRecord(Guid authorizationID)
	{
		bool flag = 1 == 0;
		SYS_AUTHORIZATION authorizationPOCO = amAuthorization.GetByKey(authorizationID);
		IList<SYS_AUTHORIZATION_DETAILS> details = authorizationPOCO.SYS_AUTHORIZATION_DETAILS.ToList();
		if (details.Count > 0)
		{
			for (int i = 0; i < details.Count; i++)
			{
				details[i].ISDEL = 1m;
			}
			amAuthorization.RemoveChild(details);
		}
		authorizationPOCO.ISDEL = 1m;
		amAuthorization.Update(authorizationPOCO);
		try
		{
			amAuthorization.DbContext.Commit();
		}
		catch (DbEntityValidationException dbEx)
		{
			throw dbEx;
		}
	}

	public SYS_AUTHORIZATIONDTO GetAuthorizationByauthID(Guid authID)
	{
		SYS_AUTHORIZATIONDTO authDTO = new SYS_AUTHORIZATIONDTO();
		IList<SYS_AUTHORIZATIONDTO> authList = SqlQuery<SYS_AUTHORIZATIONDTO>("GetAuthorizationByauthID", new
		{
			SYS_AUTHORIZATION_ID = authID
		});
		if (authList != null && authList.Count > 0)
		{
			authDTO = authList[0];
			_ = authDTO.SYS_AUTHORIZATION_ID;
			bool flag = 1 == 0;
			IList<SYS_AUTHORIZATION_DETAILSDTO> list = GetAuthorizationDetailByauthID(authDTO.SYS_AUTHORIZATION_ID);
			authDTO.SYS_AUTHORIZATION_DETAILS = list.ToList();
		}
		return authDTO;
	}

	public IList<SYS_AUTHORIZATION_DETAILSDTO> GetAuthorizationDetailByauthID(Guid authID)
	{
		List<SYS_AUTHORIZATION_DETAILSDTO> list = new List<SYS_AUTHORIZATION_DETAILSDTO>();
		IList<SYS_AUTHORIZATION_DETAILS> detailList = SqlQuery<SYS_AUTHORIZATION_DETAILS>("GetAuthorizationDetailByauthID", new
		{
			AUTHORIZATION_ID = authID
		});
		detailList.ToList().ForEach(delegate(SYS_AUTHORIZATION_DETAILS detail)
		{
			list.Add(detail.AdaptAsDTO<SYS_AUTHORIZATION_DETAILSDTO>());
		});
		return list;
	}

	public IList<SYS_AUTHORIZATION_SPECIALDTO> GetAuthorizationSpecialList(SYS_AUTHORIZATION_SPECIALDTO trDTO)
	{
		return SqlQuery<SYS_AUTHORIZATION_SPECIALDTO>("GetAuthorizationSpecialListByUserId", trDTO);
	}

	public SYS_AUTHORIZATIONDTO SaveAuthorization(SYS_AUTHORIZATIONDTO authorizationDto)
	{
		SYS_AUTHORIZATION auPOCO;
		if (authorizationDto.IsCreate)
		{
			authorizationDto.SYS_AUTHORIZATION_ID = Guid.NewGuid();
			auPOCO = authorizationDto.AdaptAsEntity<SYS_AUTHORIZATION>();
			auPOCO.SYS_AUTHORIZATION_DETAILS.Clear();
		}
		else
		{
			auPOCO = amAuthorization.GetByKey(authorizationDto.SYS_AUTHORIZATION_ID);
			auPOCO.SYS_AUTHORIZATION_ID = authorizationDto.SYS_AUTHORIZATION_ID;
			auPOCO.USER_ID = authorizationDto.USER_ID.Value;
			auPOCO.TO_USER_ID = authorizationDto.TO_USER_ID;
			auPOCO.TO_ORG_ID = authorizationDto.TO_ORG_ID;
			auPOCO.START_TIME = authorizationDto.START_TIME;
			auPOCO.END_TIME = authorizationDto.END_TIME;
			auPOCO.AUTHORIZATION_TYPE = authorizationDto.AUTHORIZATION_TYPE;
			auPOCO.ORG_ID = authorizationDto.ORG_ID;
			auPOCO.STATUS = authorizationDto.STATUS;
			auPOCO.NOTE = authorizationDto.NOTE;
			amAuthorization.RemoveChild(auPOCO.SYS_AUTHORIZATION_DETAILS);
		}
		if (authorizationDto.SYS_AUTHORIZATION_DETAILS != null && authorizationDto.SYS_AUTHORIZATION_DETAILS.Count > 0)
		{
			if (authorizationDto.AUTHORIZATION_TYPE == 0m)
			{
				foreach (SYS_AUTHORIZATION_DETAILSDTO item in authorizationDto.SYS_AUTHORIZATION_DETAILS)
				{
					IList<AUTHORIZATION_BUSINESSDTO> business = SqlQuery<AUTHORIZATION_BUSINESSDTO>("GetBusinessList", item);
					foreach (AUTHORIZATION_BUSINESSDTO ab in business)
					{
						SYS_AUTHORIZATION_DETAILS sYS_AUTHORIZATION_DETAILS = new SYS_AUTHORIZATION_DETAILS();
						sYS_AUTHORIZATION_DETAILS.SYS_AUTHORIZATION_DETAILS_ID = Guid.NewGuid();
						sYS_AUTHORIZATION_DETAILS.AUTHORIZATION_ID = authorizationDto.SYS_AUTHORIZATION_ID;
						sYS_AUTHORIZATION_DETAILS.ROLE_ID = item.ROLE_ID;
						sYS_AUTHORIZATION_DETAILS.RESOURCES_ID = ab.RESOURCES_ID;
						sYS_AUTHORIZATION_DETAILS.RESOURCES_TYPE = ab.RESOURCES_TYPE;
						sYS_AUTHORIZATION_DETAILS.CREATOR = SessionContext.UserInfo.UserID;
						sYS_AUTHORIZATION_DETAILS.CREATETIME = DateTime.Now;
						sYS_AUTHORIZATION_DETAILS.MODIFIER = SessionContext.UserInfo.UserID;
						sYS_AUTHORIZATION_DETAILS.MODIFYTIME = DateTime.Now;
						SYS_AUTHORIZATION_DETAILS detail = sYS_AUTHORIZATION_DETAILS;
						auPOCO.SYS_AUTHORIZATION_DETAILS.Add(detail);
					}
				}
			}
			else
			{
				foreach (SYS_AUTHORIZATION_DETAILSDTO item in authorizationDto.SYS_AUTHORIZATION_DETAILS)
				{
					SYS_AUTHORIZATION_DETAILS sYS_AUTHORIZATION_DETAILS2 = new SYS_AUTHORIZATION_DETAILS();
					sYS_AUTHORIZATION_DETAILS2.SYS_AUTHORIZATION_DETAILS_ID = Guid.NewGuid();
					sYS_AUTHORIZATION_DETAILS2.AUTHORIZATION_ID = authorizationDto.SYS_AUTHORIZATION_ID;
					sYS_AUTHORIZATION_DETAILS2.ROLE_ID = item.ROLE_ID;
					sYS_AUTHORIZATION_DETAILS2.RESOURCES_ID = item.RESOURCES_ID;
					sYS_AUTHORIZATION_DETAILS2.RESOURCES_TYPE = item.RESOURCES_TYPE;
					sYS_AUTHORIZATION_DETAILS2.CREATOR = SessionContext.UserInfo.UserID;
					sYS_AUTHORIZATION_DETAILS2.CREATETIME = DateTime.Now;
					sYS_AUTHORIZATION_DETAILS2.MODIFIER = SessionContext.UserInfo.UserID;
					sYS_AUTHORIZATION_DETAILS2.MODIFYTIME = DateTime.Now;
					SYS_AUTHORIZATION_DETAILS detail = sYS_AUTHORIZATION_DETAILS2;
					auPOCO.SYS_AUTHORIZATION_DETAILS.Add(detail);
				}
			}
		}
		if (authorizationDto.IsCreate)
		{
			amAuthorization.Add(auPOCO);
		}
		else
		{
			amAuthorization.Update(auPOCO);
		}
		amAuthorization.DbContext.Commit();
		return authorizationDto;
	}

	public QueryResult<SYS_AUTHORIZATIONDTO> GetAuthorizationByauthID(SYS_AUTHORIZATIONDTO dict)
	{
		return SqlQueryPager<SYS_AUTHORIZATIONDTO>("GetAuthorizationList", dict);
	}

	public IList<AUTHORIZATION_BUSINESSDTO> GetAuthorizationRole(SYS_AUTHORIZATIONDTO dict)
	{
		return SqlQuery<AUTHORIZATION_BUSINESSDTO>("GetAuthorizationRole", dict);
	}
}
