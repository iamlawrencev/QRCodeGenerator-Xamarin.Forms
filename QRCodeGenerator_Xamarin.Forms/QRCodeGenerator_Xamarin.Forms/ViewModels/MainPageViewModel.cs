using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using QRCoder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace QRCodeGenerator_Xamarin.Forms.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            ConvertCommand = new DelegateCommand(Convert);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            PopulateECCLevels();
        }

        public DelegateCommand ConvertCommand { get; set; }

        List<QRCodeGenerator.ECCLevel> _eccLevels;
        public List<QRCodeGenerator.ECCLevel> ECCLevels
        {
            get => _eccLevels;
            set => SetProperty(ref _eccLevels, value);
        }

        QRCodeGenerator.ECCLevel _selectedECCLevel;
        public QRCodeGenerator.ECCLevel SelectedECCLevel
        {
            get => _selectedECCLevel;
            set => SetProperty(ref _selectedECCLevel, value);
        }

        ImageSource _qrCodeImage;
        public ImageSource QrCodeImage
        {
            get => _qrCodeImage;
            set => SetProperty(ref _qrCodeImage, value);
        }

        string _inputText;
        public string InputText
        {
            get => _inputText;
            set => SetProperty(ref _inputText, value);
        }

        void Convert()
        {
            if (string.IsNullOrEmpty(InputText))
                InputText = "";

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(InputText, SelectedECCLevel);
            PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeBytes = qRCode.GetGraphic(20);
            QrCodeImage = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
        }

        void PopulateECCLevels()
        {
            ECCLevels = Enum.GetValues(typeof(QRCodeGenerator.ECCLevel)).OfType<QRCodeGenerator.ECCLevel>().ToList();
        }
    }
}
