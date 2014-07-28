using System;
using System.IO;
using System.Linq;
using System.Data.Objects;
using System.Linq.Expressions;
using MinecraftManagerPlus.App_Data;

namespace MinecraftManagerPlus.Utility
{
    public static class ExtensionMethods
    {
        #region Private Members
        // ReSharper disable ConvertToConstant.Local
        private static readonly string Username = "Default";

        private static readonly int ImageIndex = -1;

        private static readonly string OptionsFile =
            @"
music:1.0
sound:1.0
invertYMouse:false
mouseSensitivity:0.5
fov:0.0
gamma:0.0
viewDistance:0
guiScale:0
bobView:true
anaglyph3d:false
advancedOpengl:false
fpsLimit:1
difficulty:2
fancyGraphics:true
ao:true
skin:Default
lastServer:
key_key.attack:-100
key_key.use:-99
key_key.forward:17
key_key.left:30
key_key.back:31
key_key.right:32
key_key.jump:57
key_key.sneak:42
key_key.drop:16
key_key.inventory:18
key_key.chat:20
key_key.playerlist:15
key_key.pickItem:-98

";

        private static readonly string OptionsPath = string.Format(@"{0}\.minecraft\options.txt",
                                                             Environment.GetFolderPath(
                                                                 Environment.SpecialFolder.ApplicationData));

        private static readonly int BackupCount = 5;

        private static readonly string Java = string.Format(@"{0}\Java\jre6\bin\java.exe", Environment.GetFolderPath(
                                                                Environment.SpecialFolder.
                                                                    ProgramFiles));

        private static readonly string TargetPath = string.Format(@"{0}\Games\Minecraft\Minecraft.exe",
                                                            FindDropBoxPath());

        private static readonly string SharePath = string.Format(@"{0}\Games\Minecraft\Saves\",
                                                           FindDropBoxPath());

        private static readonly string WorkingDirectory = string.Format(@"{0}\.minecraft",
                                                                  Environment.GetFolderPath(
                                                                      Environment.SpecialFolder.
                                                                          ApplicationData));

        private static readonly bool Debugging = false;

        private static readonly bool LaunchWithoutJava = false;
        // ReSharper restore ConvertToConstant.Local
        #endregion
        
        #region Method - FindDropBoxPath
        public static string FindDropBoxPath()
        {
            string folderPath = null;
            var dbPath = System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Dropbox\host.db");

            if (File.Exists(dbPath))
            {
                string[] lines = System.IO.File.ReadAllLines(dbPath);
                byte[] dbBase64Text = Convert.FromBase64String(lines[1]);
                folderPath = System.Text.Encoding.ASCII.GetString(dbBase64Text);
            }
            return (string.IsNullOrEmpty(folderPath) ? @"C:" : folderPath);
        }
        #endregion

        /// <summary>
        /// Current Entity Framework version does not support identity keys using SQL Compact.
        /// This is a work around to detect the current value of the ID column for the table and increment it.
        /// http://enigmadomain.wordpress.com/2010/01/06/sql-compact-identity-columns-and-entity-framework/
        /// </summary>
        /// <typeparam name="TSource">Source Object</typeparam>
        /// <typeparam name="TResult">Result Object</typeparam>
        /// <param name="table">Table</param>
        /// <param name="selector">Identity Column</param>
        /// <returns>1 + the greatest value in the column</returns>
        /// <example>
        /// using (goBRdatabase db = new goBRdatabase())
        ///{
        ///    db.Categories.AddObject(new Category()
        ///                            {
        ///                                categoryID = db.Categories.NextId(f => f.categoryID),
        ///                                description = "High"
        ///                            });
        ///    int changes = db.SaveChanges();
        ///}
        /// </example>
        public static TResult NextId<TSource, TResult>(this ObjectSet<TSource> table, Expression<Func<TSource, TResult>> selector)
            where TSource : class
        {
            TResult lastId = table.Any() ? table.Max(selector) : default(TResult);

            if (lastId is int)
            {
                lastId = (TResult)(object)(((int)(object)lastId) + 1);
            }

            return lastId;
        }

        public static App_Data.User LoadDefaults(this App_Data.User user)
        {
            //Create a new user
            user.Id = Guid.NewGuid();
            user.Username = ExtensionMethods.Username;
            user.ImageIndex = ExtensionMethods.ImageIndex;

            //Create settings for that user
            var settings = new Settings();
            settings.Id = Guid.NewGuid();
            settings.BackupCount = ExtensionMethods.BackupCount;
            settings.Debugging = ExtensionMethods.Debugging;
            settings.JavaPath = ExtensionMethods.Java;
            settings.OptionsFile = ExtensionMethods.OptionsFile;
            settings.OptionsPath = ExtensionMethods.OptionsPath;
            settings.SharePath = ExtensionMethods.SharePath;
            settings.TargetPath = ExtensionMethods.TargetPath;
            settings.WorkingDirectory = ExtensionMethods.WorkingDirectory;
            settings.LaunchWithoutJava = ExtensionMethods.LaunchWithoutJava;

            user.Setting = settings;

            return user;
        }

        public static App_Data.User Copy(this App_Data.User aUseruser)
        {
            var newUser = new App_Data.User();
            //Create a new user
            newUser.Id = Guid.NewGuid();
            newUser.Username = aUseruser.Username;
            newUser.ImageIndex = aUseruser.ImageIndex;

            //Create settings for that user
            var settings = new Settings();
            settings.Id = Guid.NewGuid();
            settings.BackupCount = aUseruser.Setting.BackupCount;
            settings.Debugging = aUseruser.Setting.Debugging;
            settings.JavaPath = aUseruser.Setting.JavaPath;
            settings.OptionsFile = aUseruser.Setting.OptionsFile;
            settings.OptionsPath = aUseruser.Setting.OptionsPath;
            settings.SharePath = aUseruser.Setting.SharePath;
            settings.TargetPath = aUseruser.Setting.TargetPath;
            settings.WorkingDirectory = aUseruser.Setting.WorkingDirectory;
            settings.LaunchWithoutJava = aUseruser.Setting.LaunchWithoutJava;

            newUser.Setting = settings;

            return newUser;
        }
    }

}
