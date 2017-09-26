using JSONProcessing.Data.CarDealer;
using JSONProcessing.Models.CarDealer;
using Ninject;
using System.Linq;

namespace JSONProcessing.Services.CarDealer
{
    class PartService : IPartService
    {
        private readonly ICarDealerContext _carDealerContext;

        public PartService()
        {
            _carDealerContext = NinjectCommon.Kernel.Get<CarDealerContext>();
        }

        public IQueryable<Part> GetAllParts()
        {
            return _carDealerContext.Parts;
        }
    }
}
