using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace LylBoilerPlate.Localization
{
    public static class LylBoilerPlateLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(LylBoilerPlateConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(LylBoilerPlateLocalizationConfigurer).GetAssembly(),
                        "LylBoilerPlate.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
