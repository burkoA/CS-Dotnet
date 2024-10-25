namespace HomeTask2_3.Entities
{
    internal class Training : TrainingElement
    {
        private Lesson[] trainingElements;
        private int _itemCount;

        public Training(string? description) : base(description)
        {
            trainingElements = new Lesson[10];
            _itemCount = 0;
        }

        public void Add(Lesson item)
        {
            if (_itemCount == trainingElements.Length)
            {
                Array.Resize(ref trainingElements, _itemCount * 2);
            }

            trainingElements[_itemCount] = item;
            _itemCount++;
        }

        public bool IsPractical()
        {
            for (int i = 0; i < _itemCount; i++)
            {
                if (!(trainingElements[i] is PracticalLesson))
                {
                    return false;
                }
            }
            return true;
        }

        public Training Clone()
        {
            Training clone = new Training(this.Description);

            for (int i = 0; i < _itemCount; i++)
            {
                clone.Add(trainingElements[i].Clone());
            }

            return clone;
        }

    }
}
