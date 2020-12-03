using System;
using System.ComponentModel;
using System.Net;
using System.Windows;
using Ssepan.Utility;

namespace ThemeEditorLibrary
{
    public abstract class ViewModelBase : 
        INotifyPropertyChanged
    {
        #region Declarations
        #endregion Declarations

        #region Constructors
        #endregion Constructors

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion INotifyPropertyChanged

        #region Properties
        private String _StatusMessage = default(String);
        public String StatusMessage
        {
            get { return _StatusMessage; }
            set
            {
                if (value != _StatusMessage)
                {
                    _StatusMessage = value;
                    NotifyPropertyChanged("StatusMessage");
                }
            }
        }

        private String _ErrorMessage = default(String);
        public String ErrorMessage
        {
            get { return _ErrorMessage; }
            set
            {
                if (value != _ErrorMessage)
                {
                    _ErrorMessage = value;
                    NotifyPropertyChanged("ErrorMessage");
                }
            }
        }

        private String _ErrorMessageToolTipText = default(String);
        public String ErrorMessageToolTipText
        {
            get { return _ErrorMessageToolTipText; }
            set
            {
                if (value != _ErrorMessageToolTipText)
                {
                    _ErrorMessageToolTipText = value;
                    NotifyPropertyChanged("ErrorMessageToolTipText");
                }
            }
        }

        private Int32 _ProgressBarValue = default(Int32);
        public Int32 ProgressBarValue
        {
            get { return _ProgressBarValue; }
            set
            {
                if (value != _ProgressBarValue)
                {
                    _ProgressBarValue = value;
                    NotifyPropertyChanged("ProgressBarValue");
                }
            }
        }

        private Int32 _ProgressBarMaximum = default(Int32);
        public Int32 ProgressBarMaximum
        {
            get { return _ProgressBarMaximum; }
            set
            {
                if (value != _ProgressBarMaximum)
                {
                    _ProgressBarMaximum = value;
                    NotifyPropertyChanged("ProgressBarMaximum");
                }
            }
        }

        private Int32 _ProgressBarMinimum = default(Int32);
        public Int32 ProgressBarMinimum
        {
            get { return _ProgressBarMinimum; }
            set
            {
                if (value != _ProgressBarMinimum)
                {
                    _ProgressBarMinimum = value;
                    NotifyPropertyChanged("ProgressBarMinimum");
                }
            }
        }

        private Int32 _ProgressBarStep = default(Int32);
        public Int32 ProgressBarStep
        {
            get { return _ProgressBarStep; }
            set
            {
                if (value != _ProgressBarStep)
                {
                    _ProgressBarStep = value;
                    NotifyPropertyChanged("ProgressBarStep");
                }
            }
        }

        private Boolean _ProgressBarIsMarquee = default(Boolean);
        public Boolean ProgressBarIsMarquee
        {
            get { return _ProgressBarIsMarquee; }
            set
            {
                if (value != _ProgressBarIsMarquee)
                {
                    _ProgressBarIsMarquee = value;
                    NotifyPropertyChanged("ProgressBarIsMarquee");
                }
            }
        }

        private Boolean _ProgressBarIsVisible = default(Boolean);
        public Boolean ProgressBarIsVisible
        {
            get { return _ProgressBarIsVisible; }
            set
            {
                if (value != _ProgressBarIsVisible)
                {
                    _ProgressBarIsVisible = value;
                    NotifyPropertyChanged("ProgressBarIsVisible");
                }
            }
        }

        private Boolean _ActionIconIsVisible = default(Boolean);
        public Boolean ActionIconIsVisible
        {
            get { return _ActionIconIsVisible; }
            set
            {
                if (value != _ActionIconIsVisible)
                {
                    _ActionIconIsVisible = value;
                    NotifyPropertyChanged("ActionIconIsVisible");
                }
            }
        }

        private System.Drawing.Image _ActionIconWinformsImage = default(System.Drawing.Image);
        public System.Drawing.Image ActionIconWinformsImage
        {
            get { return _ActionIconWinformsImage; }
            set
            {
                if (value != _ActionIconWinformsImage)
                {
                    _ActionIconWinformsImage = value;
                    NotifyPropertyChanged("ActionIconWinformsImage");
                }
            }
        }

        private Boolean _DirtyIconIsVisible = default(Boolean);
        public Boolean DirtyIconIsVisible
        {
            get { return _DirtyIconIsVisible; }
            set
            {
                if (value != _DirtyIconIsVisible)
                {
                    _DirtyIconIsVisible = value;
                    NotifyPropertyChanged("DirtyIconIsVisible");
                }
            }
        }

        private System.Drawing.Image _DirtyIconWinformsImage = default(System.Drawing.Image);
        public System.Drawing.Image DirtyIconWinformsImage
        {
            get { return _DirtyIconWinformsImage; }
            set
            {
                if (value != _DirtyIconWinformsImage)
                {
                    _DirtyIconWinformsImage = value;
                    NotifyPropertyChanged("DirtyIconWinformsImage");
                }
            }
        }

        public Boolean IsDataLoaded
        {
            get;
            protected set;
        }
        #endregion Properties

        #region Methods
        public abstract void LoadData(ref String errorMessage);

        /// <summary>
        /// Provide a means for view to mark data as invalid.
        /// </summary>
        public void InvalidateData()
        {
            IsDataLoaded = false;
        }

        /// <summary>
        /// Use when Marquee-style progress bar is not sufficient, and percentages must be indicated.
        /// WinForms.
        /// </summary>
        /// <param name="statusMessage"></param>
        /// <param name="errorMessage"></param>
        /// <param name="objImage"></param>
        /// <param name="isMarqueeProgressBarStyle"></param>
        /// <param name="progressBarValue"></param>
        public void StartProgressBar(String statusMessage, String errorMessage, System.Drawing.Image objImage, Boolean isMarqueeProgressBarStyle, Int32 progressBarValue)
        {
            try
            {
                ProgressBarIsMarquee = isMarqueeProgressBarStyle;//set to blocks if actual percentage was used.
                ProgressBarValue = progressBarValue;//set to value if percentage used.
                //if Style is not Marquee, then we are marking either a count or percentage
                if (progressBarValue > ProgressBarMaximum)
                {
                    ProgressBarStep = 1;
                    ProgressBarValue = 1;
                }

                StatusMessage = statusMessage;
                ErrorMessage = errorMessage;
                //this.StatusBarErrorMessage.ToolTipText = errorMessage;

                ProgressBarIsVisible = true;

                ActionIconWinformsImage = objImage;
                ActionIconIsVisible = true;

                //give the app time to draw the eye-candy, even if its only for an instant
                System.Windows.Forms.Application.DoEvents();
            }
            catch (Exception ex)
            {
                Log.Write(
                    ex,
                    System.Reflection.MethodBase.GetCurrentMethod(),
                    System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
        }

        /// <summary>
        /// Update percentage changes.
        /// </summary>
        /// <param name="statusMessage"></param>
        /// <param name="progressBarValue"></param>
        public void UpdateProgressBar(String statusMessage, Int32 progressBarValue)
        {
            try
            {
                StatusMessage = statusMessage;
                //ErrorMessage = errorMessage;
                //this.StatusBarErrorMessage.ToolTipText = errorMessage;

                //if Style is not Marquee, then we are marking either a count or percentage
                //if we are simply counting, the progress bar will periodically need to adjust the Maximum.
                if (progressBarValue > ProgressBarMaximum)
                {
                    ProgressBarMaximum = ProgressBarMaximum * 2;
                }
                ProgressBarValue = progressBarValue;

                //give the app time to draw the eye-candy, even if its only for an instant
                //Application.DoEvents();
            }
            catch (Exception ex)
            {
                Log.Write(
                    ex,
                    System.Reflection.MethodBase.GetCurrentMethod(),
                    System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
        }

        /// <summary>
        /// Update message(s) only, without changing progress bar. 
        /// Null parameter will leave a message unchanged; 
        /// String.Empty will clear it.
        /// Optional doEvents flag will determine if
        /// messages are processed before continuing.
        /// </summary>
        /// <param name="statusMessage"></param>
        /// <param name="errorMessage"></param>
        /// <param name="doEvents"></param>
        public void UpdateStatusBarMessages(String statusMessage, String errorMessage, Boolean doEvents = false)
        {
            try
            {
                if (statusMessage != null)
                {
                    StatusMessage = statusMessage;
                }
                if (errorMessage != null)
                {
                    ErrorMessage = errorMessage;
                    ErrorMessageToolTipText = errorMessage;
                }

                if (doEvents)
                {
                    //give the app time to draw the eye-candy, even if its only for an instant
                    //Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                Log.Write(
                    ex,
                    System.Reflection.MethodBase.GetCurrentMethod(),
                    System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
        }

        /// <summary>
        /// Stop progress bar and display messages.
        /// DoEvents will ensure messages are processed before continuing.
        /// </summary>
        /// <param name="statusMessage"></param>
        /// <param name="errorMessage">Null parameter will leave a message unchanged; String.Empty will clear it.</param>
        public void StopProgressBar(String statusMessage, String errorMessage = null)
        {
            try
            {
                StatusMessage = statusMessage;
                //do not clear error at end of operation, clear it at start of operation
                if (errorMessage != null)
                {
                    ErrorMessage = errorMessage;
                    //this.StatusBarErrorMessage.ToolTipText = errorMessage;
                }

                ProgressBarIsMarquee = false;//reset back to marquee (default) in case actual percentage was used
                ProgressBarMaximum = 100;//ditto
                ProgressBarStep = 10;//ditto
                ProgressBarValue = 0;//dittoo
                ProgressBarIsVisible = false;

                ActionIconIsVisible = false;
                ActionIconWinformsImage = null;

                //give the app time to draw the eye-candy, even if its only for an instant
                //Application.DoEvents();
            }
            catch (Exception ex)
            {
                Log.Write(
                    ex,
                    System.Reflection.MethodBase.GetCurrentMethod(),
                    System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
        }
        #endregion Methods

    }
}
