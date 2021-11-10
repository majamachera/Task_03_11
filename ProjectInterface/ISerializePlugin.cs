
namespace Task_03_11
{
    public interface ISerializePlugin
    {
        public string Name { get; }
        public string Description { get; }
        public void Serialize(Person person);
        public Person Deserialize(string path);

    }
}
