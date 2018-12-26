using System;
using System.Threading;

namespace Delegates
{

    internal class Program
    {

        enum typeAttack
        {
            Rage = 0,
            Buzova = 1,
            Gloom = 2
        }

        struct Attack
        {

            public string attackInfo;
            public int damage;
            public ConsoleColor colorTalk;

        }

        private static typeAttack GetRandomTypeAttack()
        {
            int indexTypeAttack = DateTime.Now.Millisecond % 3;
            
            return (typeAttack)indexTypeAttack;
        }
        
        private static Attack CreateAttack(typeAttack typeOfAttack)
        {

            Attack BossAttack = new Attack();
            
            if (typeOfAttack == typeAttack.Rage)
            {
                
                BossAttack.damage = 100;
                BossAttack.attackInfo = "Босс атаковал с немыслимой яростью своими руками";
                BossAttack.colorTalk = ConsoleColor.DarkRed;
                
            } else if (typeOfAttack == typeAttack.Buzova)
            {
                
                BossAttack.damage = 140;
                BossAttack.attackInfo = "Босс исполнил новый альбом Ольги бузовой";
                BossAttack.colorTalk = ConsoleColor.DarkMagenta;
                
            } else if (typeOfAttack == typeAttack.Gloom)
            {
                
                BossAttack.damage = 80;
                BossAttack.attackInfo = "Босс приуныл и рассказал вам о своём долгом пути и дал пару советов, после выпил ритуальный стопарь боярки";
                BossAttack.colorTalk = ConsoleColor.DarkGray;
                
            }
            else
            {
                BossAttack.damage = 0;
                BossAttack.attackInfo = "Неизвестная атака";
                BossAttack.colorTalk = ConsoleColor.Red;
            }

            return BossAttack;

        }
        
        private static void BossAttack(Attack BossAttack, ref int Health, ref int Armor)
        {

            ConsoleColor oldColor = Console.ForegroundColor;
            
            Console.ForegroundColor = BossAttack.colorTalk;
            Console.WriteLine(BossAttack.attackInfo);
            
            Console.ForegroundColor = oldColor;

            Health = Health - (BossAttack.damage - Armor);
        }

        private static void InformPlayer(string info, ConsoleColor infoColor)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = infoColor;
            Console.WriteLine(info);
            Console.ForegroundColor = oldColor;
        }
        
        public static void Main(string[] args)
        {
           
            InformPlayer("Босс может атаковать в двух режимах: все атаки по очереди и случайной атакой", ConsoleColor.Yellow);
            
            int Health = 1000;
            int Armor = 20;

            bool isRandomAttack = (DateTime.Now.Millisecond % 2) == 0;

            InformPlayer("Босс будет атаковать: " + (isRandomAttack ? "случайно" : "все атаки по очереди"), ConsoleColor.Yellow);
            InformPlayer("Нажмите enter для начала боя", ConsoleColor.Green);
            Console.ReadLine();
            
            int attackNumber = 0;
            while (Health > 0)
            {
                Console.Clear();
  
                InformPlayer("У вас здоровья: " + Health, ConsoleColor.Red);
   
                Attack attackData = CreateAttack(isRandomAttack ? GetRandomTypeAttack() : (typeAttack) attackNumber);
                BossAttack(attackData, ref Health, ref Armor);
                                
                attackNumber++;
                attackNumber = attackNumber > 2 ? 0 : attackNumber;
                
                Thread.Sleep(4000);
            }
            
            InformPlayer("Бой закончен, вы погибли", ConsoleColor.DarkGray);
        }
    }
}