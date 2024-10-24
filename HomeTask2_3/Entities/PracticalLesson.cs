namespace HomeTask2_3.Entities
{
    internal class PracticalLesson : Lesson
    {
        public string? LinkToTask { get; set; }
        public string? LinkToSolution { get; set; }

        public PracticalLesson(string? description, string? linkToTask, string? linkToSolution) : base(description)
        {
            LinkToTask = linkToTask;
            LinkToSolution = linkToSolution;
        }

        public override Lesson Clone()
        {
            return new PracticalLesson(this.Description, this.LinkToTask, this.LinkToSolution);
        }
    }
}
