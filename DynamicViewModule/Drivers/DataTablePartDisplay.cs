using System.Threading.Tasks;
using DynamicViewModule.Models;
using DynamicViewModule.ViewModels;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;

namespace DynamicViewModule.Drivers
{
    public class DataTablePartDisplay : ContentPartDisplayDriver<DataTablePart>
    {
        public override IDisplayResult Display(DataTablePart part)
        {
            return View(nameof(DataTablePart), part).Location("Detail", "Content");
        }

        public override IDisplayResult Edit(DataTablePart part)
        {
            return Initialize<DataTablePartViewModel>($"{nameof(DataTablePart)}_Fields_Edit", m =>
            {
                m.JsonData = part.JsonData;
            });
        }

        public async override Task<IDisplayResult> UpdateAsync(DataTablePart part, IUpdateModel updater)
        {
            DataTablePartViewModel viewModel = new DataTablePartViewModel();

            if (await updater.TryUpdateModelAsync(viewModel, Prefix))
            {

                part.JsonData = viewModel.JsonData;
            }

            return Edit(part);
        }
    }
}
