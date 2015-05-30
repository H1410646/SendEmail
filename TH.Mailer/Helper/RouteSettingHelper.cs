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
	/// ·�ɲ�����
	///
	/// �޸ļ�¼
	///	 2013-06-03 �汾��1.0 ϵͳ�Զ���������
	///
	/// </summary>
	public partial class RouteSettingHelper {
		/// <summary>
		/// ·�ɻ�������� x 5
		/// </summary>
		public static int cacheSeconds = 1440;
		/// <summary>
		/// ·����Ӽ�¼
		/// </summary>
		/// <param name="routeSetting">·��ʵ����</param>
		/// <param name="delCache">��ӳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>����Ƿ�ɹ�</returns>
		public static bool Insert(RouteSetting routeSetting, string dbkey = "", string[] delCache = null) {
			int obj = new SQL().Database(dbkey).Insert(RouteSetting._)
				.ValueP(RouteSetting._RouteID, routeSetting.RouteID)
				.ValueP(RouteSetting._RouteIP, routeSetting.RouteIP)
				.ValueP(RouteSetting._UserName, routeSetting.UserName)
				.ValueP(RouteSetting._RPassword, routeSetting.RPassword)
				.ValueP(RouteSetting._RouteConnect, routeSetting.RouteConnect)
				.ValueP(RouteSetting._RouteDisConnect, routeSetting.RouteDisConnect)
				.ValueP(RouteSetting._RouteMethod, routeSetting.RouteMethod)
				.ToExec();
			if (delCache.IsNull()) return obj == 1;
			Cache2.Remove("TH.Mailer.RouteSettingCache_", delCache);
			return obj == 1;
		}
		/// <summary>
		/// ·����Ӽ�¼
		/// </summary>
		/// <param name="routeSetting">·��ʵ����</param>
		/// <returns>����Ƿ�ɹ�</returns>
		public static bool Insert(RouteSetting routeSetting, string dbkey) {
			return Insert(routeSetting, dbkey, null);
		}
		/// <summary>
		/// ·���޸ļ�¼
		/// </summary>
		/// <param name="routeSetting">·��ʵ����</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool Update(RouteSetting routeSetting, string dbkey = "", Where where = null, string[] delCache = null) {
			if (routeSetting.RouteID.IsNull()) return false;
			int value = new SQL().Database(dbkey).Update(RouteSetting._)
				.SetP(RouteSetting._RouteIP, routeSetting.RouteIP)
				.SetP(RouteSetting._UserName, routeSetting.UserName)
				.SetP(RouteSetting._RPassword, routeSetting.RPassword)
				.SetP(RouteSetting._RouteConnect, routeSetting.RouteConnect)
				.SetP(RouteSetting._RouteDisConnect, routeSetting.RouteDisConnect)
				.SetP(RouteSetting._RouteMethod, routeSetting.RouteMethod)
				.Where(new Where()
					.AndP(RouteSetting._RouteID, routeSetting.RouteID, Operator.Equal, true)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.RouteSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// ·���޸ļ�¼
		/// </summary>
		/// <param name="routeSetting">·��ʵ����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool Update(RouteSetting routeSetting, string dbkey) {
			return Update(routeSetting, dbkey, null, null);
		}
		/// <summary>
		/// ·���޸Ķ�����¼
		/// </summary>
		/// <param name="routeIDList">·�ɱ���б��á�,���ŷָ�</param>
		/// <param name="routeSetting">·��ʵ����</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool UpdateByIDList(IEnumerable<int> routeIDList,  RouteSetting routeSetting, string dbkey = "", Where where = null, string[] delCache = null) {
			int value = new SQL().Database(dbkey).Update(RouteSetting._)
				.SetP(RouteSetting._RouteIP, routeSetting.RouteIP)
				.SetP(RouteSetting._UserName, routeSetting.UserName)
				.SetP(RouteSetting._RPassword, routeSetting.RPassword)
				.SetP(RouteSetting._RouteConnect, routeSetting.RouteConnect)
				.SetP(RouteSetting._RouteDisConnect, routeSetting.RouteDisConnect)
				.SetP(RouteSetting._RouteMethod, routeSetting.RouteMethod)
				.Where(new Where()
					.And(RouteSetting._RouteID, "(" + routeIDList .Join(",") + ")", Operator.In)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.RouteSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// ·���޸Ķ�����¼
		/// </summary>
		/// <param name="routeIDList">·�ɱ���б��á�,���ŷָ�</param>
		/// <param name="routeSetting">·��ʵ����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool UpdateByIDList(IEnumerable<int> routeIDList,  RouteSetting routeSetting, string dbkey) {
			return UpdateByIDList(routeIDList,  routeSetting, dbkey, null, null);
		}
		/// <summary>
		/// ·�ɰ�������ѯ���������ݵ�ʵ����
		/// </summary>
		/// <param name="routeID">·�ɱ��</param>
		/// <param name="where">����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱ���ȡ����key</param>
		/// <returns>���ص�����¼��ʵ����</returns>
		public static RouteSetting SelectByID(int routeID,  string dbkey = "", Where where = null) {
			string cacheNameKey = "TH.Mailer.RouteSettingCache_SelectByID_{0}".FormatWith(routeID + "_" +  "_" + where);
			return Cache2.Get<RouteSetting>(cacheNameKey, cacheSeconds, () => {
				RouteSetting obj = new SQL().Database(dbkey).From(RouteSetting._)
					.Select(RouteSetting._RouteID)
					.Select(RouteSetting._RouteIP)
					.Select(RouteSetting._UserName)
					.Select(RouteSetting._RPassword)
					.Select(RouteSetting._RouteConnect)
					.Select(RouteSetting._RouteDisConnect)
					.Select(RouteSetting._RouteMethod)
					.Where(new Where()
						.AndP(RouteSetting._RouteID, routeID, Operator.Equal)
					).Where(where).ToEntity<RouteSetting>();
				return obj;
			});
		}
		/// <summary>
		/// ·�ɰ�������ѯ���������ݵ�ʵ����
		/// </summary>
		/// <param name="routeID">·�ɱ��</param>
		/// <returns>���ص�����¼��ʵ����</returns>
		public static RouteSetting SelectByID(int routeID, string dbkey) {
			return SelectByID(routeID,  dbkey, null);
		}
		/// <summary>
		/// ���·�ɰ�������ѯ�Ļ���
		/// </summary>
		public static void ClearCacheSelectByID(int routeID,  Where where = null) {
			string cacheName = "TH.Mailer.RouteSettingCache_SelectByID_{0}";
			string cacheNameKey = string.Format(cacheName, routeID + "_" +  "_" + where);
			Cache2.Remove(cacheNameKey);
		}
		/// <summary>
		/// ·��ɾ�����м�¼
		/// </summary>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱ���ȡ����key</param>
		/// <returns>����ʵ���¼��</returns>
		public static bool RemoveAll(string dbkey = "") {
			return (new SQL().Database(dbkey).Delete(RouteSetting._).ToExec()) > 0;
		}
		/// <summary>
		/// ���·�ɲ�ѯ���м�¼�Ļ���
		/// </summary>
		public static void ClearCacheSelectListByAll() {
			//Cache2.Remove("TH.Mailer.RouteSettingCache_SelectListByAll___");
			Cache2.RemoveByPattern("TH.Mailer.RouteSettingCache_SelectListByAll_(.+?)");
		}
		/// <summary>
		/// ���·�����л���
		/// </summary>
		public static void ClearCacheAll() {
			Cache2.RemoveByPattern("TH.Mailer.RouteSettingCache_(.+?)");
		}
	}
}

