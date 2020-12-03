using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
//using System.Windows;
using System.Windows.Forms;
//using System.Windows.Controls;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
using Ssepan.Utility;
using Ssepan.Application;
using Ssepan.Application.WinForms;
using Ssepan.Io;
using ThemeEditorLibrary;

namespace ThemeEditor
{
    /// <summary>
    /// Note: this class can subclass the base without type parameters.
    /// </summary>
    public class ThemeEditorViewModel :
        FormsViewModel<Bitmap, ThemeEditorSettings, ThemeEditorModel, ThemeEditorView>
    {
        #region Declarations
        public const String VIEW_TITLE_FORMAT = "{0} {1}";

        #region Commands
        //public ICommand FileNewCommand { get; private set; }
        //public ICommand FileOpenCommand { get; private set; }
        //public ICommand FileSaveCommand { get; private set; }
        //public ICommand FileSaveAsCommand { get; private set; }
        //public ICommand FilePrintCommand { get; private set; }
        //public ICommand FileExitCommand { get; private set; }
        //public ICommand EditCopyToClipboardCommand { get; private set; }
        //public ICommand EditPropertiesCommand { get; private set; }
        //public ICommand ViewPreviousMonthCommand { get; private set; }
        //public ICommand ViewPreviousWeekCommand { get; private set; }
        //public ICommand ViewNextWeekCommand { get; private set; }
        //public ICommand ViewNextMonthCommand { get; private set; }
        //public ICommand HelpAboutCommand { get; private set; }
        #endregion Commands
        #endregion Declarations

        #region Constructors
        public ThemeEditorViewModel() { }//Note: not called, but need to be present to compile--SJS

        public ThemeEditorViewModel
        (
            PropertyChangedEventHandler propertyChangedEventHandlerDelegate,
            Dictionary<String, Bitmap> actionIconImages,
            FileDialogInfo settingsFileDialogInfo
        ) :
            base(propertyChangedEventHandlerDelegate, actionIconImages, settingsFileDialogInfo)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }
        #endregion Constructors

        #region Properties
        #endregion Properties

        #region Methods
        /// <summary>
        /// Creates and adds data to view model
        /// </summary>
        /// <param name="errorMessage"></param>
        internal void LoadThemes
        (
        )
        {
            String errorMessage = default(String);
            try
            {
                StartProgressBar("Loading themes...", null, _actionIconImages["Open"], false, 0);

                ModelController<ThemeEditorModel>.Model.Themes = ThemeInfo.ReadThemes(ModelController<ThemeEditorModel>.Model, ref errorMessage);
                if (errorMessage != null)
                {
                    throw new ApplicationException(errorMessage);
                }

                StopProgressBar("Themes loaded.");
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        /// <summary>
        /// Returns a title for a given edition and version.
        /// </summary>
        /// <returns></returns>
        internal String BuildThemeEditorViewTitle
        (
        )
        {
            String returnValue = default(String);
            try
            {
                returnValue =
                    String.Format
                    (
                        VIEW_TITLE_FORMAT,
                        (ModelController<ThemeEditorModel>.Model.Edition == null ? null : ModelController<ThemeEditorModel>.Model.Edition.EditionName),
                        (ModelController<ThemeEditorModel>.Model.Version == null ? null : ModelController<ThemeEditorModel>.Model.Version.VersionYear)
                    );
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
            return returnValue;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void BackupTheme_Click()
        {
            String errorMessage = default(String);
            String filePath = default(String);

            try
            {
                StartProgressBar(String.Format("Backing up theme ..."), null, _actionIconImages["Save"], true, 33);

                filePath = ThemeInfo.BuildExportFilename(ModelController<ThemeEditorModel>.Model);

                if
                (
                    !Dialogs.GetFileSavePath
                    (
                        new String[] { filePath },
                        ref filePath,
                        ref errorMessage,
                        title: ThemeEditorModel.DIALOGTITLE_BACKUP,
                        defaultExtension: ThemeInfo.EXTENSION_REGISTRYKEY,
                        initialDirectory: Environment.CurrentDirectory
                    )
                )
                {
                    StopProgressBar("Theme backup cancelled.", null);
                    return;
                }
                else
                {
                    ThemeInfo.BackupTheme(filePath, ModelController<ThemeEditorModel>.Model);

                    StopProgressBar("Theme backup complete.", null);
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void ResetTheme_Click()
        {
            String errorMessage = default(String);
            String filePath = default(String);

            try
            {
                StartProgressBar("Resetting theme ...", null, _actionIconImages["New"], true, 33);

                if (MessageBox.Show(ThemeEditorModel.DIALOGMESSAGE, ThemeEditorModel.DIALOGTITLE_RESET, MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    StopProgressBar("Theme reset cancelled.", null);
                    return;
                }
                else
                {
                    filePath = ThemeInfo.BuildImportFilename(ModelController<ThemeEditorModel>.Model);
                    //Load .REG file containing theme info into registry
                    if (!ThemeInfo.ResetTheme(filePath, ref errorMessage))
                    {
                        throw new ApplicationException(errorMessage);
                    }

                    //Read themes from registry into model
                    LoadThemes();

                    StopProgressBar("Theme reset completed.", null);
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void SelectColor_Click(Button selectColorButton, Button saveColorButton, String description)
        {
            Color color = default(Color);

            try
            {
                StartProgressBar(String.Format("Selecting {0} color ...", description), null, null/*_actionIconImages["New"]*/, true, 33);

                color = selectColorButton.BackColor;

                if (Dialogs.GetColor(ref color))
                {
                    selectColorButton.BackColor = color;
                    saveColorButton.Enabled = true;

                    StopProgressBar(String.Format("{0} color selected.", description), null);
                }
                else
                {
                    StopProgressBar(String.Format("{0} color selection cancelled.", description), null);
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
           }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void SaveColor_Click(Button selectForegroundColorButton, Button selectBackgroundColorButton, Button saveColorButton)
        {
            String errorMessage = default(String);

            try
            {
                StartProgressBar(String.Format("Saving color to list ..."), null, _actionIconImages["Save"], true, 33);

                if
                (
                    !ModelController<ThemeEditorModel>.Model.SaveColor
                    (
                        (selectForegroundColorButton.Enabled ? (Color?)selectForegroundColorButton.BackColor : null),
                        (selectBackgroundColorButton.Enabled ? (Color?)selectBackgroundColorButton.BackColor : null),
                        ref errorMessage
                    )
                )
                {
                    throw new ApplicationException(errorMessage);
                }

                saveColorButton.Enabled = false;

                StopProgressBar("Color saved to list.", null);
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
        }
        #endregion Methods

    }
}
