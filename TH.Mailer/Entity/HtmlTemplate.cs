//-------------------------------------------------------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2013 , TH , Ltd.
//-------------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using Pub.Class;

namespace TH.Mailer.Entity {
	/// <summary>
	/// �ʼ�ģ��ʵ����
	///
	/// �޸ļ�¼
	///	 2013-06-03 �汾��1.0 ϵͳ�Զ���������
	///
	/// </summary>
	[Serializable]
	[EntityInfo("�ʼ�ģ��")]
	public partial class HtmlTemplate {
		/// <summary>
		/// �ʼ�ģ��
		/// </summary>
		public static readonly string _ = "HtmlTemplate";

		/// <summary>
		/// �ʼ�ģ����
		/// </summary>
		public static readonly string _TemplateID = "TemplateID";
		private Int64? templateID = null;
		/// <summary>
		/// �ʼ�ģ����
		/// </summary>
		[EntityInfo("�ʼ�ģ����")]
		public new Int64? TemplateID { get { return templateID; } set { templateID = value; } }

		/// <summary>
		/// ����
		/// </summary>
		public static readonly string _Subject = "Subject";
		private string subject = null;
		/// <summary>
		/// ����
		/// </summary>
		[EntityInfo("����")]
		public new string Subject { get { return subject; } set { subject = value; } }

		/// <summary>
		/// ����
		/// </summary>
		public static readonly string _Body = "Body";
		private string body = null;
		/// <summary>
		/// ����
		/// </summary>
		[EntityInfo("����")]
		public new string Body { get { return body; } set { body = value; } }

		/// <summary>
		/// ��ʾ����������
		/// </summary>
		public static readonly string _ShowName = "ShowName";
		private string showName = null;
		/// <summary>
		/// ��ʾ����������
		/// </summary>
		[EntityInfo("��ʾ����������")]
		public new string ShowName { get { return showName; } set { showName = value; } }

		/// <summary>
		/// �Ƿ�ʹ��HTML����
		/// </summary>
		public static readonly string _IsHTML = "IsHTML";
		private bool? isHTML = null;
		/// <summary>
		/// �Ƿ�ʹ��HTML����
		/// </summary>
		[EntityInfo("�Ƿ�ʹ��HTML����")]
		public new bool? IsHTML { get { return isHTML; } set { isHTML = value; } }

		/// <summary>
		/// ״̬ 0���� 1������
		/// </summary>
		public static readonly string _Status = "Status";
		private int? status = null;
		/// <summary>
		/// ״̬ 0���� 1������
		/// </summary>
		[EntityInfo("״̬ 0���� 1������")]
		public new int? Status { get { return status; } set { status = value; } }

		/// <summary>
		/// ����ʱ��
		/// </summary>
		public static readonly string _CreateTime = "CreateTime";
		private DateTime? createTime = null;
		/// <summary>
		/// ����ʱ��
		/// </summary>
		[EntityInfo("����ʱ��")]
		public new DateTime? CreateTime { get { return createTime; } set { createTime = value; } }
	}
}



