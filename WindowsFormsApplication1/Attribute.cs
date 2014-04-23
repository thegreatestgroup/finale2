using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class Attribute<T>
    {
        private T value;
        
        public bool IsDirty
        {
            get;
            private set;
        }

        public bool IsLike
        {
            get;
            set;
        }


        public T Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                this.IsDirty = true;
            }
        }


    };
}
