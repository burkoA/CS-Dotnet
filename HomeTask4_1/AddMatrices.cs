namespace HomeTask4_1
{
    public static class AddMatrices
    {
        public static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> firstMatrix, DiagonalMatrix<T> secondMatrix, Func<T, T, T> addMatrix)
        {
            if (firstMatrix == null) throw new ArgumentNullException(nameof(firstMatrix));
            if (secondMatrix == null) throw new ArgumentNullException(nameof(secondMatrix));

            int newSize = Math.Max(firstMatrix.Size, secondMatrix.Size);
            T[] resultElements = new T[newSize];

            for (int i = 0; i < newSize; i++)
            {
                T firstMatrixElement = i < firstMatrix.Size ? firstMatrix.GetElement(i) : default;
                T secondMatrixElement = i < secondMatrix.Size ? secondMatrix.GetElement(i) : default;

                resultElements[i] = addMatrix(firstMatrixElement, secondMatrixElement);
            }

            DiagonalMatrix<T> resultMatrix = new DiagonalMatrix<T>(newSize);

            for (int i = 0; i < newSize; i++)
            {
                resultMatrix[i, i] = resultElements[i];
            }

            return resultMatrix;
        }
    }
}
