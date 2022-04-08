using KT_1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_1.View.UserControls
{
    public class MenuItemData
    {
        public string Title { get; private set; }
        public Uri PageUri { get; private set; }
        public RelayCommand ClickCommand { get; private set; }


        public MenuItemData(string title, Uri pageUri)
        {
            Title = title;
            PageUri = pageUri;
        }

        public MenuItemData(string title, RelayCommand clickCommand)
        {
            Title = title;
            ClickCommand = clickCommand;

        }
    }
}
