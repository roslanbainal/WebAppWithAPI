using System.Threading.Tasks;
using WebAppWithAPI.Models.ViewModels;

namespace WebAppWithAPI.Infrastructures.Interfaces
{
    public interface IPoskodService
    {
        Task<FullPoskodViewModel> GetPoskod(PoskodRequest request);
    }
}
