using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateClient
{
    public class Request<T>
    {
        public string Action;
        public string Path;
        public T Data;
    }
}
