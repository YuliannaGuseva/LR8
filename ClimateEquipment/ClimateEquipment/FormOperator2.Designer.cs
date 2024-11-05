namespace ClimateEquipment
{
    partial class FormOperator2
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelBack = new System.Windows.Forms.Label();
            this.labelViewLogin = new System.Windows.Forms.Label();
            this.labelView = new System.Windows.Forms.Label();
            this.labelCreate = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.климатическое_оборудованиеDataSet = new ClimateEquipment.климатическое_оборудованиеDataSet();
            this.requestsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.requestsTableAdapter = new ClimateEquipment.климатическое_оборудованиеDataSetTableAdapters.RequestsTableAdapter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelLines = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.климатическое_оборудованиеDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(52, 415);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 26);
            this.label1.TabIndex = 60;
            this.label1.Text = "ФИО";
            // 
            // labelBack
            // 
            this.labelBack.AutoSize = true;
            this.labelBack.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelBack.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBack.Location = new System.Drawing.Point(648, 12);
            this.labelBack.Name = "labelBack";
            this.labelBack.Size = new System.Drawing.Size(65, 26);
            this.labelBack.TabIndex = 59;
            this.labelBack.Text = "Назад";
            this.labelBack.Click += new System.EventHandler(this.labelBack_Click);
            // 
            // labelViewLogin
            // 
            this.labelViewLogin.AutoSize = true;
            this.labelViewLogin.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelViewLogin.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelViewLogin.Location = new System.Drawing.Point(382, 12);
            this.labelViewLogin.Name = "labelViewLogin";
            this.labelViewLogin.Size = new System.Drawing.Size(263, 26);
            this.labelViewLogin.TabIndex = 58;
            this.labelViewLogin.Text = "Просмотреть историю входа";
            this.labelViewLogin.Click += new System.EventHandler(this.labelViewLogin_Click);
            // 
            // labelView
            // 
            this.labelView.AutoSize = true;
            this.labelView.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelView.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelView.Location = new System.Drawing.Point(186, 12);
            this.labelView.Name = "labelView";
            this.labelView.Size = new System.Drawing.Size(191, 26);
            this.labelView.TabIndex = 57;
            this.labelView.Text = "Просмотреть заявки";
            // 
            // labelCreate
            // 
            this.labelCreate.AutoSize = true;
            this.labelCreate.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelCreate.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCreate.Location = new System.Drawing.Point(11, 12);
            this.labelCreate.Name = "labelCreate";
            this.labelCreate.Size = new System.Drawing.Size(171, 26);
            this.labelCreate.TabIndex = 56;
            this.labelCreate.Text = "Зарегистрировать";
            this.labelCreate.Click += new System.EventHandler(this.labelCreate_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(731, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(57, 26);
            this.labelName.TabIndex = 53;
            this.labelName.Text = "ФИО";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // климатическое_оборудованиеDataSet
            // 
            this.климатическое_оборудованиеDataSet.DataSetName = "климатическое_оборудованиеDataSet";
            this.климатическое_оборудованиеDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // requestsBindingSource
            // 
            this.requestsBindingSource.DataMember = "Requests";
            this.requestsBindingSource.DataSource = this.климатическое_оборудованиеDataSet;
            // 
            // requestsTableAdapter
            // 
            this.requestsTableAdapter.ClearBeforeFill = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ClimateEquipment.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(10, 407);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 61;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox2.Image = global::ClimateEquipment.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(754, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 54;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox3.Location = new System.Drawing.Point(-1, 10);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(802, 31);
            this.pictureBox3.TabIndex = 55;
            this.pictureBox3.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 106);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(770, 281);
            this.dataGridView1.TabIndex = 63;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(13, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 28);
            this.label5.TabIndex = 62;
            this.label5.Text = "Заявки";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(483, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 26);
            this.label6.TabIndex = 64;
            this.label6.Text = "Статус:";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.Font = new System.Drawing.Font("Palatino Linotype", 14.25F);
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(563, 59);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(223, 34);
            this.comboBoxStatus.TabIndex = 65;
            this.comboBoxStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxStatus_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(353, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 26);
            this.label2.TabIndex = 66;
            this.label2.Text = "Показать все";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // labelLines
            // 
            this.labelLines.AutoSize = true;
            this.labelLines.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLines.Location = new System.Drawing.Point(623, 412);
            this.labelLines.Name = "labelLines";
            this.labelLines.Size = new System.Drawing.Size(165, 26);
            this.labelLines.TabIndex = 67;
            this.labelLines.Text = "100 из 100 заявок";
            // 
            // FormOperator2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelLines);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelBack);
            this.Controls.Add(this.labelViewLogin);
            this.Controls.Add(this.labelView);
            this.Controls.Add(this.labelCreate);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.labelName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormOperator2";
            this.Text = "Оператор";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormOperator2_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.климатическое_оборудованиеDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label labelBack;
        internal System.Windows.Forms.Label labelViewLogin;
        internal System.Windows.Forms.Label labelView;
        internal System.Windows.Forms.Label labelCreate;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        internal System.Windows.Forms.Label labelName;
        private климатическое_оборудованиеDataSet климатическое_оборудованиеDataSet;
        private System.Windows.Forms.BindingSource requestsBindingSource;
        private климатическое_оборудованиеDataSetTableAdapters.RequestsTableAdapter requestsTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label labelLines;
    }
}