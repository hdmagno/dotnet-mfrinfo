using Api.Domain.Dto;
using Api.Domain.Dto.Cep;
using Api.Domain.Dto.Municipio;
using Api.Domain.Dto.Uf;
using Api.Domain.Entities;
using Api.Domain.Entity;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToEntity : Profile
    {
        public DtoToEntity()
        {
            #region user
            CreateMap<CreateUserDto, UserEntity>();
            CreateMap<UpdateUserDto, UserEntity>();

            CreateMap<UserEntity, UserDto>();
            CreateMap<UserEntity, CreateUserDtoResult>();
            CreateMap<UserEntity, UpdateUserDtoResult>();
            #endregion

            #region Uf
            CreateMap<UfEntity, UfDto>();
            #endregion

            #region Municipio
            CreateMap<MunicipioDtoCreate, MunicipioEntity>();
            CreateMap<MunicipioDtoUpdate, MunicipioEntity>();

            CreateMap<MunicipioEntity, MunicipioDto>();
            CreateMap<MunicipioEntity, MunicipioDtoCompleto>();
            CreateMap<MunicipioEntity, MunicipioDtoCreateResult>();
            CreateMap<MunicipioEntity, MunicipioDtoUpdateResult>();
            #endregion

            #region Cep
            CreateMap<CepDtoCreate, CepEntity>();
            CreateMap<CepDtoUpdate, CepEntity>();

            CreateMap<CepEntity, CepDto>();
            CreateMap<CepEntity, CepDtoCreateResult>();
            CreateMap<CepEntity, CepDtoUpdateResult>();
            #endregion

        }
    }
}
