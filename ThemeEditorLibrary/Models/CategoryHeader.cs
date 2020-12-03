using System;
using System.ComponentModel;
using System.Diagnostics;
using Ssepan.Utility;

namespace ThemeEditorLibrary
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public struct CategoryHeader 
    {
        #region Properties
        //Note:Order is significant - do not reorder!
        public Int32 CategoryDataSize { get; set; }
        public Int32 VisualStudioVersion { get; set; }
        public Int32 Unknown { get; set; }
        public Guid CategoryGuid { get; set; }
        public Int32 ColorCount { get; set; }
        #endregion Properties
    }
}