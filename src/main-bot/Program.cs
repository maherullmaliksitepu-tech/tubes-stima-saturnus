using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;
using System;

public class PredatorProBot : Bot
{
    static void Main(string[] args)
    {
        new PredatorProBot().Start();
    }

    PredatorProBot() : base(BotInfo.FromFile("PredatorProBot.json")) { }

    public override void Run()
    {
        // ✅ FIX DI SINI (hapus "Is")
        AdjustGunForBodyTurn = true;
        AdjustRadarForGunTurn = true;

        while (IsRunning)
        {
            TurnRadarRight(360);
            Forward(100);

            if (X < 100 || X > ArenaWidth - 100 ||
                Y < 100 || Y > ArenaHeight - 100)
            {
                TurnRight(90);
            }
        }
    }

    public override void OnScannedBot(ScannedBotEvent e)
    {
        double bearing = BearingTo(e.X, e.Y);

        TurnGunRight(bearing);

        double distance = DistanceTo(e.X, e.Y);

        if (GunHeat == 0)
        {
            if (distance < 100)
                Fire(3);
            else if (distance < 300)
                Fire(2);
            else
                Fire(1);
        }

        TurnRight(30);
    }

    public override void OnHitByBullet(HitByBulletEvent e)
    {
        TurnRight(90);
        Forward(100);
    }
}