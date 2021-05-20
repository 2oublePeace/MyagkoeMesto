using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MebelBusinessLogic.BindingModels;
using MebelBusinessLogic.BusinessLogics;
using MebelBusinessLogic.ViewModels;
using Unity;

namespace SecureShopView
{
	public partial class FormModuleMaterials : Form
	{
		[Dependency]
		public new IUnityContainer Container { get; set; }
		public int Id
		{
			get { return Convert.ToInt32(comboBoxMaterial.SelectedValue); }
			set { comboBoxMaterial.SelectedValue = value; }
		}
		public string ComponentName { get { return comboBoxMaterial.Text; } }
		public int Count
		{
			get { return Convert.ToInt32(textBoxCount.Text); }
			set
			{
				textBoxCount.Text = value.ToString();
			}
		}
		public FormModuleMaterials(MaterialLogic logic)
		{
			InitializeComponent();
			List<MaterialViewModel> list = logic.Read(null);
			if (list != null)
			{
				comboBoxMaterial.DisplayMember = "MaterialName";
				comboBoxMaterial.ValueMember = "Id";
				comboBoxMaterial.DataSource = list;
				comboBoxMaterial.SelectedItem = null;
			}
		}
		private void ButtonSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxCount.Text))
			{
				MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (comboBoxMaterial.SelectedValue == null)
			{
				MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
		    }
			DialogResult = DialogResult.OK;
			Close();
		}
		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

	}
}
