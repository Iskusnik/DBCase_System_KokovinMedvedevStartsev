namespace DBCaseSystem_KokovinMedvedevStartsev.Forms
{
	partial class FormDBList
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddDB = new System.Windows.Forms.Button();
            this.dataGridViewDB = new System.Windows.Forms.DataGridView();
            this.ColumnDBName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEditDB = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnDeleteDB = new System.Windows.Forms.DataGridViewButtonColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDB)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonAddDB, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewDB, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.39286F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.60714F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(370, 448);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonAddDB
            // 
            this.buttonAddDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddDB.Location = new System.Drawing.Point(3, 3);
            this.buttonAddDB.Name = "buttonAddDB";
            this.buttonAddDB.Size = new System.Drawing.Size(364, 54);
            this.buttonAddDB.TabIndex = 0;
            this.buttonAddDB.Text = "Добавить базу данных";
            this.buttonAddDB.UseVisualStyleBackColor = true;
            this.buttonAddDB.Click += new System.EventHandler(this.buttonAddDB_Click);
            // 
            // dataGridViewDB
            // 
            this.dataGridViewDB.AllowUserToAddRows = false;
            this.dataGridViewDB.AllowUserToDeleteRows = false;
            this.dataGridViewDB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDBName,
            this.ColumnEditDB,
            this.ColumnDeleteDB,
            this.id});
            this.dataGridViewDB.Location = new System.Drawing.Point(3, 63);
            this.dataGridViewDB.Name = "dataGridViewDB";
            this.dataGridViewDB.RowHeadersVisible = false;
            this.dataGridViewDB.Size = new System.Drawing.Size(364, 382);
            this.dataGridViewDB.TabIndex = 1;
            // 
            // ColumnDBName
            // 
            this.ColumnDBName.HeaderText = "Имя БД";
            this.ColumnDBName.Name = "ColumnDBName";
            this.ColumnDBName.ReadOnly = true;
            // 
            // ColumnEditDB
            // 
            this.ColumnEditDB.HeaderText = "Редактировать";
            this.ColumnEditDB.Name = "ColumnEditDB";
            this.ColumnEditDB.Text = "Редактировать";
            // 
            // ColumnDeleteDB
            // 
            this.ColumnDeleteDB.HeaderText = "Удалить";
            this.ColumnDeleteDB.Name = "ColumnDeleteDB";
            this.ColumnDeleteDB.Text = "Удалить";
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // FormDBList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormDBList";
            this.Text = "FormDBList";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDB)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button buttonAddDB;
		private System.Windows.Forms.DataGridView dataGridViewDB;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDBName;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnEditDB;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnDeleteDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
    }
}