namespace HomeTask2_3.Entities
{
    internal class Lesson : TrainingElement
    {
        public Lesson(string description) : base(description) { }

        public virtual Lesson Clone()
        {
            return new Lesson(this.Description);
        }
    }
}
