using System;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace AutomationPracticeProject.Helpers
{
    public static class GMailHelper
    {
        private static string[] _scopes = {GmailService.Scope.GmailSend, GmailService.Scope.GmailReadonly};
        private static string _applicationName = "Gmail API .NET Quickstart";
        private static GmailService _service;

        public static void ConnectToGMailApi(string senderNickname)
        {
            if (_service == null)
            {
                UserCredential credential;
                using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    var credPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets, _scopes, senderNickname, CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                }

                _service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = _applicationName,
                });
            }
        }

        public static void SendMessageWithAttachment(string senderNickname, string from, string to, string subject,
            string body, string attachmentPath)
        {
            ConnectToGMailApi(senderNickname);
            var mail = new MailMessage
            {
                Subject = subject,
                Body = body,
                From = new MailAddress(from),
                IsBodyHtml = true
            };
            mail.To.Add(new MailAddress(to));
            mail.Attachments.Add(new Attachment(attachmentPath));
            var mimeMessage = MimeKit.MimeMessage.CreateFromMailMessage(mail);
            var message = new Message {Raw = Base64UrlEncode(mimeMessage.ToString())};
            _service.Users.Messages.Send(message, from).Execute();
        }

        private static string Base64UrlEncode(string input)
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);

            return Convert.ToBase64String(inputBytes)
                .Replace('+', '-')
                .Replace('/', '_')
                .Replace("=", "");
        }

        public static string ReadLastInboxMessage(string senderNickname, string userId)
        {
            ConnectToGMailApi(senderNickname);
            var inboxListRequest = _service.Users.Messages.List(userId);
            inboxListRequest.LabelIds = "INBOX";
            inboxListRequest.IncludeSpamTrash = false;
            var emailListResponse = inboxListRequest.Execute();
            var message = _service.Users.Messages.Get(userId, emailListResponse.Messages.First().Id).Execute();
            return message.Snippet;
        }
    }
}