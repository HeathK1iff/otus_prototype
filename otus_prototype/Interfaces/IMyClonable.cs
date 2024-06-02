namespace otus_prototype.Interfaces;

internal interface IMyClonable<out T> where T : class
{
    T CloneObject();
}
