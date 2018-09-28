using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore.Controllers
{
    public class Operation : IScoped
    {
        public Guid ScopeGuid { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
