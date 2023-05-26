using System.Collections.Generic;
using System.Linq;
using Ciber.Models.Paging;
//using EFCoreDatabaseFirstSample.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace Ciber.Models.DataManager
{
    public class AgentDataManager : IDataRepository<Agent, AgentDTO>
    {
        readonly AppPegaContext _appPegaContext;

        public AgentDataManager(AppPegaContext appPegaContext)
        {
            _appPegaContext = appPegaContext;
        }

        public void Add(Agent entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Agent entity)
        {
            throw new System.NotImplementedException();
        }

        public Agent Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PagedResult<Agent>> GetAll(PagingImplementation pagingImplementation, int Year, int Month)
        {
            var list = _appPegaContext.Agents.Where(x => x.Status == 1).Where(x => x.CreateDate.Value.Year == Year && x.CreateDate.Value.Month == Month);
            int countlist = list.Count();
            var items = list.Skip((pagingImplementation.PageNumber - 1) * pagingImplementation.PageSize)
                                .Take(pagingImplementation.PageSize)
                                .ToList();
            foreach (var item in items)
            {
                var listGallery = _appPegaContext.AgentGalleries.Where(x => x.Status == 1 && x.AgentId == item.AgentId);
                string gallery = "";
                foreach (var gl in listGallery)
                {
                    gallery += "http://app.pega.com.vn/Backend/data/Agent/" + gl.Image + ",";
                }
                if (gallery != "")
                {
                    gallery = gallery.Remove(gallery.Length - 1);
                }
                item.Note = gallery;
            }
            yield return new PagedResult<Agent>
            {
                totalSum = countlist,
                totalCount = items.Count(),
                items = items
            };

        }

        public AgentDTO GetDto(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Agent entityToUpdate, Agent entity)
        {
            throw new System.NotImplementedException();
        }


    }
}
