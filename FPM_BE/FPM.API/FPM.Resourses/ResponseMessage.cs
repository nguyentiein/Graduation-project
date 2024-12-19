using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses
{
    public sealed class ResponseMessage
    {
        #region Property
        public Dictionary<string, string> Values { get; set; }
        #endregion
    }
    public enum CodeMessage
    {
        _98,
        _99,
        _200,
        _209,
        _210,
        _211,
        _212,
        _213,
        _214,
        _215,
        _216,
        _217,
        _223,
        _227,
        _228,
        _229,
        _230,
        _231,
        _233,
        _234,
        _236,
        _237,
        _239,
        _245,
        _300,
        _401,
    }
}
