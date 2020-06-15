using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    Cell[,] grid;
    private int cellSize;
    private int rows, cols;
   
    public Grid (int cellSize, int cols, int rows)
    {
        this.cellSize = cellSize;
        this.rows = rows;
        this.cols = cols;
        grid = new Cell[this.rows, this.cols];

        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                grid[row, col] = new Cell();
            }
        }
    }

    public Vector3 VectorFromGridPoint(int col, int row)
    {
        return new Vector3((col * cellSize), 0,(row * cellSize));
    }

    public static Vector3 GridPosition(Vector3 point)
    {
        int col = Mathf.RoundToInt(point.x);
        int row = Mathf.RoundToInt(point.z);
        return new Vector3(col, 0, row);
    }

    public Vector2Int GridIndex(Vector3 gridPosition)
    {
        return new Vector2Int((int)(gridPosition.x / cellSize), (int)(gridPosition.z / cellSize));
    }

    public bool IsCellBlocked(Vector2Int cellPosition)
    {
        if (cellPosition.x > 0 && cellPosition.x < grid.GetLength(0) && cellPosition.y > 0 && cellPosition.y < grid.GetLength(1))
            return grid[cellPosition.x, cellPosition.y].isTaken;
        throw new IndexOutOfRangeException("No cell at " + cellPosition + " on grid.");
    }
}
