using FabricAPI.dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FabricAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WarehouseController : ControllerBase
    {                
        private ProductTypes productTypes = new ProductTypes();
        private Warehouse warehouse = new Warehouse();

        
        private readonly ILogger<WarehouseController> _logger;

        public WarehouseController(ILogger<WarehouseController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "allocateCell")]
        public Response Post(string productId, int quantity)
        {
            string[] newProductTypes = productTypes.GetProductType(productId);
            if (newProductTypes.Contains(Strings.INVALID))
            {
                return new Response(false);
            }

            if (newProductTypes.Contains(Strings.CHILLED))
            {
                if (newProductTypes.Contains(Strings.HAZARD))
                {
                    var chillHazardCells = warehouse.GetChillHazardCells();
                    return AllocateSpecialCells(chillHazardCells, quantity);

                }
                var chillCells = warehouse.GetChillCells();
                return AllocateSpecialCells(chillCells, quantity);
            }
            if (newProductTypes.Contains(Strings.HAZARD))
            {
                var hazardCells = warehouse.GetHazardCells();
                return AllocateSpecialCells(hazardCells, quantity);
            }
            return AllocateRegularCell(warehouse, quantity);
        }

        public Response AllocateSpecialCells(HashSet<Cell> cells, int quantity)
        {
            foreach (var cell in cells)
            {
                if (cell.HasRoom(quantity))
                {
                    cell.AddToCell(quantity);
                    return new Response(true, cell.GetCellLocation());
                }
            }
            return new Response(false);
        }

        public Response AllocateRegularCell(Warehouse warehouse, int quantity)
        {
            var regularCells = warehouse.GetRegularCells();
            foreach (var cell in regularCells)
            {
                if (cell.HasRoom(quantity))
                {
                    cell.AddToCell(quantity);
                    return new Response(true, cell.GetCellLocation());
                }
            }
            HashSet<Cell> specialCells = new HashSet<Cell>();
            specialCells.UnionWith(warehouse.GetChillCells());
            specialCells.UnionWith(warehouse.GetHazardCells());
            specialCells.UnionWith(warehouse.GetChillHazardCells());

            return AllocateSpecialCells(specialCells, quantity);
        }
    }
}