﻿namespace RecruitmentPlatform.Api.Models
{
    public class Response
    {
        public int StatusCode { get; set; } = 200;
        public string Message { get; set; }
        public object Data { get; set; }

    }
}
