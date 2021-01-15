using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ssepan.Application;

namespace ThemeEditorLibrary
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class VisualStudioEdition :
        SettingsComponentBase
    {
        #region Declarations
        public const String REGISTRY_THEMES_EDITIONKEY_OTHER = @"VisualStudio";
        public const String REGISTRY_THEMES_EDITIONKEY_EXPRESSWIN = @"VSWinExpress";
        public const String REGISTRY_THEMES_EDITIONKEY_EXPRESSDESKTOP = @"WDExpress";
        public const String REGISTRY_THEMES_EDITIONKEY_EXPRESSWEB = @"VWDExpress";

        public const String REGISTRY_THEMES_EDITIONNAME_OTHER = @"Visual Studio";
        public const String REGISTRY_THEMES_EDITIONNAME_EXPRESSWIN = @"Visual Studio Express Windows";
        public const String REGISTRY_THEMES_EDITIONNAME_EXPRESSDESKTOP = @"Visual Studio Express Desktop";
        public const String REGISTRY_THEMES_EDITIONNAME_EXPRESSWEB = @"Visual Studio Express Web";
        #endregion Declarations

        #region Constructors
        static VisualStudioEdition()
        {
            VisualStudioEditions = new List<VisualStudioEdition>
            {
                new VisualStudioEdition() 
                { 
                    EditionKey = REGISTRY_THEMES_EDITIONKEY_OTHER,
                    EditionName = REGISTRY_THEMES_EDITIONNAME_OTHER
                },
                new VisualStudioEdition() 
                { 
                    EditionKey = REGISTRY_THEMES_EDITIONKEY_EXPRESSWIN,
                    EditionName = REGISTRY_THEMES_EDITIONNAME_EXPRESSWIN
                },
                new VisualStudioEdition() 
                { 
                    EditionKey = REGISTRY_THEMES_EDITIONKEY_EXPRESSDESKTOP,
                    EditionName = REGISTRY_THEMES_EDITIONNAME_EXPRESSDESKTOP
                },
                new VisualStudioEdition() 
                { 
                    EditionKey = REGISTRY_THEMES_EDITIONKEY_EXPRESSWEB,
                    EditionName = REGISTRY_THEMES_EDITIONNAME_EXPRESSWEB
                }
            };
        }
        #endregion Constructors

        #region Properties
        private String _EditionKey = default(String);
        public String EditionKey
        {
            get { return _EditionKey; }
            set { _EditionKey = value; }
        }

        private String _EditionName = default(String);
        public String EditionName
        {
            get { return _EditionName; }
            set { _EditionName = value; }
        }

        private static List<VisualStudioEdition> _VisualStudioEditions = default(List<VisualStudioEdition>);
        public static List<VisualStudioEdition> VisualStudioEditions
        {
            get { return _VisualStudioEditions; }
            set { _VisualStudioEditions = value; }
        }
        #endregion Properties
    }
}
