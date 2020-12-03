using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Ssepan.Application;
using Ssepan.Utility;

namespace ThemeEditorLibrary
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ThemeEditorModel :
        ModelBase
    {
        #region Declarations
        private const String REGISTRY_THEMES_PATHMASK = @"Software\Microsoft\{0}\{1}_Config\Themes";

        //public const String APPLICATIONNAME = "Theme Editor (Alpha)";
        public const String MASK_ARGB = "({0}) ({1}, {2}, {3})";
        public const String DIALOGMESSAGE = "This will reset your Visual Studio theme back to stock. Are you sure?";
        public const String DIALOGTITLE_RESET = "Reset Theme";
        public const String DIALOGTITLE_BACKUP = "Save Theme to ...";

        /// <summary>
        /// Test-mode -- not implemented -- example of command line switch.
        /// </summary>
        public static Boolean TestDataMode = default(Boolean);
        #endregion Declarations

        #region Constructors
        public ThemeEditorModel()
        {
            if (SettingsController<ThemeEditorSettings>.Settings == null)
            {
                SettingsController<ThemeEditorSettings>.New();
            }
            Debug.Assert(SettingsController<ThemeEditorSettings>.Settings != null, "SettingsController<ThemeEditorSettings>.Settings != null");
        }

        //public ThemeEditorModel
        //(
        //    Int32 someInt,
        //    Boolean someBoolean,
        //    String someString
        //) :
        //    this()
        //{
        //    SomeInt = someInt;
        //    SomeBoolean = someBoolean;
        //    SomeString = someString;
        //}
        #endregion Constructors

        #region IEquatable<IModel>
        /// <summary>
        /// Compare property values of two specified Model objects.
        /// </summary>
        /// <param name="anotherSettings"></param>
        /// <returns></returns>
        public override Boolean Equals(IModel other)
        {
            Boolean returnValue = default(Boolean);
            ThemeEditorModel otherModel = default(ThemeEditorModel);

            try
            {
                otherModel = other as ThemeEditorModel;

                if (this == otherModel)
                {
                    returnValue = true;
                }
                else
                {
                    if (!base.Equals(other))
                    {
                        returnValue = false;
                    }
                    //else if (this.SomeInt != otherModel.SomeInt)
                    //{
                    //    returnValue = false;
                    //}
                    //else if (this.SomeBoolean != otherModel.SomeBoolean)
                    //{
                    //    returnValue = false;
                    //}
                    //else if (this.SomeString != otherModel.SomeString)
                    //{
                    //    returnValue = false;
                    //}
                    else
                    {
                        returnValue = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }

            return returnValue;
        }
        #endregion IEquatable<IModel>

        #region Properties
        private List<ThemeInfo> _Themes = default(List<ThemeInfo>);
        /// <summary>
        /// In-memory respository of Themes, Categories, and ColorRecords data.
        /// </summary>
        public List<ThemeInfo> Themes
        {
            get { return _Themes; }
            set
            {
                _Themes = value;
                OnPropertyChanged("Themes");
            }
        }

        private VisualStudioEdition _Edition = default(VisualStudioEdition);
        /// <summary>
        /// Affects Title and RegistryPath.
        /// </summary>
        public VisualStudioEdition Edition
        {
            get { return _Edition; }
            set
            {
                _Edition = value;
                OnPropertyChanged("Edition");

                RegistryPath = BuildThemesRegistryPath();
            }
        }

        private VisualStudioVersion _Version = default(VisualStudioVersion);
        /// <summary>
        /// Affects Title and RegistryPath.
        /// </summary>
        public VisualStudioVersion Version
        {
            get { return _Version; }
            set
            {
                _Version = value;
                OnPropertyChanged("Version");

                RegistryPath = BuildThemesRegistryPath();
            }
        }

        private String _RegistryPath = default(String);
        /// <summary>
        /// Affected by Edition and Version.
        /// Affects Theme.
        /// </summary>
        public String RegistryPath
        {
            get { return _RegistryPath; }
            set 
            {
                _RegistryPath = value;
                OnPropertyChanged("RegistryPath");
            }
        }

        private ThemeInfo _Theme = default(ThemeInfo);
        /// <summary>
        /// Selected Theme.
        /// Affected by RegistryPath.
        /// Affects Category.
        /// </summary>
        public ThemeInfo Theme
        {
            get { return _Theme; }
            set
            {
                _Theme = value;
                OnPropertyChanged("Theme");
            }
        }

        private ThemeCategory _Category = default(ThemeCategory);
        /// <summary>
        /// Selected Category.
        /// Affected by Theme.
        /// Affects ColorRecord.
        /// </summary>
        public ThemeCategory Category
        {
            get { return _Category; }
            set
            {
                _Category = value;
                OnPropertyChanged("Category");
            }
        }

        private ColorRecord _ColorRecord = default(ColorRecord);
        /// <summary>
        /// Selected ColorRecord.
        /// Affected by Category.
        /// </summary>
        public ColorRecord ColorRecord
        {
            get { return _ColorRecord; }
            set
            {
                _ColorRecord = value;
                OnPropertyChanged("ColorRecord");
            }
        }
        #endregion Properties

        #region Methods

        /// <summary>
        /// Returns a registry path for a given edition and version.
        /// </summary>
        /// <returns></returns>
        public String BuildThemesRegistryPath
        (
        )
        {
            String returnValue = default(String);
            try
            {
                returnValue = 
                    String.Format
                    (
                        REGISTRY_THEMES_PATHMASK,
                        (Edition == null ? null : Edition.EditionKey),
                        (Version == null ? null : Version.VersionNumber)
                    );
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
            return returnValue;
        }

        /// <summary>
        /// Returns a formatted display string for the given Color's definition.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public String GetColorDisplay
        (
            Color color
        )
        {
            String returnValue = default(String);
            try
            {
                returnValue = String.Format(MASK_ARGB, color.A, color.R, color.G, color.B);
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
            return returnValue;
        }

        /// <summary>
        /// Save color to model and regsitry.
        /// </summary>
        /// <param name="foregroundColor"></param>
        /// <param name="backgroundColor"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public Boolean SaveColor
        (
            Color? foregroundColor,
            Color? backgroundColor,
            ref String errorMessage
        )
        {
            Boolean returnValue = default(Boolean);
            try
            {
                ColorRecord.InjectColor(foregroundColor, backgroundColor, this);

                ColorRecord.Foreground = foregroundColor;
                ColorRecord.Background = backgroundColor;

                returnValue = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;

                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
            return returnValue;
        }
        #endregion Methods

    }
}
