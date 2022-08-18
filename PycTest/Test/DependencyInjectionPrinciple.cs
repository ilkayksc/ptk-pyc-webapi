using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PycTest.Test
{

    // old way 
    class DBLogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine(String.Format("DBLogger : {0}", message));
        }
    }
    class MailSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine(String.Format("MailSender : {0}", message));
        }
    }
    class FileLogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine(String.Format("FileLogger : {0}", message));
        }
    }
    class SMSSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine(String.Format("SMSSender : {0}", message));
        }
    }
    class OldProcessor
    {
        public void Process1()
        {
            //DBLogger logger = new DBLogger();                   
            FileLogger logger = new FileLogger();
            logger.WriteLog("Log Text");
            //Ana Uygulama Akışı          
            //MailSender messageSender = new MailSender();
            SMSSender messageSender = new SMSSender();
            messageSender.SendMessage("Message Text");
        }
        public void Process2()
        {
            DBLogger logger = new DBLogger();
            logger.WriteLog("Log Text");
            //Ana Uygulama Akışı          
            MailSender messageSender = new MailSender();
            messageSender.SendMessage("Message Text");
        }
    }




    // Dependency inject 
    interface IMessageSender
    {
        void SendMessage(string Message);
    }
    interface ILogger
    {
        void WriteLog(string message);
    }
    class SqlDbLogger : ILogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine(String.Format("SqlDbLogger : {0}", message));
        }
    }
    class PdfFileLogger : ILogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine(String.Format("PdfFileLogger : {0}", message));
        }
    }
    class SmtpMailSender : IMessageSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine(String.Format("SmtpMailSender : {0}", message));
        }
    }  
    class TwillioSMSSender : IMessageSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine(String.Format("SMSSender : {0}", message));
        }
    }
    class MainProcessor
    {
        ILogger logger = null;
        IMessageSender messageSender;
        public MainProcessor(ILogger _logger, IMessageSender _messageSender)
        {
            logger = _logger;
            messageSender = _messageSender;
        }
        public void Process()
        {
            logger.WriteLog("Log Text");          
            messageSender.SendMessage("Message Text");
        }
    }



    public  class DependencyInjectionPrinciple
    {
        [Test]
        public void Test()
        {
            IMessageSender msgsender1 = new TwillioSMSSender();
            ILogger logr2 = new SqlDbLogger();
            MainProcessor processor = new MainProcessor(logr2, msgsender1);
            processor.Process();
        }
    }
}
