namespace HomeTask2_2
{
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
}