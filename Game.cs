using Colia;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static Colia.Unit;

public class Game 
{ 
    public void Start()
    {
        Characters tb = new Characters("Trailblazer", 980, 20, 8);
        Characters dh = new Characters("DanHeng", 714, 25, 3);
        Characters m7 = new Characters("March7th", 857, 14, 6, true, 180);
        Boss cocolia = new Boss("Cocolia", 1307, 102, 10);
        Random random = new Random();

        tb.MaxHp = 980;
        dh.MaxHp = 714;
        m7.MaxHp = 857;
        cocolia.MaxHp = 1307;

        List<Unit> team = new List<Unit> { tb, dh, m7 };
        List<Unit> boss = new List<Unit> { cocolia };

        List<string> voiceLines = new List<string>()
    {
        "Tremble before my power.",
        "You are doomed to fail.",
        " Witness... the avalanche!"
    };

        List<string> voiceLinesTb = new List<string>()
    {
        "Fracture!",
        "Defend the weak.",
        "Flaming lance! Forward!"
    };

        List<string> voiceLinesDh = new List<string>()
    {
        "The truth of life and death, revealed in an instant.",
        "This body isn't that frail.",
        "Careless."
    };

        List<string> voiceLinesM7 = new List<string>()
    {
        "I told ya I could fight!",
        "Check out this awesome move~",
        "With me out here, how can we lose~"
    };

        Console.WriteLine("--------------Battle Start--------------");

        while (!cocolia.isDead && !(tb.isDead && dh.isDead && m7.isDead))
        {
            Console.WriteLine($"{cocolia.Name}      HP: {cocolia.Hp}/{cocolia.MaxHp}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"{tb.Name}  HP: {tb.Hp}/{tb.MaxHp}");
            Console.WriteLine($"{dh.Name}      Hp: {dh.Hp}/{dh.MaxHp}");
            Console.WriteLine($"{m7.Name}     Hp: {m7.Hp}/{m7.MaxHp}");
            Console.WriteLine("");
            Console.WriteLine("");


            if (!cocolia.isDead)
            {
                Console.WriteLine("Cocolia Turn!");
                Console.WriteLine("----------------------------------------");
                int attack = random.Next(0, 2);
                var alive = team.FindAll(mc => !mc.isDead);

                if (attack == 0)
                {
                    Unit target = alive[random.Next(alive.Count)];
                    int randomIndex = random.Next(voiceLines.Count);
                    Console.WriteLine($"-> {voiceLines[randomIndex]}");
                    cocolia.Attack(target);
                    Console.WriteLine("----------------------------------------");
                }
                else
                {
                    cocolia.UseUltimate(team, boss);
                    Console.WriteLine("----------------------------------------");
                }
                GameStatus(tb, dh, m7, cocolia);

            }

            if (!tb.isDead && !cocolia.isDead)
            {
                PlayerTurn(tb, team, boss);
                int randomIndex = random.Next(voiceLinesTb.Count);
                Console.WriteLine($"-> {voiceLinesTb[randomIndex]}");
                Console.WriteLine("----------------------------------------");

                GameStatus(tb, dh, m7, cocolia);
            }

            if (!dh.isDead && !cocolia.isDead)
            {
                PlayerTurn(dh, team, boss);
                int randomIndex = random.Next(voiceLinesDh.Count);
                Console.WriteLine($"-> {voiceLinesDh[randomIndex]}");
                Console.WriteLine("----------------------------------------");
                GameStatus(tb, dh, m7, cocolia);
            }

            if (!m7.isDead && !cocolia.isDead)
            {
                PlayerTurn(m7, team, boss);
                int randomIndex = random.Next(voiceLinesM7.Count);
                Console.WriteLine($"-> {voiceLinesM7[randomIndex]}");
                Console.WriteLine("----------------------------------------");
                GameStatus(tb, dh, m7, cocolia);
            }

            static void PlayerTurn(Characters character, List<Unit> team, List<Unit> boss)
            {
                Console.WriteLine($"{character.Name} Turn");
                Console.WriteLine("1.Basic Attack");
                Console.WriteLine("2.Ultimate");
                Console.WriteLine("----------------------------------------");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    character.Attack(boss[0]);
                }
                else if (option == "2")
                {
                    character.UseUltimate(team, boss);
                }
            }

            static void GameStatus(Characters tb, Characters dh, Characters m7, Boss cocolia)
            {
                if (cocolia.isDead)
                {
                    Console.WriteLine("-> The world that they promised...");
                    Console.WriteLine("VICTORY");
                }

                if (tb.isDead && dh.isDead && m7.isDead)
                {
                    Console.WriteLine("-> Try that again!");
                    Console.WriteLine("DEFEATED");
                }
            }
        }
    }
}
    
    

