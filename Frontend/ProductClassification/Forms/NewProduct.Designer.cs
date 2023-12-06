namespace ProjeStaj
{
    partial class NewProduct
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
            this.labelType = new System.Windows.Forms.Label();
            this.labelMinValue = new System.Windows.Forms.Label();
            this.labelCoefficient = new System.Windows.Forms.Label();
            this.labelMaxValue = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxMinValue = new System.Windows.Forms.TextBox();
            this.textBoxMaxValue = new System.Windows.Forms.TextBox();
            this.textBoxCoefficient = new System.Windows.Forms.TextBox();
            this.radioButtonFile = new System.Windows.Forms.RadioButton();
            this.radioButtonParcel = new System.Windows.Forms.RadioButton();
            this.labelProgressType = new System.Windows.Forms.Label();
            this.comboBoxProgressType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(44, 132);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(51, 20);
            this.labelType.TabIndex = 0;
            this.labelType.Text = "Type: ";
            // 
            // labelMinValue
            // 
            this.labelMinValue.AutoSize = true;
            this.labelMinValue.Location = new System.Drawing.Point(44, 196);
            this.labelMinValue.Name = "labelMinValue";
            this.labelMinValue.Size = new System.Drawing.Size(87, 20);
            this.labelMinValue.TabIndex = 1;
            this.labelMinValue.Text = "Min Value: ";
            // 
            // labelCoefficient
            // 
            this.labelCoefficient.AutoSize = true;
            this.labelCoefficient.Location = new System.Drawing.Point(44, 312);
            this.labelCoefficient.Name = "labelCoefficient";
            this.labelCoefficient.Size = new System.Drawing.Size(93, 20);
            this.labelCoefficient.TabIndex = 3;
            this.labelCoefficient.Text = "Coefficient: ";
            // 
            // labelMaxValue
            // 
            this.labelMaxValue.AutoSize = true;
            this.labelMaxValue.Location = new System.Drawing.Point(44, 257);
            this.labelMaxValue.Name = "labelMaxValue";
            this.labelMaxValue.Size = new System.Drawing.Size(91, 20);
            this.labelMaxValue.TabIndex = 4;
            this.labelMaxValue.Text = "Max Value: ";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(249, 376);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(126, 36);
            this.buttonAdd.TabIndex = 5;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonEkle_Click);
            // 
            // textBoxMinValue
            // 
            this.textBoxMinValue.Location = new System.Drawing.Point(219, 193);
            this.textBoxMinValue.Name = "textBoxMinValue";
            this.textBoxMinValue.Size = new System.Drawing.Size(156, 26);
            this.textBoxMinValue.TabIndex = 6;
            // 
            // textBoxMaxValue
            // 
            this.textBoxMaxValue.Location = new System.Drawing.Point(219, 257);
            this.textBoxMaxValue.Name = "textBoxMaxValue";
            this.textBoxMaxValue.Size = new System.Drawing.Size(156, 26);
            this.textBoxMaxValue.TabIndex = 7;
            // 
            // textBoxCoefficient
            // 
            this.textBoxCoefficient.Location = new System.Drawing.Point(219, 312);
            this.textBoxCoefficient.Name = "textBoxCoefficient";
            this.textBoxCoefficient.Size = new System.Drawing.Size(156, 26);
            this.textBoxCoefficient.TabIndex = 8;
            // 
            // radioButtonFile
            // 
            this.radioButtonFile.AutoSize = true;
            this.radioButtonFile.Location = new System.Drawing.Point(219, 128);
            this.radioButtonFile.Name = "radioButtonFile";
            this.radioButtonFile.Size = new System.Drawing.Size(59, 24);
            this.radioButtonFile.TabIndex = 9;
            this.radioButtonFile.TabStop = true;
            this.radioButtonFile.Text = "File";
            this.radioButtonFile.UseVisualStyleBackColor = true;
            // 
            // radioButtonParcel
            // 
            this.radioButtonParcel.AutoSize = true;
            this.radioButtonParcel.Location = new System.Drawing.Point(316, 128);
            this.radioButtonParcel.Name = "radioButtonParcel";
            this.radioButtonParcel.Size = new System.Drawing.Size(78, 24);
            this.radioButtonParcel.TabIndex = 10;
            this.radioButtonParcel.TabStop = true;
            this.radioButtonParcel.Text = "Parcel";
            this.radioButtonParcel.UseVisualStyleBackColor = true;
            // 
            // labelProgressType
            // 
            this.labelProgressType.AutoSize = true;
            this.labelProgressType.Location = new System.Drawing.Point(44, 75);
            this.labelProgressType.Name = "labelProgressType";
            this.labelProgressType.Size = new System.Drawing.Size(118, 20);
            this.labelProgressType.TabIndex = 12;
            this.labelProgressType.Text = "Progress Type: ";
            // 
            // comboBoxProgressType
            // 
            this.comboBoxProgressType.FormattingEnabled = true;
            this.comboBoxProgressType.Location = new System.Drawing.Point(219, 67);
            this.comboBoxProgressType.Name = "comboBoxProgressType";
            this.comboBoxProgressType.Size = new System.Drawing.Size(156, 28);
            this.comboBoxProgressType.TabIndex = 13;
            this.comboBoxProgressType.SelectedIndexChanged += new System.EventHandler(this.comboBoxHakedisTipi_SelectedIndexChanged);
            // 
            // NewProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 472);
            this.Controls.Add(this.comboBoxProgressType);
            this.Controls.Add(this.labelProgressType);
            this.Controls.Add(this.radioButtonParcel);
            this.Controls.Add(this.radioButtonFile);
            this.Controls.Add(this.textBoxCoefficient);
            this.Controls.Add(this.textBoxMaxValue);
            this.Controls.Add(this.textBoxMinValue);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelMaxValue);
            this.Controls.Add(this.labelCoefficient);
            this.Controls.Add(this.labelMinValue);
            this.Controls.Add(this.labelType);
            this.Name = "NewProduct";
            this.Text = "New Product";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelMinValue;
        private System.Windows.Forms.Label labelCoefficient;
        private System.Windows.Forms.Label labelMaxValue;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxMinValue;
        private System.Windows.Forms.TextBox textBoxMaxValue;
        private System.Windows.Forms.TextBox textBoxCoefficient;
        private System.Windows.Forms.RadioButton radioButtonFile;
        private System.Windows.Forms.RadioButton radioButtonParcel;
        private System.Windows.Forms.Label labelProgressType;
        private System.Windows.Forms.ComboBox comboBoxProgressType;
    }
}