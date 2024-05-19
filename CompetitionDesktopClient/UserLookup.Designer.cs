namespace CompetitionDesktopClient
{
    partial class UserLookup
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
            dgvUsers = new DataGridView();
            name = new DataGridViewTextBoxColumn();
            Code = new DataGridViewTextBoxColumn();
            Tag = new DataGridViewTextBoxColumn();
            bClose = new Button();
            bOk = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // dgvUsers
            // 
            dgvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvUsers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { name, Code, Tag });
            dgvUsers.Location = new Point(12, 12);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(776, 387);
            dgvUsers.TabIndex = 0;
            dgvUsers.SelectionChanged += dgvUsers_SelectionChanged;
            // 
            // name
            // 
            name.DataPropertyName = "name";
            name.HeaderText = "Name";
            name.Name = "name";
            name.ReadOnly = true;
            name.Width = 64;
            // 
            // Code
            // 
            Code.DataPropertyName = "Code";
            Code.HeaderText = "Code";
            Code.Name = "Code";
            Code.ReadOnly = true;
            Code.Width = 60;
            // 
            // Tag
            // 
            Tag.DataPropertyName = "Tag";
            Tag.HeaderText = "Tag";
            Tag.Name = "Tag";
            Tag.ReadOnly = true;
            Tag.Width = 50;
            // 
            // bClose
            // 
            bClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bClose.DialogResult = DialogResult.Cancel;
            bClose.Location = new Point(713, 415);
            bClose.Name = "bClose";
            bClose.Size = new Size(75, 23);
            bClose.TabIndex = 1;
            bClose.Text = "Close";
            bClose.UseVisualStyleBackColor = true;
            bClose.Click += bClose_Click;
            // 
            // bOk
            // 
            bOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bOk.DialogResult = DialogResult.OK;
            bOk.Location = new Point(632, 415);
            bOk.Name = "bOk";
            bOk.Size = new Size(75, 23);
            bOk.TabIndex = 2;
            bOk.Text = "Ok";
            bOk.UseVisualStyleBackColor = true;
            // 
            // UserLookup
            // 
            AcceptButton = bOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = bClose;
            ClientSize = new Size(800, 450);
            Controls.Add(bOk);
            Controls.Add(bClose);
            Controls.Add(dgvUsers);
            Name = "UserLookup";
            Text = "UserLookup";
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvUsers;
        private Button bClose;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn Code;
        private DataGridViewTextBoxColumn Tag;
        private Button bOk;
    }
}