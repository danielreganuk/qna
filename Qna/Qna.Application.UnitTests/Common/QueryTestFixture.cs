using AutoMapper;
using Qna.Persistence;
using System;
using Qna.Application.Interfaces.Mappings;
using Xunit;

namespace Qna.Application.UnitTests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public DatabaseContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {
            Context = DatabaseContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            DatabaseContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}