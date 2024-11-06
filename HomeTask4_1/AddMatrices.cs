namespace HomeTask4_1
{
    public static class AddMatrices
    {
        public static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> firstMatrix, DiagonalMatrix<T> secondMatrix, Func<T, T, T> addMatrix)
        {
            int newSize = Math.Max(firstMatrix._diagonalElement.Length, secondMatrix._diagonalElement.Length);

            T[] resultElements = new T[newSize];

            for (int i = 0; i < newSize; i++)
            {
                T firstMatrixElement = i < firstMatrix._diagonalElement.Length ? firstMatrix._diagonalElement[i] : default;

                T secondMatrixElement = i < secondMatrix._diagonalElement.Length ? secondMatrix._diagonalElement[i] : default;

                resultElements[i] = addMatrix(firstMatrixElement, secondMatrixElement);
            }

            return new DiagonalMatrix<T>(newSize , resultElements);
        }
    }
}
