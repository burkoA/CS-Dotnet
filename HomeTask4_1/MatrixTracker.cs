using HomeTask4_1.Events;

namespace HomeTask4_1
{
    public class MatrixTracker<T>
    {
        private DiagonalMatrix<T> _matrix;
        private readonly ElementChangedEventArgs<T>[] _changes;
        private int _countChanges = 0;

        public MatrixTracker(DiagonalMatrix<T> diagonalMatrix)
        {
            _matrix = diagonalMatrix;
            _changes = new ElementChangedEventArgs<T>[10];
            _countChanges = 0;

            _matrix.ElementChanged += OnElementChanged;
        }

        private void OnElementChanged(object? sender, ElementChangedEventArgs<T> element)
        {
            if(_countChanges < 10)
            {
                _changes[_countChanges++] = element;
            }
        }

        public void Undo()
        {
            if (_countChanges > 0)
            {
                var lastChange = _changes[--_countChanges];
                _matrix[lastChange.Position, lastChange.Position] = lastChange.OldValue;
            }
            else
            {
                throw new Exception("Changes has been not provided");
            }
        }
    }
}
