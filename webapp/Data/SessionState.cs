using System;
using System.Collections.Generic;

namespace webapp.Data
{
    public class SessionState
    {
        public Dictionary<string, string> Storage { get; private set; } = new Dictionary<string, string>();
    }
}