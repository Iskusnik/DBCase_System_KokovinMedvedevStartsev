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
            this.buttonEditWhole = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDB)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonEditWhole, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonAddDB, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewDB, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.42336F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.57664F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(389, 326);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonAddDB
            // 
            this.buttonAddDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddDB.Location = new System.Drawing.Point(3, 3);
            this.buttonAddDB.Name = "buttonAddDB";
            this.buttonAddDB.Size = new System.Drawing.Size(383, 41);
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
            this.dataGridViewDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDB.Location = new System.Drawing.Point(3, 50);
            this.dataGridViewDB.MultiSelect = false;
            this.dataGridViewDB.Name = "dataGridViewDB";
            this.dataGridViewDB.RowHeadersVisible = false;
            this.dataGridViewDB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDB.Size = new System.Drawing.Size(383, 234);
            this.dataGridViewDB.TabIndex = 1;
            this.dataGridViewDB.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTables_CellContentClick);
            this.dataGridViewDB.SelectionChanged += new System.EventHandler(this.dataGridViewTables_SelectionChanged);
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
            // buttonEditWhole
            // 
            this.buttonEditWhole.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonEditWhole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditWhole.Location = new System.Drawing.Point(3, 290);
            this.buttonEditWhole.Name = "buttonEditWhole";
            this.buttonEditWhole.Size = new System.Drawing.Size(383, 33);
            this.buttonEditWhole.TabIndex = 2;
            this.buttonEditWhole.Text = "Настроить содержимое";
            this.buttonEditWhole.UseVisualStyleBackColor = true;
            this.buttonEditWhole.Click += new System.EventHandler(this.buttonEditWhole_Click);
            // 
            // FormDBList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 326);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormDBList";
            this.Text = "FormDBList";
            this.Load += new System.EventHandler(this.FormDBList_Load);
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
        private System.Windows.Forms.Button buttonEditWhole;
    }
}