using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Ssepan.Utility;

namespace ThemeEditorLibrary
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ThemeCategory :
        INotifyPropertyChanged
    {
        #region Constructors
        public ThemeCategory()
        {
            this.ColorRecords = new List<ColorRecord>();
        }
        #endregion Constructors

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(String propertyName)
        {
            try
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }

            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }
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
        private List<ColorRecord> _ColorRecords = default(List<ColorRecord>);
        public List<ColorRecord> ColorRecords
        {
            get { return _ColorRecords; }
            set
            {
                _ColorRecords = value;
                OnPropertyChanged("ColorRecords");
            }
        }
        private CategoryHeader _Header = default(CategoryHeader);
        public CategoryHeader Header
        {
            get { return _Header; }
            set
            {
                _Header = value;
                OnPropertyChanged("Header");
            }
        }
        #endregion Properties

        #region Methods
        /// <summary>
        /// Extract category struct from theme in registry bytes.
        /// Note: Color records are not Alphabetized, but the list that is bound to the UI 
        ///  will be sorted during binding. This will not change the underlying list.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static ThemeCategory UnpackColorCategory
        (
            Byte[] bytes
        )
        {
            ThemeCategory category = new ThemeCategory();

            using (MemoryStream memoryStream = new MemoryStream(bytes))
            using (BinaryReader binaryReader = new BinaryReader(memoryStream))
            {
                category.Header = memoryStream.ReadStruct<CategoryHeader>();

                for (Int32 i = 0; i < category.Header.ColorCount; i++)
                {
                    ColorRecord colorRecord = ColorRecord.UnpackColorRecord(binaryReader);
                    if (colorRecord != null)
                    {
                        category.ColorRecords.Add(colorRecord);
                    }
                }
                //var alignCheck = binaryReader.ReadInt32();
                //Debug.Assert( alignCheck == category.Header.CategoryDataSize, "The header (and color reads) alignment is not correct." );
            }
            return category;
        }
        #endregion Methods

    }
}