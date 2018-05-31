using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using System.Text;

namespace KindoUIDemo.Middleware
{
    public class DynamicView : IFileInfo
    {
        private readonly string _viewPath;

        private byte[] _viewContent;

        public DynamicView(string viewPath)
        {
            _viewPath = viewPath;
            GetView(viewPath);
        }

        public bool Exists { get; private set; }
        public DateTimeOffset LastModified { get; private set; }

        public bool IsDirectory => false;
        public long Length
        {
            get
            {
                using (var stream = new MemoryStream(_viewContent))
                {
                    return stream.Length;
                }
            }
        }
        public string PhysicalPath => null;
        public string Name => Path.GetFileName(_viewPath);

        public Stream CreateReadStream() => new MemoryStream(_viewContent);

        private void GetView(string viewPath)
        {
            try
            {
                //ToDo call Jeeves Server and get proper view and updatew Exists property.
                var view = string.Empty;
                Exists = true;

                if (Exists)
                {
                    _viewContent = Encoding.UTF8.GetBytes(view);

                    LastModified = Convert.ToDateTime(DateTime.Now);
                }
            }
            catch (Exception)
            {
                // if something went wrong, Exists will be false
            }
        }
    }
}
