using HomeTask4_1.Events;

namespace HomeTask4_1
{
    public class MatrixTracker<T>
    {
        private const int MAX_TRACK_LENGTH = 10;
        private readonly DiagonalMatrix<T> _matrix;
        private readonly ElementChangedEventArgs<T>[] _changes;
        private int _countChanges = 0;

        public MatrixTracker(DiagonalMatrix<T> diagonalMatrix)
        {
            _matrix = diagonalMatrix;
            _changes = new ElementChangedEventArgs<T>[MAX_TRACK_LENGTH];
            _countChanges = 0;

            _matrix.ElementChanged += OnElementChanged;
        }

        private void OnElementChanged(object? sender, ElementChangedEventArgs<T> element)
        {
            if (_countChanges < MAX_TRACK_LENGTH)
            {
                _changes[_countChanges++] = element;
            }
            else
            {
                for (int i = 0; i < MAX_TRACK_LENGTH - 1; i++)
                {
                    _changes[i] = _changes[i + 1];
                }
                _changes[MAX_TRACK_LENGTH - 1] = element;
            }
        }

        public void Undo()
        {
            if (_countChanges > 0)
            {
                var lastChange = _changes[--_countChanges];

                _matrix.ElementChanged -= OnElementChanged;

                _matrix[lastChange.Position, lastChange.Position] = lastChange.OldValue;

                _matrix.ElementChanged += OnElementChanged;
            }
            else
            {
                throw new InvalidOperationException("No changes to undo");
            }
        }
    }
}
