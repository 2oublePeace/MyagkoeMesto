﻿using System;
using System.Windows.Forms;
using MebelBusinessLogic.BindingModels;
using MebelBusinessLogic.BusinessLogics;
using Unity;

namespace SecureShopView
{
	public partial class FormMaterial : Form
	{
		[Dependency]
		public new IUnityContainer Container { get; set; }
		public int Id { set { id = value; } }
		private readonly MaterialLogic logic;
		private int? id;
		public FormMaterial(MaterialLogic logic)
		{
			InitializeComponent();
			this.logic = logic;
		}
		private void FormMaterial_Load(object sender, EventArgs e)
		{
			if (id.HasValue)
			{
				try
				{
					var view = logic.Read(new MaterialBindingModel { Id = id })?[0];
					if (view != null)
					{
						materialTextBox.Text = view.MaterialName;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
				   MessageBoxIcon.Error);
				}
			}
		}
		private void ButtonSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(materialTextBox.Text))
			{
				MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
			   MessageBoxIcon.Error);
				return;
			}
			try
			{
				logic.CreateOrUpdate(new MaterialBindingModel
				{
					Id = id,
					MaterialName = materialTextBox.Text
				});
				MessageBox.Show("Сохранение прошло успешно", "Сообщение",
			   MessageBoxButtons.OK, MessageBoxIcon.Information);
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
			   MessageBoxIcon.Error);
			}
		}
		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}