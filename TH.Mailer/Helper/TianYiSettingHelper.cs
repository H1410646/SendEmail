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
	/// �����������ò�����
	///
	/// �޸ļ�¼
	///	 2013-06-03 �汾��1.0 ϵͳ�Զ���������
	///
	/// </summary>
	public partial class TianYiSettingHelper {
		/// <summary>
		/// �����������û�������� x 5
		/// </summary>
		public static int cacheSeconds = 1440;
		/// <summary>
		/// ��������������Ӽ�¼
		/// </summary>
		/// <param name="tianYiSetting">������������ʵ����</param>
		/// <param name="delCache">��ӳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>����Ƿ�ɹ�</returns>
		public static bool Insert(TianYiSetting tianYiSetting, string dbkey = "", string[] delCache = null) {
			int obj = new SQL().Database(dbkey).Insert(TianYiSetting._)
				.ValueP(TianYiSetting._TianYiID, tianYiSetting.TianYiID)
				.ValueP(TianYiSetting._TianYiExePath, tianYiSetting.TianYiExePath)
				.ToExec();
			if (delCache.IsNull()) return obj == 1;
			Cache2.Remove("TH.Mailer.TianYiSettingCache_", delCache);
			return obj == 1;
		}
		/// <summary>
		/// ��������������Ӽ�¼
		/// </summary>
		/// <param name="tianYiSetting">������������ʵ����</param>
		/// <returns>����Ƿ�ɹ�</returns>
		public static bool Insert(TianYiSetting tianYiSetting, string dbkey) {
			return Insert(tianYiSetting, dbkey, null);
		}
		/// <summary>
		/// �������������޸ļ�¼
		/// </summary>
		/// <param name="tianYiSetting">������������ʵ����</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool Update(TianYiSetting tianYiSetting, string dbkey = "", Where where = null, string[] delCache = null) {
			if (tianYiSetting.TianYiID.IsNull()) return false;
			int value = new SQL().Database(dbkey).Update(TianYiSetting._)
				.SetP(TianYiSetting._TianYiExePath, tianYiSetting.TianYiExePath)
				.Where(new Where()
					.AndP(TianYiSetting._TianYiID, tianYiSetting.TianYiID, Operator.Equal, true)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.TianYiSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// �������������޸ļ�¼
		/// </summary>
		/// <param name="tianYiSetting">������������ʵ����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool Update(TianYiSetting tianYiSetting, string dbkey) {
			return Update(tianYiSetting, dbkey, null, null);
		}
		/// <summary>
		/// �������������޸Ķ�����¼
		/// </summary>
		/// <param name="tianYiIDList">�����������ñ���б��á�,���ŷָ�</param>
		/// <param name="tianYiSetting">������������ʵ����</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool UpdateByIDList(IEnumerable<int> tianYiIDList,  TianYiSetting tianYiSetting, string dbkey = "", Where where = null, string[] delCache = null) {
			int value = new SQL().Database(dbkey).Update(TianYiSetting._)
				.SetP(TianYiSetting._TianYiExePath, tianYiSetting.TianYiExePath)
				.Where(new Where()
					.And(TianYiSetting._TianYiID, "(" + tianYiIDList .Join(",") + ")", Operator.In)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.TianYiSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// �������������޸Ķ�����¼
		/// </summary>
		/// <param name="tianYiIDList">�����������ñ���б��á�,���ŷָ�</param>
		/// <param name="tianYiSetting">������������ʵ����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool UpdateByIDList(IEnumerable<int> tianYiIDList,  TianYiSetting tianYiSetting, string dbkey) {
			return UpdateByIDList(tianYiIDList,  tianYiSetting, dbkey, null, null);
		}
 		/// <summary>
		/// ������������ɾ����¼
		/// </summary>
		/// <param name="tianYiID">�����������ñ��</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">ɾ���ɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByID(int? tianYiID,  string dbkey = "", Where where = null, string[] delCache = null) {
			if (tianYiID.IsNull()) return false;
			int value = new SQL().Database(dbkey).Delete(TianYiSetting._)
				.Where(new Where()
					.AndP(TianYiSetting._TianYiID, tianYiID, Operator.Equal, true)
				).Where(where).ToExec();
			if (value != 1) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.TianYiSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// ������������ɾ����¼
		/// </summary>
		/// <param name="tianYiID">�����������ñ��</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByID(int? tianYiID, string dbkey) {
			return DeleteByID(tianYiID,  dbkey, null, null);
		}
		/// <summary>
		/// ������������ɾ����¼
		/// </summary>
		/// <param name="tianYiID">�����������ñ��</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">ɾ���ɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByID(int tianYiID,  string dbkey = "", Where where = null, string[] delCache = null) {
			return DeleteByID((int?)tianYiID,  dbkey, where, delCache);
		}
		/// <summary>
		/// ������������ɾ����¼
		/// </summary>
		/// <param name="tianYiID">�����������ñ��</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByID(int tianYiID, string dbkey) {
			return DeleteByID((int?)tianYiID,  dbkey, null, null);
		}
		/// <summary>
		/// ������������ɾ��������¼
		/// </summary>
		/// <param name="tianYiIDList">�����������ñ���б��á�,���ŷָ�</param>
		/// <param name="where">ɾ��ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByIDList(IEnumerable<int> tianYiIDList,  string dbkey = "", Where where = null, string[] delCache = null) {
			int value = new SQL().Database(dbkey).Delete(TianYiSetting._)
				.Where(new Where()
					.And(TianYiSetting._TianYiID, "(" + tianYiIDList .Join(",") + ")", Operator.In)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.TianYiSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// ������������ɾ��������¼
		/// </summary>
		/// <param name="tianYiIDList">�����������ñ���б��á�,���ŷָ�</param>
		/// <param name="where">ɾ��ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByIDList(IEnumerable<int> tianYiIDList, string dbkey) {
			return DeleteByIDList(tianYiIDList,  dbkey, null, null);
		}
		/// <summary>
		/// �����������ð�������ѯ���������ݵ�ʵ����
		/// </summary>
		/// <param name="tianYiID">�����������ñ��</param>
		/// <param name="where">����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱ���ȡ����key</param>
		/// <returns>���ص�����¼��ʵ����</returns>
		public static TianYiSetting SelectByID(int tianYiID,  string dbkey = "", Where where = null) {
			string cacheNameKey = "TH.Mailer.TianYiSettingCache_SelectByID_{0}".FormatWith(tianYiID + "_" +  "_" + where);
			return Cache2.Get<TianYiSetting>(cacheNameKey, cacheSeconds, () => {
				TianYiSetting obj = new SQL().Database(dbkey).From(TianYiSetting._)
					.Select(TianYiSetting._TianYiID)
					.Select(TianYiSetting._TianYiExePath)
					.Where(new Where()
						.AndP(TianYiSetting._TianYiID, tianYiID, Operator.Equal)
					).Where(where).ToEntity<TianYiSetting>();
				return obj;
			});
		}
		/// <summary>
		/// �����������ð�������ѯ���������ݵ�ʵ����
		/// </summary>
		/// <param name="tianYiID">�����������ñ��</param>
		/// <returns>���ص�����¼��ʵ����</returns>
		public static TianYiSetting SelectByID(int tianYiID, string dbkey) {
			return SelectByID(tianYiID,  dbkey, null);
		}
		/// <summary>
		/// ��������������ð�������ѯ�Ļ���
		/// </summary>
		public static void ClearCacheSelectByID(int tianYiID,  Where where = null) {
			string cacheName = "TH.Mailer.TianYiSettingCache_SelectByID_{0}";
			string cacheNameKey = string.Format(cacheName, tianYiID + "_" +  "_" + where);
			Cache2.Remove(cacheNameKey);
		}
		/// <summary>
		/// �����������ò�ѯ���ݣ�����ҳ
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
		public static IList<TianYiSetting> SelectPageList(int pageIndex, int pageSize, out long totalRecords, string dbkey = "", Where where = null, string order = "", string fieldList = "", PagerSQLEnum pageEnum = PagerSQLEnum.sqlite) {
			string cacheNameKey = "TH.Mailer.TianYiSettingCache_SelectPageList_{0}_{1}_{2}_{3}_{4}".FormatWith(pageIndex, pageSize, where, order, fieldList);
			string cacheRecordsKey = "TH.Mailer.TianYiSettingCache_RecordsSelectPageList_{0}_{1}_{2}_{3}_{4}".FormatWith(pageIndex, pageSize, where, order, fieldList);
			IList<TianYiSetting> list = (IList<TianYiSetting>)Cache2.Get(cacheNameKey);
			if (!list.IsNull()) { totalRecords = (int)Cache2.Get(cacheRecordsKey); return list; }

			using (PagerSQLHelper s = new PagerSQLHelper(pageEnum)) {
				list = s.GetSQL(pageIndex, pageSize, TianYiSetting._, TianYiSetting._TianYiID, fieldList.IfNullOrEmpty("[TianYiID],[TianYiExePath],"), where, "", order).ToList<TianYiSetting>(out totalRecords, dbkey);
			}
			Cache2.Insert(cacheNameKey, list, cacheSeconds);
			Cache2.Insert(cacheRecordsKey, totalRecords, cacheSeconds);
			return list;
		}
		/// <summary>
		/// �����������ò�ѯ��¼������ҳ
		/// </summary>
		/// <param name="pageIndex">��ǰ�ڼ�ҳ����1��ʼ</param>
		/// <param name="pageSize">ÿҳ��¼��</param>
		/// <param name="totalRecords">�����ܼ�¼��</param>
		/// <returns>����ʵ���¼��</returns>
		public static IList<TianYiSetting> SelectPageList(int pageIndex, int pageSize, out long totalRecords, string dbkey) {
			return SelectPageList(pageIndex, pageSize, out totalRecords, dbkey, null, "", "", PagerSQLEnum.sqlite);
		}
		/// <summary>
		/// ��������������ò�ѯ��¼������ҳ�Ļ���
		/// </summary>
		public static void ClearCacheSelectPageList() {
			string cacheNameKey = "TH.Mailer.TianYiSettingCache_SelectPageList_(.+?)";
			string cacheRecordsKey = "TH.Mailer.TianYiSettingCache_RecordsSelectPageList_(.+?)";
			Cache2.RemoveByPattern(cacheNameKey);
			Cache2.RemoveByPattern(cacheRecordsKey);
		}
		/// <summary>
		/// ������������ɾ�����м�¼
		/// </summary>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱ���ȡ����key</param>
		/// <returns>����ʵ���¼��</returns>
		public static bool RemoveAll(string dbkey = "") {
			return (new SQL().Database(dbkey).Delete(TianYiSetting._).ToExec()) > 0;
		}
		/// <summary>
		/// ��������������ò�ѯ���м�¼�Ļ���
		/// </summary>
		public static void ClearCacheSelectListByAll() {
			//Cache2.Remove("TH.Mailer.TianYiSettingCache_SelectListByAll___");
			Cache2.RemoveByPattern("TH.Mailer.TianYiSettingCache_SelectListByAll_(.+?)");
		}
		/// <summary>
		/// ������������������л���
		/// </summary>
		public static void ClearCacheAll() {
			Cache2.RemoveByPattern("TH.Mailer.TianYiSettingCache_(.+?)");
		}
	}
}

