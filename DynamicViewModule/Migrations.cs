using DynamicViewModule.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace DynamicViewModule.Migrations
{
    public class Migrations : DataMigration
    {
        private IContentDefinitionManager _contentDefinitionManager;

        public Migrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public int Create()
        {
            _contentDefinitionManager.AlterPartDefinition(nameof(DataTablePart), part => part
            .WithDescription("Provides input field properties with additional extensions."));

            _contentDefinitionManager.AlterTypeDefinition($"DatatableWidget", type => type
                .WithPart("FormInputElementPart")
                .WithPart("FormElementPart")
                .WithPart(nameof(DataTablePart))
                .Stereotype("Widget"));
            return 1;
        }
    }
}
