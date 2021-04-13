using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ssepan.Application;
using Ssepan.Application.MVC;

namespace ThemeEditorLibrary
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class VisualStudioVersion :
        SettingsComponentBase
    {
        #region Declarations
        public const String VISUALSTUDIO_VERSIONNUMBER_2012 = @"11.0";
        public const String VISUALSTUDIO_VERSIONNUMBER_2013 = @"12.0";

        public const String VISUALSTUDIO_VERSIONYEAR_2012 = @"2012";
        public const String VISUALSTUDIO_VERSIONYEAR_2013 = @"2013";
        #endregion Declarations

        #region Constructors
        static VisualStudioVersion()
        {
            VisualStudioVersions = new List<VisualStudioVersion>
            {
                new VisualStudioVersion() 
                { 
                    VersionNumber = VISUALSTUDIO_VERSIONNUMBER_2012,
                    VersionYear = VISUALSTUDIO_VERSIONYEAR_2012
                },
                new VisualStudioVersion() 
                { 
                    VersionNumber = VISUALSTUDIO_VERSIONNUMBER_2013,
                    VersionYear = VISUALSTUDIO_VERSIONYEAR_2013
                }
            };
        }
        #endregion Constructors

        #region Properties
        private String _VersionNumber = default(String);
        public String VersionNumber
        {
            get { return _VersionNumber; }
            set { _VersionNumber = value; }
        }

        private String _VersionYear = default(String);
        public String VersionYear
        {
            get { return _VersionYear; }
            set { _VersionYear = value; }
        }

        private static List<VisualStudioVersion> _VisualStudioVersions = default(List<VisualStudioVersion>);
        public static List<VisualStudioVersion> VisualStudioVersions
        {
            get { return _VisualStudioVersions; }
            set { _VisualStudioVersions = value; }
        }
        #endregion Properties
    }
}
