using System;
using System.Collections.Generic;
using System.Text;

namespace carbonics
{
    class Task
    {
        String desc;
        bool check=false;    
        bool checkComp()
        {
            return check; 
        }
        int SwipeRight()
        {
            check = true;
            return 0;
        }
        int swipeLeft()
        {
            check = false;
            return 0;
        }
    }
}
