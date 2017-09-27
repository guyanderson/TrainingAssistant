using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingHelper.Models;

namespace TrainingHelper.Helpers
{
   
    public class FabHelper
    {
        private TrainingHelperDbContext db = new TrainingHelperDbContext();

        public bool isBayCertified(int target, List<Tool> tools) {
            List<Oper> opers = GetAllOperators();

            List<int> certsReq = GetCertIds(tools);
            
            

            return true;   
        }

        public List<int> GetCertIds(List<Tool> tools) {
            List<int> result = new List<int>();

            foreach (Tool tool in tools) {
                result.Add(tool.CertificationId);
            }

            return result;
        }

        public List<Oper> GetAllOperators() {
            List<Oper> result = new List<Oper>();
            
            result = db.Operators.ToList();

            return result;
        }

       
    }
}
