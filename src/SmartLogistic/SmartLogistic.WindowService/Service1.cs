using EntVisionLibraries.Common.API;
using EntVisionLibraries.Common.Enums;
using EntVisionLibraries.Common.Utilities.Interfaces;
using SmartLogistic.Domain.MapAggregate;
using SmartLogistic.Domain.TransportRequestAggregate;
using SmartLogistic.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace SmartLogistic.WindowService
{
    public partial class Service1 : ServiceBase
    {        
        Thread thread1, thread2;

        private System.Timers.Timer timer;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Debug.WriteLine("Service is started at " + DateTime.Now);
            //instantiate timer
            Thread t = new Thread(new ThreadStart(InitTimer));
            t.Start();       
        }

        private void InitTimer()
        {
            timer = new System.Timers.Timer();
            //wire up the timer event 
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            //set timer interval   
            //var timeInSeconds = Convert.ToInt32(ConfigurationManager.AppSettings["TimerIntervalInSeconds"]); 
            double timeInSeconds = 3.0;
            timer.Interval = (timeInSeconds * 1000);
            // timer.Interval is in milliseconds, so times above by 1000 
            timer.Enabled = true;
        }


        protected override void OnStop()
        {
            timer.Enabled = false;
            Debug.WriteLine("Service is stopped at " + DateTime.Now);
        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            try
            {
                timer.Enabled = true;
                Debug.WriteLine("Service is recall at " + DateTime.Now);

                timer.Enabled = false;
                thread1 = new Thread(new ThreadStart(JobAssignmentThread));
                thread1.Start();

                Thread.Sleep(5000);

                thread2 = new Thread(new ThreadStart(RouteOptimisationThread));
                thread2.Start();                

                timer.Enabled = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                timer.Enabled = true;
            }

        }

        private void JobAssignmentThread()
        {
            try
            {
                Debug.WriteLine("JobAssignment is started at " + DateTime.Now);
                
                var JobAssignment = new HttpRequestUtlitiy<ApiResponse>()
                    .Request(HttpRequestType.GET, $"http://localhost:59810/api/TransportManagement/JobAssignment");

                Debug.WriteLine(JobAssignment);

                Thread.Sleep(6000);
                //WriteToFile("JobAssignment is started at " + DateTime.Now);
                //var dataPending = context.TransportRequest.Where(x => x.Status == "Pending").ToList();
                //dataPending.ForEach(item =>
                //{
                //    item.AssignedStatus("Assigned");

                //    var geocodingDelivery = new HttpRequestUtlitiy<Geocoding>()
                //        .Request(HttpRequestType.GET, $"http://localhost:59810/Geocoding?address={item.Delivery}");

                //    item.Delivery.Latitude = geocodingDelivery.Geometry.Location.Lat;
                //    item.Delivery.Longitude = geocodingDelivery.Geometry.Location.Lng;

                //    var geocodingPickup = new HttpRequestUtlitiy<Geocoding>()
                //        .Request(HttpRequestType.GET, $"http://localhost:59810/Geocoding?address={item.Pickup}");

                //    item.Pickup.Latitude = geocodingPickup.Geometry.Location.Lat;
                //    item.Pickup.Longitude = geocodingPickup.Geometry.Location.Lng;

                //    item.DeliveryDate = DateTime.Now;
                //    item.AssignedVehicle("Vehicle Default");

                //    context.TransportRequest.Attach(item);

                //    context.Entry(item).State = EntityState.Modified;

                //    context.SaveChanges();

                //    Thread.Sleep(10000);
                //});

                //WriteToFile("Total Job Assigned is " + dataPending.Count);
                //WriteToFile("JobAssignment is fisnihed at " + DateTime.Now);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public void RouteOptimisationThread()
        {
            try
            {
                Debug.WriteLine("RouteOptimisationThread is started at " + DateTime.Now);                
                
                var RouteOptimisation = new HttpRequestUtlitiy<ApiResponse>()
                        .Request(HttpRequestType.GET, $"http://localhost:59810/api/TransportManagement/RouteOptimisation");

                Debug.WriteLine(RouteOptimisation);

                Thread.Sleep(6000);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            //WriteToFile("RouteOptimisationThread is started at " + DateTime.Now);
            //var dataPending = context.TransportRequest.Where(x => x.Status == "Pending").ToList();
            //dataPending.ForEach(item =>
            //{
            //    item.AssignedStatus("Routed");

            //    context.TransportRequest.Attach(item);

            //    context.Entry(item).State = EntityState.Modified;

            //    context.SaveChanges();

            //    Thread.Sleep(10000);
            //});

            
            //WriteToFile("Total Job Assigned is " + dataPending.Count);
            //WriteToFile("JobAssignment is fisnihed at " + DateTime.Now);

        }

        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }
    }
}
