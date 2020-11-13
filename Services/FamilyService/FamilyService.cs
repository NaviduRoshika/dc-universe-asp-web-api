using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alone_mysql_dc_comics.Data;
using alone_mysql_dc_comics.Dto.Family;
using alone_mysql_dc_comics.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace alone_mysql_dc_comics.Services.FamilyService
{
    public class FamilyService : IFamilyService
    {
        private readonly DcDbContext _context;
        private readonly IMapper _mapper;
        public FamilyService(DcDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }
        public async Task<ServiceResponse<List<GetFamilyDto>>> AddFamily(AddFamilyDto newFamily)
        {
            ServiceResponse<List<GetFamilyDto>> response = new ServiceResponse<List<GetFamilyDto>>();
            try
            {
                Family family = _mapper.Map<Family>(newFamily);
                await _context.Families.AddAsync(family);
                await _context.SaveChangesAsync();
                response.Data = await _context.Families.Select(c => _mapper.Map<GetFamilyDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Task<ServiceResponse<List<GetFamilyDto>>> DeleteFamily(DeleteFamilyDto toDelete)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResponse<List<GetFamilyDto>>> GetAllFamilies()
        {
           ServiceResponse<List<GetFamilyDto>> response = new ServiceResponse<List<GetFamilyDto>>();
            try
            {
                 List<Family> families = await _context.Families.ToListAsync();
                 response.Data = (families.Select(c => _mapper.Map<GetFamilyDto>(c))).ToList();
            }
            catch (Exception ex)
            {
               response.Success = false;
               response.Message = ex.Message;
            }
            return response;
        }

        public Task<ServiceResponse<GetFamilyDto>> UpdateFamily(UpdateFamilyDto toUpdate)
        {
            throw new System.NotImplementedException();
        }
    }
}