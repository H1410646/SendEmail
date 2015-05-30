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
	public partial class EmailList {
		/// <summary>
		/// 
		/// </summary>
		public static readonly string _ = "EmailList";

		/// <summary>
		/// ���͵�Email
		/// </summary>
		public static readonly string _EmailAddress = "EmailAddress";
		private string emailAddress = null;
		/// <summary>
		/// ���͵�Email
		/// </summary>
		[EntityInfo("���͵�Email")]
		public new string EmailAddress { get { return emailAddress; } set { emailAddress = value; } }

		/// <summary>
		/// �ռ����ǳ�
		/// </summary>
		public static readonly string _NickName = "NickName";
		private string nickName = null;
		/// <summary>
		/// �ռ����ǳ�
		/// </summary>
		[EntityInfo("�ռ����ǳ�")]
		public new string NickName { get { return nickName; } set { nickName = value; } }

		/// <summary>
		/// ״̬ 0�ȴ����� 1���ͳɹ� 2����ʧ��
		/// </summary>
		public static readonly string _LastSendStatus = "LastSendStatus";
		private int? lastSendStatus = null;
		/// <summary>
		/// ״̬ 0�ȴ����� 1���ͳɹ� 2����ʧ��
		/// </summary>
		[EntityInfo("״̬ 0�ȴ����� 1���ͳɹ� 2����ʧ��")]
		public new int? LastSendStatus { get { return lastSendStatus; } set { lastSendStatus = value; } }

		/// <summary>
		/// ���һ�γ�����־
		/// </summary>
		public static readonly string _LastSendError = "LastSendError";
		private string lastSendError = null;
		/// <summary>
		/// ���һ�γ�����־
		/// </summary>
		[EntityInfo("���һ�γ�����־")]
		public new string LastSendError { get { return lastSendError; } set { lastSendError = value; } }

		/// <summary>
		/// ���һ�η���ʱ��
		/// </summary>
		public static readonly string _LastSendTime = "LastSendTime";
		private DateTime? lastSendTime = null;
		/// <summary>
		/// ���һ�η���ʱ��
		/// </summary>
		[EntityInfo("���һ�η���ʱ��")]
		public new DateTime? LastSendTime { get { return lastSendTime; } set { lastSendTime = value; } }

		/// <summary>
		/// ���һ��ʹ��SMTP
		/// </summary>
		public static readonly string _LastSendSmtp = "LastSendSmtp";
		private string lastSendSmtp = null;
		/// <summary>
		/// ���һ��ʹ��SMTP
		/// </summary>
		[EntityInfo("���һ��ʹ��SMTP")]
		public new string LastSendSmtp { get { return lastSendSmtp; } set { lastSendSmtp = value; } }

		/// <summary>
		/// ���ʹ���
		/// </summary>
		public static readonly string _SendCount = "SendCount";
		private int? sendCount = null;
		/// <summary>
		/// ���ʹ���
		/// </summary>
		[EntityInfo("���ʹ���")]
		public new int? SendCount { get { return sendCount; } set { sendCount = value; } }

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

		/// <summary>
		/// ex0
		/// </summary>
		public static readonly string _ex0 = "ex0";
		private string __ex0 = null;
		/// <summary>
		/// ex0
		/// </summary>
		[EntityInfo("ex0")]
		public new string ex0 { get { return __ex0; } set { __ex0 = value; } }

		/// <summary>
		/// ex1
		/// </summary>
		public static readonly string _ex1 = "ex1";
		private string __ex1 = null;
		/// <summary>
		/// ex1
		/// </summary>
		[EntityInfo("ex1")]
		public new string ex1 { get { return __ex1; } set { __ex1 = value; } }

		/// <summary>
		/// ex2
		/// </summary>
		public static readonly string _ex2 = "ex2";
		private string __ex2 = null;
		/// <summary>
		/// ex2
		/// </summary>
		[EntityInfo("ex2")]
		public new string ex2 { get { return __ex2; } set { __ex2 = value; } }

		/// <summary>
		/// ex3
		/// </summary>
		public static readonly string _ex3 = "ex3";
		private string __ex3 = null;
		/// <summary>
		/// ex3
		/// </summary>
		[EntityInfo("ex3")]
		public new string ex3 { get { return __ex3; } set { __ex3 = value; } }

		/// <summary>
		/// ex4
		/// </summary>
		public static readonly string _ex4 = "ex4";
		private string __ex4 = null;
		/// <summary>
		/// ex4
		/// </summary>
		[EntityInfo("ex4")]
		public new string ex4 { get { return __ex4; } set { __ex4 = value; } }

		/// <summary>
		/// ex5
		/// </summary>
		public static readonly string _ex5 = "ex5";
		private string __ex5 = null;
		/// <summary>
		/// ex5
		/// </summary>
		[EntityInfo("ex5")]
		public new string ex5 { get { return __ex5; } set { __ex5 = value; } }

		/// <summary>
		/// ex6
		/// </summary>
		public static readonly string _ex6 = "ex6";
		private string __ex6 = null;
		/// <summary>
		/// ex6
		/// </summary>
		[EntityInfo("ex6")]
		public new string ex6 { get { return __ex6; } set { __ex6 = value; } }

		/// <summary>
		/// ex7
		/// </summary>
		public static readonly string _ex7 = "ex7";
		private string __ex7 = null;
		/// <summary>
		/// ex7
		/// </summary>
		[EntityInfo("ex7")]
		public new string ex7 { get { return __ex7; } set { __ex7 = value; } }

		/// <summary>
		/// ex8
		/// </summary>
		public static readonly string _ex8 = "ex8";
		private string __ex8 = null;
		/// <summary>
		/// ex8
		/// </summary>
		[EntityInfo("ex8")]
		public new string ex8 { get { return __ex8; } set { __ex8 = value; } }
	}
}



