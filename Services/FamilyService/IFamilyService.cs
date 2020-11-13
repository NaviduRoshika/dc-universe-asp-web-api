using System.Collections.Generic;
using System.Threading.Tasks;
using alone_mysql_dc_comics.Dto.Family;
using alone_mysql_dc_comics.Models;

namespace alone_mysql_dc_comics.Services.FamilyService
{
    public interface IFamilyService
    {
         Task<ServiceResponse<List<GetFamilyDto>>> GetAllFamilies();
         Task<ServiceResponse<List<GetFamilyDto>>> AddFamily(AddFamilyDto newCharacter);
         Task<ServiceResponse<GetFamilyDto>> UpdateFamily(UpdateFamilyDto toUpdate);
         Task<ServiceResponse<List<GetFamilyDto>>> DeleteFamily(DeleteFamilyDto toDelete);
    }
}