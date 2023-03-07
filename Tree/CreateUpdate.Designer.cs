
namespace Tree
{
    partial class CreateUpdate
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
            this.components = new System.ComponentModel.Container();
            this.lbParent = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbTree = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.numboxPrice = new NumboxColtrols.Numbox(this.components);
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCanel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbParent
            // 
            this.lbParent.AutoSize = true;
            this.lbParent.Location = new System.Drawing.Point(63, 26);
            this.lbParent.Name = "lbParent";
            this.lbParent.Size = new System.Drawing.Size(61, 13);
            this.lbParent.TabIndex = 0;
            this.lbParent.Text = "Родитель: ";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(61, 68);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(63, 13);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "Название: ";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(63, 109);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(36, 13);
            this.lbPrice.TabIndex = 2;
            this.lbPrice.Text = "Цена:";
            // 
            // lbTree
            // 
            this.lbTree.AutoSize = true;
            this.lbTree.Location = new System.Drawing.Point(142, 26);
            this.lbTree.Name = "lbTree";
            this.lbTree.Size = new System.Drawing.Size(0, 13);
            this.lbTree.TabIndex = 3;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(135, 68);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 5;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // numboxPrice
            // 
            this.numboxPrice.Location = new System.Drawing.Point(135, 109);
            this.numboxPrice.Name = "numboxPrice";
            this.numboxPrice.Size = new System.Drawing.Size(100, 20);
            this.numboxPrice.TabIndex = 4;
            this.numboxPrice.TextChanged += new System.EventHandler(this.numboxPrice_TextChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(169, 189);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCanel
            // 
            this.btnCanel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCanel.Location = new System.Drawing.Point(250, 189);
            this.btnCanel.Name = "btnCanel";
            this.btnCanel.Size = new System.Drawing.Size(75, 23);
            this.btnCanel.TabIndex = 7;
            this.btnCanel.Text = "Cancel";
            this.btnCanel.UseVisualStyleBackColor = true;
            this.btnCanel.Click += new System.EventHandler(this.btnCanel_Click);
            // 
            // CreateUpdate
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCanel;
            this.ClientSize = new System.Drawing.Size(362, 224);
            this.Controls.Add(this.btnCanel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.numboxPrice);
            this.Controls.Add(this.lbTree);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.lbParent);
            this.Name = "CreateUpdate";
            this.Text = "CreateUpdate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbParent;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label lbTree;
        private NumboxColtrols.Numbox numboxPrice;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCanel;
    }
}