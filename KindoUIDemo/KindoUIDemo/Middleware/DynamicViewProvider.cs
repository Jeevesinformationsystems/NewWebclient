using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KindoUIDemo.Middleware
{
    public class DynamicViewProvider : IFileProvider
    {
        public IDirectoryContents GetDirectoryContents(string subpath) => throw new NotImplementedException();

        public IFileInfo GetFileInfo(string subpath)
        {

            var result = new DynamicView(subpath);

            return result.Exists ? result as IFileInfo : new NotFoundFileInfo(subpath);
        }

        public IChangeToken Watch(string filter)
        {
            return new DynamicViewChangeToken(filter);
        }
    }



    internal class EmptyDisposable : IDisposable
    {
        public static EmptyDisposable Instance { get; } = new EmptyDisposable();

        private EmptyDisposable() { }

        public void Dispose() { }
    }
}
