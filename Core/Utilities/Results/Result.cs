using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        // public bool Success { get; } normalde readonlydir. Set edilemez, okunabilir ama consructor da element set edilebilir
        public Result(bool success, string message):this(success) // Diğer consructora parametre yollar ikisi consructor da çalışmış olur.
        {
            Message = message;
        }
        // Overloading aşırı yükleme

        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
