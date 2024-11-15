using CommunityToolkit.Maui.Storage;
using System.Text;

namespace Lab
{
    class FileSystem
    {
        IFileSaver fileSaver;
        CancellationTokenSource cancellationTokenSource;

        public FileSystem(IFileSaver fileSaver)
        {
            this.fileSaver = fileSaver;
            cancellationTokenSource = new();
        }

        public async Task<string> LoadAsync()
        {
            var customFileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
            {
                {DevicePlatform.Unknown, new[] {".xml"} },
                {DevicePlatform.WinUI, new[] { ".xml" } },
                {DevicePlatform.iOS, new[] {".xml" } },
                {DevicePlatform.Android, new[] {".xml" } }
            });

            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Pick xml",
                FileTypes = customFileType
            });

            if (result == null) {
                throw new Exception("Файл не обрано!");
            }

            using var stream = await result.OpenReadAsync();
            using var reader = new StreamReader(stream);

            string content = await reader.ReadToEndAsync();

            return content;
        }

    }
}
