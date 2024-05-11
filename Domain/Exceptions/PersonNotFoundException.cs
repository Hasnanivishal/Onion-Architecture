using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class PersonNotFoundException(Guid personId) :
        Exception($"The Person wiht id {personId} was not found.")
    {
    }
}
