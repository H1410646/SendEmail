//-------------------------------------------------------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2013 , TH , Ltd.
//-------------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using Pub.Class;

namespace TH.Mailer.Entity {
	/// <summary>
	/// ������������ʵ����
	///
	/// �޸ļ�¼
	///	 2013-06-03 �汾��1.0 ϵͳ�Զ���������
	///
	/// </summary>
	[Serializable]
	[EntityInfo("������������")]
	public partial class TianYiSetting {
		/// <summary>
		/// ������������
		/// </summary>
		public static readonly string _ = "TianYiSetting";

		/// <summary>
		/// �����������ñ��
		/// </summary>
		public static readonly string _TianYiID = "TianYiID";
		private int? tianYiID = null;
		/// <summary>
		/// �����������ñ��
		/// </summary>
		[EntityInfo("�����������ñ��")]
		public new int? TianYiID { get { return tianYiID; } set { tianYiID = value; } }

		/// <summary>
		/// ����������·��
		/// </summary>
		public static readonly string _TianYiExePath = "TianYiExePath";
		private string tianYiExePath = null;
		/// <summary>
		/// ����������·��
		/// </summary>
		[EntityInfo("����������·��")]
		public new string TianYiExePath { get { return tianYiExePath; } set { tianYiExePath = value; } }
	}
}



