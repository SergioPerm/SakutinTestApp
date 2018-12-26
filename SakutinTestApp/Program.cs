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

            Health = Health - (100 - Armor);
        }
        
        public static void Main(string[] args)
        {
            
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Босс может атаковать в двух режимах: все атаки по очереди и случайной атакой");
            Console.ForegroundColor = oldColor;

            int Health = 1000;
            int Armor = 20;

            bool isRandomAttack = (DateTime.Now.Millisecond % 2) == 0;

            oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Босс будет атаковать: " + (isRandomAttack ? "случайно" : "все атаки по очереди"));
            Console.ForegroundColor = oldColor;

            oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Нажмите enter для начала боя");
            Console.ForegroundColor = oldColor;
            Console.ReadLine();

            int attackNumber = 0;
            while (Health > 0)
            {
                Console.Clear();
                oldColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("У вас здоровья: " + Health);
                Console.ForegroundColor = oldColor;
   
                Attack attackData = CreateAttack(isRandomAttack ? GetRandomTypeAttack() : (typeAttack) attackNumber);
                BossAttack(attackData, ref Health, ref Armor);
                                
                attackNumber++;
                attackNumber = attackNumber > 2 ? 0 : attackNumber;
                
                Thread.Sleep(4000);
            }

            oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Бой закончен, вы погибли");
            Console.ForegroundColor = oldColor;
        }
    }
}