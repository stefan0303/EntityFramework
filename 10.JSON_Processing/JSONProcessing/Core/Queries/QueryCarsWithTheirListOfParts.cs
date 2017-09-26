using JSONProcessing.Common;
using JSONProcessing.Services;
using JSONProcessing.Services.CarDealer;
using Ninject;
using System.Collections.Generic;

namespace JSONProcessing.Core.Queries
{
    class QueryCarsWithTheirListOfParts : Query
    {
        public override IEnumerable<object> ExportData { get; set; }

        private readonly ICarService _carService;

        public QueryCarsWithTheirListOfParts()
        {
            _carService = NinjectCommon.Kernel.Get<CarService>();
        }
        public override string Execute()
        {
            var carsWithTheirListOfPartsDto = _carService.CarsWithTheirListOfParts();
            ExportData = carsWithTheirListOfPartsDto;

            return string.Join("\n---------------------\n", carsWithTheirListOfPartsDto);
        }

        public override void Export()
        {
            Exporter.Export(this);
        }
    }
}
