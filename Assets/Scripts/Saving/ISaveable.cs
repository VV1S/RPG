namespace Assets.Scripts.Saving
{
    internal interface ISaveable
    {
        object CaptureState();

        void RestoreState(object state);
    }
}
