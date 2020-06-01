using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordLib.Models
{
    public class MethodResult
    {
        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        private object _tag;
        public object Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        public bool IsSuccess
        {
            get { return _status == 0; }
        }

        public override string ToString()
        {
            return string.Format("status = {0}, message = {1}, tag = {2}", _status, _message, _tag);
        }
    }
}
