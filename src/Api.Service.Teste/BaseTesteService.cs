using System;
using Api.CrossCutting.Mappings;
using AutoMapper;

namespace Api.Service.Teste
{
    public abstract class BaseTesteService
    {
        public IMapper Mapper { get; set; }
        public BaseTesteService()
        {
            Mapper = new AutoMapperFixture().GetMapper();
        }
        public class AutoMapperFixture : IDisposable
        {
            public IMapper GetMapper()
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new DtoToEntity());
                });

                return config.CreateMapper();
            }
            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }
}
