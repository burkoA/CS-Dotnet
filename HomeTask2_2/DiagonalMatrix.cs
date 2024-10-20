using System;

namespace HomeTask2_2;

public class DiagonalMatrix
{
    private readonly int Size;
    public int[] _diagonalElement;

    public DiagonalMatrix(params int[] diagonalElement)
    {
        if (diagonalElement == null)
        {
            Size = 0;
            _diagonalElement = new int[0];
        }
        else
        {
            Size = diagonalElement.Length;
            _diagonalElement = new int[Size];
            Array.Copy(diagonalElement, _diagonalElement, Size);
        }
    }

    public int this[int i, int j]
    {
        get
        {
            if (i >= Size || j >= Size || i < 0 || j < 0)
            {
                return 0;
            }
            return (i == j) ? _diagonalElement[i] : 0;
        }
        set
        {
            if (i >= 0 && i < Size && j >= 0 && j < Size)
            {
                _diagonalElement[i] = value;
            }
        }
    }

    public int Track()
    {
        int sum = 0;

        for (int i = 0; i < Size; i++)
        {
            sum += _diagonalElement[i];
        }

        return sum;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        DiagonalMatrix otherDiagonal = (DiagonalMatrix)obj;

        if (Size != otherDiagonal.Size)
            return false;

        for (int i = 0; i < Size; i++)
        {
            if (_diagonalElement[i] != otherDiagonal._diagonalElement[i])
                return false;
        }

        return true;
    }

    public override string ToString()
    {
        string result = "";

        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                if (i == j)
                {
                    result += _diagonalElement[i];
                }
                else
                {
                    result += "0";
                }
            }
            result += "\n";
        }

        return result;
    }

    public static DiagonalMatrix SumTwoMatrix(DiagonalMatrix firstMatrix, DiagonalMatrix secondMatrix)
    {
        int newSize = Math.Max(firstMatrix.Size, secondMatrix.Size);

        int[] resultElements = new int[newSize];

        int firstMatrixElement = 0;
        int secondMatrixElement = 0;

        for (int i = 0; i < newSize; i++)
        {
            if (i < firstMatrix.Size)
            {
                firstMatrixElement = firstMatrix._diagonalElement[i];
            }
            else
            {
                firstMatrixElement = 0;
            }

            if (i < secondMatrix.Size)
            {
                secondMatrixElement = secondMatrix._diagonalElement[i];
            }
            else
            {
                secondMatrixElement = 0;
            }

            resultElements[i] = firstMatrixElement + secondMatrixElement;
        }

        return new DiagonalMatrix(resultElements);
    }
}
