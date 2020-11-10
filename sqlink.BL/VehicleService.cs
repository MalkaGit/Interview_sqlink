using sqlink.Common;
using sqlink.Common.Exceptions;
using sqlink.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace sqlink.BL
{
    public class VehicleService
    {

        #region singletone

        private VehicleService()
        {
        }

        static VehicleService()
        {
            VehicleService.Instance = new VehicleService();
        }

        public static VehicleService Instance { get; private set; }

        #endregion


        public void Create(Vehicle model)
        {
            
            var repositry = new VehicleRepositry();

            if (model == null || model.LicenseNumber == 0)
            {
                throw new BaseException("LicenseNumber is manadatory");
            }

            var model_from_Db = repositry.GetById(model.LicenseNumber);
            if (model_from_Db != null)
            {
                throw new BaseException("Vehicle already exists.");
            }
            

            repositry.Create(model);

        }


        public IEnumerable<Vehicle> GetAll(long? licenseNumber, string owner)
        {
            var repositry   = new VehicleRepositry();
            var result      = repositry.GetAll(licenseNumber, owner);

            return result;
        }


        public bool Update(Vehicle model)
        {
            var repositry   = new VehicleRepositry();
            var result      = repositry.Update(model);

            return result;
        }


        public void BulkUpdate(IEnumerable<Vehicle> models)
        {
            var repositry = new VehicleRepositry();
            repositry.BulkUpdate(models);
        }

        public bool Delete(long licenseNumber)
        {
            var repositry   = new VehicleRepositry();
            var result      = repositry.Delete(licenseNumber);

            return result;
        }

        public void BulkDelete(long[] lisenceNumbers)
        {
            var repositry = new VehicleRepositry();
            repositry.BulkDelete(lisenceNumbers);

        }


    }
}
