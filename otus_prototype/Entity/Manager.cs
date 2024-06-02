using otus_prototype.Interfaces;

namespace otus_prototype.Entity;

internal class Manager : Employee, IMyClonable<Manager>
{
    public List<Employee> Employees { get; set; }


    public Manager(Manager manager) : base(manager)
    {
        Employees = new List<Employee>(manager.Employees.Select(f => new Employee(f)).ToArray());
    }

    public Manager()
    {
    }

    public override string ToString()
    {
        return $"{base.ToString()},[{string.Join(',', Employees)}]";
    }

    public new Manager CloneObject()
    {
        return new Manager(this);
    }

    
    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Employees.GetHashCode());
    }

    public override bool Equals(object obj)
    {
        return obj is Manager manager &&
               Id == manager.Id &&
               Name == manager.Name &&
               Position == manager.Position &&
               Payscale == manager.Payscale &&
               EqualityComparer<List<Employee>>.Default.Equals(Employees, manager.Employees);
    }

    public override object Clone()
    {
        var manager =  base.Clone() as Manager;
        
        if (Employees != null)
        {
            manager.Employees = new List<Employee>(Employees.Select(f => new Employee(f)).ToArray());
        }

        return manager;
    }
}
