namespace MinecraftManagerPlus
{
    partial class FormMinecraft
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMinecraft));
            this.lbl_share = new System.Windows.Forms.Label();
            this.txt_share = new System.Windows.Forms.TextBox();
            this.browse_share = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_share = new System.Windows.Forms.Button();
            this.lbl_exec = new System.Windows.Forms.Label();
            this.txt_exec = new System.Windows.Forms.TextBox();
            this.open_exec = new System.Windows.Forms.OpenFileDialog();
            this.btn_exec = new System.Windows.Forms.Button();
            this.lbl_backup = new System.Windows.Forms.Label();
            this.numeric_backup = new System.Windows.Forms.NumericUpDown();
            this.btn_about = new System.Windows.Forms.Button();
            this.btn_launch = new System.Windows.Forms.Button();
            this.contextMenu_Launch = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_launch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_backupOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_backup = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_workingDir = new System.Windows.Forms.Button();
            this.lbl_workingDir = new System.Windows.Forms.Label();
            this.txt_workingDir = new System.Windows.Forms.TextBox();
            this.browse_workingDir = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.btn_java = new System.Windows.Forms.Button();
            this.open_java = new System.Windows.Forms.OpenFileDialog();
            this.btn_log = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_launcher = new System.Windows.Forms.TabPage();
            this.chk_NoJava = new System.Windows.Forms.CheckBox();
            this.btn_options = new System.Windows.Forms.Button();
            this.txt_options = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.lbl_options = new System.Windows.Forms.Label();
            this.lbl_User = new System.Windows.Forms.Label();
            this.btn_DeleteUser = new System.Windows.Forms.Button();
            this.btn_EditUser = new System.Windows.Forms.Button();
            this.btn_CopyUser = new System.Windows.Forms.Button();
            this.btn_NewUser = new System.Windows.Forms.Button();
            this.btn_UserSize = new System.Windows.Forms.Button();
            this.lv_Users = new System.Windows.Forms.ListView();
            this.LargeImageList = new System.Windows.Forms.ImageList(this.components);
            this.SmallImageList = new System.Windows.Forms.ImageList(this.components);
            this.lbl_IconSize = new System.Windows.Forms.Label();
            this.tabPage_logging = new System.Windows.Forms.TabPage();
            this.groupBox_Log = new System.Windows.Forms.GroupBox();
            this.btn_SaveLog = new System.Windows.Forms.Button();
            this.btn_ClearLog = new System.Windows.Forms.Button();
            this.textBox_Logging = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.open_options = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_backup)).BeginInit();
            this.contextMenu_Launch.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage_launcher.SuspendLayout();
            this.tabPage_logging.SuspendLayout();
            this.groupBox_Log.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_share
            // 
            this.lbl_share.AutoSize = true;
            this.lbl_share.Location = new System.Drawing.Point(237, 194);
            this.lbl_share.Name = "lbl_share";
            this.lbl_share.Size = new System.Drawing.Size(117, 13);
            this.lbl_share.TabIndex = 0;
            this.lbl_share.Text = "Backup Save Directory";
            this.toolTip.SetToolTip(this.lbl_share, "The path to your backup or shared save directory.");
            // 
            // txt_share
            // 
            this.txt_share.AllowDrop = true;
            this.txt_share.Location = new System.Drawing.Point(240, 210);
            this.txt_share.Name = "txt_share";
            this.txt_share.Size = new System.Drawing.Size(389, 20);
            this.txt_share.TabIndex = 1;
            this.toolTip.SetToolTip(this.txt_share, "The path to your backup or shared save directory.");
            this.txt_share.DragDrop += new System.Windows.Forms.DragEventHandler(this.TxtShareDragDrop);
            this.txt_share.Leave += new System.EventHandler(this.TxtShareTextChanged);
            // 
            // btn_share
            // 
            this.btn_share.Location = new System.Drawing.Point(636, 208);
            this.btn_share.Name = "btn_share";
            this.btn_share.Size = new System.Drawing.Size(75, 23);
            this.btn_share.TabIndex = 2;
            this.btn_share.Text = "Browse...";
            this.toolTip.SetToolTip(this.btn_share, "The path to your backup or shared save directory.");
            this.btn_share.UseVisualStyleBackColor = true;
            this.btn_share.Click += new System.EventHandler(this.BtnShareClick);
            // 
            // lbl_exec
            // 
            this.lbl_exec.AutoSize = true;
            this.lbl_exec.Location = new System.Drawing.Point(237, 116);
            this.lbl_exec.Name = "lbl_exec";
            this.lbl_exec.Size = new System.Drawing.Size(38, 13);
            this.lbl_exec.TabIndex = 3;
            this.lbl_exec.Text = "Target";
            this.toolTip.SetToolTip(this.lbl_exec, "The path to your minecraft executable.");
            // 
            // txt_exec
            // 
            this.txt_exec.AllowDrop = true;
            this.txt_exec.Location = new System.Drawing.Point(240, 132);
            this.txt_exec.Name = "txt_exec";
            this.txt_exec.Size = new System.Drawing.Size(389, 20);
            this.txt_exec.TabIndex = 4;
            this.toolTip.SetToolTip(this.txt_exec, "The path to your minecraft executable.");
            this.txt_exec.DragDrop += new System.Windows.Forms.DragEventHandler(this.TxtExecDragDrop);
            this.txt_exec.Leave += new System.EventHandler(this.TxtExecTextChanged);
            // 
            // open_exec
            // 
            this.open_exec.FileName = "open_exec";
            // 
            // btn_exec
            // 
            this.btn_exec.Location = new System.Drawing.Point(636, 130);
            this.btn_exec.Name = "btn_exec";
            this.btn_exec.Size = new System.Drawing.Size(75, 23);
            this.btn_exec.TabIndex = 2;
            this.btn_exec.Text = "Browse...";
            this.toolTip.SetToolTip(this.btn_exec, "The path to your minecraft executable.");
            this.btn_exec.UseVisualStyleBackColor = true;
            this.btn_exec.Click += new System.EventHandler(this.BtnExecClick);
            // 
            // lbl_backup
            // 
            this.lbl_backup.AutoSize = true;
            this.lbl_backup.Location = new System.Drawing.Point(237, 27);
            this.lbl_backup.Name = "lbl_backup";
            this.lbl_backup.Size = new System.Drawing.Size(75, 13);
            this.lbl_backup.TabIndex = 5;
            this.lbl_backup.Text = "Backup Count";
            this.toolTip.SetToolTip(this.lbl_backup, "The number of local backups to retain. (0 to keep all saved files)");
            // 
            // numeric_backup
            // 
            this.numeric_backup.Location = new System.Drawing.Point(240, 45);
            this.numeric_backup.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_backup.Name = "numeric_backup";
            this.numeric_backup.Size = new System.Drawing.Size(72, 20);
            this.numeric_backup.TabIndex = 6;
            this.toolTip.SetToolTip(this.numeric_backup, "The number of local backups to retain. (0 to keep all saved files)");
            this.numeric_backup.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numeric_backup.ValueChanged += new System.EventHandler(this.NumericBackupValueChanged);
            this.numeric_backup.Leave += new System.EventHandler(this.NumericBackupValueChanged);
            // 
            // btn_about
            // 
            this.btn_about.Location = new System.Drawing.Point(663, 6);
            this.btn_about.Name = "btn_about";
            this.btn_about.Size = new System.Drawing.Size(48, 23);
            this.btn_about.TabIndex = 7;
            this.btn_about.Text = "About";
            this.toolTip.SetToolTip(this.btn_about, "How to use this tool.");
            this.btn_about.UseVisualStyleBackColor = true;
            this.btn_about.Click += new System.EventHandler(this.BtnHelpAbout);
            // 
            // btn_launch
            // 
            this.btn_launch.ContextMenuStrip = this.contextMenu_Launch;
            this.btn_launch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_launch.ForeColor = System.Drawing.Color.Green;
            this.btn_launch.Location = new System.Drawing.Point(283, 236);
            this.btn_launch.Name = "btn_launch";
            this.btn_launch.Size = new System.Drawing.Size(281, 31);
            this.btn_launch.TabIndex = 8;
            this.btn_launch.Text = "Launch Minecraft Now!";
            this.toolTip.SetToolTip(this.btn_launch, "Launch Minecraft!");
            this.btn_launch.UseVisualStyleBackColor = true;
            this.btn_launch.Click += new System.EventHandler(this.BtnLaunchClick);
            // 
            // contextMenu_Launch
            // 
            this.contextMenu_Launch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_launch,
            this.toolStripMenuItem_backupOnly,
            this.toolStripMenuItem_backup});
            this.contextMenu_Launch.Name = "contextMenu_Launch";
            this.contextMenu_Launch.Size = new System.Drawing.Size(176, 70);
            // 
            // toolStripMenuItem_launch
            // 
            this.toolStripMenuItem_launch.Name = "toolStripMenuItem_launch";
            this.toolStripMenuItem_launch.Size = new System.Drawing.Size(175, 22);
            this.toolStripMenuItem_launch.Text = "Launch Minecraft";
            this.toolStripMenuItem_launch.Click += new System.EventHandler(this.ToolStripMenuItemLaunchClick);
            // 
            // toolStripMenuItem_backupOnly
            // 
            this.toolStripMenuItem_backupOnly.Name = "toolStripMenuItem_backupOnly";
            this.toolStripMenuItem_backupOnly.Size = new System.Drawing.Size(175, 22);
            this.toolStripMenuItem_backupOnly.Text = "Backup Only Mode";
            this.toolStripMenuItem_backupOnly.Click += new System.EventHandler(this.ToolStripMenuItemBackupOnlyClick);
            // 
            // toolStripMenuItem_backup
            // 
            this.toolStripMenuItem_backup.Name = "toolStripMenuItem_backup";
            this.toolStripMenuItem_backup.Size = new System.Drawing.Size(175, 22);
            this.toolStripMenuItem_backup.Text = "Backup Save Files";
            this.toolStripMenuItem_backup.Click += new System.EventHandler(this.ToolStripMenuItemBackupClick);
            // 
            // btn_workingDir
            // 
            this.btn_workingDir.Location = new System.Drawing.Point(636, 169);
            this.btn_workingDir.Name = "btn_workingDir";
            this.btn_workingDir.Size = new System.Drawing.Size(75, 23);
            this.btn_workingDir.TabIndex = 2;
            this.btn_workingDir.Text = "Browse...";
            this.toolTip.SetToolTip(this.btn_workingDir, "The path to the Minecraft working directory for your user profile.");
            this.btn_workingDir.UseVisualStyleBackColor = true;
            this.btn_workingDir.Click += new System.EventHandler(this.BtnWorkingDirClick);
            // 
            // lbl_workingDir
            // 
            this.lbl_workingDir.AutoSize = true;
            this.lbl_workingDir.Location = new System.Drawing.Point(237, 155);
            this.lbl_workingDir.Name = "lbl_workingDir";
            this.lbl_workingDir.Size = new System.Drawing.Size(139, 13);
            this.lbl_workingDir.TabIndex = 3;
            this.lbl_workingDir.Text = "Minecraft Working Directory";
            this.toolTip.SetToolTip(this.lbl_workingDir, "The path to the Minecraft working directory for your user profile.");
            // 
            // txt_workingDir
            // 
            this.txt_workingDir.AllowDrop = true;
            this.txt_workingDir.Location = new System.Drawing.Point(240, 171);
            this.txt_workingDir.Name = "txt_workingDir";
            this.txt_workingDir.Size = new System.Drawing.Size(389, 20);
            this.txt_workingDir.TabIndex = 4;
            this.toolTip.SetToolTip(this.txt_workingDir, "The path to the Minecraft working directory for your user profile.");
            this.txt_workingDir.DragDrop += new System.Windows.Forms.DragEventHandler(this.TxtWorkingDirDragDrop);
            this.txt_workingDir.Leave += new System.EventHandler(this.TxtWorkingDirTextChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusText,
            this.progressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 329);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(750, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 9;
            // 
            // statusText
            // 
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(0, 17);
            // 
            // progressBar
            // 
            this.progressBar.AutoToolTip = true;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(200, 16);
            this.progressBar.Visible = false;
            // 
            // btn_java
            // 
            this.btn_java.Location = new System.Drawing.Point(336, 45);
            this.btn_java.Name = "btn_java";
            this.btn_java.Size = new System.Drawing.Size(93, 23);
            this.btn_java.TabIndex = 7;
            this.btn_java.Text = "Java Path";
            this.toolTip.SetToolTip(this.btn_java, "Set the location of Java to use.");
            this.btn_java.UseVisualStyleBackColor = true;
            this.btn_java.Click += new System.EventHandler(this.BtnJavaClick);
            // 
            // open_java
            // 
            this.open_java.FileName = "open_java";
            // 
            // btn_log
            // 
            this.btn_log.Location = new System.Drawing.Point(671, 34);
            this.btn_log.Name = "btn_log";
            this.btn_log.Size = new System.Drawing.Size(40, 23);
            this.btn_log.TabIndex = 13;
            this.btn_log.Text = "Log";
            this.toolTip.SetToolTip(this.btn_log, "Show log.");
            this.btn_log.UseVisualStyleBackColor = true;
            this.btn_log.Click += new System.EventHandler(this.BtnLogClick);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_launcher);
            this.tabControl.Controls.Add(this.tabPage_logging);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(726, 302);
            this.tabControl.TabIndex = 14;
            // 
            // tabPage_launcher
            // 
            this.tabPage_launcher.Controls.Add(this.btn_launch);
            this.tabPage_launcher.Controls.Add(this.chk_NoJava);
            this.tabPage_launcher.Controls.Add(this.btn_options);
            this.tabPage_launcher.Controls.Add(this.txt_options);
            this.tabPage_launcher.Controls.Add(this.btn_share);
            this.tabPage_launcher.Controls.Add(this.btn_save);
            this.tabPage_launcher.Controls.Add(this.txt_share);
            this.tabPage_launcher.Controls.Add(this.lbl_share);
            this.tabPage_launcher.Controls.Add(this.btn_exec);
            this.tabPage_launcher.Controls.Add(this.btn_workingDir);
            this.tabPage_launcher.Controls.Add(this.lbl_options);
            this.tabPage_launcher.Controls.Add(this.txt_exec);
            this.tabPage_launcher.Controls.Add(this.txt_workingDir);
            this.tabPage_launcher.Controls.Add(this.lbl_workingDir);
            this.tabPage_launcher.Controls.Add(this.lbl_backup);
            this.tabPage_launcher.Controls.Add(this.lbl_exec);
            this.tabPage_launcher.Controls.Add(this.lbl_User);
            this.tabPage_launcher.Controls.Add(this.numeric_backup);
            this.tabPage_launcher.Controls.Add(this.btn_DeleteUser);
            this.tabPage_launcher.Controls.Add(this.btn_EditUser);
            this.tabPage_launcher.Controls.Add(this.btn_CopyUser);
            this.tabPage_launcher.Controls.Add(this.btn_NewUser);
            this.tabPage_launcher.Controls.Add(this.btn_UserSize);
            this.tabPage_launcher.Controls.Add(this.lv_Users);
            this.tabPage_launcher.Controls.Add(this.btn_log);
            this.tabPage_launcher.Controls.Add(this.btn_about);
            this.tabPage_launcher.Controls.Add(this.btn_java);
            this.tabPage_launcher.Controls.Add(this.lbl_IconSize);
            this.tabPage_launcher.Location = new System.Drawing.Point(4, 22);
            this.tabPage_launcher.Name = "tabPage_launcher";
            this.tabPage_launcher.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_launcher.Size = new System.Drawing.Size(718, 276);
            this.tabPage_launcher.TabIndex = 0;
            this.tabPage_launcher.Text = "Launcher";
            this.tabPage_launcher.UseVisualStyleBackColor = true;
            this.tabPage_launcher.Click += new System.EventHandler(this.LvUsersLeave);
            // 
            // chk_NoJava
            // 
            this.chk_NoJava.AutoSize = true;
            this.chk_NoJava.Location = new System.Drawing.Point(159, 250);
            this.chk_NoJava.Name = "chk_NoJava";
            this.chk_NoJava.Size = new System.Drawing.Size(128, 17);
            this.chk_NoJava.TabIndex = 9;
            this.chk_NoJava.Text = "Launch Without Java";
            this.toolTip.SetToolTip(this.chk_NoJava, "This will enable you to launch without using Java, like\r\nwhen launching tekkit (l" +
        "aunches Java itself).");
            this.chk_NoJava.UseVisualStyleBackColor = true;
            this.chk_NoJava.Click += new System.EventHandler(this.ChkNoJavaClick);
            // 
            // btn_options
            // 
            this.btn_options.Location = new System.Drawing.Point(636, 90);
            this.btn_options.Name = "btn_options";
            this.btn_options.Size = new System.Drawing.Size(75, 23);
            this.btn_options.TabIndex = 2;
            this.btn_options.Text = "Browse...";
            this.btn_options.UseVisualStyleBackColor = true;
            this.btn_options.Click += new System.EventHandler(this.BtnOptionsClick);
            // 
            // txt_options
            // 
            this.txt_options.AllowDrop = true;
            this.txt_options.Location = new System.Drawing.Point(240, 93);
            this.txt_options.Name = "txt_options";
            this.txt_options.Size = new System.Drawing.Size(389, 20);
            this.txt_options.TabIndex = 4;
            this.txt_options.DragDrop += new System.Windows.Forms.DragEventHandler(this.TxtExecDragDrop);
            this.txt_options.Leave += new System.EventHandler(this.TxtExecTextChanged);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(128, 206);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 14;
            this.btn_save.Text = "Save Settings";
            this.toolTip.SetToolTip(this.btn_save, "Save the settings for the selected user profile.");
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // lbl_options
            // 
            this.lbl_options.AutoSize = true;
            this.lbl_options.Location = new System.Drawing.Point(237, 77);
            this.lbl_options.Name = "lbl_options";
            this.lbl_options.Size = new System.Drawing.Size(62, 13);
            this.lbl_options.TabIndex = 3;
            this.lbl_options.Text = "Options File";
            // 
            // lbl_User
            // 
            this.lbl_User.AutoSize = true;
            this.lbl_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_User.ForeColor = System.Drawing.Color.Green;
            this.lbl_User.Location = new System.Drawing.Point(6, 3);
            this.lbl_User.Name = "lbl_User";
            this.lbl_User.Size = new System.Drawing.Size(82, 20);
            this.lbl_User.TabIndex = 20;
            this.lbl_User.Text = "Welcome";
            // 
            // btn_DeleteUser
            // 
            this.btn_DeleteUser.Location = new System.Drawing.Point(128, 144);
            this.btn_DeleteUser.Name = "btn_DeleteUser";
            this.btn_DeleteUser.Size = new System.Drawing.Size(64, 23);
            this.btn_DeleteUser.TabIndex = 18;
            this.btn_DeleteUser.Text = "Delete";
            this.btn_DeleteUser.UseVisualStyleBackColor = true;
            this.btn_DeleteUser.Click += new System.EventHandler(this.BtnDeleteUserClick);
            // 
            // btn_EditUser
            // 
            this.btn_EditUser.Location = new System.Drawing.Point(128, 115);
            this.btn_EditUser.Name = "btn_EditUser";
            this.btn_EditUser.Size = new System.Drawing.Size(64, 23);
            this.btn_EditUser.TabIndex = 18;
            this.btn_EditUser.Text = "Edit";
            this.btn_EditUser.UseVisualStyleBackColor = true;
            this.btn_EditUser.Click += new System.EventHandler(this.BtnEditUserClick);
            // 
            // btn_CopyUser
            // 
            this.btn_CopyUser.Location = new System.Drawing.Point(128, 86);
            this.btn_CopyUser.Name = "btn_CopyUser";
            this.btn_CopyUser.Size = new System.Drawing.Size(64, 23);
            this.btn_CopyUser.TabIndex = 18;
            this.btn_CopyUser.Text = "Copy";
            this.btn_CopyUser.UseVisualStyleBackColor = true;
            this.btn_CopyUser.Click += new System.EventHandler(this.BtnCopyUserClick);
            // 
            // btn_NewUser
            // 
            this.btn_NewUser.Location = new System.Drawing.Point(128, 57);
            this.btn_NewUser.Name = "btn_NewUser";
            this.btn_NewUser.Size = new System.Drawing.Size(64, 23);
            this.btn_NewUser.TabIndex = 18;
            this.btn_NewUser.Text = "New";
            this.btn_NewUser.UseVisualStyleBackColor = true;
            this.btn_NewUser.Click += new System.EventHandler(this.BtnNewUserClick);
            // 
            // btn_UserSize
            // 
            this.btn_UserSize.Location = new System.Drawing.Point(128, 28);
            this.btn_UserSize.Name = "btn_UserSize";
            this.btn_UserSize.Size = new System.Drawing.Size(30, 23);
            this.btn_UserSize.TabIndex = 17;
            this.btn_UserSize.Text = "Lg";
            this.btn_UserSize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip.SetToolTip(this.btn_UserSize, "Size of the user icon");
            this.btn_UserSize.UseVisualStyleBackColor = true;
            this.btn_UserSize.Click += new System.EventHandler(this.BtnUserSizeClick);
            // 
            // lv_Users
            // 
            this.lv_Users.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_Users.LargeImageList = this.LargeImageList;
            this.lv_Users.Location = new System.Drawing.Point(10, 27);
            this.lv_Users.MultiSelect = false;
            this.lv_Users.Name = "lv_Users";
            this.lv_Users.Size = new System.Drawing.Size(112, 202);
            this.lv_Users.SmallImageList = this.SmallImageList;
            this.lv_Users.TabIndex = 16;
            this.lv_Users.UseCompatibleStateImageBehavior = false;
            this.lv_Users.View = System.Windows.Forms.View.SmallIcon;
            this.lv_Users.SelectedIndexChanged += new System.EventHandler(this.LvUsersSelectedIndexChanged);
            this.lv_Users.Enter += new System.EventHandler(this.LvUsersLeave);
            this.lv_Users.Leave += new System.EventHandler(this.LvUsersLeave);
            this.lv_Users.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LvUsersMouseDoubleClick);
            // 
            // LargeImageList
            // 
            this.LargeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("LargeImageList.ImageStream")));
            this.LargeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.LargeImageList.Images.SetKeyName(0, "Cat.png");
            this.LargeImageList.Images.SetKeyName(1, "Cow.png");
            this.LargeImageList.Images.SetKeyName(2, "Creeper.png");
            this.LargeImageList.Images.SetKeyName(3, "Dog.png");
            this.LargeImageList.Images.SetKeyName(4, "Duck.png");
            this.LargeImageList.Images.SetKeyName(5, "Ghast.png");
            this.LargeImageList.Images.SetKeyName(6, "Pig.png");
            this.LargeImageList.Images.SetKeyName(7, "Skeleton.png");
            this.LargeImageList.Images.SetKeyName(8, "Snowgolem.png");
            this.LargeImageList.Images.SetKeyName(9, "Squid.png");
            this.LargeImageList.Images.SetKeyName(10, "Steve.png");
            this.LargeImageList.Images.SetKeyName(11, "Zombie.png");
            // 
            // SmallImageList
            // 
            this.SmallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SmallImageList.ImageStream")));
            this.SmallImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.SmallImageList.Images.SetKeyName(0, "CatSmall.png");
            this.SmallImageList.Images.SetKeyName(1, "CowSmall.png");
            this.SmallImageList.Images.SetKeyName(2, "CreeperSmall.png");
            this.SmallImageList.Images.SetKeyName(3, "DogSmall.png");
            this.SmallImageList.Images.SetKeyName(4, "DuckSmall.png");
            this.SmallImageList.Images.SetKeyName(5, "GhastSmall.png");
            this.SmallImageList.Images.SetKeyName(6, "PigSmall.png");
            this.SmallImageList.Images.SetKeyName(7, "SkeletonSmall.png");
            this.SmallImageList.Images.SetKeyName(8, "SnowgolemSmall.png");
            this.SmallImageList.Images.SetKeyName(9, "SquidSmall.png");
            this.SmallImageList.Images.SetKeyName(10, "SteveSmall.png");
            this.SmallImageList.Images.SetKeyName(11, "ZombieSmall.png");
            // 
            // lbl_IconSize
            // 
            this.lbl_IconSize.AutoSize = true;
            this.lbl_IconSize.Location = new System.Drawing.Point(156, 34);
            this.lbl_IconSize.Name = "lbl_IconSize";
            this.lbl_IconSize.Size = new System.Drawing.Size(27, 13);
            this.lbl_IconSize.TabIndex = 19;
            this.lbl_IconSize.Text = "Size";
            // 
            // tabPage_logging
            // 
            this.tabPage_logging.Controls.Add(this.groupBox_Log);
            this.tabPage_logging.Location = new System.Drawing.Point(4, 22);
            this.tabPage_logging.Name = "tabPage_logging";
            this.tabPage_logging.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_logging.Size = new System.Drawing.Size(718, 276);
            this.tabPage_logging.TabIndex = 1;
            this.tabPage_logging.Text = "Logging";
            this.tabPage_logging.UseVisualStyleBackColor = true;
            // 
            // groupBox_Log
            // 
            this.groupBox_Log.Controls.Add(this.btn_SaveLog);
            this.groupBox_Log.Controls.Add(this.btn_ClearLog);
            this.groupBox_Log.Controls.Add(this.textBox_Logging);
            this.groupBox_Log.Location = new System.Drawing.Point(6, 6);
            this.groupBox_Log.Name = "groupBox_Log";
            this.groupBox_Log.Size = new System.Drawing.Size(706, 264);
            this.groupBox_Log.TabIndex = 1;
            this.groupBox_Log.TabStop = false;
            this.groupBox_Log.Text = "Log";
            this.toolTip.SetToolTip(this.groupBox_Log, "Logging information.");
            // 
            // btn_SaveLog
            // 
            this.btn_SaveLog.Location = new System.Drawing.Point(626, 47);
            this.btn_SaveLog.Name = "btn_SaveLog";
            this.btn_SaveLog.Size = new System.Drawing.Size(75, 23);
            this.btn_SaveLog.TabIndex = 2;
            this.btn_SaveLog.Text = "Save Log";
            this.btn_SaveLog.UseVisualStyleBackColor = true;
            this.btn_SaveLog.Click += new System.EventHandler(this.BtnSaveLogClick);
            // 
            // btn_ClearLog
            // 
            this.btn_ClearLog.Location = new System.Drawing.Point(625, 17);
            this.btn_ClearLog.Name = "btn_ClearLog";
            this.btn_ClearLog.Size = new System.Drawing.Size(75, 23);
            this.btn_ClearLog.TabIndex = 1;
            this.btn_ClearLog.Text = "Clear Log";
            this.btn_ClearLog.UseVisualStyleBackColor = true;
            this.btn_ClearLog.Click += new System.EventHandler(this.BtnClearLogClick);
            // 
            // textBox_Logging
            // 
            this.textBox_Logging.Location = new System.Drawing.Point(20, 19);
            this.textBox_Logging.Multiline = true;
            this.textBox_Logging.Name = "textBox_Logging";
            this.textBox_Logging.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Logging.Size = new System.Drawing.Size(599, 239);
            this.textBox_Logging.TabIndex = 0;
            this.toolTip.SetToolTip(this.textBox_Logging, "Logging information.");
            // 
            // toolTip
            // 
            this.toolTip.ShowAlways = true;
            // 
            // open_options
            // 
            this.open_options.FileName = "options.txt";
            // 
            // FormMinecraft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 351);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMinecraft";
            this.Text = "Minecraft Manager Plus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMinecraftFormClosing);
            this.Click += new System.EventHandler(this.LvUsersLeave);
            ((System.ComponentModel.ISupportInitialize)(this.numeric_backup)).EndInit();
            this.contextMenu_Launch.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage_launcher.ResumeLayout(false);
            this.tabPage_launcher.PerformLayout();
            this.tabPage_logging.ResumeLayout(false);
            this.groupBox_Log.ResumeLayout(false);
            this.groupBox_Log.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_share;
        private System.Windows.Forms.TextBox txt_share;
        private System.Windows.Forms.FolderBrowserDialog browse_share;
        private System.Windows.Forms.Button btn_share;
        private System.Windows.Forms.Label lbl_exec;
        private System.Windows.Forms.TextBox txt_exec;
        private System.Windows.Forms.OpenFileDialog open_exec;
        private System.Windows.Forms.Button btn_exec;
        private System.Windows.Forms.Label lbl_backup;
        private System.Windows.Forms.NumericUpDown numeric_backup;
        private System.Windows.Forms.Button btn_about;
        private System.Windows.Forms.Button btn_launch;
        private System.Windows.Forms.Button btn_workingDir;
        private System.Windows.Forms.Label lbl_workingDir;
        private System.Windows.Forms.TextBox txt_workingDir;
        private System.Windows.Forms.FolderBrowserDialog browse_workingDir;
        private System.Windows.Forms.ContextMenuStrip contextMenu_Launch;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_launch;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_backup;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusText;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.Button btn_java;
        private System.Windows.Forms.OpenFileDialog open_java;
        private System.Windows.Forms.Button btn_log;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_launcher;
        private System.Windows.Forms.TabPage tabPage_logging;
        private System.Windows.Forms.TextBox textBox_Logging;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBox_Log;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.OpenFileDialog open_options;
        private System.Windows.Forms.Button btn_options;
        private System.Windows.Forms.TextBox txt_options;
        private System.Windows.Forms.Label lbl_options;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_backupOnly;
        private System.Windows.Forms.CheckBox chk_NoJava;
        private System.Windows.Forms.ListView lv_Users;
        private System.Windows.Forms.ImageList SmallImageList;
        private System.Windows.Forms.ImageList LargeImageList;
        private System.Windows.Forms.Button btn_UserSize;
        private System.Windows.Forms.Button btn_NewUser;
        private System.Windows.Forms.Label lbl_IconSize;
        private System.Windows.Forms.Label lbl_User;
        private System.Windows.Forms.Button btn_EditUser;
        private System.Windows.Forms.Button btn_DeleteUser;
        private System.Windows.Forms.Button btn_ClearLog;
        private System.Windows.Forms.Button btn_SaveLog;
        private System.Windows.Forms.Button btn_CopyUser;
    }
}

