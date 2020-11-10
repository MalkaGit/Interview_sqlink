using sqlink.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sqlink.DAL
{
    public class VehicleRepositry
    {

        private static Dictionary<long, Vehicle> dic_LicenseNumber_to_Vehicle = new Dictionary<long, Vehicle>();

        public void Create(Vehicle model)
        {
            dic_LicenseNumber_to_Vehicle[model.LicenseNumber] = model;
        }


        public Vehicle GetById(long licenseNumber)
        {
            if (dic_LicenseNumber_to_Vehicle.ContainsKey(licenseNumber))
            {
                return dic_LicenseNumber_to_Vehicle[licenseNumber];
            }

            return null;

        }



        public IEnumerable<Vehicle> GetAll(long? liceseNumber, string owner)
        {
            var result = dic_LicenseNumber_to_Vehicle.Values.ToList();

            if (liceseNumber != null)
            {
                result = result.Where(v => v.LicenseNumber == liceseNumber.Value).ToList();
            }

            if (owner != null)
            {
                result = result.Where(v => v.Owner == owner).ToList();
            }

            return result;
        }


        public bool Update(Vehicle model)
        {
            //case1:key does not exist - return false
            var storageModel = GetById(model.LicenseNumber);
            if (storageModel == null)
            {
                return false;
            }

            //case2: key exist - update and return true
            dic_LicenseNumber_to_Vehicle[model.LicenseNumber] = model;
            return true;
        }

        public void BulkUpdate(IEnumerable<Vehicle> models)
        {
            foreach (var model in models)
            {
                var updated = Update(model);
            }
        }


        public bool Delete(long licenseNumber)
        {

            //case1:key does not exist - return false
            var storageModel = GetById(licenseNumber);
            if (storageModel == null)
            {
                return false;
            }

            //case2: key exist - delete and return true
            dic_LicenseNumber_to_Vehicle.Remove(licenseNumber);
            return true;
        }


        public void BulkDelete(long[] lisenceNumbers)
        {
            foreach (var lisenceNumber in lisenceNumbers)
            {
                 Delete(lisenceNumber);
            }
        }
    
    }
}
