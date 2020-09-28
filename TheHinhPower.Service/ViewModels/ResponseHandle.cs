using System;
using System.Collections.Generic;
using System.Text;

namespace TheHinhPower.Service.ViewModels
{
    public class ResponseHandle
    {
        public ResponseHandle()
        {

        }
        public bool status { get; set; }
        public string errorMessage { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public ResponseHandle(bool status, string errorMessage, object data)
        {
            this.status = status;
            this.errorMessage = errorMessage;
            this.data = data;
        }
        public ResponseHandle(bool status, string errorMessage, string message, object data)
        {
            this.status = status;
            this.message = message;
            this.errorMessage = errorMessage;
            this.data = data;
        }
    }
}
