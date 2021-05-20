
namespace SecureShopView
{
	partial class FormReportOrders
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
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.sWordLabel = new System.Windows.Forms.Label();
			this.poWordLabel = new System.Windows.Forms.Label();
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.performBtn = new System.Windows.Forms.Button();
			this.toPdfBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(28, 12);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker1.TabIndex = 0;
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.Location = new System.Drawing.Point(272, 12);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker2.TabIndex = 1;
			// 
			// sWordLabel
			// 
			this.sWordLabel.AutoSize = true;
			this.sWordLabel.Location = new System.Drawing.Point(8, 15);
			this.sWordLabel.Name = "sWordLabel";
			this.sWordLabel.Size = new System.Drawing.Size(14, 13);
			this.sWordLabel.TabIndex = 2;
			this.sWordLabel.Text = "С";
			// 
			// poWordLabel
			// 
			this.poWordLabel.AutoSize = true;
			this.poWordLabel.Location = new System.Drawing.Point(240, 15);
			this.poWordLabel.Name = "poWordLabel";
			this.poWordLabel.Size = new System.Drawing.Size(19, 13);
			this.poWordLabel.TabIndex = 3;
			this.poWordLabel.Text = "по";
			// 
			// reportViewer1
			// 
			this.reportViewer1.LocalReport.ReportEmbeddedResource = "SecureShopView.Report.rdlc";
			this.reportViewer1.Location = new System.Drawing.Point(11, 38);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.ServerReport.BearerToken = null;
			this.reportViewer1.Size = new System.Drawing.Size(777, 400);
			this.reportViewer1.TabIndex = 4;
			// 
			// performBtn
			// 
			this.performBtn.Location = new System.Drawing.Point(478, 9);
			this.performBtn.Name = "performBtn";
			this.performBtn.Size = new System.Drawing.Size(91, 23);
			this.performBtn.TabIndex = 5;
			this.performBtn.Text = "Сформировать";
			this.performBtn.UseVisualStyleBackColor = true;
			this.performBtn.Click += new System.EventHandler(this.buttonCreateReport_Click);
			// 
			// toPdfBtn
			// 
			this.toPdfBtn.Location = new System.Drawing.Point(713, 9);
			this.toPdfBtn.Name = "toPdfBtn";
			this.toPdfBtn.Size = new System.Drawing.Size(75, 23);
			this.toPdfBtn.TabIndex = 6;
			this.toPdfBtn.Text = "В Pdf";
			this.toPdfBtn.UseVisualStyleBackColor = true;
			this.toPdfBtn.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// FormReportOrders
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.toPdfBtn);
			this.Controls.Add(this.performBtn);
			this.Controls.Add(this.reportViewer1);
			this.Controls.Add(this.poWordLabel);
			this.Controls.Add(this.sWordLabel);
			this.Controls.Add(this.dateTimePicker2);
			this.Controls.Add(this.dateTimePicker1);
			this.Name = "FormReportOrders";
			this.Text = "FormClientOrders";
			this.Load += new System.EventHandler(this.FormReportOrders_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.Label sWordLabel;
		private System.Windows.Forms.Label poWordLabel;
		private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
		private System.Windows.Forms.Button performBtn;
		private System.Windows.Forms.Button toPdfBtn;
	}
}