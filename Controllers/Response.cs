namespace FabricAPI.Controllers
{
    public class Response
    {
        public bool foundCell;
        public string? cell;

        public Response(bool foundCell, string? cell = null)
        {
            this.foundCell = foundCell;
            this.cell = cell;
        }
    }
}
