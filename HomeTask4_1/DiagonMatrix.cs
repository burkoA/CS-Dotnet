using HomeTask4_1.Events;
using System.Text;

namespace HomeTask4_1
{
    public class DiagonalMatrix<T>
    {
        private T[] _diagonalElements;

        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;

        public int Size { get; }

        public DiagonalMatrix(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("Size cannot be negative");
            }

            Size = size;
            _diagonalElements = new T[Size];
        }

        public T this[int i, int j]
        {
            get
            {
                if (IsValidIndexes(i, j))
                {
                    return i == j ? _diagonalElements[i] : default;
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (IsValidIndexes(i, j) && i == j)
                {
                    if (!Equals(_diagonalElements[i], value))
                    {
                        OnElementChanged(new ElementChangedEventArgs<T>(_diagonalElements[i], value, i));
                        _diagonalElements[i] = value;
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public T GetElement(int index)
        {
            if (index < 0 || index >= Size)
            {
                throw new IndexOutOfRangeException();
            }
            return _diagonalElements[index];
        }

        public virtual void OnElementChanged(ElementChangedEventArgs<T> element)
        {
            ElementChanged?.Invoke(this, element);
        }

        private bool IsValidIndexes(int i, int j) => i >= 0 && i < Size && j >= 0 && j < Size;

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    result.Append(this[i, j]);
                }

                result.AppendLine();
            }

            return result.ToString();
        }
    }
}