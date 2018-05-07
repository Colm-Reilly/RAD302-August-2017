using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rad302Autumn2017.Models;
using Rad302Autumn2017.DAL;
using System.Web.Http;
using System.Net;

namespace Rad302Autumn2017.DAL
{
    public class ModuleRepositoryEF : IModuleRepository
    {
        private AppDBContext _context;


        public ModuleRepositoryEF(AppDBContext context)
        {
            _context = context;
        }

        //Get /API/modules
        //Returns all modules
        public IEnumerable<Module> GetModules()
        {
            return _context.Modules.ToList();
        }

        //GET /api/modules/id
        //Get specific module
        public Module GetModule(int Id)
        {
            var module = _context.Modules.SingleOrDefault(m => m.ModuleID == Id);

            if (module == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return module;
        }

        //POST /api/modules
        //Create new module
        [HttpPost]
        public Module CreateModule(Module module)
        {
            
            _context.Modules.Add(module);
            _context.SaveChanges();

            return module;
        }

        //PUT /api/modules/id
        //Update existing module
        [HttpPut]
        public void UpdateModule(int Id, Module module)
        {
            

            var moduleInDb = _context.Modules.SingleOrDefault(m => m.ModuleID == Id);

            if (moduleInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            moduleInDb.ModuleID = module.ModuleID;
            moduleInDb.ModuleName = module.ModuleName;

            _context.SaveChanges();

        }

        //DELETE /api/modules/1
        //Delete a module
        [HttpDelete]
        public void DeleteModule(int Id)
        {
            var moduleInDb = _context.Modules.SingleOrDefault(m => m.ModuleID == Id);

            if (moduleInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Modules.Remove(moduleInDb);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}