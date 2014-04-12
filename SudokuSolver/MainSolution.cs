using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    public static class MainSolution
    {
    	public static void Start(Number[,] TheContainer)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    while (TheContainer[i, j].IsReadOnly == false)
                    {
                        if (writeNumber(TheContainer[i, j]))
                        {
                            if (lineCheck(i, j, TheContainer) && rowCheck(i, j, TheContainer) 
                                && squareCheck(i, j, TheContainer))
                            {
                                break;
                            }
                        }
                        else
                        {
                            do
                            {
                                if (j == 0)
                                {
                                    i--;
                                    j = 8;
                                }
                                else
                                {
                                    j--;
                                }
                            }
                            while (TheContainer[i, j].IsReadOnly);
                        }
                    }
                }
            }
        }

        private static bool writeNumber(Number dealNumber)
        {
            if (dealNumber.Value < 9)
            {
                dealNumber.Value++;
                return true;
            }
            else 
            {
                dealNumber.Value = 0;
                return false;
            }
        }

        private static bool rowCheck(int i, int j, Number[,] TheContainer)
        {
            for (int check = 0; check < 9; check++)
            {
                if (check != i && TheContainer[check, j].Value != 0)
                {
                    if (TheContainer[check, j].Value ==
                        TheContainer[i, j].Value)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool squareCheck(int i, int j, Number[,] TheContainer)
        {
            int a = i / 3 * 3;
            int b = j / 3 * 3;
            int xmax = a + 3;
            int ymax = b + 3;
            for (; a < xmax; a++)
            {
                for (b = j / 3 * 3; b < ymax; b++)
                {
                    if (a == i && b == j)
                    {
                        continue;
                    }
                    if (TheContainer[a, b].Value != 0)
                    {
                        if (TheContainer[a, b].Value ==
                            TheContainer[i, j].Value)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private static bool lineCheck(int i, int j, Number[,] TheContainer)
        {
            for (int check = 0; check < 9; check++)
            {
                if (check != j && TheContainer[i, check].Value != 0)
                {
                    if (TheContainer[i, check].Value ==
                        TheContainer[i, j].Value)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
