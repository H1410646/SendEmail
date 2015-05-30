//-------------------------------------------------------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2013 , TH , Ltd.
//-------------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using Pub.Class;

namespace TH.Mailer.Entity {
	/// <summary>
	/// ����ʵ����
	///
	/// �޸ļ�¼
	///	 2013-06-03 �汾��1.0 ϵͳ�Զ���������
	///
	/// </summary>
	[Serializable]
	[EntityInfo("����")]
	public partial class SendSetting {
		/// <summary>
		/// ����
		/// </summary>
		public static readonly string _ = "SendSetting";

		/// <summary>
		/// ���ñ��
		/// </summary>
		public static readonly string _SettingID = "SettingID";
		private int? settingID = null;
		/// <summary>
		/// ���ñ��
		/// </summary>
		[EntityInfo("���ñ��")]
		public new int? SettingID { get { return settingID; } set { settingID = value; } }

		/// <summary>
		/// ����������
		/// </summary>
		public static readonly string _TemplateID = "TemplateID";
		private Int64? templateID = null;
		/// <summary>
		/// ����������
		/// </summary>
		[EntityInfo("����������")]
		public new Int64? TemplateID { get { return templateID; } set { templateID = value; } }

		/// <summary>
		/// �������� 0ʹ��·������ 1ʹ�ò�������
		/// </summary>
		public static readonly string _ConnectType = "ConnectType";
		private int? connectType = null;
		/// <summary>
		/// �������� 0ʹ��·������ 1ʹ�ò�������
		/// </summary>
		[EntityInfo("�������� 0ʹ��·������ 1ʹ�ò�������")]
		public new int? ConnectType { get { return connectType; } set { connectType = value; } }

		/// <summary>
		/// �����ʼ�ʱ����(����)
		/// </summary>
		public static readonly string _SendInterval = "SendInterval";
		private int? sendInterval = null;
		/// <summary>
		/// �����ʼ�ʱ����(����)
		/// </summary>
		[EntityInfo("�����ʼ�ʱ����(����)")]
		public new int? SendInterval { get { return sendInterval; } set { sendInterval = value; } }

		/// <summary>
		/// ���Ͷ��ٷ��ʼ������IP
		/// </summary>
		public static readonly string _IPInterval = "IPInterval";
		private int? iPInterval = null;
		/// <summary>
		/// ���Ͷ��ٷ��ʼ������IP
		/// </summary>
		[EntityInfo("���Ͷ��ٷ��ʼ������IP")]
		public new int? IPInterval { get { return iPInterval; } set { iPInterval = value; } }

		/// <summary>
		/// ���Ͷ��ٷ��ʼ������SMTP
		/// </summary>
		public static readonly string _SmtpInterval = "SmtpInterval";
		private int? smtpInterval = null;
		/// <summary>
		/// ���Ͷ��ٷ��ʼ������SMTP
		/// </summary>
		[EntityInfo("���Ͷ��ٷ��ʼ������SMTP")]
		public new int? SmtpInterval { get { return smtpInterval; } set { smtpInterval = value; } }

		/// <summary>
		/// ������ٷ���֮ǰ����ʷIP
		/// </summary>
		public static readonly string _DeleteInterval = "DeleteInterval";
		private int? deleteInterval = null;
		/// <summary>
		/// ������ٷ���֮ǰ����ʷIP
		/// </summary>
		[EntityInfo("������ٷ���֮ǰ����ʷIP")]
		public new int? DeleteInterval { get { return deleteInterval; } set { deleteInterval = value; } }

		/// <summary>
		/// ������Դ���
		/// </summary>
		public static readonly string _MaxRetryCount = "MaxRetryCount";
		private int? maxRetryCount = null;
		/// <summary>
		/// ������Դ���
		/// </summary>
		[EntityInfo("������Դ���")]
		public new int? MaxRetryCount { get { return maxRetryCount; } set { maxRetryCount = value; } }

		/// <summary>
		/// �����ʼ�ʧ�����Դ���
		/// </summary>
		public static readonly string _SendRetryCount = "SendRetryCount";
		private int? sendRetryCount = null;
		/// <summary>
		/// �����ʼ�ʧ�����Դ���
		/// </summary>
		[EntityInfo("�����ʼ�ʧ�����Դ���")]
		public new int? SendRetryCount { get { return sendRetryCount; } set { sendRetryCount = value; } }

		/// <summary>
		/// ״̬  0�ȴ����� 1���ڷ��� 2�ѷ������
		/// </summary>
		public static readonly string _Status = "Status";
		private int? status = null;
		/// <summary>
		/// ״̬  0�ȴ����� 1���ڷ��� 2�ѷ������
		/// </summary>
		[EntityInfo("״̬  0�ȴ����� 1���ڷ��� 2�ѷ������")]
		public new int? Status { get { return status; } set { status = value; } }
	}
}



