using System;

namespace Jiabin
{
    public class BizException : Exception
    {
        public BizException(string msg) : base(msg) { }

        public BizException() : base() { }
    }
}
