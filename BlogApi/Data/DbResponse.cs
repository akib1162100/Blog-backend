using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Data
{
    public enum DbResponse
    {
        Added,
        Updated,
        Failed,
        NotFound,
        NotModified,
        Deleted,
        Success,
        Exists,
        DoesnotExists,
    }
}
