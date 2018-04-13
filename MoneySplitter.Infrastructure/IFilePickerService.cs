using MoneySplitter.Models.App;
using System.Threading.Tasks;

namespace MoneySplitter.Infrastructure
{
    public interface IFilePickerService
    {
        Task<FileImageModel> BrowseImageAsync();
    }
}
