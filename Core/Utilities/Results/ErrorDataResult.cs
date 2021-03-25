using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }

        public ErrorDataResult(T data) : base(data, false)
        {

        }
        public ErrorDataResult(string message) : base(default, false, message) // default halini döndürür, default tipi dataya denk gelir. örneğin int döner ve bir değer döndürmek istemeyiz
        {

        }
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
