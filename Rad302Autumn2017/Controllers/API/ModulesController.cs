using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Rad302Autumn2017.Models;

namespace Rad302Autumn2017.Controllers.API
{
    public class ModulesController : ApiController
    {
        private AppDBContext _context;

        public ModulesController()
        {
            _context = new AppDBContext();
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
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _context.Modules.Add(module);
            _context.SaveChanges();

            return module;
        }

        //PUT /api/modules/id
        //Update existing module
        [HttpPut]
        public void UpdateModule(int Id, Module module)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

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
    }
}
