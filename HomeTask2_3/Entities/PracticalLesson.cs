namespace HomeTask2_3.Entities
{
    internal class PracticalLesson : TrainingElement
    {
        public string? LinkToTask { get; set; }
        public string? LinkToSolution { get; set; }

        public PracticalLesson(string? description, string? linkToTask, string? linkToSolution) : base(description)
        {
            LinkToTask = linkToTask;
            LinkToSolution = linkToSolution;
        }
    }
}
