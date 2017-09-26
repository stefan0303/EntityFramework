using JSONProcessing.Common;
using JSONProcessing.Services;
using JSONProcessing.Services.CarDealer;
using Ninject;
using System.Collections.Generic;

namespace JSONProcessing.Core.Queries
{
    class QueryCarsFromMakeToyota : Query
    {
        public override IEnumerable<object> ExportData { get; set; }

        private readonly ICarService _carService;

        public QueryCarsFromMakeToyota()
        {
            _carService = NinjectCommon.Kernel.Get<CarService>();
        }

        public override string Execute()
        {
            var carsFromMakeToyota = _carService.CarsFromMakeToyota();
            ExportData = carsFromMakeToyota;

            return string.Join("\n---------------------\n", carsFromMakeToyota);
        }

        public override void Export()
        {
            Exporter.Export(this);
        }


    }
}
