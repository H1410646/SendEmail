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
	/// �ʼ�ģ�������
	///
	/// �޸ļ�¼
	///	 2013-06-03 �汾��1.0 ϵͳ�Զ���������
	///
	/// </summary>
	public partial class HtmlTemplateHelper {
		/// <summary>
		/// �ʼ�ģ�滺������� x 5
		/// </summary>
		public static int cacheSeconds = 1440;
		/// <summary>
		/// �ʼ�ģ����Ӽ�¼
		/// </summary>
		/// <param name="htmlTemplate">�ʼ�ģ��ʵ����</param>
		/// <param name="delCache">��ӳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>������ӳɹ����ID</returns>
		public static Int64 Insert(HtmlTemplate htmlTemplate, string dbkey = "", string[] delCache = null) {
			object obj = new SQL().Database(dbkey).Insert(HtmlTemplate._)
				.ValueP(HtmlTemplate._TemplateID, htmlTemplate.TemplateID)
				.ValueP(HtmlTemplate._Subject, htmlTemplate.Subject)
				.ValueP(HtmlTemplate._Body, htmlTemplate.Body)
				.ValueP(HtmlTemplate._ShowName, htmlTemplate.ShowName)
				.ValueP(HtmlTemplate._IsHTML, htmlTemplate.IsHTML)
				.ValueP(HtmlTemplate._Status, htmlTemplate.Status)
				.ValueP(HtmlTemplate._CreateTime, htmlTemplate.CreateTime)
				.ToExec();
			if (obj.ToInt() != 1) return 0;
			obj = new SQL().Database(dbkey).From(HtmlTemplate._).Max("TemplateID").ToScalar();
			if (obj.IsAllNull()) return 0;
			Int64 value = obj.ToString().ToBigInt();
			if (delCache.IsNull()) return value;
			Cache2.Remove("TH.Mailer.HtmlTemplateCache_", delCache);
			return value;
		}
		/// <summary>
		/// �ʼ�ģ����Ӽ�¼
		/// </summary>
		/// <param name="htmlTemplate">�ʼ�ģ��ʵ����</param>
		/// <returns>������ӳɹ����ID</returns>
		public static Int64 Insert(HtmlTemplate htmlTemplate, string dbkey) {
			return Insert(htmlTemplate, dbkey, null);
		}
		/// <summary>
		/// �ʼ�ģ���޸ļ�¼
		/// </summary>
		/// <param name="htmlTemplate">�ʼ�ģ��ʵ����</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool Update(HtmlTemplate htmlTemplate, string dbkey = "", Where where = null, string[] delCache = null) {
			if (htmlTemplate.TemplateID.IsNull()) return false;
			int value = new SQL().Database(dbkey).Update(HtmlTemplate._)
				.SetP(HtmlTemplate._Subject, htmlTemplate.Subject)
				.SetP(HtmlTemplate._Body, htmlTemplate.Body)
				.SetP(HtmlTemplate._ShowName, htmlTemplate.ShowName)
				.SetP(HtmlTemplate._IsHTML, htmlTemplate.IsHTML)
				.SetP(HtmlTemplate._Status, htmlTemplate.Status)
				.SetP(HtmlTemplate._CreateTime, htmlTemplate.CreateTime)
				.Where(new Where()
					.AndP(HtmlTemplate._TemplateID, htmlTemplate.TemplateID, Operator.Equal, true)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.HtmlTemplateCache_", delCache);
			return true;
		}
		/// <summary>
		/// �ʼ�ģ���޸ļ�¼
		/// </summary>
		/// <param name="htmlTemplate">�ʼ�ģ��ʵ����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool Update(HtmlTemplate htmlTemplate, string dbkey) {
			return Update(htmlTemplate, dbkey, null, null);
		}
		/// <summary>
		/// �ʼ�ģ���޸Ķ�����¼
		/// </summary>
		/// <param name="templateIDList">�ʼ�ģ�����б��á�,���ŷָ�</param>
		/// <param name="htmlTemplate">�ʼ�ģ��ʵ����</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool UpdateByIDList(IEnumerable<Int64> templateIDList,  HtmlTemplate htmlTemplate, string dbkey = "", Where where = null, string[] delCache = null) {
			int value = new SQL().Database(dbkey).Update(HtmlTemplate._)
				.SetP(HtmlTemplate._Subject, htmlTemplate.Subject)
				.SetP(HtmlTemplate._Body, htmlTemplate.Body)
				.SetP(HtmlTemplate._ShowName, htmlTemplate.ShowName)
				.SetP(HtmlTemplate._IsHTML, htmlTemplate.IsHTML)
				.SetP(HtmlTemplate._Status, htmlTemplate.Status)
				.SetP(HtmlTemplate._CreateTime, htmlTemplate.CreateTime)
				.Where(new Where()
					.And(HtmlTemplate._TemplateID, "(" + templateIDList .Join(",") + ")", Operator.In)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.HtmlTemplateCache_", delCache);
			return true;
		}
		/// <summary>
		/// �ʼ�ģ���޸Ķ�����¼
		/// </summary>
		/// <param name="templateIDList">�ʼ�ģ�����б��á�,���ŷָ�</param>
		/// <param name="htmlTemplate">�ʼ�ģ��ʵ����</param>
		/// <returns>�޸��Ƿ�ɹ�</returns>
		public static bool UpdateByIDList(IEnumerable<Int64> templateIDList,  HtmlTemplate htmlTemplate, string dbkey) {
			return UpdateByIDList(templateIDList,  htmlTemplate, dbkey, null, null);
		}
 		/// <summary>
		/// �ʼ�ģ��ɾ����¼
		/// </summary>
		/// <param name="templateID">�ʼ�ģ����</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">ɾ���ɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByID(Int64? templateID,  string dbkey = "", Where where = null, string[] delCache = null) {
			if (templateID.IsNull()) return false;
			int value = new SQL().Database(dbkey).Delete(HtmlTemplate._)
				.Where(new Where()
					.AndP(HtmlTemplate._TemplateID, templateID, Operator.Equal, true)
				).Where(where).ToExec();
			if (value != 1) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.HtmlTemplateCache_", delCache);
			return true;
		}
		/// <summary>
		/// �ʼ�ģ��ɾ����¼
		/// </summary>
		/// <param name="templateID">�ʼ�ģ����</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByID(Int64? templateID, string dbkey) {
			return DeleteByID(templateID,  dbkey, null, null);
		}
		/// <summary>
		/// �ʼ�ģ��ɾ����¼
		/// </summary>
		/// <param name="templateID">�ʼ�ģ����</param>
		/// <param name="where">�޸�ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">ɾ���ɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByID(Int64 templateID,  string dbkey = "", Where where = null, string[] delCache = null) {
			return DeleteByID((Int64?)templateID,  dbkey, where, delCache);
		}
		/// <summary>
		/// �ʼ�ģ��ɾ����¼
		/// </summary>
		/// <param name="templateID">�ʼ�ģ����</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByID(Int64 templateID, string dbkey) {
			return DeleteByID((Int64?)templateID,  dbkey, null, null);
		}
		/// <summary>
		/// �ʼ�ģ��ɾ��������¼
		/// </summary>
		/// <param name="templateIDList">�ʼ�ģ�����б��á�,���ŷָ�</param>
		/// <param name="where">ɾ��ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByIDList(IEnumerable<Int64> templateIDList,  string dbkey = "", Where where = null, string[] delCache = null) {
			int value = new SQL().Database(dbkey).Delete(HtmlTemplate._)
				.Where(new Where()
					.And(HtmlTemplate._TemplateID, "(" + templateIDList .Join(",") + ")", Operator.In)
				).Where(where).ToExec();
			if (value <= 0) return false;
			if (delCache.IsNull()) return true;
			Cache2.Remove("TH.Mailer.HtmlTemplateCache_", delCache);
			return true;
		}
		/// <summary>
		/// �ʼ�ģ��ɾ��������¼
		/// </summary>
		/// <param name="templateIDList">�ʼ�ģ�����б��á�,���ŷָ�</param>
		/// <param name="where">ɾ��ʱ����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="delCache">�޸ĳɹ��������CACHE key��֧������</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱʹ��ConnString����</param>
		/// <returns>ɾ���Ƿ�ɹ�</returns>
		public static bool DeleteByIDList(IEnumerable<Int64> templateIDList, string dbkey) {
			return DeleteByIDList(templateIDList,  dbkey, null, null);
		}
		/// <summary>
		/// �ʼ�ģ���ѯ���м�¼
		/// </summary>
		/// <param name="where">����������ͳһ��ǰ��Ҫ�����ӷ���and��or�ȵȣ�</param>
		/// <param name="order">�����ֶΣ����ӡ�order by��</param>
		/// <param name="fieldList">������Ҫ���ص��ֶ�</param>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱ���ȡ����key</param>
		/// <returns>����ʵ���¼��</returns>
		public static IList<HtmlTemplate> SelectListByAll(string dbkey = "", Where where = null, string order = "", string fieldList = "") {
			string cacheNameKey = "TH.Mailer.HtmlTemplateCache_SelectListByAll_{0}_{1}_{2}".FormatWith(where, order, fieldList);
			return Cache2.Get<IList<HtmlTemplate>>(cacheNameKey, cacheSeconds, () => {
				IList<HtmlTemplate> list = new List<HtmlTemplate>();
				if (fieldList.IsNullEmpty()) {
					list = new SQL().Database(dbkey).From(HtmlTemplate._)
						.Select(HtmlTemplate._TemplateID)
						.Select(HtmlTemplate._Subject)
						.Select(HtmlTemplate._Body)
						.Select(HtmlTemplate._ShowName)
						.Select(HtmlTemplate._IsHTML)
						.Select(HtmlTemplate._Status)
						.Select(HtmlTemplate._CreateTime)
						.Where(where).Order(order).ToList<HtmlTemplate>();
				} else {
					list = new SQL().Database(dbkey).From(HtmlTemplate._).Select(fieldList).Where(where).Order(order).ToList<HtmlTemplate>();
				}
				return list;
			});
		}
		/// <summary>
		/// �ʼ�ģ���ѯ���м�¼
		/// </summary>
		/// <returns>����ʵ���¼��</returns>
		public static IList<HtmlTemplate> SelectListByAll(string dbkey) {
			return SelectListByAll(dbkey, null, "", "");
		}
		/// <summary>
		/// �ʼ�ģ��ɾ�����м�¼
		/// </summary>
		/// <param name="dbkey">�������ݿ����ӳ��е�����key��Ϊ��ʱ���ȡ����key</param>
		/// <returns>����ʵ���¼��</returns>
		public static bool RemoveAll(string dbkey = "") {
			return (new SQL().Database(dbkey).Delete(HtmlTemplate._).ToExec()) > 0;
		}
		/// <summary>
		/// ����ʼ�ģ���ѯ���м�¼�Ļ���
		/// </summary>
		public static void ClearCacheSelectListByAll() {
			//Cache2.Remove("TH.Mailer.HtmlTemplateCache_SelectListByAll___");
			Cache2.RemoveByPattern("TH.Mailer.HtmlTemplateCache_SelectListByAll_(.+?)");
		}
		/// <summary>
		/// ����ʼ�ģ�����л���
		/// </summary>
		public static void ClearCacheAll() {
			Cache2.RemoveByPattern("TH.Mailer.HtmlTemplateCache_(.+?)");
		}
	}
}

