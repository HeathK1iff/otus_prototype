using otus_prototype.Interfaces;

namespace otus_prototype.Entity;

internal class Employee : Person, IMyClonable<Employee>, IEquatable<Employee>
{
    public Employee()
    {

    }

    public Employee(Employee employee) : base(employee)
    {
        Position = employee.Position;
        Payscale = employee.Payscale;
    }

    public string Position { get; set; }
    public string Payscale { get; set; }

    public override string ToString()
    {
        return $"{base.ToString()},{Position},{Payscale}";
    }

    public new Employee CloneObject()
    {
        return new Employee(this);
    }


    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Position, Payscale);
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Employee);    
    }

    public bool Equals(Employee other)
    {
        return other != null &&
               Id == other.Id &&
               Name == other.Name &&
               Position == other.Position &&
               Payscale == other.Payscale;
    }

    public override object Clone()
    {
        var employee = base.Clone() as Employee;
        
        employee.Position = Position;
        employee.Payscale = Payscale;

        return employee;
    }
}