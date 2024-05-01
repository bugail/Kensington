namespace Kensington.DataAccess.Core;

public interface ISoftDelete
{
    public bool IsActive { get; set; }
}