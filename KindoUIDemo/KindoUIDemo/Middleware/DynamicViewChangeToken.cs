using Microsoft.Extensions.Primitives;
using System;

namespace KindoUIDemo.Middleware
{
    public class DynamicViewChangeToken : IChangeToken
    {
        private string _viewPath;

        public DynamicViewChangeToken(string viewPath)
        {
            _viewPath = viewPath;
        }

        public bool ActiveChangeCallbacks => false;

        public bool HasChanged => true;

        public IDisposable RegisterChangeCallback(Action<object> callback, object state) => EmptyDisposable.Instance;
    }
}
