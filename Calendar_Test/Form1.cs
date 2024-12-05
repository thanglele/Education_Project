using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static string[] Scopes = { "https://www.googleapis.com/auth/calendar.calendarlist.readonly", "https://www.googleapis.com/auth/calendar.app.created" };
        private static string ApplicationName = "Education";

        // Đặt nội dung JSON của credentials.json vào một chuỗi
        private static string clientSecretJson = @"{""installed"":{""client_id"":""916619588737-3tac8hokbsgad163g4sh2e4jfi0as9oa.apps.googleusercontent.com"",""project_id"":""educationapi-432405"",""auth_uri"":""https://accounts.google.com/o/oauth2/auth"",""token_uri"":""https://oauth2.googleapis.com/token"",""auth_provider_x509_cert_url"":""https://www.googleapis.com/oauth2/v1/certs"",""client_secret"":""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"",""redirect_uris"":[""http://localhost""]}}";

        public static async Task<CalendarService> Authenticate()
        {
            var clientSecrets = GoogleClientSecrets.FromStream(new MemoryStream(Encoding.UTF8.GetBytes(clientSecretJson))).Secrets;

            // Sử dụng LocalServerCodeReceiver để mở trình duyệt và theo dõi trạng thái
            var codeReceiver = new Google.Apis.Auth.OAuth2.LocalServerCodeReceiver();

            var authorizationCodeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = clientSecrets,
                Scopes = new string[] { "https://www.googleapis.com/auth/calendar.calendarlist.readonly", "https://www.googleapis.com/auth/calendar.app.created" },
                DataStore = null
            });

            var authResult = await new AuthorizationCodeInstalledApp(authorizationCodeFlow, codeReceiver)
                .AuthorizeAsync("user", CancellationToken.None);

            // Kiểm tra nếu đăng nhập thành công, authResult sẽ không null
            if (authResult != null && !authResult.Token.IsExpired(authorizationCodeFlow.Clock))
            {
                return new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = authResult,
                    ApplicationName = ApplicationName,
                });
            }
            else
            {
                // Nếu authResult là null hoặc token hết hạn, nghĩa là quá trình đăng nhập đã thất bại hoặc bị đóng
                MessageBox.Show("Đăng nhập thất bại hoặc bị hủy.");
                return null;
            }
        }

        public static string CreateSecondaryCalendar(CalendarService service)
        {
            // Lấy danh sách lịch của người dùng
            var calendarList = service.CalendarList.List().Execute().Items;

            // Tìm kiếm lịch phụ dựa trên tên và thuộc tính Description đặc biệt
            var existingCalendar = calendarList.FirstOrDefault(c =>
                c.Summary == "Lịch học" &&
                c.Description == "Lịch học được tạo tự động bởi Education-Tool" +
                "Một sản phẩm thuộc hệ thống NDCC." +
                "ID: MSV");

            if (existingCalendar != null)
            {
                // Lịch đã tồn tại, trả về calendarId của nó
                MessageBox.Show("Found existing calendar with ID: " + existingCalendar.Id);
                return existingCalendar.Id;
            }
            else
            {
                // Tạo lịch phụ mới nếu chưa tồn tại
                var newCalendar = new Calendar()
                {
                    Summary = "Lịch học",
                    Description = "Lịch học được tạo tự động bởi Education-Tool" + "Một sản phẩm thuộc hệ thống NDCC." + "ID: MSV",
                    TimeZone = "Asia/Ho_Chi_Minh"
                };

                var createdCalendar = service.Calendars.Insert(newCalendar).Execute();
                MessageBox.Show("Created new calendar with ID: " + createdCalendar.Id);
                return createdCalendar.Id;
            }
        }

        public static void DeleteAllEventsInCalendar(CalendarService service, string calendarId)
        {
            var request = service.Events.List(calendarId);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            var events = request.Execute().Items;

            foreach (var ev in events)
            {
                service.Events.Delete(calendarId, ev.Id).Execute();
                Console.WriteLine($"Deleted event with ID: {ev.Id}");
            }
        }

        public static void AddEventToSecondaryCalendar(CalendarService service, string calendarId)
        {
            // Tạo sự kiện với các thuộc tính được yêu cầu
            Event newEvent = new Event()
            {
                Summary = "Lớp chủ nghĩa xã hội khoa học-1-24",
                Location = "327-A2",
                Start = new EventDateTime()
                {
                    DateTime = new DateTime(2024, 11, 14, 12, 55, 0),
                    TimeZone = "Asia/Ho_Chi_Minh"
                },
                End = new EventDateTime()
                {
                    DateTime = new DateTime(2024, 11, 14, 14, 40, 0),
                    TimeZone = "Asia/Ho_Chi_Minh"
                },
                Recurrence = new string[]
                {
                    "RRULE:FREQ=WEEKLY;BYDAY=TH,SA;UNTIL=20250105T235959Z"
                },
                Reminders = new Event.RemindersData()
                {
                    UseDefault = false,
                    Overrides = new EventReminder[]
                    {
                        new EventReminder() { Method = "popup", Minutes = 30 }
                    }
                }
            };

            
            // Thêm sự kiện vào lịch phụ
            service.Events.Insert(newEvent, calendarId).Execute();
            MessageBox.Show("Recurring event added to secondary calendar successfully.");
        }

        // Xóa token khỏi bộ nhớ khi đóng ứng dụng
        public static void ClearToken()
        {
            // Hủy token tạm thời (nếu có)
            if (GoogleWebAuthorizationBroker.Folder != null && Directory.Exists(GoogleWebAuthorizationBroker.Folder))
            {
                Directory.Delete(GoogleWebAuthorizationBroker.Folder, true);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var calendarService = await Authenticate();

            if(calendarService != null)
            {
                // Tạo lịch phụ nếu chưa có, hoặc lấy calendarId đã tạo
                string calendarId = CreateSecondaryCalendar(calendarService);

                // Xóa tất cả sự kiện trong lịch phụ
                DeleteAllEventsInCalendar(calendarService, calendarId);

                // Thêm sự kiện vào lịch phụ
                AddEventToSecondaryCalendar(calendarService, calendarId);
            }   
            else
            {
                MessageBox.Show("Bạn chưa đăng nhập!");
            }    
        }
    }
}
