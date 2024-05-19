namespace CompetitionDesktopClient
{
    partial class Player
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(31, 12);
            button1.Name = "button1";
            button1.Size = new Size(154, 23);
            button1.TabIndex = 0;
            button1.Text = "Test Decorator Pattern";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(31, 41);
            button2.Name = "button2";
            button2.Size = new Size(154, 23);
            button2.TabIndex = 1;
            button2.Text = "Test State Pattern";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(31, 70);
            button3.Name = "button3";
            button3.Size = new Size(154, 23);
            button3.TabIndex = 2;
            button3.Text = "Test Func";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(191, 70);
            button4.Name = "button4";
            button4.Size = new Size(154, 23);
            button4.TabIndex = 3;
            button4.Text = "Test Predicate";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(31, 99);
            button5.Name = "button5";
            button5.Size = new Size(154, 23);
            button5.TabIndex = 4;
            button5.Text = "Test Generics";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(323, 214);
            button6.Name = "button6";
            button6.Size = new Size(154, 23);
            button6.TabIndex = 5;
            button6.Text = "Test";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Player
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Player";
            Text = "Player";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
    }
}