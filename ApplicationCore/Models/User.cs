using ApplicationCore.Interfaces.Repository;

namespace ApplicationCore.Models;

public class User: IIdentity<int>
{
    public int Id { get; set; }
    
    public string Username { get; init; }
}