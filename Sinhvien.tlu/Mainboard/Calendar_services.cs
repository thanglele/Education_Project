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
        private static List<ListRoomExam_Preview> examlist_Preview;
        private TaskCompletionSource<bool> _taskCompletionSource = new TaskCompletionSource<bool>();
        private TaskCompletionSource<bool> _taskCompletionSource2 = new TaskCompletionSource<bool>();

        public Calendar_services(string temp, List<Regislist_Preview> regislist_inp)
		{
			MSV = temp;
			regislist_Preview = regislist_inp;
        }

        public Calendar_services(string temp, List<ListRoomExam_Preview> examlist_inp)
        {
            MSV = temp;
            examlist_Preview = examlist_inp;
        }

        public static async Task<CalendarService> Authenticate()
		{
            var clientSecrets = GoogleClientSecrets.FromStream(new MemoryStream(Encoding.UTF8.GetBytes(@"{""installed"":{""client_id"":"",""project_id"":"",""auth_uri"":"",""token_uri"":"""","""":"""",""client_secret"":"""",""redirect_uris"":[""http://localhost""]}}"))).Secrets;

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
				" Một sản phẩm thuộc hệ thống NDCC." +
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
        public static string CreateSecondaryCalendarExam(CalendarService service)
        {
            // Lấy danh sách lịch của người dùng
            var calendarList = service.CalendarList.List().Execute().Items;

            // Tìm kiếm lịch phụ dựa trên tên và thuộc tính Description đặc biệt
            var existingCalendar = calendarList.FirstOrDefault(c =>
                c.Summary == "Lịch thi" &&
                c.Description == "Lịch thi được tạo tự động bởi Education-Tool" +
                " Một sản phẩm thuộc hệ thống NDCC." +
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
                    Summary = "Lịch thi",
                    Description = "Lịch thi được tạo tự động bởi Education-Tool" + "Một sản phẩm thuộc hệ thống NDCC." + "ID: " + MSV,
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

			if(events.Count != 0)
			{
                foreach (var ev in events)
                {
                    service.Events.Delete(calendarId, ev.Id).Execute();
                    Console.WriteLine($"Deleted event with ID: {ev.Id}");
                }
            }
		}

        public static DateTime? GetFirstDayOfWeekInRange(DateTime startDate, DateTime endDate, string weekIndex_string)
        {
            int weekIndex;
            switch (weekIndex_string)
            {
                case "MO":
                    weekIndex = 1;
                    break;
                case "TU":
                    weekIndex = 2;
                    break;
                case "WE":
                    weekIndex = 3;
                    break;
                case "TH":
                    weekIndex = 4;
                    break;
                case "FR":
                    weekIndex = 5;
                    break;
                case "SA":
                    weekIndex = 6;
                    break;
                default:
                    weekIndex = 7;
                    break;
            }

            // Ngày đầu tiên tìm thấy là startDate + daysToAdd
            DateTime firstDate = startDate.AddDays((weekIndex - (int)startDate.DayOfWeek + 7) % 7);

            // Kiểm tra xem ngày tìm thấy có nằm trong khoảng không
            if (firstDate <= endDate)
            {
                return firstDate;
            }

            // Trả về null nếu không có ngày hợp lệ trong khoảng
            return null;
        }

        public static void AddEventToSecondaryCalendar(CalendarService service, string calendarId)
		{
			Regislist_Preview last_regis = new Regislist_Preview();
            foreach (Regislist_Preview regislist in regislist_Preview)
            {
                if (regislist.displayName == null)
                {
                    regislist.displayName = last_regis.displayName;
                    regislist.teacher_displayName = last_regis.teacher_displayName;
                    regislist.numberStudent = last_regis.numberStudent;
                }
                else
                {
                    last_regis = regislist;
                }

                switch (regislist.weekIndex)
                {
                    case "Thứ 2":
                        regislist.weekIndex = "MO";
                        break;
                    case "Thứ 3":
                        regislist.weekIndex = "TU";
                        break;
                    case "Thứ 4":
                        regislist.weekIndex = "WE";
                        break;
                    case "Thứ 5":
                        regislist.weekIndex = "TH";
                        break;
                    case "Thứ 6":
                        regislist.weekIndex = "FR";
                        break;
                    case "Thứ 7":
                        regislist.weekIndex = "SA";
                        break;
                    default:
                        regislist.weekIndex = "SU";
                        break;
                }
                DateTime? firstday_weekindex = GetFirstDayOfWeekInRange(DateTime.ParseExact(regislist.startDate, "dd-MM-yyyy", null), DateTime.ParseExact(regislist.endDate, "dd-MM-yyyy", null), regislist.weekIndex);

                Event subject = new Event();

                subject.Summary = regislist.displayName;
                subject.Location = regislist.nameRoom;

                subject.Start = new EventDateTime();
                subject.Start.DateTime = DateTime.ParseExact(firstday_weekindex.Value.ToString("dd-MM-yyyy") + " " + regislist.startString, "dd-MM-yyyy HH:mm", null);
                subject.Start.TimeZone = "Asia/Ho_Chi_Minh";
                subject.End = new EventDateTime();
                subject.End.DateTime = DateTime.ParseExact(firstday_weekindex.Value.ToString("dd-MM-yyyy") + " " + regislist.endString, "dd-MM-yyyy HH:mm", null);
                subject.End.TimeZone = "Asia/Ho_Chi_Minh";
                subject.Recurrence = new string[]
                    {
                        $"RRULE:FREQ=WEEKLY;BYDAY={regislist.weekIndex};UNTIL=" + DateTime.ParseExact(regislist.endDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).AddHours(23).AddMinutes(59).AddSeconds(59).ToString("yyyyMMdd'T'HHmmss'Z'")
                    };
                subject.Reminders = new Event.RemindersData()
                {
                    UseDefault = false,
                    Overrides = new EventReminder[]
                        {
                            new EventReminder() { Method = "popup", Minutes = 30 }
                        }
                };

                // Thêm sự kiện vào lịch phụ
                service.Events.Insert(subject, calendarId).Execute();

                switch (regislist.weekIndex)
                {
                    case "MO":
                        regislist.weekIndex = "Thứ 2";
                        break;
                    case "TU":
                        regislist.weekIndex = "Thứ 3";
                        break;
                    case "WE":
                        regislist.weekIndex = "Thứ 4";
                        break;
                    case "TH":
                        regislist.weekIndex = "Thứ 5";
                        break;
                    case "FR":
                        regislist.weekIndex = "Thứ 6";
                        break;
                    case "SA":
                        regislist.weekIndex = "Thứ 7";
                        break;
                    default:
                        regislist.weekIndex = "Chủ nhật";
                        break;
                }
            }
			MessageBox.Show("Lịch học đã được gửi lên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
        public static void AddEventToSecondaryCalendarExam(CalendarService service, string calendarId)
        {
            ListRoomExam_Preview last_exam = new ListRoomExam_Preview();
            foreach (ListRoomExam_Preview examlist in examlist_Preview)
            {
                if(examlist.subjectName != "Tên môn học")
                {
                    Event exam = new Event();

                    exam.Summary = examlist.subjectName;
                    exam.Location = examlist.name;
                    exam.Description = "Số báo danh: " + examlist.examCode;

                    exam.Start = new EventDateTime();
                    exam.Start.DateTime = DateTime.ParseExact(examlist.examDateString.ToString() + " " + examlist.startString, "dd/MM/yyyy HH:mm", null);
                    exam.Start.TimeZone = "Asia/Ho_Chi_Minh";
                    exam.End = new EventDateTime();
                    exam.End.DateTime = DateTime.ParseExact(examlist.examDateString.ToString() + " " + examlist.startString, "dd/MM/yyyy HH:mm", null);
                    exam.End.TimeZone = "Asia/Ho_Chi_Minh";
                    //exam.Recurrence = new string[]
                    //    {
                    //        $"RRULE:FREQ=WEEKLY;BYDAY={examlist.weekIndex};UNTIL=" + DateTime.ParseExact(examlist.endDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).AddHours(23).AddMinutes(59).AddSeconds(59).ToString("yyyyMMdd'T'HHmmss'Z'")
                    //    };
                    exam.Reminders = new Event.RemindersData()
                    {
                        UseDefault = false,
                        Overrides = new EventReminder[]
                            {
                            new EventReminder() { Method = "popup", Minutes = 30 }
                            }
                    };

                    // Thêm sự kiện vào lịch phụ
                    service.Events.Insert(exam, calendarId).Execute();
                }    
            }
            MessageBox.Show("Lịch thi đã được gửi lên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public async void send_regislist()
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
            _taskCompletionSource.SetResult(true);
        }

        public async void send_examlist()
        {
            var calendarService = await Authenticate();

            if (calendarService != null)
            {
                // Tạo lịch phụ nếu chưa có, hoặc lấy calendarId đã tạo
                string calendarId = CreateSecondaryCalendarExam(calendarService);

                // Xóa tất cả sự kiện trong lịch phụ
                DeleteAllEventsInCalendar(calendarService, calendarId);

                // Thêm sự kiện vào lịch phụ
                AddEventToSecondaryCalendarExam(calendarService, calendarId);
            }
            else
            {
                MessageBox.Show("Bạn chưa đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _taskCompletionSource2.SetResult(true);
        }
        public Task GetTask() => _taskCompletionSource.Task;
        public Task GetTask2() => _taskCompletionSource2.Task;
    }
}
