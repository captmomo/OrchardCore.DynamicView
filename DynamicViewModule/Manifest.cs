using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "DynamicViewModule",
    Author = "Captmomo",
    Website = "https://github.com/captmomo",
    Version = "0.0.1",
    Description = "Module to render views with dynamic content",
    Category = "Content",
     Dependencies = new[] { "OrchardCore.Widgets", "OrchardCore.Flows" }
)]
