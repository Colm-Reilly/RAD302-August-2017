using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rad302Autumn2017.Models;
using Rad302Autumn2017.DAL;

namespace Rad302Autumn2017.DAL
{
    public interface IModuleRepository : IDisposable
    {
        IEnumerable<Module> GetModules();
        Module GetModule(int Id);
        Module CreateModule(Module module);
        void UpdateModule(int Id, Module module);
        void DeleteModule(int Id);

    }
}