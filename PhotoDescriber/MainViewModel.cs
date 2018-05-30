using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Xamarin.Forms;

namespace PhotoDescriber
{
    public class MainViewModel : INotifyPropertyChanged
    {
        ComputerVisionAPI _visionApi;
        
        public MainViewModel()
        {
            TakePhotoCommand = new Command(async () => await TakePhoto());

            var creds = new ApiKeyServiceClientCredentials("<your key here>");
            _visionApi = new ComputerVisionAPI(creds)
            {
                AzureRegion = AzureRegions.Westeurope
            };
        }

        async Task TakePhoto()
        {
            var opts = new Plugin.Media.Abstractions.StoreCameraMediaOptions();
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(opts);

            Image = ImageSource.FromStream(() => photo.GetStream());

            var d = await _visionApi.DescribeImageInStreamAsync(photo.GetStream());
            Caption = d.Captions.FirstOrDefault().Text;
        }

        string _caption;
        public string Caption
        {
            get => _caption;
            set
            {
                _caption = value;
                PropertyChanged?.Invoke(this,
                                        new PropertyChangedEventArgs(nameof(Caption)));

            }
        }

        ImageSource _image;
        public ImageSource Image
        {
            get => _image;
            set
            {
                _image = value;
                PropertyChanged?.Invoke(this,
                                        new PropertyChangedEventArgs(nameof(Image)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand TakePhotoCommand { get; }
    }
}
