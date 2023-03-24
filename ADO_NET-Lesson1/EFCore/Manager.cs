using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NET_Lesson1.EFCore
{
    public class Manager
    {
        public Guid Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Secname { get; set; }
        public Guid IdMainDep { get; set; }
        public Guid? IdSecDep { get; set; }
        public Guid? IdChief { get; set; }
        public DateTime? DeleteDt { get; set; }

        /// Navigation Properties ///
        public Department MainDep { get; set; }
        public Department SecDep { get; set; }
        public List<Sale> Sales { get; set; }
        public List<Product> Products { get; set; }
    }
}
