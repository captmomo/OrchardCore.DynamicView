using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicViewModule.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display;
using OrchardCore.DisplayManagement;
using OrchardCore.DisplayManagement.ModelBinding;

namespace Module1.Controllers
{
    [IgnoreAntiforgeryToken, AllowAnonymous]
    public class HomeController : Controller
    {
        private dynamic _shape;

        private readonly IContentManager _contentManager;
        private readonly IUpdateModelAccessor _updateModelAccessor;
        private readonly IContentItemDisplayManager _contentItemDisplayManager;
        public HomeController(
            IShapeFactory shapeFactory,
            IContentManager contentManager,
            IUpdateModelAccessor updateModelAccessor,
            IContentItemDisplayManager contentItemDisplayManager)
        {
            _contentManager = contentManager;
            _updateModelAccessor = updateModelAccessor;
            _contentItemDisplayManager = contentItemDisplayManager;
            _shape = shapeFactory;
        }
        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> FormTableAsync(string jsonData)
        {
            ContentItem contentItem = await _contentManager.NewAsync("DatatableWidget");

            // EXPLICIT syntax
            DataTablePart testPart = contentItem.As<DataTablePart>();
            testPart.JsonData = jsonData;
            contentItem.Apply(testPart);

            await _contentManager.CreateAsync(contentItem);
            //do create here
            //send contentitemid
            return RedirectToAction("Display",
                "Home",
                new
                {
                    area = "DynamicViewModule",
                    contentItemId = contentItem.ContentItemId
                });
        }
        [HttpPost]
        public async Task<IActionResult> TableAsync([FromBody] DataTablePart part)
        {

            ContentItem contentItem = await _contentManager.NewAsync("DatatableWidget");
            // EXPLICIT syntax
            DataTablePart testPart = contentItem.As<DataTablePart>();
            testPart.JsonData = part.JsonData;
            contentItem.Apply(testPart);
            try
            {
                await _contentManager.CreateAsync(contentItem);
                //do create here
                //send contentitemid
                ContentResult result = new ContentResult
                {
                    ContentType = "application/json"
                };
                //result.Content = System.Text.Json.JsonSerializer.Serialize(new { result = contentItem.ContentItemId });
                //result.StatusCode = 200;
                //return result;
                return Ok(contentItem.ContentItemId);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.GetBaseException().Message);
            }

        }

        [HttpPost]
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public IActionResult Test(string hello)
        {
            return Ok(hello);
        }
        public async Task<IActionResult> DisplayAsync([FromQuery]string contentItemId)
        {

            ContentItem contentItem = await _contentManager.GetAsync(contentItemId);


            IShape model = await _contentItemDisplayManager
                .BuildDisplayAsync(contentItem,
                _updateModelAccessor.ModelUpdater);

            return View(model);
        }

    }
}
