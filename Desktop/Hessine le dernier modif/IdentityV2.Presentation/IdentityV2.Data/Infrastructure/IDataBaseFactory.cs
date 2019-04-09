﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityV2.Data.Infrastructure
{
    public interface IDataBaseFactory : IDisposable
    {
        MyContext DataContext { get; }
        //void Dispose(); hidden
    }
}
