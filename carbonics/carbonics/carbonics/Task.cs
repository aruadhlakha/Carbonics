using System;
using System.Collections.Generic;
using System.Text;

namespace carbonics
{
    class Task
    {
        String desc;
        int XP;
        bool check=false;
        char color = 'y';
        public Task(String description, int xp)
        {
            desc = description;
            XP = xp;
            color = 'y';
        }
        public bool checkComp()
        {
            return check; 
        }
        public int SwipeRight()
        {
            check = true;
            color = 'g';
            return 0;
        }
        public int SwipeLeft()
        {
            check = true;
            color = 'r';
            return 0;
        }
        public int xp()
        {
            return this.XP;
        }
    }
}
