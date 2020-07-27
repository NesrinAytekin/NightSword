using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NightSword.Business.Logger
{
    //Loglama islemi istenildiginde web ortamında bulunabilir hazır bir kalıptır.
    public class SystemLogger : ILogger
    {
        IWebHostEnvironment _hostEnvironment;

        public SystemLogger(IWebHostEnvironment hostEnvironment) => this._hostEnvironment = hostEnvironment;

        public async void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            using (StreamWriter streamWriter = new StreamWriter($"{_hostEnvironment.ContentRootPath}/log.txt", true)) //Loglama log.txt'de gorulebilecek.
            {
                await streamWriter.WriteLineAsync($"Log Level : {logLevel.ToString()} | Event Id: {eventId.Id} | Event Name: {eventId.Name} | Formatter: {formatter(state, exception)}");
                streamWriter.Close();
                await streamWriter.DisposeAsync();
            }
        }

        public bool IsEnabled(LogLevel logLevel) => true;

        public IDisposable BeginScope<TState>(TState state) => null;

    }
}
