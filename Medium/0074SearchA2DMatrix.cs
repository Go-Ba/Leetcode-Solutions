using System;

public class SearchA2DMatrix
{
    //https://leetcode.com/problems/search-a-2d-matrix/
    public class Solution_BinarySearch_Single //beat 98% on runtime
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int l = 0, mid, r = matrix.Length * matrix[0].Length - 1;
            int width = matrix[0].Length;
            while (l <= r)
            {
                mid = (l + r) / 2;
                int val = GetValue(matrix, mid, width);
                if (val == target)
                    return true;
                else if (val > target)
                    r = mid - 1;
                else
                    l = mid + 1;
            }
            return false;
        }
        //the 2D matrix is sorted, so we can just flatten it
        public int GetValue(int[][] matrix, int i, int width)
        {
            int x = i % width;
            return matrix[(i - x) / width][x];
        }
    }
    public class Solution_BinarySearch_Multiple
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length < 1)
                return false;

            int row = matrix.Length == 1 ? 0 : GetLayer(matrix, target);
            if (matrix[row].Length == 1)
                return matrix[row][0] == target;

            return ValueExists(matrix, target, row);
        }
        public int GetLayer(int[][] matrix, int target)
        {
            int l = 0, r = matrix.Length - 1, mid = 0;
            while (l <= r)
            {
                mid = (l + r) / 2;
                if (matrix[mid][0] == target)
                    return mid;
                else if (matrix[mid][0] > target)
                    r = mid - 1;
                else
                    l = mid + 1;
            }
            return Math.Clamp(Math.Min(mid, r), 0, matrix.Length);
        }
        public bool ValueExists(int[][] matrix, int target, int row)
        {
            int l = 0, mid, r = matrix[row].Length - 1;
            while (l <= r)
            {
                mid = (l + r) / 2;
                if (matrix[row][mid] == target)
                    return true;
                else if (matrix[row][mid] > target)
                    r = mid - 1;
                else
                    l = mid + 1;
            }
            return false;
        }
    }
}