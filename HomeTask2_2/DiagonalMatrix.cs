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
            _diagonalElement = new int[Size];
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
            if (IsValidIndexes(i, j))
            {
                return _diagonalElement[i];
            }
            return 0;
        }
        set
        {
            if (IsValidIndexes(i, j))
            {
                _diagonalElement[i] = value;
            }
        }
    }

    private bool IsValidIndexes(int i, int j)
    {
        if (i >= 0 && i < Size && j >= 0 && j < Size && i == j)
            return true;

        return false;
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
        if (!(obj is DiagonalMatrix m) || Size != m.Size)
            return false;

        DiagonalMatrix otherDiagonal = obj as DiagonalMatrix;

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
                result += this[i, j];
            }

            result += "\n";
        }

        return result;
    }
}

public static class AddMatrices
{
    public static DiagonalMatrix Add(this DiagonalMatrix firstMatrix, DiagonalMatrix secondMatrix)
    {
        int newSize = Math.Max(firstMatrix._diagonalElement.Length, secondMatrix._diagonalElement.Length);

        int[] resultElements = new int[newSize];

        for (int i = 0; i < newSize; i++)
        {
            int firstMatrixElement = i < firstMatrix._diagonalElement.Length ? firstMatrix._diagonalElement[i] : 0;

            int secondMatrixElement = i < secondMatrix._diagonalElement.Length ? secondMatrix._diagonalElement[i] : 0;

            resultElements[i] = firstMatrixElement + secondMatrixElement;
        }

        return new DiagonalMatrix(resultElements);
    }
}
