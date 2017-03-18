using System.Collections.Generic;
using System;

namespace Morpheus.API.Validation {
    public class RouteValidator 
    {
        private readonly IDictionary<string, Type> _routeValidator;
        
        public RouteValidator()
        {
            this._routeValidator = new Dictionary<string, Type>();
        }

        public void Register<T>(string route) where T : IValidation
        {
            _routeValidator[route] = typeof(T);
        }

        public IValidation Resolve(string route)
        {
            var vtype = _routeValidator.ContainsKey(route) ? _routeValidator[route] : null;
            return vtype != null ? (IValidation)Activator.CreateInstance(vtype) : null;
        }
    }
}

