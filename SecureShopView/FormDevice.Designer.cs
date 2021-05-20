
namespace SecureShopView
{
	partial class FormMaterial
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.materialSaveBtn = new System.Windows.Forms.Button();
            this.materialCancelBtn = new System.Windows.Forms.Button();
            this.materialLbl = new System.Windows.Forms.Label();
            this.materialTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // materialSaveBtn
            // 
            this.materialSaveBtn.Location = new System.Drawing.Point(152, 30);
            this.materialSaveBtn.Name = "materialSaveBtn";
            this.materialSaveBtn.Size = new System.Drawing.Size(71, 22);
            this.materialSaveBtn.TabIndex = 0;
            this.materialSaveBtn.Text = "Сохранить";
            this.materialSaveBtn.UseVisualStyleBackColor = true;
            this.materialSaveBtn.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // materialCancelBtn
            // 
            this.materialCancelBtn.Location = new System.Drawing.Point(229, 30);
            this.materialCancelBtn.Name = "materialCancelBtn";
            this.materialCancelBtn.Size = new System.Drawing.Size(64, 22);
            this.materialCancelBtn.TabIndex = 1;
            this.materialCancelBtn.Text = "Отмена";
            this.materialCancelBtn.UseVisualStyleBackColor = true;
            this.materialCancelBtn.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // materialLbl
            // 
            this.materialLbl.AutoSize = true;
            this.materialLbl.Location = new System.Drawing.Point(10, 8);
            this.materialLbl.Name = "materialLbl";
            this.materialLbl.Size = new System.Drawing.Size(60, 13);
            this.materialLbl.TabIndex = 2;
            this.materialLbl.Text = "Название:";
            // 
            // materialTextBox
            // 
            this.materialTextBox.Location = new System.Drawing.Point(71, 5);
            this.materialTextBox.Name = "materialTextBox";
            this.materialTextBox.Size = new System.Drawing.Size(223, 20);
            this.materialTextBox.TabIndex = 3;
            // 
            // FormMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 58);
            this.Controls.Add(this.materialTextBox);
            this.Controls.Add(this.materialLbl);
            this.Controls.Add(this.materialCancelBtn);
            this.Controls.Add(this.materialSaveBtn);
            this.Name = "FormMaterial";
            this.Text = "Создать устройство";
            this.Load += new System.EventHandler(this.FormMaterial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button materialSaveBtn;
		private System.Windows.Forms.Button materialCancelBtn;
		private System.Windows.Forms.Label materialLbl;
		private System.Windows.Forms.TextBox materialTextBox;
	}
}

