﻿using System.Windows.Forms;
using osu_StreamCompanion.Code.Core;
using osu_StreamCompanion.Code.Interfeaces;
using osu_StreamCompanion.Code.Modules.osuPathReslover;

namespace osu_StreamCompanion.Code.Modules.FileSaveLocation
{
    class FileSaveLocation : IModule, ISettingsProvider,ISaveRequester
    {
        private FileSaveLocationSettings _fileSaveLocationSettings;
        private ISaver _saver;

        public bool Started { get; set; }
        public void Start(ILogger logger)
        {
            Started = true;
        }

        public string SettingGroup { get; } = "General";
        public void SetSettingsHandle(Settings settings)
        {
        }

        public void Free()
        {
            _fileSaveLocationSettings.Dispose();
        }

        public UserControl GetUiSettings()
        {
            if (_fileSaveLocationSettings == null || _fileSaveLocationSettings.IsDisposed)
            {
                _fileSaveLocationSettings = new FileSaveLocationSettings();
                _fileSaveLocationSettings.SetSaveHandle(_saver);
            }
            return _fileSaveLocationSettings;
        }

        public void SetSaveHandle(ISaver saver)
        {
            _saver = saver;
        }
    }
}
