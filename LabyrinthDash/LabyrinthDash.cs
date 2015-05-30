using System;
using System.Linq;

internal class LabyrinthDash
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        char[][] matrix = new char[n][];
        int row = 0;
        for (row = 0; row < n; row++)
        {
            matrix[row] = Console.ReadLine().ToCharArray();
        }
        string command = Console.ReadLine();
        row = 0;
        int col = 0;
        int lives = 3;
        int moves = 0;
        string obstacles="@#*";
        string wall = "_|";
        int oldRow = row;
        int oldCol = col;
        for (int i = 0; i < command.Length; i++)
        {
            oldRow = row;
            oldCol = col;
            switch (command[i])
            {
                case 'v': row++; break;
                case '^': row--; break;
                case '<': col--; break;
                case '>': col++; break;
            }
            moves++;
            if ((row < 0 || row >= matrix.Count()) || (col < 0 || col >= matrix[row].Length) || matrix[row][col] == ' ')
            {
                Console.WriteLine("Fell off a cliff! Game Over!");
                break;
            }
            if (obstacles.Contains(matrix[row][col].ToString()))
            {
                lives--;
                Console.WriteLine("Ouch! That hurt! Lives left: {0}", lives);
                if (lives == 0)
                {
                    Console.WriteLine("No lives left! Game Over!");
                    break;
                }
            }
            else if (wall.Contains(matrix[row][col].ToString()))
            {
                moves--;
                row = oldRow;
                col = oldCol;
                Console.WriteLine("Bumped a wall.");
            }
            else if (matrix[row][col] == '$')
            {
                lives++;
                Console.WriteLine("Awesome! Lives left: {0}", lives);
                matrix[row][col] = '.';
            }
            else if (matrix[row][col] == '.')
            {
                Console.WriteLine("Made a move!");
            }
        }
        Console.WriteLine("Total moves made: {0}", moves);
    }
}


