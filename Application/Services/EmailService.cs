using System;
using System.IO;

namespace LeadsService.Application.Services
{
    public class FakeEmailService
    {
        private readonly string _logDirectory;
        private readonly string _logFilePath;

        public FakeEmailService()
        {
            _logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Emails");
            _logFilePath = Path.Combine(_logDirectory, "emails.log");

            if (!Directory.Exists(_logDirectory))
            {
                Directory.CreateDirectory(_logDirectory);
            }
        }

        public void SendEmail(string recipient, string subject, string body)
        {
            try
            {
                string logEntry = $"To: {recipient}\nSubject: {subject}\n{body}\n\n";
                File.AppendAllText(_logFilePath, logEntry);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao escrever no arquivo: {ex.Message}");
            }
        }
    }
}
