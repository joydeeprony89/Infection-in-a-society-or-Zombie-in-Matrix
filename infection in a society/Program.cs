using System;
using System.Collections.Generic;

namespace infection_in_a_society
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new int[][]
            { 
                new int[] { 0, 1, 1, 0, 1 }, 
                new int[] { 0, 1, 0, 1, 0 }, 
                new int[] { 0, 0, 0, 0, 1 }, 
                new int[] { 0, 1, 0, 0, 0 } 
            };
			Console.WriteLine(MinDays(grid));
        }

        static int MinDays(int[][] grid)
        {
            // base condition 
            if (grid == null || grid.Length == 0) return 0;
            // infected building will be added.
            Queue<int[]> infectedBuildings = new Queue<int[]>();
            // for the result
            int output = 0;
            // count of current infected buildings at any time
            int noOfInfectedBuildings = 0;
            int row = grid.Length;
            int column = grid[0].Length;
            // counter for total no of buildigs
            int totalBuildings = row * column;
            // loop through entire society and add the already infected ones.
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if(grid[i][j] == 1)
                    {
                        infectedBuildings.Enqueue(new int[] { i, j });
                        noOfInfectedBuildings++;
                    }
                }
            }

            while (infectedBuildings.Count > 0)
            {
                // when all the buildings are infected we can return the counter.
                if (noOfInfectedBuildings == totalBuildings) return output;
                int qSize = infectedBuildings.Count;
                // directions -> right - left - up - down
                int[][] directions = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
                while (qSize-- > 0)
                {
                    var currentBuilding = infectedBuildings.Dequeue();
                    foreach (var dir in directions)
                    {
                        // adjacent buildings address.
                        int newRow = currentBuilding[0] + dir[0];
                        int newColumn = currentBuilding[1] + dir[1];
                        // if the adjacent buildings are within the society border and they are not yet infected.
                        if (newRow >= 0 && newRow < row && newColumn >= 0 && newColumn < column && grid[newRow][newColumn] == 0)
                        {
                            // mark the adjacent building as infected.
                            grid[newRow][newColumn] = 1;
                            // increase the infected building count
                            noOfInfectedBuildings++;
                            // push the new infected building index to the queue.
                            infectedBuildings.Enqueue(new int[] { newRow, newColumn });
                        }
                    }
                }
                output++;
            }

            return 0;
        }
	}
}
