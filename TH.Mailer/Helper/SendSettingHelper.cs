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
	/// ���ò�����
	///
	/// �޸ļ�¼
	///	 2013-06-03 �汾��1.0 ϵͳ�Զ���������
	///
	/// </summary>
	public partial class SendSettingHelper {
		/// <summary>
		/// ���û�������� x 5
		/// </summary>
		public static int cacheSeconds = 1440;
		/// <summary>
		/// ������Ӽ�¼
		/// </summary>
		/// <param name="sendSetting">����ʵ����</param>
		/// <param name="delCache">��ӳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>����Ƿ�ɹ�</returns>
		public static bool Insert(SendSetting sendSetting, string dbkey = "", string[] delCache = null) {
			int obj = new SQL().Database(dbkey).Insert(SendSetting._)
				.ValueP(SendSetting._SettingID, sendSetting.SettingID)
				.ValueP(SendSetting._TemplateID, sendSetting.TemplateID)
				.ValueP(SendSetting._ConnectType, sendSetting.ConnectType)
				.ValueP(SendSetting._SendInterval, sendSetting.SendInterval)
				.ValueP(SendSetting._IPInterval, sendSetting.IPInterval)
				.ValueP(SendSetting._SmtpInterval, sendSetting.SmtpInterval)
				.ValueP(SendSetting._DeleteInterval, sendSetting.DeleteInterval)
				.ValueP(SendSetting._MaxRetryCount, sendSetting.MaxRetryCount)
				.ValueP(SendSetting._SendRetryCount, sendSetting.SendRetryCount)
				.ValueP(SendSetting._Status, sendSetting.Status)
				.ToExec();
			if (delCache.IsNull()) return obj == 1;
			Cache2.Remove("TH.Mailer.SendSettingCache_", delCache);
			return obj == 1;
		}
		/// <summary>
		/// ������Ӽ�¼
		/// </summary>
		/// <param name="sendSetting">����ʵ����</param>
		/// <returns>����Ƿ�ɹ�</returns>
		public static bool Insert(SendSetting sendSetting, string dbkey) {
			return Insert(sendSetting, dbkey, null);
		}
		/// <summary>
		/// �����޸ļ�¼
		/// </summary>
		/// <param name="sendSetting">����ʵ����</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool Update(SendSetting sendSetting, string dbkey = "", Where where = null, string[] delCache = null) {
			if (sendSetting.SettingID.IsNull()) return false;
			int value = new SQL().Database(dbkey).Update(SendSetting._)
				.SetP(SendSetting._TemplateID, sendSetting.TemplateID)
				.SetP(SendSetting._ConnectType, sendSetting.ConnectType)
				.SetP(SendSetting._SendInterval, sendSetting.SendInterval)
				.SetP(SendSetting._IPInterval, sendSetting.IPInterval)
				.SetP(SendSetting._SmtpInterval, sendSetting.SmtpInterval)
				.SetP(SendSetting._DeleteInterval, sendSetting.DeleteInterval)
				.SetP(SendSetting._MaxRetryCount, sendSetting.MaxRetryCount)
				.SetP(SendSetting._SendRetryCount, sendSetting.SendRetryCount)
				.SetP(SendSetting._Status, sendSetting.Status)
				.Where(new Where()
					.AndP(SendSetting._SettingID, sendSetting.SettingID, Operator.Equal, true)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.SendSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// �����޸ļ�¼
		/// </summary>
		/// <param name="sendSetting">����ʵ����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool Update(SendSetting sendSetting, string dbkey) {
			return Update(sendSetting, dbkey, null, null);
		}
		/// <summary>
		/// �����޸Ķ�����¼
		/// </summary>
		/// <param name="settingIDList">���ñ���б��á�,���ŷָ�</param>
		/// <param name="sendSetting">����ʵ����</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool UpdateByIDList(IEnumerable<int> settingIDList,  SendSetting sendSetting, string dbkey = "", Where where = null, string[] delCache = null) {
			int value = new SQL().Database(dbkey).Update(SendSetting._)
				.SetP(SendSetting._TemplateID, sendSetting.TemplateID)
				.SetP(SendSetting._ConnectType, sendSetting.ConnectType)
				.SetP(SendSetting._SendInterval, sendSetting.SendInterval)
				.SetP(SendSetting._IPInterval, sendSetting.IPInterval)
				.SetP(SendSetting._SmtpInterval, sendSetting.SmtpInterval)
				.SetP(SendSetting._DeleteInterval, sendSetting.DeleteInterval)
				.SetP(SendSetting._MaxRetryCount, sendSetting.MaxRetryCount)
				.SetP(SendSetting._SendRetryCount, sendSetting.SendRetryCount)
				.SetP(SendSetting._Status, sendSetting.Status)
				.Where(new Where()
					.And(SendSetting._SettingID, "(" + settingIDList .Join(",") + ")", Operator.In)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.SendSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// �����޸Ķ�����¼
		/// </summary>
		/// <param name="settingIDList">���ñ���б��á�,���ŷָ�</param>
		/// <param name="sendSetting">����ʵ����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool UpdateByIDList(IEnumerable<int> settingIDList,  SendSetting sendSetting, string dbkey) {
			return UpdateByIDList(settingIDList,  sendSetting, dbkey, null, null);
		}
		/// <summary>
		/// ���ð�������ѯ���������ݵ�ʵ����
		/// </summary>
		/// <param name="settingID">���ñ��</param>
		/// <param name="where">����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱ���ȡ����key</param>
		/// <returns>���ص�����¼��ʵ����</returns>
		public static SendSetting SelectByID(int settingID,  string dbkey = "", Where where = null) {
			string cacheNameKey = "TH.Mailer.SendSettingCache_SelectByID_{0}".FormatWith(settingID + "_" +  "_" + where);
			return Cache2.Get<SendSetting>(cacheNameKey, cacheSeconds, () => {
				SendSetting obj = new SQL().Database(dbkey).From(SendSetting._)
					.Select(SendSetting._SettingID)
					.Select(SendSetting._TemplateID)
					.Select(SendSetting._ConnectType)
					.Select(SendSetting._SendInterval)
					.Select(SendSetting._IPInterval)
					.Select(SendSetting._SmtpInterval)
					.Select(SendSetting._DeleteInterval)
					.Select(SendSetting._MaxRetryCount)
					.Select(SendSetting._SendRetryCount)
					.Select(SendSetting._Status)
					.Where(new Where()
						.AndP(SendSetting._SettingID, settingID, Operator.Equal)
					).Where(where).ToEntity<SendSetting>();
				return obj;
			});
		}
		/// <summary>
		/// ���ð�������ѯ���������ݵ�ʵ����
		/// </summary>
		/// <param name="settingID">���ñ��</param>
		/// <returns>���ص�����¼��ʵ����</returns>
		public static SendSetting SelectByID(int settingID, string dbkey) {
			return SelectByID(settingID,  dbkey, null);
		}
		/// <summary>
		/// ������ð�������ѯ�Ļ���
		/// </summary>
		public static void ClearCacheSelectByID(int settingID,  Where where = null) {
			string cacheName = "TH.Mailer.SendSettingCache_SelectByID_{0}";
			string cacheNameKey = string.Format(cacheName, settingID + "_" +  "_" + where);
			Cache2.Remove(cacheNameKey);
		}
		/// <summary>
		/// ����ɾ�����м�¼
		/// </summary>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱ���ȡ����key</param>
		/// <returns>����ʵ���¼��</returns>
		public static bool RemoveAll(string dbkey = "") {
			return (new SQL().Database(dbkey).Delete(SendSetting._).ToExec()) > 0;
		}
		/// <summary>
		/// ������ò�ѯ���м�¼�Ļ���
		/// </summary>
		public static void ClearCacheSelectListByAll() {
			//Cache2.Remove("TH.Mailer.SendSettingCache_SelectListByAll___");
			Cache2.RemoveByPattern("TH.Mailer.SendSettingCache_SelectListByAll_(.+?)");
		}
		/// <summary>
		/// ����������л���
		/// </summary>
		public static void ClearCacheAll() {
			Cache2.RemoveByPattern("TH.Mailer.SendSettingCache_(.+?)");
		}
	}
}

