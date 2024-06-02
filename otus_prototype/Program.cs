using otus_prototype.Entity;

namespace Application;

//Описание: Есть 3 класса Person, Emmployee, Manager. Между ними представлена цепочка наследования
//где супер класс "Персона" (Person) содержит базовые поля Id, Name. Данный класс пораждает класс "Работник" (Employee)
//и содержит поля "Зарплатная ставка" (Payscale) и "Должность" (Position). Каждый класс реализуют обобщеный интерфейс IMyClonable<T>
//и IClonable для поддержки клонирования 

public sealed class Program
{
    public static void Main(string[] args)
    {
        var program = new Program();
        program.Run();
    }

    public Program()
    {
    }

    public void Run()
    {
        Console.WriteLine("Otus, Prototype pattern");
        Test();
    }


    public void Test()
    {
        //Тест поверхностного клонирования (тест Employee тип содержит, только значимые типы)
        ShallowClone();

        //Тест глубокого клонирования (тест Employee тип содержит, только значимые типы)
        DeepClone();

        //Тест поверхностного клонирования (тест Employee тип содержит, только значимые типы)
        ShallowClonnableClone();

        //Тест глубокого клонирования (тест Employee тип содержит, только значимые типы)
        DeepClonnableClone();
    }


    public void ShallowClone()
    {
        Console.WriteLine("Shallow clone, IMyClonnable");

        //Создаем экземпляр Employee класса
        var employee = new Employee()
        {
            Id = 1,
            Name = "John",
            Payscale = "Junior Cabinboy",
            Position = "Cabinboy"
        };

        //Клонируем обьект через интерфейс IMyClonable
        var clonedEmp1 = employee.CloneObject();


        //Проверка по ссылкам что объекты разные *Для демонстрации*
        if (!Object.ReferenceEquals(clonedEmp1, employee))
        {
            Console.WriteLine("It is different objects");
        }

        //Сравниваем экземпляры обьектов. Методы Equals переропределены
        if (employee.Equals(clonedEmp1))
        {
            Console.WriteLine("Employees are equal");
        }
    }

    public void DeepClone()
    {
        Console.WriteLine("Deep clone, IMyClonnable");

        //Создаем экземпляр Manager класса, с сылочным типом List<Employee>
        var manager = new Manager()
        {
            Id = 1,
            Name = "Peter",
            Payscale = "Payscale",
            Position = "Test",
            Employees = new List<Employee>
            {
                new Employee()
                {
                    Id = 1,
                    Name = "Jack",
                    Position = "Position#1",
                    Payscale = "Payscale#1"
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Peter",
                    Position = "Position#2",
                    Payscale = "Payscale#2"
                }
            }
        };

        var cloneMgr1 = manager.CloneObject();

        //Проверка по ссылкам что объекты разные *Для демонстрации*
        if (!Object.ReferenceEquals(cloneMgr1, manager))
        {
            Console.WriteLine("It is different objects");
        }

        //Сравниваем экземпляры обьектов. Методы Equals переропределены
        if (manager.Equals(cloneMgr1))
        {
            Console.WriteLine("Manager(s) are equal");
        }
    }

    public void ShallowClonnableClone()
    {
        Console.WriteLine("Shallow clone, IClonnable");

        //Создаем экземпляр Employee класса
        var employee = new Employee()
        {
            Id = 1,
            Name = "John",
            Payscale = "Junior Cabinboy",
            Position = "Cabinboy"
        };

        //Клонируем обьект через интерфейс IClonable
        var clonedEmp1 = employee.Clone() as Employee;


        //Проверка по ссылкам что объекты разные *Для демонстрации*
        if (!Object.ReferenceEquals(clonedEmp1, employee))
        {
            Console.WriteLine("It is different objects");
        }

        //Сравниваем экземпляры обьектов. Методы Equals переропределены
        if (employee.Equals(clonedEmp1))
        {
            Console.WriteLine("Employees are equal");
        }
    }

    public void DeepClonnableClone()
    {
        Console.WriteLine("Deep clone, IClonnable");

        var manager = new Manager()
        {
            Id = 1,
            Name = "Peter",
            Payscale = "Payscale",
            Position = "Test",
            Employees = new List<Employee>
            {
                new Employee()
                {
                    Id = 1,
                    Name = "Jack",
                    Position = "Position#1",
                    Payscale = "Payscale#1"
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Peter",
                    Position = "Position#2",
                    Payscale = "Payscale#2"
                }
            }
        };

        var cloneMgr1 = manager.Clone() as Manager;

        //Проверка по ссылкам что объекты разные *Для демонстрации*
        if (!Object.ReferenceEquals(cloneMgr1, manager))
        {
            Console.WriteLine("It is different objects");
        }

        //Сравниваем экземпляры обьектов. Методы Equals переропределены
        if (manager.Equals(cloneMgr1))
        {
            Console.WriteLine("Manager(s) are equal");
        }

    }

}
