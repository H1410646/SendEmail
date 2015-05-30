//-------------------------------------------------------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2013 , TH , Ltd.
//-------------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using Pub.Class;

namespace TH.Mailer.Entity {
	/// <summary>
	/// ʵ����
	///
	/// �޸ļ�¼
	///	 2013-06-03 �汾��1.0 ϵͳ�Զ���������
	///
	/// </summary>
	[Serializable]
	[EntityInfo("")]
	public partial class SmtpList {
		/// <summary>
		/// 
		/// </summary>
		public static readonly string _ = "SmtpList";

		/// <summary>
		/// SMTP������
		/// </summary>
		public static readonly string _SmtpServer = "SmtpServer";
		private string smtpServer = null;
		/// <summary>
		/// SMTP������
		/// </summary>
		[EntityInfo("SMTP������")]
		public new string SmtpServer { get { return smtpServer; } set { smtpServer = value; } }

		/// <summary>
		/// SMTP�˿�
		/// </summary>
		public static readonly string _SmtpPort = "SmtpPort";
		private int? smtpPort = null;
		/// <summary>
		/// SMTP�˿�
		/// </summary>
		[EntityInfo("SMTP�˿�")]
		public new int? SmtpPort { get { return smtpPort; } set { smtpPort = value; } }

		/// <summary>
		/// ��¼�û���
		/// </summary>
		public static readonly string _UserName = "UserName";
		private string userName = null;
		/// <summary>
		/// ��¼�û���
		/// </summary>
		[EntityInfo("��¼�û���")]
		public new string UserName { get { return userName; } set { userName = value; } }

		/// <summary>
		/// ��¼����
		/// </summary>
		public static readonly string _SPassword = "SPassword";
		private string sPassword = null;
		/// <summary>
		/// ��¼����
		/// </summary>
		[EntityInfo("��¼����")]
		public new string SPassword { get { return sPassword; } set { sPassword = value; } }

		/// <summary>
		/// �Ƿ�֧��SSL
		/// </summary>
		public static readonly string _SSL = "SSL";
		private bool? sSL = null;
		/// <summary>
		/// �Ƿ�֧��SSL
		/// </summary>
		[EntityInfo("�Ƿ�֧��SSL")]
		public new bool? SSL { get { return sSL; } set { sSL = value; } }

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
		/// ���ʹ���
		/// </summary>
		public static readonly string _Sends = "Sends";
		private int? sends = null;
		/// <summary>
		/// ���ʹ���
		/// </summary>
		[EntityInfo("���ʹ���")]
		public new int? Sends { get { return sends; } set { sends = value; } }

		/// <summary>
		/// ����ʧ�ܴ���
		/// </summary>
		public static readonly string _SendFails = "SendFails";
		private int? sendFails = null;
		/// <summary>
		/// ����ʧ�ܴ���
		/// </summary>
		[EntityInfo("����ʧ�ܴ���")]
		public new int? SendFails { get { return sendFails; } set { sendFails = value; } }

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



