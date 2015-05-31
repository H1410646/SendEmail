//-------------------------------------------------------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2013 , TH , Ltd.
//-------------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Data.Common;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Text;
#if NET20
using Pub.Class.Linq;
#else
using System.Linq;
#endif
using TH.Mailer.Entity;
using Pub.Class;

namespace TH.Mailer.Helper {
	/// <summary>
	/// ������
	///
	/// �޸ļ�¼
	///	 2013-06-03 �汾��1.0 ϵͳ�Զ���������
	///
	/// </summary>
	public partial class EmailListHelper {
		/// <summary>
		/// ��������� x 5
		/// </summary>
		public static int cacheSeconds = 1440;
		/// <summary>
		/// ��Ӽ�¼
		/// </summary>
		/// <param name="emailList">ʵ����</param>
		/// <param name="delCache">��ӳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>����Ƿ�ɹ�</returns>
		public static bool Insert(EmailList emailList, string dbkey = "", string[] delCache = null) {
			int obj = new SQL().Database(dbkey).Insert(EmailList._)
				.ValueP(EmailList._EmailAddress, emailList.EmailAddress)
				.ValueP(EmailList._NickName, emailList.NickName)
				.ValueP(EmailList._LastSendStatus, emailList.LastSendStatus)
				.ValueP(EmailList._LastSendError, emailList.LastSendError)
				.ValueP(EmailList._LastSendTime, emailList.LastSendTime)
				.ValueP(EmailList._LastSendSmtp, emailList.LastSendSmtp)
				.ValueP(EmailList._SendCount, emailList.SendCount)
				.ValueP(EmailList._CreateTime, emailList.CreateTime)
				.ValueP(EmailList._ex0, emailList.ex0)
				.ValueP(EmailList._ex1, emailList.ex1)
				.ValueP(EmailList._ex2, emailList.ex2)
				.ValueP(EmailList._ex3, emailList.ex3)
				.ValueP(EmailList._ex4, emailList.ex4)
				.ValueP(EmailList._ex5, emailList.ex5)
				.ValueP(EmailList._ex6, emailList.ex6)
				.ValueP(EmailList._ex7, emailList.ex7)
				.ValueP(EmailList._ex8, emailList.ex8)
				.ToExec();
			if (delCache.IsNull()) return obj == 1;
			Cache2.Remove("TH.Mailer.EmailListCache_", delCache);
			return obj == 1;
		}
		/// <summary>
		/// ��Ӽ�¼
		/// </summary>
		/// <param name="emailList">ʵ����</param>
		/// <returns>����Ƿ�ɹ�</returns>
		public static bool Insert(EmailList emailList, string dbkey) {
			return Insert(emailList, dbkey, null);
		}
		/// <summary>
		/// �޸ļ�¼
		/// </summary>
		/// <param name="emailList">ʵ����</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool Update(EmailList emailList, string dbkey = "", Where where = null, string[] delCache = null) {
			if (emailList.EmailAddress.IsNullEmpty()) return false;
			int value = new SQL().Database(dbkey).Update(EmailList._)
				.SetP(EmailList._NickName, emailList.NickName)
				.SetP(EmailList._LastSendStatus, emailList.LastSendStatus)
				.SetP(EmailList._LastSendError, emailList.LastSendError)
				.SetP(EmailList._LastSendTime, emailList.LastSendTime)
				.SetP(EmailList._LastSendSmtp, emailList.LastSendSmtp)
				.SetP(EmailList._SendCount, emailList.SendCount)
				.SetP(EmailList._CreateTime, emailList.CreateTime)
				.SetP(EmailList._ex0, emailList.ex0)
				.SetP(EmailList._ex1, emailList.ex1)
				.SetP(EmailList._ex2, emailList.ex2)
				.SetP(EmailList._ex3, emailList.ex3)
				.SetP(EmailList._ex4, emailList.ex4)
				.SetP(EmailList._ex5, emailList.ex5)
				.SetP(EmailList._ex6, emailList.ex6)
				.SetP(EmailList._ex7, emailList.ex7)
				.SetP(EmailList._ex8, emailList.ex8)
				.Where(new Where()
					.AndP(EmailList._EmailAddress, emailList.EmailAddress, Operator.Equal, true)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.EmailListCache_", delCache);
			return true;
		}
		/// <summary>
		/// �޸ļ�¼
		/// </summary>
		/// <param name="emailList">ʵ����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool Update(EmailList emailList, string dbkey) {
			return Update(emailList, dbkey, null, null);
		}
		/// <summary>
		/// �޸Ķ�����¼
		/// </summary>
		/// <param name="emailAddressList">���͵�Email�б��á�,���ŷָ�</param>
		/// <param name="emailList">ʵ����</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool UpdateByIDList(IEnumerable<string> emailAddressList,  EmailList emailList, string dbkey = "", Where where = null, string[] delCache = null) {
			int value = new SQL().Database(dbkey).Update(EmailList._)
				.SetP(EmailList._NickName, emailList.NickName)
				.SetP(EmailList._LastSendStatus, emailList.LastSendStatus)
				.SetP(EmailList._LastSendError, emailList.LastSendError)
				.SetP(EmailList._LastSendTime, emailList.LastSendTime)
				.SetP(EmailList._LastSendSmtp, emailList.LastSendSmtp)
				.SetP(EmailList._SendCount, emailList.SendCount)
				.SetP(EmailList._CreateTime, emailList.CreateTime)
				.SetP(EmailList._ex0, emailList.ex0)
				.SetP(EmailList._ex1, emailList.ex1)
				.SetP(EmailList._ex2, emailList.ex2)
				.SetP(EmailList._ex3, emailList.ex3)
				.SetP(EmailList._ex4, emailList.ex4)
				.SetP(EmailList._ex5, emailList.ex5)
				.SetP(EmailList._ex6, emailList.ex6)
				.SetP(EmailList._ex7, emailList.ex7)
				.SetP(EmailList._ex8, emailList.ex8)
				.Where(new Where()
					.And(EmailList._EmailAddress, "(" + emailAddressList .Join(",") + ")", Operator.In)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.EmailListCache_", delCache);
			return true;
		}
		/// <summary>
		/// �޸Ķ�����¼
		/// </summary>
		/// <param name="emailAddressList">���͵�Email�б��á�,���ŷָ�</param>
		/// <param name="emailList">ʵ����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool UpdateByIDList(IEnumerable<string> emailAddressList,  EmailList emailList, string dbkey) {
			return UpdateByIDList(emailAddressList,  emailList, dbkey, null, null);
		}
		/// <summary>
		/// ɾ����¼
		/// </summary>
		/// <param name="emailAddress">���͵�Email</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">ɾ���ɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByID(string emailAddress,  string dbkey = "", Where where = null, string[] delCache = null) {
			if (emailAddress.IsNullEmpty()) return false;
			int value = new SQL().Database(dbkey).Delete(EmailList._)
				.Where(new Where()
					.AndP(EmailList._EmailAddress, emailAddress, Operator.Equal, true)
				).Where(where).ToExec();
			if (value != 1) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.EmailListCache_", delCache);
			return true;
		}
		/// <summary>
		/// ɾ����¼
		/// </summary>
		/// <param name="emailAddress">���͵�Email</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByID(string emailAddress, string dbkey) {
			return DeleteByID(emailAddress,  dbkey, null, null);
		}
		/// <summary>
		/// ɾ��������¼
		/// </summary>
		/// <param name="emailAddressList">���͵�Email�б��á�,���ŷָ�</param>
		/// <param name="where">ɾ��ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByIDList(IEnumerable<string> emailAddressList,  string dbkey = "", Where where = null, string[] delCache = null) {
			int value = new SQL().Database(dbkey).Delete(EmailList._)
				.Where(new Where()
					.And(EmailList._EmailAddress, "(" + emailAddressList .Join(",") + ")", Operator.In)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.EmailListCache_", delCache);
			return true;
		}
		/// <summary>
		/// ɾ��������¼
		/// </summary>
		/// <param name="emailAddressList">���͵�Email�б��á�,���ŷָ�</param>
		/// <param name="where">ɾ��ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByIDList(IEnumerable<string> emailAddressList, string dbkey) {
			return DeleteByIDList(emailAddressList,  dbkey, null, null);
		}
		/// <summary>
		/// ��¼�Ƿ����
		/// </summary>
		/// <param name="emailAddress">���͵�Email</param>
		/// <param name="where">����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>��¼�Ƿ����</returns>
		public static bool IsExistByID(string emailAddress,  string dbkey = "", Where where = null) {
			long value = new SQL().Database(dbkey).Count(EmailList._EmailAddress).From(EmailList._)
				.Where(new Where()
					.AndP(EmailList._EmailAddress, emailAddress, Operator.Equal)
				).Where(where).ToScalar().ToString().ToBigInt();
			return value == 1;
		}
		/// <summary>
		/// ��¼�Ƿ����
		/// </summary>
		/// <param name="emailAddress">���͵�Email</param>
		/// <returns>��¼�Ƿ����</returns>
		public static bool IsExistByID(string emailAddress, string dbkey) {
			return IsExistByID(emailAddress,  dbkey, null);
		}
		/// <summary>
		/// ��������ѯ���������ݵ�ʵ����
		/// </summary>
		/// <param name="emailAddress">���͵�Email</param>
		/// <param name="where">����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱ���ȡ����key</param>
		/// <returns>���ص�����¼��ʵ����</returns>
		public static EmailList SelectByID(string emailAddress,  string dbkey = "", Where where = null) {
			string cacheNameKey = "TH.Mailer.EmailListCache_SelectByID_{0}".FormatWith(emailAddress + "_" +  "_" + where);
			return Cache2.Get<EmailList>(cacheNameKey, cacheSeconds, () => {
				EmailList obj = new SQL().Database(dbkey).From(EmailList._)
					.Select(EmailList._EmailAddress)
					.Select(EmailList._NickName)
					.Select(EmailList._LastSendStatus)
					.Select(EmailList._LastSendError)
					.Select(EmailList._LastSendTime)
					.Select(EmailList._LastSendSmtp)
					.Select(EmailList._SendCount)
					.Select(EmailList._CreateTime)
					.Select(EmailList._ex0)
					.Select(EmailList._ex1)
					.Select(EmailList._ex2)
					.Select(EmailList._ex3)
					.Select(EmailList._ex4)
					.Select(EmailList._ex5)
					.Select(EmailList._ex6)
					.Select(EmailList._ex7)
					.Select(EmailList._ex8)
					.Where(new Where()
						.AndP(EmailList._EmailAddress, emailAddress, Operator.Equal)
					).Where(where).ToEntity<EmailList>();
				return obj;
			});
		}
		/// <summary>
		/// ��������ѯ���������ݵ�ʵ����
		/// </summary>
		/// <param name="emailAddress">���͵�Email</param>
		/// <returns>���ص�����¼��ʵ����</returns>
		public static EmailList SelectByID(string emailAddress, string dbkey) {
			return SelectByID(emailAddress,  dbkey, null);
		}
		/// <summary>
		/// �����������ѯ�Ļ���
		/// </summary>
		public static void ClearCacheSelectByID(string emailAddress,  Where where = null) {
			string cacheName = "TH.Mailer.EmailListCache_SelectByID_{0}";
			string cacheNameKey = string.Format(cacheName, emailAddress + "_" +  "_" + where);
			Cache2.Remove(cacheNameKey);
		}
		/// <summary>
		/// ��ѯ���ݣ�����ҳ
		/// </summary>
		/// <param name="pageIndex">��ǰ�ڼ�ҳ����1��ʼ</param>
		/// <param name="pageSize">ÿҳ��¼��</param>
		/// <param name="totalRecords">�����ܼ�¼��</param>
		/// <param name="where">����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="order">�����ֶΣ����ӡ�order by��</param>
		/// <param name="fieldList">������Ҫ���ص��ֶ�</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱ���ȡ����key</param>
		/// <param name="pageEnum">ʹ�����ַ�ҳ��ʽ��not_in��max_top��top_top��row_number��mysql��oracle��sqlite��</param>
		/// <returns>����ʵ���¼��</returns>
		public static IList<EmailList> SelectPageList(int pageIndex, int pageSize, out long totalRecords, string dbkey = "", Where where = null, string order = "", string fieldList = "", PagerSQLEnum pageEnum = PagerSQLEnum.sqlite) {
			string cacheNameKey = "TH.Mailer.EmailListCache_SelectPageList_{0}_{1}_{2}_{3}_{4}".FormatWith(pageIndex, pageSize, where, order, fieldList);
			string cacheRecordsKey = "TH.Mailer.EmailListCache_RecordsSelectPageList_{0}_{1}_{2}_{3}_{4}".FormatWith(pageIndex, pageSize, where, order, fieldList);
			IList<EmailList> list = (IList<EmailList>)Cache2.Get(cacheNameKey);
			if (!list.IsNull()) { totalRecords = (int)Cache2.Get(cacheRecordsKey); return list; }

			using (PagerSQLHelper s = new PagerSQLHelper(pageEnum)) {
				list = s.GetSQL(pageIndex, pageSize, EmailList._, EmailList._EmailAddress, fieldList.IfNullOrEmpty("[EmailAddress],[NickName],[LastSendStatus],[LastSendError],[LastSendTime],[LastSendSmtp],[SendCount],[CreateTime],[ex0],[ex1],[ex2],[ex3],[ex4],[ex5],[ex6],[ex7],[ex8],"), where, "", order).ToList<EmailList>(out totalRecords, dbkey);
			}
			Cache2.Insert(cacheNameKey, list, cacheSeconds);
			Cache2.Insert(cacheRecordsKey, totalRecords, cacheSeconds);
			return list;
		}
		/// <summary>
		/// ��ѯ��¼������ҳ
		/// </summary>
		/// <param name="pageIndex">��ǰ�ڼ�ҳ����1��ʼ</param>
		/// <param name="pageSize">ÿҳ��¼��</param>
		/// <param name="totalRecords">�����ܼ�¼��</param>
		/// <returns>����ʵ���¼��</returns>
		public static IList<EmailList> SelectPageList(int pageIndex, int pageSize, out long totalRecords, string dbkey) {
			return SelectPageList(pageIndex, pageSize, out totalRecords, dbkey, null, "", "", PagerSQLEnum.sqlite);
		}
		/// <summary>
		/// �����ѯ��¼������ҳ�Ļ���
		/// </summary>
		public static void ClearCacheSelectPageList() {
			string cacheNameKey = "TH.Mailer.EmailListCache_SelectPageList_(.+?)";
			string cacheRecordsKey = "TH.Mailer.EmailListCache_RecordsSelectPageList_(.+?)";
			Cache2.RemoveByPattern(cacheNameKey);
			Cache2.RemoveByPattern(cacheRecordsKey);
		}
		/// <summary>
		/// ��ѯ���м�¼
		/// </summary>
		/// <param name="where">����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="order">�����ֶΣ����ӡ�order by��</param>
		/// <param name="fieldList">������Ҫ���ص��ֶ�</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱ���ȡ����key</param>
		/// <returns>����ʵ���¼��</returns>
		public static IList<EmailList> SelectListByAll(string dbkey = "", Where where = null, string order = "", string fieldList = "") {
			string cacheNameKey = "TH.Mailer.EmailListCache_SelectListByAll_{0}_{1}_{2}".FormatWith(where, order, fieldList);
			return Cache2.Get<IList<EmailList>>(cacheNameKey, cacheSeconds, () => {
				IList<EmailList> list = new List<EmailList>();
				if (fieldList.IsNullEmpty()) {
					list = new SQL().Database(dbkey).From(EmailList._)
						.Select(EmailList._EmailAddress)
						.Select(EmailList._NickName)
						.Select(EmailList._LastSendStatus)
						.Select(EmailList._LastSendError)
						.Select(EmailList._LastSendTime)
						.Select(EmailList._LastSendSmtp)
						.Select(EmailList._SendCount)
						.Select(EmailList._CreateTime)
						.Select(EmailList._ex0)
						.Select(EmailList._ex1)
						.Select(EmailList._ex2)
						.Select(EmailList._ex3)
						.Select(EmailList._ex4)
						.Select(EmailList._ex5)
						.Select(EmailList._ex6)
						.Select(EmailList._ex7)
						.Select(EmailList._ex8)
						.Where(where).Order(order).ToList<EmailList>();
				} else {
					list = new SQL().Database(dbkey).From(EmailList._).Select(fieldList).Where(where).Order(order).ToList<EmailList>();
				}
				return list;
			});
		}
		/// <summary>
		/// ��ѯ���м�¼
		/// </summary>
		/// <returns>����ʵ���¼��</returns>
		public static IList<EmailList> SelectListByAll(string dbkey) {
			return SelectListByAll(dbkey, null, "", "");
		}
		/// <summary>
		/// ɾ�����м�¼
		/// </summary>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱ���ȡ����key</param>
		/// <returns>����ʵ���¼��</returns>
		public static bool RemoveAll(string dbkey = "") {
			return (new SQL().Database(dbkey).Delete(EmailList._).ToExec()) > 0;
		}
		/// <summary>
		/// �����ѯ���м�¼�Ļ���
		/// </summary>
		public static void ClearCacheSelectListByAll() {
			//Cache2.Remove("TH.Mailer.EmailListCache_SelectListByAll___");
			Cache2.RemoveByPattern("TH.Mailer.EmailListCache_SelectListByAll_(.+?)");
		}
		/// <summary>
		/// ������л���
		/// </summary>
		public static void ClearCacheAll() {
			Cache2.RemoveByPattern("TH.Mailer.EmailListCache_(.+?)");
		}
	}
}

