using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;
using System;

public class DefensiveBot : Bot
{
    static void Main(string[] args)
    {
        new DefensiveBot().Start();
    }

    DefensiveBot() : base(BotInfo.FromFile("DefensiveBot.json")) { }

    public override void Run()
    {
        while (IsRunning)
        {
            TurnRadarRight(360);
            Forward(80);
        }
    }

    public override void OnScannedBot(ScannedBotEvent e)
    {
        TurnGunRight(BearingTo(e.X, e.Y));

        double distance = DistanceTo(e.X, e.Y);

        if (GunHeat == 0)
        {
            if (distance < 150)
                Fire(2);
            else
                Fire(1);
        }

        Back(50); // menjauh
    }
}