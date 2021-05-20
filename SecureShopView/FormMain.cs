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

namespace SecureShopView
{
	public partial class FormMain : Form
	{
		[Dependency]
		public new IUnityContainer Container { get; set; }
		private readonly SupplyLogic _orderLogic;
		private readonly ReportLogic _reportLogic;
		public FormMain(SupplyLogic orderLogic, ReportLogic reportLogic)
		{
			InitializeComponent();
			this._orderLogic = orderLogic;
			this._reportLogic = reportLogic;
		}
		private void FormMain_Load(object sender, EventArgs e)
		{
			LoadData();
		}
		private void LoadData()
		{
			try
			{
				var list = _orderLogic.Read(null);
				if (list != null)
				{
					dataGridView.DataSource = list;
					dataGridView.Columns[0].Visible = false;
					dataGridView.Columns[1].Visible = false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void MaterialsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormMaterials>();
			form.ShowDialog();
		}
		private void ModulesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormModules>();
			form.ShowDialog();
		}
		private void ButtonCreateOrder_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormCreateOrder>();
			form.ShowDialog();
			LoadData();
		}
		private void ButtonTakeOrderInWork_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
				try
				{
					_orderLogic.TakeOrderInWork(new ChangeStatusBindingModel { OrderId = id });
					LoadData();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		private void ButtonOrderReady_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
				try
				{
					_orderLogic.FinishOrder(new ChangeStatusBindingModel { OrderId = id });
					LoadData();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		private void ButtonPayOrder_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
				try
				{
					_orderLogic.PayOrder(new ChangeStatusBindingModel { OrderId = id });
					LoadData();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void MaterialsToolStripMenuReportItem_Click(object sender, EventArgs e)
		{
			using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
			{
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					_reportLogic.SaveMaterialsToWordFile(new ReportBindingModel
					{
						FileName = dialog.FileName
					});
					MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void MaterialModulesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormReportModuleMaterials>(); form.ShowDialog();
		}

		private void OrdersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Container.Resolve<FormReportOrders>(); form.ShowDialog();
		}


		private void ButtonRef_Click(object sender, EventArgs e)
		{
			LoadData();
		}
	}
}
