using System;
using System.Collections.Generic;
using System.Text;

namespace carbonics
{
    class User
    {   
        private int level = 0;
        private int numTaskspDay=0;
        private int TasksCompleted = 0;
        private int XPcount = 0;
        private String name;
        //list of tasks per day
        private Task[] tasksInProgress;
        //list of 20 tasks 
        Task[] taskList;
        Random rand = new Random();

        public User(int numTaskspDay, string name)
        {
            this.numTaskspDay = numTaskspDay;
            tasksInProgress = new Task[numTaskspDay];
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
        public void swipeRight(int num)
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
            }

        //swipes left denoting whether the task had been completed
        //or not and then accordingly increases the XP and the 
        //tasksCompleted count
        public void swipeLeft(int num)
        {
            tasksInProgress[num].SwipeLeft();
            XPcount += (int)Math.Round(0.25 * tasksInProgress[num].xp());
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
        public void selectTasks(Task selectTask)
        {
            for (int i = 0; i < numTaskspDay; i++)
            {
                if (tasksInProgress[i] == null)
                {
                    tasksInProgress[i] = selectTask;
                    break;
                }
            }
        }
            //returns the FIRST list of tasks so that it can 
            //be implemented on the UI and the user can pick 
            //from a list of tasks
            public Task[] fDisplayTasks()
            {
            Task[] displayList=new Task[numTaskspDay];
            for (int i= 0;i< numTaskspDay; i++){
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
        public Task[] displayTasks()
        {
            Task[] toReturn;
            int countF= 0;
            for (int i = 0; i < numTaskspDay; i++)
            {
                if (tasksInProgress[i].checkComp() == false)
                {
                    countF++;
                }
            }
            toReturn = new Task[countF];
            int j = 0;
            for (int i = 0; i < numTaskspDay; i++)
            {
                if (tasksInProgress[i].checkComp() == false)
                {
                    toReturn[j] = tasksInProgress[i];
                }
            }
            return toReturn;
        }

            //defines a list of initial 20 tasks
            //10 remaining to be added
            private Task[] taskAssignment()
            {
            taskList = new Task[10];
            taskList[0] = new Task("Switch off all the appliances before going to bed", 50);
            taskList[1] = new Task("Ditch the car and use a bike or bus to get to work", 80);
            taskList[2] = new Task("Use one less plastic bottle or can today", 30);
            taskList[3] = new Task("Challenge a friend to a task!", 100);
            taskList[4] = new Task("Save a gallon of water today", 120);
            taskList[5] = new Task("Switch off all the lights in the house for an hour", 90);
            taskList[6] = new Task("Don't use any paper napkins today", 50);
            taskList[7] = new Task("Recycle as much stuff as you can today", 70);
            taskList[8] = new Task("Plant a tree today!", 200);
            taskList[9] = new Task("Get together with your friends and clean up the local park", 150);
                return taskList;
        }
    }
}
