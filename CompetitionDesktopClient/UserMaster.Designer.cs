namespace CompetitionDesktopClient
{
    partial class UserMaster
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
            panel1 = new Panel();
            bClear = new Button();
            bLookup = new Button();
            bArchive = new Button();
            bSave = new Button();
            bDelete = new Button();
            panel2 = new Panel();
            bLast = new Button();
            bNext = new Button();
            bPrevious = new Button();
            bFirst = new Button();
            bClose = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tbId = new TextBox();
            tbName = new TextBox();
            tbCode = new TextBox();
            tbTag = new TextBox();
            pbThumbnail = new PictureBox();
            la = new Label();
            pbImage = new PictureBox();
            bCodeLookup = new Button();
            button5 = new Button();
            bGetImage = new Button();
            ddlImageType = new ComboBox();
            bSaveImage = new Button();
            bDeleteImage = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbThumbnail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbImage).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(bClear);
            panel1.Controls.Add(bLookup);
            panel1.Controls.Add(bArchive);
            panel1.Controls.Add(bSave);
            panel1.Controls.Add(bDelete);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(778, 56);
            panel1.TabIndex = 0;
            // 
            // bClear
            // 
            bClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bClear.BackColor = Color.DarkGray;
            bClear.FlatStyle = FlatStyle.Flat;
            bClear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            bClear.ForeColor = Color.IndianRed;
            bClear.Location = new Point(434, 10);
            bClear.Name = "bClear";
            bClear.Size = new Size(100, 30);
            bClear.TabIndex = 6;
            bClear.Tag = "Clear";
            bClear.UseVisualStyleBackColor = false;
            bClear.EnabledChanged += ButtonEnabledChanged;
            bClear.Click += bClear_Click;
            bClear.Paint += ButtonPaints;
            // 
            // bLookup
            // 
            bLookup.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bLookup.BackColor = Color.LightSteelBlue;
            bLookup.FlatStyle = FlatStyle.Flat;
            bLookup.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            bLookup.ForeColor = Color.Black;
            bLookup.Location = new Point(328, 10);
            bLookup.Name = "bLookup";
            bLookup.Size = new Size(100, 30);
            bLookup.TabIndex = 5;
            bLookup.Tag = "Lookup";
            bLookup.UseVisualStyleBackColor = false;
            bLookup.EnabledChanged += ButtonEnabledChanged;
            bLookup.Click += bLookup_Click_1;
            bLookup.Paint += ButtonPaints;
            // 
            // bArchive
            // 
            bArchive.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bArchive.BackColor = Color.DarkGray;
            bArchive.Enabled = false;
            bArchive.FlatStyle = FlatStyle.Flat;
            bArchive.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            bArchive.ForeColor = Color.IndianRed;
            bArchive.Location = new Point(222, 10);
            bArchive.Name = "bArchive";
            bArchive.Size = new Size(100, 30);
            bArchive.TabIndex = 4;
            bArchive.Tag = "Archive";
            bArchive.UseVisualStyleBackColor = false;
            bArchive.EnabledChanged += ButtonEnabledChanged;
            bArchive.Paint += ButtonPaints;
            // 
            // bSave
            // 
            bSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bSave.BackColor = Color.DarkGray;
            bSave.FlatStyle = FlatStyle.Flat;
            bSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            bSave.ForeColor = Color.IndianRed;
            bSave.Location = new Point(116, 10);
            bSave.Name = "bSave";
            bSave.Size = new Size(100, 30);
            bSave.TabIndex = 3;
            bSave.Tag = "Save";
            bSave.UseVisualStyleBackColor = false;
            bSave.EnabledChanged += ButtonEnabledChanged;
            bSave.Click += bSave_Click;
            bSave.Paint += ButtonPaints;
            // 
            // bDelete
            // 
            bDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bDelete.BackColor = Color.DarkGray;
            bDelete.Enabled = false;
            bDelete.FlatStyle = FlatStyle.Flat;
            bDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            bDelete.ForeColor = Color.IndianRed;
            bDelete.Location = new Point(10, 10);
            bDelete.Name = "bDelete";
            bDelete.Size = new Size(100, 30);
            bDelete.TabIndex = 2;
            bDelete.Tag = "Delete";
            bDelete.UseVisualStyleBackColor = false;
            bDelete.EnabledChanged += ButtonEnabledChanged;
            bDelete.Paint += ButtonPaints;
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(bLast);
            panel2.Controls.Add(bNext);
            panel2.Controls.Add(bPrevious);
            panel2.Controls.Add(bFirst);
            panel2.Controls.Add(bClose);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 568);
            panel2.Name = "panel2";
            panel2.Size = new Size(778, 69);
            panel2.TabIndex = 1;
            // 
            // bLast
            // 
            bLast.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bLast.BackColor = Color.LightSteelBlue;
            bLast.FlatStyle = FlatStyle.Flat;
            bLast.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            bLast.ForeColor = Color.Black;
            bLast.Location = new Point(171, 9);
            bLast.Name = "bLast";
            bLast.Size = new Size(50, 50);
            bLast.TabIndex = 4;
            bLast.Tag = "last";
            bLast.Text = ">>";
            bLast.UseVisualStyleBackColor = false;
            bLast.Click += moveCurrentUser;
            // 
            // bNext
            // 
            bNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bNext.BackColor = Color.LightSteelBlue;
            bNext.FlatStyle = FlatStyle.Flat;
            bNext.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            bNext.ForeColor = Color.Black;
            bNext.Location = new Point(115, 9);
            bNext.Name = "bNext";
            bNext.Size = new Size(50, 50);
            bNext.TabIndex = 3;
            bNext.Tag = "next";
            bNext.Text = ">";
            bNext.UseVisualStyleBackColor = false;
            bNext.Click += moveCurrentUser;
            // 
            // bPrevious
            // 
            bPrevious.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bPrevious.BackColor = Color.LightSteelBlue;
            bPrevious.FlatStyle = FlatStyle.Flat;
            bPrevious.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            bPrevious.ForeColor = Color.Black;
            bPrevious.Location = new Point(59, 9);
            bPrevious.Name = "bPrevious";
            bPrevious.Size = new Size(50, 50);
            bPrevious.TabIndex = 2;
            bPrevious.Tag = "previous";
            bPrevious.Text = "<";
            bPrevious.UseVisualStyleBackColor = false;
            bPrevious.Click += moveCurrentUser;
            // 
            // bFirst
            // 
            bFirst.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bFirst.BackColor = Color.LightSteelBlue;
            bFirst.FlatStyle = FlatStyle.Flat;
            bFirst.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            bFirst.ForeColor = Color.Black;
            bFirst.Location = new Point(3, 9);
            bFirst.Name = "bFirst";
            bFirst.Size = new Size(50, 50);
            bFirst.TabIndex = 1;
            bFirst.Tag = "first";
            bFirst.Text = "<<";
            bFirst.UseVisualStyleBackColor = false;
            bFirst.Click += moveCurrentUser;
            // 
            // bClose
            // 
            bClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bClose.Location = new Point(690, 24);
            bClose.Name = "bClose";
            bClose.Size = new Size(75, 23);
            bClose.TabIndex = 0;
            bClose.Text = "Close";
            bClose.UseVisualStyleBackColor = true;
            bClose.Click += bClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 66);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 5;
            label1.Text = "Guid:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 124);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 6;
            label2.Text = "Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 95);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 7;
            label3.Text = "Code:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 153);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 8;
            label4.Text = "Tag:";
            // 
            // tbId
            // 
            tbId.Enabled = false;
            tbId.Location = new Point(116, 63);
            tbId.Name = "tbId";
            tbId.ReadOnly = true;
            tbId.Size = new Size(248, 23);
            tbId.TabIndex = 9;
            // 
            // tbName
            // 
            tbName.Location = new Point(117, 121);
            tbName.Name = "tbName";
            tbName.Size = new Size(463, 23);
            tbName.TabIndex = 10;
            tbName.TextChanged += ValidateButtonsStatus;
            // 
            // tbCode
            // 
            tbCode.Location = new Point(116, 92);
            tbCode.MaxLength = 10;
            tbCode.Name = "tbCode";
            tbCode.Size = new Size(156, 23);
            tbCode.TabIndex = 11;
            tbCode.Text = "TST0000001";
            // 
            // tbTag
            // 
            tbTag.Location = new Point(117, 150);
            tbTag.Name = "tbTag";
            tbTag.Size = new Size(371, 23);
            tbTag.TabIndex = 12;
            tbTag.TextChanged += ValidateButtonsStatus;
            // 
            // pbThumbnail
            // 
            pbThumbnail.BackColor = Color.WhiteSmoke;
            pbThumbnail.BorderStyle = BorderStyle.Fixed3D;
            pbThumbnail.Location = new Point(637, 62);
            pbThumbnail.Name = "pbThumbnail";
            pbThumbnail.Size = new Size(112, 106);
            pbThumbnail.SizeMode = PictureBoxSizeMode.CenterImage;
            pbThumbnail.TabIndex = 13;
            pbThumbnail.TabStop = false;
            // 
            // la
            // 
            la.AutoSize = true;
            la.Location = new Point(11, 179);
            la.Name = "la";
            la.Size = new Size(45, 15);
            la.TabIndex = 15;
            la.Text = "Images";
            // 
            // pbImage
            // 
            pbImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbImage.BackColor = Color.WhiteSmoke;
            pbImage.BorderStyle = BorderStyle.Fixed3D;
            pbImage.Location = new Point(12, 208);
            pbImage.Name = "pbImage";
            pbImage.Size = new Size(402, 354);
            pbImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbImage.TabIndex = 16;
            pbImage.TabStop = false;
            // 
            // bCodeLookup
            // 
            bCodeLookup.BackColor = Color.LightSteelBlue;
            bCodeLookup.FlatStyle = FlatStyle.Flat;
            bCodeLookup.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            bCodeLookup.Location = new Point(278, 92);
            bCodeLookup.Name = "bCodeLookup";
            bCodeLookup.Size = new Size(86, 23);
            bCodeLookup.TabIndex = 17;
            bCodeLookup.Tag = "code";
            bCodeLookup.Text = "Load From";
            bCodeLookup.UseVisualStyleBackColor = false;
            bCodeLookup.Click += bLookup_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.LightSteelBlue;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button5.Location = new Point(494, 150);
            button5.Name = "button5";
            button5.Size = new Size(86, 23);
            button5.TabIndex = 19;
            button5.Tag = "tag";
            button5.Text = "Load From";
            button5.UseVisualStyleBackColor = false;
            button5.Click += bLookup_Click;
            // 
            // bGetImage
            // 
            bGetImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bGetImage.BackColor = Color.LightSteelBlue;
            bGetImage.FlatStyle = FlatStyle.Flat;
            bGetImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            bGetImage.Location = new Point(420, 208);
            bGetImage.Name = "bGetImage";
            bGetImage.Size = new Size(136, 23);
            bGetImage.TabIndex = 20;
            bGetImage.Text = "Get File Image";
            bGetImage.UseVisualStyleBackColor = false;
            bGetImage.Click += bGetImage_Click;
            // 
            // ddlImageType
            // 
            ddlImageType.DisplayMember = "1";
            ddlImageType.DropDownStyle = ComboBoxStyle.DropDownList;
            ddlImageType.FormattingEnabled = true;
            ddlImageType.Items.AddRange(new object[] { "None", "Main", "Vertical", "Horizontal" });
            ddlImageType.Location = new Point(118, 179);
            ddlImageType.Name = "ddlImageType";
            ddlImageType.Size = new Size(370, 23);
            ddlImageType.TabIndex = 21;
            ddlImageType.ValueMember = "1";
            ddlImageType.TextChanged += ValidateButtonsStatus;
            // 
            // bSaveImage
            // 
            bSaveImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bSaveImage.BackColor = Color.LightSteelBlue;
            bSaveImage.FlatStyle = FlatStyle.Flat;
            bSaveImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            bSaveImage.ForeColor = Color.Black;
            bSaveImage.Location = new Point(420, 237);
            bSaveImage.Name = "bSaveImage";
            bSaveImage.Size = new Size(136, 23);
            bSaveImage.TabIndex = 23;
            bSaveImage.Text = "Save Image";
            bSaveImage.UseVisualStyleBackColor = false;
            bSaveImage.Click += bSaveImage_Click;
            // 
            // bDeleteImage
            // 
            bDeleteImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bDeleteImage.BackColor = Color.LightSteelBlue;
            bDeleteImage.FlatStyle = FlatStyle.Flat;
            bDeleteImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            bDeleteImage.ForeColor = Color.Black;
            bDeleteImage.Location = new Point(420, 266);
            bDeleteImage.Name = "bDeleteImage";
            bDeleteImage.Size = new Size(136, 23);
            bDeleteImage.TabIndex = 24;
            bDeleteImage.Text = "Delete Image";
            bDeleteImage.UseVisualStyleBackColor = false;
            bDeleteImage.Click += bDeleteImage_Click;
            // 
            // UserMaster
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 637);
            Controls.Add(bDeleteImage);
            Controls.Add(bSaveImage);
            Controls.Add(ddlImageType);
            Controls.Add(bGetImage);
            Controls.Add(button5);
            Controls.Add(bCodeLookup);
            Controls.Add(pbImage);
            Controls.Add(la);
            Controls.Add(pbThumbnail);
            Controls.Add(tbTag);
            Controls.Add(tbCode);
            Controls.Add(tbName);
            Controls.Add(tbId);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UserMaster";
            Text = "User Manipulation";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbThumbnail).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button bFirst;
        private Button bClose;
        private Button bPrevious;
        private Button bArchive;
        private Button bSave;
        private Button bDelete;
        private Button bLast;
        private Button bNext;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox tbId;
        private TextBox tbName;
        private TextBox tbCode;
        private TextBox tbTag;
        private PictureBox pbThumbnail;
        private Label la;
        private PictureBox pbImage;
        private Button bLookup;
        private Button bCodeLookup;
        private Button button5;
        private Button bGetImage;
        private ComboBox ddlImageType;
        private Button bSaveImage;
        private Button bDeleteImage;
        private Button bClear;
    }
}