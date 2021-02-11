using AutoWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlintaAPI.Models
{
    public class MapResponseObject
    {
        [AutoWrapperPropertyMap(Prop.ResponseException)]
        public object Error { get; set; }

        [AutoWrapperPropertyMap(Prop.ResponseException_ExceptionMessage)]
        public string Message { get; set; }

        [AutoWrapperPropertyMap(Prop.ResponseException_Details)]
        public string StackTrace { get; set; }
        
        [AutoWrapperPropertyMap(Prop.StatusCode)]
        public object StatusCode { get; set; }

        [AutoWrapperPropertyMap(Prop.Result)]
        public object Data { get; set; }
    }
}
