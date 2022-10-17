class Program
{
    static async Task Main(string[] args)
    {
        var person = new Person()
        {
            Name = "Peter Pan",
            Address = "Musterweg 3",
            ReferenceId = Guid.NewGuid().ToString()
        };

        var personType = person.GetType();

        var isEditable = personType.GetCustomAttribute<EditableAttribute>() != null;
        var multilines = personType.GetProperty("Address").GetCustomAttribute<MultilineAttribute>().Lines;
        var tableName = personType.GetMethod("Save").GetCustomAttribute<EntityReferenceAttribute>().TableName;


        Console.WriteLine($"isEditable: {isEditable}\nmultilineCount: {multilines}\nTableName: {tableName}");

        Console.ReadKey();
    }

}

[AttributeUsage(AttributeTargets.Class)]
public class EditableAttribute : Attribute
{ }

[AttributeUsage(AttributeTargets.Property)]
public class InternalAttribute : Attribute
{ }

[AttributeUsage(AttributeTargets.Property)]
public class MultilineAttribute : Attribute
{
    public MultilineAttribute(int lines)
    {
        this.Lines = lines;
    }

    public int Lines { get; }
}

[AttributeUsage(AttributeTargets.Method)]
public class EntityReferenceAttribute : Attribute
{
    public EntityReferenceAttribute(string entityName)
    {
        this.TableName = entityName;
    }

    public string TableName { get; }
}

[Editable]
public class Person
{
    public string Name { get; set; }

    [Multiline(10)]
    public string Address { get; set; }

    [Internal]
    public string ReferenceId { get; set; }

    [EntityReference("customer")]
    public void Save()
    {
        // TODO: Implement save logic here (is not your job today ;))
    }
}