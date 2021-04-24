using DbCommunicationLib;

namespace IoTWorkerService.ModelControllers
{
    class ModelControllerBase
    {
        protected HomeAutomationContext DbContext { get; private init; }

        protected ModelControllerBase(HomeAutomationContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
