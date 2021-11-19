
namespace Final__Convert_NmapXML_To_Word_01
{
    partial class Form1
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
            this.btn_ChooseFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Status = new System.Windows.Forms.TextBox();
            this.textBox_FilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Convert = new System.Windows.Forms.Button();
            this.textBox_OutputFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_ChooseFile
            // 
            this.btn_ChooseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btn_ChooseFile.Location = new System.Drawing.Point(287, 12);
            this.btn_ChooseFile.Name = "btn_ChooseFile";
            this.btn_ChooseFile.Size = new System.Drawing.Size(191, 53);
            this.btn_ChooseFile.TabIndex = 0;
            this.btn_ChooseFile.Text = "Choose File";
            this.btn_ChooseFile.UseVisualStyleBackColor = true;
            this.btn_ChooseFile.Click += new System.EventHandler(this.btn_ChooseFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.Location = new System.Drawing.Point(39, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Status";
            // 
            // textBox_Status
            // 
            this.textBox_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Status.Location = new System.Drawing.Point(45, 189);
            this.textBox_Status.Name = "textBox_Status";
            this.textBox_Status.Size = new System.Drawing.Size(433, 41);
            this.textBox_Status.TabIndex = 2;
            // 
            // textBox_FilePath
            // 
            this.textBox_FilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_FilePath.Location = new System.Drawing.Point(45, 71);
            this.textBox_FilePath.Name = "textBox_FilePath";
            this.textBox_FilePath.Size = new System.Drawing.Size(433, 41);
            this.textBox_FilePath.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label2.Location = new System.Drawing.Point(39, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 36);
            this.label2.TabIndex = 4;
            this.label2.Text = "Input File Path";
            // 
            // btn_Convert
            // 
            this.btn_Convert.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btn_Convert.Location = new System.Drawing.Point(287, 130);
            this.btn_Convert.Name = "btn_Convert";
            this.btn_Convert.Size = new System.Drawing.Size(191, 53);
            this.btn_Convert.TabIndex = 5;
            this.btn_Convert.Text = "Convert";
            this.btn_Convert.UseVisualStyleBackColor = true;
            this.btn_Convert.Click += new System.EventHandler(this.btn_Convert_Click);
            // 
            // textBox_OutputFileName
            // 
            this.textBox_OutputFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_OutputFileName.Location = new System.Drawing.Point(45, 287);
            this.textBox_OutputFileName.Name = "textBox_OutputFileName";
            this.textBox_OutputFileName.Size = new System.Drawing.Size(433, 41);
            this.textBox_OutputFileName.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label3.Location = new System.Drawing.Point(39, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 36);
            this.label3.TabIndex = 6;
            this.label3.Text = "Output file name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(533, 336);
            this.Controls.Add(this.textBox_OutputFileName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Convert);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_FilePath);
            this.Controls.Add(this.textBox_Status);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ChooseFile);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Form1";
            this.Text = "Nmap XML -> Word";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ChooseFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Status;
        private System.Windows.Forms.TextBox textBox_FilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Convert;
        private System.Windows.Forms.TextBox textBox_OutputFileName;
        private System.Windows.Forms.Label label3;
    }
}

