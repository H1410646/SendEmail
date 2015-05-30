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
	/// �������Ӳ�����
	///
	/// �޸ļ�¼
	///	 2013-06-03 �汾��1.0 ϵͳ�Զ���������
	///
	/// </summary>
	public partial class ModelSettingHelper {
		/// <summary>
		/// �������ӻ�������� x 5
		/// </summary>
		public static int cacheSeconds = 1440;
		/// <summary>
		/// ����������Ӽ�¼
		/// </summary>
		/// <param name="modelSetting">��������ʵ����</param>
		/// <param name="delCache">��ӳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>����Ƿ�ɹ�</returns>
		public static bool Insert(ModelSetting modelSetting, string dbkey = "", string[] delCache = null) {
			int obj = new SQL().Database(dbkey).Insert(ModelSetting._)
				.ValueP(ModelSetting._ModelID, modelSetting.ModelID)
				.ValueP(ModelSetting._ModelName, modelSetting.ModelName)
				.ValueP(ModelSetting._UserName, modelSetting.UserName)
				.ValueP(ModelSetting._MPassword, modelSetting.MPassword)
				.ToExec();
			if (delCache.IsNull()) return obj == 1;
			Cache2.Remove("TH.Mailer.ModelSettingCache_", delCache);
			return obj == 1;
		}
		/// <summary>
		/// ����������Ӽ�¼
		/// </summary>
		/// <param name="modelSetting">��������ʵ����</param>
		/// <returns>����Ƿ�ɹ�</returns>
		public static bool Insert(ModelSetting modelSetting, string dbkey) {
			return Insert(modelSetting, dbkey, null);
		}
		/// <summary>
		/// ���������޸ļ�¼
		/// </summary>
		/// <param name="modelSetting">��������ʵ����</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool Update(ModelSetting modelSetting, string dbkey = "", Where where = null, string[] delCache = null) {
			if (modelSetting.ModelID.IsNull()) return false;
			int value = new SQL().Database(dbkey).Update(ModelSetting._)
				.SetP(ModelSetting._ModelName, modelSetting.ModelName)
				.SetP(ModelSetting._UserName, modelSetting.UserName)
				.SetP(ModelSetting._MPassword, modelSetting.MPassword)
				.Where(new Where()
					.AndP(ModelSetting._ModelID, modelSetting.ModelID, Operator.Equal, true)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.ModelSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// ���������޸ļ�¼
		/// </summary>
		/// <param name="modelSetting">��������ʵ����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool Update(ModelSetting modelSetting, string dbkey) {
			return Update(modelSetting, dbkey, null, null);
		}
		/// <summary>
		/// ���������޸Ķ�����¼
		/// </summary>
		/// <param name="modelIDList">�������ӱ���б��á�,���ŷָ�</param>
		/// <param name="modelSetting">��������ʵ����</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool UpdateByIDList(IEnumerable<int> modelIDList,  ModelSetting modelSetting, string dbkey = "", Where where = null, string[] delCache = null) {
			int value = new SQL().Database(dbkey).Update(ModelSetting._)
				.SetP(ModelSetting._ModelName, modelSetting.ModelName)
				.SetP(ModelSetting._UserName, modelSetting.UserName)
				.SetP(ModelSetting._MPassword, modelSetting.MPassword)
				.Where(new Where()
					.And(ModelSetting._ModelID, "(" + modelIDList .Join(",") + ")", Operator.In)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.ModelSettingCache_", delCache);
			return true;
		}
		/// <summary>
		/// ���������޸Ķ�����¼
		/// </summary>
		/// <param name="modelIDList">�������ӱ���б��á�,���ŷָ�</param>
		/// <param name="modelSetting">��������ʵ����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool UpdateByIDList(IEnumerable<int> modelIDList,  ModelSetting modelSetting, string dbkey) {
			return UpdateByIDList(modelIDList,  modelSetting, dbkey, null, null);
		}
		/// <summary>
		/// �������Ӱ�������ѯ���������ݵ�ʵ����
		/// </summary>
		/// <param name="modelID">�������ӱ��</param>
		/// <param name="where">����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱ���ȡ����key</param>
		/// <returns>���ص�����¼��ʵ����</returns>
		public static ModelSetting SelectByID(int modelID,  string dbkey = "", Where where = null) {
			string cacheNameKey = "TH.Mailer.ModelSettingCache_SelectByID_{0}".FormatWith(modelID + "_" +  "_" + where);
			return Cache2.Get<ModelSetting>(cacheNameKey, cacheSeconds, () => {
				ModelSetting obj = new SQL().Database(dbkey).From(ModelSetting._)
					.Select(ModelSetting._ModelID)
					.Select(ModelSetting._ModelName)
					.Select(ModelSetting._UserName)
					.Select(ModelSetting._MPassword)
					.Where(new Where()
						.AndP(ModelSetting._ModelID, modelID, Operator.Equal)
					).Where(where).ToEntity<ModelSetting>();
				return obj;
			});
		}
		/// <summary>
		/// �������Ӱ�������ѯ���������ݵ�ʵ����
		/// </summary>
		/// <param name="modelID">�������ӱ��</param>
		/// <returns>���ص�����¼��ʵ����</returns>
		public static ModelSetting SelectByID(int modelID, string dbkey) {
			return SelectByID(modelID,  dbkey, null);
		}
		/// <summary>
		/// ����������Ӱ�������ѯ�Ļ���
		/// </summary>
		public static void ClearCacheSelectByID(int modelID,  Where where = null) {
			string cacheName = "TH.Mailer.ModelSettingCache_SelectByID_{0}";
			string cacheNameKey = string.Format(cacheName, modelID + "_" +  "_" + where);
			Cache2.Remove(cacheNameKey);
		}
		/// <summary>
		/// ��������ɾ�����м�¼
		/// </summary>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱ���ȡ����key</param>
		/// <returns>����ʵ���¼��</returns>
		public static bool RemoveAll(string dbkey = "") {
			return (new SQL().Database(dbkey).Delete(ModelSetting._).ToExec()) > 0;
		}
		/// <summary>
		/// ����������Ӳ�ѯ���м�¼�Ļ���
		/// </summary>
		public static void ClearCacheSelectListByAll() {
			//Cache2.Remove("TH.Mailer.ModelSettingCache_SelectListByAll___");
			Cache2.RemoveByPattern("TH.Mailer.ModelSettingCache_SelectListByAll_(.+?)");
		}
		/// <summary>
		/// ��������������л���
		/// </summary>
		public static void ClearCacheAll() {
			Cache2.RemoveByPattern("TH.Mailer.ModelSettingCache_(.+?)");
		}
	}
}

