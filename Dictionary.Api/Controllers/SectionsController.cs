﻿using Dictionary.DataAccess;
using Dictionary.Model;
using System.Collections.Generic;
using System.Web.Http.Cors;
using System.Linq;
using System.Web.Http;

namespace Dictionary.Api.Controllers
{
    [EnableCors(origins: "http://localhost:51994", headers: "*", methods: "*")]
    public class SectionsController : ApiController
    {
        private UnitOfWork<DictionaryContext> unitOfWork;

        public SectionsController()
        {
            this.unitOfWork = new UnitOfWork<DictionaryContext>();
        }

        public SectionsController(UnitOfWork<DictionaryContext> uow)
        {
            this.unitOfWork = uow;
        }

        public IEnumerable<Section> Get()
        {
            return unitOfWork.GetRepository<Section>().Get();
        }

        public Section Get(int id)
        {
            return unitOfWork.GetRepository<Section>().GetById(id);
        }
    }
}
