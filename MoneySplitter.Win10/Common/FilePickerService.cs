using MoneySplitter.Infrastructure;
using MoneySplitter.Models.App;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage.Pickers;

namespace MoneySplitter.Win10.Common
{
    public class FilePickerService : IFilePickerService
    {
        FileOpenPicker _picker;

        public FilePickerService()
        {
            InitializePicker();
        }

        private void InitializePicker()
        {
            _picker = new FileOpenPicker()
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.PicturesLibrary
            };

            _picker.FileTypeFilter.Add(Defines.ImageExtension.JPG);
            _picker.FileTypeFilter.Add(Defines.ImageExtension.JPEG);
            _picker.FileTypeFilter.Add(Defines.ImageExtension.PNG);
        }

        public async Task<FileImageModel> BrowseImageAsync()
        {
            var file = await _picker.PickSingleFileAsync();

            if (file != null)
            {
                var stream = await file.OpenStreamForReadAsync();
                var bytes = new byte[(int)stream.Length];
                stream.Read(bytes, 0, (int)stream.Length);

                return new FileImageModel
                {
                    Base64StringImage = Convert.ToBase64String(bytes),
                    ImageName = file.Name
                };
            }

            else return null;
        }
    }
}
