using HomeTask4_1.Events;

namespace HomeTask4_1
{
    public class DiagonalMatrix<T>
    {
        public T[] _diagonalElement;

        public int Size { get; }

        public DiagonalMatrix(int size, params T[] diagonalElement)
        {
            if(size < 0)
            {
                throw new ArgumentException("Size cannot be negative");
            }

            if (diagonalElement == null)
            {
                Size = size;
                _diagonalElement = new T[Size];
            }
            else
            {
                Size = size;
                _diagonalElement = new T[Size];
                Array.Copy(diagonalElement, _diagonalElement, Size);
            }
        }

        public T this[int i, int j]
        {
            get
            {
                if (IsValidIndexes(i, j))
                {
                    return i == j ? _diagonalElement[i] : default;
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (IsValidIndexes(i, j) && i == j)
                {
                    if (!Equals(_diagonalElement[i], value))
                    {
                        OnElementChanged(new ElementChangedEventArgs<T>(_diagonalElement[i], value, i));
                        _diagonalElement[i] = value;
                    }
                }
                else if (IsValidIndexes(i, j))
                {
                    _diagonalElement[i] = default;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;

        public virtual void OnElementChanged(ElementChangedEventArgs<T> element)
        {
            ElementChanged?.Invoke(this, element);
        }

        private bool IsValidIndexes(int i, int j)
        {
            if (i >= 0 && i < Size && j >= 0 && j < Size)
                return true;

            return false;
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
}