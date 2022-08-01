namespace WebApplication.Core.Models;
public class Student
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreationDate { get; set; }
    public byte[] ConcurrencyStamp { get; set; }
    public int DisplayOrder { get; set; }
}
