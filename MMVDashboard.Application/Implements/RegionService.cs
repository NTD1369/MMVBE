using MMVDashboard.Application.Interfaces;
using MMVDashboard.Data.Entities;
using MMVDashboard.Data.Repositories;
using MMVDashboard.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMVDashboard.Application.Implements
{
    public class RegionService: IRegionService
    {
        private readonly IGenericRepository<Region> _RegionRepository;

        public RegionService(IGenericRepository<Region> regionRepository)
        {
            _RegionRepository = regionRepository;
        }

        public async Task<GenericResult> GetAll()
        {
            GenericResult result = new GenericResult();
            try
            {
               
                var data = await _RegionRepository.GetAllAsync($"USP_S_RegionMMV", null, commandType: CommandType.Text);
                result.Data = data;
                //data.ForEach(x =>
                //{

                //});
                result.Success = true;

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
