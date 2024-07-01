using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Cdeem.Core.ValueObject
{
    public record Note(string Annotation,DateTime CreatedDate);
}