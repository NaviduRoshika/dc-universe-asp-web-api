using System.Collections.Generic;
using System.Threading.Tasks;
using alone_mysql_dc_comics.Dto.Power;
using alone_mysql_dc_comics.Models;

namespace alone_mysql_dc_comics.Services.PowerService
{
    public interface IPowerService
    {
         Task<ServiceResponse<List<GetPowerDto>>> GetAllPowers();
         Task<ServiceResponse<List<GetPowerDto>>> AddPower(AddPowerDto newPower);
         Task<ServiceResponse<GetPowerDto>> GetPowerById(int id);
    }
}