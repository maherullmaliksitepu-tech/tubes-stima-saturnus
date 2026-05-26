using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;
using System;

public class RandomBot : Bot
{
    static void Main(string[] args)
    {
        new RandomBot().Start();
    }

    Random rand = new Random();

    RandomBot() : base(BotInfo.FromFile("RandomBot.json")) { }

    public override void Run()
    {
        AdjustGunForBodyTurn = true;
        AdjustRadarForGunTurn = true;

        while (IsRunning)
        {
            TurnRadarRight(360);

            Forward(rand.Next(50, 150));
            TurnRight(rand.Next(0, 360));
        }
    }

    public override void OnScannedBot(ScannedBotEvent e)
    {
        TurnGunRight(BearingTo(e.X, e.Y));

        if (GunHeat == 0)
            Fire(rand.Next(1, 3));
    }
}