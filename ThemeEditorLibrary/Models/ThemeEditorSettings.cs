using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
//using System.Threading.Tasks;
using System.Xml.Serialization;
using Ssepan.Application;
using Ssepan.Utility;

namespace ThemeEditorLibrary
{
    /// <summary>
    /// persisted settings; run-time model depends on this
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class ThemeEditorSettings :
        SettingsBase
    {
        #region Declarations
        private const String FILE_TYPE_EXTENSION = "themeeditorsettings";
        private const String FILE_TYPE_NAME = "themeeditorsettings";
        private const String FILE_TYPE_DESCRIPTION = "ThemeEditor Settings File";
        #endregion Declarations

        #region Constructors
        public ThemeEditorSettings()
        {
            FileTypeExtension = FILE_TYPE_EXTENSION;
            FileTypeName = FILE_TYPE_NAME;
            FileTypeDescription = FILE_TYPE_DESCRIPTION;
            SerializeAs = SerializationFormat.Xml;//default
        }

        //public ThemeEditorSettings
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

        #region IDisposable support
        ~ThemeEditorSettings()
        {
            Dispose(false);
        }

        //inherited; override if additional cleanup needed
        protected override void Dispose(Boolean disposeManagedResources)
        {
            // process only if mananged and unmanaged resources have
            // not been disposed of.
            if (!disposed)
            {
                try
                {
                    //Resources not disposed
                    if (disposeManagedResources)
                    {
                        // dispose managed resources
                    }

                    disposed = true;
                }
                finally
                {
                    // dispose unmanaged resources
                    base.Dispose(disposeManagedResources);
                }
            }
            else
            {
                //Resources already disposed
            }
        }
        #endregion
            
        #region IEquatable<ISettings>
        /// <summary>
        /// Compare property values of two specified Settings objects.
        /// </summary>
        /// <param name="anotherSettings"></param>
        /// <returns></returns>
        public /*override*/ Boolean Equals(ISettings other)
        {
            Boolean returnValue = default(Boolean);
            ThemeEditorSettings otherSettings = default(ThemeEditorSettings);

            try
            {
                otherSettings = other as ThemeEditorSettings;

                if (this == otherSettings)
                {
                    returnValue = true;
                }
                else
                {
                    if (!base.Equals(other))
                    {
                        returnValue = false;
                    }
                    //else if (this.SomeInt != otherSettings.SomeInt)
                    //{
                    //    returnValue = false;
                    //}
                    //else if (this.SomeBoolean != otherSettings.SomeBoolean)
                    //{
                    //    returnValue = false;
                    //}
                    //else if (this.SomeString != otherSettings.SomeString)
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
        #endregion IEquatable<ISettings>

        #region Properties
        [XmlIgnore]
        public override Boolean Dirty
        {
            get
            {
                Boolean returnValue = default(Boolean);

                try
                {
                    if (base.Dirty)
                    {
                        returnValue = true;
                    }
                    //else if (_SomeInt != __SomeInt)
                    //{
                    //    returnValue = true;
                    //}
                    //else if (_SomeBoolean != __SomeBoolean)
                    //{
                    //    returnValue = true;
                    //}
                    //else if (_SomeString != __SomeString)
                    //{
                    //    returnValue = true;
                    //}
                    else
                    {
                        returnValue = false;
                    }
                }
                catch (Exception ex)
                {
                    Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                    throw;
                }

                return returnValue;
            }
        }

        #region Persisted Properties
        //private Int32 __SomeInt = default(Int32);
        //private Int32 _SomeInt = default(Int32);
        //public Int32 SomeInt
        //{
        //    get { return _SomeInt; }
        //    set 
        //    {
        //        _SomeInt = value;
        //        OnPropertyChanged("SomeInt");
        //    }
        //}

        //private Boolean __SomeBoolean = default(Boolean);
        //private Boolean _SomeBoolean = default(Boolean);
        //public Boolean SomeBoolean
        //{
        //    get { return _SomeBoolean; }
        //    set 
        //    { 
        //        _SomeBoolean = value;
        //        OnPropertyChanged("SomeBoolean");
        //    }
        //}

        //private String __SomeString = default(String);
        //private String _SomeString = default(String);
        //public String SomeString
        //{
        //    get { return _SomeString; }
        //    set 
        //    { 
        //        _SomeString = value;
        //        OnPropertyChanged("SomeString");
        //    }
        //}
        #endregion Persisted Properties
        #endregion Properties

        #region Methods
        /// <summary>
        /// Copies property values from source working fields to detination working fields, then optionally syncs destination.
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="sync"></param>
        public /*override*/ void CopyTo(ISettings destination, Boolean sync)
        {
            ThemeEditorSettings destinationSettings = default(ThemeEditorSettings);

            try
            {
                destinationSettings = destination as ThemeEditorSettings;

                //destinationSettings.SomeInt = this.SomeInt;
                //destinationSettings.SomeBoolean = this.SomeBoolean;
                //destinationSettings.SomeString = this.SomeString;

                base.CopyTo(destination, sync);//also checks and optionally performs sync
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }

        /// <summary>
        /// Syncs property values by copying from working fields to reference fields.
        /// </summary>
        public override void Sync()
        {
            try
            {
                //__SomeInt = _SomeInt;
                //__SomeBoolean = _SomeBoolean;
                //__SomeString = _SomeString;

                base.Sync();

                if (Dirty)
                {
                    throw new ApplicationException("Sync failed.");
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }        
        #endregion Methods
    }
}
