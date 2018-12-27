using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;

namespace Delegates
{

    internal class Program
    {

        private static void InformPlayer(string info, ConsoleColor infoColor)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = infoColor;
            Console.WriteLine(info);
            Console.ForegroundColor = oldColor;
        }

        public static BossAttack[] Attacks =
        {
            new BossAttack("Босс атаковал с немыслимой яростью своими руками", ConsoleColor.DarkRed, 100),
            new BossAttack("Босс исполнил новый альбом Ольги бузовой", ConsoleColor.DarkMagenta, 140),
            new BossAttack("Босс приуныл и рассказал вам о своём долгом пути и дал пару советов, после выпил ритуальный стопарь боярки", ConsoleColor.DarkGray, 80)
        }; 
        
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

                int AttackIndex = isRandomAttack ? DateTime.Now.Millisecond % 3 : attackNumber;
                
                BossAttack CurrentAttack = Attacks[AttackIndex];
                CurrentAttack.ApplyDamage(Armor, ref Health);
                CurrentAttack.ShowInfo();
                                                
                attackNumber++;
                attackNumber = attackNumber > 2 ? 0 : attackNumber;
                
                Thread.Sleep(4000);
            }
            
            InformPlayer("Бой закончен, вы погибли", ConsoleColor.DarkGray);
        }
    }

    class BossAttack
    {
        
        private string _damageInfo;
        private ConsoleColor _damageColor;
        private int _damage; 

        public BossAttack(string DamageInfo, ConsoleColor DamageColor, int Damage)
        {
            this._damageInfo = DamageInfo;
            this._damageColor = DamageColor;
            this._damage = Damage;
        }

        public void ApplyDamage(int Armor, ref int Health)
        {
            Health -= this._damage - Armor;
        }

        public void ShowInfo()
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            
            Console.ForegroundColor = this._damageColor;
            Console.WriteLine(this._damageInfo);
            
            Console.ForegroundColor = oldColor;
        }
    }  
}