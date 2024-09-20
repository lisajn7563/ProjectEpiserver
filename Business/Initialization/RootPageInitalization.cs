using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Initialization;
using EPiServer.ServiceLocation;
using Nackademin_Episerver.Models.Pages;

namespace Nackademin_Episerver.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(CmsCoreInitialization))]
    public class RootPageInitalization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            var contentTypePepository = context.Locate.Advanced.GetInstance<IContentTypeRepository>();
            var sysRoot = contentTypePepository.Load("SysRoot") as PageType;
            var setting = new AvailableSetting { Availability = Availability.Specific };

            setting.AllowedContentTypeNames.Add(contentTypePepository.Load<StartPage>().Name);
            
            var availableSettingsRepository = context.Locate.Advanced.GetInstance<IAvailableSettingsRepository>();
            availableSettingsRepository.RegisterSetting(sysRoot, setting);
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}
