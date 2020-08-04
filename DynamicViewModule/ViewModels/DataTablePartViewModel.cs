using OrchardCore.DisplayManagement.Views;

namespace DynamicViewModule.ViewModels
{
    public class DataTablePartViewModel : ShapeViewModel
    {
        public string JsonData { get; set; }

        public string Heading { get; set; }

        public string DisplayType { get; set; }

        public DataTablePartViewModel(string shapeType) : base(shapeType: shapeType)
        {

        }
        public DataTablePartViewModel()
        {
            //this defines the template
            //for this example it will look for DataTableShape.cshtml or DataTableShape.liquid
            this.Metadata.Type = "DataTableShape";
        }

        public string DisplayMode
        {
            get
            {
                return Metadata.DisplayType;
            }
            set
            {
                //this is to toggle between ALTERNATE fields.
                //e.g. DataTableShape.Edit
                //e.g  DataTableShape.Create
                var alternate = $"DataTableShape_{value}";
                if (Metadata.Alternates.Contains(alternate))
                {
                    if (Metadata.Alternates.Last == alternate)
                    {
                        return;
                    }

                    Metadata.Alternates.Remove(alternate);
                }

                Metadata.Alternates.Add(alternate);
                Metadata.DisplayType = value;
            }
        }
    }
}
