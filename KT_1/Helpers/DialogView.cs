using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.DataAccessLayer
{
    public interface DialogView<T>
    {
        bool? ShowDialog(T viewModel);
    }
}
