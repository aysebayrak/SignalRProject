using BusinessLayer.Abstract;
using DtoLayer.MenuTableDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuTablesController : ControllerBase
	{
		private readonly IMenuTableService _menuTableService;

		public MenuTablesController(IMenuTableService menuTableService)
		{
			_menuTableService = menuTableService;
		}

		[HttpGet("MenuTableCount")]

		public IActionResult MenuTableCount()
		{
		   return Ok(	_menuTableService.TMenuTableCount());
		}


        [HttpGet]
        public IActionResult MenuTableList()
        {
            var values = _menuTableService.TGetListAll();
            return Ok(values);
        }


        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            MenuTable menuTable = new MenuTable()
            {
               MenuTableName = createMenuTableDto.MenuTableName,
               MenuTableStatus = false

            };
            _menuTableService.TAdd(menuTable);
            return Ok("masa  başarılı bir şekilde eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            _menuTableService.TDelete(value);
            return Ok("masa Silindi");

        }

        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            MenuTable menuTable = new MenuTable()
            {
                MenuTableId = updateMenuTableDto.MenuTableId,
                MenuTableName = updateMenuTableDto.MenuTableName,
                MenuTableStatus = updateMenuTableDto.MenuTableStatus
            };
            _menuTableService.TUpdate(menuTable);
            return Ok("Masa Güncellendi");

        }

        [HttpGet("{id}")]

        public IActionResult GetMenuTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            return Ok(value);
        }
    }
}
