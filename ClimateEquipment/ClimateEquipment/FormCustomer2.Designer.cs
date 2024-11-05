namespace ClimateEquipment
{
    partial class FormCustomer2
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
            this.labelBack = new System.Windows.Forms.Label();
            this.labelEdit = new System.Windows.Forms.Label();
            this.labelView = new System.Windows.Forms.Label();
            this.labelCreate = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.климатическое_оборудованиеDataSet = new ClimateEquipment.климатическое_оборудованиеDataSet();
            this.requestsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.requestsTableAdapter = new ClimateEquipment.климатическое_оборудованиеDataSetTableAdapters.RequestsTableAdapter();
            this.labelLines = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.климатическое_оборудованиеDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelBack
            // 
            this.labelBack.AutoSize = true;
            this.labelBack.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelBack.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBack.Location = new System.Drawing.Point(508, 9);
            this.labelBack.Name = "labelBack";
            this.labelBack.Size = new System.Drawing.Size(65, 26);
            this.labelBack.TabIndex = 29;
            this.labelBack.Text = "Назад";
            this.labelBack.Click += new System.EventHandler(this.labelBack_Click);
            // 
            // labelEdit
            // 
            this.labelEdit.AutoSize = true;
            this.labelEdit.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelEdit.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEdit.Location = new System.Drawing.Point(359, 9);
            this.labelEdit.Name = "labelEdit";
            this.labelEdit.Size = new System.Drawing.Size(143, 26);
            this.labelEdit.TabIndex = 28;
            this.labelEdit.Text = "Редактировать";
            this.labelEdit.Click += new System.EventHandler(this.labelEdit_Click);
            // 
            // labelView
            // 
            this.labelView.AutoSize = true;
            this.labelView.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelView.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelView.Location = new System.Drawing.Point(162, 9);
            this.labelView.Name = "labelView";
            this.labelView.Size = new System.Drawing.Size(191, 26);
            this.labelView.TabIndex = 27;
            this.labelView.Text = "Просмотреть заявки";
            // 
            // labelCreate
            // 
            this.labelCreate.AutoSize = true;
            this.labelCreate.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelCreate.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCreate.Location = new System.Drawing.Point(13, 9);
            this.labelCreate.Name = "labelCreate";
            this.labelCreate.Size = new System.Drawing.Size(143, 26);
            this.labelCreate.TabIndex = 26;
            this.labelCreate.Text = "Создать заявку";
            this.labelCreate.Click += new System.EventHandler(this.labelCreate_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(54, 412);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(57, 26);
            this.labelName.TabIndex = 30;
            this.labelName.Text = "ФИО";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ClimateEquipment.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(12, 404);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox2.Image = global::ClimateEquipment.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(756, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox3.Location = new System.Drawing.Point(1, 7);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(802, 31);
            this.pictureBox3.TabIndex = 25;
            this.pictureBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(13, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 28);
            this.label5.TabIndex = 32;
            this.label5.Text = "Заявки";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(770, 281);
            this.dataGridView1.TabIndex = 33;
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
            // labelLines
            // 
            this.labelLines.AutoSize = true;
            this.labelLines.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLines.Location = new System.Drawing.Point(623, 412);
            this.labelLines.Name = "labelLines";
            this.labelLines.Size = new System.Drawing.Size(165, 26);
            this.labelLines.TabIndex = 34;
            this.labelLines.Text = "100 из 100 заявок";
            // 
            // FormCustomer2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelLines);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelBack);
            this.Controls.Add(this.labelEdit);
            this.Controls.Add(this.labelView);
            this.Controls.Add(this.labelCreate);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormCustomer2";
            this.Text = "Заказчик";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCustomer2_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.климатическое_оборудованиеDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label labelBack;
        internal System.Windows.Forms.Label labelEdit;
        internal System.Windows.Forms.Label labelView;
        internal System.Windows.Forms.Label labelCreate;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label labelName;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private климатическое_оборудованиеDataSet климатическое_оборудованиеDataSet;
        private System.Windows.Forms.BindingSource requestsBindingSource;
        private климатическое_оборудованиеDataSetTableAdapters.RequestsTableAdapter requestsTableAdapter;
        internal System.Windows.Forms.Label labelLines;
    }
}