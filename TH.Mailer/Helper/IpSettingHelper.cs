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
	/// ��ȡIP���ò�����
	///
	/// �޸ļ�¼
	///	 2013-06-03 �汾��1.0 ϵͳ�Զ���������
	///
	/// </summary>
	public partial class IpSettingHelper {
		/// <summary>
		/// ��ȡIP���û�������� x 5
		/// </summary>
		public static int cacheSeconds = 1440;
		/// <summary>
		/// ��ȡIP������Ӽ�¼
		/// </summary>
		/// <param name="ipSetting">��ȡIP����ʵ����</param>
		/// <param name="delCache">��ӳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>������ӳɹ����ID</returns>
		public static Int64 Insert(IpSetting ipSetting, string dbkey = "", string[] delCache = null) {
			object obj = new SQL().Database(dbkey).Insert(IpSetting._)
				.ValueP(IpSetting._IPCID, ipSetting.IPCID)
				.ValueP(IpSetting._WebName, ipSetting.WebName)
				.ValueP(IpSetting._IPUrl, ipSetting.IPUrl)
				.ValueP(IpSetting._IPRegex, ipSetting.IPRegex)
				.ValueP(IpSetting._DataEncode, ipSetting.DataEncode)
				.ToExec();
			if (obj.ToInt() != 1) return 0;
			obj = new SQL().Database(dbkey).From(IpSetting._).Max("IPCID").ToScalar();
			if (obj.IsAllNull()) return 0;
			Int64 value = obj.ToString().ToBigInt();
			if (delCache.IsNull()) return value;
			Cache2.Remove("TH.Mailer.IpSettingCache_", delCache);
			return value;
		}
		/// <summary>
		/// ��ȡIP������Ӽ�¼
		/// </summary>
		/// <param name="ipSetting">��ȡIP����ʵ����</param>
		/// <returns>������ӳɹ����ID</returns>
		public static Int64 Insert(IpSetting ipSetting, string dbkey) {
			return Insert(ipSetting, dbkey, null);
		}
		/// <summary>
		/// ��ȡIP�����޸ļ�¼
		/// </summary>
		/// <param name="ipSetting">��ȡIP����ʵ����</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool Update(IpSetting ipSetting, string dbkey = "", Where where = null, string[] delCache = null) {
			if (ipSetting.IPCID.IsNull()) return false;
			int value = new SQL().Database(dbkey).Update(IpSetting._)
				.SetP(IpSetting._WebName, ipSetting.WebName)
				.SetP(IpSetting._IPUrl, ipSetting.IPUrl)
				.SetP(IpSetting._IPRegex, ipSetting.IPRegex)
				.SetP(IpSetting._DataEncode, ipSetting.DataEncode)
				.Where(new Where()
					.AndP(IpSetting._IPCID, ipSetting.IPCID, Operator.Equal, true)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.IpSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// ��ȡIP�����޸ļ�¼
		/// </summary>
		/// <param name="ipSetting">��ȡIP����ʵ����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool Update(IpSetting ipSetting, string dbkey) {
			return Update(ipSetting, dbkey, null, null);
		}
		/// <summary>
		/// ��ȡIP�����޸Ķ�����¼
		/// </summary>
		/// <param name="iPCIDList">��ȡIP���ñ���б��á�,���ŷָ�</param>
		/// <param name="ipSetting">��ȡIP����ʵ����</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool UpdateByIDList(IEnumerable<Int64> iPCIDList,  IpSetting ipSetting, string dbkey = "", Where where = null, string[] delCache = null) {
			int value = new SQL().Database(dbkey).Update(IpSetting._)
				.SetP(IpSetting._WebName, ipSetting.WebName)
				.SetP(IpSetting._IPUrl, ipSetting.IPUrl)
				.SetP(IpSetting._IPRegex, ipSetting.IPRegex)
				.SetP(IpSetting._DataEncode, ipSetting.DataEncode)
				.Where(new Where()
					.And(IpSetting._IPCID, "(" + iPCIDList .Join(",") + ")", Operator.In)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.IpSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// ��ȡIP�����޸Ķ�����¼
		/// </summary>
		/// <param name="iPCIDList">��ȡIP���ñ���б��á�,���ŷָ�</param>
		/// <param name="ipSetting">��ȡIP����ʵ����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool UpdateByIDList(IEnumerable<Int64> iPCIDList,  IpSetting ipSetting, string dbkey) {
			return UpdateByIDList(iPCIDList,  ipSetting, dbkey, null, null);
		}
 		/// <summary>
		/// ��ȡIP����ɾ����¼
		/// </summary>
		/// <param name="iPCID">��ȡIP���ñ��</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">ɾ���ɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByID(Int64? iPCID,  string dbkey = "", Where where = null, string[] delCache = null) {
			if (iPCID.IsNull()) return false;
			int value = new SQL().Database(dbkey).Delete(IpSetting._)
				.Where(new Where()
					.AndP(IpSetting._IPCID, iPCID, Operator.Equal, true)
				).Where(where).ToExec();
			if (value != 1) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.IpSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// ��ȡIP����ɾ����¼
		/// </summary>
		/// <param name="iPCID">��ȡIP���ñ��</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByID(Int64? iPCID, string dbkey) {
			return DeleteByID(iPCID,  dbkey, null, null);
		}
		/// <summary>
		/// ��ȡIP����ɾ����¼
		/// </summary>
		/// <param name="iPCID">��ȡIP���ñ��</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">ɾ���ɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByID(Int64 iPCID,  string dbkey = "", Where where = null, string[] delCache = null) {
			return DeleteByID((Int64?)iPCID,  dbkey, where, delCache);
		}
		/// <summary>
		/// ��ȡIP����ɾ����¼
		/// </summary>
		/// <param name="iPCID">��ȡIP���ñ��</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByID(Int64 iPCID, string dbkey) {
			return DeleteByID((Int64?)iPCID,  dbkey, null, null);
		}
		/// <summary>
		/// ��ȡIP����ɾ��������¼
		/// </summary>
		/// <param name="iPCIDList">��ȡIP���ñ���б��á�,���ŷָ�</param>
		/// <param name="where">ɾ��ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByIDList(IEnumerable<Int64> iPCIDList,  string dbkey = "", Where where = null, string[] delCache = null) {
			int value = new SQL().Database(dbkey).Delete(IpSetting._)
				.Where(new Where()
					.And(IpSetting._IPCID, "(" + iPCIDList .Join(",") + ")", Operator.In)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.IpSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// ��ȡIP����ɾ��������¼
		/// </summary>
		/// <param name="iPCIDList">��ȡIP���ñ���б��á�,���ŷָ�</param>
		/// <param name="where">ɾ��ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByIDList(IEnumerable<Int64> iPCIDList, string dbkey) {
			return DeleteByIDList(iPCIDList,  dbkey, null, null);
		}
		/// <summary>
		/// ��ȡIP���ò�ѯ���м�¼
		/// </summary>
		/// <param name="where">����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="order">�����ֶΣ����ӡ�order by��</param>
		/// <param name="fieldList">������Ҫ���ص��ֶ�</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱ���ȡ����key</param>
		/// <returns>����ʵ���¼��</returns>
		public static IList<IpSetting> SelectListByAll(string dbkey = "", Where where = null, string order = "", string fieldList = "") {
			string cacheNameKey = "TH.Mailer.IpSettingCache_SelectListByAll_{0}_{1}_{2}".FormatWith(where, order, fieldList);
			return Cache2.Get<IList<IpSetting>>(cacheNameKey, cacheSeconds, () => {
				IList<IpSetting> list = new List<IpSetting>();
				if (fieldList.IsNullEmpty()) {
					list = new SQL().Database(dbkey).From(IpSetting._)
						.Select(IpSetting._IPCID)
						.Select(IpSetting._WebName)
						.Select(IpSetting._IPUrl)
						.Select(IpSetting._IPRegex)
						.Select(IpSetting._DataEncode)
						.Where(where).Order(order).ToList<IpSetting>();
				} else {
					list = new SQL().Database(dbkey).From(IpSetting._).Select(fieldList).Where(where).Order(order).ToList<IpSetting>();
				}
				return list;
			});
		}
		/// <summary>
		/// ��ȡIP���ò�ѯ���м�¼
		/// </summary>
		/// <returns>����ʵ���¼��</returns>
		public static IList<IpSetting> SelectListByAll(string dbkey) {
			return SelectListByAll(dbkey, null, "", "");
		}
		/// <summary>
		/// ��ȡIP����ɾ�����м�¼
		/// </summary>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱ���ȡ����key</param>
		/// <returns>����ʵ���¼��</returns>
		public static bool RemoveAll(string dbkey = "") {
			return (new SQL().Database(dbkey).Delete(IpSetting._).ToExec()) > 0;
		}
		/// <summary>
		/// �����ȡIP���ò�ѯ���м�¼�Ļ���
		/// </summary>
		public static void ClearCacheSelectListByAll() {
			//Cache2.Remove("TH.Mailer.IpSettingCache_SelectListByAll___");
			Cache2.RemoveByPattern("TH.Mailer.IpSettingCache_SelectListByAll_(.+?)");
		}
		/// <summary>
		/// �����ȡIP�������л���
		/// </summary>
		public static void ClearCacheAll() {
			Cache2.RemoveByPattern("TH.Mailer.IpSettingCache_(.+?)");
		}
	}
}

