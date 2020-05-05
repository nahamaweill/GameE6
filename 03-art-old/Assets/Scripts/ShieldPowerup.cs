public class ShieldPowerup : Powerup {
    public override void activate(PlayerController player) {
        player.ActivateShield(duration);
    }
}
