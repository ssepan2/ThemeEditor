using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32;
using ThemeEditorLibrary;
using Ssepan.Application;
using Ssepan.Io;
using Ssepan.Utility;

namespace ThemeEditor
{
    /// <summary>
    /// Based on Visual Studio Theme Editor 2012, 
    /// by Brian Chavez (http://twitter.com/bchavez)
    /// on http://bchavez.bitarmory.com/archive/2012/08/27/modify-visual-studio-2012-dark-and-light-themes.aspx
    /// Forked by Stephen J Sepan (mailto:ssepanus@yahoo.com).
    /// </summary>
    public partial class ThemeEditorView :
        Form,
        INotifyPropertyChanged
    {
        #region Declarations
        protected Boolean disposed;

        private Boolean _ValueChangedProgrammatically;

        //cancellation hook
        Action cancelDelegate = null;
        protected ThemeEditorViewModel ViewModel = default(ThemeEditorViewModel);
        #endregion Declarations

        #region Constructors
        public ThemeEditorView(String[] args)
        {
            try
            {
                InitializeComponent();

                ////(re)define default output delegate
                //ConsoleApplication.defaultOutputDelegate = ConsoleApplication.messageBoxWrapperOutputDelegate;

                //subscribe to notifications
                this.PropertyChanged += PropertyChangedEventHandlerDelegate;

                InitViewModel();

                BindSizeAndLocation();
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }
        #endregion Constructors

        #region INotifyPropertyChanged
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
                ViewModel.ErrorMessage = ex.Message;
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                throw;
            }
        }
        #endregion INotifyPropertyChanged

        #region PropertyChangedEventHandlerDelegate
        /// <summary>
        /// Note: property changes update UI manually.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PropertyChangedEventHandlerDelegate
        (
            Object sender,
            PropertyChangedEventArgs e
        )
        {
            try
            {
                if (e.PropertyName == "IsChanged")
                {
                    //ConsoleApplication.defaultOutputDelegate(String.Format("{0}", e.PropertyName));
                    ApplySettings();
                }
                //Status Bar
                else if (e.PropertyName == "ActionIconIsVisible")
                {
                    StatusBarActionIcon.Visible = (ViewModel.ActionIconIsVisible);
                }
                else if (e.PropertyName == "ActionIconImage")
                {
                    StatusBarActionIcon.Image = (ViewModel != null ? ViewModel.ActionIconImage : (Image)null);
                }
                else if (e.PropertyName == "StatusMessage")
                {
                    //replace default action by setting control property
                    StatusBarStatusMessage.Text = ViewModel.StatusMessage;
                    //e = new PropertyChangedEventArgs(e.PropertyName + ".handled");

                    //ConsoleApplication.defaultOutputDelegate(String.Format("{0}", StatusMessage));
                }
                else if (e.PropertyName == "ErrorMessage")
                {
                    //replace default action by setting control property
                    StatusBarErrorMessage.Text = ViewModel.ErrorMessage;
                    //e = new PropertyChangedEventArgs(e.PropertyName + ".handled");

                    //ConsoleApplication.defaultOutputDelegate(String.Format("{0}", ErrorMessage));
                }
                else if (e.PropertyName == "ErrorMessageToolTipText")
                {
                    StatusBarErrorMessage.ToolTipText = ViewModel.ErrorMessageToolTipText;
                }
                else if (e.PropertyName == "ProgressBarValue")
                {
                    StatusBarProgressBar.Value = ViewModel.ProgressBarValue;
                }
                else if (e.PropertyName == "ProgressBarMaximum")
                {
                    StatusBarProgressBar.Maximum = ViewModel.ProgressBarMaximum;
                }
                else if (e.PropertyName == "ProgressBarMinimum")
                {
                    StatusBarProgressBar.Minimum = ViewModel.ProgressBarMinimum;
                }
                else if (e.PropertyName == "ProgressBarStep")
                {
                    StatusBarProgressBar.Step = ViewModel.ProgressBarStep;
                }
                else if (e.PropertyName == "ProgressBarIsMarquee")
                {
                    StatusBarProgressBar.Style = (ViewModel.ProgressBarIsMarquee ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks);
                }
                else if (e.PropertyName == "ProgressBarIsVisible")
                {
                    StatusBarProgressBar.Visible = (ViewModel.ProgressBarIsVisible);
                }
                else if (e.PropertyName == "DirtyIconIsVisible")
                {
                    StatusBarDirtyMessage.Visible = (ViewModel.DirtyIconIsVisible);
                }
                else if (e.PropertyName == "DirtyIconImage")
                {
                    StatusBarDirtyMessage.Image = ViewModel.DirtyIconImage;
                }
                //Form
                //Themes
                else if (e.PropertyName == "RegistryPath")
                {
                    //A change of the key (due to change of version  / edition) loads new theme...
                    ViewModel.LoadThemes();

                    //... and then triggers a UI refresh.
                    ModelController<ThemeEditorModel>.Model.IsChanged = true;
                }
                else if (e.PropertyName == "Theme")
                {
                    bsCategoryBindingSource.DataSource = null;
                    bsCategoryBindingSource.DataSource = ModelController<ThemeEditorModel>.Model.Theme.Categories;
                    bsCategoryBindingSource.MoveFirst();
                }
                else if (e.PropertyName == "Category")
                {
                    if (ModelController<ThemeEditorModel>.Model.Category != null)
                    {
                        //sort and bind
                        bsColorRecordBindingSource.DataSource =
                            from ColorRecord colorRecord in ModelController<ThemeEditorModel>.Model.Category.ColorRecords
                            orderby colorRecord.Name
                            select colorRecord;
                        bsColorRecordBindingSource.MoveFirst();
                    }
                    else
                    {
                        bsColorRecordBindingSource.DataSource = null;
                    }
                }
                else if (e.PropertyName == "ColorRecord")
                {
                    //Note: Validation already triggered save / cancel. 
                    Debug.Assert(!cmdSaveColor.Enabled);
                    // However, Enabled should never be true if save / cancel already done, 
                    // so maybe this is unnecessary.
                    cmdSaveColor.Enabled = false;

                    //t ColorRecord for null before accessing Foreground/Background
                    if ((ModelController<ThemeEditorModel>.Model.ColorRecord != null))
                    {
                        if ((ModelController<ThemeEditorModel>.Model.ColorRecord.Foreground != null))
                        {
                            cmdForeground.Text = String.Empty;
                            cmdForeground.BackColor = ModelController<ThemeEditorModel>.Model.ColorRecord.Foreground.Value;
                            cmdForeground.Enabled = true;
                            trkForeground.Enabled = true;
                        }
                        else
                        {
                            cmdForeground.Text = " -- No Color --";
                            cmdForeground.BackColor = Color.Transparent;
                            cmdForeground.Enabled = false;
                            trkForeground.Enabled = false;
                        }

                        if ((ModelController<ThemeEditorModel>.Model.ColorRecord.Background != null))
                        {
                            cmdBackground.Text = String.Empty;
                            cmdBackground.BackColor = ModelController<ThemeEditorModel>.Model.ColorRecord.Background.Value;
                            cmdBackground.Enabled = true;
                            trkBackground.Enabled = true;
                        }
                        else
                        {
                            cmdBackground.Text = " -- No Color -- ";
                            cmdBackground.BackColor = Color.Transparent;
                            cmdBackground.Enabled = false;
                            trkBackground.Enabled = false;
                        }

                        lblColorRecordName.Text = ModelController<ThemeEditorModel>.Model.ColorRecord.Name;
                    }
                    else
                    {
                        cmdForeground.Text = " -- No Color --";
                        cmdForeground.BackColor = Color.Transparent;
                        cmdForeground.Enabled = false;
                        trkForeground.Enabled = false;

                        cmdBackground.Text = " -- No Color -- ";
                        cmdBackground.BackColor = Color.Transparent;
                        cmdBackground.Enabled = false;
                        trkBackground.Enabled = false;

                        lblColorRecordName.Text = " -- N/A -- ";
                    }
                }
                //use if properties cannot be databound
                //else if (e.PropertyName == "SomeInt")
                //{
                //    //SettingsController<ThemeEditorSettings>.Settings.
                //    ModelController<ThemeEditorModel>.Model.IsChanged = true;
                //}
                //else if (e.PropertyName == "SomeBoolean")
                //{
                //    //SettingsController<ThemeEditorSettings>.Settings.
                //    ModelController<ThemeEditorModel>.Model.IsChanged = true;
                //}
                //else if (e.PropertyName == "SomeString")
                //{
                //    //SettingsController<ThemeEditorSettings>.Settings.
                //    ModelController<ThemeEditorModel>.Model.IsChanged = true;
                //}
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }
        #endregion PropertyChangedEventHandlerDelegate

        #region Properties
        private String _ViewName = Program.APP_NAME;
        public String ViewName
        {
            get { return _ViewName; }
            set
            {
                _ViewName = value;
                OnPropertyChanged("ViewName");
            }
        }
        #endregion Properties

        #region Events
        #region Form Events
        private void ThemeEditorView_Load(Object sender, EventArgs e)
        {
            try
            {
                ViewModel.StatusMessage = String.Format("{0} starting...", ViewName);

                ButtonsEnabled(true);

                ViewModel.StatusMessage = String.Format("{0} started.", ViewName);

                _Run();
            }
            catch (Exception ex)
            {
                ViewModel.ErrorMessage = ex.Message;
                ViewModel.StatusMessage = String.Empty;

                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
            //String statusMessage = String.Empty;
            //String errorMessage = default(String);

            //try
            //{
            //    statusMessage = "Loading...";
            //    StartProgressBar(statusMessage, errorMessage, null/*this.menu???.Image*//*, ProgressBarStyle.Blocks, 0*/);

            //    //'Bind' view-model properties to toolstrip status bar properties
            //    PropertyChangedEventHandlerDelegate = PropertyChangedEventHandler;

            //    #region Load Data
            //    //instantiate viewmodel
            //    if (App.ThemeEditorVM == null)
            //    {
            //        App.ThemeEditorVM = new ThemeEditorViewModel(this);
            //    }

            //    //do once
            //    RefreshStaticDataBindings();
                
            //    //load viewmodel
            //    if (!App.ThemeEditorVM.IsDataLoaded)
            //    {
            //        RefreshDynamicDataBindings();
            //    }
            //    #endregion Load Data

            //    //ButtonsEnabled(true);
                
            //    statusMessage = "Loaded.";
            //}
            //catch (Exception ex)
            //{
            //    errorMessage = ex.Message;
            //    statusMessage = String.Empty;

            //    Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            //}
            //finally
            //{
            //    StopProgressBar(statusMessage, errorMessage);
            //}
        }
        #endregion Form Events

        #region Menu Events
        private void menuFileNew_Click(Object sender, EventArgs e)
        {
            ViewModel.FileNew();
        }

        private void menuFileOpen_Click(Object sender, EventArgs e)
        {
            ViewModel.FileOpen();
        }

        private void menuFileSave_Click(Object sender, EventArgs e)
        {
            ViewModel.FileSave();
        }

        private void menuFileSaveAs_Click(Object sender, EventArgs e)
        {
            ViewModel.FileSaveAs();
        }

        private void menuFileExit_Click(Object sender, EventArgs e)
        {
            ViewModel.FileExit();
        }

        private void menuEditProperties_Click(Object sender, EventArgs e)
        {
            ViewModel.EditProperties();
        }

        private void menuEditCopyToClipboard_Click(Object sender, EventArgs e)
        {
            ViewModel.EditCopy();
        }

        private void menuHelpAbout_Click(Object sender, EventArgs e)
        {
            ViewModel.HelpAbout<AssemblyInfo>();
        }
        //private void menuEditProperties_Click(Object sender, EventArgs e)
        //{
        //    try
        //    {
        //        App.ThemeEditorVM.EditPropertiesCommand.Execute(null);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
        //    }
        //}

        //private void menuFileExit_Click(Object sender, EventArgs e)
        //{
        //    try
        //    {
        //        App.ThemeEditorVM.FileExitCommand.Execute(null);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
        //    }
        //}

        //private void menuHelpAbout_Click(Object sender, EventArgs e)
        //{
        //    try
        //    {
        //        App.ThemeEditorVM.HelpAboutCommand.Execute(null);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
        //    }
        //}        #endregion Menu Events
        #endregion Menu Events

        #region Control Events


        private void bsVersionYearBindingSource_PositionChanged(Object sender, EventArgs e)
        {
            try
            {
                ModelController<ThemeEditorModel>.Model.Version = (bsVersionYearBindingSource.Current as VisualStudioVersion);
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        private void bsEditionBindingSource_PositionChanged(Object sender, EventArgs e)
        {
            try
            {
                ModelController<ThemeEditorModel>.Model.Edition = (bsEditionBindingSource.Current as VisualStudioEdition);
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        private void bsThemeBindingSource_PositionChanged( Object sender, EventArgs e )
        {
            try
            {
                ModelController<ThemeEditorModel>.Model.Theme = (bsThemeBindingSource.Current as ThemeInfo);
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        private void bsCategoryBindingSource_PositionChanged( Object sender, EventArgs e )
        {
            try
            {
                ModelController<ThemeEditorModel>.Model.Category = (bsCategoryBindingSource.Current as ThemeCategory);                
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        private void bsColorRecordBindingSource_CurrentChanged( Object sender, EventArgs e )
        {
            try
            {
                ModelController<ThemeEditorModel>.Model.ColorRecord = (bsColorRecordBindingSource.Current as ColorRecord);                                
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        private void cboYearVersion_Validating(Object sender, CancelEventArgs e)
        {
            try
            {
                ValidatingColor();
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        private void cboYearVersion_SelectedValueChanged(Object sender, EventArgs e)
        {
            try
            {
                ValidatingColor();
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        private void cboEdition_Validating(Object sender, CancelEventArgs e)
        {
            try
            {
                ValidatingColor();
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        private void cboEdition_SelectedValueChanged(Object sender, EventArgs e)
        {
            try
            {
                ValidatingColor();
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        private void cboTheme_Validating(Object sender, CancelEventArgs e)
        {
            try
            {
                ValidatingColor();
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        private void cboTheme_SelectedValueChanged(Object sender, EventArgs e)
        {
            try
            {
                ValidatingColor();
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        private void cboCategory_Validating(Object sender, CancelEventArgs e)
        {
            try
            {
                ValidatingColor();
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        private void cboCategory_SelectedValueChanged( Object sender, EventArgs e )
        {
            try
            {
                ValidatingColor();
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        private void lstColorRecords_Validating(Object sender, CancelEventArgs e)
        {
            try
            {
                ValidatingColor();
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        private void lstRecords_SelectedValueChanged( Object sender, EventArgs e )
        {
            try
            {
                ValidatingColor();
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        private void cmdForeground_Click(Object sender, EventArgs e)
        {
            ViewModel.SelectColor_Click(sender as Button, cmdSaveColor, "Foreground");
        }

        /// <summary>
        /// BackColorChanged handler will NOT trigger TrackBar's Scroll event by changing Value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdForeground_BackColorChanged(Object sender, EventArgs e)
        {
            try
            {
                lblFG.Text = ModelController<ThemeEditorModel>.Model.GetColorDisplay(cmdForeground.BackColor);
                trkForeground.Value = cmdForeground.BackColor.A;
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        private void cmdBackground_Click(Object sender, EventArgs e)
        {
            ViewModel.SelectColor_Click(sender as Button, cmdSaveColor, "Background");
        }

        /// <summary>
        /// BackColorChanged handler will NOT trigger TrackBar's Scroll event by changing Value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdBackground_BackColorChanged(Object sender, EventArgs e)
        {
            try
            {
                lblBG.Text = ModelController<ThemeEditorModel>.Model.GetColorDisplay(cmdBackground.BackColor);
                trkBackground.Value = cmdBackground.BackColor.A;
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        /// <summary>
        /// Scroll handler will trigger Button's BackColorChanged event by setting BackColor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trkForeground_Scroll(Object sender, EventArgs e)
        {
            TrackBar trackBar = default(TrackBar);

            try
            {
                trackBar = sender as TrackBar;
                cmdForeground.BackColor = Color.FromArgb(trackBar.Value, cmdForeground.BackColor);

                cmdSaveColor.Enabled = true;
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        /// <summary>
        /// Scroll handler will trigger Button's BackColorChanged event by setting BackColor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trkBackground_Scroll(Object sender, EventArgs e)
        {
            TrackBar trackBar = default(TrackBar);

            try
            {
                trackBar = sender as TrackBar;
                cmdBackground.BackColor = Color.FromArgb(trackBar.Value, cmdBackground.BackColor);

                cmdSaveColor.Enabled = true;
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        /// <summary>
        /// Save/Save As theme.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdBackupTheme_Click(Object sender, EventArgs e)
        {
            ViewModel.BackupTheme_Click();
        }

        /// <summary>
        /// New theme.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdResetTheme_Click(Object sender, EventArgs e)
        {
            ViewModel.ResetTheme_Click();
        }

        /// <summary>
        /// Save color record to list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSaveColor_Click(Object sender, EventArgs e)
        {
            ViewModel.SaveColor_Click(cmdForeground, cmdBackground, cmdSaveColor);
        }
        #endregion Control Events
        #endregion Events

        #region Methods

        #region FormAppBase
        protected void InitViewModel()
        {
            try
            {
                //subscribe view to model notifications
                ModelController<ThemeEditorModel>.Model.PropertyChanged += PropertyChangedEventHandlerDelegate;

                FileDialogInfo settingsFileDialogInfo =
                    new FileDialogInfo
                    (
                        SettingsController<ThemeEditorSettings>.FILE_NEW,
                        null,
                        null,
                        SettingsBase.FileTypeExtension,
                        SettingsBase.FileTypeDescription,
                        SettingsBase.FileTypeName,
                        new String[] 
                    { 
                        "XML files (*.xml)|*.xml", 
                        "All files (*.*)|*.*" 
                    },
                        false,
                        default(Environment.SpecialFolder),
                        Environment.GetFolderPath(Environment.SpecialFolder.Personal).WithTrailingSeparator()
                    );

                //set dialog caption
                settingsFileDialogInfo.Title = this.Text;

                //class to handle standard behaviors
                ViewModelController<Bitmap, ThemeEditorViewModel>.New
                (
                    ViewName,
                    new ThemeEditorViewModel
                    (
                        this.PropertyChangedEventHandlerDelegate,
                        new Dictionary<String, Bitmap>() 
                    { 
                        { "New", ThemeEditorLibrary.Properties.Resources.New }, 
                        { "Save", ThemeEditorLibrary.Properties.Resources.Save },
                        { "Open", ThemeEditorLibrary.Properties.Resources.Open },
                        { "Print", ThemeEditorLibrary.Properties.Resources.Print },
                        { "Copy", ThemeEditorLibrary.Properties.Resources.Copy },
                        { "Properties", ThemeEditorLibrary.Properties.Resources.Properties }
                    },
                        settingsFileDialogInfo
                    )
                );
                ViewModel = ViewModelController<Bitmap, ThemeEditorViewModel>.ViewModel[ViewName];

                BindFormUi();

                //Init config parameters
                if (!LoadParameters())
                {
                    throw new Exception(String.Format("Unable to load config file parameter(s)."));
                }

                //DEBUG:filename coming in is being converted/passed as DOS 8.3 format equivalent
                //Load
                if ((SettingsController<ThemeEditorSettings>.FilePath == null) || (SettingsController<ThemeEditorSettings>.Filename == SettingsController<ThemeEditorSettings>.FILE_NEW))
                {
                    //NEW
                    ViewModel.FileNew();
                }
                else
                {
                    //OPEN
                    ViewModel.FileOpen(false);
                }

#if debug
            //debug view
            menuEditProperties_Click(sender, e);
#endif

                //Display dirty state
                ModelController<ThemeEditorModel>.Model.Refresh();
            }
            catch (Exception ex)
            {
                if (ViewModel != null)
                {
                    ViewModel.ErrorMessage = ex.Message;
                }
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        protected void DisposeSettings()
        {
            //save user and application settings 
            Properties.Settings.Default.Save();

            if (SettingsController<ThemeEditorSettings>.Settings.Dirty)
            {
                //prompt before saving
                DialogResult dialogResult = MessageBox.Show("Save changes?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        {
                            //SAVE
                            ViewModel.FileSave();

                            break;
                        }
                    case DialogResult.No:
                        {
                            break;
                        }
                    default:
                        {
                            throw new InvalidEnumArgumentException();
                        }
                }
            }

            //unsubscribe from model notifications
            ModelController<ThemeEditorModel>.Model.PropertyChanged -= PropertyChangedEventHandlerDelegate;
        }

        protected void _Run()
        {
            //MessageBox.Show("running", "MVC", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            ValidatingColor();
        }
        #endregion FormAppBase
        
        #region Utility
        private void ValidatingColor()
        {
            try
            {
                if (cmdSaveColor.Enabled)
                {
                    if (MessageBox.Show("Save last Color?", "Color", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        cmdSaveColor_Click(cmdSaveColor, null);
                    }
                    else
                    {
                        cmdSaveColor.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        private void ShowField<TControl>
        (
            Label labelControl,
            TControl fieldControl,
            Boolean show = true
        )
            where TControl : Control
        {
            try
            {
                labelControl.Visible = show;
                fieldControl.Visible = show;

            }
            catch (Exception ex)
            {
                Log.Write
                (
                    ex,
                    MethodBase.GetCurrentMethod(),
                    System.Diagnostics.EventLogEntryType.Error
                );
            }
        }

        /// <summary>
        /// Define buttons.
        /// </summary>
        private void ButtonsEnabled(Boolean enabledFlag)
        {
            try
            {
                //ButtonEnabled(enabledFlag, ref PreviousEnabledStateLoadData, cmdLoadData, menuFileLoadData);
                //ButtonEnabled(enabledFlag, ref PreviousEnabledStateClear, cmdClear, menuFileClear);
                //ButtonEnabled(enabledFlag, ref PreviousEnabledStateConvert, cmdConvert, menuEditConvert);

            }
            catch (Exception ex)
            {
                Log.Write
                (
                    ex,
                    MethodBase.GetCurrentMethod(),
                    System.Diagnostics.EventLogEntryType.Error
                );
                throw;
            }
        }

        /// <summary>
        /// Bind static Model controls to Model Controller
        /// </summary>
        private void BindFormUi()
        {
            try
            {
                //Form

                //_ValueChangedProgrammatically = true;

                this.bsEditionBindingSource.DataSource = VisualStudioEdition.VisualStudioEditions;
                this.bsEditionBindingSource.ResetBindings(false);

                this.bsVersionYearBindingSource.DataSource = VisualStudioVersion.VisualStudioVersions;
                this.bsVersionYearBindingSource.ResetBindings(false);

                //do 1st time (triggers setting of Title and RegistryPath)
                cboEdition.SelectedValue = VisualStudioEdition.REGISTRY_THEMES_EDITIONKEY_EXPRESSDESKTOP;
                cboYearVersion.SelectedValue = VisualStudioVersion.VISUALSTUDIO_VERSIONYEAR_2013;
                
                //Controls
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
            //finally
            //{
            //    _ValueChangedProgrammatically = false;
            //}
        }

        /// <summary>
        /// Bind Model controls to Model Controller
        /// </summary>
        private void BindModelUi()
        {
            try
            {
                //set themes; also need to clear themes if there is an error
                bsThemeBindingSource.DataSource = ModelController<ThemeEditorModel>.Model.Themes;
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }

        private void BindField<TControl, TModel>
        (
            TControl fieldControl,
            TModel model,
            String modelPropertyName,
            String controlPropertyName = "Text",
            Boolean formattingEnabled = false,
            DataSourceUpdateMode dataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged,
            Boolean reBind = true
        )
            where TControl : Control
        {
            try
            {
                fieldControl.DataBindings.Clear();
                if (reBind)
                {
                    fieldControl.DataBindings.Add(controlPropertyName, model, modelPropertyName, formattingEnabled, dataSourceUpdateMode);
                }
            }
            catch (Exception ex)
            {
                Log.Write
                (
                    ex,
                    MethodBase.GetCurrentMethod(),
                    System.Diagnostics.EventLogEntryType.Error
                );
            }
        }

        /// <summary>
        /// Apply Settings to viewer.
        /// </summary>
        private void ApplySettings()
        {
            try
            {
                _ValueChangedProgrammatically = true;

                //apply settings that have databindings
                BindModelUi();

                //apply settings that shouldn't use databindings

                //apply settings that can't use databindings
                Text = String.Format("{0} - {1} - {2}", Path.GetFileName(SettingsController<ThemeEditorSettings>.Filename), ViewModel.BuildThemeEditorViewTitle(), ViewName);  

                //apply settings that don't have databindings
                ViewModel.DirtyIconIsVisible = (SettingsController<ThemeEditorSettings>.Settings.Dirty);

                _ValueChangedProgrammatically = false;
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }

        /// <summary>
        /// Set function selectColorButton and menu to enable value, and cancel selectColorButton to opposite.
        /// For now, do only disabling here and leave enabling based on biz logic 
        ///  to be triggered by refresh?
        /// </summary>
        /// <param name="functionButton"></param>
        /// <param name="functionMenu"></param>
        /// <param name="cancelButton"></param>
        /// <param name="enable"></param>
        private void SetFunctionControlsEnable
        (
            Button functionButton,
            ToolStripButton functionToolbarButton,
            ToolStripMenuItem functionMenu,
            Button cancelButton,
            Boolean enable
        )
        {
            try
            {
                //stand-alone selectColorButton
                if (functionButton != null)
                {
                    functionButton.Enabled = enable;
                }

                //toolbar selectColorButton
                if (functionToolbarButton != null)
                {
                    functionToolbarButton.Enabled = enable;
                }

                //menu item
                if (functionMenu != null)
                {
                    functionMenu.Enabled = enable;
                }

                //stand-alone cancel selectColorButton
                if (cancelButton != null)
                {
                    cancelButton.Enabled = !enable;
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        /// <summary>
        /// Invoke any delegate that has been registered 
        ///  to cancel a long-running background process.
        /// </summary>
        private void InvokeActionCancel()
        {
            try
            {
                //execute cancellation hook
                if (cancelDelegate != null)
                {
                    cancelDelegate();
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        /// <summary>
        /// Load from app config; override with command line if present
        /// </summary>
        /// <returns></returns>
        private Boolean LoadParameters()
        {
            Boolean returnValue = default(Boolean);
#if USE_CONFIG_FILEPATH
            String _settingsFilename = default(String);
#endif

            try
            {
                if ((Program.Filename != null) && (Program.Filename != SettingsController<ThemeEditorSettings>.FILE_NEW))
                {
                    //got filename from command line
                    //DEBUG:filename coming in is being converted/passed as DOS 8.3 format equivalent
                    if (!RegistryAccess.ValidateFileAssociation(Application.ExecutablePath, "." + SettingsBase.FileTypeExtension))
                    {
                        throw new ApplicationException(String.Format("Settings filename not associated: '{0}'.\nCheck filename on command line.", Program.Filename));
                    }
                    //it passed; use value from command line
                }
                else
                {
#if USE_CONFIG_FILEPATH
                    //get filename from app.config
                    if (!Configuration.ReadString("SettingsFilename", out _settingsFilename))
                    {
                        throw new ApplicationException(String.Format("Unable to load SettingsFilename: {0}", "SettingsFilename"));
                    }
                    if ((_settingsFilename == null) || (_settingsFilename == SettingsController<ThemeEditorSettings>.FILE_NEW))
                    {
                        throw new ApplicationException(String.Format("Settings filename not set: '{0}'.\nCheck SettingsFilename in app config file.", _settingsFilename));
                    }
                    //use with the supplied path
                    SettingsController<ThemeEditorSettings>.Filename = _settingsFilename;

                    if (Path.GetDirectoryName(_settingsFilename) == String.Empty)
                    {
                        //supply default path if missing
                        SettingsController<ThemeEditorSettings>.Pathname = Environment.GetFolderPath(Environment.SpecialFolder.Personal).WithTrailingSeparator();
                    }
#endif
                }

                returnValue = true;
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                //throw;
            }
            return returnValue;
        }

        private void BindSizeAndLocation()
        {
            //Note:Size must be done after InitializeComponent(); do Location this way as well.--SJS
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::ThemeEditor.Properties.Settings.Default, "Location", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("ClientSize", global::ThemeEditor.Properties.Settings.Default, "Size", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ClientSize = global::ThemeEditor.Properties.Settings.Default.Size;
            this.Location = global::ThemeEditor.Properties.Settings.Default.Location;
        }
        #endregion Utility
        #endregion Methods
    }
}
