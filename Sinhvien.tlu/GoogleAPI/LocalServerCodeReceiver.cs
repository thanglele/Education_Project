//using Google.Apis.Auth.OAuth2;
//using Google.Apis.Calendar.v3;
//using Google.Apis.Services;
//using Google.Apis.Util.Store;
//using System.IO;
//using System.Threading;
//using System;
//using Google.Apis.Auth.OAuth2.Requests;
//using Google.Apis.Auth.OAuth2.Responses;
//using System.Diagnostics;
//using System.Net;
//using System.Threading.Tasks;
//using Google.Apis.Calendar.v3.Data;

//namespace Sinhvien.tlu.GoogleAPI
//{
//    class GoogleCalendar
//    {
//        static string[] Scopes = { CalendarService.Scope.Calendar };
//        static string ApplicationName = "Google Calendar API .NET Quickstart";

//        public class LocalServerCodeReceiver : ICodeReceiver
//        {
//            private const string LoopbackCallbackPath = "/authorize/";
//            private const string LoopbackCallbackHost = "http://localhost";
//            private const int DefaultPort = 8080;

//            public string RedirectUri => $"{LoopbackCallbackHost}:{DefaultPort}{LoopbackCallbackPath}";

//            public async Task<AuthorizationCodeResponseUrl> ReceiveCodeAsync(AuthorizationCodeRequestUrl url, CancellationToken taskCancellationToken)
//            {
//                using (var listener = new HttpListener())
//                {
//                    listener.Prefixes.Add(RedirectUri);
//                    listener.Start();

//                    Process.Start(new ProcessStartInfo
//                    {
//                        FileName = url.Build().AbsoluteUri,
//                        UseShellExecute = true
//                    });

//                    var context = await listener.GetContextAsync();

//                    var response = context.Response;
//                    string responseString = "<html><head></head><body>Authorization received. You can close this tab.</body></html>";
//                    var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
//                    response.ContentLength64 = buffer.Length;
//                    var responseOutput = response.OutputStream;
//                    await responseOutput.WriteAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
//                    responseOutput.Close();

//                    var code = context.Request.QueryString["code"];
//                    var error = context.Request.QueryString["error"];

//                    if (!string.IsNullOrEmpty(error))
//                    {
//                        throw new Exception($"OAuth2 Authorization Error: {error}");
//                    }

//                    return new AuthorizationCodeResponseUrl
//                    {
//                        Code = code,
//                        State = context.Request.QueryString["state"]
//                    };
//                }
//            }
//        }

//        private void AuthenticateUser()
//        {
//            UserCredential credential;
//            string credPath = "token.json";

//            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
//            {
//                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
//                    GoogleClientSecrets.Load(stream).Secrets,
//                    Scopes,
//                    "user",
//                    CancellationToken.None,
//                    new FileDataStore(credPath, true),
//                    new LocalServerCodeReceiver()).Result;

//                Console.WriteLine("Credential file saved to: " + credPath);
//            }

//            // Create Google Calendar API service.
//            var service = new CalendarService(new BaseClientService.Initializer()
//            {
//                HttpClientInitializer = credential,
//                ApplicationName = ApplicationName,
//            });

//            // Define parameters of request.
//            EventsResource.ListRequest request = service.Events.List("primary");
//            request.TimeMin = DateTime.Now;
//            request.ShowDeleted = false;
//            request.SingleEvents = true;
//            request.MaxResults = 10;
//            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

//            // List events.
//            Events events = request.Execute();
//            Console.WriteLine("Upcoming events:");
//            if (events.Items != null && events.Items.Count > 0)
//            {
//                foreach (var eventItem in events.Items)
//                {
//                    string when = eventItem.Start.DateTime.ToString();
//                    if (String.IsNullOrEmpty(when))
//                    {
//                        when = eventItem.Start.Date;
//                    }
//                    Console.WriteLine("{0} ({1})", eventItem.Summary, when);
//                }
//            }
//            else
//            {
//                Console.WriteLine("No upcoming events found.");
//            }
//        }

//        private void addEvent()
//        {
//            // Use the service object created in the btnAuthenticate_Click method
//            // to create a new event
//            var service = new CalendarService(new BaseClientService.Initializer()
//            {
//                HttpClientInitializer = credential,
//                ApplicationName = ApplicationName,
//            });

//            Event newEvent = new Event()
//            {
//                Summary = "Google I/O 2025",
//                Location = "800 Howard St., San Francisco, CA 94103",
//                Description = "A chance to hear more about Google's developer products.",
//                Start = new EventDateTime()
//                {
//                    DateTime = DateTime.Now.AddDays(1),
//                    TimeZone = "America/Los_Angeles",
//                },
//                End = new EventDateTime()
//                {
//                    DateTime = DateTime.Now.AddDays(1).AddHours(1),
//                    TimeZone = "America/Los_Angeles",
//                },
//                Recurrence = new String[] { "RRULE:FREQ=DAILY;COUNT=2" },
//                Attendees = new EventAttendee[] {
//                    new EventAttendee() { Email = "lpage@example.com" },
//                    new EventAttendee() { Email = "sbrin@example.com" },
//                },
//                Reminders = new Event.RemindersData()
//                {
//                    UseDefault = false,
//                    Overrides = new EventReminder[] {
//                        new EventReminder() { Method = "email", Minutes = 24 * 60 },
//                        new EventReminder() { Method = "sms", Minutes = 10 },
//                    }
//                }
//            };

//            String calendarId = "primary";
//            EventsResource.InsertRequest request = service.Events.Insert(newEvent, calendarId);
//            Event createdEvent = request.Execute();
//            Console.WriteLine("Event created: {0}", createdEvent.HtmlLink);
//        }
//        private void removeEvent()
//        {
//            // Use the service object created in the btnAuthenticate_Click method
//            // to delete an event
//            var service = new CalendarService(new BaseClientService.Initializer()
//            {
//                HttpClientInitializer = credential,
//                ApplicationName = ApplicationName,
//            });

//            // Replace 'eventId' with the actual event ID to be deleted
//            string eventId = "eventId";
//            EventsResource.DeleteRequest request = service.Events.Delete("primary", eventId);
//            request.Execute();
//            Console.WriteLine("Event deleted.");
//        }
//    }
//}
