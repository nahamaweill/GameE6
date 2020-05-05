public class TripleShotPowerup : Powerup {
    public override void activate(PlayerController player) {
        player.ActivateTripleShot(duration);
    }
}
