using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace Chocoholics.Business
{
    /// <summary>
    /// An alphabetically ordered list of service names and corresponding 
    /// service codes and fees.
    /// </summary>
    public class ProviderDirectory
    {
        // constructors
        public ProviderDirectory()
        {
            _services = new List<Service>();
        }

        // fields
        private List<Service> _services;

        // properties
        public IReadOnlyCollection<Service> Services
        {
            get { return _services.AsReadOnly(); }
        }

        // methods
        public void Load()
        {
            // load directory from database.
            try
            {
                _services.Clear();
                _services = Database.ServicesDb.GetAllServices();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Saves a csv file to the desired path.
        /// </summary>
        /// <param name="path">The location to save.</param>
        public void SaveToDisk(string path)
        {
            /* save the provider directory to a file on disk,    
            so it can be emailed as an attachment.*/
            try
            {
                if (_services.Count == 0)
                {
                    throw new InvalidOperationException("No services exist, did you forget to load them?");
                }

                FileInfo file = new FileInfo(path);
                if (!Directory.Exists(file.DirectoryName))
                {
                    Directory.CreateDirectory(file.DirectoryName);
                }

                using (StreamWriter sr = new StreamWriter(path, false))
                {
                    sr.WriteLine("\"Name\",\"Code\",\"Fee\"");

                    IEnumerable <Service> orderedServices = _services.OrderBy(s => s.Name);
                    foreach (Service svc in orderedServices)
                    {
                        sr.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\"", svc.Name, svc.Code, svc.Fee));
                    }
                }
            }
            catch (Exception)
            { 
                throw;
            }
        }


        /// <summary>
        /// Looks up and returns the current price for a service identified 
        /// by the serviceId.
        /// </summary>
        /// <param name="serviceId"> The unique identifier for the particular service.</param>
        /// <returns>
        /// The price for a particular service, identified by the service id.
        /// </returns>
        /// <exception cref="Exception">If no services are found, invalid serviceId format.</exception>
        public decimal PriceForService(int serviceId)
        {
            if (_services == null || _services.Count == 0)
            {
                throw new Exception("No services available.  Did you forget to load the services?");
            }
            else
            {
                Service svc = _services.Where(s => s.Code == serviceId).FirstOrDefault();
                if (svc != null)
                {
                    return svc.Fee;
                }

                string message = InvalidServiceIdMessage(serviceId);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Returns the name of the service for provided serviceId.
        /// </summary>
        /// <param name="serviceId">
        /// The unique identifier for the service.</param>
        /// <returns>
        /// The name of the service with the provided serviceId.  If the serviceId is 
        /// invalid, or if the service is not found, error messages will be returned 
        /// instead of the name of the service.
        /// </returns>
        public string NameOfService(int serviceId)
        {
            if (_services == null || _services.Count == 0)
            {
                throw new Exception("No services available.  Did you forget to load the services?");
            }

            string message = InvalidServiceIdMessage(serviceId);
            if (message == null)
            {
                // check if the service exists and return appropriate values.
                Service match = _services.Where(s => s.Code == serviceId).FirstOrDefault();
                if (match != null)
                {
                    message = match.Name;
                }                
            }

            return message;
        }

        // precondition: _services is not null and _services.Count > 0
        private string InvalidServiceIdMessage(int serviceId)
        {
            // used to check the length.
            string svcId = serviceId.ToString();
            if (svcId.Length != 6)
            {
                return ("Service codes must be 6-digit numbers.");
            }
            else if (_services.Where(s => s.Code == serviceId).FirstOrDefault() == null)
            {
                return (string.Format("Service code {0} not found.", serviceId));
            }
            else
            {
                return null;
            }
        }

    }
}