using JSONProcessing.Common;
using JSONProcessing.Core;
using JSONProcessing.Services;

namespace JSONProcessing
{
    class Startup
    {
        static void Main()
        {
            NinjectCommon.InitializeKernel();
            AutoMapperCommon.InitializeMapper();
            Engine.Run();
        }
    }
}
