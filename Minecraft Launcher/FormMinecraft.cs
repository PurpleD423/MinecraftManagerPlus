using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ionic.Zip;
using MinecraftManagerPlus.Properties;
using MinecraftManagerPlus.Utility;
using Itenso.Configuration;
using DataModel = MinecraftManagerPlus.App_Data.DataModelContainer;

namespace MinecraftManagerPlus
{
    //TODO: Come up with a new icon that is inspired by MC, but not just MC. Maybe with some Tekkit in there. or "+".
	//TODO: When backing up the files, if all of the files have not changed, then just skip the backup.
    //TODO: Add an option to restore to a previous version of a world(s).
    //TODO: Add a secret way to restore to a previous version of minecraft. Or launch different versions.

    public partial class FormMinecraft : Form
    {
        #region Read Only Defaults
        // ReSharper disable ConvertToConstant.Local
        private readonly string _newline = @"

";

        // ReSharper restore ConvertToConstant.Local
        #endregion

        #region Enum - Statuses
        /// <summary>
        /// Status bar mesages.
        /// </summary>
        protected enum Statuses
        {
            [Description("Ready")] Ready = 1,
            [Description("Launching")] Launching = 2,
            [Description("Running")] Running = 3,
            [Description("Saving")] Saving = 4,
            [Description("Error")] Error = 5,
            [Description("Adding Files")] AddingFiles = 6,
            [Description("Creating Archive")] CreatingArchive = 7,
            [Description("Cleaning Up Folder")] CleaningUpFolder = 8,
            [Description("Backup Complete")] BackupComplete = 9
        }
        #endregion

        #region Public Enum Helper - Description
        public static string Description(Enum value)
        {
            DescriptionAttribute description = value.GetType()
                                                   .GetField(value.ToString())
                                                   .GetCustomAttributes(typeof (DescriptionAttribute), false)
                                                   .Cast<DescriptionAttribute>()
                                                   .FirstOrDefault() ??
                                               new DescriptionAttribute(value.ToString());

            return description.Description;
        }
        #endregion

        #region Members
        protected App_Data.User CurrentUser;
        protected UserForm UserForm;
        private readonly FormSettings _formSettings;
        private readonly ApplicationSettings _appSettings;
        #endregion

        #region Property - InErrorState
        protected bool InErrorState { get; set; }
        #endregion

        #region Property - Username
        public string Username
        {
            get { return CurrentUser.Username; }
            set
            {
                if (CurrentUser.Username == value)
                    return;
                CurrentUser.Username = value;
            }
        }
        #endregion

        #region Property - OptionsFile
        public string OptionsFile
        {
            get { return CurrentUser.Setting.OptionsFile; }
            set
            {
                if (CurrentUser.Setting.OptionsFile == value)
                    return;
                CurrentUser.Setting.OptionsFile = value;
            }
        }
        #endregion

        #region Property - OptionsPath
        public string OptionsPath
        {
            get { return CurrentUser.Setting.OptionsPath; }
            set
            {
                if (CurrentUser.Setting.OptionsPath == value)
                    return;
                CurrentUser.Setting.OptionsPath = value;
            }
        }
        #endregion

        #region Property - BackupCount
        /// <summary>
        /// Get/set the value for BackupCount.
        /// </summary>
        public int BackupCount
        {
            get { return CurrentUser.Setting.BackupCount; }
            set
            {
                if (CurrentUser.Setting.BackupCount == value)
                    return;
                CurrentUser.Setting.BackupCount = value;
            }
        }
        #endregion

        #region Property - SharePath
        /// <summary>
        /// Get/set the value for SharePath.
        /// </summary>
        public string SharePath
        {
            get
            {
                return CurrentUser.Setting.SharePath;
            }
            set
            {
                if (CurrentUser.Setting.SharePath == value)
                    return;
                CurrentUser.Setting.SharePath = value;
            }
        }
        #endregion

        #region Property - TargetPath
        /// <summary>
        /// Get/set the value for TargetPath.
        /// </summary>
        public string TargetPath
        {
            get
            {
                return CurrentUser.Setting.TargetPath;
            }
            set
            {
                if (CurrentUser.Setting.TargetPath == value)
                    return;
                CurrentUser.Setting.TargetPath = value;
            }
        }
        #endregion

        #region Property - WorkingDirectory
        /// <summary>
        /// Get/set the value for WorkingDirectory.
        /// </summary>
        public string WorkingDirectory
        {
            get
            {
                return CurrentUser.Setting.WorkingDirectory;
            }
            set
            {
                if (CurrentUser.Setting.WorkingDirectory == value)
                    return;
                CurrentUser.Setting.WorkingDirectory = value;
            }
        }
        #endregion

        #region Property - Debugging
        /// <summary>
        /// Get/set the value for Debugging.
        /// </summary>
        public bool Debugging
        {
            get
            {
                return CurrentUser.Setting.Debugging;
            }
            set
            {
                if (CurrentUser.Setting.Debugging == value)
                    return;
                CurrentUser.Setting.Debugging = value;
            }
        }
        #endregion

        #region Property - LaunchWithoutJava
        /// <summary>
        /// This is to set the value controlling if we use 
        /// Java to launch the application or not
        /// </summary>
        public bool LaunchWithoutJava
        {
            get
            {
                return CurrentUser.Setting.LaunchWithoutJava;
            }
            set
            {
                if (CurrentUser.Setting.LaunchWithoutJava == value)
                    return;
                CurrentUser.Setting.LaunchWithoutJava = value;
            }
        }
        #endregion

        #region Property - JavaPath
        /// <summary>
        /// The path to the Java executable
        /// </summary>
        public string JavaPath
        {
            get
            {
                return CurrentUser.Setting.JavaPath;
            }
            set
            {
                if (CurrentUser.Setting.JavaPath == value)
                    return;
                CurrentUser.Setting.JavaPath = value;
            }
        }
        #endregion

        #region Property - UserImages
        public ImageList UserImages
        {
            get { return LargeImageList; }
        }
        #endregion

        [PropertySetting]
        public string UserSelectedName { get; set; }

        #region Constructor
        public FormMinecraft()
        {
            InErrorState = false;
            InitializeComponent();

            // create settings group
            _formSettings = new FormSettings(this);
            _formSettings.SaveOnClose = true; // enable auto-save
            _formSettings.Load();

            _appSettings = new ApplicationSettings(this);
            _appSettings.Load();

            bool steve = FileCompare(@"C:\Users\Matt\Desktop\New folder\test",
                                     @"C:\Users\Matt\Desktop\New folder\test - Copy",
                                     true);
            MessageBox.Show(steve.ToString(CultureInfo.InvariantCulture));

            try
            {
                //Thread.Sleep(15000);
                LoadUserList();

                if (lv_Users.FindItemWithText(UserSelectedName) != null)
                {
                    LoadUser(UserSelectedName);
                }
                else
                {
                    LoadUser();
                }

                //LoadUser();
                LoadUserSettings();
                if (CurrentUser == null)
                {
                    MessageBox.Show(Resources.FormMinecraft_LoadUsers_User_load_error_);
                    return;
                }
                Debugging = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("{0}: {1}", Resources.FormMinecraft_FormMinecraft_Error_Occured,
                                  ex.InnerException),
                    Resources.FormMinecraft_FormMinecraft_Error_Occured);
            }
        }
        #endregion

        #region Event Handlers
        private void BtnJavaClick(object sender, EventArgs e)
        {
            var curJavaDir = new FileInfo(JavaPath);
            open_java.InitialDirectory = curJavaDir.DirectoryName;
            open_java.FileName = "java.exe";

            if (open_java.ShowDialog() == DialogResult.OK)
            {
                JavaPath = open_java.FileName;
            }
        }

        private void BtnOptionsClick(object sender, EventArgs e)
        {
            var curExecDir = new FileInfo(OptionsPath);
            open_options.InitialDirectory = curExecDir.DirectoryName;
            open_options.Title = "Options File Location";
            open_options.FileName = "options.txt";

            if (open_options.ShowDialog() == DialogResult.OK)
            {
                OptionsPath = open_exec.FileName;
                txt_options.Text = open_options.FileName;
            }
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            using (var model = new DataModel())
            {
                if (lv_Users.Items.Count > 0)
                {
                    if (CurrentUser == null)
                    {
                        MessageBox.Show(Resources.FormMinecraft_BtnSaveClick_You_must_select_a_User_before_you_can_save_);
                        return;
                    }

                    SaveSettings();
                }
                else
                {
                    MessageBox.Show(Resources.FormMinecraft_LoadUsers_Create_your_first_user_);
                    UserForm = new UserForm(this);
                    UserForm.ShowDialog(this);
                    return;
                }
            }
        }

        private void BtnWorkingDirClick(object sender, EventArgs e)
        {
            var curWorkingDir = new FileInfo(WorkingDirectory);
            browse_workingDir.SelectedPath = curWorkingDir.FullName;
            browse_workingDir.Description = @"Working Directory Path

Directory must contain a folder called ""saves""";

            if (browse_workingDir.ShowDialog() == DialogResult.OK)
            {
                WorkingDirectory = browse_workingDir.SelectedPath;
                txt_workingDir.Text = browse_workingDir.SelectedPath;
            }
        }

        private void BtnShareClick(object sender, EventArgs e)
        {
            var curShareDir = new FileInfo(SharePath);
            browse_share.SelectedPath = curShareDir.FullName;
            browse_share.Description = "Backup Save Directory Path";

            if (browse_share.ShowDialog() == DialogResult.OK)
            {
                SharePath = browse_share.SelectedPath;
                txt_share.Text = browse_share.SelectedPath;
            }
        }

        private void BtnExecClick(object sender, EventArgs e)
        {
            var curExecDir = new FileInfo(TargetPath);
            open_exec.InitialDirectory = curExecDir.DirectoryName;
            open_exec.Title = "Target File Location";
            open_exec.FileName = "Minecraft.exe";

            if (open_exec.ShowDialog() == DialogResult.OK)
            {
                TargetPath = open_exec.FileName;
                txt_exec.Text = open_exec.FileName;
            }
        }

        private void TxtWorkingDirDragDrop(object sender, DragEventArgs e)
        {
            WorkingDirectory = txt_workingDir.Text;
        }

        private void TxtShareDragDrop(object sender, DragEventArgs e)
        {
            SharePath = txt_share.Text;
        }

        private void TxtExecDragDrop(object sender, DragEventArgs e)
        {
            TargetPath = txt_exec.Text;
        }

        private void TxtWorkingDirTextChanged(object sender, EventArgs e)
        {
            WorkingDirectory = txt_workingDir.Text;
        }

        private void TxtShareTextChanged(object sender, EventArgs e)
        {
            SharePath = txt_share.Text;
        }

        private void TxtExecTextChanged(object sender, EventArgs e)
        {
            TargetPath = txt_exec.Text;
        }
        
        private void NumericBackupValueChanged(object sender, EventArgs e)
        {
            BackupCount = (int) numeric_backup.Value;
        }

        private void BtnHelpAbout(object sender, EventArgs e)
        {
            var aboutBox = new AboutBox();
            aboutBox.Show();
        }

        private void BtnLogClick(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPage_logging;
        }

        private void BtnClearLogClick(object sender, EventArgs e)
        {
            textBox_Logging.Clear();
        }

        private void BtnSaveLogClick(object sender, EventArgs e)
        {
            //Save the log to a fileStream myStream = null;
            byte[] array;

            array = StrToByteArray(textBox_Logging.Text);

            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (DialogResult.OK != saveFileDialog1.ShowDialog())
                    return;
                File.WriteAllBytes(saveFileDialog1.FileName, array);
            }
        }

        private byte[] StrToByteArray(string str)
        {
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            return enc.GetBytes(str);
        }

        private void BtnLaunchClick(object sender, EventArgs e)
        {
            SaveSettings(true);
            LaunchMinecraft();
        }

        private void ToolStripMenuItemLaunchClick(object sender, EventArgs e)
        {
            SaveSettings();
            LaunchMinecraft();
        }

        private void ToolStripMenuItemBackupOnlyClick(object sender, EventArgs e)
        {
            LaunchWithoutJava = true;
            SaveSettings();
            LaunchMinecraft();
        }

        private void ToolStripMenuItemBackupClick(object sender, EventArgs e)
        {
            SaveSettings();
            BackupSaveFiles();

            DialogResult result =
                MessageBox.Show(Resources.FormMinecraft_ToolStripMenuItemBackupClick_Backup_complete__Exit_,
                                Resources.FormMinecraft_ToolStripMenuItemBackupClick_Backup_Complete,
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

            ResetUI();
        }

        private void FormMinecraftFormClosing(object sender, FormClosingEventArgs e)
        {
            // ReSharper disable EmptyGeneralCatchClause
            try
            {
                SaveSettings();
            }
            catch
            {
                //If we cannot sucessfully save, just proceed since they are exiting anyway.
            }
            // ReSharper restore EmptyGeneralCatchClause
        }

        private void ZipAddProgress(object sender, AddProgressEventArgs e)
        {
            if (e.EventType == ZipProgressEventType.Adding_AfterAddEntry)
                progressBar.PerformStep();
        }

        private void ZipSaveProgress(object sender, SaveProgressEventArgs e)
        {
            if (e.EventType == ZipProgressEventType.Saving_AfterWriteEntry)
                progressBar.PerformStep();
        }
        #endregion

        #region Method - SaveSettings
        /// <summary>
        /// Persist all of the settings from the UI to the database.
        /// </summary>
        public void SaveSettings(bool isLaunching = false, App_Data.User aUser = null)
        {
            using (var model = new DataModel())
            {
                if (aUser != null)
                {
                    if (model.Users.Any(o => o.Id == aUser.Id))
                    {
                        model.Attach(aUser);
                        model.ObjectStateManager.ChangeObjectState(aUser, EntityState.Modified);
                        model.ObjectStateManager.ChangeObjectState(aUser.Setting, EntityState.Modified);
                        model.SaveChanges();
                        UserForm.SaveCompleted = true;
                    }
                    else
                    {
                        if (model.Users.Any(o => o.Username == aUser.Username))
                        {
                            MessageBox.Show(Resources.FormMinecraft_SaveSettings_This_Username_is_already_in_use_);
                            UserForm.SaveCompleted = false;
                            return;
                        }
                        model.Users.AddObject(aUser);
                        model.SaveChanges();
                        UserForm.SaveCompleted = true;
                    }
                }
                else if (CurrentUser != null)
                {
                    if (!isLaunching)
                    {
                        //Save the options file
                        var curOptionsFile = new FileInfo(txt_options.Text);
                        if (curOptionsFile.Exists)
                        {
                            var reader = curOptionsFile.OpenText();
                            CurrentUser.Setting.OptionsFile = reader.ReadToEnd();
                        }
                        CurrentUser.Setting.OptionsPath = txt_options.Text;
                    }

                    model.Attach(CurrentUser);
                    model.ObjectStateManager.ChangeObjectState(CurrentUser, EntityState.Modified);
                    model.ObjectStateManager.ChangeObjectState(CurrentUser.Setting, EntityState.Modified);
                    model.SaveChanges();
                }
            }
            _formSettings.Save();
            _appSettings.Save();
        }
        #endregion

        #region Method - LoadUserList
        public void LoadUserList()
        {
            using (var model = new DataModel())
            {
                //Load the ListView with all of the users
                lv_Users.Items.Clear();
                foreach (App_Data.User user in model.Users)
                {
                    lv_Users.Items.Add(new ListViewItem(user.Username, user.ImageIndex));
                }
            }
        }
        #endregion

        #region Method - LoadUser
        public void LoadUser(string aUsername = "")
        {
            using (var model = new DataModel())
            {
                //Loading all the settings, not a particular one.
                if (string.IsNullOrEmpty(aUsername))
                {
                    if (model.Users.Any())
                    {
                        CurrentUser = model.Users.Include("Setting").FirstOrDefault();
                        if (CurrentUser != null)
                        {
                            var selectedItem = lv_Users.FindItemWithText(CurrentUser.Username);
                            selectedItem.Selected = true;
                            UserSelectedName = CurrentUser.Username;
                        }
                    }
                    else
                    {
                        MessageBox.Show(Resources.FormMinecraft_LoadUsers_Create_your_first_user_);
                        UserForm = new UserForm(this);
                        UserForm.ShowDialog(this);
                        return;
                    }
                }
                else
                {
                    if (lv_Users.FindItemWithText(aUsername) != null)
                    {
                        CurrentUser = model.Users.Include("Setting").FirstOrDefault(o => o.Username == aUsername);
                        if (CurrentUser != null)
                        {
                            var selectedItem = lv_Users.FindItemWithText(CurrentUser.Username);
                            selectedItem.Selected = true;
                            UserSelectedName = CurrentUser.Username;
                        }
                    }
                    else
                    {
                        MessageBox.Show(Resources.FormMinecraft_LoadUsers_User_load_error_);
                        return;
                    }
                }
            }
        }
        #endregion

        #region Method - LoadUserSettings
        public void LoadUserSettings()
        {
            //Load all of the users settings
            if (CurrentUser == null) return;
            
            lbl_User.Text = string.Format("Welcome {0}", CurrentUser.Username);
            txt_options.Text = CurrentUser.Setting.OptionsPath;
            numeric_backup.Value = CurrentUser.Setting.BackupCount;
            txt_workingDir.Text = CurrentUser.Setting.WorkingDirectory;
            txt_exec.Text = CurrentUser.Setting.TargetPath;
            txt_share.Text = CurrentUser.Setting.SharePath;
            chk_NoJava.Checked = CurrentUser.Setting.LaunchWithoutJava;
        }

        #endregion

        #region Method - DeleteUser
        /// <summary>
        /// Delete a user from the database
        /// </summary>
        /// <param name="aUser">User record to delete (recursive)</param>
        public void DeleteUser(App_Data.User aUser)
        {
            using (var model = new DataModel())
            {
                if (aUser == null) return;
                if (model.Users.All(o => o.Username != aUser.Username)) return;
                var user = model.Users.Include("Setting").FirstOrDefault(o => o.Username == aUser.Username);
                if (user == null) return;

                //Perform the delete
                model.DeleteObject(user.Setting);
                model.DeleteObject(user);
                model.SaveChanges();
            }
            LoadUserList();
            LoadUser();
            LoadUserSettings();
        }
        #endregion

        #region Private Method - Launch Minecraft
        /// <summary>
        /// Launch the Minecraft executable, monitor the process that was launched and wait for it to end.
        /// </summary>
        private void LaunchMinecraft()
        {
            //Toggle debugging.
            Debugging = false;

            // Show the log window for output
            ClearLogMessage();
            tabControl.SelectedTab = tabPage_logging;
            tabControl.Refresh();

            statusText.Text = Description(Statuses.Launching);
            statusStrip.Update();

            try
            {
                btn_launch.Text = Resources.FormMinecraft_LaunchMinecraft_Waiting_for_process_to_end_;

                if (!VerifyPaths()) return;

                string commandArgs = string.Empty;
                if (LaunchWithoutJava)
                {
                    commandArgs = TargetPath;
                }
                else
                {
                    var commandArgBuilder = new StringBuilder();
                    commandArgBuilder.Append(@" -Xmx1024M -Xms512M -cp");
                    commandArgBuilder.Append(string.Format(@" ""{0}""", TargetPath));
                    commandArgBuilder.Append(@" net.minecraft.LauncherFrame");
                    commandArgs = commandArgBuilder.ToString();
                }

                // Open the stream and write to it.
                using (FileStream fs = File.OpenWrite(WorkingDirectory + "\\options.txt"))
                {
                    Byte[] info =
                        new UTF8Encoding(true).GetBytes(OptionsFile);

                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                if (LaunchWithoutJava)
                {
                    ExecuteShellCommand(commandArgs, string.Empty);
                }
                else
                {
                    ExecuteShellCommand(JavaPath, commandArgs);
                }

                DialogResult result =
                    MessageBox.Show(Resources.FormMinecraft_LaunchMinecraft_Backup_save_files_,
                                    Resources.FormMinecraft_LaunchMinecraft_Backup,
                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (result)
                {
                    case DialogResult.Yes:
                        BackupSaveFiles();
                        Application.Exit();
                        break;
                    case DialogResult.No:
                        Application.Exit();
                        break;
                    default:
                        ResetUI();
                        if (!InErrorState)
                        {
                            // Show the launch window
                            tabControl.SelectedTab = tabPage_launcher;
                        }
                        tabControl.Refresh();
                        break;
                }
            }
            catch (Exception ex)
            {
                statusText.Text = Description(Statuses.Error);
                MessageBox.Show(ex.Message, Resources.FormMinecraft_LaunchMinecraft_Error_,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                btn_launch.Text = Resources.FormMinecraft_LaunchMinecraft_Launch_Minecraft_Now_;
            }
        }
        #endregion

        #region Private Method - VerifyPaths

        /// <summary>
        /// Verify that all of the paths that we have saved are valid before we try and use them.
        /// </summary>
        /// <param name="backupOnly"> </param>
        /// <returns>True if all passed validation, false if any were not valid.</returns>
        private bool VerifyPaths()
        {
            var verified = true;
            //If we are only running in backup only mode, then we don't care about the Java check.
            if (!LaunchWithoutJava)
            {
                if (!File.Exists(JavaPath))
                {
                    LogMessage(string.Format(@"Java was not found at: 
    {0}
", JavaPath));
                    verified = false;
                }
            }
            if (!File.Exists(TargetPath))
            {
                LogMessage(string.Format(@"TargetPath directory not found at: 
    {0}
", TargetPath));
                verified = false;
            }

            if (!Directory.Exists(SharePath))
            {
                LogMessage(string.Format(@"SharePath directory not found at: 
    {0}
", SharePath));
                verified = false;
            }

            if (!Directory.Exists(WorkingDirectory))
            {
                LogMessage(string.Format(@"WorkingDirectory directory not found at: 
    {0}
", WorkingDirectory));
                verified = false;
            }

            if (!verified)
                ResetUI();

            return verified;
        } 
        #endregion

        #region Private Method - ResetUI
        /// <summary>
        /// Reset the status bar and the launch minecraft button to be ready for launching.
        /// </summary>
        private void ResetUI()
        {
            statusText.Text = Description(Statuses.Ready);
            btn_launch.Text = Resources.FormMinecraft_LaunchMinecraft_Launch_Minecraft_Now_;
        } 
        #endregion

        #region Private Method - LogMessage
        /// <summary>
        /// Log a message to the logging tab, then scroll to that new entry
        /// </summary>
        /// <param name="message">Message to append to the</param>
        private void LogMessage(string message)
        {
            textBox_Logging.Text += message;
            textBox_Logging.ScrollToCaret();
        }
        #endregion

        #region Private Method - ClearLogMessage
        /// <summary>
        /// Clears the logging text box
        /// </summary>
        private void ClearLogMessage()
        {
            textBox_Logging.Text = string.Empty;
        } 
        #endregion

        #region Public Method - ExecuteShellCommand
        /// <summary>
        /// Execute a shell command
        /// </summary>
        /// <param name="command">File/Command to execute</param>
        /// <param name="commandArgs">Command line parameters to pass</param>  
        public void ExecuteShellCommand(string command, string commandArgs)
        {
            try
            {
                if (!File.Exists(command))
                {
                    // Log all data
                    LogMessage(string.Format("Command was not found at: {0}", command));
                    return;
                }

                var debugTextBuilder = new StringBuilder();
                debugTextBuilder.Append(@"Starting command line configuration:");
                debugTextBuilder.Append(_newline);

                using (var process = new Process())
                {
                    // invokes the cmd process specifying the command to be executed.
                    string cmdProcess = string.Format(CultureInfo.InvariantCulture, @"{0}\cmd.exe",
                                                      new object[] {Environment.SystemDirectory});

                    var arguments = new StringBuilder();

                    // pass any command line parameters for execution
                    if (!string.IsNullOrEmpty(commandArgs))
                    {
                        // pass executing file to cmd (Windows command interpreter) as a arguments
                        // /C tells cmd that we want it to execute the command that follows, and then exit.
                        arguments.Append(string.Format(CultureInfo.InvariantCulture,
                                                       @"{0} """"{1}""",
                                                       new object[] { Debugging ? " /K" : " /C", command }));

                        arguments.Append(string.Format(CultureInfo.InvariantCulture, " {0}",
                                                       new object[]
                                                           {
                                                               commandArgs,
                                                               CultureInfo.InvariantCulture
                                                           }));
                        arguments.Append(@"""");
                    }
                    else
                    {
                        // pass executing file to cmd (Windows command interpreter) as a arguments
                        // /C tells cmd that we want it to execute the command that follows, and then exit.
                        arguments.Append(string.Format(CultureInfo.InvariantCulture, @"{0} ""{1}""",
                                                       new object[] { Debugging ? " /K" : " /C", command }));
                    }

                    //Add debugging information to the log.
                    debugTextBuilder.Append(cmdProcess);
                    debugTextBuilder.Append(arguments.ToString());
                    debugTextBuilder.Append(_newline);

                    // Specifies a set of values used when starting a process.
                    var processStartInfo = new ProcessStartInfo(cmdProcess, arguments.ToString())
                                               {
                                                   // sets a value indicating not to start the process in a new window.
                                                   CreateNoWindow = Debugging,
                                                   // sets a value indicating not to use the operating system shell to start the process. 
                                                   UseShellExecute = false,
                                                   // sets a value that indicates the output/input/error of an application is written to the Process.
                                                   RedirectStandardOutput = true,
                                                   RedirectStandardInput = true,
                                                   RedirectStandardError = true
                                               };
                    process.StartInfo = processStartInfo;

                    // Starts a process resource and associates it with a Process component.
                    process.Start();

                    // Handle error from Process
                    var error = process.StandardError.ReadToEnd();
                    if (!string.IsNullOrEmpty(error))
                    {
                        debugTextBuilder.Append(@"Error:
");
                        debugTextBuilder.Append(error);
                        debugTextBuilder.Append(_newline);
                        InErrorState = true;
                    }

                    // Handle output from Process
                    var output = process.StandardOutput.ReadToEnd();
                    if (!string.IsNullOrEmpty(output))
                    {
                        debugTextBuilder.Append(@"Output:
");
                        debugTextBuilder.Append(output);
                        debugTextBuilder.Append(_newline);
                    }

                    // Log all data
                    LogMessage(debugTextBuilder.ToString());
                }
            }
            catch (Win32Exception win32Exception)
            {
                // Error
                throw new Exception(string.Format(@"Win32 Exception caught in process: {0}", win32Exception));
            }
            catch (Exception exception)
            {
                // Error
                throw new Exception(string.Format(@"Exception caught in process: {0}", exception));
            }
        }

        #endregion

        #region Private Method - BackupSaveFiles
        /// <summary>
        /// Backup the saved files.
        /// </summary>
        private void BackupSaveFiles()
        {
            statusText.Text = Description(Statuses.Saving);
            statusStrip.Update();

            progressBar.Visible = true;
            progressBar.Value = 10;
            statusStrip.Update();

            // Initialize the directories we will be working with.
            if (!VerifyPaths()) return;
            var workingDir = new DirectoryInfo(WorkingDirectory);
            var shareDir = new DirectoryInfo(SharePath);

            // This method assumes that the application has discovery permissions
            // for all folders under the specified path.
            DirectoryInfo[] directoryList = workingDir.GetDirectories("*.*", SearchOption.TopDirectoryOnly);

            IEnumerable<DirectoryInfo> saves = from file in directoryList
                                               where file.Name.ToLower() == "saves"
                                               select file;

            // ReSharper disable PossibleMultipleEnumeration
            if (saves.Count() == 1)
            {
                DirectoryInfo[] saveList = saves.First().GetDirectories("*.*", SearchOption.TopDirectoryOnly);
                // ReSharper restore PossibleMultipleEnumeration

                using (var zip = new ZipFile())
                {
                    statusText.Text = Description(Statuses.AddingFiles);
                    statusStrip.Update();
                    zip.AddProgress += ZipAddProgress;
                    zip.SaveProgress += ZipSaveProgress;

                    foreach (DirectoryInfo info in saveList)
                    {
                        zip.AddDirectory(info.FullName, info.Name);
                    }

                    statusText.Text = Description(Statuses.CreatingArchive);
                    progressBar.Step = 1;
                    progressBar.Value = 0;
                    progressBar.Maximum = zip.Count;
                    statusStrip.Update();

                    zip.Save(string.Format(@"{0}\Minecraft_Backup-{1:yyyy-MM-dd_Hmm}.zip", SharePath,
                                           DateTime.Now));
                }

                // Remove older backups when the number of backups exceed the number we have specified.
                IEnumerable<FileInfo> currentSaves = shareDir.GetFiles("Minecraft_Backup*.zip",
                                                                       SearchOption.TopDirectoryOnly);
                if (numeric_backup.Value > 0 && currentSaves.Count() > numeric_backup.Value)
                {
                    statusText.Text = Description(Statuses.CleaningUpFolder);
                    progressBar.Maximum = 100;
                    progressBar.Step = 10;
                    progressBar.Value = 50;
                    statusStrip.Update();

                    int removeNum = currentSaves.Count() - (int) numeric_backup.Value;
                    currentSaves = currentSaves.OrderBy(fh => fh.CreationTime);
                    IEnumerable<FileInfo> oldSaves = currentSaves.Take(removeNum);
                    foreach (FileInfo oldSave in oldSaves)
                    {
                        progressBar.PerformStep();
                        statusStrip.Update();

                        oldSave.Delete();
                    }

                    progressBar.Value = 100;
                    statusText.Text = Description(Statuses.BackupComplete);
                    progressBar.Visible = false;
                    statusStrip.Update();
                }
            }
            else
            {
                throw new Exception(
                    @"Saves not found in working directory.

The save file location must be at the directory that contains
the Minecraft ""saves"" folder.");
            }
        }
        #endregion

        private void BtnUserSizeClick(object sender, EventArgs e)
        {
            if (sender == null || !(sender is Button)) return;
            var button = sender as Button;
            if (button.Text == Resources.FormMinecraft_btn_UserSize_Click_Lg)
            {
                button.Text = Resources.FormMinecraft_btn_UserSize_Click_Sm;
                lv_Users.View = View.LargeIcon;
            }
            else
            {
                button.Text = Resources.FormMinecraft_btn_UserSize_Click_Lg;
                lv_Users.View = View.SmallIcon;
            }
        }

        private void BtnNewUserClick(object sender, EventArgs e)
        {
            UserForm = new UserForm(this);
            UserForm.ShowDialog(this);
        }

        private void BtnCopyUserClick(object sender, EventArgs e)
        {
            App_Data.User newUser = CurrentUser.Copy();
            newUser.Username = String.Empty;
            UserForm = new UserForm(this, newUser);
            UserForm.ShowDialog(this);
        }

        private void BtnEditUserClick(object sender, EventArgs e)
        {
            UserForm = new UserForm(this, CurrentUser);
            UserForm.ShowDialog(this);
        }

        private void BtnDeleteUserClick(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                String.Format("Are you sure you want to delete {0}", CurrentUser.Username), 
                Resources.FormMinecraft_BtnDeleteUserClick_Warning_, MessageBoxButtons.OKCancel) 
                == DialogResult.OK)
            {
                DeleteUser(CurrentUser);
            }

        }

        private void ChkNoJavaClick(object sender, EventArgs e)
        {
            LaunchWithoutJava = ((CheckBox) sender).Checked;
        }

        private void LvUsersSelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrentUser == null) return;
            if (((ListView)sender).SelectedItems.Count == 1)
            {
                var item = ((ListView) sender).SelectedItems[0];
                if (CurrentUser.Username != item.Text)
                {
                    LoadUserList();
                    LoadUser(item.Text);
                    LoadUserSettings();
                }
                LvUsersLeave(new object(), new EventArgs());
            }
        }

        private void LvUsersMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (CurrentUser == null) return;
            if (((ListView)sender).SelectedItems.Count == 1)
            {
                var item = ((ListView)sender).SelectedItems[0];
                LoadUserList();
                LoadUser(item.Text);
                LoadUserSettings();
                LvUsersLeave(new object(), new EventArgs());
            }
            LaunchMinecraft();
        }

        private void LvUsersLeave(object sender, EventArgs e)
        {
            if (CurrentUser == null) return;
            var selectedItem = lv_Users.FindItemWithText(CurrentUser.Username);
            if (selectedItem != null)
            {
                selectedItem.EnsureVisible();
                selectedItem.BackColor = Color.LightGray;
            }
        }

        // This method accepts two strings the represent two files to 
        // compare. A return value of 0 indicates that the contents of the files
        // are the same. A return value of any other value indicates that the 
        // files are not the same.
        private bool FileCompare(string a_file, string b_file, bool byteCompare = true)
        {
            try
            {
                // Determine if the same file was referenced two times.
                if (a_file == b_file)
                {
                    // Return true to indicate that the files are the same.
                    return true;
                }

                //Save files for comparison
                FileInfo[] files1 = null;
                FileInfo[] files2 = null;

                var fileInfo1 = new FileInfo(a_file);
                var fileInfo2 = new FileInfo(b_file);

                if (fileInfo1.Attributes.HasFlag(FileAttributes.Directory) &&
                    fileInfo2.Attributes.HasFlag(FileAttributes.Directory))
                {
                    WalkDirectoryTree(new DirectoryInfo(a_file), ref files1);
                    WalkDirectoryTree(new DirectoryInfo(b_file), ref files2);
                }
                else
                {
                    files1 = new[] {fileInfo1};
                    files2 = new[] {fileInfo2};
                }

                MessageBox.Show("Number of files" + files1.Length + " \\ " + files2.Length);
                if (files1.Length != files2.Length)
                    return false;

                for (var i = 0; i < files1.Length; i++)
                {
                    // Check to see if the files are the same size
                    if (files1[i].Length != files2[i].Length)
                        return false;

                    if (files1[i].LastWriteTime != files2[i].LastWriteTime)
                        return false;

                    if (byteCompare)
                    {
                        // Open the two files.
                        var fs1 = new FileStream(files1[i].FullName, FileMode.Open);
                        var fs2 = new FileStream(files2[i].FullName, FileMode.Open);

                        int file1Byte;
                        int file2Byte;
                        long seekJump = fs1.Length/5;

                        // Read and compare a byte from each file until either a
                        // non-matching set of bytes is found or until the end of
                        // file1 is reached.
                        do
                        {
                            // Read one byte from each file.
                            file1Byte = fs1.ReadByte();
                            file2Byte = fs2.ReadByte();
                            fs1.Seek(seekJump, SeekOrigin.Current);
                            fs2.Seek(seekJump, SeekOrigin.Current);
                        }
                        while ((file1Byte == file2Byte) && (file1Byte != -1));

                        if ((file1Byte - file2Byte) != 0)
                            return false;


                        //byte[] byteArray1 = File.ReadAllBytes(files1[i].FullName);
                        //byte[] byteArray2 = File.ReadAllBytes(files2[i].FullName);

                        //// Check to see if the files are the same size
                        //if (byteArray1.Length != byteArray2.Length)
                        //    return false;

                        //for (var j = 0; j < byteArray1.Length; j++)
                        //{
                        //    if (byteArray1[j] != byteArray2[j])
                        //        return false;
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("There was an error when comparing files, {0}\n{1}",
                                              ex.GetType(),
                                              ex.Message));
            }
            return true;
        }

        static void WalkDirectoryTree(DirectoryInfo root, ref FileInfo[] files)
        {
            if (files == null)
                files = new FileInfo[0];

            // First, process all the files directly under this folder 
            try
            {
                files = files.ToList().Concat(root.GetFiles("*.*")).ToArray();
            }
            // This is thrown if even one of the files requires permissions greater 
            // than the application provides. 
            catch (UnauthorizedAccessException e)
            {
                // This code just writes out the message and continues to recurse. 
                // You may decide to do something different here. For example, you 
                // can try to elevate your privileges and access the file again.
                //MessageBox.Show(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                MessageBox.Show(e.Message);
            }

            if (files != null)
            {
                //foreach (FileInfo fi in files)
                //{
                //    // In this example, we only access the existing FileInfo object. If we 
                //    // want to open, delete or modify the file, then 
                //    // a try-catch block is required here to handle the case 
                //    // where the file has been deleted since the call to TraverseTree().
                //    Console.WriteLine(fi.FullName);
                //}

                // Now find all the subdirectories under this directory.
                DirectoryInfo[] subDirs = root.GetDirectories();

                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    // Resursive call for each subdirectory.
                    WalkDirectoryTree(dirInfo, ref files);
                }
            }
        }
    }
} ;