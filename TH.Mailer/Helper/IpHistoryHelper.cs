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
	public partial class IpHistoryHelper {
		/// <summary>
		/// ��������� x 5
		/// </summary>
		public static int cacheSeconds = 1440;
		/// <summary>
		/// ��Ӽ�¼
		/// </summary>
		/// <param name="ipHistory">ʵ����</param>
		/// <param name="delCache">��ӳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>����Ƿ�ɹ�</returns>
		public static bool Insert(IpHistory ipHistory, string dbkey = "", string[] delCache = null) {
			int obj = new SQL().Database(dbkey).Insert(IpHistory._)
				.ValueP(IpHistory._IP, ipHistory.IP)
				.ValueP(IpHistory._CreateTime, ipHistory.CreateTime)
				.ToExec();
			if (delCache.IsNull()) return obj == 1;
			Cache2.Remove("TH.Mailer.IpHistoryCache_", delCache);
			return obj == 1;
		}
		/// <summary>
		/// ��Ӽ�¼
		/// </summary>
		/// <param name="ipHistory">ʵ����</param>
		/// <returns>����Ƿ�ɹ�</returns>
		public static bool Insert(IpHistory ipHistory, string dbkey) {
			return Insert(ipHistory, dbkey, null);
		}
		/// <summary>
		/// �޸ļ�¼
		/// </summary>
		/// <param name="ipHistory">ʵ����</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool Update(IpHistory ipHistory, string dbkey = "", Where where = null, string[] delCache = null) {
			if (ipHistory.IP.IsNullEmpty()) return false;
			int value = new SQL().Database(dbkey).Update(IpHistory._)
				.SetP(IpHistory._CreateTime, ipHistory.CreateTime)
				.Where(new Where()
					.AndP(IpHistory._IP, ipHistory.IP, Operator.Equal, true)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.IpHistoryCache_", delCache);
			return true;
		}
		/// <summary>
		/// �޸ļ�¼
		/// </summary>
		/// <param name="ipHistory">ʵ����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool Update(IpHistory ipHistory, string dbkey) {
			return Update(ipHistory, dbkey, null, null);
		}
		/// <summary>
		/// �޸Ķ�����¼
		/// </summary>
		/// <param name="iPList">IP��ַ�б��á�,���ŷָ�</param>
		/// <param name="ipHistory">ʵ����</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool UpdateByIDList(IEnumerable<string> iPList,  IpHistory ipHistory, string dbkey = "", Where where = null, string[] delCache = null) {
			int value = new SQL().Database(dbkey).Update(IpHistory._)
				.SetP(IpHistory._CreateTime, ipHistory.CreateTime)
				.Where(new Where()
					.And(IpHistory._IP, "(" + iPList .Join(",") + ")", Operator.In)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.IpHistoryCache_", delCache);
			return true;
		}
		/// <summary>
		/// �޸Ķ�����¼
		/// </summary>
		/// <param name="iPList">IP��ַ�б��á�,���ŷָ�</param>
		/// <param name="ipHistory">ʵ����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool UpdateByIDList(IEnumerable<string> iPList,  IpHistory ipHistory, string dbkey) {
			return UpdateByIDList(iPList,  ipHistory, dbkey, null, null);
		}
		/// <summary>
		/// ɾ����¼
		/// </summary>
		/// <param name="iP">IP��ַ</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">ɾ���ɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByID(string iP,  string dbkey = "", Where where = null, string[] delCache = null) {
			if (iP.IsNullEmpty()) return false;
			int value = new SQL().Database(dbkey).Delete(IpHistory._)
				.Where(new Where()
					.AndP(IpHistory._IP, iP, Operator.Equal, true)
				).Where(where).ToExec();
			if (value != 1) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.IpHistoryCache_", delCache);
			return true;
		}
		/// <summary>
		/// ɾ����¼
		/// </summary>
		/// <param name="iP">IP��ַ</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByID(string iP, string dbkey) {
			return DeleteByID(iP,  dbkey, null, null);
		}
		/// <summary>
		/// ɾ��������¼
		/// </summary>
		/// <param name="iPList">IP��ַ�б��á�,���ŷָ�</param>
		/// <param name="where">ɾ��ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByIDList(IEnumerable<string> iPList,  string dbkey = "", Where where = null, string[] delCache = null) {
			int value = new SQL().Database(dbkey).Delete(IpHistory._)
				.Where(new Where()
					.And(IpHistory._IP, "(" + iPList .Join(",") + ")", Operator.In)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.IpHistoryCache_", delCache);
			return true;
		}
		/// <summary>
		/// ɾ��������¼
		/// </summary>
		/// <param name="iPList">IP��ַ�б��á�,���ŷָ�</param>
		/// <param name="where">ɾ��ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByIDList(IEnumerable<string> iPList, string dbkey) {
			return DeleteByIDList(iPList,  dbkey, null, null);
		}
		/// <summary>
		/// ��¼�Ƿ����
		/// </summary>
		/// <param name="iP">IP��ַ</param>
		/// <param name="where">����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>��¼�Ƿ����</returns>
		public static bool IsExistByID(string iP,  string dbkey = "", Where where = null) {
			long value = new SQL().Database(dbkey).Count(IpHistory._IP).From(IpHistory._)
				.Where(new Where()
					.AndP(IpHistory._IP, iP, Operator.Equal)
				).Where(where).ToScalar().ToString().ToBigInt();
			return value == 1;
		}
		/// <summary>
		/// ��¼�Ƿ����
		/// </summary>
		/// <param name="iP">IP��ַ</param>
		/// <returns>��¼�Ƿ����</returns>
		public static bool IsExistByID(string iP, string dbkey) {
			return IsExistByID(iP,  dbkey, null);
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
		public static IList<IpHistory> SelectPageList(int pageIndex, int pageSize, out int totalRecords, string dbkey = "", Where where = null, string order = "", string fieldList = "", PagerSQLEnum pageEnum = PagerSQLEnum.sqlite) {
			totalRecords = 0;
			string cacheNameKey = "TH.Mailer.IpHistoryCache_SelectPageList_{0}_{1}_{2}_{3}_{4}".FormatWith(pageIndex, pageSize, where, order, fieldList);
			string cacheRecordsKey = "TH.Mailer.IpHistoryCache_RecordsSelectPageList_{0}_{1}_{2}_{3}_{4}".FormatWith(pageIndex, pageSize, where, order, fieldList);
			IList<IpHistory> list = (IList<IpHistory>)Cache2.Get(cacheNameKey);
			if (!list.IsNull()) { totalRecords = (int)Cache2.Get(cacheRecordsKey); return list; }

			using (PagerSQLHelper s = new PagerSQLHelper(pageEnum)) {
				PagerSql sql = s.GetSQL(pageIndex, pageSize, IpHistory._, IpHistory._IP, fieldList.IfNullOrEmpty("[IP],[CreateTime],"), where, "", order);
				IDataReader dr = Data.Pool(dbkey).GetDbDataReader(sql.DataSql + ";" + sql.CountSql);
				if (dr.IsNull()) return list;
				list = dr.ToList<IpHistory>(false);
				bool result = dr.NextResult();
				if (result) { dr.Read(); totalRecords = dr[0].ToString().ToInt(); }
				dr.Close (); dr.Dispose(); dr = null;
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
		public static IList<IpHistory> SelectPageList(int pageIndex, int pageSize, out int totalRecords, string dbkey) {
			return SelectPageList(pageIndex, pageSize, out totalRecords, dbkey, null, "", "", PagerSQLEnum.sqlite);
		}
		/// <summary>
		/// �����ѯ��¼������ҳ�Ļ���
		/// </summary>
		public static void ClearCacheSelectPageList() {
			string cacheNameKey = "TH.Mailer.IpHistoryCache_SelectPageList_(.+?)";
			string cacheRecordsKey = "TH.Mailer.IpHistoryCache_RecordsSelectPageList_(.+?)";
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
		public static IList<IpHistory> SelectListByAll(string dbkey = "", Where where = null, string order = "", string fieldList = "") {
			string cacheNameKey = "TH.Mailer.IpHistoryCache_SelectListByAll_{0}_{1}_{2}".FormatWith(where, order, fieldList);
			return Cache2.Get<IList<IpHistory>>(cacheNameKey, cacheSeconds, () => {
				IList<IpHistory> list = new List<IpHistory>();
				if (fieldList.IsNullEmpty()) {
					list = new SQL().Database(dbkey).From(IpHistory._)
						.Select(IpHistory._IP)
						.Select(IpHistory._CreateTime)
						.Where(where).Order(order).ToList<IpHistory>();
				} else {
					list = new SQL().Database(dbkey).From(IpHistory._).Select(fieldList).Where(where).Order(order).ToList<IpHistory>();
				}
				return list;
			});
		}
		/// <summary>
		/// ��ѯ���м�¼
		/// </summary>
		/// <returns>����ʵ���¼��</returns>
		public static IList<IpHistory> SelectListByAll(string dbkey) {
			return SelectListByAll(dbkey, null, "", "");
		}
		/// <summary>
		/// ɾ�����м�¼
		/// </summary>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱ���ȡ����key</param>
		/// <returns>����ʵ���¼��</returns>
		public static bool RemoveAll(string dbkey = "") {
			return (new SQL().Database(dbkey).Delete(IpHistory._).ToExec()) > 0;
		}
		/// <summary>
		/// �����ѯ���м�¼�Ļ���
		/// </summary>
		public static void ClearCacheSelectListByAll() {
			//Cache2.Remove("TH.Mailer.IpHistoryCache_SelectListByAll___");
			Cache2.RemoveByPattern("TH.Mailer.IpHistoryCache_SelectListByAll_(.+?)");
		}
		/// <summary>
		/// ������л���
		/// </summary>
		public static void ClearCacheAll() {
			Cache2.RemoveByPattern("TH.Mailer.IpHistoryCache_(.+?)");
		}
	}
}

