using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dto.Municipio;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Municipio;
using AutoMapper;

namespace Api.Service.Services
{
    public class MunicipioService : IMunicipioService
    {
        private IMunicipioRepository _repository;
        private readonly IMapper _mapper;

        public MunicipioService(IMunicipioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MunicipioDtoCreateResult> Post(MunicipioDtoCreate municipio)
        {
            var entity = _mapper.Map<MunicipioEntity>(municipio);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<MunicipioDtoCreateResult>(result);
        }

        public async Task<MunicipioDtoUpdateResult> Put(MunicipioDtoUpdate municipio, Guid id)
        {
            var entity = _mapper.Map<MunicipioEntity>(municipio);
            var result = await _repository.UpdateAsync(entity, entity.Id);
            return _mapper.Map<MunicipioDtoUpdateResult>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _repository.DeleteAsync(id);
            return result;
        }

        public async Task<IEnumerable<MunicipioDto>> GetAll()
        {
            var entities = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<MunicipioDto>>(entities);
        }

        public async Task<MunicipioDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<MunicipioDto>(entity);
        }

        public async Task<MunicipioDtoCompleto> GetCompleteById(Guid id)
        {
            var entity = await _repository.GetCompleteById(id);
            return _mapper.Map<MunicipioDtoCompleto>(entity);
        }

        public async Task<MunicipioDtoCompleto> GetCompleteByIBGE(int codIBGE)
        {
            var entity = await _repository.GetCompleteByIBGE(codIBGE);
            return _mapper.Map<MunicipioDtoCompleto>(entity);
        }
    }
}
