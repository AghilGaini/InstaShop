using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace MyException
{
    public class CustomException : Exception
    {

        private static Hashtable _exceptionsList;

        private int? _exceptionCode;

        public int ExceptionCode
        {
            get
            {
                if (_exceptionCode.HasValue)
                    return _exceptionCode.Value;
                return 9000;
            }
        }
        public CustomException()
        {
            if (_exceptionsList == null || _exceptionsList.Count == 0)
            {
                var Exceptions = BusinessLite.FacadeInstaShop.GetBasicValueBusiness().GetExceptions();
                _exceptionsList = new Hashtable();
                foreach (var item in Exceptions)
                {
                    _exceptionsList.Add(item.EnTitle, item.Identifier);
                }
            }
        }
        public CustomException(string message)
            : base(message)
        {
            if (_exceptionsList == null || _exceptionsList.Count == 0)
            {
                var Exceptions = BusinessLite.FacadeInstaShop.GetBasicValueBusiness().GetExceptions();
                _exceptionsList = new Hashtable();
                foreach (var item in Exceptions)
                {
                    _exceptionsList.Add(item.EnTitle, item.Identifier);
                }
            }

            var ExceptionCode = new object();
            if (_exceptionsList.ContainsKey(message))
                ExceptionCode = _exceptionsList[message];

            if (ExceptionCode.GetType() != typeof(int))
                _exceptionCode = 9000;
            else
                _exceptionCode = ExceptionCode.ToInt();

        }

    }
}
