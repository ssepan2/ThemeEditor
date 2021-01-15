using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Text;
using Microsoft.Win32;
using Ssepan.Application;
using Ssepan.Utility;

namespace ThemeEditorLibrary
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ColorRecord :
        SettingsComponentBase//,
        //INotifyPropertyChanged
    {

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
        private Color? _Foreground = default(Color?);
        public Color? Foreground
        {
            get { return _Foreground; }
            set
            {
                _Foreground = value;
                OnPropertyChanged("Foreground");
            }
        }
        private Int64 _ForegroundPos = default(Int64);
        public Int64 ForegroundPos
        {
            get { return _ForegroundPos; }
            set
            {
                _ForegroundPos = value;
                OnPropertyChanged("ForegroundPos");
            }
        }
        private Color? _Background = default(Color?);
        public Color? Background
        {
            get { return _Background; }
            set
            {
                _Background = value;
                OnPropertyChanged("Background");
            }
        }
        private Int64 _BackgroundPos = default(Int64);
        public Int64 BackgroundPos
        {
            get { return _BackgroundPos; }
            set
            {
                _BackgroundPos = value;
                OnPropertyChanged("BackgroundPos");
            }
        }
        #endregion Properties

        #region Methods
        #region Reader
        /// <summary>
        /// Extract color record from theme category in registry bytes.
        /// </summary>
        /// <param name="binaryReader"></param>
        /// <returns></returns>
        public static ColorRecord UnpackColorRecord
        (
            BinaryReader binaryReader
        )
        {
            ColorRecord returnValue = default(ColorRecord);
            try
            {
                try
                {
                    Int32 recordNameLength = binaryReader.ReadInt32();
                    Byte[] nameBytes = binaryReader.ReadBytes(recordNameLength);

                    returnValue = new ColorRecord
                    {
                        Name = Encoding.UTF8.GetString(nameBytes),
                    };
                    returnValue.BackgroundPos = binaryReader.BaseStream.Position;
                    returnValue.Background = UnpackColor(binaryReader);
                    returnValue.ForegroundPos = binaryReader.BaseStream.Position;
                    returnValue.Foreground = UnpackColor(binaryReader);
                }
                catch (EndOfStreamException /*ex*/)
                {
                    //log?
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), System.Diagnostics.EventLogEntryType.Error);
            }
            return returnValue;
        }

        /// <summary>
        /// Unpack color fields.
        /// </summary>
        /// <param name="binaryReader"></param>
        /// <returns></returns>
        public static Color? UnpackColor
        (
            BinaryReader binaryReader
        )
        {
            Byte hasValue = binaryReader.ReadByte();
            if (hasValue == 0)
            {
                return null;
            }

            Byte red = binaryReader.ReadByte();
            Byte green = binaryReader.ReadByte();
            Byte blue = binaryReader.ReadByte();
            Byte alpha = binaryReader.ReadByte();

            return Color.FromArgb(alpha, red, green, blue);
        }
        #endregion Reader

        #region Writer
        /// <summary>
        /// Inject color record back into registry key, and write key to registry.
        /// Note: cannot add new color names without determining Pos values, so for now cannot add missing color names to a theme.
        /// </summary>
        /// <param name="foregroundColor"></param>
        /// <param name="backgroundColor"></param>
        /// <param name="model"></param>
        public static void InjectColor
        (
            Color? foregroundColor, 
            Color? backgroundColor, 
            ThemeEditorModel model
        )
        {
            String registryPath = 
                Path.Combine
                ( 
                    model.RegistryPath, 
                    model.Theme.Guid.ToString("B"), 
                    model.Category.Name 
                );
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey( registryPath, true );
            Byte[] colorBytes = registryKey.GetValue("Data") as Byte[];

            using (MemoryStream memoryStream = new MemoryStream( colorBytes ) )
            using ( BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
            {
                if (backgroundColor != null )
                {
                    memoryStream.Seek( model.ColorRecord.BackgroundPos, SeekOrigin.Begin );
                    WriteColor( backgroundColor.Value, binaryWriter );
                }
                if (foregroundColor != null)
                {
                    memoryStream.Seek( model.ColorRecord.ForegroundPos, SeekOrigin.Begin );
                    WriteColor( foregroundColor.Value, binaryWriter );
                }

                binaryWriter.Flush();
                binaryWriter.Close();
                Byte[] setBytes = memoryStream.ToArray();

                registryKey.SetValue( "Data", setBytes, RegistryValueKind.Binary );
            }
        }

        /// <summary>
        /// Inject color fields.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="binaryWriter"></param>
        public static void WriteColor
        (
            Color color, 
            BinaryWriter binaryWriter
        )
        {
            binaryWriter.Write( (Byte)1 );
            binaryWriter.Write( color.R );
            binaryWriter.Write( color.G );
            binaryWriter.Write( color.B );
            binaryWriter.Write( color.A );
        }
        #endregion Writer
        #endregion Methods

    }
}