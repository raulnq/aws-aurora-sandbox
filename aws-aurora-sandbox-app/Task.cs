namespace aws_aurora_sandbox_app
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        private Task()
        {

        }

        public Task(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}