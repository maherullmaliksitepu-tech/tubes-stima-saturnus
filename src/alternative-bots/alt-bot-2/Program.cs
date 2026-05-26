using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;
using System;

public class AggressiveBot : Bot
{
    static void Main(string[] args)
    {
        new AggressiveBot().Start();
    }

    AggressiveBot() : base(BotInfo.FromFile("AggressiveBot.json")) { }

    public override void Run()
    {
        while (IsRunning)
        {
            TurnRadarRight(360);
            Forward(150);
        }
    }

    public override void OnScannedBot(ScannedBotEvent e)
    {
        TurnGunRight(BearingTo(e.X, e.Y));

        if (GunHeat == 0)
            Fire(3); // selalu kuat

        Forward(50); // kejar musuh
    }
}