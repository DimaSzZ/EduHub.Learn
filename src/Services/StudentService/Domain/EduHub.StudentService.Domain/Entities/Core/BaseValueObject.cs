using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace EduHub.StudentService.Domain.Entities.Core;

public abstract class BaseValueObject
{
    public override bool Equals(object obj)
    {
        if (obj is null || GetType() != obj.GetType())
        {
            return false;
        }
        
        return GetHashCode() == obj.GetHashCode();
    }
    
    public override int GetHashCode()
    {
        var serializeObject = JsonSerializer.Serialize(this, GetType()).Trim();
        var hash = MD5.HashData(Encoding.UTF8.GetBytes(serializeObject));
        return BitConverter.ToInt32(hash);
    }
}