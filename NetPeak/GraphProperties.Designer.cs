namespace nsNetPeak
{
    partial class GraphProperties
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
            this.graphList = new System.Windows.Forms.ListView();
            this.col1 = new System.Windows.Forms.ColumnHeader();
            this.col_title = new System.Windows.Forms.ColumnHeader();
            this.col3 = new System.Windows.Forms.ColumnHeader();
            this.col4 = new System.Windows.Forms.ColumnHeader();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.title = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Button();
            this.splitDialog = new System.Windows.Forms.SplitContainer();
            this.splitDialog.Panel1.SuspendLayout();
            this.splitDialog.Panel2.SuspendLayout();
            this.splitDialog.SuspendLayout();
            this.SuspendLayout();
            // 
            // graphList
            // 
            this.graphList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col1,
            this.col_title,
            this.col3,
            this.col4});
            this.graphList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphList.FullRowSelect = true;
            this.graphList.GridLines = true;
            this.graphList.Location = new System.Drawing.Point(0, 0);
            this.graphList.Name = "graphList";
            this.graphList.Size = new System.Drawing.Size(667, 158);
            this.graphList.TabIndex = 0;
            this.graphList.UseCompatibleStateImageBehavior = false;
            this.graphList.View = System.Windows.Forms.View.Details;
            this.graphList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.graphList_ItemSelectionChanged);
            // 
            // col1
            // 
            this.col1.Text = "#";
            // 
            // col_title
            // 
            this.col_title.Text = "Title";
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(667, 380);
            this.propertyGrid.TabIndex = 1;
            this.propertyGrid.SelectedGridItemChanged += new System.Windows.Forms.SelectedGridItemChangedEventHandler(this.propertyGrid_SelectedGridItemChanged);
            // 
            // title
            // 
            this.title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(12, 16);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(667, 20);
            this.title.TabIndex = 2;
            this.title.Text = "Graph Properties";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.Location = new System.Drawing.Point(604, 620);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // splitDialog
            // 
            this.splitDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitDialog.Location = new System.Drawing.Point(12, 53);
            this.splitDialog.Name = "splitDialog";
            this.splitDialog.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitDialog.Panel1
            // 
            this.splitDialog.Panel1.Controls.Add(this.graphList);
            // 
            // splitDialog.Panel2
            // 
            this.splitDialog.Panel2.Controls.Add(this.propertyGrid);
            this.splitDialog.Size = new System.Drawing.Size(667, 542);
            this.splitDialog.SplitterDistance = 158;
            this.splitDialog.TabIndex = 4;
            // 
            // GraphProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(692, 655);
            this.Controls.Add(this.splitDialog);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.title);
            this.Name = "GraphProperties";
            this.Text = "GraphProperties";
            this.splitDialog.Panel1.ResumeLayout(false);
            this.splitDialog.Panel2.ResumeLayout(false);
            this.splitDialog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView graphList;
        private System.Windows.Forms.ColumnHeader col1;
        private System.Windows.Forms.ColumnHeader col_title;
        private System.Windows.Forms.ColumnHeader col3;
        private System.Windows.Forms.ColumnHeader col4;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.SplitContainer splitDialog;
    }
}