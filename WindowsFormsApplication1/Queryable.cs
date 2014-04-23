using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace WindowsFormsApplication2
{
    public abstract class Queryable
    {
        //This should hold an Attribute where object is.
        protected Dictionary<string, Object> columns = new Dictionary<string, Object>();

        public abstract void loadRow(DataRow row);
        public abstract void save();
        public abstract DataTable search();
    };

}
