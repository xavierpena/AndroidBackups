using AndroidBackups.UI.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AndroidBackups.UI.ViewModels
{
    public class BackuperViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IList<SourceFolder> _sourceFolders;
        public IList<SourceFolder> SourceFolders
        {
            get { return _sourceFolders; }
            set
            {
                if (_sourceFolders != value)
                {
                    _sourceFolders = value;
                    OnPropertyChanged(nameof(SourceFolders));
                }
            }
        }

        private ICommand _openConfigurationFileCommand;
        public ICommand OpenConfigurationFileCommand { get { return _openConfigurationFileCommand; } }

        public BackuperViewModel()
        {
            InitSourceFolders();

            // Delegates:
            //_openConfigurationFileCommand = new DelegateCommand(() => _episodeRepository.OpenConfigurationFile());
        }

        private void InitSourceFolders()
        {
            var souceFolderFullPaths = new string[] {
                @"This PC\XT1068\Internal storage\WhatsApp\Media\WhatsApp Images",
                @"This PC\XT1068\Internal storage\WhatsApp\Media\WhatsApp Video",
                @"This PC\XT1068\Internal storage\DCIM\Camera"
            };
            this.SourceFolders = new List<SourceFolder>();
            foreach (var sourceFolderFullPath in souceFolderFullPaths)
            {
                var sourceFolder = new SourceFolder(sourceFolderFullPath);
                this.SourceFolders.Add(sourceFolder);
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
