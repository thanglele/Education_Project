using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace Sinhvien.tlu.Mainboard
{
	public partial class Calendar_services
	{
		private static string[] Scopes = { "https://www.googleapis.com/auth/calendar.calendarlist.readonly", "https://www.googleapis.com/auth/calendar.app.created" };
		private static string ApplicationName = "Education";
		private static string MSV = "";
		private static List<Regislist_Preview> regislist_Preview;

        private static string clientSecretJson = @"{""installed"":{""client_id"":""916619588737-3tac8hokbsgad163g4sh2e4jfi0as9oa.apps.googleusercontent.com"",""project_id"":""educationapi-432405"",""auth_uri"":""http://localhost""]}}";

		public Calendar_services(string temp, List<Regislist_Preview> regislist_inp)
		{
			MSV = temp;
			regislist_Preview = regislist_inp;
			send_regislist();
        }

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
				MessageBox.Show("Đăng nhập không thành công. Không thể hoàn thành tác vụ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
				"ID: " + MSV);

			if (existingCalendar != null)
			{
				// Lịch đã tồn tại, trả về calendarId của nó
				//MessageBox.Show("Found existing calendar with ID: " + existingCalendar.Id);
				return existingCalendar.Id;
			}
			else
			{
				// Tạo lịch phụ mới nếu chưa tồn tại
				var newCalendar = new Google.Apis.Calendar.v3.Data.Calendar()

                {
					Summary = "Lịch học",
					Description = "Lịch học được tạo tự động bởi Education-Tool" + "Một sản phẩm thuộc hệ thống NDCC." + "ID: " + MSV,
					TimeZone = "Asia/Ho_Chi_Minh"
				};

				var createdCalendar = service.Calendars.Insert(newCalendar).Execute();
				//MessageBox.Show("Created new calendar with ID: " + createdCalendar.Id);
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
			Regislist_Preview last_regis = new Regislist_Preview();
			foreach(Regislist_Preview regislist in regislist_Preview)
			{
				if(regislist.displayName == null)
				{
					regislist.displayName = last_regis.displayName;
					regislist.teacher_displayName = last_regis.teacher_displayName;
					regislist.numberStudent = last_regis.numberStudent;
				}	
				else
				{
					last_regis = regislist;
				}

				switch (Convert.ToInt32(regislist.weekIndex))
				{
                    case 2:
						regislist.weekIndex = "MO";
						break;
					case 3:
                        regislist.weekIndex = "TU";
                        break;
                    case 4:
                        regislist.weekIndex = "WE";
                        break;
                    case 5:
                        regislist.weekIndex = "TH";
                        break;
                    case 6:
                        regislist.weekIndex = "FR";
                        break;
                    case 7:
                        regislist.weekIndex = "SA";
                        break;
                    default:
                        regislist.weekIndex = "SU";
                        break;
                }

    //            Event subject = new Event()
				//{
    //                Summary = regislist.displayName,
				//	Location = regislist.nameRoom,

    //                Start = new EventDateTime()
    //                {
    //                    DateTime = DateTime.ParseExact(regislist.startDate + " " + regislist.startString, "dd/MM/yyyy HH:mm", null),
    //                    TimeZone = "Asia/Ho_Chi_Minh"
    //                },
    //                End = new EventDateTime()
    //                {
    //                    DateTime = DateTime.ParseExact(regislist.startDate + " " + regislist.endString, "dd/MM/yyyy HH:mm", null),
    //                    TimeZone = "Asia/Ho_Chi_Minh"
    //                },
    //                Recurrence = new string[]
				//	{
				//		$"RRULE:FREQ=WEEKLY;BYDAY={regislist.weekIndex};UNTIL=" + DateTime.ParseExact(regislist.endDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddHours(23).AddMinutes(59).AddSeconds(59).ToString("yyyyMMdd'T'HHmmss'Z'")
				//	},
    //                Reminders = new Event.RemindersData()
    //                {
    //                    UseDefault = false,
    //                    Overrides = new EventReminder[]
				//		{
				//			new EventReminder() { Method = "popup", Minutes = 30 }
				//		}
    //                }
    //            };
                // Thêm sự kiện vào lịch phụ
                service.Events.Insert(new Event()
                {
                    Summary = regislist.displayName,
                    Location = regislist.nameRoom,

                    Start = new EventDateTime()
                    {
                        DateTime = DateTime.ParseExact(regislist.startDate + " " + regislist.startString, "dd/MM/yyyy HH:mm", null),
                        TimeZone = "Asia/Ho_Chi_Minh"
                    },
                    End = new EventDateTime()
                    {
                        DateTime = DateTime.ParseExact(regislist.startDate + " " + regislist.endString, "dd/MM/yyyy HH:mm", null),
                        TimeZone = "Asia/Ho_Chi_Minh"
                    },
                    Recurrence = new string[]
                    {
                        $"RRULE:FREQ=WEEKLY;BYDAY={regislist.weekIndex};UNTIL=" + DateTime.ParseExact(regislist.endDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddHours(23).AddMinutes(59).AddSeconds(59).ToString("yyyyMMdd'T'HHmmss'Z'")
                    },
                    Reminders = new Event.RemindersData()
                    {
                        UseDefault = false,
                        Overrides = new EventReminder[]
                        {
                            new EventReminder() { Method = "popup", Minutes = 30 }
                        }
                    }
                }, calendarId).Execute();
            }	
			MessageBox.Show("Recurring event added to secondary calendar successfully.");
		}

		private async void send_regislist()
		{
			var calendarService = await Authenticate();

			if (calendarService != null)
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
				MessageBox.Show("Bạn chưa đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}