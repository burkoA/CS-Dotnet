namespace HomeTask2_3.Entities
{
    internal class Training
    {
        public string? Description { get; set; }

        private TrainingElement[] trainingElements;
        private int _itemCount;

        public Training(string? description)
        {
            Description = description;
            trainingElements = new TrainingElement[10];
            _itemCount = 0;
        }

        public void Add(TrainingElement item)
        {
            if(_itemCount == trainingElements.Length)
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
                if (trainingElements[i] is Lecture)
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
                if (trainingElements[i] is Lecture lecture)
                {
                    clone.Add(new Lecture(lecture.Description, lecture.Topic));
                }
                else if (trainingElements[i] is PracticalLesson lesson)
                {
                    clone.Add(new PracticalLesson(lesson.Description, lesson.LinkToTask, lesson.LinkToSolution));
                }
            }

            return clone;
        }

    }
}
