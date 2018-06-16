namespace 停车收费管理系统
{
    partial class LookCollectFee
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDeleted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Plate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NeedPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManagerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CloseDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(58, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "查看指定车牌号车情况:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(298, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(243, 34);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(92)))), ((int)(((byte)(146)))));
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(595, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 43);
            this.button1.TabIndex = 2;
            this.button1.Text = "搜  索";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.CarTypeId,
            this.IsDeleted,
            this.Plate,
            this.NeedPosition,
            this.StartMoney,
            this.ManagerId,
            this.CreateDateTime,
            this.CloseDateTime,
            this.TotalMoney});
            this.dataGridView1.Location = new System.Drawing.Point(31, 92);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1472, 310);
            this.dataGridView1.TabIndex = 3;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "停车编号";
            this.Id.Name = "Id";
            // 
            // CarTypeId
            // 
            this.CarTypeId.DataPropertyName = "CarTypeId";
            this.CarTypeId.HeaderText = "汽车类型";
            this.CarTypeId.Name = "CarTypeId";
            // 
            // IsDeleted
            // 
            this.IsDeleted.DataPropertyName = "IsDeleted";
            this.IsDeleted.HeaderText = "是否已结算";
            this.IsDeleted.Name = "IsDeleted";
            this.IsDeleted.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsDeleted.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Plate
            // 
            this.Plate.DataPropertyName = "Plate";
            this.Plate.HeaderText = "车牌号";
            this.Plate.Name = "Plate";
            // 
            // NeedPosition
            // 
            this.NeedPosition.DataPropertyName = "NeedPosition";
            this.NeedPosition.HeaderText = "占车位数量";
            this.NeedPosition.Name = "NeedPosition";
            // 
            // StartMoney
            // 
            this.StartMoney.DataPropertyName = "Money";
            this.StartMoney.HeaderText = "起始价";
            this.StartMoney.Name = "StartMoney";
            // 
            // ManagerId
            // 
            this.ManagerId.DataPropertyName = "ManagerId";
            this.ManagerId.HeaderText = "管理员编号";
            this.ManagerId.Name = "ManagerId";
            // 
            // CreateDateTime
            // 
            this.CreateDateTime.DataPropertyName = "CreateDateTime";
            this.CreateDateTime.HeaderText = "开始停放时间";
            this.CreateDateTime.Name = "CreateDateTime";
            // 
            // CloseDateTime
            // 
            this.CloseDateTime.DataPropertyName = "CloseDateTime";
            this.CloseDateTime.HeaderText = "离开时间";
            this.CloseDateTime.Name = "CloseDateTime";
            // 
            // TotalMoney
            // 
            this.TotalMoney.DataPropertyName = "TotalMoney";
            this.TotalMoney.HeaderText = "总共收费";
            this.TotalMoney.Name = "TotalMoney";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(31, 419);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1472, 158);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "统计管理:";
            // 
            // LookCollectFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::停车收费管理系统.Properties.Resources._20;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1654, 599);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(1672, 646);
            this.Name = "LookCollectFee";
            this.Text = "收费情况查看";
            this.Load += new System.EventHandler(this.LookCollectFee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarTypeId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsDeleted;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NeedPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManagerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn CloseDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalMoney;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}