using Newtonsoft.Json;
using oncast_taos.src.exception;
using oncast_taos.src.model;
using System;
using System.Collections.Generic;
using System.IO;

namespace oncast_taos.src
{
    public class Configuration
    {
        private static List<Order> order;
        private static Configuration instance;
        public static Configuration Instance
        {
            get
            {
                if (instance == null)
                    instance = new Configuration();

                return instance;
            }
        }

        public Configuration()
        {
            loadConfigurationFile("order.config");
        }

        public void loadConfigurationFile(String file)
        {
            try
            {
                using (StreamReader r = new StreamReader(file))
                    loadConfiguration(r.ReadToEnd());
            }
            catch (Exception ex)
            {
                throw new OrderingException("Order.config cant be read.", ex);
            }
        }

        public void loadConfiguration(String json)
        {
            if (String.IsNullOrEmpty(json))
                throw new OrderingException("Order.config cant be Null or Empty.");

            try
            {
                order = JsonConvert.DeserializeObject<List<Order>>(json);
            }
            catch (Exception ex)
            {
                throw new OrderingException("Invalid Order.config content.", ex);
            }
        }

        public List<Order> Order
        {
            get
            {
                return order;
            }
        }
    }
}
