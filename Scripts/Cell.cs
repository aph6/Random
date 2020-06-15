using UnityEngine;

public enum CellState { Empty, UpWind, DownWind, LeftWind, RightWind, Whirlpool, SmallRock, LargeRock }

public class Cell
{
    public bool isTaken { get; private set; }
    public CellState cellState { get; private set; }

    public Cell()
    {
        isTaken = false;
        cellState = CellState.Empty;
    }
    public Cell(CellState cellState)
    {
        this.cellState = cellState;
        isTaken = (cellState == 0) ? false : true;
    }

}
