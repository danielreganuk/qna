using Qna.Persistence;
using System;

namespace Qna.Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly DatabaseContext _context;

        public CommandTestBase()
        {
            _context = DatabaseContextFactory.Create();
        }

        public void Dispose()
        {
            DatabaseContextFactory.Destroy(_context);
        }
    }
}