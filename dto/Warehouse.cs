namespace FabricAPI.dto
{
    public class Warehouse
    {
        private readonly Cell[,] cells = new Cell[10, 10];
        private readonly HashSet<Cell> chillCells = new HashSet<Cell>();
        private readonly HashSet<Cell> hazardCells = new HashSet<Cell>();
        private readonly HashSet<Cell> chillHazardCells = new HashSet<Cell>();
        private readonly HashSet<Cell> regularCells = new HashSet<Cell>();
        public Warehouse() { 
            for (int i = 0; i < 10; i++)
            {
                for (int j =  0; j < 10; j++)
                {
                    cells[i, j] = new Cell(i,j);
                    regularCells.Add(cells[i, j]);
                }
            }
            InitChillCells();
            InitHazardCells();
            InitChillHazardCells();
        }

        private void InitHazardCells()
        {
            for (int j=0; j < 10; j++)
            {
                cells[9, j].AddCellType(Strings.HAZARD);
                hazardCells.Add(cells[9, j]);
                regularCells.Remove(cells[9, j]);
            }
        }
        private void InitChillCells()
        {
            for (int i=7; i<10; i++)
            {
                for (int j=7; j<10; j++)
                {
                    cells[i, j].AddCellType(Strings.CHILLED);
                    chillCells.Add(cells[i, j]);
                    regularCells.Remove(cells[i, j]);
                }
            }
        }
        private void InitChillHazardCells()
        {
            for (int i = 7; i<10; i++)
            {
                chillHazardCells.Add(cells[i, 9]);
            }
        }

        public HashSet<Cell> GetHazardCells()
        {
            return hazardCells;
        }
        public HashSet<Cell> GetChillCells()
        {
            return chillCells;
        }
        public HashSet<Cell> GetChillHazardCells()
        {
            return chillHazardCells;
        }
        public HashSet<Cell> GetRegularCells()
        {
            return regularCells;
        }
    }
}
