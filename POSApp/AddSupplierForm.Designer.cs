namespace POSApp
{
    partial class AddSupplierForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.txtContactInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddSupplier = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(52, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 61);
            this.button1.TabIndex = 0;
            this.button1.Text = "Return";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Location = new System.Drawing.Point(207, 132);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(128, 22);
            this.txtSupplierName.TabIndex = 1;
            // 
            // txtContactInfo
            // 
            this.txtContactInfo.Location = new System.Drawing.Point(207, 172);
            this.txtContactInfo.Name = "txtContactInfo";
            this.txtContactInfo.Size = new System.Drawing.Size(128, 22);
            this.txtContactInfo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Supplier Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Info";
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAddSupplier.Location = new System.Drawing.Point(207, 218);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(108, 37);
            this.btnAddSupplier.TabIndex = 5;
            this.btnAddSupplier.Text = "Add Supplier";
            this.btnAddSupplier.UseVisualStyleBackColor = false;
            this.btnAddSupplier.Click += new System.EventHandler(this.btnAddSupplier_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCancel.Location = new System.Drawing.Point(331, 218);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 37);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddSupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddSupplier);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtContactInfo);
            this.Controls.Add(this.txtSupplierName);
            this.Controls.Add(this.button1);
            this.Name = "AddSupplierForm";
            this.Text = "AddSupplierForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.TextBox txtContactInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddSupplier;
        private System.Windows.Forms.Button btnCancel;
    }
}