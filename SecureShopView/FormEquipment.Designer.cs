
namespace SecureShopView
{
	partial class FormModule
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
			this.nameLbl = new System.Windows.Forms.Label();
			this.priceLbl = new System.Windows.Forms.Label();
			this.textBoxPrice = new System.Windows.Forms.TextBox();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.moduleGroupBox = new System.Windows.Forms.GroupBox();
			this.updateBtn = new System.Windows.Forms.Button();
			this.deleteBtn = new System.Windows.Forms.Button();
			this.editBtn = new System.Windows.Forms.Button();
			this.addBtn = new System.Windows.Forms.Button();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.materialID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.materialColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.countColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.saveBtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.moduleGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// nameLbl
			// 
			this.nameLbl.AutoSize = true;
			this.nameLbl.Location = new System.Drawing.Point(24, 14);
			this.nameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.nameLbl.Name = "nameLbl";
			this.nameLbl.Size = new System.Drawing.Size(87, 20);
			this.nameLbl.TabIndex = 0;
			this.nameLbl.Text = "Название:";
			// 
			// priceLbl
			// 
			this.priceLbl.AutoSize = true;
			this.priceLbl.Location = new System.Drawing.Point(24, 63);
			this.priceLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.priceLbl.Name = "priceLbl";
			this.priceLbl.Size = new System.Drawing.Size(52, 20);
			this.priceLbl.TabIndex = 1;
			this.priceLbl.Text = "Цена:";
			// 
			// textBoxPrice
			// 
			this.textBoxPrice.Location = new System.Drawing.Point(122, 58);
			this.textBoxPrice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.textBoxPrice.Name = "textBoxPrice";
			this.textBoxPrice.Size = new System.Drawing.Size(270, 26);
			this.textBoxPrice.TabIndex = 2;
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(122, 9);
			this.textBoxName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(270, 26);
			this.textBoxName.TabIndex = 3;
			// 
			// moduleGroupBox
			// 
			this.moduleGroupBox.Controls.Add(this.updateBtn);
			this.moduleGroupBox.Controls.Add(this.deleteBtn);
			this.moduleGroupBox.Controls.Add(this.editBtn);
			this.moduleGroupBox.Controls.Add(this.addBtn);
			this.moduleGroupBox.Controls.Add(this.dataGridView);
			this.moduleGroupBox.Location = new System.Drawing.Point(18, 94);
			this.moduleGroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.moduleGroupBox.Name = "moduleGroupBox";
			this.moduleGroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.moduleGroupBox.Size = new System.Drawing.Size(930, 509);
			this.moduleGroupBox.TabIndex = 4;
			this.moduleGroupBox.TabStop = false;
			this.moduleGroupBox.Text = "Материала";
			// 
			// updateBtn
			// 
			this.updateBtn.Location = new System.Drawing.Point(724, 332);
			this.updateBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.updateBtn.Name = "updateBtn";
			this.updateBtn.Size = new System.Drawing.Size(112, 35);
			this.updateBtn.TabIndex = 4;
			this.updateBtn.Text = "Обновить";
			this.updateBtn.UseVisualStyleBackColor = true;
			this.updateBtn.Click += new System.EventHandler(this.ButtonUpdate_Click);
			// 
			// deleteBtn
			// 
			this.deleteBtn.Location = new System.Drawing.Point(724, 240);
			this.deleteBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.deleteBtn.Name = "deleteBtn";
			this.deleteBtn.Size = new System.Drawing.Size(112, 35);
			this.deleteBtn.TabIndex = 3;
			this.deleteBtn.Text = "Удалить";
			this.deleteBtn.UseVisualStyleBackColor = true;
			this.deleteBtn.Click += new System.EventHandler(this.ButtonDel_Click);
			// 
			// editBtn
			// 
			this.editBtn.Location = new System.Drawing.Point(724, 154);
			this.editBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.editBtn.Name = "editBtn";
			this.editBtn.Size = new System.Drawing.Size(112, 35);
			this.editBtn.TabIndex = 2;
			this.editBtn.Text = "Изменить";
			this.editBtn.UseVisualStyleBackColor = true;
			this.editBtn.Click += new System.EventHandler(this.ButtonEdit_Click);
			// 
			// addBtn
			// 
			this.addBtn.Location = new System.Drawing.Point(724, 72);
			this.addBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.addBtn.Name = "addBtn";
			this.addBtn.Size = new System.Drawing.Size(112, 35);
			this.addBtn.TabIndex = 1;
			this.addBtn.Text = "Добавить";
			this.addBtn.UseVisualStyleBackColor = true;
			this.addBtn.Click += new System.EventHandler(this.ButtonAdd_Click);
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToAddRows = false;
			this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.materialID,
            this.materialColumn,
            this.countColumn});
			this.dataGridView.GridColor = System.Drawing.SystemColors.ControlLightLight;
			this.dataGridView.Location = new System.Drawing.Point(10, 29);
			this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.RowHeadersWidth = 62;
			this.dataGridView.Size = new System.Drawing.Size(698, 400);
			this.dataGridView.TabIndex = 0;
			// 
			// materialID
			// 
			this.materialID.HeaderText = "ID";
			this.materialID.MinimumWidth = 8;
			this.materialID.Name = "materialID";
			this.materialID.Visible = false;
			this.materialID.Width = 150;
			// 
			// materialColumn
			// 
			this.materialColumn.HeaderText = "Устройство";
			this.materialColumn.MinimumWidth = 8;
			this.materialColumn.Name = "materialColumn";
			this.materialColumn.Width = 200;
			// 
			// countColumn
			// 
			this.countColumn.HeaderText = "Количество";
			this.countColumn.MinimumWidth = 8;
			this.countColumn.Name = "countColumn";
			this.countColumn.Width = 230;
			// 
			// saveBtn
			// 
			this.saveBtn.Location = new System.Drawing.Point(714, 612);
			this.saveBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.Size = new System.Drawing.Size(112, 35);
			this.saveBtn.TabIndex = 5;
			this.saveBtn.Text = "Сохранить";
			this.saveBtn.UseVisualStyleBackColor = true;
			this.saveBtn.Click += new System.EventHandler(this.ButtonSave_Click);
			// 
			// cancelBtn
			// 
			this.cancelBtn.Location = new System.Drawing.Point(836, 612);
			this.cancelBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(112, 35);
			this.cancelBtn.TabIndex = 6;
			this.cancelBtn.Text = "Отмена";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// FormModule
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1200, 692);
			this.Controls.Add(this.saveBtn);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.moduleGroupBox);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.textBoxPrice);
			this.Controls.Add(this.priceLbl);
			this.Controls.Add(this.nameLbl);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "FormModule";
			this.Text = "Создать комплектацию";
			this.Load += new System.EventHandler(this.FormModule_Load);
			this.moduleGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label nameLbl;
		private System.Windows.Forms.Label priceLbl;
		private System.Windows.Forms.TextBox textBoxPrice;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.GroupBox moduleGroupBox;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Button updateBtn;
		private System.Windows.Forms.Button deleteBtn;
		private System.Windows.Forms.Button editBtn;
		private System.Windows.Forms.Button addBtn;
		private System.Windows.Forms.Button saveBtn;
		private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialID;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countColumn;
    }
}