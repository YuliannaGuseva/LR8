﻿namespace ClimateEquipment
{
    partial class FormOperator1
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
            this.labelName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelBack = new System.Windows.Forms.Label();
            this.labelViewLogin = new System.Windows.Forms.Label();
            this.labelView = new System.Windows.Forms.Label();
            this.labelCreate = new System.Windows.Forms.Label();
            this.климатическое_оборудованиеDataSet = new ClimateEquipment.климатическое_оборудованиеDataSet();
            this.requestsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.requestsTableAdapter = new ClimateEquipment.климатическое_оборудованиеDataSetTableAdapters.RequestsTableAdapter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBoxPriority = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxSpec = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.климатическое_оборудованиеDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(731, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(57, 26);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "ФИО";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(52, 415);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 26);
            this.label1.TabIndex = 51;
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
            this.labelBack.TabIndex = 50;
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
            this.labelViewLogin.TabIndex = 49;
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
            this.labelView.TabIndex = 48;
            this.labelView.Text = "Просмотреть заявки";
            this.labelView.Click += new System.EventHandler(this.labelView_Click);
            // 
            // labelCreate
            // 
            this.labelCreate.AutoSize = true;
            this.labelCreate.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelCreate.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCreate.Location = new System.Drawing.Point(11, 12);
            this.labelCreate.Name = "labelCreate";
            this.labelCreate.Size = new System.Drawing.Size(171, 26);
            this.labelCreate.TabIndex = 47;
            this.labelCreate.Text = "Зарегистрировать";
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
            this.pictureBox1.TabIndex = 52;
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
            this.pictureBox2.TabIndex = 45;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox3.Location = new System.Drawing.Point(-1, 10);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(802, 31);
            this.pictureBox3.TabIndex = 46;
            this.pictureBox3.TabStop = false;
            // 
            // buttonSend
            // 
            this.buttonSend.BackColor = System.Drawing.Color.Gold;
            this.buttonSend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSend.Font = new System.Drawing.Font("Palatino Linotype", 14.25F);
            this.buttonSend.Location = new System.Drawing.Point(602, 390);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(185, 34);
            this.buttonSend.TabIndex = 85;
            this.buttonSend.Text = "Зарегистрировать";
            this.buttonSend.UseVisualStyleBackColor = false;
            this.buttonSend.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 164);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(770, 93);
            this.dataGridView1.TabIndex = 84;
            // 
            // comboBoxPriority
            // 
            this.comboBoxPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPriority.Font = new System.Drawing.Font("Palatino Linotype", 14.25F);
            this.comboBoxPriority.FormattingEnabled = true;
            this.comboBoxPriority.Items.AddRange(new object[] {
            "Важно",
            "Срочно",
            "Быстро",
            "Не важно",
            "Не срочно",
            "Не быстро"});
            this.comboBoxPriority.Location = new System.Drawing.Point(191, 285);
            this.comboBoxPriority.Name = "comboBoxPriority";
            this.comboBoxPriority.Size = new System.Drawing.Size(223, 34);
            this.comboBoxPriority.TabIndex = 82;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(30, 336);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 26);
            this.label8.TabIndex = 81;
            this.label8.Text = "Специалист";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(30, 293);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 26);
            this.label7.TabIndex = 80;
            this.label7.Text = "Приоритетность";
            // 
            // comboBoxID
            // 
            this.comboBoxID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxID.Font = new System.Drawing.Font("Palatino Linotype", 14.25F);
            this.comboBoxID.FormattingEnabled = true;
            this.comboBoxID.Location = new System.Drawing.Point(208, 114);
            this.comboBoxID.Name = "comboBoxID";
            this.comboBoxID.Size = new System.Drawing.Size(223, 34);
            this.comboBoxID.TabIndex = 76;
            this.comboBoxID.SelectedIndexChanged += new System.EventHandler(this.comboBoxID_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 26);
            this.label2.TabIndex = 75;
            this.label2.Text = "Выберите id заявки:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(260, 28);
            this.label5.TabIndex = 74;
            this.label5.Text = "Редактирование заявки";
            // 
            // comboBoxSpec
            // 
            this.comboBoxSpec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSpec.Font = new System.Drawing.Font("Palatino Linotype", 14.25F);
            this.comboBoxSpec.FormattingEnabled = true;
            this.comboBoxSpec.Location = new System.Drawing.Point(191, 333);
            this.comboBoxSpec.Name = "comboBoxSpec";
            this.comboBoxSpec.Size = new System.Drawing.Size(223, 34);
            this.comboBoxSpec.TabIndex = 86;
            // 
            // FormOperator1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBoxSpec);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBoxPriority);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxID);
            this.Controls.Add(this.label2);
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
            this.Name = "FormOperator1";
            this.Text = "Оператор";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormOperator1_FormClosed);
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

        internal System.Windows.Forms.Label labelName;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label labelBack;
        internal System.Windows.Forms.Label labelViewLogin;
        internal System.Windows.Forms.Label labelView;
        internal System.Windows.Forms.Label labelCreate;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private климатическое_оборудованиеDataSet климатическое_оборудованиеDataSet;
        private System.Windows.Forms.BindingSource requestsBindingSource;
        private климатическое_оборудованиеDataSetTableAdapters.RequestsTableAdapter requestsTableAdapter;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxPriority;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxID;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxSpec;
    }
}