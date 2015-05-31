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
	public partial class SmtpListHelper {
		/// <summary>
		/// ��������� x 5
		/// </summary>
		public static int cacheSeconds = 1440;
		/// <summary>
		/// ��Ӽ�¼
		/// </summary>
		/// <param name="smtpList">ʵ����</param>
		/// <param name="delCache">��ӳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>����Ƿ�ɹ�</returns>
		public static bool Insert(SmtpList smtpList, string dbkey = "", string[] delCache = null) {
			int obj = new SQL().Database(dbkey).Insert(SmtpList._)
				.ValueP(SmtpList._SmtpServer, smtpList.SmtpServer)
				.ValueP(SmtpList._SmtpPort, smtpList.SmtpPort)
				.ValueP(SmtpList._UserName, smtpList.UserName)
				.ValueP(SmtpList._SPassword, smtpList.SPassword)
				.ValueP(SmtpList._SSL, smtpList.SSL)
				.ValueP(SmtpList._Status, smtpList.Status)
				.ValueP(SmtpList._Sends, smtpList.Sends)
				.ValueP(SmtpList._SendFails, smtpList.SendFails)
				.ValueP(SmtpList._CreateTime, smtpList.CreateTime)
				.ToExec();
			if (delCache.IsNull()) return obj == 1;
			Cache2.Remove("TH.Mailer.SmtpListCache_", delCache);
			return obj == 1;
		}
		/// <summary>
		/// ��Ӽ�¼
		/// </summary>
		/// <param name="smtpList">ʵ����</param>
		/// <returns>����Ƿ�ɹ�</returns>
		public static bool Insert(SmtpList smtpList, string dbkey) {
			return Insert(smtpList, dbkey, null);
		}
		/// <summary>
		/// �޸ļ�¼
		/// </summary>
		/// <param name="smtpList">ʵ����</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool Update(SmtpList smtpList, string dbkey = "", Where where = null, string[] delCache = null) {
			if (smtpList.SmtpServer.IsNullEmpty()  && smtpList.SmtpPort.IsNull()  && smtpList.UserName.IsNullEmpty()) return false;
			int value = new SQL().Database(dbkey).Update(SmtpList._)
				.SetP(SmtpList._SPassword, smtpList.SPassword)
				.SetP(SmtpList._SSL, smtpList.SSL)
				.SetP(SmtpList._Status, smtpList.Status)
				.SetP(SmtpList._Sends, smtpList.Sends)
				.SetP(SmtpList._SendFails, smtpList.SendFails)
				.SetP(SmtpList._CreateTime, smtpList.CreateTime)
				.Where(new Where()
					.AndP(SmtpList._SmtpServer, smtpList.SmtpServer, Operator.Equal, true)
					.AndP(SmtpList._SmtpPort, smtpList.SmtpPort, Operator.Equal, true)
					.AndP(SmtpList._UserName, smtpList.UserName, Operator.Equal, true)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.SmtpListCache_", delCache);
			return true;
		}
		/// <summary>
		/// �޸ļ�¼
		/// </summary>
		/// <param name="smtpList">ʵ����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool Update(SmtpList smtpList, string dbkey) {
			return Update(smtpList, dbkey, null, null);
		}
 		/// <summary>
		/// ɾ����¼
		/// </summary>
		/// <param name="smtpServer">SMTP������</param>
		/// <param name="smtpPort">SMTP�˿�</param>
		/// <param name="userName">��¼�û���</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">ɾ���ɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByID(string smtpServer, int? smtpPort, string userName,  string dbkey = "", Where where = null, string[] delCache = null) {
			if (smtpServer.IsNullEmpty()  && smtpPort.IsNull()  && userName.IsNullEmpty()) return false;
			int value = new SQL().Database(dbkey).Delete(SmtpList._)
				.Where(new Where()
					.AndP(SmtpList._SmtpServer, smtpServer, Operator.Equal, true)
					.AndP(SmtpList._SmtpPort, smtpPort, Operator.Equal, true)
					.AndP(SmtpList._UserName, userName, Operator.Equal, true)
				).Where(where).ToExec();
			if (value != 1) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.SmtpListCache_", delCache);
			return true;
		}
		/// <summary>
		/// ɾ����¼
		/// </summary>
		/// <param name="smtpServer">SMTP������</param>
		/// <param name="smtpPort">SMTP�˿�</param>
		/// <param name="userName">��¼�û���</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByID(string smtpServer, int? smtpPort, string userName, string dbkey) {
			return DeleteByID(smtpServer, smtpPort, userName,  dbkey, null, null);
		}
		/// <summary>
		/// ɾ����¼
		/// </summary>
		/// <param name="smtpServer">SMTP������</param>
		/// <param name="smtpPort">SMTP�˿�</param>
		/// <param name="userName">��¼�û���</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">ɾ���ɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByID(string smtpServer, int smtpPort, string userName,  string dbkey = "", Where where = null, string[] delCache = null) {
			return DeleteByID((string)smtpServer, (int?)smtpPort, (string)userName,  dbkey, where, delCache);
		}
		/// <summary>
		/// ɾ����¼
		/// </summary>
		/// <param name="smtpServer">SMTP������</param>
		/// <param name="smtpPort">SMTP�˿�</param>
		/// <param name="userName">��¼�û���</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByID(string smtpServer, int smtpPort, string userName, string dbkey) {
			return DeleteByID((string)smtpServer, (int?)smtpPort, (string)userName,  dbkey, null, null);
		}
		/// <summary>
		/// ��¼�Ƿ����
		/// </summary>
		/// <param name="smtpServer">SMTP������</param>
		/// <param name="smtpPort">SMTP�˿�</param>
		/// <param name="userName">��¼�û���</param>
		/// <param name="where">����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>��¼�Ƿ����</returns>
		public static bool IsExistByID(string smtpServer, int smtpPort, string userName,  string dbkey = "", Where where = null) {
			long value = new SQL().Database(dbkey).Count(SmtpList._SmtpServer).From(SmtpList._)
				.Where(new Where()
					.AndP(SmtpList._SmtpServer, smtpServer, Operator.Equal)
					.AndP(SmtpList._SmtpPort, smtpPort, Operator.Equal)
					.AndP(SmtpList._UserName, userName, Operator.Equal)
				).Where(where).ToScalar().ToString().ToBigInt();
			return value == 1;
		}
		/// <summary>
		/// ��¼�Ƿ����
		/// </summary>
		/// <param name="smtpServer">SMTP������</param>
		/// <param name="smtpPort">SMTP�˿�</param>
		/// <param name="userName">��¼�û���</param>
		/// <returns>��¼�Ƿ����</returns>
		public static bool IsExistByID(string smtpServer, int smtpPort, string userName, string dbkey) {
			return IsExistByID(smtpServer, smtpPort, userName,  dbkey, null);
		}
		/// <summary>
		/// ��������ѯ���������ݵ�ʵ����
		/// </summary>
		/// <param name="smtpServer">SMTP������</param>
		/// <param name="smtpPort">SMTP�˿�</param>
		/// <param name="userName">��¼�û���</param>
		/// <param name="where">����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱ���ȡ����key</param>
		/// <returns>���ص�����¼��ʵ����</returns>
		public static SmtpList SelectByID(string smtpServer, int smtpPort, string userName,  string dbkey = "", Where where = null) {
			string cacheNameKey = "TH.Mailer.SmtpListCache_SelectByID_{0}".FormatWith(smtpServer + "_" + smtpPort + "_" + userName + "_" +  "_" + where);
			return Cache2.Get<SmtpList>(cacheNameKey, cacheSeconds, () => {
				SmtpList obj = new SQL().Database(dbkey).From(SmtpList._)
					.Select(SmtpList._SmtpServer)
					.Select(SmtpList._SmtpPort)
					.Select(SmtpList._UserName)
					.Select(SmtpList._SPassword)
					.Select(SmtpList._SSL)
					.Select(SmtpList._Status)
					.Select(SmtpList._Sends)
					.Select(SmtpList._SendFails)
					.Select(SmtpList._CreateTime)
					.Where(new Where()
						.AndP(SmtpList._SmtpServer, smtpServer, Operator.Equal)
						.AndP(SmtpList._SmtpPort, smtpPort, Operator.Equal)
						.AndP(SmtpList._UserName, userName, Operator.Equal)
					).Where(where).ToEntity<SmtpList>();
				return obj;
			});
		}
		/// <summary>
		/// ��������ѯ���������ݵ�ʵ����
		/// </summary>
		/// <param name="smtpServer">SMTP������</param>
		/// <param name="smtpPort">SMTP�˿�</param>
		/// <param name="userName">��¼�û���</param>
		/// <returns>���ص�����¼��ʵ����</returns>
		public static SmtpList SelectByID(string smtpServer, int smtpPort, string userName, string dbkey) {
			return SelectByID(smtpServer, smtpPort, userName,  dbkey, null);
		}
		/// <summary>
		/// �����������ѯ�Ļ���
		/// </summary>
		public static void ClearCacheSelectByID(string smtpServer, int smtpPort, string userName,  Where where = null) {
			string cacheName = "TH.Mailer.SmtpListCache_SelectByID_{0}";
			string cacheNameKey = string.Format(cacheName, smtpServer + "_" + smtpPort + "_" + userName + "_" +  "_" + where);
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
		public static IList<SmtpList> SelectPageList(int pageIndex, int pageSize, out long totalRecords, string dbkey = "", Where where = null, string order = "", string fieldList = "", PagerSQLEnum pageEnum = PagerSQLEnum.sqlite) {
			string cacheNameKey = "TH.Mailer.SmtpListCache_SelectPageList_{0}_{1}_{2}_{3}_{4}".FormatWith(pageIndex, pageSize, where, order, fieldList);
			string cacheRecordsKey = "TH.Mailer.SmtpListCache_RecordsSelectPageList_{0}_{1}_{2}_{3}_{4}".FormatWith(pageIndex, pageSize, where, order, fieldList);
			IList<SmtpList> list = (IList<SmtpList>)Cache2.Get(cacheNameKey);
			if (!list.IsNull()) { totalRecords = (int)Cache2.Get(cacheRecordsKey); return list; }

			using (PagerSQLHelper s = new PagerSQLHelper(pageEnum)) {
				list = s.GetSQL(pageIndex, pageSize, SmtpList._, SmtpList._SmtpServer, fieldList.IfNullOrEmpty("[SmtpServer],[SmtpPort],[UserName],[SPassword],[SSL],[Status],[Sends],[SendFails],[CreateTime],"), where, "", order).ToList<SmtpList>(out totalRecords, dbkey);
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
		public static IList<SmtpList> SelectPageList(int pageIndex, int pageSize, out long totalRecords, string dbkey) {
			return SelectPageList(pageIndex, pageSize, out totalRecords, dbkey, null, "", "", PagerSQLEnum.sqlite);
		}
		/// <summary>
		/// �����ѯ��¼������ҳ�Ļ���
		/// </summary>
		public static void ClearCacheSelectPageList() {
			string cacheNameKey = "TH.Mailer.SmtpListCache_SelectPageList_(.+?)";
			string cacheRecordsKey = "TH.Mailer.SmtpListCache_RecordsSelectPageList_(.+?)";
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
		public static IList<SmtpList> SelectListByAll(string dbkey = "", Where where = null, string order = "", string fieldList = "") {
			string cacheNameKey = "TH.Mailer.SmtpListCache_SelectListByAll_{0}_{1}_{2}".FormatWith(where, order, fieldList);
			return Cache2.Get<IList<SmtpList>>(cacheNameKey, cacheSeconds, () => {
				IList<SmtpList> list = new List<SmtpList>();
				if (fieldList.IsNullEmpty()) {
					list = new SQL().Database(dbkey).From(SmtpList._)
						.Select(SmtpList._SmtpServer)
						.Select(SmtpList._SmtpPort)
						.Select(SmtpList._UserName)
						.Select(SmtpList._SPassword)
						.Select(SmtpList._SSL)
						.Select(SmtpList._Status)
						.Select(SmtpList._Sends)
						.Select(SmtpList._SendFails)
						.Select(SmtpList._CreateTime)
						.Where(where).Order(order).ToList<SmtpList>();
				} else {
					list = new SQL().Database(dbkey).From(SmtpList._).Select(fieldList).Where(where).Order(order).ToList<SmtpList>();
				}
				return list;
			});
		}
		/// <summary>
		/// ��ѯ���м�¼
		/// </summary>
		/// <returns>����ʵ���¼��</returns>
		public static IList<SmtpList> SelectListByAll(string dbkey) {
			return SelectListByAll(dbkey, null, "", "");
		}
		/// <summary>
		/// ɾ�����м�¼
		/// </summary>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱ���ȡ����key</param>
		/// <returns>����ʵ���¼��</returns>
		public static bool RemoveAll(string dbkey = "") {
			return (new SQL().Database(dbkey).Delete(SmtpList._).ToExec()) > 0;
		}
		/// <summary>
		/// �����ѯ���м�¼�Ļ���
		/// </summary>
		public static void ClearCacheSelectListByAll() {
			//Cache2.Remove("TH.Mailer.SmtpListCache_SelectListByAll___");
			Cache2.RemoveByPattern("TH.Mailer.SmtpListCache_SelectListByAll_(.+?)");
		}
		/// <summary>
		/// ������л���
		/// </summary>
		public static void ClearCacheAll() {
			Cache2.RemoveByPattern("TH.Mailer.SmtpListCache_(.+?)");
		}
	}
}

