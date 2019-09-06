using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeCount = 4;


            #region 工作日
            var easyDayOfWeek = new List<DayOfWeek>();

            easyDayOfWeek.Add(DayOfWeek.Monday);
            easyDayOfWeek.Add(DayOfWeek.Tuesday);
            easyDayOfWeek.Add(DayOfWeek.Wednesday);
            easyDayOfWeek.Add(DayOfWeek.Thursday);


            var easyDayPrepareEmployeeCount = 1;
            var easyDayBusyEmployeeCount = 3;

            //早班时间
            var easyDayEarlyFrom = "10:00:00";
            var easyDayEarlyTo = "20:00:00";

            //晚班时间
            var easyDayLateFrom = "12:00:00";
            var easyDayLateTo = "22:00:00";

            //通班时间
            var easyDayEntireFrom = "10:00:00";
            var easyDayEntireTo = "22:00:00";


            //计算多少人需要早班、多少人需要晚班、多少人需要通班

            #endregion


            #region 节假日
            var busyDayOfWeek = new List<DayOfWeek>();

            easyDayOfWeek.Add(DayOfWeek.Friday);
            easyDayOfWeek.Add(DayOfWeek.Saturday);
            easyDayOfWeek.Add(DayOfWeek.Sunday);


            var busyDayPrepareEmployeeCount = 2;

            var busyDayBusyEmployeeCount = 3;
            #endregion


            var year = "2019";

            var month = "9";


            var dayOfMonth = DateTime.DaysInMonth(2019, 9);

            var workPlan = new EmployeeWorkPlan[employeeCount,dayOfMonth];


            #region 开始排班
            for (var i = 1; i <= employeeCount; i++)
            {
                for (var j = 1; j <= dayOfMonth; j++)
                {

                    var dayOfWeek = DateTime.Parse(year+"-"+month+"-" + j).DayOfWeek;

                    var employeeWorkPlan = new EmployeeWorkPlan()
                    {
                        EmployeeName = "EmployeeName" + i,
                        DayOfMonth = j,
                        DayOfWeek = dayOfWeek,
                        RestDayOfWeek = (DayOfWeek)i
                    };

                    employeeWorkPlan.FromTime = DateTime.Now;
                    employeeWorkPlan.ToTime = DateTime.Now;

                    workPlan[i - 1,j - 1] = employeeWorkPlan;

                    //Console.WriteLine(j + "_" + DateTime.Parse("2019-09-" + i).DayOfWeek);
                }
            }
            #endregion



            #region 打印排班结果
            for (var i = 1; i <= employeeCount; i++)
            {
                for (var j = 1; j <= dayOfMonth; j++)
                {

                    var employeeWorkPlan = workPlan[i - 1, j - 1];

                    var printFormat = "员工姓名：{0}，当月{1}号，星期：{2}，上班时间{3}-{4}，是否休息：{5}";
                    var printContent = string.Format(printFormat, employeeWorkPlan.EmployeeName
                        , employeeWorkPlan.DayOfMonth
                        , employeeWorkPlan.DayOfWeek
                        , employeeWorkPlan.FromTime.ToString("HH:mm:ss")
                        , employeeWorkPlan.ToTime.ToString("HH:mm:ss")
                        , employeeWorkPlan.IsRest.ToString());

                    Console.WriteLine(printContent);

                }
            }
            #endregion





            Console.ReadKey();


        }

    }

    public class EmployeeWorkPlan
    {
        /// <summary>
        /// 员工名称
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// 每月的几号
        /// </summary>
        public int DayOfMonth { get; set; }
        /// <summary>
        /// 星期几
        /// </summary>
        public DayOfWeek DayOfWeek { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public  DateTime FromTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime ToTime { get; set; }
        /// <summary>
        /// 加班时间
        /// </summary>
        public decimal OT { get; set; }
        /// <summary>
        /// 每周几休息
        /// </summary>
        public DayOfWeek RestDayOfWeek { get; set; }
        /// <summary>
        /// 是否休息
        /// </summary>
        public bool IsRest { get { return DayOfWeek == RestDayOfWeek; } }
    }
}
