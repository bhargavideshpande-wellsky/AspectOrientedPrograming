using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickTackToe.Model;

namespace TickTackToe.Database
{
    interface IRepository
    {
        string AddData(UserDetails user);
    }
}
