using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using MebelBusinessLogic.BindingModels;
using MebelBusinessLogic.BusinessLogics;
using MebelBusinessLogic.ViewModels;

namespace SecureShopView
{
	public partial class FormModule : Form
	{
		[Dependency]
		public new IUnityContainer Container { get; set; }
		public int Id { set { id = value; } }
		private readonly ModuleLogic logic;
		private int? id;
		private Dictionary<int, (string, int)> moduleComponents;
		public FormModule(ModuleLogic service)
		{
			InitializeComponent();
			this.logic = service;
		}
		private void FormModule_Load(object sender, EventArgs e)
		{
			if (id.HasValue)
			{
				try
				{
					ModuleViewModel view = logic.Read(new ModuleBindingModel{Id =id.Value})?[0];
					if (view != null)
					{
						textBoxName.Text = view.ModuleName;
						textBoxPrice.Text = view.Price.ToString();
						moduleComponents = view.ModuleMaterials;
						LoadData();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				moduleComponents = new Dictionary<int, (string, int)>();
			}
		}
		private void LoadData()
		{
			try
			{
				if (moduleComponents != null)
				{
					dataGridView.Rows.Clear();
					foreach (var pc in moduleComponents)
					{
						dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2 });
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
			   MessageBoxIcon.Error);
			}
		}
		private void ButtonAdd_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormModuleMaterials>();
			if (form.ShowDialog() == DialogResult.OK)
			{
				if (moduleComponents.ContainsKey(form.Id))
				{
					moduleComponents[form.Id] = (form.ComponentName, form.Count);
				}
				else
				{
					moduleComponents.Add(form.Id, (form.ComponentName, form.Count));
				}
				LoadData();
			}
		}
		private void ButtonEdit_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				var form = Container.Resolve<FormModuleMaterials>();
				int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
				form.Id = id;
				form.Count = moduleComponents[id].Item2;
				if (form.ShowDialog() == DialogResult.OK)
				{
					moduleComponents[form.Id] = (form.ComponentName, form.Count);
					LoadData();
				}
			}
		}
		private void ButtonDel_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
			   MessageBoxIcon.Question) == DialogResult.Yes)
				{
					try
					{

						moduleComponents.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
					   MessageBoxIcon.Error);
					}
					LoadData();
				}
			}
		}
		private void ButtonUpdate_Click(object sender, EventArgs e)
		{
			LoadData();
		}
		private void ButtonSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxName.Text))
			{
				MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
			   MessageBoxIcon.Error);
				return;
			}
			if (string.IsNullOrEmpty(textBoxPrice.Text))
			{
				MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
			   MessageBoxIcon.Error);
				return;
			}
			if (moduleComponents == null || moduleComponents.Count == 0)
			{
				MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
			   MessageBoxIcon.Error);
				return;
			}
			try
			{
				logic.CreateOrUpdate(new ModuleBindingModel{Id = id, ModuleName = textBoxName.Text, Price = Convert.ToDecimal(textBoxPrice.Text), ModuleMaterials = moduleComponents});
				MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
