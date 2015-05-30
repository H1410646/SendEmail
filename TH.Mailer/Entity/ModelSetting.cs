//-------------------------------------------------------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2013 , TH , Ltd.
//-------------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using Pub.Class;

namespace TH.Mailer.Entity {
	/// <summary>
	/// ��������ʵ����
	///
	/// �޸ļ�¼
	///	 2013-06-03 �汾��1.0 ϵͳ�Զ���������
	///
	/// </summary>
	[Serializable]
	[EntityInfo("��������")]
	public partial class ModelSetting {
		/// <summary>
		/// ��������
		/// </summary>
		public static readonly string _ = "ModelSetting";

		/// <summary>
		/// �������ӱ��
		/// </summary>
		public static readonly string _ModelID = "ModelID";
		private int? modelID = null;
		/// <summary>
		/// �������ӱ��
		/// </summary>
		[EntityInfo("�������ӱ��")]
		public new int? ModelID { get { return modelID; } set { modelID = value; } }

		/// <summary>
		/// ������������
		/// </summary>
		public static readonly string _ModelName = "ModelName";
		private string modelName = null;
		/// <summary>
		/// ������������
		/// </summary>
		[EntityInfo("������������")]
		public new string ModelName { get { return modelName; } set { modelName = value; } }

		/// <summary>
		/// ��¼�˺�
		/// </summary>
		public static readonly string _UserName = "UserName";
		private string userName = null;
		/// <summary>
		/// ��¼�˺�
		/// </summary>
		[EntityInfo("��¼�˺�")]
		public new string UserName { get { return userName; } set { userName = value; } }

		/// <summary>
		/// ��¼����
		/// </summary>
		public static readonly string _MPassword = "MPassword";
		private string mPassword = null;
		/// <summary>
		/// ��¼����
		/// </summary>
		[EntityInfo("��¼����")]
		public new string MPassword { get { return mPassword; } set { mPassword = value; } }
	}
}



