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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.конструкторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.интерфейсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запросыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewAttributes = new System.Windows.Forms.DataGridView();
            this.dataGridViewTables = new System.Windows.Forms.DataGridView();
            this.buttonAddTable = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ColumnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEditTable = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnDeleteTable = new System.Windows.Forms.DataGridViewButtonColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.buttonAddAttribute = new System.Windows.Forms.Button();
            this.buttonAddRelation = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttributes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTables)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.конструкторToolStripMenuItem,
            this.интерфейсToolStripMenuItem,
            this.запросыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(718, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // конструкторToolStripMenuItem
            // 
            this.конструкторToolStripMenuItem.Name = "конструкторToolStripMenuItem";
            this.конструкторToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.конструкторToolStripMenuItem.Text = "Конструктор";
            // 
            // интерфейсToolStripMenuItem
            // 
            this.интерфейсToolStripMenuItem.Name = "интерфейсToolStripMenuItem";
            this.интерфейсToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.интерфейсToolStripMenuItem.Text = "Интерфейс";
            // 
            // запросыToolStripMenuItem
            // 
            this.запросыToolStripMenuItem.Name = "запросыToolStripMenuItem";
            this.запросыToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.запросыToolStripMenuItem.Text = "Запросы";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(718, 440);
            this.splitContainer1.SplitterDistance = 308;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewAttributes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 440);
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
            this.dataGridViewAttributes.Size = new System.Drawing.Size(406, 440);
            this.dataGridViewAttributes.TabIndex = 0;
            this.dataGridViewAttributes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAttributes_CellContentClick);
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
            this.dataGridViewTables.Location = new System.Drawing.Point(3, 94);
            this.dataGridViewTables.Name = "dataGridViewTables";
            this.dataGridViewTables.RowHeadersVisible = false;
            this.dataGridViewTables.Size = new System.Drawing.Size(302, 343);
            this.dataGridViewTables.TabIndex = 2;
            // 
            // buttonAddTable
            // 
            this.buttonAddTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddTable.Location = new System.Drawing.Point(3, 47);
            this.buttonAddTable.Name = "buttonAddTable";
            this.buttonAddTable.Size = new System.Drawing.Size(302, 41);
            this.buttonAddTable.TabIndex = 1;
            this.buttonAddTable.Text = "Новая таблица";
            this.buttonAddTable.UseVisualStyleBackColor = true;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(308, 440);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // ColumnDelete
            // 
            this.ColumnDelete.HeaderText = "Удалить";
            this.ColumnDelete.Name = "ColumnDelete";
            this.ColumnDelete.ReadOnly = true;
            // 
            // ColumnEdit
            // 
            this.ColumnEdit.HeaderText = "Редактировать";
            this.ColumnEdit.Name = "ColumnEdit";
            this.ColumnEdit.ReadOnly = true;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Имя атрибута";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // ColumnId
            // 
            this.ColumnId.HeaderText = "ID";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
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
            this.splitContainer2.Size = new System.Drawing.Size(302, 38);
            this.splitContainer2.SplitterDistance = 100;
            this.splitContainer2.TabIndex = 3;
            // 
            // buttonAddAttribute
            // 
            this.buttonAddAttribute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddAttribute.Location = new System.Drawing.Point(0, 0);
            this.buttonAddAttribute.Name = "buttonAddAttribute";
            this.buttonAddAttribute.Size = new System.Drawing.Size(198, 38);
            this.buttonAddAttribute.TabIndex = 4;
            this.buttonAddAttribute.Text = "Новый атрибут";
            this.buttonAddAttribute.UseVisualStyleBackColor = true;
            // 
            // buttonAddRelation
            // 
            this.buttonAddRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddRelation.Location = new System.Drawing.Point(0, 0);
            this.buttonAddRelation.Name = "buttonAddRelation";
            this.buttonAddRelation.Size = new System.Drawing.Size(100, 38);
            this.buttonAddRelation.TabIndex = 4;
            this.buttonAddRelation.Text = "Добавить связь";
            this.buttonAddRelation.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 464);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttributes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTables)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem конструкторToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem интерфейсToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запросыToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonAddTable;
        private System.Windows.Forms.DataGridView dataGridViewTables;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewAttributes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTableName;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnEditTable;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnDeleteTable;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button buttonAddRelation;
        private System.Windows.Forms.Button buttonAddAttribute;
    }
}