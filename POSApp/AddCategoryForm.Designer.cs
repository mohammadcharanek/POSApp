namespace POSApp
{
    partial class AddCategoryForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.btnSaveCategory = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category Name";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(256, 143);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(165, 22);
            this.txtCategoryName.TabIndex = 1;
            // 
            // btnSaveCategory
            // 
            this.btnSaveCategory.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSaveCategory.Location = new System.Drawing.Point(256, 185);
            this.btnSaveCategory.Name = "btnSaveCategory";
            this.btnSaveCategory.Size = new System.Drawing.Size(126, 42);
            this.btnSaveCategory.TabIndex = 2;
            this.btnSaveCategory.Text = "Add Category";
            this.btnSaveCategory.UseVisualStyleBackColor = false;
            this.btnSaveCategory.Click += new System.EventHandler(this.btnSaveCategory_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCancel.Location = new System.Drawing.Point(389, 185);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(119, 42);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnReturn.Location = new System.Drawing.Point(48, 45);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(150, 57);
            this.btnReturn.TabIndex = 4;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // AddCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 450);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveCategory);
            this.Controls.Add(this.txtCategoryName);
            this.Controls.Add(this.label1);
            this.Name = "AddCategoryForm";
            this.Text = "AddCategoryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Button btnSaveCategory;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnReturn;
    }
}