using System;

namespace Qna.Api.Shared
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int DataCount { get; set; }
        public object Data { get; set; }

        public ApiResponse(object data, int count = 0)
        {
            if (data == null)
            {
                Success = true;
                Message = "No data returned for query";
                DataCount = 0;
                Data = null;
            }
            else if (data.GetType() == typeof(Exception))
            {
                Exception e = (Exception)data;
                Success = false;
                Message = e.Message;
                DataCount = 0;
                Data = null;
            }
            else
            {
                Success = true;
                Message = "";
                Data = data;
                DataCount = count;
            }
        }
    }
}