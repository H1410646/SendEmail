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
	public partial class IpHistory {
		/// <summary>
		/// 
		/// </summary>
		public static readonly string _ = "IpHistory";

		/// <summary>
		/// IP��ַ
		/// </summary>
		public static readonly string _IP = "IP";
		private string iP = null;
		/// <summary>
		/// IP��ַ
		/// </summary>
		[EntityInfo("IP��ַ")]
		public new string IP { get { return iP; } set { iP = value; } }

		/// <summary>
		/// ʹ��ʱ��
		/// </summary>
		public static readonly string _CreateTime = "CreateTime";
		private DateTime? createTime = null;
		/// <summary>
		/// ʹ��ʱ��
		/// </summary>
		[EntityInfo("ʹ��ʱ��")]
		public new DateTime? CreateTime { get { return createTime; } set { createTime = value; } }
	}
}



