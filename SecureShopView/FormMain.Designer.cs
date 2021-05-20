
namespace SecureShopView
{
	partial class FormMain
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
			this.topMenuStrip = new System.Windows.Forms.MenuStrip();
			this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.устройстваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.комплектыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.списокУстройствToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.устройстваПоКомплектациямToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.списокЗазказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.createOrderBtn = new System.Windows.Forms.Button();
			this.takeToExecutionBtn = new System.Windows.Forms.Button();
			this.orderReadyBtn = new System.Windows.Forms.Button();
			this.orderPayedBtn = new System.Windows.Forms.Button();
			this.updateListBtn = new System.Windows.Forms.Button();
			this.topMenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// topMenuStrip
			// 
			this.topMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.topMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.отчетыToolStripMenuItem});
			this.topMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.topMenuStrip.Name = "topMenuStrip";
			this.topMenuStrip.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
			this.topMenuStrip.Size = new System.Drawing.Size(1305, 35);
			this.topMenuStrip.TabIndex = 0;
			this.topMenuStrip.Text = "menuStrip1";
			// 
			// справочникиToolStripMenuItem
			// 
			this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.устройстваToolStripMenuItem,
            this.комплектыToolStripMenuItem});
			this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
			this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(139, 29);
			this.справочникиToolStripMenuItem.Text = "Справочники";
			// 
			// устройстваToolStripMenuItem
			// 
			this.устройстваToolStripMenuItem.Name = "устройстваToolStripMenuItem";
			this.устройстваToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
			this.устройстваToolStripMenuItem.Text = "Материала";
			this.устройстваToolStripMenuItem.Click += new System.EventHandler(this.MaterialsToolStripMenuItem_Click);
			// 
			// комплектыToolStripMenuItem
			// 
			this.комплектыToolStripMenuItem.Name = "комплектыToolStripMenuItem";
			this.комплектыToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
			this.комплектыToolStripMenuItem.Text = "Комплекты";
			this.комплектыToolStripMenuItem.Click += new System.EventHandler(this.ModulesToolStripMenuItem_Click);
			// 
			// отчетыToolStripMenuItem
			// 
			this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокУстройствToolStripMenuItem,
            this.устройстваПоКомплектациямToolStripMenuItem,
            this.списокЗазказовToolStripMenuItem});
			this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
			this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
			this.отчетыToolStripMenuItem.Text = "Отчеты";
			// 
			// списокУстройствToolStripMenuItem
			// 
			this.списокУстройствToolStripMenuItem.Name = "списокУстройствToolStripMenuItem";
			this.списокУстройствToolStripMenuItem.Size = new System.Drawing.Size(365, 34);
			this.списокУстройствToolStripMenuItem.Text = "Список устройств";
			this.списокУстройствToolStripMenuItem.Click += new System.EventHandler(this.MaterialsToolStripMenuReportItem_Click);
			// 
			// устройстваПоКомплектациямToolStripMenuItem
			// 
			this.устройстваПоКомплектациямToolStripMenuItem.Name = "устройстваПоКомплектациямToolStripMenuItem";
			this.устройстваПоКомплектациямToolStripMenuItem.Size = new System.Drawing.Size(365, 34);
			this.устройстваПоКомплектациямToolStripMenuItem.Text = "Материала по комплектациям";
			this.устройстваПоКомплектациямToolStripMenuItem.Click += new System.EventHandler(this.MaterialModulesToolStripMenuItem_Click);
			// 
			// списокЗазказовToolStripMenuItem
			// 
			this.списокЗазказовToolStripMenuItem.Name = "списокЗазказовToolStripMenuItem";
			this.списокЗазказовToolStripMenuItem.Size = new System.Drawing.Size(365, 34);
			this.списокЗазказовToolStripMenuItem.Text = "Список зазказов";
			this.списокЗазказовToolStripMenuItem.Click += new System.EventHandler(this.OrdersToolStripMenuItem_Click);
			// 
			// dataGridView
			// 
			this.dataGridView.BackgroundColor = System.Drawing.Color.White;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Location = new System.Drawing.Point(18, 42);
			this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.RowHeadersWidth = 62;
			this.dataGridView.Size = new System.Drawing.Size(951, 632);
			this.dataGridView.TabIndex = 1;
			// 
			// createOrderBtn
			// 
			this.createOrderBtn.Location = new System.Drawing.Point(1024, 185);
			this.createOrderBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.createOrderBtn.Name = "createOrderBtn";
			this.createOrderBtn.Size = new System.Drawing.Size(222, 35);
			this.createOrderBtn.TabIndex = 2;
			this.createOrderBtn.Text = "Создать заказ";
			this.createOrderBtn.UseVisualStyleBackColor = true;
			this.createOrderBtn.Click += new System.EventHandler(this.ButtonCreateOrder_Click);
			// 
			// takeToExecutionBtn
			// 
			this.takeToExecutionBtn.Location = new System.Drawing.Point(1024, 262);
			this.takeToExecutionBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.takeToExecutionBtn.Name = "takeToExecutionBtn";
			this.takeToExecutionBtn.Size = new System.Drawing.Size(222, 35);
			this.takeToExecutionBtn.TabIndex = 3;
			this.takeToExecutionBtn.Text = "Отдать на выполнение";
			this.takeToExecutionBtn.UseVisualStyleBackColor = true;
			this.takeToExecutionBtn.Click += new System.EventHandler(this.ButtonTakeOrderInWork_Click);
			// 
			// orderReadyBtn
			// 
			this.orderReadyBtn.Location = new System.Drawing.Point(1024, 338);
			this.orderReadyBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.orderReadyBtn.Name = "orderReadyBtn";
			this.orderReadyBtn.Size = new System.Drawing.Size(222, 35);
			this.orderReadyBtn.TabIndex = 4;
			this.orderReadyBtn.Text = "Заказ готов";
			this.orderReadyBtn.UseVisualStyleBackColor = true;
			this.orderReadyBtn.Click += new System.EventHandler(this.ButtonOrderReady_Click);
			// 
			// orderPayedBtn
			// 
			this.orderPayedBtn.Location = new System.Drawing.Point(1024, 415);
			this.orderPayedBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.orderPayedBtn.Name = "orderPayedBtn";
			this.orderPayedBtn.Size = new System.Drawing.Size(222, 35);
			this.orderPayedBtn.TabIndex = 5;
			this.orderPayedBtn.Text = "Заказ оплачен";
			this.orderPayedBtn.UseVisualStyleBackColor = true;
			this.orderPayedBtn.Click += new System.EventHandler(this.ButtonPayOrder_Click);
			// 
			// updateListBtn
			// 
			this.updateListBtn.Location = new System.Drawing.Point(1024, 492);
			this.updateListBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.updateListBtn.Name = "updateListBtn";
			this.updateListBtn.Size = new System.Drawing.Size(222, 35);
			this.updateListBtn.TabIndex = 6;
			this.updateListBtn.Text = "Обновить список";
			this.updateListBtn.UseVisualStyleBackColor = true;
			this.updateListBtn.Click += new System.EventHandler(this.ButtonRef_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1305, 692);
			this.Controls.Add(this.updateListBtn);
			this.Controls.Add(this.orderPayedBtn);
			this.Controls.Add(this.orderReadyBtn);
			this.Controls.Add(this.takeToExecutionBtn);
			this.Controls.Add(this.createOrderBtn);
			this.Controls.Add(this.dataGridView);
			this.Controls.Add(this.topMenuStrip);
			this.MainMenuStrip = this.topMenuStrip;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "FormMain";
			this.Text = "Магазин охранных систем";
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.topMenuStrip.ResumeLayout(false);
			this.topMenuStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip topMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem устройстваToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem комплектыToolStripMenuItem;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Button createOrderBtn;
		private System.Windows.Forms.Button takeToExecutionBtn;
		private System.Windows.Forms.Button orderReadyBtn;
		private System.Windows.Forms.Button orderPayedBtn;
		private System.Windows.Forms.Button updateListBtn;
		private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem списокУстройствToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem устройстваПоКомплектациямToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem списокЗазказовToolStripMenuItem;
	}
}