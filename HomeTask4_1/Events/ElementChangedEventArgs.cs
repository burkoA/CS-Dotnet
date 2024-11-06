namespace HomeTask4_1.Events
{
    public class ElementChangedEventArgs<T> : EventArgs
    {
        public T OldValue { get; set; }
        public T NewValue { get; set; }
        public int Position { get; set; }

        public ElementChangedEventArgs(T oldValue, T newValue, int position)
        {
            OldValue = oldValue; 
            NewValue = newValue;
            Position = position;
        }
    }
}
