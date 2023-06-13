using System;
using System.Collections.Generic;
using System.Text;

public class EqualRowAndColumnPairs
{
    //https://leetcode.com/problems/equal-row-and-column-pairs/
    public class Solution_int
    {
        public int EqualPairs(int[][] grid)
        {
            List<long> rows = new List<long>();
            Dictionary<long, int> columns = new Dictionary<long, int>();

            for (int i = 0; i < grid.Length; i++)
            {
                long row = 0;
                long column = 0;
                for (int j = 0; j < grid.Length; j++)
                {
                    row += grid[i][j] * (int)Math.Pow(10, j);
                    column += grid[j][i] * (int)Math.Pow(10, j);
                }
                rows.Add(row);
                columns.TryAdd(column, 0);
                columns[column]++;
            }
            int count = 0;
            foreach (var item in rows)
                if (columns.TryGetValue(item, out int amount))
                    count += amount;
            return count;
        }
    }
    public class Solution_StringBuilder
    {
        public int EqualPairs(int[][] grid)
        {
            List<string> rows = new List<string>();
            Dictionary<string, int> columns = new Dictionary<string, int>();

            for (int i = 0; i < grid.Length; i++)
            {
                StringBuilder row = new StringBuilder();
                StringBuilder column = new StringBuilder();
                for (int j = 0; j < grid.Length; j++)
                {
                    row.Append(grid[i][j]);
                    row.Append(",");
                    column.Append(grid[j][i]);
                    column.Append(",");
                }
                rows.Add(row.ToString());
                var c = column.ToString();
                columns.TryAdd(c, 0);
                columns[c]++;
            }
            int count = 0;
            foreach (var item in rows)
                if (columns.TryGetValue(item, out int amount))
                    count += amount;
            return count;
        }
    }
    public class Solution_Strings
    {
        public int EqualPairs(int[][] grid)
        {
            List<string> rows = new List<string>();
            Dictionary<string, int> columns = new Dictionary<string, int>();

            for (int i = 0; i < grid.Length; i++)
            {
                string row = "";
                string column = "";
                for (int j = 0; j < grid.Length; j++)
                {
                    row += grid[i][j].ToString() + ",";
                    column += grid[j][i].ToString() + ",";
                }
                rows.Add(row);
                columns.TryAdd(column, 0);
                columns[column]++;
            }
            int count = 0;
            foreach (var item in rows)            
                if (columns.TryGetValue(item, out int amount))
                    count += amount;
            return count;
        }
    }
}