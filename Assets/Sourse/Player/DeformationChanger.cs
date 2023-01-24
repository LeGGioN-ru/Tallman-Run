using static Gate;

public static class DeformationChanger
{
    public static void ChangePlayerDeformation(PlayerDeformation playerDeformation, DirectionDeformation directionDeformation, int value)
    {
        if (directionDeformation == DirectionDeformation.Width)
            playerDeformation.ChangeWidth(value);
        else if (directionDeformation == DirectionDeformation.Height)
            playerDeformation.ChangeHeight(value);
    }
}
