namespace FabricAPI.dto
{
    public class Cell
    {
        private static readonly int MAX_ITEMS = 10;
        private int contentCount;
        private HashSet<string> cellTypes;
        private int row;
        private int column;

        public Cell(int row, int column)
        {
            contentCount = 0;
            this.row = row;
            this.column = column;
        }

        public int GetContentCount()
        {
            return contentCount;
        }
        public void AddToCell(int quantity)
        {
            if (contentCount + quantity <= MAX_ITEMS)
            {
                contentCount += quantity;
            }                
        }
        public bool HasRoom(int quantity)
        {
            return contentCount + quantity <= MAX_ITEMS;
        }
        public HashSet<string> GetCellTypes()
        {
            return cellTypes;
        }
        public void AddCellType(string cellType)
        {
            cellTypes.Add(cellType);
        }
        public bool IsCellHazard()
        {
            return cellTypes.Contains(Strings.HAZARD);
        }
        public bool IsCellChill()
        {
            return cellTypes.Contains(Strings.CHILLED);
        }
        public string GetCellLocation()
        {
            return $"{row}, {column}";
        }
    }
}
