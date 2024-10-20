namespace HomeTask2_3.Entities
{
    internal class TrainingElement
    {
        public string? Description { get; set; }

        protected TrainingElement(string? description) 
        {
            Description = description;
        }
    }
}
