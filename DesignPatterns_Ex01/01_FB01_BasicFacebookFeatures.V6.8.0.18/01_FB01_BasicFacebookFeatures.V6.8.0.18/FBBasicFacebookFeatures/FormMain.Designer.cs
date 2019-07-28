namespace BasicFacebookFeatures
{
    partial class Form1
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
            this.pictureBoxFriend = new System.Windows.Forms.PictureBox();
            this.picture_smallPictureBox = new System.Windows.Forms.PictureBox();
            this.listBoxFriends = new System.Windows.Forms.ListBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.buttonSetStatus = new System.Windows.Forms.Button();
            this.listBoxPosts = new System.Windows.Forms.ListBox();
            this.pictureBoxEvent = new System.Windows.Forms.PictureBox();
            this.linkFriends = new System.Windows.Forms.LinkLabel();
            this.labelEvents = new System.Windows.Forms.LinkLabel();
            this.linkPosts = new System.Windows.Forms.LinkLabel();
            this.linkCheckins = new System.Windows.Forms.LinkLabel();
            this.listBoxCheckins = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBoxPage = new System.Windows.Forms.PictureBox();
            this.listBoxPages = new System.Windows.Forms.ListBox();
            this.linkPages = new System.Windows.Forms.LinkLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBoxActionType = new System.Windows.Forms.ComboBox();
            this.dataGridViewActions = new System.Windows.Forms.DataGridView();
            this.linkUserActions = new System.Windows.Forms.LinkLabel();
            this.listBoxPostComments = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_smallPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEvent)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPage)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActions)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxFriend
            // 
            this.pictureBoxFriend.Location = new System.Drawing.Point(336, 465);
            this.pictureBoxFriend.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBoxFriend.Name = "pictureBoxFriend";
            this.pictureBoxFriend.Size = new System.Drawing.Size(106, 100);
            this.pictureBoxFriend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxFriend.TabIndex = 42;
            this.pictureBoxFriend.TabStop = false;
            // 
            // picture_smallPictureBox
            // 
            this.picture_smallPictureBox.Location = new System.Drawing.Point(16, 98);
            this.picture_smallPictureBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.picture_smallPictureBox.Name = "picture_smallPictureBox";
            this.picture_smallPictureBox.Size = new System.Drawing.Size(400, 300);
            this.picture_smallPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_smallPictureBox.TabIndex = 41;
            this.picture_smallPictureBox.TabStop = false;
            // 
            // listBoxFriends
            // 
            this.listBoxFriends.FormattingEnabled = true;
            this.listBoxFriends.ItemHeight = 25;
            this.listBoxFriends.Location = new System.Drawing.Point(16, 465);
            this.listBoxFriends.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.listBoxFriends.Name = "listBoxFriends";
            this.listBoxFriends.Size = new System.Drawing.Size(304, 279);
            this.listBoxFriends.TabIndex = 37;
            this.listBoxFriends.SelectedIndexChanged += new System.EventHandler(this.listBoxFriends_SelectedIndexChanged);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(16, 12);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(150, 44);
            this.buttonLogin.TabIndex = 36;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxEvents.DisplayMember = "name";
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.ItemHeight = 25;
            this.listBoxEvents.Location = new System.Drawing.Point(716, 465);
            this.listBoxEvents.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(928, 279);
            this.listBoxEvents.TabIndex = 40;
            this.listBoxEvents.SelectedIndexChanged += new System.EventHandler(this.listBoxEvents_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(426, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 25);
            this.label3.TabIndex = 44;
            this.label3.Text = "Post Status:";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatus.Location = new System.Drawing.Point(566, 15);
            this.textBoxStatus.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(538, 31);
            this.textBoxStatus.TabIndex = 45;
            // 
            // buttonSetStatus
            // 
            this.buttonSetStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetStatus.Location = new System.Drawing.Point(1120, 12);
            this.buttonSetStatus.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonSetStatus.Name = "buttonSetStatus";
            this.buttonSetStatus.Size = new System.Drawing.Size(150, 44);
            this.buttonSetStatus.TabIndex = 46;
            this.buttonSetStatus.Text = "Post";
            this.buttonSetStatus.UseVisualStyleBackColor = true;
            this.buttonSetStatus.Click += new System.EventHandler(this.buttonSetStatus_Click);
            // 
            // listBoxPosts
            // 
            this.listBoxPosts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPosts.DisplayMember = "name";
            this.listBoxPosts.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxPosts.FormattingEnabled = true;
            this.listBoxPosts.ItemHeight = 39;
            this.listBoxPosts.Location = new System.Drawing.Point(432, 98);
            this.listBoxPosts.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.listBoxPosts.Name = "listBoxPosts";
            this.listBoxPosts.Size = new System.Drawing.Size(1212, 277);
            this.listBoxPosts.TabIndex = 40;
            this.listBoxPosts.SelectedIndexChanged += new System.EventHandler(this.listBoxPosts_SelectedIndexChanged);
            // 
            // pictureBoxEvent
            // 
            this.pictureBoxEvent.Location = new System.Drawing.Point(1500, 410);
            this.pictureBoxEvent.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBoxEvent.Name = "pictureBoxEvent";
            this.pictureBoxEvent.Size = new System.Drawing.Size(148, 131);
            this.pictureBoxEvent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxEvent.TabIndex = 42;
            this.pictureBoxEvent.TabStop = false;
            // 
            // linkFriends
            // 
            this.linkFriends.AutoSize = true;
            this.linkFriends.LinkArea = new System.Windows.Forms.LinkArea(0, 13);
            this.linkFriends.Location = new System.Drawing.Point(12, 404);
            this.linkFriends.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.linkFriends.Name = "linkFriends";
            this.linkFriends.Size = new System.Drawing.Size(512, 54);
            this.linkFriends.TabIndex = 47;
            this.linkFriends.TabStop = true;
            this.linkFriends.Text = "Fetch Friends (Only friends who also use this app..)\r\n(Click on a friend to view " +
    "it\'s picture)";
            this.linkFriends.UseCompatibleTextRendering = true;
            this.linkFriends.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFriends_LinkClicked);
            // 
            // labelEvents
            // 
            this.labelEvents.AutoSize = true;
            this.labelEvents.LinkArea = new System.Windows.Forms.LinkArea(0, 13);
            this.labelEvents.Location = new System.Drawing.Point(716, 402);
            this.labelEvents.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelEvents.Name = "labelEvents";
            this.labelEvents.Size = new System.Drawing.Size(363, 54);
            this.labelEvents.TabIndex = 48;
            this.labelEvents.TabStop = true;
            this.labelEvents.Text = "Fetch Events \r\n(Click on an event to view it\'s picture)";
            this.labelEvents.UseCompatibleTextRendering = true;
            this.labelEvents.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelEvents_LinkClicked);
            // 
            // linkPosts
            // 
            this.linkPosts.AutoSize = true;
            this.linkPosts.Location = new System.Drawing.Point(426, 67);
            this.linkPosts.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.linkPosts.Name = "linkPosts";
            this.linkPosts.Size = new System.Drawing.Size(126, 25);
            this.linkPosts.TabIndex = 49;
            this.linkPosts.TabStop = true;
            this.linkPosts.Text = "Fetch Posts";
            this.linkPosts.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPosts_LinkClicked);
            // 
            // linkCheckins
            // 
            this.linkCheckins.AutoSize = true;
            this.linkCheckins.LinkArea = new System.Windows.Forms.LinkArea(0, 14);
            this.linkCheckins.Location = new System.Drawing.Point(16, 773);
            this.linkCheckins.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.linkCheckins.Name = "linkCheckins";
            this.linkCheckins.Size = new System.Drawing.Size(369, 54);
            this.linkCheckins.TabIndex = 50;
            this.linkCheckins.TabStop = true;
            this.linkCheckins.Text = "Fetch Checkins \r\n(Click on a checkin to view it\'s details)";
            this.linkCheckins.UseCompatibleTextRendering = true;
            this.linkCheckins.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCheckins_LinkClicked);
            // 
            // listBoxCheckins
            // 
            this.listBoxCheckins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxCheckins.DisplayMember = "name";
            this.listBoxCheckins.FormattingEnabled = true;
            this.listBoxCheckins.ItemHeight = 25;
            this.listBoxCheckins.Location = new System.Drawing.Point(16, 837);
            this.listBoxCheckins.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.listBoxCheckins.Name = "listBoxCheckins";
            this.listBoxCheckins.Size = new System.Drawing.Size(658, 329);
            this.listBoxCheckins.TabIndex = 40;
            this.listBoxCheckins.SelectedIndexChanged += new System.EventHandler(this.listBoxEvents_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1684, 1248);
            this.tabControl1.TabIndex = 51;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBoxPostComments);
            this.tabPage1.Controls.Add(this.pictureBoxPage);
            this.tabPage1.Controls.Add(this.pictureBoxEvent);
            this.tabPage1.Controls.Add(this.buttonLogin);
            this.tabPage1.Controls.Add(this.linkCheckins);
            this.tabPage1.Controls.Add(this.listBoxFriends);
            this.tabPage1.Controls.Add(this.linkPosts);
            this.tabPage1.Controls.Add(this.listBoxPages);
            this.tabPage1.Controls.Add(this.linkPages);
            this.tabPage1.Controls.Add(this.listBoxEvents);
            this.tabPage1.Controls.Add(this.labelEvents);
            this.tabPage1.Controls.Add(this.listBoxCheckins);
            this.tabPage1.Controls.Add(this.linkFriends);
            this.tabPage1.Controls.Add(this.listBoxPosts);
            this.tabPage1.Controls.Add(this.buttonSetStatus);
            this.tabPage1.Controls.Add(this.picture_smallPictureBox);
            this.tabPage1.Controls.Add(this.textBoxStatus);
            this.tabPage1.Controls.Add(this.pictureBoxFriend);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage1.Size = new System.Drawing.Size(1668, 1201);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBoxPage
            // 
            this.pictureBoxPage.Location = new System.Drawing.Point(1500, 781);
            this.pictureBoxPage.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBoxPage.Name = "pictureBoxPage";
            this.pictureBoxPage.Size = new System.Drawing.Size(148, 131);
            this.pictureBoxPage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPage.TabIndex = 42;
            this.pictureBoxPage.TabStop = false;
            // 
            // listBoxPages
            // 
            this.listBoxPages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPages.DisplayMember = "name";
            this.listBoxPages.FormattingEnabled = true;
            this.listBoxPages.ItemHeight = 25;
            this.listBoxPages.Location = new System.Drawing.Point(716, 837);
            this.listBoxPages.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.listBoxPages.Name = "listBoxPages";
            this.listBoxPages.Size = new System.Drawing.Size(928, 329);
            this.listBoxPages.TabIndex = 40;
            this.listBoxPages.SelectedIndexChanged += new System.EventHandler(this.listBoxPages_SelectedIndexChanged);
            // 
            // linkPages
            // 
            this.linkPages.AutoSize = true;
            this.linkPages.LinkArea = new System.Windows.Forms.LinkArea(0, 17);
            this.linkPages.Location = new System.Drawing.Point(716, 773);
            this.linkPages.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.linkPages.Name = "linkPages";
            this.linkPages.Size = new System.Drawing.Size(346, 54);
            this.linkPages.TabIndex = 48;
            this.linkPages.TabStop = true;
            this.linkPages.Text = "Fetch Liked Pages \r\n(Click on a page to view it\'s picture)";
            this.linkPages.UseCompatibleTextRendering = true;
            this.linkPages.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPages_LinkClicked);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboBoxActionType);
            this.tabPage2.Controls.Add(this.dataGridViewActions);
            this.tabPage2.Controls.Add(this.linkUserActions);
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage2.Size = new System.Drawing.Size(1668, 1201);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBoxActionType
            // 
            this.comboBoxActionType.FormattingEnabled = true;
            this.comboBoxActionType.Items.AddRange(new object[] {
            "music",
            "television",
            "movies",
            "books",
            "books.reads",
            "books.wants_to_read",
            "books.rates",
            "books.quotes",
            "fitness.runs",
            "fitness.walks",
            "fitness.bikes",
            "music.listens",
            "music.playlists",
            "news.reads",
            "news.publishes",
            "video.watches",
            "video.rates",
            "videos.wants_to_watch"});
            this.comboBoxActionType.Location = new System.Drawing.Point(240, 12);
            this.comboBoxActionType.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboBoxActionType.Name = "comboBoxActionType";
            this.comboBoxActionType.Size = new System.Drawing.Size(326, 33);
            this.comboBoxActionType.TabIndex = 23;
            // 
            // dataGridViewActions
            // 
            this.dataGridViewActions.AllowUserToAddRows = false;
            this.dataGridViewActions.AllowUserToDeleteRows = false;
            this.dataGridViewActions.AllowUserToOrderColumns = true;
            this.dataGridViewActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewActions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewActions.Location = new System.Drawing.Point(22, 63);
            this.dataGridViewActions.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dataGridViewActions.Name = "dataGridViewActions";
            this.dataGridViewActions.ReadOnly = true;
            this.dataGridViewActions.Size = new System.Drawing.Size(1630, 1098);
            this.dataGridViewActions.TabIndex = 22;
            // 
            // linkUserActions
            // 
            this.linkUserActions.AutoSize = true;
            this.linkUserActions.Location = new System.Drawing.Point(16, 17);
            this.linkUserActions.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.linkUserActions.Name = "linkUserActions";
            this.linkUserActions.Size = new System.Drawing.Size(194, 25);
            this.linkUserActions.TabIndex = 14;
            this.linkUserActions.TabStop = true;
            this.linkUserActions.Text = "Fetch User Actions";
            this.linkUserActions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUserActions_LinkClicked);
            // 
            // listBoxPostComments
            // 
            this.listBoxPostComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPostComments.DisplayMember = "name";
            this.listBoxPostComments.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxPostComments.FormattingEnabled = true;
            this.listBoxPostComments.ItemHeight = 39;
            this.listBoxPostComments.Location = new System.Drawing.Point(892, 121);
            this.listBoxPostComments.Margin = new System.Windows.Forms.Padding(6);
            this.listBoxPostComments.Name = "listBoxPostComments";
            this.listBoxPostComments.Size = new System.Drawing.Size(712, 277);
            this.listBoxPostComments.TabIndex = 51;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1684, 1248);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_smallPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEvent)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPage)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxFriend;
        private System.Windows.Forms.PictureBox picture_smallPictureBox;
        private System.Windows.Forms.ListBox listBoxFriends;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.ListBox listBoxEvents;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Button buttonSetStatus;
        private System.Windows.Forms.ListBox listBoxPosts;
        private System.Windows.Forms.PictureBox pictureBoxEvent;
        private System.Windows.Forms.LinkLabel linkFriends;
        private System.Windows.Forms.LinkLabel labelEvents;
        private System.Windows.Forms.LinkLabel linkPosts;
        private System.Windows.Forms.LinkLabel linkCheckins;
        private System.Windows.Forms.ListBox listBoxCheckins;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBoxPage;
        private System.Windows.Forms.ListBox listBoxPages;
        private System.Windows.Forms.LinkLabel linkPages;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboBoxActionType;
        private System.Windows.Forms.DataGridView dataGridViewActions;
        private System.Windows.Forms.LinkLabel linkUserActions;
        private System.Windows.Forms.ListBox listBoxPostComments;
    }
}

