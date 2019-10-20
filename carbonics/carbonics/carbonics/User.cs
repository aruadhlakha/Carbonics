using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace carbonics
{
    public class User
    {
        private int timeTillRefresh = 0;
        private int level = 0;
        private int numTaskspDay=0;
        private int TasksCompleted = 0;
        private int XPcount = 0;
        private String name;
        //list of tasks per day
        private List<Task> tasksInProgress = new List<Task>();

        //list of 20 tasks 
        Task[] taskList;
        Random rand = new Random();

        public User(int level, int xp, int numTaskspDay, string name, int timeTillRefresh)
        {
            this.timeTillRefresh = timeTillRefresh;
            this.level = level;
            XPcount = xp;
            this.numTaskspDay = numTaskspDay;
            tasksInProgress = new List<Task>();
            int count = 0;
            while(Application.Current.Properties.ContainsKey("taskd" + count))
            {
                string desc = (string)Application.Current.Properties["taskd" + count];
                int exp = (int)Application.Current.Properties["taskc" + count];
                var t = new Task(desc, exp);
                tasksInProgress.Add(t);
                count++;
            }
            this.name = name;
            taskList = taskAssignment();
        }
        //returns the level number and calculates 
        //the level check based on the current XP
        public int Level()
        {
            //stores the XP required to go the next stage    
            int XPreq = calcXP();
            if (XPcount > XPreq){
                level++;
            }
            return this.level;
        }
        //returns the value of XP required to 
        //reach next XP
        private int calcXP()
        {
            return (int)(100 + 100 * (level +1));
        }
        public String Name()
        {
            return name;
        }

        //swipe right changes the status of the task and
        //changes the XPcount
        //along with increasing the TasksCompleted
        public List<Task> swipeRight(int num)
        {
            tasksInProgress[num].SwipeRight();
            XPcount += tasksInProgress[num].xp();
            TasksCompleted++;
            /*for (int i = 0; i < numTaskspDay; i++)
            {
                if (tasksInProgress[i].checkComp() && !(TasksCompleted>95))
                {
                    bool compare = false;
                    do
                    {
                        compare = true;
                        tasksInProgress[i] = taskList[this.rand.Next(0, 10)];
                        for (int j = 0; j < i; j++)
                        {
                            if (tasksInProgress[i].xp() == tasksInProgress[j].xp())
                            {
                                compare = false;
                            }
                        }
                    } while (compare != true);
                }
                else if (tasksInProgress[i].checkComp() && (TasksCompleted > 95))
                {
                    for (int j = i; j < numTaskspDay-1; j++)
                    {
                        tasksInProgress[j] = tasksInProgress[j + 1];
                        tasksInProgress[j + 1] = null;
                    }
                }
                else { }*/
            return tasksInProgress;
            }

        //swipes left denoting whether the task had been completed
        //or not and then accordingly increases the XP and the 
        //tasksCompleted count
        public List<Task> swipeLeft(int num)
        {
            tasksInProgress[num].SwipeLeft();
            XPcount += (int)Math.Round(0.25 * tasksInProgress[num].xp());
            return tasksInProgress;
        }

        //returns taskCount
        public int TaskCount()
        {
            return TasksCompleted;
        }
        public int XPCount()
        {
            return XPcount;
        }

        //selects the tasks for the day 
        public List<Task> selectTasks(Task selectTask)
        {
            tasksInProgress.Add(selectTask);
            return tasksInProgress;
        }
            //returns the FIRST list of tasks so that it can 
            //be implemented on the UI and the user can pick 
            //from a list of tasks
            public Task[] fDisplayTasks()
            {
            Task[] displayList=new Task[numTaskspDay];
            for (int i= 0;i< numTaskspDay;i++){
                bool compare = false;
                do
                {
                    compare = true;
                    displayList[i] = taskList[this.rand.Next(0, 20)];
                    for (int j = 0; j < i; j++)
                    {
                        if (displayList[i].xp() == displayList[j].xp())
                        {
                            compare = false;
                        }
                    }
                } while (compare != true);
            }
            return displayList;
        }

        //tasks showed on the user screen
        public List<Task> displayTasks()
        {
            return tasksInProgress;
        }
        //at the end of the day, this automatically turns all
        //the XP values to 0 giving no addition to user values
        public List<Task> setAllToTrue()
        {
            for (int i = 0; i < tasksInProgress.Count; i++)
            {
                tasksInProgress[i].SwipeLeft();
            }
            return tasksInProgress;
        }

        public void RemoveTask(Task task)
        {
            if (tasksInProgress.Contains(task)) tasksInProgress.Remove(task);
        }
            //defines a list of initial 20 tasks
            //10 remaining to be added
            private Task[] taskAssignment()
            {
            taskList = new Task[20];
            taskList[0] = new Task("Switch off all the appliances \nbefore going to bed", 20);
            taskList[1] = new Task("Ditch the car and use a bike or bus \nto get to work", 80);
            taskList[2] = new Task("Use one less plastic bottle or can today", 30);
            taskList[3] = new Task("Challenge a friend to a task!", 125);
            taskList[4] = new Task("Save a gallon of water today", 120);
            taskList[5] = new Task("Switch off all the lights \nin the house for an hour", 90);
            taskList[6] = new Task("Don't use any paper napkins today", 50);
            taskList[7] = new Task("Recycle as much stuff as you can today", 70);
            taskList[8] = new Task("Plant a tree today!", 200);
            taskList[9] = new Task("Get together with your friends and \nclean up the local park", 150);
            taskList[10] = new Task("Carpool with your friends and save fuel", 100);
            taskList[11] = new Task("Make a compost for biodegradable waste", 250);
            taskList[12] = new Task("Carry a reusable bag to the supermarket", 45);
            taskList[13] = new Task("Switch the bulbs in your house for \nmore efficient ones", 105);
            taskList[14] = new Task("If it's sunny outside, use a clothsline \ninstead of the dryer", 75);
            taskList[15] = new Task("Shorten your shower time by 10 minutes", 55);
            taskList[16] = new Task("Reduce your printer use as \nmuch as possible today", 80);
            taskList[17] = new Task("Use ebill or etickets instead of a paper ones", 30);
            taskList[18] = new Task("Use rechargeable batteries \ninstead of normal ones", 65);
            taskList[19] = new Task("Share this app with your friends and family!", 190);
            return taskList;
        }
    }
}
