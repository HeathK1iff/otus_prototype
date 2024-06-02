using otus_prototype.Interfaces;

namespace otus_prototype.Entity;

internal class Person : IMyClonable<Person>, ICloneable
{
    public int Id { get; set; }
    public string Name { get; set; }


    public Person()
    {

    }

    public Person(Person person)
    {
        Id = person.Id;
        Name = person.Name;
    }


    public Person CloneObject()
    {
        return new Person(this);
    }

    public override string ToString()
    {
        return $"{Id},{Name}";
    }


    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name);
    }

    public override bool Equals(object obj)
    {
        return obj is Person person &&
               Id == person.Id &&
               Name == person.Name;
    }

    public virtual object Clone()
    {
        return MemberwiseClone();
    }
}
