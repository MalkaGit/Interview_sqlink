using sqlink.Common;
using sqlink.Common.Model;
using sqlink.DAL;
using System;
using System.Collections.Generic;

namespace sqlink.BL
{
    public class ReportService
    {

        #region singletone

        private ReportService()
        {
        }

        static ReportService()
        {
            ReportService.Instance = new ReportService();
        }

        public static ReportService Instance { get; private set; }

        #endregion


        public void AddReportEntry(ReportEntry model)
        {
            var repository = new ReportRepository();
            repository.AddReportEntry(model);
        }

        public  IEnumerable<ReportEntry> GetAll(eReportIntervalType reportIntervalType)
        {
            var repository = new ReportRepository();
            var result = repository.GetAll(reportIntervalType);

            return result;
        }

        public IEnumerable<Vehicle> GetTopVehicles(int topX)
        {
            var repository = new ReportRepository();
            var result = repository.GetTopVehicles(topX);

            return result;
        }

    }
}
