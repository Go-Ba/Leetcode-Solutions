using System.Collections.Generic;

public class ValidSudoku
{
    public class Solution
    {
        public bool IsValidSudoku(char[][] board)
        {
            if (!AreRowsValid(board)) return false;
            if (!AreColumnsValid(board)) return false;
            if (!AreSectionsValid(board)) return false;
            return true;
        }
        bool AreSectionsValid(char[][] board)
        {
            for (int x = 0; x < 9; x+=3)           
                for (int y = 0; y < 9; y += 3)                
                    if (!IsSectionValid(board, x, y))
                        return false;

            return true;
        }
        bool IsSectionValid(char[][] board, int xStart, int yStart)
        {
            HashSet<int> existingDigits = new HashSet<int>();
            for (int y = yStart; y < yStart + 3; y++)
            {
                for (int x = xStart; x < xStart + 3; x++)
                {
                    char digit = board[x][y];
                    if (digit == '.') continue;
                    if (existingDigits.Contains(digit)) return false;
                    existingDigits.Add(digit);
                }
            }
            return true;
        }
        bool AreRowsValid(char[][] board)
        {
            for (int y = 0; y < board.Length; y++)
            {
                HashSet<int> existingDigits = new HashSet<int>();
                for (int x = 0; x < board.Length; x++)
                {
                    char digit = board[x][y];
                    if (digit == '.') continue;
                    if (existingDigits.Contains(digit)) return false;
                    existingDigits.Add(digit);
                }
            }
            return true;
        }
        bool AreColumnsValid(char[][] board)
        {
            for (int x = 0; x < board.Length; x++)
            {
                HashSet<int> existingDigits = new HashSet<int>();
                for (int y = 0; y < board.Length; y++)
                {
                    char digit = board[x][y];
                    if (digit == '.') continue;
                    if (existingDigits.Contains(digit)) return false;
                    existingDigits.Add(digit);
                }
            }
            return true;
        }
    }
}