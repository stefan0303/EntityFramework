using JSONProcessing.Models.CarDealer;
using System.Linq;

namespace JSONProcessing.Services.CarDealer
{
    public interface IPartService
    {
        IQueryable<Part> GetAllParts();
    }
}