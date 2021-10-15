using System;
using System.Threading.Tasks;
using Api.Domain.Dto.Cep;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Cep;
using AutoMapper;

namespace Api.Service.Services
{
    public class CepService : ICepService
    {
        private ICepRepository _repository;
        private IMapper _mapper;

        public CepService(ICepRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<CepDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<CepDto>(entity);
        }

        public async Task<CepDto> Get(string cep)
        {
            var entity = await _repository.SelectAsync(cep);
            return _mapper.Map<CepDto>(entity);
        }

        public async Task<CepDtoCreateResult> Post(CepDtoCreate cep)
        {
            var entity = _mapper.Map<CepEntity>(cep);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<CepDtoCreateResult>(result);
        }

        public async Task<CepDtoUpdateResult> Put(CepDtoUpdate cep, Guid id)
        {
            var entity = _mapper.Map<CepEntity>(cep);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<CepDtoUpdateResult>(result);
        }
    }
}
