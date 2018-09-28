using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore.Controllers
{
    public interface IScoped
    {
        Guid ScopeGuid { get; set; }
    }

    public interface ITransient
    {
        Guid ScopeGuid { get; set; }
    }

    public interface ISingleton
    {
        Guid ScopeGuid { get; set; }
    }
}
