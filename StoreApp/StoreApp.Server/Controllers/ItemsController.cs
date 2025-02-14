using Microsoft.AspNetCore.Mvc;
using StoreApp.Server.Services;  // Примерный путь к сервису для получения данных

namespace StoreApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var items = _itemService.GetItems();
            return Ok(items);
        }
    }
}
