using System.Collections;
using System.Text;

namespace HomeTask5_1
{
    public class SparseMatrix : IEnumerable<long>
    {
        private Dictionary<(int, int), long> _sparseMatrix;

        private int _rows;
        private int _cols;

        public SparseMatrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentException("Size cannot be <= 0");
            }

            _rows = rows;
            _cols = columns;

            _sparseMatrix = new Dictionary<(int, int), long>();
        }

        private bool IsValidIndex(int rows, int columns) => rows >= 0 && columns >= 0 && rows < _rows && columns < _cols;


        public long this[int i, int j]
        {
            get
            {
                if (!IsValidIndex(i, j))
                {
                    throw new IndexOutOfRangeException("Out of range");
                }
                return _sparseMatrix.TryGetValue((i, j), out long value) ? value : 0;
            }
            set
            {
                if (!IsValidIndex(i, j))
                {
                    throw new IndexOutOfRangeException("Out of range");
                }

                if (value == 0)
                {
                    _sparseMatrix.Remove((i, j));
                }
                else
                {
                    _sparseMatrix[(i, j)] = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    result.Append(this[i, j]);
                }
                result.AppendLine();
            }

            return result.ToString();
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    yield return this[i, j];
                }
            }
        }

        IEnumerator<long> IEnumerable<long>.GetEnumerator()
        {
            return (IEnumerator<long>)GetEnumerator();
        }

        public IEnumerable<(int, int, long)> GetNonzeroElements() =>
            _sparseMatrix.OrderBy(c => c.Key.Item2).ThenBy(r => r.Key.Item1).Select(e => (e.Key.Item1, e.Key.Item2, e.Value));


        public int GetCount(long value) =>
            value == 0 ? _rows * _cols - _sparseMatrix.Count : _sparseMatrix.Count(v => v.Value == value);
    }
}
