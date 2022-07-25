namespace AccountingParser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.csvFile = new System.Windows.Forms.OpenFileDialog();
            this.inputFileBttn = new System.Windows.Forms.Button();
            this.csvFileTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OKBttn = new System.Windows.Forms.Button();
            this.cancelBttn = new System.Windows.Forms.Button();
            this.outputFileTxt = new System.Windows.Forms.TextBox();
            this.outputFileBttn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.outputFile = new System.Windows.Forms.SaveFileDialog();
            this.errLbl = new System.Windows.Forms.Label();
            this.entryLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // csvFile
            // 
            this.csvFile.InitialDirectory = "C:\\users\\%USERNAME%\\Documents\\";
            this.csvFile.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk);
            // 
            // inputFileBttn
            // 
            this.inputFileBttn.Location = new System.Drawing.Point(417, 91);
            this.inputFileBttn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.inputFileBttn.Name = "inputFileBttn";
            this.inputFileBttn.Size = new System.Drawing.Size(56, 19);
            this.inputFileBttn.TabIndex = 0;
            this.inputFileBttn.Text = "Browse...";
            this.inputFileBttn.UseVisualStyleBackColor = true;
            this.inputFileBttn.Click += new System.EventHandler(this.InputFileBttn_Click);
            // 
            // csvFileTxt
            // 
            this.csvFileTxt.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.csvFileTxt.ForeColor = System.Drawing.SystemColors.Window;
            this.csvFileTxt.Location = new System.Drawing.Point(27, 92);
            this.csvFileTxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.csvFileTxt.Name = "csvFileTxt";
            this.csvFileTxt.Size = new System.Drawing.Size(369, 20);
            this.csvFileTxt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "PRN Parser";
            // 
            // OKBttn
            // 
            this.OKBttn.Location = new System.Drawing.Point(417, 188);
            this.OKBttn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OKBttn.Name = "OKBttn";
            this.OKBttn.Size = new System.Drawing.Size(56, 19);
            this.OKBttn.TabIndex = 3;
            this.OKBttn.Text = "OK";
            this.OKBttn.UseVisualStyleBackColor = true;
            this.OKBttn.Click += new System.EventHandler(this.OKBttn_Click);
            // 
            // cancelBttn
            // 
            this.cancelBttn.Location = new System.Drawing.Point(339, 188);
            this.cancelBttn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cancelBttn.Name = "cancelBttn";
            this.cancelBttn.Size = new System.Drawing.Size(56, 19);
            this.cancelBttn.TabIndex = 4;
            this.cancelBttn.Text = "Cancel";
            this.cancelBttn.UseVisualStyleBackColor = true;
            this.cancelBttn.Click += new System.EventHandler(this.CancelBttn_Click);
            // 
            // outputFileTxt
            // 
            this.outputFileTxt.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.outputFileTxt.ForeColor = System.Drawing.SystemColors.Window;
            this.outputFileTxt.Location = new System.Drawing.Point(27, 142);
            this.outputFileTxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.outputFileTxt.Name = "outputFileTxt";
            this.outputFileTxt.Size = new System.Drawing.Size(369, 20);
            this.outputFileTxt.TabIndex = 5;
            // 
            // outputFileBttn
            // 
            this.outputFileBttn.Location = new System.Drawing.Point(417, 141);
            this.outputFileBttn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.outputFileBttn.Name = "outputFileBttn";
            this.outputFileBttn.Size = new System.Drawing.Size(56, 19);
            this.outputFileBttn.TabIndex = 6;
            this.outputFileBttn.Text = "Browse...";
            this.outputFileBttn.UseVisualStyleBackColor = true;
            this.outputFileBttn.Click += new System.EventHandler(this.OutputFileBttn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Input File";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 126);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Output File";
            // 
            // errLbl
            // 
            this.errLbl.AutoSize = true;
            this.errLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errLbl.ForeColor = System.Drawing.Color.Maroon;
            this.errLbl.Location = new System.Drawing.Point(187, 37);
            this.errLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.errLbl.Name = "errLbl";
            this.errLbl.Size = new System.Drawing.Size(0, 17);
            this.errLbl.TabIndex = 9;
            // 
            // entryLbl
            // 
            this.entryLbl.AutoSize = true;
            this.entryLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryLbl.Location = new System.Drawing.Point(27, 326);
            this.entryLbl.Name = "entryLbl";
            this.entryLbl.Size = new System.Drawing.Size(0, 25);
            this.entryLbl.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(520, 544);
            this.Controls.Add(this.entryLbl);
            this.Controls.Add(this.errLbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.outputFileBttn);
            this.Controls.Add(this.outputFileTxt);
            this.Controls.Add(this.cancelBttn);
            this.Controls.Add(this.OKBttn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.csvFileTxt);
            this.Controls.Add(this.inputFileBttn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "PRN Parser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog csvFile;
        private System.Windows.Forms.Button inputFileBttn;
        private System.Windows.Forms.TextBox csvFileTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OKBttn;
        private System.Windows.Forms.Button cancelBttn;
        private System.Windows.Forms.TextBox outputFileTxt;
        private System.Windows.Forms.Button outputFileBttn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SaveFileDialog outputFile;
        private System.Windows.Forms.Label errLbl;
        private System.Windows.Forms.Label entryLbl;
    }
}

