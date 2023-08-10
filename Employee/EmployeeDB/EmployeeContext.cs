using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDB
{
  
        public class EmployeeContext
        {
        private EmployeeEntities _Ctx;

            public EmployeeContext()
            {
                _Ctx = new EmployeeEntities();
            }

            public EmployeeEntities Context
            {
                get
                {
                    return this._Ctx;
                }
            }

            public void Dispose()
            {
                if (_Ctx != null)
                    _Ctx.Dispose();
            }
        }
    }
