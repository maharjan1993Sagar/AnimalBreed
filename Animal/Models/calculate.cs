using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    public class calculate
    {
        public string[] CalculateDm(string weight, string pregnancy, string milkVolumn)
        {
            decimal wt = Convert.ToDecimal(weight);
            decimal vol = Convert.ToDecimal(milkVolumn);
            string[] result = new string[2];
            string dm = "0";

            if (vol <= 5)
            {
                dm = (Convert.ToDecimal(0.03) * wt).ToString("0.00");//2-4 of body wt
                result[0] = dm;
                result[1] = "Dry Concentrate should be less or equal to 40% of DM";
            }
            else if (vol > 5 && vol <= 10)
            {
                dm = (Convert.ToDecimal(0.03) * wt).ToString("0.00");//2-4 of body wt
                result[0] = dm;
                result[1] = "Dry Concentrate should be less or equal to 50% of DM";
            }
            else if (vol > 10 && vol <= 15)
            {
                dm = (Convert.ToDecimal(0.03) * wt).ToString("0.00");//2-4 of body wt
                result[0] = dm;
                result[1] = "Dry Concentrate should be less or equal to 60% of DM";

            }
            else if (vol > 15 && vol <= 50)
            {
                dm = (Convert.ToDecimal(0.03) * wt).ToString("0.00");//2-4 of body wt
                result[0] = dm;
                result[1] = "Dry Concentrate should be less or equal to 70% of DM";
            }
            else if (vol > 50)
            {
                dm = (Convert.ToDecimal(0.03) * wt).ToString("0.00");//2-4 of body wt
                result[0] = dm;
                result[1] = "Dry Concentrate should be less or equal to 70% of DM";
            }




            return result;
        }

    }
}
