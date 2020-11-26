using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer.Services
{
    public class PageService : IPageService
    {
        public void Message(string Message)
        {
            System.Windows.MessageBox.Show(Message); 
        }
    }
}
