using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Win32;
using Ssepan.Application;
using Ssepan.Application.MVC;
using Ssepan.Utility;

namespace ThemeEditorLibrary
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ThemeInfo :
        SettingsComponentBase//,
        //INotifyPropertyChanged
    {
        #region Declarations
        private const String FORMAT_DATESTAMP = "yyyy-MM-dd.";
        //0: Edition, 1: Year, 2:Theme Name, 3: "Stock", 4:Extension 
        private const String MASK_FILENAME_IMPORT = "{0}{1}.{2}.Theme.{3}{4}";
        //0: Edition, 1: Year, 2:Theme Name, 3:Datestamp, 4: Timestamp (time of day), 5:Extension 
        private const String MASK_FILENAME_EXPORT = "{0}{1}.{2}.Theme.{3}{4}{5}";
        private const String COMMAND_IMPORT = "regedit.exe";
        private const String COMMAND_EXPORT = "registryKey.exe";
        //0:registry path, 1:filePath
        private const String MASK_ARGUMENTS_EXPORT = "EXPORT \"{0}\" \"{1}\"";

        public const String EXTENSION_REGISTRYKEY = ".registryKey";
        #endregion Declarations
        
        #region Constructors
        public ThemeInfo()
        {
            this.Categories = new List<ThemeCategory>();
        }
        #endregion Constructors

        #region INotifyPropertyChanged Members
        //public event PropertyChangedEventHandler PropertyChanged;
        //protected void OnPropertyChanged(String propertyName)
        //{
        //    try
        //    {
        //        if (this.PropertyChanged != null)
        //        {
        //            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
        //        throw;
        //    }
        //}
        #endregion

        #region Properties
        private String _Name = default(String);
        public String Name
        {
            get { return _Name; }
            set 
            { 
                _Name = value;
                OnPropertyChanged("Name");
            }
        }

        private Guid _Guid = default(Guid);
        public Guid Guid
        {
            get { return _Guid; }
            set 
            { 
                _Guid = value;
                OnPropertyChanged("Guid");
            }
        }

        private List<ThemeCategory> _Categories = default(List<ThemeCategory>);
        public List<ThemeCategory> Categories
        {
            get { return _Categories; }
            set 
            { 
                _Categories = value;
                OnPropertyChanged("Categories");
            }
        }
        #endregion Properties

        #region Methods
        /// <summary>
        /// Extract theme keys from Themes key in registry.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static List<ThemeInfo> ReadThemes
        (
            ThemeEditorModel model,
            ref String errorMessage
        )
        {
            List<ThemeInfo> returnValue = default(List<ThemeInfo>);

            try
            {
                RegistryKey themesRegistryKey = Registry.CurrentUser.OpenSubKey(model.RegistryPath);
                if (themesRegistryKey == null)
                {
                    throw new ApplicationException(String.Format("Error: Could not load registry path: {0}", model.RegistryPath));
                }

                String[] themesGuids = themesRegistryKey.GetSubKeyNames();

                if (!themesGuids.Any())
                {
                    throw new ApplicationException("Could not find any themes.");
                }

                returnValue = new List<ThemeInfo>();

                foreach (String guidString in themesGuids)
                {
                    RegistryKey themeRegistryKey = themesRegistryKey.OpenSubKey(guidString);

                    String themeName = themeRegistryKey.GetValue(String.Empty).ToString();

                    ThemeInfo theme =
                        new ThemeInfo()
                        {
                            Name = themeName,
                            Guid = Guid.Parse(guidString)
                        };
                    returnValue.Add(theme);

                    foreach (String categoryName in themeRegistryKey.GetSubKeyNames())
                    {
                        Byte[] categoryBytes = themeRegistryKey.OpenSubKey(categoryName).GetValue("Data") as Byte[];
                        if (categoryBytes == null)
                        {
                            continue;
                        }

                        ThemeCategory category = ThemeCategory.UnpackColorCategory(categoryBytes);
                        category.Name = categoryName;
                        theme.Categories.Add(category);
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;

                Log.Write(ex, MethodBase.GetCurrentMethod(), System.Diagnostics.EventLogEntryType.Error);
            }

            return returnValue;
        }
        
        /// <summary>
        /// Save theme as registry export.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Boolean BackupTheme
        (
            String filePath,
            ThemeEditorModel model
        )
        {
            Boolean returnValue = default(Boolean);
            String args = default(String);
            ProcessStartInfo processStartInfo = default(ProcessStartInfo);

            try
            {
                args =
                    String.Format
                    (
                        MASK_ARGUMENTS_EXPORT,
                        Path.Combine(Registry.CurrentUser.Name, model.RegistryPath, model.Theme.Guid.ToString("B")),
                        filePath
                    );

                processStartInfo = new ProcessStartInfo(COMMAND_EXPORT, args) { CreateNoWindow = true, WindowStyle = ProcessWindowStyle.Hidden };
                Process.Start(processStartInfo).WaitForExit();

                returnValue = true;
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
            return returnValue;
        }

        /// <summary>
        /// Restore theme from registry export.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static Boolean ResetTheme
        (
            String filePath,
            ref String errorMessage
        )
        {
            Boolean returnValue = default(Boolean);
            try
            {
                //load theme from file directly into registry
                Process.Start(COMMAND_IMPORT, filePath).WaitForExit();

                returnValue = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;

                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
            return returnValue;
        }

        /// <summary>
        /// Create filename for export, based on version and year.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static String BuildExportFilename
        (
            ThemeEditorModel model
        )
        {
            String returnValue = default(String);
            
            try
            {
                returnValue =
                    String.Format
                    (
                        MASK_FILENAME_EXPORT,
                        model.Edition.EditionKey,
                        model.Version.VersionYear,
                        model.Theme.Name,
                        DateTime.Now.ToString(FORMAT_DATESTAMP),
                        (Int32)DateTime.Now.TimeOfDay.TotalSeconds,
                        EXTENSION_REGISTRYKEY
                    );
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
            return returnValue;
        }

        /// <summary>
        /// Create filename for import, based on version and year.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static String BuildImportFilename
        (
            ThemeEditorModel model
        )
        {
            String returnValue = default(String);
            
            try
            {
                returnValue =
                    String.Format
                    (
                        MASK_FILENAME_IMPORT,
                        model.Version.VersionYear,
                        model.Edition.EditionKey,
                        model.Theme.Name,
                        "Stock",
                        EXTENSION_REGISTRYKEY
                    );
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
            return returnValue;
        }
        #endregion Methods
    }
}