using System;
using System.Collections.Generic;
using System.Text;

namespace PracteceService.Test.Helper
{
    public class HttpMethodCode
    {
        public string Code;

        private HttpMethodCode(string code)
        {
            Code = code;
        }

        public static HttpMethodCode GET { get { return new HttpMethodCode("GET"); } }

        public static HttpMethodCode POST { get { return new HttpMethodCode("POST"); } }

        public static HttpMethodCode PUT { get { return new HttpMethodCode("PUT"); } }

        public static HttpMethodCode DELETE { get { return new HttpMethodCode("DELETE"); } }

        public static HttpMethodCode PATCH { get { return new HttpMethodCode("PATCH"); } }
    }
}
