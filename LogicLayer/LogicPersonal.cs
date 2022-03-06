using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;

namespace LogicLayer
{
    public class LogicPersonal
    {
        public static List<EntityPersonal> LLPersonalList()
        {
            return DALPersonal.PersonalList();
        }
        public static int LLAddPersonel(EntityPersonal p)
        {
            if (p.Name != "" && p.Surname != "" && p.City != "" && p.Duty != "" && p.Salary >= 4250 && p.Name.Length >= 2)
            { 
                return DALPersonal.AddPersonal(p);
            }
            else
            {
                return -1;
            }
        }

        public static bool LLDelPersonal(int d)
        {
            if(d>=1)
            {
                return DALPersonal.DelPersonal(d);
            }
            else
            { 
                return false;
            }
        }
        
        public static bool LLUpdPersonal(EntityPersonal u)
        {
            if(u.Name != "" && u.Surname != "" && u.City != "" && u.Duty != "" && u.Salary >= 4250 && u.Name.Length >= 2)
            {
                return DALPersonal.UpdPersonal(u);
            }
            else
            {
                return false;
            }
        }
    }
}
