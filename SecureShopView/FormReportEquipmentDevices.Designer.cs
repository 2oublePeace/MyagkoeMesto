
namespace SecureShopView
{
	partial class FormReportModuleMaterials
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.saveInExcelBtn = new System.Windows.Forms.Button();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// saveInExcelBtn
			// 
			this.saveInExcelBtn.Location = new System.Drawing.Point(18, 18);
			this.saveInExcelBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.saveInExcelBtn.Name = "saveInExcelBtn";
			this.saveInExcelBtn.Size = new System.Drawing.Size(214, 31);
			this.saveInExcelBtn.TabIndex = 0;
			this.saveInExcelBtn.Text = "Сохранить в Excel";
			this.saveInExcelBtn.UseVisualStyleBackColor = true;
			this.saveInExcelBtn.Click += new System.EventHandler(this.ButtonSaveToExcel_Click);
			// 
			// dataGridView
			// 
			this.dataGridView.BackgroundColor = System.Drawing.Color.White;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
			this.dataGridView.Location = new System.Drawing.Point(18, 58);
			this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.RowHeadersWidth = 62;
			this.dataGridView.Size = new System.Drawing.Size(663, 615);
			this.dataGridView.TabIndex = 1;
			// 
			// Column1
			// 
			this.Column1.HeaderText = "Устройство";
			this.Column1.MinimumWidth = 8;
			this.Column1.Name = "Column1";
			this.Column1.Width = 125;
			// 
			// Column2
			// 
			this.Column2.HeaderText = "Комплектация";
			this.Column2.MinimumWidth = 8;
			this.Column2.Name = "Column2";
			this.Column2.Width = 175;
			// 
			// Column3
			// 
			this.Column3.HeaderText = "Количество";
			this.Column3.MinimumWidth = 8;
			this.Column3.Name = "Column3";
			this.Column3.Width = 75;
			// 
			// FormReportModuleMaterials
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(699, 692);
			this.Controls.Add(this.dataGridView);
			this.Controls.Add(this.saveInExcelBtn);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "FormReportModuleMaterials";
			this.Text = "FormReportModuleMaterials";
			this.Load += new System.EventHandler(this.FormReportModuleMaterials_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button saveInExcelBtn;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
	}
}