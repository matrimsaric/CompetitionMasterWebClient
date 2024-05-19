namespace CompetitionDesktopClient
{
    partial class Index
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            bUserManagement = new Button();
            bClose = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // bUserManagement
            // 
            bUserManagement.Location = new Point(12, 12);
            bUserManagement.Name = "bUserManagement";
            bUserManagement.Size = new Size(586, 23);
            bUserManagement.TabIndex = 0;
            bUserManagement.Text = "User Management";
            bUserManagement.UseVisualStyleBackColor = true;
            bUserManagement.Click += bUserManagement_Click;
            // 
            // bClose
            // 
            bClose.Location = new Point(12, 404);
            bClose.Name = "bClose";
            bClose.Size = new Size(586, 23);
            bClose.TabIndex = 1;
            bClose.Text = "Close";
            bClose.UseVisualStyleBackColor = true;
            bClose.Click += bClose_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 375);
            button1.Name = "button1";
            button1.Size = new Size(586, 23);
            button1.TabIndex = 2;
            button1.Text = "Tester";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Index
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(610, 450);
            Controls.Add(button1);
            Controls.Add(bClose);
            Controls.Add(bUserManagement);
            Name = "Index";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button bUserManagement;
        private Button bClose;
        private Button button1;
    }
}
