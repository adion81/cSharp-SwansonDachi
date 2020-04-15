using System;

namespace SwansonDachi.Models
{
    public class Swanson
    {
        public int Happiness;
        public int Fullness;
        public int Energy;
        public int Meals;
        public string ImgUrl;
        public bool didWin
        {
            get
            {
                return Happiness >= 100 && Fullness >= 100 && Energy >= 100;
            }
        }
        public bool didLose
        {
            get
            {
                return Happiness <= 0 || Fullness <= 0;
            }
        }
        

        public Swanson()
        {
            Happiness = 20;
            Fullness = 20;
            Energy = 50;
            Meals = 3;
            ImgUrl = "ron-swanson.jpg";
        }

        public string Play()
        {
            ResetRon();
            if(Energy == 0)
            {
                return "Ron has no more energy.";
            }
            else if(Energy < 5)
            {
                Energy = 0;
            }
            else if(TwentyFiveChance())
            {
                Energy -=5;
                ImgUrl = "madRon.gif";
                return $"You accidentally shot Ron in the ear on a hunting trip you were not invited to.  Ron is not happy.";
            }
            else
            {
                Energy -=5;
            }
            Random rand = new Random();
            int hap = rand.Next(5,11);
            Happiness += hap;
            return $"You played with Ron and he gained a total of {hap}";
        }

        public string Feed()
        {
            ResetRon();
            if(Meals == 0)
            {
                return "Ron stares into the empty fridge.";
            }
            else if(TwentyFiveChance())
            {
                Meals --;
                ImgUrl = "banana.gif";
                return $"You gave Ron a banana.  He didn't like it and gained no Fullness.";
                
            }
            Random rand = new Random();

            Meals --;
            ImgUrl = "eatingRon.jpg";
            int full = rand.Next(5,11);
            Fullness += full;
            return $"Ron had a porterhouse and whiskey, gaining {full} Fullness.";
        }

        public string Work()
        {
            ResetRon();
            if(Energy == 0)
            {
                return "Ron has no energy.  Make him take a nap.";
            }
            else if( Energy < 5)
            {
                Energy = 0;
            }
            else
            {
                Energy -= 5;
            }
            Random rand = new Random();
            int work = rand.Next(1,4);
            Meals += work;
            return $"Ron locked himself in his office and gained {work} meals";
        }

        public string Sleep()
        {
            ResetRon();
            Happiness -= 5;
            Fullness -= 5;
            Energy += 15;
            return $"Ron took a nap in his office and gained 15 energy.";
        }

        static bool TwentyFiveChance()
        {
            Random rand = new Random();
            return rand.Next(0,101) <= 25;
        }

        public void ResetRon()
        {
            ImgUrl = "ron-swanson.jpg";

        }
    }
}