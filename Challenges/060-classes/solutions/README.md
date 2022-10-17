# Namespaces und Klassen

## Klassen

1. 
    ```csharp
    class Program
    {
        static void Main(string[] args)
        {
            var dog = new Animal();
            
            Console.ReadKey();
        }
    }

    class Animal
    {

    }
    ```

2. 
    ```csharp
    class Animal
    {
        public void Speak()
        {
            Console.WriteLine("Der Hund sagt wuff!");
        }
    }
    ```

3. 
    ```csharp
    class Animal
    {
        public string Sound { get; set; }

        public void Speak()
        {
            Console.WriteLine("Der Hund sagt wuff!");
        }
    }
    ```

4. 
    ```csharp
    class Animal
    {
        public string Sound { get; set; }

        public Animal(string sound) {
            Sound = sound;
        }

        public void Speak()
        {
            Console.WriteLine($"Der Hund sagt {Sound}!");
        }
    }
    ```

5. 
    ```csharp
    class Animal
    {
        public string Sound { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Animal(string sound)
        {
            Sound = sound;
            DateOfBirth = DateTime.Now;
        }

        public Animal(string sound, DateTime dateOfBirth)
        {
            Sound = sound;
            DateOfBirth = dateOfBirth;
        }

        public void Speak()
        {
            Console.WriteLine("Der Hund sagt wuff!");
        }
    }
    ```

6. 
    ```csharp
    class Animal
    {
        public string Sound { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Animal(string sound)
        {
            Sound = sound;
            DateOfBirth = DateTime.Now;
        }

        public Animal(string sound, DateTime dateOfBirth)
        {
            Sound = sound;
            DateOfBirth = dateOfBirth;
        }

        public void Speak()
        {
            Console.WriteLine("Der Hund sagt wuff!");
        }

        public int GetAge()
        {
            return DateOfBirth.Year - DateTime.Now.Year;
        }
    }
    ```

## Namespaces

1.
    ```csharp
    namespace GrossWeber
    {
        class Program
        {
            static void Main(string[] args)
            {
                var trainer = new GrossWeber.Trainings.Trainer("Robert Meyer");
                var course = new GrossWeber.Trainings.Course("C# Grundlagen");
                GrossWeber.Trainings.Management.BookingTrainer.Booking(trainer.Name, course.Title);

                Console.ReadKey();
            }
        }
    }

    namespace GrossWeber.Trainings
    {
        public class Trainer
        {
            public string Name { get; set; }

            public Trainer(string name)
            {
                Name = name;
            }
        }

        public class Course
        {
            public string Title { get; set; }

            public Course(string title)
            {
                Title = title;
            }
        }
    }

    namespace GrossWeber.Trainings.Management
    {
        public static class BookingTrainer
        {
            public static void Booking(string trainer, string course) =>
                Console.WriteLine($"{trainer} wurde für {course} gebucht.");
        }
    }
    ```

2.
    ```csharp
    namespace GrossWeber
    {
        using TrainerInfo = GrossWeber.Trainings.Trainer;
        using CourseInfo = GrossWeber.Trainings.Course;

        class Program
        {
            static void Main(string[] args)
            {
                var trainer = new TrainerInfo("Robert Meyer");
                var course = new CourseInfo("C# Grundlagen");
                GrossWeber.Trainings.Management.BookingTrainer.Booking(trainer.Name, course.Title);

                Console.ReadKey();
            }
        }
    }

    // ...
    ```

3.
    ```csharp
    namespace GrossWeber
    {
        using GrossWeber.Trainings;
        using GrossWeber.Trainings.Management;

        class Program
        {
            static void Main(string[] args)
            {
                var trainer = new Trainer("Robert Meyer");
                var course = new Course("C# Grundlagen");
                BookingTrainer.Booking(trainer.Name, course.Title);

                Console.ReadKey();
            }
        }
    }
    ```

## Das ferngesteuerte Auto

Die Lösung findest du im Order **Challenges/060-classes/solutions/01_RemoteCar**.


## Der Getränkeautomat

Die Lösung findest du im Order **Challenges/060-classes/solutions/02_Getraenkeautomat**.
