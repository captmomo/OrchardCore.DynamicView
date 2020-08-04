using OrchardCore.ResourceManagement;

namespace DynamicViewModule
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(IResourceManifestBuilder builder)
        {
            OrchardCore.ResourceManagement.ResourceManifest manifest = builder.Add();

            manifest
                .DefineScript("DataTableJs")
                .SetUrl(
                "~/DynamicViewModule/Resources/datatables.min.js",
                "~/DynamicViewModule/Resources/datatables.js")
                .SetCdn(
                "https://cdn.datatables.net/v/dt/dt-1.10.21/af-2.3.5/b-1.6.2/datatables.min.js");

            manifest
                .DefineScript("jQuery")
                .SetUrl("~/DynamicViewModule/Resources/jquery-3.5.1.min.js")
                .SetVersion("3.5.1");

            manifest
                .DefineStyle("DataTableCss")
                .SetUrl(
                "~/DynamicViewModule/Resources/datatables.min.css",
                "~/DynamicViewModule/Resources/datatables.css")
                .SetCdn(
                "https://cdn.datatables.net/v/dt/dt-1.10.21/af-2.3.5/b-1.6.2/datatables.min.css");

            manifest
                .DefineScript("TableInitJs")
                .SetUrl("~/DynamicViewModule/Resources/table-init.Js");

            manifest
                .DefineStyle("BulmaCss")
                .SetUrl("~/DynamicViewModule/Resources/bulma/css/bulma.min.css");

        }
    }
}
