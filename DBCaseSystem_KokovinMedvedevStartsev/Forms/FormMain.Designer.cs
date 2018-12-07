namespace DBCaseSystem_KokovinMedvedevStartsev.Forms
{
    partial class FormMain
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddTable = new System.Windows.Forms.Button();
            this.dataGridViewTables = new System.Windows.Forms.DataGridView();
            this.ColumnTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEditTable = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnDeleteTable = new System.Windows.Forms.DataGridViewButtonColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.buttonAddRelation = new System.Windows.Forms.Button();
            this.buttonAddAttribute = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewAttributes = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttributes)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(718, 464);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(710, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Конструктор БД";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(704, 432);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonAddTable, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewTables, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.52941F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.47059F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 348F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 432);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonAddTable
            // 
            this.buttonAddTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddTable.Location = new System.Drawing.Point(3, 43);
            this.buttonAddTable.Name = "buttonAddTable";
            this.buttonAddTable.Size = new System.Drawing.Size(294, 37);
            this.buttonAddTable.TabIndex = 1;
            this.buttonAddTable.Text = "Новая таблица";
            this.buttonAddTable.UseVisualStyleBackColor = true;
            this.buttonAddTable.Click += new System.EventHandler(this.buttonAddTable_Click);
            // 
            // dataGridViewTables
            // 
            this.dataGridViewTables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTableName,
            this.ColumnEditTable,
            this.ColumnDeleteTable});
            this.dataGridViewTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTables.Location = new System.Drawing.Point(3, 86);
            this.dataGridViewTables.Name = "dataGridViewTables";
            this.dataGridViewTables.RowHeadersVisible = false;
            this.dataGridViewTables.Size = new System.Drawing.Size(294, 343);
            this.dataGridViewTables.TabIndex = 2;
            // 
            // ColumnTableName
            // 
            this.ColumnTableName.HeaderText = "Название таблицы";
            this.ColumnTableName.Name = "ColumnTableName";
            this.ColumnTableName.ReadOnly = true;
            // 
            // ColumnEditTable
            // 
            this.ColumnEditTable.HeaderText = "Редактировать";
            this.ColumnEditTable.Name = "ColumnEditTable";
            // 
            // ColumnDeleteTable
            // 
            this.ColumnDeleteTable.HeaderText = "Удалить";
            this.ColumnDeleteTable.Name = "ColumnDeleteTable";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.buttonAddRelation);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.buttonAddAttribute);
            this.splitContainer2.Size = new System.Drawing.Size(294, 34);
            this.splitContainer2.SplitterDistance = 96;
            this.splitContainer2.TabIndex = 3;
            // 
            // buttonAddRelation
            // 
            this.buttonAddRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddRelation.Location = new System.Drawing.Point(0, 0);
            this.buttonAddRelation.Name = "buttonAddRelation";
            this.buttonAddRelation.Size = new System.Drawing.Size(96, 34);
            this.buttonAddRelation.TabIndex = 4;
            this.buttonAddRelation.Text = "Редактор отношений";
            this.buttonAddRelation.UseVisualStyleBackColor = true;
            this.buttonAddRelation.Click += new System.EventHandler(this.buttonAddRelation_Click);
            // 
            // buttonAddAttribute
            // 
            this.buttonAddAttribute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddAttribute.Location = new System.Drawing.Point(0, 0);
            this.buttonAddAttribute.Name = "buttonAddAttribute";
            this.buttonAddAttribute.Size = new System.Drawing.Size(194, 34);
            this.buttonAddAttribute.TabIndex = 4;
            this.buttonAddAttribute.Text = "Новый атрибут";
            this.buttonAddAttribute.UseVisualStyleBackColor = true;
            this.buttonAddAttribute.Click += new System.EventHandler(this.buttonAddAttribute_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewAttributes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 432);
            this.panel1.TabIndex = 0;
            // 
            // dataGridViewAttributes
            // 
            this.dataGridViewAttributes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAttributes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnName,
            this.ColumnEdit,
            this.ColumnDelete});
            this.dataGridViewAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAttributes.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewAttributes.Name = "dataGridViewAttributes";
            this.dataGridViewAttributes.ReadOnly = true;
            this.dataGridViewAttributes.RowHeadersVisible = false;
            this.dataGridViewAttributes.Size = new System.Drawing.Size(400, 432);
            this.dataGridViewAttributes.TabIndex = 0;
            this.dataGridViewAttributes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAttributes_CellContentClick_1);
            // 
            // ColumnId
            // 
            this.ColumnId.HeaderText = "ID";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Имя атрибута";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // ColumnEdit
            // 
            this.ColumnEdit.HeaderText = "Редактировать";
            this.ColumnEdit.Name = "ColumnEdit";
            this.ColumnEdit.ReadOnly = true;
            // 
            // ColumnDelete
            // 
            this.ColumnDelete.HeaderText = "Удалить";
            this.ColumnDelete.Name = "ColumnDelete";
            this.ColumnDelete.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(710, 438);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Запросы";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(710, 438);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Интерфейс";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 464);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTables)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttributes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonAddTable;
        private System.Windows.Forms.DataGridView dataGridViewTables;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTableName;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnEditTable;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnDeleteTable;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button buttonAddRelation;
        private System.Windows.Forms.Button buttonAddAttribute;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewAttributes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnDelete;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
    }
}